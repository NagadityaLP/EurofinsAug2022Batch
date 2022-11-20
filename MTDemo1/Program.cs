using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main running in thread {Thread.CurrentThread.ManagedThreadId}");
            //Console.WriteLine($"No. of CORES : {Environment.ProcessorCount}");
            Console.WriteLine("Running seq....");
            Stopwatch stopwatch = Stopwatch.StartNew();
            M1();
            M2();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);


            Console.WriteLine("Running in Threads : ");
            stopwatch = Stopwatch.StartNew();
            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();
            //ParameterizedThreadStart ts2 = new ParameterizedThreadStart(); -- applicable for functions which takes object as parameter
            Thread t2 = new Thread(M2);
            t2.Start();

            //Join - is used to make Main thread wait until t1 and t2 threads complete its execution
            t1.Join();
            t2.Join();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //Imperative programming
            Console.WriteLine("Running using TPL - Task");
            stopwatch = Stopwatch.StartNew();
            Task tt1 = new Task(M1);
            tt1.Start();
            //Task tt2 = new Task(M1);
            //tt2.Start();
            Task tt2 = Task.Factory.StartNew(M2);

            tt1.Wait();
            tt2.Wait();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);


            Console.WriteLine("Running using TPL - Parallel");
            stopwatch = Stopwatch.StartNew();
            Parallel.Invoke(M1, M2); // Declarative Programming
            Console.WriteLine(stopwatch.ElapsedMilliseconds);


            Console.WriteLine("Running using TPL - Parallel For");
            stopwatch = Stopwatch.StartNew();
            Parallel.Invoke(M11, M22); // Declarative Programming
            Console.WriteLine(stopwatch.ElapsedMilliseconds);



        }


        //This method takes nothing(no Parameter) and returns nothing - only this can be executed parallelly as per the delegate signature
        static void M1()
        {
            Console.WriteLine($"M1 running in thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(100);
            }
        }
        static void M2()
        {
            Console.WriteLine($"M2 running in thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(100);
            }
        }

        static void M11()
        {
            Console.WriteLine($"M1 running in thread {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 1; i <= 10; i++)
            Parallel.For(1, 11, i =>
            {
                Thread.Sleep(100);
            });
            
        }
        static void M22()
        {
            Console.WriteLine($"M2 running in thread {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 1; i <= 10; i++)
            Parallel.For(1, 11, i =>
            {
                Thread.Sleep(100);
            });
            
        }


        static void F1() { }
        static void F2(int a) { }
        static int F3() { return 1; }
        static int F4(int a) { return a; }

        static void RunInThreads()
        {
            Thread t1 = new Thread(F1);
            t1.Start();

            //Normal version of Task - use it when method doesn't returns anything
            Task tt1 = new Task(F1);
            tt1.Start();

            Thread t2 = new Thread( () =>  F2(10) );
            t2.Start();

            Task tt2 = new Task(() => F2(10));
            tt2.Start();

            //Generic version of task - when a method returns a value. Based on the return type of the method, the generic type need to be set
            Task<int> tt3 = new Task<int>(F3);
            tt3.Start();
            //Any other work 
            //to be performed by 
            //Main thread
            int r = tt3.Result; // when this statement is executed, main will waits until result is obtained

            Task<int> tt4 = new Task<int>(() => { return F4(100);  } );
            tt4.Start();
            //
            //
            //
            r = tt4.Result;

        }
    }
}
