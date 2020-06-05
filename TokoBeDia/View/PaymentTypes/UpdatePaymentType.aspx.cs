using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.PaymentTypes
{
    public partial class UpdatePaymentType : System.Web.UI.Page
    {
        private static PaymentType currentPaymentType = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ViewPaymentType.aspx");
                return;
            }
            if (!IsPostBack)
            {
                int paymentTypeID = Int32.Parse(Request.QueryString["id"]);
                attachProperties(paymentTypeID);
            }
        }

        private void attachProperties(int paymentTypeID)
        {
            if (!IsPostBack)
            {
                currentPaymentType = PaymentTypeController.getPaymentTypeByID(paymentTypeID);
                if (currentPaymentType == null)
                {
                    Response.Redirect("ViewPaymentType.aspx");
                    return;
                }
                PaymentTypeNameBox.Text = currentPaymentType.PaymentTypeName;
            }
        }

        protected void updatePaymentType(object sender, EventArgs e)
        {
            string paymentTypeName = PaymentTypeNameBox.Text;

            string error = PaymentTypeController.updatePaymentType(currentPaymentType, paymentTypeName);

            if (error == "")
            {
                Response.Redirect("ViewPaymentType.aspx");
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }
    }
}