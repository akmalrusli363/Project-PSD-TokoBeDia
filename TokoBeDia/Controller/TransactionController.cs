using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;

namespace TokoBeDia.Controller
{
    public class TransactionController
    {
        public static void CheckOut(int userId,int paymentID)
        {
            TransactionHandler.Checkout(userId, paymentID);
        }
    }
}