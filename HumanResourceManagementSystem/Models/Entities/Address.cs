using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanResourceManagementSystem.Models.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Street1 { get; set; }
        [MaxLength(200)]
        public string Street2 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Locality { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [MaxLength(30)]
        public string State { get; set; }
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
        [Required]
        [MaxLength(40)]
        public string MailId { get; set; }
        [MaxLength(40)]
        public string AlternateMailId { get; set; }
        [Required]
        [MaxLength(11)]
        public string MobileNumber { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }



    }
}