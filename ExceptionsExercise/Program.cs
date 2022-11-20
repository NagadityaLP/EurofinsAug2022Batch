using System;
using System.IO;


namespace ExceptionsExercise
{
    internal class ExceptionTest
    {
        static void Main(string[] args)
        {
            try
            {
                Write("data.txt", "Good Morning.");
                /*int[] arr = new int[10];
                Console.Write("Enter an array index : ");
                int arrIndex = int.Parse(Console.ReadLine());
                arr[arrIndex] = 5;
                Console.Write("Enter two integers for division - a and b.  a/b in seperate lines : ");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                double val = a / b;*/
            }
            catch
            {
                Console.WriteLine("Exception raised");
            }
            /*catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Index Out of Range Exception raised.");
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }*/
        }
        static void Write(string filename, string message)
        {
            StreamWriter sw = new StreamWriter(filename);
            try
            {
                sw.WriteLine(message);
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sw.Close();
                Console.WriteLine("Closed successfully");
            }
        }
    }
}
