using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class CartController
    {
        public static String DoAddCart(int qty,int productId,int userId)
        {
            int productStock = ProductRepository.getProductByID(productId).Stock;
            int currCartStock = CartRepository.getCartProductByID(productId).Quantity;
            int totalRequestStock = currCartStock + qty;
            //if the product is already listed in the shopping cart, its cart quantity will be added with the new quantity. 
            if (totalRequestStock > productStock)
            {
                return "Quantity must be less than or equals to product stocks";
            }
            if (qty == 0)
            {
                return "Quantity must be more than 0";
            }
            CartHandler.createCartProduct(userId,productId,qty);
            return "";
        }
    }
}