using System;

namespace CalculatorConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fno, sno, sum;
            Console.Write($"Enter the first number : ");
            fno = int.Parse(Console.ReadLine());
            Console.Write($"Enter the second number : ");
            sno = int.Parse(Console.ReadLine());

            //Calculator calculator = new Calculator();
            Console.WriteLine($"Sum of {fno} and {sno} is {CalculatorLibrary.Calculator.Sum(fno, sno)}");
        }// UI
    }
    /*class Calculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

    }//BL*/
}
