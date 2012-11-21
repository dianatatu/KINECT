using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class DTUtils
    {
        public static void printTree(DTNode root)
        {
            if (root.getChildren().Count == 0)
                Console.WriteLine(" => " + root.getResult() + "\n");
            else
            {
                foreach (KeyValuePair<DTNode, Condition> entry in root.getChildren())
                {
                    // do something with entry.Value or entry.Key
                    Console.Write(entry.Value.getMember1() + " ");
                    switch (entry.Value.getOperator())
                    {
                        case Constants.conditionType.LT:
                            Console.Write(" < "); break;
                        case Constants.conditionType.GEQT:
                            Console.Write(" >= "); break;
                        default: break;
                    }
                    Console.Write(entry.Value.getMember2() + "\n");
                    printTree(entry.Key);
                }
            }
        }
        public static String findValueInTree(DTNode root, Example test)
        {
            if (root.getChildren().Count > 0)
            {
                double value;
                // foreach child
                foreach (KeyValuePair<DTNode, Condition> entry in root.getChildren())
                {
                    switch (entry.Value.getOperator())
                    {
                        case Constants.conditionType.GEQT:
                            if (test.getAttributes().TryGetValue(entry.Value.getMember1(), out value) == true)
                            {
                                if (value >= entry.Value.getMember2())
                                    return findValueInTree(entry.Key, test);
                            }
                            break;
                        case Constants.conditionType.LT:
                            if (test.getAttributes().TryGetValue(entry.Value.getMember1(), out value) == true)
                            {
                                if (value < entry.Value.getMember2())
                                    return findValueInTree(entry.Key, test);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return root.getResult();
        }



        public static void buildTree(DTNode root) {
        if (isTrivial(root) == true) {
            root.setResult(root.getTrainingSet()[0].getResult());
        }
        else if (root.getAttrNames().Count == 0) {
            // set as a result the most frequent class in training set
            Dictionary<String, int> classCount = new Dictionary<String, int>(); 
            foreach (String className in root.getClasses()) {
                classCount.Add(className, 0);
            }
            // get entropy of all training set
            foreach (Example example in root.getTrainingSet()) {
                int value;
                if (classCount.TryGetValue(example.getResult(), out value)) 
                {
                    classCount[example.getResult()] = value+1;
                }
                
            }     
            int maxCount = 0;
            String classResult = "";
            foreach(KeyValuePair<String, int> entry in classCount)
            {
                if (maxCount < entry.Value) {
                    maxCount = entry.Value;
                    classResult = entry.Key;
                }
            }
            
            root.setResult(classResult);
        }
        else {
            // find attribute with maximum gain
            GainResult gainResult = new GainResult();
            GainResult gainResultMax = new GainResult();
            gainResultMax.setGain(0.0);
            int resultIndex = 0;
            for (int i=0; i<root.getAttrNames().Count; i++) {
                gainResult = getGain(root.getTrainingSet(), root.getAttrNames()[i], root.getClasses());
                gainResult.setGain(getEntropy(root.getTrainingSet(), root.getClasses(), root.getAttrNames()[i], -1) - 
                        gainResult.getGain());
                if (gainResultMax.getGain() < gainResult.getGain()) {
                    gainResultMax.setGain(gainResult.getGain());
                    gainResultMax.setPartitionIndex(gainResult.getPartitionIndex());
                    resultIndex = i;
                }
            }
            String attributeNode = root.getAttrNames()[resultIndex];
            root.getAttrNames().RemoveAt(resultIndex);
            // sort training list by the attribute with maximum gain
            root.getTrainingSet().Sort(new ExampleComparator(attributeNode));
            // form children
            for (int i=0; i<2; i++)
            {
                List<String> newAttrNames = new List<String>();
                foreach (String str in root.getAttrNames()) {
                    newAttrNames.Add(str);
                }
                
                List<String> newClassNames = new List<String>();
                foreach (String str in root.getClasses()) {
                    newClassNames.Add(str);
                }
                DTNode child = new DTNode(new List<Example>(), newAttrNames, newClassNames);
                List<Example> newTrainingSet = new List<Example>();
                Condition condition = new Condition();
                if (i == 0) {
                    for (int p=0; p <= gainResultMax.getPartitionIndex(); p++) {
                        Example example = root.getTrainingSet()[p];
                        Example newExample = new Example();
                        // copy result
                        newExample.setResult(example.getResult());
                        // copy attribute values
                        Dictionary<String, Double> newAttributes = new Dictionary<String, Double>();
                        foreach (KeyValuePair<String, Double> entry in example.getAttributes())
                        {
                            newAttributes.Add(entry.Key, entry.Value);
                        }
                        newExample.setAttributes(newAttributes);                        
                        newTrainingSet.Add(newExample); 
                    }
                    condition.setOperator(Constants.conditionType.LT);                    
                }
                else {
                    for (int p=gainResultMax.getPartitionIndex()+1; p<root.getTrainingSet().Count; p++) {
                        Example example = root.getTrainingSet()[p];
                        Example newExample = new Example();
                        // copy result
                        newExample.setResult(example.getResult());
                        // copy attribute values
                        Dictionary<String, Double> newAttributes = new Dictionary<String, Double>();
                        foreach (KeyValuePair<String, Double> entry in example.getAttributes())
                        {
                            newAttributes.Add(entry.Key, entry.Value);
                        }
                        newExample.setAttributes(newAttributes);
                        newTrainingSet.Add(newExample);
                    }
                    condition.setOperator(Constants.conditionType.GEQT);
                }
                condition.setMember1(attributeNode);
                double leftValue = root.getTrainingSet()[gainResultMax.getPartitionIndex()].getValue(attributeNode);
                double rightValue = root.getTrainingSet()[gainResultMax.getPartitionIndex()+1].getValue(attributeNode);
                condition.setMember2((leftValue+rightValue)/2);                
                child.setTrainingSet(newTrainingSet);
                root.getChildren().Add(child, condition);                
                buildTree(child);
            }
        }
    }
        public static double getEntropy(List<Example> trainingSet, List<String> classNames, String attrName, int partitionIndex) 
        {        
        double entropy = 0.0;
        double entropyLeft = 0.0;
        double entropyRight = 0.0;
        Dictionary<String, int> classCount = new Dictionary<String, int>(); 
        Dictionary<String, int> classCountLT = new Dictionary<String, int>();
        Dictionary<String, int> classCountGEQT = new Dictionary<String, int>();
        
        foreach (String className in classNames) {
            classCount.Add(className, 0);
            classCountLT.Add(className, 0);
            classCountGEQT.Add(className, 0);
        }
        
        if (partitionIndex == -1) {
            // get entropy of all training set
            foreach (Example example in trainingSet) 
            {
                int value;
                if (classCount.TryGetValue(example.getResult(), out value))
                {
                    classCount[example.getResult()] = value + 1;
                }
                else
                {
                    Console.WriteLine("WROONG");
                }
            }        

            foreach (KeyValuePair<String, int> entry in classCount)
            {
                if (entry.Value != 0) 
                {
                    entropy -= (double)(entry.Value)/trainingSet.Count * ( (Math.Log((double)(entry.Value)/trainingSet.Count))/Math.Log(2)); 
                }
            }
            return entropy;
        }
        else {
            // get specific entropy 
            double attrValue = (trainingSet[partitionIndex].getValue(attrName) + trainingSet[partitionIndex+1].getValue(attrName)) / 2;
            foreach (Example example in trainingSet) {
                double value;
                int valueInt;
                if (example.getAttributes().TryGetValue(attrName, out value)) 
                {
                
                    if (value < attrValue)
                    {
                        if (classCountLT.TryGetValue(example.getResult(), out valueInt))
                        {
                            classCountLT[example.getResult()] = valueInt+1;
                        }
                    }
                    else
                    {
                        if (classCountGEQT.TryGetValue(example.getResult(), out valueInt))
                        {
                            classCountGEQT[example.getResult()] = valueInt+1;
                        }
                    }                    
                }
            }  
            int leftCount = partitionIndex+1;
            int rightCount = trainingSet.Count - leftCount;

            foreach (KeyValuePair<String, int> entry in classCountLT)
            {
                if (entry.Value != 0)
                    entropyLeft -= (double)(int)(entry.Value) / leftCount *
                            ((Math.Log((double)(int)(entry.Value) / leftCount)) / Math.Log(2));
                int value;
                if (classCountGEQT.TryGetValue(entry.Key, out value))
                {
                    if (value != 0)
                        entropyRight -= (double)(value) / rightCount *
                                ((Math.Log((double)(value) / rightCount)) / Math.Log(2));
                }
            }
            
            return ((double)leftCount/trainingSet.Count * entropyLeft) + ((double)rightCount/trainingSet.Count * entropyRight);
        }
    }
        public static GainResult getGain(List<Example> trainingSet, String attrName, List<String> classNames)
        {
            GainResult gainResult = new GainResult();
            // sort learning set by attr values
            trainingSet.Sort(new ExampleComparator(attrName));
            // for each possible partitioning, compute gain for attr
            double minEntropy = 0xffffff;
            for (int i = 0; i < trainingSet.Count - 1; i++)
            {
                if (trainingSet[i].getResult().Equals(trainingSet[i+1].getResult()) == false)
                {
                    double tempEntropy = getEntropy(trainingSet, classNames, attrName, i);
                    if (minEntropy > tempEntropy)
                    {
                        gainResult.setPartitionIndex(i);
                        minEntropy = tempEntropy;
                    }
                }
            }
            gainResult.setGain(minEntropy);
            return gainResult;
        }
        public static bool isTrivial(DTNode node)
        {
            for (int i = 0; i < node.getTrainingSet().Count - 1; i++)
            {                
                if (node.getTrainingSet()[i].getResult().Equals
                        (node.getTrainingSet()[i+1].getResult()) == false)
                    return false;
            }
            return true;
        }
   
    }
}
