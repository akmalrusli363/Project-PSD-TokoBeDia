using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class ProductController
    {
        public static List<Product> getAllProducts()
        {
            return ProductHandler.getAllProducts();
        }

        public static Product getProductByID(int productID)
        {
            return ProductHandler.getProductByID(productID);
        }

        public static string insertProduct(string name, int price, int stock, int productType)
        {
            if (name.Length <= 0)
            {
                return "Name must be filled!";
            }
            else if (price < 1000 || price % 1000 != 0)
            {
                return "Price must at least 1000 and multiply of 1000!";
            }
            else if (stock < 0)
            {
                return "Stock must at least 1!";
            }
            else if (productType < 0)
            {
                return "Product type must be choosen!";
            }

            try
            {
                ProductHandler.addProduct(productType, name, price, stock);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }

            return "";
        }

        public static string updateProduct(Product product, string name, int price, int stock)
        {
            if (name.Length <= 0)
            {
                return "Name must be filled!";
            }
            else if (price < 1000 || price % 1000 != 0)
            {
                return "Price must at least 1000 and multiply of 1000!";
            }
            else if (stock < 0)
            {
                return "Stock must at least 1!";
            }

            try
            {
                ProductHandler.updateProduct(product.ID, name, price, stock);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }

            return "";
        }

        public static string deleteProduct(Product product)
        {
            try
            {
                ProductHandler.deleteProduct(product.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }

            return "";
        }

        public static List<String> getRandomFiveProducts()
        {
            return ProductHandler.getRandomProductsList(5);
        }
    }
}