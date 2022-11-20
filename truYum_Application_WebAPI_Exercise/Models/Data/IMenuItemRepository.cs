using System.Collections.Generic;
using truYum_Application_WebAPI_Exercise.Models.Entities;

namespace truYum_Application_WebAPI_Exercise.Models.Data
{
    public interface IMenuItemRepository
    {
        MenuItem GetMenuItem(int id);
        List<MenuItem> GetAllMenuItems();
        void Create(MenuItem menuItem);
        void Update(MenuItem menuItem);
        void Delete(int id);
    }
}
