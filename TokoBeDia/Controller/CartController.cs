using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class CartController
    {
        public static String DoAddCart(int qty,int productId,int userId)
        {
            Cart cp = CartHandler.getCartProduct(productId);
            int productStock = ProductHandler.getProductByID(productId).Stock;

            if (qty < 1)
            {
                return "Quantity must be more than 0";
            }

            if  (cp == null)
            {
                if(qty > productStock)
                {
                    return "Quantity can't be more than available stock";
                }
                CartHandler.createCartProduct(userId, productId, qty);
                return "";
            }
            else
            {

                int currCartStock = cp.Quantity;
                int totalRequestStock = currCartStock + qty;
                
       
                if (totalRequestStock > productStock)
                {
                    return "Quantity must be less than or equals to product stocks";
                }
                CartHandler.updateProduct(productId,userId,totalRequestStock);
                return "";
            }
        }
        public static String DoUpdateCart(int qty, int productId, int userId)
        {
            int productStock = ProductHandler.getProductByID(productId).Stock;

            if (qty == 0)
            {
                CartHandler.deleteCartProduct(productId, userId);
                return "";
            }
            else if (qty < 1)
            {
                return "Quantity must be more than 0";
            }
            else if(qty > productStock)
            {
                return "Quantity can't be more than available stock";
            }
            CartHandler.updateCartProductQty(productId,userId,qty);
            return "";
        }
    }
}