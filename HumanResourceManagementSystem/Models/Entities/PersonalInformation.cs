using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanResourceManagementSystem.Models.Entities
{
    public class PersonalInformation
    {
        public int PersonalInformationID { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        public virtual Address Address { get; set; }
        public virtual Education Education { get; set; }
        public virtual CivilInfo CivilInfo { get; set; }
        public virtual OfficialInfo OfficialInfo { get; set; }
    }
}