using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;

namespace TokoBeDia.Controller
{
    public class TransactionHistoryController
    {
        public static List<TransactionHistory> getAllTransactionHistoryById(int userId)
        {
            return TransactionHistoryHandler.getAllTransactionHistoryById(userId).ToList();
        }

        public static List<TransactionHistory> getAllTransactionHistory()
        {
            return TransactionHistoryHandler.getAllTransactionHistory().ToList();
        }
    }
}