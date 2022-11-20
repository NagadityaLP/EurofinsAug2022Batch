using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MTDemo3
{
    class Program
    {
        static int ROWS = 9000;
        static int COL = 9000;

        static void Main(string[] args)
        {

            int[,] matrix1 = new int[ROWS, COL];
            int[,] matrix2 = new int[ROWS, COL];
            InitializeMatrix(matrix1);
            InitializeMatrix(matrix2);
            Console.WriteLine("Running sequentially.......");
            Stopwatch sw = Stopwatch.StartNew();
            var result = MultiplyMatrix(matrix1, matrix2);
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static void InitializeMatrix(int[,] matrix)
        {
            Random rnd = new Random();
            for (int i = 0; i < ROWS; i++)
            //Parallel.For(0, ROWS, i =>
            {
                for (int x = 0; x < COL; x++)
                //Parallel.For(0, COL, x =>
                {
                    matrix[i, x] = rnd.Next(1, 99);
                }
            }
        }
        static int[,] MultiplyMatrix(int[,] m1, int[,] m2)
        {
            int[,] result = new int[ROWS, COL];
            //for (int r = 0; r < ROWS; r++)
            Parallel.For(0, ROWS, r =>
            {
                //for (int c = 0; c < COL; c++)
                Parallel.For(0, COL, c =>
                {
                    result[r, c] = m1[r, c] * m2[r, c];
                });

            });
            return result;
        }
    }
}