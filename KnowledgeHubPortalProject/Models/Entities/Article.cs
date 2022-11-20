

using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortalProject.Models.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public bool IsApproved { get; set; }
        public string PostedBy { get; set; }
        public DateTime DateSubmited { get; set; }
    }
}