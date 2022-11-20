using SellPhonesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.DataAccess
{
    public class PhoneRepository : IPhoneRepository
    {
        public List<CustomerOrder> GetAllCustomerOrders()
        {
            SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
            List<CustomerOrder> customerOrders = (from o in db.CustomerOrders select o).ToList();
            return customerOrders;
        }

        public List<CustomerOrder> GetCustomerOrders(long customerId)
        {
            SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
            var customerOrders = (from c in db.Customers where c.CustomerId == customerId
                                                  select c.Orders).ToList();
            return customerOrders[0];
        }

        public long SaveCustomer(Customer customer)
        {
            SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
            db.Customers.Add(customer);
            int val = db.SaveChanges();
            return (long)val;
        }

        public long SaveOrder(CustomerOrder order)
        {
            SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
            db.CustomerOrders.Add(order);
            return (long)db.SaveChanges();
        }

        public long SaveOrderedPhone(OrdereredPhone orderPhone, long orderId)
        {
            SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
            CustomerOrder customerOrder = db.CustomerOrders.Find(orderId);
            customerOrder.OrderedPhones.Add(orderPhone); 
            return (long)db.SaveChanges();
        }

        public long SavePhone(Phone phone)
        {
            SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
            db.Phones.Add(phone);
            return (long)db.SaveChanges();
        }
    }
}
