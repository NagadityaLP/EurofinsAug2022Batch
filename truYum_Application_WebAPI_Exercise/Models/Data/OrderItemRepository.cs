using System;
using System.Collections.Generic;
using System.Linq;
using truYum_Application_WebAPI_Exercise.Models.Entities;

namespace truYum_Application_WebAPI_Exercise.Models.Data
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private MenuItemDbContext db = new MenuItemDbContext();
        public void Create(Cart cartItem)
        {
            db.Carts.Add(cartItem);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Carts.Remove(db.Carts.Find(id));
            db.SaveChanges();
        }

        public List<Cart> GetAllCarts()
        {
            return db.Carts.ToList();
        }

        public Cart GetCart(int id)
        {
            return db.Carts.Find(id);
        }

        public void Update(Cart cartItem)
        {
            db.Entry(cartItem).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}