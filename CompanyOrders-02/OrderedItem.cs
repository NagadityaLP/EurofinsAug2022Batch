using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders_02
{
    internal class OrderedItem
    {
        public int Qty { get; set; }
        public Item Item { get; set; }
        public double GetOrderValue()
        {
            return Qty * Item.Rate;
        }
    }
}
