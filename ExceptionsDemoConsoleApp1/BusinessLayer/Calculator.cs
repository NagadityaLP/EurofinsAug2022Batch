using ExceptionsDemoConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsDemoConsoleApp1.BusinessLayer
{
    /// <summary>
    /// Calculator is used for calculating simple mathematical calculations
    /// </summary>
    internal class Calculator
    {
        /// <summary>
        /// Finds sum of two ints non zero positive evens numbers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>sum of two numbers</returns>
        /// <exception cref="ZeroInputException"/>
        public int Sum(int a, int b)
        {
            if (a == 0 || b == 0)
                throw new ZeroInputException("Enter only non zero values");
            if (a < 0 || b < 0)
                throw new NegativeInputException();
            if (a % 2 != 0 || b % 2 != 0)
                throw new OddInputException();
            return a + b;
        }
    }
}
