using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class ProductTypeHandler
    {
        public static List<ProductType> getAllProductTypes()
        {
            return ProductTypeRepository.getAllProductTypes().ToList();
        }

        public static ProductType getProductTypeByID(int id)
        {
            return ProductTypeRepository.getProductTypeByID(id);
        }

        public static void addProductType(String name, String description)
        {
            ProductType pt = ProductTypeRepository.createProductType(name, description);
            ProductTypeRepository.addProductType(pt);
        }

        public static void updateProductType(int id, string name, string description)
        {
            ProductType pt = ProductTypeRepository.getProductTypeByID(id);
            ProductTypeRepository.updateProductType(pt, name, description);
        }

        public static void deleteProductType(int id)
        {
            ProductType pt = ProductTypeRepository.getProductTypeByID(id);
            ProductTypeRepository.deleteProductType(pt);
        }

        public static bool validateProductTypeName(string productTypeName)
        {
            return ProductTypeRepository.validateProductTypeName(productTypeName);
        }
    }
}