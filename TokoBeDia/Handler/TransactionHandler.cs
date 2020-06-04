using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class TransactionHandler
    {
        public static void Checkout(int userId,int paymentID)
        {
            List<Cart> cp = CartRepository.getAllCartProducts(userId);
            DateTime now = DateTime.Now;
            for(int i = 0; i < cp.Count(); i++)
            {
                HeaderTransaction transactionHeader = TransactionFactory.CreateHeader(userId, now, paymentID);
                int headerId = TransactionRepository.AddTransactionHeader(transactionHeader).ID;

                DetailTransaction transactionDetail = TransactionFactory.CreateDetail(headerId, cp[i].ProductID, cp[i].Quantity);
                TransactionRepository.AddTransactionDetail(transactionDetail);
            }
            CartRepository.deleteCartProductByUser(cp);
;
        }
    }
}