using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class PaymentTypeFactory
    {
        public static PaymentType createPaymentType(String paymentTypeName)
        {
            return new TokoBeDia.Model.PaymentType()
            {
                PaymentTypeName = paymentTypeName
            };
        }
    }
}