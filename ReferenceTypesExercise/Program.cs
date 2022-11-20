using System;

namespace ReferenceTypesExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Keeper keeper = new Keeper();
            keeper.Run();
        }
    }
    class Hive
    {
        public int[] Cells;
        public const int Empty = 0;
        public const int Full = 1;

        public Hive(int size)
        {
            Cells = new int[size];
            for (int i = 0; i < size; i++)  
                Cells[i] = Empty;
        }
    }
    class Bee
    {
        private Random random = new Random();
        private int currentState;
        private const int searching = 0;
        private const int gathering = 1;
        private const int returning = 2;
        private const int depositing = 3;
        public Hive hive;

        public Bee(Hive hive)
        {
            this.hive = hive;
            currentState = searching;
        }
        public void Work()
        {
            switch (currentState)
            {
                case 0:
                    {
                        Console.WriteLine("Searching...");
                        if (random.Next(5) == 0)
                            currentState = gathering;
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Gathering");
                        currentState = returning;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Returning");
                        currentState = depositing;
                        break;       
                    }                
                case 3:              
                    {                
                        Console.WriteLine("Depositing");
                        int i = random.Next(hive.Cells.Length);
                        if (hive.Cells[i] == Hive.Empty)
                        {
                            hive.Cells[i] = Hive.Full;
                            currentState = searching;
                        }
                        break;
                    }
            }
        }
    }
    class Keeper
    {
        public int Collect(Hive hive)
        {
            int filledCellsCount = 0;
            foreach (int cell in hive.Cells)
            {
                if (cell == Hive.Full) filledCellsCount += 1;
            }
            for (int i = 0; i < hive.Cells.Length; i++)
                hive.Cells[i] = Hive.Empty;
            return filledCellsCount;
        }
        public void Run()
        {
            Hive hive = new Hive(20);
            Bee[] bees = new Bee[10];
            for(int i = 0;i < bees.Length; i++)
            {
                bees[i] = new Bee(hive);
            }  
            while (true)
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < bees.Length; j++)
                    {
                        Console.Write($"Bee {j + 1}: ");
                        bees[j].Work();
                    }
                    Console.WriteLine("----------------");
                }
                Console.WriteLine("collect {0}", Collect(hive));
                Console.ReadKey();  
                
            }
        }
    }
}





