using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class DTNode
    {
        private String result;
        private List<Example> trainingSet;
        private List<String> attrNames;
        private Dictionary<DTNode, Condition> children;
        private List<String> classes;

        public DTNode(List<Example> _trainingSet, List<String> _attributes, List<String> _classes)
        {
            attrNames = _attributes;
            children = new Dictionary<DTNode, Condition>();
            trainingSet = _trainingSet;
            classes = _classes;
            result = "";
        }

        public String getResult()
        {
            return result;
        }

        public void setResult(String result)
        {
            this.result = result;
        }

        public List<String> getAttrNames()
        {
            return attrNames;
        }

        public Dictionary<DTNode, Condition> getChildren()
        {
            return children;
        }

        public List<Example> getTrainingSet()
        {
            return trainingSet;
        }

        public void setAttrNames(List<String> attrNames)
        {
            this.attrNames = attrNames;
        }

        public void setChildren(Dictionary<DTNode, Condition> children)
        {
            this.children = children;
        }

        public void setTrainingSet(List<Example> trainingSet)
        {
            this.trainingSet = trainingSet;
        }

        public List<String> getClasses()
        {
            return classes;
        }

        public void setClasses(List<String> classes)
        {
            this.classes = classes;
        }
    }
}
