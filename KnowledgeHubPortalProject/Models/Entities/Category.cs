using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortalProject.Models.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Kindly Enter Category name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}