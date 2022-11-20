using System;
using System.Collections.Generic;
using static System.Console;

namespace Dispose_Function_Implementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            M1();
            M1();
            WriteLine("end of application");
        }

        public static void M1()
        {
            BigClass b1 = new BigClass();
            Program p1 = new Program();
            using (b1)
            {
                WriteLine("end of m1");
                WriteLine("b1 goes out of scope");
            }
            //BigClass b2 = new BigClass();
        }
    }

    class BigClass : IDisposable
    {
        private List<int> numbers = null;
        public BigClass()
        {
            WriteLine("ctor called");
            numbers = new List<int>(100000);
        }
        ~BigClass()
        {

            WriteLine("dtor called");
        }

        public void Dispose()
        {
            WriteLine("BigClass Disposed");
            GC.SuppressFinalize(this);
        }
    }
}
