using System.Data.Entity;
using truYum_Application_WebAPI_Exercise.Models.Entities;

namespace truYum_Application_WebAPI_Exercise.Models.Data
{
    public class MenuItemDbContext : DbContext
    {
        public MenuItemDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}