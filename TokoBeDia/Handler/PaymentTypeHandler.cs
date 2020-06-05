using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class PaymentTypeHandler
    {
        public static List<PaymentType> getAllPaymentTypes()
        {
            return PaymentTypeRepository.getAllPayments().ToList();
        }

        public static PaymentType getPaymentTypeByID(int id)
        {
            return PaymentTypeRepository.getPaymentTypeByID(id);
        }

        public static void addPaymentType(String paymentTypeName)
        {
            PaymentType pt = PaymentTypeRepository.createPaymentType(paymentTypeName);
            PaymentTypeRepository.addPaymentType(pt);
        }

        public static void deletePaymentType(int id)
        {
            PaymentType pt = PaymentTypeRepository.getPaymentTypeByID(id);
            PaymentTypeRepository.deletePaymentType(pt);
        }

        public static bool validatePaymentTypeName(string paymentTypeName)
        {
            return PaymentTypeRepository.validatePaymentTypeName(paymentTypeName);
        }

    }
}