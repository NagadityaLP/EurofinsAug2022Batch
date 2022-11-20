using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SellPhonesStore.Entities
{
    public class CustomerOrder
    {
        [Key]
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public float OrderTotal { get; set; }
        public virtual List<OrdereredPhone> OrderedPhones { get; set; }
    }
}
