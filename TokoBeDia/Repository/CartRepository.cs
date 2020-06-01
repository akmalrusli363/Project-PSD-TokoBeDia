using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class CartRepository
    {
        private static DatabaseEntities db = TokoBeDia.Singleton.DBSingleton.getInstance();
        public static List<Cart> getAllCartProducts(int userId)
        {
            List<Cart> cp = db.Carts.Where(x => x.UserID == userId).ToList();
            return cp;
        }
        public static Cart getCartProductByID(int id)
        {
            return db.Carts.Where(cart => cart.ProductID == id).FirstOrDefault();
        }

        public static void addCartProduct(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }
    }
}