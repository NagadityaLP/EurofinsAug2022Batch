using ProductsCatalogWebAPIDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsCatalogWebAPIDemo.Models.Data
{
    public class ProductsCatalogRepository : IProductsCatalogRepository
    {
        private ProductsCatalogDBContext db = new ProductsCatalogDBContext();
        public void Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            //db.Products.Remove(db.Products.Find(id));

            var productToDelete = db.Products.Find(id);
            db.Entry(productToDelete).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public void Update(Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}