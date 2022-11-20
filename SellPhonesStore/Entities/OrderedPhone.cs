using System;

namespace SellPhonesStore.Entities
{
    public class OrdereredPhone
    {
        private float quantity;
        public long OrdereredPhoneId { get; set; }
        public Phone OrderedPhone { get; set; }
        public float Quantity 
        {
            get { return quantity; }
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Quantity should be non-negative");
                    quantity = 0;
                }
                else
                    quantity = value;
            }
        }
    }
}
