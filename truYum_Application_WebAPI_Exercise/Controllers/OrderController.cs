using System.Web.Http;
using truYum_Application_WebAPI_Exercise.Models.Data;
using truYum_Application_WebAPI_Exercise.Models.Entities;
using RestSharp;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using Newtonsoft.Json.Linq;

namespace truYum_Application_WebAPI_Exercise.Controllers
{
    public class OrderController : ApiController
    {
        //IOrderItemRepository repo = null;
        IOrderItemRepository repo = new OrderItemRepository();
        /*public OrderController(IOrderItemRepository repo)
        {
            this.repo = repo;
        }*/
        
        
        //Post ..../api/order/

        //[HttpPost]
        //[System.Web.Http.Route("api/order/{menuItemId}")]
        public IHttpActionResult Post(int menuItemId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input");

            //local server address
            var client = new RestClient("https://localhost:44376/");

            //api from which content to be brought from
            var request = new RestRequest("api/MenuItem/{menuItemId}", Method.Get);
            request.AddUrlSegment("menuItemId", menuItemId);

            //getting response from the specified api
            RestResponse response = client.Execute(request);

            //extracting content from the response object. Here content will bee the string
            var content = response.Content;

            //parsing string to the json object in order to access in a key-value manner
            JObject jsonContent = JObject.Parse(content);

            //Create cart object by passing values obtained from the Get request of requested api. In this case MenuItem
            Cart cart = new Cart { MenuItemId = (int)jsonContent["Id"], MenuItemName = (string)jsonContent["Name"]  };
            repo.Create(cart);
            return Created($"api/order/{cart.MenuItemId}", cart);
            
        }




        



    }
}
