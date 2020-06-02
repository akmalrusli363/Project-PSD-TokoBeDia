﻿using System;
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
            Cart cartProduct = CartRepository.createCartProduct(userId, productId, qty);
            CartRepository.addCartProduct(cartProduct);
        }

        public static Cart getCartProduct(int productid)
        {
            return CartRepository.getCartProductByID(productid);
        }

        public static void updateProduct(int productid ,int userid, int qty)
        {
            CartRepository.updateCartProductQty(productid,userid,qty);
        }

        public static void deleteCartProduct(int id,int userid)
        {
            CartRepository.deleteCartProduct(id,userid);
        }

        public static void updateCartProductQty(int id, int userid,int qty)
        {
            CartRepository.updateCartProductQty(id,userid,qty);
        }

    }

}