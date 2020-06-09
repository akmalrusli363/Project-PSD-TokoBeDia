using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class TransactionFactory
    {
        public static HeaderTransaction CreateHeader(int userId, DateTime transactionDate,int paymentID)
        {
            return new HeaderTransaction()
            {
                UserID = userId,
                PaymentTypeID = paymentID,
                Date = transactionDate
            };
        }

        public static DetailTransaction CreateDetail(int transactionid, int productId, int qty)
        {
            return new TokoBeDia.Model.DetailTransaction()
            {
                TransactionID = transactionid,
                ProductID = productId,
                Quantity = qty
            };
        }
    }
}