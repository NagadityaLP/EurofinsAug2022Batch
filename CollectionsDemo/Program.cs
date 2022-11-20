using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Jagged arrays - array with fixed rows and variable number of columns
            int[][] scores = new int[3][];
            scores[0] = new int[3];
            scores[1] = new int[2];
            scores[2] = new int[5];

            //two - dimensional arrays
            int[,] twod = new int[3, 5];
 

            //store 5 int munbers and find their sum
            int[] numbers = new int[5];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Enter number {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            //find sum
            int sum = numbers.Sum();
            Array.Sort(numbers);
            numbers.Reverse();
            foreach (int item in numbers)
                sum += item;
            Console.WriteLine($"The sum of all numbers is {sum}");


            //want to store n number of ints and display


            List<int> numbers1 = new List<int>();
            numbers1.Add(5);
            Console.WriteLine($"Capacity : {numbers1.Capacity}");


        }
        /*class DynamicIntArray
        {
            private int[] numbers = new int[10];
            private int index;
            public void Add(int a)
            {
                numbers
            }
            public int Count { get; set; }
            public int Get(int i)
            {

            }
        }*/
    }
}
