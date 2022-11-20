
using System.ComponentModel.DataAnnotations;

namespace HumanResourceManagementSystem.Models.Entities
{
    public class CivilInfo
    {
        [Required]
        [MaxLength(30)]
        public string Nationality { get; set; }
        [Key]
        [Required]
        [MaxLength(15)]
        public string PanCardNo { get; set; }
    }
}