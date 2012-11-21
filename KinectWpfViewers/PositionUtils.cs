using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class PositionUtils
    {
        public static String getCommon(List<String> list)
        {
            String result="";
            int count;
                
            Dictionary<String, int> dictList = new Dictionary<String, int>();
            foreach (String s in list)
            {
                if (dictList.TryGetValue(s, out count))
                {
                    dictList[s] = count + 1;
                }
                else
                {
                    dictList.Add(s, 1);
                }
            }

            count = 0;
            foreach (KeyValuePair<String, int> entry in dictList)
            {
                if (entry.Value > count)
                {
                    result = entry.Key;
                }
            }
            return result;
        }
    }
}
