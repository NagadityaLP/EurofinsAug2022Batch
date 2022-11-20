
using System.ComponentModel.DataAnnotations;

namespace ProductsCatalogWebAPIDemo.Models.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public bool IsAvailable { get; set; }
        public string Country { get; set; }
    }
}