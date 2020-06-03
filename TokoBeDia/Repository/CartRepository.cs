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

        public static Cart getCartProductByUserID(int productid,int userid)
        {
            return db.Carts.Where(cart => (cart.ProductID == productid && cart.UserID == userid)).FirstOrDefault();
        }

        public static void updateCartProductQty(int productId,int userId,int qty)
        {
            Cart p = getCartProductByUserID(productId,userId);
            p.Quantity = qty;
            db.SaveChanges();
        }

        public static void addCartProduct(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static Cart createCartProduct(int userId,int productId,int qty)
        {
            return CartFactory.CreateCart(userId, productId, qty);
        }

        public static void deleteCartProduct(int id,int userid)
        {
            Cart c = getCartProductByUserID(id,userid);
            db.Carts.Remove(c);
            db.SaveChanges();
        }
    }
}