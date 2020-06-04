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

        public static List<ProductType> getAllProductTypes()
        {
            return db.ProductTypes.ToList();
        }

        public static ProductType getProductTypeByID(int id)
        {
            return db.ProductTypes.Where(product => product.ID == id).FirstOrDefault();
        }

        public static ProductType createProductType(String name, String description)
        {
            return ProductTypeFactory.createProductType(name, description);
        }

        public static void addProductType(ProductType pt) 
        {
            db.ProductTypes.Add(pt);
            db.SaveChanges();
        }

        public static void updateProductType(ProductType pt, string newName, string newDescription)
        {
            pt.Name = newName;
            pt.Description = newDescription;
            db.SaveChanges();
        }

        public static void deleteProductType(ProductType pt)
        {
            db.ProductTypes.Remove(pt);
            db.SaveChanges();
        }

        public static bool validateProductTypeName(string productTypeName)
        {
            return (db.ProductTypes.Where(pt => pt.Name == productTypeName).FirstOrDefault() == null);
        }
    }
}