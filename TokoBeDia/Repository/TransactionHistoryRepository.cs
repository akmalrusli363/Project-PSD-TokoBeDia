using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class TransactionHistoryRepository
    {
        private static DatabaseEntities db = TokoBeDia.Singleton.DBSingleton.getInstance();

        public static Object getAllTransactionHistoryById(int userId)
        {
            var queryTransactionHistory = (from ht in db.HeaderTransactions
                    join dt in db.DetailTransactions
                    on ht.ID equals dt.TransactionID
                    join p in db.Products
                    on dt.ProductID equals p.ID
                    join pt in db.PaymentTypes
                    on ht.PaymentTypeID equals pt.PaymentTypeID
                    where ht.UserID == userId
                    select new 
                    {
                        transactionId = ht.ID,
                        transactionDate = ht.Date,
                        paymentTypeName = pt.PaymentTypeName,
                        productName = p.Name,
                        productQuantity = dt.Quantity,
                        productPrice = p.Price
                    });
            return queryTransactionHistory.ToList();
        }

        public static Object getAllTransactionHistory()
        {
            var queryTransactionHistory = (from ht in db.HeaderTransactions
                                           join dt in db.DetailTransactions
                                           on ht.ID equals dt.TransactionID
                                           join p in db.Products
                                           on dt.ProductID equals p.ID
                                           join pt in db.PaymentTypes
                                           on ht.PaymentTypeID equals pt.PaymentTypeID
                                           select new 
                                           {
                                               transactionId = ht.ID,
                                               transactionDate = ht.Date,
                                               paymentTypeName = pt.PaymentTypeName,
                                               productName = p.Name,
                                               productQuantity = dt.Quantity,
                                               productPrice = p.Price
                                           });
            return queryTransactionHistory.ToList();
        }
    }
}