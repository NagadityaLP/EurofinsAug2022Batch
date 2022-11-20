using ExceptionsDemoConsoleApp1.BusinessLayer;
using ExceptionsDemoConsoleApp1.Exceptions;
using System;

namespace ExceptionsDemoConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //accept two ints and find sum continuously
            int fno, sno, sum;
            while (true)
            {
                try
                {
                    Console.Write($"Enter the first number : ");
                    fno = int.Parse(Console.ReadLine());
                    Console.Write($"Enter the second number : ");
                    sno = int.Parse(Console.ReadLine());
                    Calculator calculator = new Calculator();
                    Console.WriteLine($"Sum of {fno} and {sno} is {calculator.Sum(fno, sno)}");
                }
                catch (ZeroInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Enter only numbers");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Enter integer numbers only.");
                }
                catch (Exception ex) //Catch all block
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                //Console.WriteLine("After catch before finally");

                finally
                {
                    Console.WriteLine("This is the finally block to be executed.");
                }
            }
        }
    }
}
