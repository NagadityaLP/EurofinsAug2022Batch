using SellPhonesStore.Entities;
using System.Data.Entity;

namespace SellPhonesStore.DataAccess
{
    public class SellPhonesStoreDbContext : DbContext
    {
        public SellPhonesStoreDbContext() : base("name=default")
        {

        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<OrdereredPhone> OrderedPhones { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
