using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class ExampleComparator : IComparer<Example>
    {
        String attrName;
    
        public int Compare(Example o1, Example o2) {
            return (o1.getAttributes()[attrName] < o2.getAttributes()[attrName] ? -1 : 
                    (o1.getAttributes()[attrName] == o2.getAttributes()[attrName] ? 0 : 1));
        }

        public ExampleComparator(String __attrName)
        {
            this.attrName = __attrName;
        }
    }
}
