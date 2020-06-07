using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class TransactionHistoryHandler
    {
        public static List<TransactionHistory> getAllTransactionHistoryById(int userId)
        {
            return TransactionHistoryRepository.getAllTransactionHistoryById(userId);
        }

        public static List<TransactionHistory> getAllTransactionHistory()
        {
            return TransactionHistoryRepository.getAllTransactionHistory();
        }
    }
}