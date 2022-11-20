using KnowledgeHubPortalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace KnowledgeHubPortalProject.Models.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public async Task CreateAsync(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return db.Categories.Find(id);
        }

        public List<Category> SearchCategories(string data)
        {
            return (from c in db.Categories
                             where c.Name.Contains(data) || c.Description.Contains(data)
                             select c).ToList();
        }

        public void Update(Category category)
        {
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}