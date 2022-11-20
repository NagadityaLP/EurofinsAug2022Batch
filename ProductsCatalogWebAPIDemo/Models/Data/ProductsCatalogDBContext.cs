using ProductsCatalogWebAPIDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsCatalogWebAPIDemo.Models.Data
{
    public class ProductsCatalogDBContext : DbContext
    {
        //db configuration
        public ProductsCatalogDBContext() : base("name=DefaultConnection")
        {

        }

        //table configuration
        public DbSet<Product> Products { get; set; }
    }
}