using System.Collections.Generic;
using truYum_Application_WebAPI_Exercise.Models.Entities;

namespace truYum_Application_WebAPI_Exercise.Models.Data
{
    public interface IOrderItemRepository
    {
        Cart GetCart(int id);
        List<Cart> GetAllCarts();
        void Create(Cart cartItem);
        void Update(Cart cartItem);
        void Delete(int id);
    }
}
