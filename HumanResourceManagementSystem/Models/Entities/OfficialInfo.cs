

using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagementSystem.Models.Entities
{
    public class OfficialInfo
    {
        [Key]
        [Required]
        [MaxLength(15)]
        public string MID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Location { get; set; }
        [Required]
        [MaxLength(50)]
        public string Department { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

    }
}