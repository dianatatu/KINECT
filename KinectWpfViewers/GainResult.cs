using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class GainResult
    {
        private double gain;
        private int partitionIndex;

        public GainResult() { }

        public GainResult(double _gain, int _partitionIndex)
        {
            this.gain = _gain;
            this.partitionIndex = _partitionIndex;
        }

        public double getGain()
        {
            return gain;
        }

        public int getPartitionIndex()
        {
            return partitionIndex;
        }

        public void setGain(double gain)
        {
            this.gain = gain;
        }

        public void setPartitionIndex(int partitionIndex)
        {
            this.partitionIndex = partitionIndex;
        }
    }
}
