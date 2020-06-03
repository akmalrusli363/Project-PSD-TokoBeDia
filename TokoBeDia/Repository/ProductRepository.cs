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

        public static void addProduct(int typeID, string name, int price, int stock)
        {
            Product p = ProductFactory.createProduct(typeID, name, price, stock);
            db.Products.Add(p);
            db.SaveChanges();
        }

        public static void updateProduct(int id, string name, int price, int stock)
        {
            Product p = getProductByID(id);
            p.Name = name;
            p.Price = price;
            p.Stock = stock;
            db.SaveChanges();
        }

        public static void deleteProduct(int id)
        {
            Product p = getProductByID(id);
            db.Products.Remove(p);
            db.SaveChanges();
        }

        public static List<String> pickRandomProduct(int nums, string field)
        {
            List<String> randomProducts = db.Products.OrderBy(p => Guid.NewGuid()).Take(nums)
                .ToList().Select(p =>  String.Format("{0} (Rp {1})", p.Name, p.Price)).ToList();
            return randomProducts;
        }
    }
}