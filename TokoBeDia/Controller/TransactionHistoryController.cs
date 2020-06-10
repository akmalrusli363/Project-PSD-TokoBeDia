using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;

namespace TokoBeDia.Controller
{
    public class TransactionHistoryController
    {
        public static Object getAllTransactionHistoryById(int userId)
        {
            return TransactionHistoryHandler.getAllTransactionHistoryById(userId);
        }

        public static Object getAllTransactionHistory()
        {
            return TransactionHistoryHandler.getAllTransactionHistory();
        }
    }
}