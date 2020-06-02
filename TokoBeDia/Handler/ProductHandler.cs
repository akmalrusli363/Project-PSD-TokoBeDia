using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repository;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Handler
{
    public class ProductHandler
    {
        public static Product getProductByID(int productid)
        {
            return ProductRepository.getProductByID(productid);
        }

    }
}