using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace MyFirstConsoleApp
{
    internal class EnvironmentInteraction
    { 
        static int Main(string[] args)
        {
            foreach (string str in args)
            {
                Console.Write($"{str} ");
            }
            return 0;
        }


    }

}

 