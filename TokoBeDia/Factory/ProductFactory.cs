using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class ProductFactory
    {
        public static Product createProduct(int typeid, String name, int price, int stock)
        {
            return new TokoBeDia.Model.Product()
            {
                ProductTypeID = typeid,
                Name = name,
                Price = price,
                Stock = stock
            };
        }
    }
}