using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders_02
{
    internal class Customer
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        public virtual double GetTotalOrdersWorth()
        {
            double totalOrdersWorth = 0;
            foreach (Order order in Orders)
                totalOrdersWorth += order.GetOrderValue();
            return totalOrdersWorth;
        }

    }
}
