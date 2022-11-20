using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo1
{
    /*class MyDelegate : Delegate
    {

    }*/


    //Step 1 : delegate declaration - signature has to be specified mandatorily i.e. what type of methods address, this delegate should hold?  needto be answered
    delegate void MyDelegate(string str);
    internal class Program
    {
        static void Main(string[] args)
        {
            //direct invoking of method - info required : Method name, class it belongs to, type of method(static or instance) and method's signature
            //Program.Greeting("Hello");

            //indirect method of invoking a function - can be used when only method's signature is known and nothing else
            //Step 2 : Instantiate and initialize - pass address of the function to which the delegate should point to. For passing the address, oly function name should be given.
            MyDelegate delObj = new MyDelegate(Greeting);
            //subscribing
            delObj += new Program().Hello;

            //unsubscribing
            delObj -= Greeting;

            //Step 3 : Delegate Invoking/Calling
            //delObj.Invoke("Hello");
            delObj("Ramesh");//same as above
        }
        public static void Greeting(string msg)
        {
            Console.WriteLine($"Greeting: {msg}");
        }
        public void Hello(string msg)
        {
            Console.WriteLine($"Hello: {msg}");
        }
    }
}
