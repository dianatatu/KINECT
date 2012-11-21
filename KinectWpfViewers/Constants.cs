using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class Constants
    {
        public enum conditionType
        {
            EQ,
            LT,
            GEQT
        }

        public enum planeType
        {
            XOY,
            XOZ,
            YOZ
        }

        public enum stateType
        {
            INTERMEDIATE,
            FINAL
        }

        public static int SnapshotFrequency = 10;
        public static bool DEBUG = false;
    }
}
