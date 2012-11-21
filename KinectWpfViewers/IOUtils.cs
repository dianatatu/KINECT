using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class IOUtils
    {

        public static List<Example> readBodyTS() {
        // TRAIN BODY PART ...
        List<Example> bodyTS = new List<Example>();
        StreamReader sr;
        String strLine;
        
        if (Constants.DEBUG) {
            Console.WriteLine("\n=====\tTRUNCHI\t=====");
            // Attributes: A.2.1.13, A.2.1.17, A.1.2.XOY, A.1.2.YOZ
            Console.WriteLine("\tDrept");
        }
        double maxim1 = 0.0;
        double minim1 = 180.0;
        double average1 = 0.0;

        double maxim2 = 0.0;
        double minim2 = 180.0;
        double average2 = 0.0;

        double maxim3 = 0.0;
        double minim3 = 180.0;
        double average3 = 0.0;

        double maxim4 = 0.0;
        double minim4 = 180.0;
        double average4 = 0.0;

        double fileSize = 5838;
        
        try {
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\trunchi\\drept.txt");

            for (int i=0; i<fileSize; i+=21) {
                strLine = sr.ReadLine(); // blank
                strLine = sr.ReadLine(); // 0:hipcenter
                strLine = sr.ReadLine(); // 1:spine
                string[] words = strLine.Split(' ');
                Point3D P1 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 2:shoulder center
                words = strLine.Split(' ');
                Point3D P2 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                strLine = sr.ReadLine(); // 5:elbow left
                strLine = sr.ReadLine(); // 6:wrist left
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left                
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                words = strLine.Split(' ');
                Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right
                
                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P2,P1,P13);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;
                average1 += angle;
                example.add("A.2.1.13", angle);
                
                angle = GeometryUtils.getAngle(P2,P1,P17);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;
                average2 += angle;
                example.add("A.2.1.17", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.XOY);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;
                average3 += angle;
                example.add("A.1.2.XoY", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.YOZ);
                if (maxim4 < angle)
                    maxim4 = angle;
                if (minim4 > angle)
                    minim4 = angle;
                average4 += angle;
                example.add("A.1.2.YoZ", angle);
                
                example.setResult("drept");
                bodyTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.2.1.13:(" + (int)minim1 + ", " + (int)maxim1 + "), " + (int)(average1/fileSize*21));
                Console.WriteLine("A.2.1.17:(" + (int)minim2 + ", " + (int)maxim2 + "), " + (int)(average2/fileSize*21));
                Console.WriteLine("A.1.2.XOY:(" + (int)minim3 + ", " + (int)maxim3 + "), " + (int)(average3/fileSize*21));
                Console.WriteLine("A.1.2.YOZ:(" + (int)minim4 + ", " + (int)maxim4 + "), " + (int)(average4/fileSize*21));
            }
            
            
            if (Constants.DEBUG) {
                Console.WriteLine("\tAplecat frontal");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\trunchi\\aplecat frontal.txt");

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            maxim4 = 0.0;
            minim4 = 180.0;
            average4 = 0.0;

            fileSize = 10605;
            for (int i=0; i<fileSize; i+=21) {                   
                strLine = sr.ReadLine(); // blank
                strLine = sr.ReadLine(); // 0:hipcenter
                strLine = sr.ReadLine(); // 1:spine
                string[] words = strLine.Split(' ');
                Point3D P1 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 2:shoulder center
                words = strLine.Split(' ');
                Point3D P2 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                strLine = sr.ReadLine(); // 5:elbow left
                strLine = sr.ReadLine(); // 6:wrist left
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left                
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                words = strLine.Split(' ');
                Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right
                
                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P2,P1,P13);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;
                average1 += angle;
                example.add("A.2.1.13", angle);
                
                angle = GeometryUtils.getAngle(P2,P1,P17);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;
                average2 += angle;
                example.add("A.2.1.17", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.XOY);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;
                average3 += angle;
                example.add("A.1.2.XoY", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.YOZ);
                if (maxim4 < angle)
                    maxim4 = angle;
                if (minim4 > angle)
                    minim4 = angle;
                average4 += angle;
                example.add("A.1.2.YoZ", angle);
                
                example.setResult("aplecat frontal");
                bodyTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.2.1.13:(" + (int)minim1 + ", " + (int)maxim1 + "), " + (int)(average1/fileSize*21));
                Console.WriteLine("A.2.1.17:(" + (int)minim2 + ", " + (int)maxim2 + "), " + (int)(average2/fileSize*21));
                Console.WriteLine("A.1.2.XOY:(" + (int)minim3 + ", " + (int)maxim3 + "), " + (int)(average3/fileSize*21));
                Console.WriteLine("A.1.2.YOZ:(" + (int)minim4 + ", " + (int)maxim4 + "), " + (int)(average4/fileSize*21));
            }

            if (Constants.DEBUG) {
                Console.WriteLine("\tAplecat lateral");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\trunchi\\aplecat lateral.txt");

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            maxim4 = 0.0;
            minim4 = 180.0;
            average4 = 0.0;

            fileSize = 9786;
            
            for (int i=0; i<fileSize; i+=21) {
                strLine = sr.ReadLine(); // blank
                strLine = sr.ReadLine(); // 0:hipcenter
                strLine = sr.ReadLine(); // 1:spine
                string[] words = strLine.Split(' ');
                Point3D P1 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 2:shoulder center
                words = strLine.Split(' ');
                Point3D P2 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                strLine = sr.ReadLine(); // 5:elbow left
                strLine = sr.ReadLine(); // 6:wrist left
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left                
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                words = strLine.Split(' ');
                Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right
                
                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P2,P1,P13);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;
                average1 += angle;
                example.add("A.2.1.13", angle);
                
                angle = GeometryUtils.getAngle(P2,P1,P17);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;
                average2 += angle;
                example.add("A.2.1.17", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.XOY);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;
                average3 += angle;
                example.add("A.1.2.XoY", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.YOZ);
                if (maxim4 < angle)
                    maxim4 = angle;
                if (minim4 > angle)
                    minim4 = angle;
                average4 += angle;
                example.add("A.1.2.YoZ", angle);
                
                example.setResult("aplecat lateral");
                bodyTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.2.1.13:(" + (int)minim1 + ", " + (int)maxim1 + "), " + (int)(average1/fileSize*21));
                Console.WriteLine("A.2.1.17:(" + (int)minim2 + ", " + (int)maxim2 + "), " + (int)(average2/fileSize*21));
                Console.WriteLine("A.1.2.XOY:(" + (int)minim3 + ", " + (int)maxim3 + "), " + (int)(average3/fileSize*21));
                Console.WriteLine("A.1.2.YOZ:(" + (int)minim4 + ", " + (int)maxim4 + "), " + (int)(average4/fileSize*21));
            }

            if (Constants.DEBUG) {
                Console.WriteLine("\tAsezat");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\trunchi\\asezat.txt");

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            maxim4 = 0.0;
            minim4 = 180.0;
            average4 = 0.0;

            fileSize = 6237;
            
            for (int i=0; i<fileSize; i+=21) {                
                strLine = sr.ReadLine(); // blank
                strLine = sr.ReadLine(); // 0:hipcenter
                strLine = sr.ReadLine(); // 1:spine
                string[] words = strLine.Split(' ');
                Point3D P1 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 2:shoulder center
                words = strLine.Split(' ');
                Point3D P2 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                strLine = sr.ReadLine(); // 5:elbow left
                strLine = sr.ReadLine(); // 6:wrist left
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left                
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                words = strLine.Split(' ');
                Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right
                
                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P2,P1,P13);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;
                average1 += angle;
                example.add("A.2.1.13", angle);
                
                angle = GeometryUtils.getAngle(P2,P1,P17);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;
                average2 += angle;
                example.add("A.2.1.17", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.XOY);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;
                average3 += angle;
                example.add("A.1.2.XoY", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.YOZ);
                if (maxim4 < angle)
                    maxim4 = angle;
                if (minim4 > angle)
                    minim4 = angle;
                average4 += angle;
                example.add("A.1.2.YoZ", angle);
                
                example.setResult("asezat");
                bodyTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.2.1.13:(" + (int)minim1 + ", " + (int)maxim1 + "), " + (int)(average1/fileSize*21));
                Console.WriteLine("A.2.1.17:(" + (int)minim2 + ", " + (int)maxim2 + "), " + (int)(average2/fileSize*21));
                Console.WriteLine("A.1.2.XOY:(" + (int)minim3 + ", " + (int)maxim3 + "), " + (int)(average3/fileSize*21));
                Console.WriteLine("A.1.2.YOZ:(" + (int)minim4 + ", " + (int)maxim4 + "), " + (int)(average4/fileSize*21));
            }
            
            if (Constants.DEBUG) {
                Console.WriteLine("\tCulcat");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\trunchi\\culcat.txt");

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            maxim4 = 0.0;
            minim4 = 180.0;
            average4 = 0.0;
            
            fileSize = 2604;
            
            for (int i=0; i<fileSize; i+=21) {
                strLine = sr.ReadLine(); // blank
                strLine = sr.ReadLine(); // 0:hipcenter
                strLine = sr.ReadLine(); // 1:spine
                string[] words = strLine.Split(' ');
                Point3D P1 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 2:shoulder center
                words = strLine.Split(' ');
                Point3D P2 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                strLine = sr.ReadLine(); // 5:elbow left
                strLine = sr.ReadLine(); // 6:wrist left
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left                
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                words = strLine.Split(' ');
                Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right
                
                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P2,P1,P13);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;
                average1 += angle;
                example.add("A.2.1.13", angle);
                
                angle = GeometryUtils.getAngle(P2,P1,P17);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;
                average2 += angle;
                example.add("A.2.1.17", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.XOY);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;
                average3 += angle;
                example.add("A.1.2.XoY", angle);
                
                angle = GeometryUtils.getAngle(P1,P2,Constants.planeType.YOZ);
                if (maxim4 < angle)
                    maxim4 = angle;
                if (minim4 > angle)
                    minim4 = angle;
                average4 += angle;
                example.add("A.1.2.YoZ", angle);
                
                example.setResult("culcat");
                bodyTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.2.1.13:(" + (int)minim1 + ", " + (int)maxim1 + "), " + (int)(average1/fileSize*21));
                Console.WriteLine("A.2.1.17:(" + (int)minim2 + ", " + (int)maxim2 + "), " + (int)(average2/fileSize*21));
                Console.WriteLine("A.1.2.XOY:(" + (int)minim3 + ", " + (int)maxim3 + "), " + (int)(average3/fileSize*21));
                Console.WriteLine("A.1.2.YOZ:(" + (int)minim4 + ", " + (int)maxim4 + "), " + (int)(average4/fileSize*21));
            }
          
        }
        catch (Exception e) {Console.WriteLine(e);}
        
        return bodyTS;
    }



        public static List<Example> readLeftHandTS() {
        // TRAIN LEFT HAND PART...
        StreamReader sr;
        String strLine;
        List<Example> leftHandTS = new List<Example>();
        
        if (Constants.DEBUG) {
            // Attributes: A.4.5.XOY, A.4.5.YOZ, D.4y.5y
            Console.WriteLine("\n=====\tMANA STANGA =====");
            // LANGA CORP
            Console.WriteLine("\tLanga corp");
        }
        double maxim1 = 0.0;
        double minim1 = 180.0;
        double average1 = 0.0;

        double maxim2 = 0.0;
        double minim2 = 180.0;
        double average2 = 0.0;

        double maxim3 = 0.0;
        double minim3 = 180.0;
        double average3 = 0.0;

        double fileSize = 27090; 
        
        try {
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mss\\langa corp.txt");

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                string[] words = strLine.Split(' ');
                Point3D P4 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 5:elbow left
                words = strLine.Split(' ');
                Point3D P5 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P4,P5,Constants.planeType.XOY);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.4.5.XoY", angle);
                
                angle = GeometryUtils.getAngle(P4,P5,Constants.planeType.YOZ);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.4.5.YoZ", angle);
                
                angle = P4.getY() - P5.getY();
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("D.4y.5y", angle);
                
                example.setResult("langa corp");
                leftHandTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.4.5.XOY:\t(" + minim1 + ", " + maxim1 + "), " + (average1/fileSize*21));
                Console.WriteLine("A.4.5.YOZ:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("D.4y.5y:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }
            
            // RIDICAT LATERAL
            if (Constants.DEBUG) {
                Console.WriteLine("\tRidicat lateral");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mss\\ridicat lateral.txt");
            fileSize = 30198;    
            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                string[] words = strLine.Split(' ');
                Point3D P4 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 5:elbow left
                words = strLine.Split(' ');
                Point3D P5 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P4,P5,Constants.planeType.XOY);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.4.5.XoY", angle);
                
                angle = GeometryUtils.getAngle(P4,P5,Constants.planeType.YOZ);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.4.5.YoZ", angle);
                
                angle = P4.getY() - P5.getY();
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("D.4y.5y", angle);
                
                example.setResult("ridicat lateral");
                leftHandTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.4.5.XOY:\t(" + minim1 + ", " + maxim1 + "), " + (average1/fileSize*21));
                Console.WriteLine("A.4.5.YOZ:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("D.4y.5y:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }


            // RIDICAT SUS
            if (Constants.DEBUG) {
                Console.WriteLine("\tRidicat sus");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mss\\ridicat sus.txt");
            fileSize = 29022;    
            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                string[] words = strLine.Split(' ');
                Point3D P4 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 5:elbow left
                words = strLine.Split(' ');
                Point3D P5 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P4,P5,Constants.planeType.XOY);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.4.5.XoY", angle);
                
                angle = GeometryUtils.getAngle(P4,P5,Constants.planeType.YOZ);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.4.5.YoZ", angle);
                
                angle = P4.getY() - P5.getY();
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("D.4y.5y", angle);
                
                example.setResult("ridicat sus");
                leftHandTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.4.5.XOY:\t(" + minim1 + ", " + maxim1 + "), " + (average1/fileSize*21));
                Console.WriteLine("A.4.5.YOZ:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("D.4y.5y:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }

            // RIDICAT FRONTAL
            if (Constants.DEBUG) {
                Console.WriteLine("\tRidicat frontal");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mss\\ridicat frontal.txt");
            fileSize = 9219;    
            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left
                string[] words = strLine.Split(' ');
                Point3D P4 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 5:elbow left
                words = strLine.Split(' ');
                Point3D P5 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                strLine = sr.ReadLine(); // 13:knee left
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right
                strLine = sr.ReadLine(); // 17:knee right
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P4,P5,Constants.planeType.XOY);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.4.5.XoY", angle);
                
                angle = GeometryUtils.getAngle(P4,P5,Constants.planeType.YOZ);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.4.5.YoZ", angle);
                
                angle = P4.getY() - P5.getY();
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("D.4y.5y", angle);
                
                example.setResult("ridicat frontal");
                leftHandTS.Add(example);
            }
            if (Constants.DEBUG) {
                Console.WriteLine("A.4.5.XOY:\t(" + minim1 + ", " + maxim1 + "), " + (average1/fileSize*21));
                Console.WriteLine("A.4.5.YOZ:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("D.4y.5y:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }
        }
        catch (Exception e) {Console.WriteLine(e);}
        
        return leftHandTS;
    }


        public static List<Example> readRightHandTS() {
         // TRAIN RIGHT HAND PART...
        if (Constants.DEBUG) {
            // Attributes: A.8.9.XOY, A.8.9.YOZ, D.8y.9y
            Console.WriteLine("\n=====\tMANA DREAPTA =====");  
            Console.WriteLine("\tLanga corp");
        }
        StreamReader sr;
        String strLine;
        List<Example> rightHandTS = new List<Example>();
        
        double maxim1 = 0.0;
        double minim1 = 180.0;
        double average1 = 0.0;

        double maxim2 = 0.0;
        double minim2 = 180.0;
        double average2 = 0.0;

        double maxim3 = 0.0;
        double minim3 = 180.0;
        double average3 = 0.0;
        
        try {
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\msd\\langa corp.txt");
            double fileSize = 22323;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left                              
                strLine = sr.ReadLine(); // 5:elbow left                
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right  
                string[] words = strLine.Split(' ');
                Point3D P8 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 9:elbow right
                words = strLine.Split(' ');
                Point3D P9 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left                
                strLine = sr.ReadLine(); // 13:knee left
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right       
                strLine = sr.ReadLine(); // 17:knee right                
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P8,P9,Constants.planeType.XOY);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.8.9.XoY", angle);
                
                angle = GeometryUtils.getAngle(P8,P9,Constants.planeType.YOZ);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.8.9.YoZ", angle);
                
                angle = P8.getY() - P9.getY();
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("D.8y.9y", angle);
                
                example.setResult("langa corp");
                rightHandTS.Add(example);
            }    
            if (Constants.DEBUG) {
                Console.WriteLine("A.8.9.XOY:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                Console.WriteLine("A.8.9.YOZ:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("D.8y.9y:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }
            
            //RIDICAT LATERAL
            if (Constants.DEBUG) {
                Console.WriteLine("\tRidicat lateral");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\msd\\ridicat lateral.txt");
            fileSize = 24444;

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left                              
                strLine = sr.ReadLine(); // 5:elbow left                
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right  
                string[] words = strLine.Split(' ');
                Point3D P8 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 9:elbow right
                words = strLine.Split(' ');
                Point3D P9 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left                
                strLine = sr.ReadLine(); // 13:knee left
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right       
                strLine = sr.ReadLine(); // 17:knee right                
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P8,P9,Constants.planeType.XOY);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.8.9.XoY", angle);
                
                angle = GeometryUtils.getAngle(P8,P9,Constants.planeType.YOZ);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.8.9.YoZ", angle);
                
                angle = P8.getY() - P9.getY();
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("D.8y.9y", angle);
                
                example.setResult("ridicat lateral");
                rightHandTS.Add(example);
            }  
            if (Constants.DEBUG) {
                Console.WriteLine("A.8.9.XOY:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                Console.WriteLine("A.8.9.YOZ:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("D.8y.9y:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }
            
            // RIDICAT SUS
            if (Constants.DEBUG) {
                Console.WriteLine("\tRidicat sus");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\msd\\ridicat sus.txt");
            fileSize = 14469;

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left                              
                strLine = sr.ReadLine(); // 5:elbow left                
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right  
                string[] words = strLine.Split(' ');
                Point3D P8 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 9:elbow right
                words = strLine.Split(' ');
                Point3D P9 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left                
                strLine = sr.ReadLine(); // 13:knee left
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right       
                strLine = sr.ReadLine(); // 17:knee right                
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P8,P9,Constants.planeType.XOY);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.8.9.XoY", angle);
                
                angle = GeometryUtils.getAngle(P8,P9,Constants.planeType.YOZ);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.8.9.YoZ", angle);
                
                angle = P8.getY() - P9.getY();
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("D.8y.9y", angle);
                
                example.setResult("ridicat sus");
                rightHandTS.Add(example);
            }     
            if (Constants.DEBUG) {
                Console.WriteLine("A.8.9.XOY:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                Console.WriteLine("A.8.9.YOZ:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("D.8y.9y:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }
            
            // RIDICAT FRONTAL
            if (Constants.DEBUG) {
                Console.WriteLine("\tRidicat frontal");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\msd\\ridicat frontal.txt");
            fileSize = 21567;

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left                              
                strLine = sr.ReadLine(); // 5:elbow left                
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right  
                string[] words = strLine.Split(' ');
                Point3D P8 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 9:elbow right
                words = strLine.Split(' ');
                Point3D P9 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left                
                strLine = sr.ReadLine(); // 13:knee left
                strLine = sr.ReadLine(); // 14:ankle left
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right       
                strLine = sr.ReadLine(); // 17:knee right                
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();
                
                double angle = GeometryUtils.getAngle(P8,P9,Constants.planeType.XOY);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.8.9.XoY", angle);
                
                angle = GeometryUtils.getAngle(P8,P9,Constants.planeType.YOZ);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.8.9.YoZ", angle);
                
                angle = P8.getY() - P9.getY();
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("D.8y.9y", angle);
                
                example.setResult("ridicat frontal");
                rightHandTS.Add(example);
            }       
            if (Constants.DEBUG) {
                Console.WriteLine("A.8.9.XOY:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                Console.WriteLine("A.8.9.YOZ:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("D.8y.9y:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }
        }
        catch (Exception e) {Console.WriteLine(e);}
        
        return rightHandTS;
     }


        public static List<Example> readLeftLegTS() {
         // TRAIN LEFT LEG PART...
         if (Constants.DEBUG) {
            // Attributes: A.12.13.14, A.13.14.XOY, A.13.14.YOZ
            Console.WriteLine("\n=====\tPICIOR STANG  =====");
            Console.WriteLine("\tDrept");
         }

        StreamReader sr;
        String strLine;
        List<Example> leftLegTS = new List<Example>();

        double maxim1 = 0.0;
        double minim1 = 180.0;
        double average1 = 0.0;

        double maxim2 = 0.0;
        double minim2 = 180.0;
        double average2 = 0.0;

        double maxim3 = 0.0;
        double minim3 = 180.0;
        double average3 = 0.0;

        double fileSize = 25242;

        try {
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mis\\drept.txt");

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left                              
                strLine = sr.ReadLine(); // 5:elbow left                
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right               
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                string[] words = strLine.Split(' ');
                Point3D P12 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 13:knee left
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                words = strLine.Split(' ');
                Point3D P14 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right       
                strLine = sr.ReadLine(); // 17:knee right                
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();

                double angle = GeometryUtils.getAngle(P12,P13,P14);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.12.13.14", angle);
                
                angle = GeometryUtils.getAngle(P13,P14,Constants.planeType.XOY);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.13.14.XoY", angle);

                angle = GeometryUtils.getAngle(P13,P14,Constants.planeType.YOZ);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("A.13.14.YoZ", angle);

                example.setResult("drept");
                leftLegTS.Add(example);
            }   
            if (Constants.DEBUG) {
                Console.WriteLine("A.12.13.14:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                Console.WriteLine("A.13.14.XOY:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("A.13.14.YOZ:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }

            // RIDICAT LATERAL
            if (Constants.DEBUG) {
                Console.WriteLine("\tRidicat lateral");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mis\\ridicat lateral.txt");
            fileSize = 3444;

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left                              
                strLine = sr.ReadLine(); // 5:elbow left                
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right               
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                string[] words = strLine.Split(' ');
                Point3D P12 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 13:knee left
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                words = strLine.Split(' ');
                Point3D P14 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right       
                strLine = sr.ReadLine(); // 17:knee right                
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();

                double angle = GeometryUtils.getAngle(P12,P13,P14);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.12.13.14", angle);
                                
                angle = GeometryUtils.getAngle(P13,P14,Constants.planeType.XOY);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.13.14.XoY", angle);

                angle = GeometryUtils.getAngle(P13,P14,Constants.planeType.YOZ);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("A.13.14.YoZ", angle);

                example.setResult("ridicat lateral");
                leftLegTS.Add(example);
            }   
            if (Constants.DEBUG) {
                Console.WriteLine("A.12.13.14:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                Console.WriteLine("A.13.14.XOY:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("A.13.14.YOZ:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }

            // RIDICAT FRONTAL
            if (Constants.DEBUG) {
                Console.WriteLine("\tRidicat frontal");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mis\\ridicat frontal.txt");
            fileSize = 12432;

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left                              
                strLine = sr.ReadLine(); // 5:elbow left                
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right               
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                string[] words = strLine.Split(' ');
                Point3D P12 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 13:knee left
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                words = strLine.Split(' ');
                Point3D P14 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right       
                strLine = sr.ReadLine(); // 17:knee right                
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();

                double angle = GeometryUtils.getAngle(P12,P13,P14);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.12.13.14", angle);
                
                
                angle = GeometryUtils.getAngle(P13,P14,Constants.planeType.XOY);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.13.14.XoY", angle);

                angle = GeometryUtils.getAngle(P13,P14,Constants.planeType.YOZ);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("A.13.14.YoZ", angle);

                example.setResult("ridicat frontal");
                leftLegTS.Add(example);
            }   
            if (Constants.DEBUG) {
                Console.WriteLine("A.12.13.14:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                Console.WriteLine("A.13.14.XOY:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("A.13.14.YOZ:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }

            // INDOIT
            if (Constants.DEBUG) {
                Console.WriteLine("\tIndoit");
            }
            sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mis\\indoit.txt");
            fileSize = 10584;

            maxim1 = 0.0;
            minim1 = 180.0;
            average1 = 0.0;

            maxim2 = 0.0;
            minim2 = 180.0;
            average2 = 0.0;

            maxim3 = 0.0;
            minim3 = 180.0;
            average3 = 0.0;

            for (int i=0; i<fileSize; i+=21) {  
                strLine = sr.ReadLine(); // blank                
                strLine = sr.ReadLine(); // 0:hipcenter   
                strLine = sr.ReadLine(); // 1:spine
                strLine = sr.ReadLine(); // 2:shoulder center
                strLine = sr.ReadLine(); // 3:head                 
                strLine = sr.ReadLine(); // 4:shoulder left                              
                strLine = sr.ReadLine(); // 5:elbow left                
                strLine = sr.ReadLine(); // 6:wrist left 
                strLine = sr.ReadLine(); // 7:hand left
                strLine = sr.ReadLine(); // 8:shoulder right               
                strLine = sr.ReadLine(); // 9:elbow right
                strLine = sr.ReadLine(); // 10:wrist right
                strLine = sr.ReadLine(); // 11:hand right
                strLine = sr.ReadLine(); // 12:hip left
                string[] words = strLine.Split(' ');
                Point3D P12 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 13:knee left
                words = strLine.Split(' ');
                Point3D P13 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 14:ankle left
                words = strLine.Split(' ');
                Point3D P14 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                strLine = sr.ReadLine(); // 15:foot left
                strLine = sr.ReadLine(); // 16:hip right       
                strLine = sr.ReadLine(); // 17:knee right                
                strLine = sr.ReadLine(); // 18:ankle right
                strLine = sr.ReadLine(); // 19:foot right

                Example example = new Example();

                double angle = GeometryUtils.getAngle(P12,P13,P14);
                if (maxim1 < angle)
                    maxim1 = angle;
                if (minim1 > angle)
                    minim1 = angle;  
                average1 += angle;  
                example.add("A.12.13.14", angle);
                
                angle = GeometryUtils.getAngle(P13,P14,Constants.planeType.XOY);
                if (maxim2 < angle)
                    maxim2 = angle;
                if (minim2 > angle)
                    minim2 = angle;  
                average2 += angle;
                example.add("A.13.14.XoY", angle);

                angle = GeometryUtils.getAngle(P13,P14,Constants.planeType.YOZ);
                if (maxim3 < angle)
                    maxim3 = angle;
                if (minim3 > angle)
                    minim3 = angle;  
                average3 += angle;
                example.add("A.13.14.YoZ", angle);

                example.setResult("indoit");
                leftLegTS.Add(example);
            }    
            if (Constants.DEBUG) {
                Console.WriteLine("A.12.13.14:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                Console.WriteLine("A.13.14.XOY:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                Console.WriteLine("A.13.14.YOZ:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
            }
        }
        catch (Exception e) {Console.WriteLine(e);} 

        return leftLegTS;
     }

        public static List<Example> readRightLegTS() {
            if (Constants.DEBUG) {
                Console.WriteLine("\n=====\tPICIOR DREPT  =====");   
                // DREPT
                Console.WriteLine("\tDrept");
            }
            
            List<Example> rightLegTS = new List<Example>();
            StreamReader sr;
            String strLine;

            double maxim1 = 0.0;
            double minim1 = 180.0;
            double average1 = 0.0;

            double maxim2 = 0.0;
            double minim2 = 180.0;
            double average2 = 0.0;

            double maxim3 = 0.0;
            double minim3 = 180.0;
            double average3 = 0.0;

            double fileSize = 14133;
            try {
                sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mid\\drept.txt");

                for (int i=0; i<fileSize; i+=21) {  
                    strLine = sr.ReadLine(); // blank                
                    strLine = sr.ReadLine(); // 0:hipcenter   
                    strLine = sr.ReadLine(); // 1:spine
                    strLine = sr.ReadLine(); // 2:shoulder center
                    strLine = sr.ReadLine(); // 3:head                 
                    strLine = sr.ReadLine(); // 4:shoulder left                              
                    strLine = sr.ReadLine(); // 5:elbow left                
                    strLine = sr.ReadLine(); // 6:wrist left 
                    strLine = sr.ReadLine(); // 7:hand left
                    strLine = sr.ReadLine(); // 8:shoulder right               
                    strLine = sr.ReadLine(); // 9:elbow right
                    strLine = sr.ReadLine(); // 10:wrist right
                    strLine = sr.ReadLine(); // 11:hand right
                    strLine = sr.ReadLine(); // 12:hip left                
                    strLine = sr.ReadLine(); // 13:knee left
                    strLine = sr.ReadLine(); // 14:ankle left
                    strLine = sr.ReadLine(); // 15:foot left
                    strLine = sr.ReadLine(); // 16:hip right
                    string[] words = strLine.Split(' ');
                    Point3D P16 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 17:knee right   
                    words = strLine.Split(' ');
                    Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 18:ankle right
                    words = strLine.Split(' ');
                    Point3D P18 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 19:foot right

                    Example example = new Example();
                    
                    double angle = GeometryUtils.getAngle(P16,P17,P18);
                    if (maxim1 < angle)
                        maxim1 = angle;
                    if (minim1 > angle)
                        minim1 = angle;  
                    average1 += angle;  
                    example.add("A.16.17.18", angle);
                    
                    angle = GeometryUtils.getAngle(P17,P18,Constants.planeType.XOY);
                    if (maxim2 < angle)
                        maxim2 = angle;
                    if (minim2 > angle)
                        minim2 = angle;  
                    average2 += angle;
                    example.add("A.17.18.XoY", angle);
                    
                    angle = GeometryUtils.getAngle(P17,P18,Constants.planeType.YOZ);
                    if (maxim3 < angle)
                        maxim3 = angle;
                    if (minim3 > angle)
                        minim3 = angle;  
                    average3 += angle;
                    example.add("A.17.18.YoZ", angle);
                    
                    example.setResult("drept");
                    rightLegTS.Add(example);
                }   
                if (Constants.DEBUG) {
                    Console.WriteLine("A.16.17.18:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                    Console.WriteLine("A.17.18.XOY:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                    Console.WriteLine("A.17.18.YOZ:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
                }
                
                // RIDICAT LATERAL
                if (Constants.DEBUG) {
                    Console.WriteLine("\tRidicat lateral");
                }
                sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mid\\ridicat lateral.txt");
                fileSize = 5859;

                maxim1 = 0.0;
                minim1 = 180.0;
                average1 = 0.0;

                maxim2 = 0.0;
                minim2 = 180.0;
                average2 = 0.0;

                maxim3 = 0.0;
                minim3 = 180.0;
                average3 = 0.0;

                for (int i=0; i<fileSize; i+=21) {  
                    strLine = sr.ReadLine(); // blank                
                    strLine = sr.ReadLine(); // 0:hipcenter   
                    strLine = sr.ReadLine(); // 1:spine
                    strLine = sr.ReadLine(); // 2:shoulder center
                    strLine = sr.ReadLine(); // 3:head                 
                    strLine = sr.ReadLine(); // 4:shoulder left                              
                    strLine = sr.ReadLine(); // 5:elbow left                
                    strLine = sr.ReadLine(); // 6:wrist left 
                    strLine = sr.ReadLine(); // 7:hand left
                    strLine = sr.ReadLine(); // 8:shoulder right               
                    strLine = sr.ReadLine(); // 9:elbow right
                    strLine = sr.ReadLine(); // 10:wrist right
                    strLine = sr.ReadLine(); // 11:hand right
                    strLine = sr.ReadLine(); // 12:hip left                
                    strLine = sr.ReadLine(); // 13:knee left
                    strLine = sr.ReadLine(); // 14:ankle left
                    strLine = sr.ReadLine(); // 15:foot left
                    strLine = sr.ReadLine(); // 16:hip right
                    string[] words = strLine.Split(' ');
                    Point3D P16 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 17:knee right   
                    words = strLine.Split(' ');
                    Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 18:ankle right
                    words = strLine.Split(' ');
                    Point3D P18 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 19:foot right

                    Example example = new Example();
                    
                    double angle = GeometryUtils.getAngle(P16,P17,P18);
                    if (maxim1 < angle)
                        maxim1 = angle;
                    if (minim1 > angle)
                        minim1 = angle;  
                    average1 += angle;  
                    example.add("A.16.17.18", angle);
                    
                    angle = GeometryUtils.getAngle(P17,P18,Constants.planeType.XOY);
                    if (maxim2 < angle)
                        maxim2 = angle;
                    if (minim2 > angle)
                        minim2 = angle;  
                    average2 += angle;
                    example.add("A.17.18.XoY", angle);
                    
                    angle = GeometryUtils.getAngle(P17,P18,Constants.planeType.YOZ);
                    if (maxim3 < angle)
                        maxim3 = angle;
                    if (minim3 > angle)
                        minim3 = angle;  
                    average3 += angle;
                    example.add("A.17.18.YoZ", angle);
                    
                    example.setResult("ridicat lateral");
                    rightLegTS.Add(example);
                }  
                if (Constants.DEBUG) {
                    Console.WriteLine("A.16.17.18:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                    Console.WriteLine("A.17.18.XOY:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                    Console.WriteLine("A.17.18.YOZ:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
                }

                // RIDICAT FRONTAL
                if (Constants.DEBUG) {
                    Console.WriteLine("\tRidicat frontal");
                }
                sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mid\\ridicat frontal.txt");
                fileSize = 9870;

                maxim1 = 0.0;
                minim1 = 180.0;
                average1 = 0.0;

                maxim2 = 0.0;
                minim2 = 180.0;
                average2 = 0.0;

                maxim3 = 0.0;
                minim3 = 180.0;
                average3 = 0.0;

                for (int i=0; i<fileSize; i+=21) {  
                    strLine = sr.ReadLine(); // blank                
                    strLine = sr.ReadLine(); // 0:hipcenter   
                    strLine = sr.ReadLine(); // 1:spine
                    strLine = sr.ReadLine(); // 2:shoulder center
                    strLine = sr.ReadLine(); // 3:head                 
                    strLine = sr.ReadLine(); // 4:shoulder left                              
                    strLine = sr.ReadLine(); // 5:elbow left                
                    strLine = sr.ReadLine(); // 6:wrist left 
                    strLine = sr.ReadLine(); // 7:hand left
                    strLine = sr.ReadLine(); // 8:shoulder right               
                    strLine = sr.ReadLine(); // 9:elbow right
                    strLine = sr.ReadLine(); // 10:wrist right
                    strLine = sr.ReadLine(); // 11:hand right
                    strLine = sr.ReadLine(); // 12:hip left                
                    strLine = sr.ReadLine(); // 13:knee left
                    strLine = sr.ReadLine(); // 14:ankle left
                    strLine = sr.ReadLine(); // 15:foot left
                    strLine = sr.ReadLine(); // 16:hip right
                    string[] words = strLine.Split(' ');
                    Point3D P16 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 17:knee right   
                    words = strLine.Split(' ');
                    Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 18:ankle right
                    words = strLine.Split(' ');
                    Point3D P18 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 19:foot right

                    Example example = new Example();
                    
                    double angle = GeometryUtils.getAngle(P16,P17,P18);
                    if (maxim1 < angle)
                        maxim1 = angle;
                    if (minim1 > angle)
                        minim1 = angle;  
                    average1 += angle;  
                    example.add("A.16.17.18", angle);
                    
                    angle = GeometryUtils.getAngle(P17,P18,Constants.planeType.XOY);
                    if (maxim2 < angle)
                        maxim2 = angle;
                    if (minim2 > angle)
                        minim2 = angle;  
                    average2 += angle;
                    example.add("A.17.18.XoY", angle);
                    
                    angle = GeometryUtils.getAngle(P17,P18,Constants.planeType.YOZ);
                    if (maxim3 < angle)
                        maxim3 = angle;
                    if (minim3 > angle)
                        minim3 = angle;  
                    average3 += angle;
                    example.add("A.17.18.YoZ", angle);
                    
                    example.setResult("ridicat frontal");
                    rightLegTS.Add(example);
                }    
                if (Constants.DEBUG) {
                    Console.WriteLine("A.16.17.18:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                    Console.WriteLine("A.17.18.XOY:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                    Console.WriteLine("A.17.18.YOZ:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
                }

                // INDOIT
                if (Constants.DEBUG) {
                    Console.WriteLine("\tIndoit");
                }
                sr = new StreamReader("D:\\LICENTA\\Pose Recognition\\input_antrenare_3\\mid\\indoit.txt");
                fileSize = 28791;

                maxim1 = 0.0;
                minim1 = 180.0;
                average1 = 0.0;

                maxim2 = 0.0;
                minim2 = 180.0;
                average2 = 0.0;

                maxim3 = 0.0;
                minim3 = 180.0;
                average3 = 0.0;

                for (int i=0; i<fileSize; i+=21) {  
                    strLine = sr.ReadLine(); // blank                
                    strLine = sr.ReadLine(); // 0:hipcenter   
                    strLine = sr.ReadLine(); // 1:spine
                    strLine = sr.ReadLine(); // 2:shoulder center
                    strLine = sr.ReadLine(); // 3:head                 
                    strLine = sr.ReadLine(); // 4:shoulder left                              
                    strLine = sr.ReadLine(); // 5:elbow left                
                    strLine = sr.ReadLine(); // 6:wrist left 
                    strLine = sr.ReadLine(); // 7:hand left
                    strLine = sr.ReadLine(); // 8:shoulder right               
                    strLine = sr.ReadLine(); // 9:elbow right
                    strLine = sr.ReadLine(); // 10:wrist right
                    strLine = sr.ReadLine(); // 11:hand right
                    strLine = sr.ReadLine(); // 12:hip left                
                    strLine = sr.ReadLine(); // 13:knee left
                    strLine = sr.ReadLine(); // 14:ankle left
                    strLine = sr.ReadLine(); // 15:foot left
                    strLine = sr.ReadLine(); // 16:hip right
                    string[] words = strLine.Split(' ');
                    Point3D P16 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 17:knee right   
                    words = strLine.Split(' ');
                    Point3D P17 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 18:ankle right
                    words = strLine.Split(' ');
                    Point3D P18 = new Point3D(Double.Parse(words[0]), 
                        Double.Parse(words[1]), 
                        Double.Parse(words[2]));
                    strLine = sr.ReadLine(); // 19:foot right

                    Example example = new Example();
                    
                    double angle = GeometryUtils.getAngle(P16,P17,P18);
                    if (maxim1 < angle)
                        maxim1 = angle;
                    if (minim1 > angle)
                        minim1 = angle;  
                    average1 += angle;  
                    example.add("A.16.17.18", angle);
                    
                    angle = GeometryUtils.getAngle(P17,P18,Constants.planeType.XOY);
                    if (maxim2 < angle)
                        maxim2 = angle;
                    if (minim2 > angle)
                        minim2 = angle;  
                    average2 += angle;
                    example.add("A.17.18.XoY", angle);
                    
                    angle = GeometryUtils.getAngle(P17,P18,Constants.planeType.YOZ);
                    if (maxim3 < angle)
                        maxim3 = angle;
                    if (minim3 > angle)
                        minim3 = angle;  
                    average3 += angle;
                    example.add("A.17.18.YoZ", angle);
                    
                    example.setResult("indoit");
                    rightLegTS.Add(example);
                }    
                if (Constants.DEBUG) {
                    Console.WriteLine("A.16.17.18:\t(" + (int)minim1 + ", " + (int)maxim1 + "), " + ((int)average1/fileSize*21));
                    Console.WriteLine("A.17.18.XOY:\t(" + (int)minim2 + ", " + (int)maxim2 + "), " + ((int)average2/fileSize*21));
                    Console.WriteLine("A.17.18.YOZ:\t(" + (int)minim3 + ", " + (int)maxim3 + "), " + ((int)average3/fileSize*21));
                }
        }
        catch (Exception e) {Console.WriteLine(e);}
            
        return rightLegTS;
     }

    }
}
