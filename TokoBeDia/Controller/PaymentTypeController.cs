using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Handler;
using TokoBeDia.Model;

namespace TokoBeDia.Controller
{
    public class PaymentTypeController
    {
        public static List<PaymentType> getAllPaymentTypes()
        {
            return PaymentTypeHandler.getAllPaymentTypes();
        }

        public static PaymentType getPaymentTypeByID(int paymentTypeID)
        {
            return PaymentTypeHandler.getPaymentTypeByID(paymentTypeID);
        }

        public static string insertPaymentType(string paymentTypeName)
        {
            if (paymentTypeName.Length < 3)
            {
                return "Payment type name must at least 3 characters!";
            }
            else if (paymentTypeName.Length == 0)
            {
                return "Payment type must not be empty!";
            }
            else if (!PaymentTypeHandler.validatePaymentTypeName(paymentTypeName))
            {
                return "These payment type name has already taken!";
            }

            try
            {
                PaymentTypeHandler.addPaymentType(paymentTypeName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }
            return "";
        }

        public static string deletePaymentType(PaymentType pt)
        {
            try
            {
                PaymentTypeHandler.deletePaymentType(pt.PaymentTypeID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Database update on server failure, please try again!";
            }

            return "";
        }

    }
}