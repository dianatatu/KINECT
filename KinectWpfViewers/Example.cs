using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class Example
    {
        Dictionary<String, Double> attributes;
        String result;

        public Example()
        {
            attributes = new Dictionary<String, Double>();
        }

        public void add(String _name, Double _value)
        {
            attributes.Add(_name, _value);
        }

        public double getValue(String _name)
        {
            double value;
            if (attributes.TryGetValue(_name, out value))
            {
                return value;
            }
            Console.WriteLine("WRONG");
            return 0.0;
        }

        public void setResult(String result)
        {
            this.result = result;
        }

        public String getResult()
        {
            return result;
        }

        public Dictionary<String, Double> getAttributes()
        {
            return attributes;
        }

        public String toString()
        {
            String stringResult = "";
            foreach (KeyValuePair<String, Double> entry in attributes)
            {
                // do something with entry.Value or entry.Key
                stringResult += entry.Key + ": " + entry.Value + "\t";
            }
            return stringResult + "\t" + this.result;
        }

        public void setAttributes(Dictionary<String, Double> attributes)
        {
            this.attributes = attributes;
        }
    }
}
