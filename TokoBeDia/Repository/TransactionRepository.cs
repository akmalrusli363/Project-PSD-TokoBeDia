using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class TransactionRepository
    {
        private static DatabaseEntities db = TokoBeDia.Singleton.DBSingleton.getInstance();
        public static HeaderTransaction AddTransactionHeader(HeaderTransaction transactionHeader)
        {
            db.HeaderTransactions.Add(transactionHeader);
            db.SaveChanges();
            return transactionHeader;
        }

        public static DetailTransaction AddTransactionDetail(DetailTransaction transactionDetail)
        {
            db.DetailTransactions.Add(transactionDetail);
            db.SaveChanges();

            return transactionDetail;
        }

        public static List<HeaderTransaction> GetAllTransactions()
        {
            return db.HeaderTransactions.ToList();
        }

        public static List<HeaderTransaction> GetAllTransactionsByUserID(int userID)
        {
            return db.HeaderTransactions.Where(ht => ht.User.ID == userID).ToList();
        }

        public static TransactionDatas GenerateTransactionLogs(List<HeaderTransaction> transactionList)
        {
            TransactionDatas newDatas = new TransactionDatas();
            var headerTransactionTable = newDatas.HeaderTransaction;
            var detailTransactionTable = newDatas.DetailTransaction;

            foreach (var ht in transactionList)
            {
                var headerTransactionRow = headerTransactionTable.NewRow();

                headerTransactionRow["Transaction ID"] = ht.ID;
                headerTransactionRow["Transaction Date"] = ht.Date;
                headerTransactionRow["User Name"] = ht.User.Name;
                headerTransactionRow["User Email"] = ht.User.Email;
                headerTransactionRow["Payment Type"] = ht.PaymentType.PaymentTypeName;
                headerTransactionTable.Rows.Add(headerTransactionRow);

                foreach (var dt in ht.DetailTransactions)
                {
                    var detailTransactionRow = detailTransactionTable.NewRow();

                    detailTransactionRow["Transaction ID"] = dt.TransactionID;
                    detailTransactionRow["Product ID"] = dt.Product.ID;
                    detailTransactionRow["Product Name"] = dt.Product.Name;
                    detailTransactionRow["Product Price"] = dt.Product.Price;
                    detailTransactionRow["Product Quantity"] = dt.Quantity;
                    detailTransactionRow["Total Price"] = dt.Product.Price * dt.Quantity;
                    detailTransactionTable.Rows.Add(detailTransactionRow);
                }
            }
            return newDatas;
        }
    }
}