using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class PaymentTypeRepository
    {
        private static DatabaseEntities db = TokoBeDia.Singleton.DBSingleton.getInstance();

        public static List<PaymentType> getAllPayments()
        {
            return db.PaymentTypes.ToList();
        }

        public static PaymentType getPaymentTypeByID(int id)
        {
            return db.PaymentTypes.Where(payment => payment.PaymentTypeID == id).FirstOrDefault();
        }

        public static PaymentType createPaymentType(String paymentTypeName)
        {
            return PaymentTypeFactory.createPaymentType(paymentTypeName);
        }

        public static void addPaymentType(PaymentType pt)
        {
            db.PaymentTypes.Add(pt);
            db.SaveChanges();
        }

        public static void updatePaymentType(PaymentType pt, string newPaymentTypeName)
        {
            pt.PaymentTypeName = newPaymentTypeName;
            db.SaveChanges();
        }

        public static void deletePaymentType(PaymentType pt)
        {
            db.PaymentTypes.Remove(pt);
            db.SaveChanges();
        }

        public static bool validatePaymentTypeName(string paymentTypeName)
        {
            return (db.PaymentTypes.Where(pt => pt.PaymentTypeName == paymentTypeName).FirstOrDefault() == null);
        }

    }
}