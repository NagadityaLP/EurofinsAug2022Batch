using System.Collections.Generic;
using System.Linq;
using truYum_Application_WebAPI_Exercise.Models.Entities;

namespace truYum_Application_WebAPI_Exercise.Models.Data
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private MenuItemDbContext db = new MenuItemDbContext();

        public void Create(MenuItem menuItem)
        {
            db.MenuItems.Add(menuItem);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.MenuItems.Remove(db.MenuItems.Find(id));
            db.SaveChanges();
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return db.MenuItems.ToList();
        }

        public MenuItem GetMenuItem(int id)
        {
            return db.MenuItems.Find(id);
        }

        public void Update(MenuItem menuItem)
        {
            db.Entry(menuItem).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}