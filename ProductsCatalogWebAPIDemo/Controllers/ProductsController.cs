using ProductsCatalogWebAPIDemo.Models.Data;
using ProductsCatalogWebAPIDemo.Models.Entities;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;

namespace ProductsCatalogWebAPIDemo.Controllers
{
    public class ProductsController : ApiController
    {
        IProductsCatalogRepository repo = new ProductsCatalogRepository();
        //Step 1. Design API End Points

        //Get ...../api/Products/
        [HttpGet]
        [EnableQuery]
        public IQueryable<Product> GetProducts()
        {
            return repo.GetProducts().AsQueryable();
        }
        /*public IHttpActionResult GetProduct(int id)
        {
            var product = repo.GetProduct(id);
            if(product == null)
            {
                //return 404
                return NotFound();
            }
            //return ok  + data
            return Ok(product);
        }

        //GET ..../api/products/brand/apple
        [HttpGet]
        [Route("api/products/brand/{brand}")]
        public IHttpActionResult GetProductByBrand(string brand)
        {
            var products = repo.GetProducts().Where(p => p.Brand == brand);
            if (products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

        //get cheapest product
        [Route("api/products/cheapest")]
        public IHttpActionResult GetCheapestProduct()
        {
            var cheapestProduct = repo.GetProducts().OrderBy(p => p.Price).FirstOrDefault();    
            return Ok(cheapestProduct);
        }

        //get costliest product
        [Route("api/products/costliest")]
        public IHttpActionResult GetCostliestProduct()
        {
            var costliestProduct = repo.GetProducts().OrderByDescending(p => p.Price).FirstOrDefault();
            return Ok(costliestProduct);
        }

        //color based product : color
        [Route("api/products/color/{color}")]
        public IHttpActionResult GetProductByColor(string color)
        {
            var products = repo.GetProducts().Where(p => p.Color == color);
            if(products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

        //get price range product : minPrice, maxPrice
        [Route("api/products/min/{min}/max/{max}")]
        public IHttpActionResult GetProductByMinMax(int min, int max)
        {
            var products = repo.GetProducts().Where(p => p.Price >= min && p.Price <= max);
            if (products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

        //Get available products
        [Route("api/products/instock")]
        public IHttpActionResult GetProductsInStock()
        {
            var products = repo.GetProducts().Where(p => p.IsAvailable);
            if (products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

        public IHttpActionResult GetProductsInStockAsync()
        {
            var products = repo.GetProducts().Where(p => p.IsAvailable);
            if (products.Count() == 0)
                return NotFound();
            return Ok(products);
        }*/

        //Read - Write endpoints

        //Create a new product
        public IHttpActionResult Post(Product product)//Model binder will fills this parameter
        {
            if(!ModelState.IsValid)
                return BadRequest("Invalid input"); // Status code is 400
            repo.Create(product);
            //return 3 things : Status code - 201, Location - Uri, Data(programmatically certain data might be added along with the user provided data) 
            return Created($"api/products/{product.ProductID}", product);
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var productToDelete = repo.GetProduct(id);
            if (productToDelete == null)
                return NotFound();
            repo.Delete(id); 
            return Ok(productToDelete);
        }

        //Edit a product
        public IHttpActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");
            repo.Update(product);
            return Ok(product);
        }

    }
}
