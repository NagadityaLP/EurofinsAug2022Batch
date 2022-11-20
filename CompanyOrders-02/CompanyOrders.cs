using System;
using System.Collections.Generic;

namespace CompanyOrders_02
{
    internal class CompanyOrders
    {
        static void Main(string[] args)
        {
            Company company = new Company();    
            Customer customer = new Customer();
            Customer customer1 = new Customer();
            
            company.Customers.Add(customer);
            company.Customers.Add(customer1);

            Order order = new Order() { Location = "India"};
            Factory factory = new Factory();
            Factory.Addkey("India", "GST");
            Factory.Addkey("UK", "VAT");
            
            OrderedItem orderedItem = new OrderedItem { Qty = 100};    
            order.OrderedItems.Add(orderedItem);

            Item item = new Item { Rate = 20};

            orderedItem.Item = item;    

            customer.Orders.Add(order);
            customer1.Orders.Add(order);

            double amountWithoutTax = company.GetTotalWorthOfOrdersPlaced();
            Console.WriteLine($"Amount without tax : {amountWithoutTax}");
            double amountWithTax = Factory.CalculatePayableAmount(amountWithoutTax, order.Location);
            Console.WriteLine($"Amount with tax : {amountWithTax}");

        }
    }
    
    
    
    
    
    

}
