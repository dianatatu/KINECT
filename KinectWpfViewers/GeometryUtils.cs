using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class GeometryUtils
    {
        // get angle from three 3D points
        public static double getAngle(Point3D A, Point3D B, Point3D C) {
        double AB = Math.Sqrt(
                        Math.Pow(B.getX() - A.getX(),2) +
                        Math.Pow(B.getY() - A.getY(),2) + 
                        Math.Pow(B.getZ() - A.getZ(),2));
        
        double BC = Math.Sqrt(
                        Math.Pow(C.getX() - B.getX(),2) +
                        Math.Pow(C.getY() - B.getY(),2) + 
                        Math.Pow(C.getZ() - B.getZ(),2));
        
        double CA = Math.Sqrt(
                        Math.Pow(A.getX() - C.getX(),2) +
                        Math.Pow(A.getY() - C.getY(),2) + 
                        Math.Pow(A.getZ() - C.getZ(),2));
        
        if ((-Math.Pow(CA, 2) + Math.Pow(AB, 2) + Math.Pow(BC, 2)) / ( 2 * AB * BC) < -1 ||
                (-Math.Pow(CA, 2) + Math.Pow(AB, 2) + Math.Pow(BC, 2)) / ( 2 * AB * BC) > 1)
            Console.WriteLine("!!" + (-Math.Pow(CA, 2) + Math.Pow(AB, 2) + Math.Pow(BC, 2)) / ( 2 * AB * BC));
        
        return (180/3.14) * Math.Acos((-Math.Pow(CA, 2) + Math.Pow(AB, 2) + Math.Pow(BC, 2)) / ( 2 * AB * BC) );
        
    }



        // get angle from 2 points 3D and a plane XOY, YOZ, XOZ
        public static double getAngle(Point3D A, Point3D B, Constants.planeType _type)
        {
            Line3D line = new Line3D(A, B);
            Plane3D plane = new Plane3D(_type);

            return (180 / 3.14) * Math.Asin((Math.Abs(plane.getA() * line.getL() + plane.getB() * line.getM() + plane.getC() * line.getN()))
                    / (Math.Sqrt(line.getL() * line.getL() + line.getM() * line.getM() + line.getN() * line.getN()) * Math.Sqrt(plane.getA() * plane.getA() + plane.getB() * plane.getB() + plane.getC() * plane.getC())));
        }
    }
}
