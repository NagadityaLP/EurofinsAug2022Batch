using KnowledgeHubPortalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortalProject.Models.Data
{
    public interface ICategoriesRepository
    {
        void Create(Category category);
        Task CreateAsync(Category category);
        void Update(Category category);

        Category GetCategory(int id);
        List<Category> GetCategories();
        List<Category> SearchCategories(string data);
        void Delete(int id);    
    }
}
