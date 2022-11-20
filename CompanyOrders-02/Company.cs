using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders_02
{
    internal class Company
    {
        List<Item> items { get; set; } = new List<Item>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public double GetTotalWorthOfOrdersPlaced()
        {   
            double totalWorthOfOrdersPlaced = 0;
            foreach (Customer customer in Customers)
                totalWorthOfOrdersPlaced += customer.GetTotalOrdersWorth();
            return totalWorthOfOrdersPlaced;
        }
    }
}
