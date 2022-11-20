using ProductsCatalogWebAPIDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalogWebAPIDemo.Models.Data
{
    public interface IProductsCatalogRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
        void Delete(int id);
        void Create(Product product);
        void Update(Product product);
    }
}
