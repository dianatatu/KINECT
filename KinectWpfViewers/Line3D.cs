using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class Line3D
    {
        /*
     * ecuatia dreptei:
     * x - x0 / l =
     * y - y0 / m = 
     * z - z0 / n
     */
        private double x0;
        private double l;
        private double y0;
        private double m;
        private double z0;
        private double n;

        public Line3D()
        {

        }

        public Line3D(Point3D A, Point3D B)
        {
            x0 = A.getX();
            l = B.getX() - A.getX();

            y0 = A.getY();
            m = B.getY() - A.getY();

            z0 = A.getZ();
            n = B.getZ() - A.getZ();
        }

        public double getL()
        {
            return l;
        }

        public double getM()
        {
            return m;
        }

        public double getN()
        {
            return n;
        }

        public double getX0()
        {
            return x0;
        }

        public double getY0()
        {
            return y0;
        }

        public double getZ0()
        {
            return z0;
        }

        public void setL(double l)
        {
            this.l = l;
        }

        public void setM(double m)
        {
            this.m = m;
        }

        public void setN(double n)
        {
            this.n = n;
        }

        public void setX0(double x0)
        {
            this.x0 = x0;
        }

        public void setY0(double y0)
        {
            this.y0 = y0;
        }

        public void setZ0(double z0)
        {
            this.z0 = z0;
        }
    
    }
}
