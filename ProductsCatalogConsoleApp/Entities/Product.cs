using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCatalogConsoleApp.Entities
{

    //Relationships
    //Product -> Category = 1 : 1
    //Category -> Product = 1 : n
    //Supplier -> Product = m : n - In this case SupplierProduct new table will be automatically created by the compiler
    //Supplier -> Address = 1 : 1 - Here since Address class has no ID field and is explicitly declared as Complex
    //      Type, no new table will be created for Address. Rather Address fields will be attached to the Supplier 
    //      table itself as Supplier class has association relationship with the Address class
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public int ProfitMargin { get; set; }

        public string Brand { get; set; }   
        //For lazy loading
        public virtual Category TheCategory { get; set; }
        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
    //[Table("Suppliers")]
    public class Supplier : Person
    {
        //public int SupplierID { get; set; }
        //public string Name { get; set; }
        public string GST { get; set; }
        public int Rating { get; set; }
        public virtual List<Product> Products { get; set;} = new List<Product>();
        //public Address Address { get; set; }
    }

    [ComplexType] // Don't map Address class to a table. Rather add fields inside this class into the class in which it's object is created(Association)
    //Also ID field should not be given for not generating a table
    public class Address
    {
        public string Area { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
    abstract public class Person
    {
        //TPC
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
    //[Table("Customers")]
    public class Customer : Person
    {
        public int Discount { get; set; }
        public string Type { get; set; }

    }

}
