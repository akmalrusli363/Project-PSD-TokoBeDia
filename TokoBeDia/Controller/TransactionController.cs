using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class TransactionController
    {
        public static void CheckOut(int userId,int paymentID)
        {
            TransactionHandler.Checkout(userId, paymentID);
        }

        public static List<HeaderTransaction> GetAllTransactionsList()
        {
            return TransactionHandler.GetAllTransactionsList();
        }

        public static List<HeaderTransaction> GetAllTransactionsListByID(int userID)
        {
            return TransactionHandler.GetAllTransactionsListByID(userID);
        }
    }
}