using System;
using System.ComponentModel.DataAnnotations;

namespace SellPhonesStore.Entities
{
    public class Phone
    {
        private float price;
        
        public long PhoneId { get; set; }
        [Required]
        [MaxLength(500)]
        public string PhoneDesciption { get; set; }
        public float Price 
        {
            get
            {
                return price;
            }
            set 
            { 
                if(value < 0)
                {
                    Console.WriteLine("Value cannot be negative");
                    price = 0;
                }
                else
                    price = value;
            } 
        }
        public DateTime ManufacturingDate { get; set; }
        public string BrandName { get; set; }
        public int InStock { get; set; }

    }
}
