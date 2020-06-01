using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repository;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Handler
{
    public class CartHandler
    {
        public static void createCartProduct(int userId , int productId,int qty)
        {
            Cart cartProduct = CartFactory.CreateCart(userId, productId, qty);
            CartRepository.addCartProduct(cartProduct);
        }
    }
}