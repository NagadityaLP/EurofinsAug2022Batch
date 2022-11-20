using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsDemoConsoleApp1.Exceptions
{
    internal class ZeroInputException : ApplicationException
    {
        public ZeroInputException(string message) : base(message)
        {
            
        }
    }
}
