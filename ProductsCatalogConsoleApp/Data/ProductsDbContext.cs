
using ProductsCatalogConsoleApp.Entities;
using System.Data.Entity;

namespace ProductsCatalogConsoleApp.Data
{
    public class ProductsDbContext : DbContext
    {
        //1. Configure the Database

        //Please use connectionstring named default which is present in the app.config file to connect to the database
        public ProductsDbContext() : base("name=default")
        {

        }

        //For TPC
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //map producs to stored procedures
            //modelBuilder.Entity<Product>().MapToStoredProcedures();

            //map all the types in the database to stored procedures
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());

            // Fluent API
            // TPC - For table of Customer objects, name the table as Customers. In herit all the menbers from its parent class and create attributes in this table only
            modelBuilder.Entity<Customer>().Map(c => c.MapInheritedProperties()).ToTable("Customers");

            modelBuilder.Entity<Supplier>().Map(s => s.MapInheritedProperties()).ToTable("Suppliers");

        }

        //2. Configure/map the tables with Entity

        //return type is must and should DbSet only
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> People { get; set; } //People - Persons
        //public DbSet<Customer> Customers { get; set; }
    }
}
