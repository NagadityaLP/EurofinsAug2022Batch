using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders_02
{
    internal class RegCustomer : Customer
    {
        public double Discount { get; set; }
        public override double GetTotalOrdersWorth()
        {
            double totalOrdersWorth = base.GetTotalOrdersWorth();
            totalOrdersWorth -= Discount;
            return totalOrdersWorth;
        }
    }
}
