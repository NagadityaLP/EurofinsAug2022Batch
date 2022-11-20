using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders_02
{
    internal class Order
    {
        public List<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();
        public string Location { get; set; }

        public double GetOrderValue()
        {
            double totalOrdersValue = 0;
            foreach (OrderedItem item in OrderedItems)
                totalOrdersValue += item.GetOrderValue();
            return totalOrdersValue;
        }
    }
}
