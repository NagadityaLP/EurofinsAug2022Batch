using System;

namespace Parameter_Passing_Exercise
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            ParameterTest obj = new ParameterTest();
            obj.Value(5);

            int a = 2, b = 4, minVal, maxVal;
            int[] arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            obj.swap(ref a, ref b);
            obj.MinMax(arr, out minVal, out maxVal);
            Console.WriteLine($"The minimum value and maximum value in the array are : {minVal} and {maxVal}");
            int sum_result = obj.sum(arr);
            Console.WriteLine(sum_result);
        }
    }

    class ParameterTest
    {
        public void Value(int X)
        {
            Console.WriteLine($"Integer value passed in the parameter is : {X}");
        }
        public void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public void MinMax(int[] a, out int min, out int max)
        {
            min = max = a[0];
            foreach (int item in a)
            {
                if (item < min) min = item;
                if (item > max) max = item;
            }
        }
        public int sum(params int[] values)
        {
            int sum = 0;
            foreach (int item in values)
                sum += item;
            return sum;
        }
    }
}
