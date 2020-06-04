using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.View.PaymentTypes
{
    public partial class InsertPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }
        }

        protected void insertPaymentType(object sender, EventArgs e)
        {
            string paymentTypeName = PaymentTypeNameBox.Text;

            string error = PaymentTypeController.insertPaymentType(paymentTypeName);

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