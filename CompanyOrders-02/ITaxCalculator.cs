using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders_02
{
    internal interface ITaxCalculator
    {
        double TaxCalculate(double amount);
    }
}
