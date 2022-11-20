using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //client 1 - show all process
            //ProcessManager.ShowProcessList();

            //client 2 - show all process with starting char
            //ProcessManager.ShowProcessList("S");

            //client 3 - show only big processes(50MB)
            //ProcessManager.ShowProcessList(50 * 1024 * 1024);



            //ProcessManager pm = new ProcessManager();
            //pm.fd += Program.FilterBySize;
            //ProcessManager.ShowProcessList(pm.fd);

            //client 1
            ProcessManager.ShowProcessList(FilterByNone);
            

            //client2
            FilterDelegate filter = new FilterDelegate(FilterByName);
            ProcessManager.ShowProcessList(filter);


            //client 3
            //ProcessManager.ShowProcessList(FilterBySize);

            //Anonymous Delegate
            ProcessManager.ShowProcessList(delegate (Process p)
            {
                return p.WorkingSet64 >= 50 * 1024 * 1024;
            });
            
            //Lambda Statement       => - goes to / lambda
            ProcessManager.ShowProcessList((Process p) =>
            {
                return p.WorkingSet64 >= 50 * 1024 * 1024;
            });

            // Lambda Expression - light weight syntax for anonymous delegates       => -goes to / lambda
            ProcessManager.ShowProcessList((Process p) =>
                 p.WorkingSet64 >= 50 * 1024 * 1024
            ); 
            
            // Lambda Expression - light weight syntax for anonymous delegates       => -goes to / lambda
            ProcessManager.ShowProcessList( p => p.WorkingSet64 >= 50 * 1024 * 1024);


            List<int> numbers = new List<int>() { 123, 23, 44, 67, 89, 536 };
            var sum = numbers.Sum();
            var evenSum = numbers.Where(n => n % 2 == 0).Sum();







        }

        //client 1 - no filter
        static bool FilterByNone(Process p)
        {
            return true;
        }

        //client 2 - filter by name
        static bool FilterByName(Process p)
        {
            if (p.ProcessName.StartsWith("S"))
                return true;
            else
                return false;
        }

        //client 3 - filter by size
        static bool FilterBySize(Process p)
        {
            return p.WorkingSet64 >= 50 * 1024 * 1024;
        }
    }

    //declare the delegate

    public delegate bool FilterDelegate(Process p);
    class ProcessManager
    {
        /*public static void ShowProcessList()
        {
            foreach (var p in Process.GetProcesses())
                Console.WriteLine(p.ProcessName);
        }
        public static void ShowProcessList(string s)
        {
            foreach (var p in Process.GetProcesses())
            {
                if(p.ProcessName.StartsWith(s))
                    Console.WriteLine(p.ProcessName);
            }
        }
        public static void ShowProcessList(long size)
        {
            foreach (var p in Process.GetProcesses())
            {
                if (p.WorkingSet64 >= size)
                    Console.WriteLine(p.ProcessName);
            }
        }*/
        //public FilterDelegate fd;
        public static void ShowProcessList(FilterDelegate filter)
        {
            foreach (var p in Process.GetProcesses())
            {
                if (filter(p))
                    Console.WriteLine(p.ProcessName);
            }
        }
    }
}
