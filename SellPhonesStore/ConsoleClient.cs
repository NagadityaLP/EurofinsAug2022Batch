using SellPhonesStore.DataAccess;
using SellPhonesStore.Entities;
using System;
using System.Collections.Generic;

namespace SellPhonesStore
{
    internal class ConsoleClient
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2015, 12, 25);
            DateTime date2 = new DateTime(2015, 10, 04);
            DateTime date3 = new DateTime(2015, 9, 07);
            SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
            /*Phone phone = new Phone { BrandName = "Samsung", InStock = 1, Price = 72300,
                                        PhoneDesciption = "Amazing mobile", ManufacturingDate = date1};
            db.Database.Log = Console.WriteLine;
            db.Phones.Add(phone);
            db.SaveChanges();*/

            CustomerOrder order = new CustomerOrder { OrderDate = date1 , OrderTotal = 7000};
            CustomerOrder order1 = new CustomerOrder { OrderDate = date2 , OrderTotal = 7000};
            CustomerOrder order2 = new CustomerOrder { OrderDate = date3 , OrderTotal = 7000};
            List<CustomerOrder> orders = new List<CustomerOrder>();
            orders.Add(order);
            orders.Add(order1);
            orders.Add(order2);
            Customer customer = new Customer
            {
                CustomerName = "aditya1",
                City = "Tumkur",
                EmailId = "abcd@gmail.com",
                MobileNo = 7654567833,
                StreetName = "MG Road",
                PinCode = "567834",
                Orders =  orders
            };
            Phone phone = new Phone
            {
                BrandName = "Samsung",
                InStock = 1,
                Price = 72300,
                PhoneDesciption = "Amazing mobile",
                ManufacturingDate = date1
            };
            OrdereredPhone ordereredPhone = new OrdereredPhone { OrderedPhone = phone , Quantity = 2};

            IPhoneRepository rep = new PhoneRepository();
            //rep.SaveCustomer(customer);
            //rep.SaveOrder(order);
            List<CustomerOrder> cOrders = rep.GetCustomerOrders(7);
            foreach (var item in cOrders)
            {
                Console.WriteLine(item.OrderId);
            }
            //rep.SavePhone(phone);
            //rep.SaveOrderedPhone(ordereredPhone, 11);

        }
    }
}
