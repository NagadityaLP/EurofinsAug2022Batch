    using ProductsCatalogConsoleApp.Data;
using ProductsCatalogConsoleApp.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProductsCatalogConsoleApp
{
    /*class NamePrice
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }*/
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;


            //Executing Stored Procedure Manually
            SqlParameter p1 = new SqlParameter("@CategoryID", 3);
            db.Database.ExecuteSqlCommand("Category_Delete @CategoryID", p1);
            //AddCustomerSuppliers();
            //SelectCustomers();

            //db.Database.ExecuteSqlCommand("update products set price = price + 500");
        }

        private static void SelectCustomers()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            var customers = db.People.OfType<Customer>();
            foreach (var item in customers)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void AddCustomerSuppliers()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            Address a = new Address();
            Customer c = new Customer { Name = "Customer 1", Discount = 250, Type = "Silver" };
            Supplier s = new Supplier { Name = "Supplier 1", GST = "dfsd23434erwerwe", Rating = 9 };
            c.Address = a;
            s.Address = a;
            db.People.Add(c);
            //db.People.Add(s);
            db.SaveChanges();
        }



        private static void EagerLoading()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            //Load data not only from products table but also from the category table while executing the query
            var plist = from p in db.Products.Include("TheCategory")
                        select p;

            foreach (var item in plist)
            {
                Console.WriteLine($"{item.Name} \t {item.TheCategory.Name}");
            }
        }

        //Virtual keyword is mandatory for lazy loading and it is to be included in the association class
        //i.e. the class in which object of another class is created
        //Here virtual keyword is used in Product class while creating an instance of Category inside it

        //Also "MultipleActiveResultSets=True" need to be included in the connection strings of Config file
        private static void LazyLoading()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            var plist = from p in db.Products
                        select p;

            foreach (var item in plist)
            {
                Console.WriteLine($"{item.Name} \t {item.TheCategory.Name}");
            }
        }

        private static void ExtractDataFromTwoDifferentTables()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            //Extract product name and category name
            //An anonymous class will be created by the compiler to hold the Product name and Category name 
            // For PName and CName - compiler only creates a class with these fields
            //Explicitly new class can be created and fields of that can be used to store the data returned from the query
            var plist = from p in db.Products  
                        select new { PName = p.Name, CName = p.TheCategory.Name };
            foreach (var item in plist)
            {
                Console.WriteLine(item.PName + "\t" + item.CName);
            }
        }

        private static void UpdateExistingProductWithExistingCategory()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var cat = db.Categories.Find(1);
            var p = db.Products.Find(2);
            p.TheCategory = cat;
            db.SaveChanges();
        }

        private static void ProductWithExistingCategory()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            //Add new product with existing category
            var mobileCategory = (from c in db.Categories
                                  where c.Name == "Mobiles"
                                  select c).FirstOrDefault();
            var p = new Product { Name = "Galaxy S7", Price = 70000, Brand = "Samsung", TheCategory = mobileCategory };
            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void saveProductAndCategory()
        {
            ProductsDbContext db = new ProductsDbContext();
            var cat = new Category { Name = "Mobiles", Description = "Smart Devices" };
            var p = new Product { Name = "IPhone 13 Max", Price = 75000, Brand = "Apple", TheCategory = cat };

            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void loggingEntityFrameworkFunctionality()
        {
            Product p = new Product { Name = "Iphone 14 Plus", Price = 1140000 };
            //Establish connection to the database by creating an instance of class extending DbContext
            ProductsDbContext db = new ProductsDbContext();//This will establish a connection to the database server

            //How actually entity framework is doing actions internally
            //Just pass the address of the function to be logged
            db.Database.Log = Console.WriteLine;
            //Products property present in the class extending DbContext acts as Table in the database
            db.Products.Add(p);
            //Proceed data present in the memory to saving the same into database table
            db.SaveChanges();
        }

        private static void Linq()
        {
            //get all products more than 1 lac
            ProductsDbContext db = new ProductsDbContext();
            //LINQ to Entities
            //SQL Select : select * from products where price >= 100000

            var costlyProducts = (from p in db.Products where p.Price >= 100000 select p).ToList();
            foreach (var product in costlyProducts)
                Console.WriteLine($"{product.Name}\t{product.Price}");

            //Lambda expressions
            var costlyProductsList = db.Products.Where(p => p.Price >= 100000);


            var costliestProduct = (from p in db.Products orderby p.Price descending select p).FirstOrDefault();
            Console.WriteLine(costliestProduct.Name);

            int maxPrice = (from p in db.Products select p.Price).Max();
            var costliestProduct1 = from p in db.Products where p.Price == maxPrice select p;

            var result = from p in db.Products
                         where p.Price == ((from m in db.Products select m.Price).Max())
                         select p;

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //linq to objects
            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;
        }

        private static void edit()
        {
            //edit product by id
            ProductsDbContext db = new ProductsDbContext();
            var productToEdit = db.Products.Find(2);
            productToEdit.Price += 500;
            db.SaveChanges();
            Console.WriteLine("Editing done");
        }

        private static void delete()
        {
            //delete product id 1
            //get the object to delete
            ProductsDbContext db = new ProductsDbContext();
            var productToDel = db.Products.Find(1);
            if (productToDel != null)
            {
                db.Products.Remove(productToDel);
                db.SaveChanges();
                Console.WriteLine("Deleted");
            }
            else
                Console.WriteLine("product not found");
        }

        private static void Get()
        {
            //get product by ID
            ProductsDbContext db = new ProductsDbContext();
            var p = db.Products.Find(1);
            if (p == null) Console.WriteLine("Product not found");
            else Console.WriteLine(p.Name + "\t" + p.Price);
        }
        private static void Save()
        {
            //Add new product - Only oo code and not the database code even though data is being stored in the database

            //Create an OO Entity Class Object to be added to the database
            Product p = new Product { Name = "Iphone 14 Plus", Price = 1140000 };
            //Establish connection to the database by creating an instance of class extending DbContext
            ProductsDbContext db = new ProductsDbContext();//This will establish a connection to the database server
            //Products property present in the class extending DbContext acts as Table in the database
            db.Products.Add(p);
            //Proceed data present in the memory to saving the same into database table
            db.SaveChanges();
        }
    }
}
