using System;
using System.Collections.Generic;
using System.Linq;


namespace CompanyOrders_VenkatSir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            Item i1 = new Item() { Rate = 500 };
            Item i2 = new Item() { Rate = 120 };
            Item i3 = new Item() { Rate = 100 };
            
            company.Items.Add(i1); //Dynamic(Runtime) Association
            company.Items.Add(i2); // Company is associated with 3 Items
            company.Items.Add(i3);

            RegCustomer customer = new RegCustomer { Discount = 100};
            company.Customers.Add(customer); // Company is associated with 1 customer

            Customer customer1 = new Customer();
            company.Customers.Add(customer1);

            Order order = new Order();
            customer.Orders.Add(order);

            OrderedItem oi = new OrderedItem { Item = i1, Quantity = 1};
            order.OrderedItems.Add(oi);

            Console.WriteLine($"Total Worth of all items : {company.GetTotalWorthOfOrdersPlaced()}");
            Console.WriteLine($"Total number of customers in the company : {company.GetTotalCustomersCount()}");
            Console.WriteLine($"Total number of registered customers in the company : {company.GetTotalRegCustomersCount()}");
        }
    }
    class Company
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public double GetTotalWorthOfOrdersPlaced()
        {
            double totalAmount = 0;
            //for each customer
            foreach (Customer customer in Customers)
                totalAmount += customer.GetOrdersTotal();
            return totalAmount; 
        }
        public int GetTotalCustomersCount()
        {
            return Customers.Count;
        }
        public int GetTotalRegCustomersCount()
        {
            /*int registeredCustomersCount = 0;
            foreach(Customer customer in Customers)
            {
                if (customer is RegCustomer) registeredCustomersCount += 1;
            }
            return registeredCustomersCount;*/

            return Customers.OfType<RegCustomer>().Count();
        }
    }
    class Item
    {
        public int Rate { get; set; }
        public string Description { get; set; }

    }
    class Customer
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public virtual double GetOrdersTotal()
        {
            double ordersTotal = 0;
            foreach (Order order in Orders)
                ordersTotal += order.GetOrderTotal();
            return ordersTotal;
        }

    }
    class RegCustomer : Customer
    {
        public double Discount { get; set; }

        public override double GetOrdersTotal()
        {
            return base.GetOrdersTotal() - Discount;
        }
    }
    class Order
    {
        public List<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();

        public double GetOrderTotal()
        {
            double orderTotal = 0;
            foreach (OrderedItem oItem in OrderedItems)
                orderTotal += oItem.GetItemValue(); 
            return orderTotal;
        }
    }
    class OrderedItem
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }

        public double GetItemValue()
        {
            return Quantity * Item.Rate;
        }
    }
}
