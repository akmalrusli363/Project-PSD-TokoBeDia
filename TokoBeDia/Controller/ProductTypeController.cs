using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class ProductTypeController
    {
        public static List<ProductType> getAllProductTypes()
        {
            return ProductTypeHandler.getAllProductTypes();
        }

        public static ProductType getProductTypeByID(int productTypeID)
        {
            return ProductTypeHandler.getProductTypeByID(productTypeID);
        }

        public static string insertProductType(string name, string description)
        {
            if (name.Length < 5)
            {
                return "Name must at least 5 characters!";
            }
            else if (description.Length <= 0)
            {
                return "Description must not be empty!";
            }
            else if (!ProductTypeHandler.validateProductTypeName(name))
            {
                return "These product type name has already taken!";
            }

            try
            {
                ProductTypeHandler.addProductType(name, description);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }
            return "";
        }

        public static string updateProductType(ProductType pt, string name, string description)
        {
            if (name.Length < 5)
            {
                return "Name must at least 5 characters!";
            }
            else if (description.Length <= 0)
            {
                return "Description must not be empty!";
            }
            else if (!name.Equals(pt.Name) && !ProductTypeHandler.validateProductTypeName(name))
            {
                return String.Format("These product type name has already taken! " +
                    "Use old name: '{0}' or other non-existent product type instead.", pt.Name);
            }

            try
            {
                ProductTypeHandler.updateProductType(pt.ID, name, description);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }
            return "";
        }

        public static string deleteProductType(ProductType pt)
        {
            try
            {
                ProductTypeHandler.deleteProductType(pt.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }

            return "";
        }
    }
}