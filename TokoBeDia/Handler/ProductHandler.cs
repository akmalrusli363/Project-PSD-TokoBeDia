using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repository;
using TokoBeDia.Model;

namespace TokoBeDia.Handler
{
    public class ProductHandler
    {
        public static List<Product> getAllProducts()
        {
            return ProductRepository.getAllProducts();
        }

        public static Product getProductByID(int productID)
        {
            return ProductRepository.getProductByID(productID);
        }

        public static void addProduct(int typeID, string name, int price, int stock)
        {
            Product p = ProductRepository.createProduct(typeID, name, price, stock);
            ProductRepository.addProduct(p);
        }

        public static void updateProduct(int id, string name, int price, int stock)
        {
            Product p = ProductRepository.getProductByID(id);
            ProductRepository.updateProduct(p, name, price, stock);
        }

        public static void deleteProduct(int id)
        {
            Product p = ProductRepository.getProductByID(id);
            ProductRepository.deleteProduct(p);
        }

        public static List<String> getRandomProductsList(int nums)
        {
            List<String> randomProducts = ProductRepository.pickRandomProduct(nums)
                .Select(p => String.Format("{0} (Rp {1})", p.Name, p.Price)).ToList();
            return randomProducts;
        }
    }
}