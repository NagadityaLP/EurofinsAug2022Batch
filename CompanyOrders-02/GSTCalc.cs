using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders_02
{
    internal class GSTCalc : ITaxCalculator
    {  
        public double TaxCalculate(double amount)
        {
            return amount * 0.205;
        }
    }
}
