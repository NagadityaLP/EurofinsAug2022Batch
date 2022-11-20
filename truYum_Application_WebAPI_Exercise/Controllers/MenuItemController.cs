using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using truYum_Application_WebAPI_Exercise.Models.Data;

namespace truYum_Application_WebAPI_Exercise.Controllers
{
    public class MenuItemController : ApiController
    {
        //IMenuItemRepository repo = null;
        IMenuItemRepository repo = new MenuItemRepository();

        /*public MenuItemController(IMenuItemRepository repo)
        {
            this.repo = repo;
        }*/

        //Get ......./api/MenuItem/{id}
        public IHttpActionResult GetMenuItem(int id)
        {
            var menuItem = repo.GetMenuItem(id);
            if(menuItem == null)
                return NotFound();
            return Ok(menuItem);
        }
    }
}
