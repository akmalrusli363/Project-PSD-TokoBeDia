using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia
{
    public class TransactionHistory
    {
        public int transactionId { get; set; }
        public DateTime transactionDate { get; set; }
        public String paymentTypeName { get; set; }
        public String productName { get; set; }
        public int productQuantity { get; set; }
        public int productPrice { get; set; }
    }
}