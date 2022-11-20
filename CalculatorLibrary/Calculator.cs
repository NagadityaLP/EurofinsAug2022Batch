using CalculatorDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class Calculator
    {
        private ICalculatorRepository repo = null;
        public Calculator(ICalculatorRepository repo)
        {
            this.repo = repo;
        }
        public Calculator()
        {
            repo = new CalculatorFileRepositor();
        }
        public static int Sum(int a , int b)
        {
            if (a == 0 || b == 0)
                throw new Exception("Zero Input provided");
            if (a < 0 || b < 0)
                throw new Exception("Negative Input provided");
            if (a % 2 != 0 || b % 2 != 0)
                throw new Exception("Odd Input provided");

            int sum = a + b;
            //save
            ICalculatorRepository repo = new CalculatorFileRepositor();
            return a + b;
        }

        
    }
}
