using System;

namespace Class_Exercise
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            Point point = new Point();
            point.Initialize(5, 3);
            Console.WriteLine($"X-Coordinate is : {point.GetX()}");
            Console.WriteLine($"Y-Coordinate is : {point.GetY()}");
            point.Translate(2, 4);
            
            point.Scale(4);
            Console.WriteLine($"New point obtained after scaling is : ({point.GetX()},{point.GetY()})");

            Point point1 = new Point();
            point1.Initialize(4, 7);
            
            Console.WriteLine($"Distance between ({point.GetX()},{point.GetY()}) and ({point1.GetX()},{point1.GetY()}) is {point.Distance(point1)}");
        }
    }

    class Point
    {
        private int x;
        private int y;

        public void Initialize(int x, int y)
        {
            this.x = x; this.y = y;
            Console.WriteLine("Point initialized successfully.");
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

        public void Translate(int xOffset, int yOffset)
        {
            Point newPoint = new Point();
            newPoint.x = x + xOffset; 
            newPoint.y = y + yOffset;
            Console.WriteLine($"New point obtained after translation is : ({newPoint.GetX()},{newPoint.GetY()})");
        }
        public void Scale(int a)
        {
            x *= a;
            y *= a;
        }
        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow((p.GetX() - x),2) + Math.Pow((p.GetY() - y), 2));
        }
    }
}
