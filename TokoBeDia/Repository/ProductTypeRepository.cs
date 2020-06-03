using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class ProductTypeRepository
    {
        private static DatabaseEntities db = TokoBeDia.Singleton.DBSingleton.getInstance();

        public static List<ProductType> getAllProducts()
        {
            return db.ProductTypes.ToList();
        }

        public static ProductType getProductTypeByID(int id)
        {
            return db.ProductTypes.Where(product => product.ID == id).FirstOrDefault();
        }

        public static void addProductType(String name, String description) 
        {
            ProductType pt = ProductTypeFactory.createProductType(name, description);
            db.ProductTypes.Add(pt);
            db.SaveChanges();
        }

        public static void updateProductType(int id, String name, String description)
        {
            ProductType pt = getProductTypeByID(id);
            pt.Name = name;
            pt.Description = description;
            db.SaveChanges();
        }

        public static void deleteProductType(int id)
        {
            ProductType pt = getProductTypeByID(id);
            db.ProductTypes.Remove(pt);
            db.SaveChanges();
        }

        public static bool validateProductTypeName(String productTypeName)
        {
            return (db.ProductTypes.Where(pt => pt.Name == productTypeName).FirstOrDefault() == null);
        }
    }
}