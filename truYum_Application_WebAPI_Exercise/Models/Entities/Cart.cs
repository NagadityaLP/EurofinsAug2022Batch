
using System.ComponentModel.DataAnnotations;

namespace truYum_Application_WebAPI_Exercise.Models.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int UserId  { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }

    }
}