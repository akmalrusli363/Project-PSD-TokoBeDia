using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class TransactionHistoryHandler
    {
        public static Object getAllTransactionHistoryById(int userId)
        {
            return TransactionHistoryRepository.getAllTransactionHistoryById(userId);
        }

        public static Object getAllTransactionHistory()
        {
            return TransactionHistoryRepository.getAllTransactionHistory();
        }
    }
}