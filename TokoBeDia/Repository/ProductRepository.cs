using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class ProductRepository
    {
        private static DatabaseEntities db = TokoBeDia.Singleton.DBSingleton.getInstance();

        public static List<Product> getAllProducts()
        {
            return db.Products.ToList();
        }

        public static Product getProductByID(int id)
        {
            return db.Products.Where(product => product.ID == id).FirstOrDefault();
        }

        public static Product createProduct(int typeID, string name, int price, int stock)
        {
            return ProductFactory.createProduct(typeID, name, price, stock);
        }

        public static void addProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public static void updateProduct(Product p, string newName, int newPrice, int newStock)
        {
            p.Name = newName;
            p.Price = newPrice;
            p.Stock = newStock;
            db.SaveChanges();
        }

        public static void deleteProduct(Product p)
        {
            db.Products.Remove(p);
            db.SaveChanges();
        }

        public static List<Product> pickRandomProduct(int nums)
        {
            List<Product> randomProducts = db.Products.OrderBy(p => Guid.NewGuid()).Take(nums).ToList();
            return randomProducts;
        }
    }
}