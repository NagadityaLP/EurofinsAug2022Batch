using System;

namespace RobotExercise
{
    internal class World
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            int goalx = 7;
            int goaly = 9;

            robot.Initialize("Avengers", 2, 3, 0);
            Console.WriteLine("After initializing the robot : ");
            robot.Print();
            robot.Move();
            Console.WriteLine("After executing Move() function : ");
            robot.Print();
            robot.Turn(5);
            Console.WriteLine("After executing Turn(5) function : ");
            robot.Print();

            //call Step() function until the robot reaches its goal
            while(!robot.At(goalx, goaly))
                robot.Step();
           
            if(robot.At(goalx, goaly)) Console.WriteLine($"Robot has reached its goal and it is at ({goalx}, {goaly})\n");
            
        }
    }
    class Robot
    {
        private string name;
        private int x;
        private int y;
        private int direction;
        public const int North = 0;
        public const int East = 1;
        public const int South = 2;
        public const int West = 3;
        public const int Left = 4;
        public const int Right = 5;
        public const int Size = 10;

        private Random random = new Random((int)DateTime.Now.Ticks);
        public void Initialize(string name, int x, int y, int direction)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.direction = direction;
        }
        public void Print()
        {
            Console.WriteLine($"{name} robot is at ({x}, {y}) facing {ToString(direction)} direction.\n");
        }
        private string ToString(int direction)
        {
            string[] names = { "North", "East", "South", "West", "Left", "Right" };
            return names[direction];
        }
        public void Move()
        {
            if (direction == North) y += 1;
            else if(direction == East) x += 1;
            else if(direction == South) y -= 1;
            else if(direction == West) x -= 1;

            x = (x + Size) % Size;
            y = (y + Size) % Size;
        }
        public void Turn(int to)
        {
            if(direction == North)
            {
                if(to == 4)direction = West;
                else if(to == 5)direction = East;
            }
            else if(direction == East)
            {
                if(to == 4)direction = North;
                else if(to == 5)direction = South;
            }
            else if(direction == South)
            {
                if(to == 4)direction = East;
                else if(to == 5)direction = West;
            }
            else if(direction == West)
            {
                if(to == 4)direction = South;
                else if(to == 5)direction = North;
            }
        }
        public void Step()
        {
            int randomNum = random.Next(2);
            if (randomNum == 0) Move();
            else if (randomNum == 1)
            {
                int turn = random.Next(2);
                if (turn == 0) Turn(4);
                else Turn(5);
            }
        }
        public bool At(int x, int y)
        {
            return this.x == x && this.y == y;
        }
    }
}
