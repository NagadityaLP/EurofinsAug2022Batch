using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace SellPhonesStore.Entities
{
    public class Customer
    {
        
        private string emailId;
        public long CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        public string EmailId 
        {
            get { return emailId; }
            set
            {
                if(isEmailValid(value))
                    emailId = value;
                else
                    Console.WriteLine("EmailId entered is not valid.");
            }
        }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string PinCode { get; set; }
        public long MobileNo { get; set; }
        public virtual List<CustomerOrder> Orders { get; set; }

        private static bool isEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
