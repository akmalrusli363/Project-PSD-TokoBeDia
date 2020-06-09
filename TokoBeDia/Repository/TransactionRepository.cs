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
    }
}