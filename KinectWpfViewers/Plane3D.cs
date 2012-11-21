using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class Plane3D
    {
        private Constants.planeType type;
        private double a;
        private double b;
        private double c;

        public Plane3D(Constants.planeType _type)
        {
            type = _type;
            getParameters(type);
        }

        private void getParameters(Constants.planeType _type)
        {
            switch (_type)
            {
                case Constants.planeType.XOY:
                    a = 0;
                    b = 0;
                    c = 1;
                    break;
                case Constants.planeType.XOZ:
                    a = 0;
                    b = 1;
                    c = 0;
                    break;
                case Constants.planeType.YOZ:
                    a = 1;
                    b = 0;
                    c = 0;
                    break;
                default:
                    break;
            }
        }

        public double getA()
        {
            return a;
        }

        public double getB()
        {
            return b;
        }

        public double getC()
        {
            return c;
        }

        public Constants.planeType getType()
        {
            return type;
        }
    
    }
}
