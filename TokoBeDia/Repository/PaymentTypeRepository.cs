using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    }
}