using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

// hati-hati, dilarang keras akses module repository tanpa buat handler dan controller lho!
using TokoBeDia.Repository;

namespace TokoBeDia.View.PaymentTypes
{
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        private static PaymentType currPaymentType = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }

            PaymentTypeTable.DataSource = PaymentTypeController.getAllPaymentTypes();
            PaymentTypeTable.DataBind();
        }

        protected void insertPaymentType(object sender, EventArgs e)
        {
            Response.Redirect("InsertPaymentType.aspx");
        }

        protected void updatePaymentType(object sender, EventArgs e)
        {
            if (currPaymentType == null)
            {
                return;
            }

            int currPaymentTypeID = currPaymentType.PaymentTypeID;
            Response.Redirect("UpdatePaymentType.aspx?id=" + currPaymentTypeID);
            currPaymentType = null;
        }

        protected void deletePaymentType(object sender, EventArgs e)
        {
            if (currPaymentType == null)
            {
                return;
            }

            string error = PaymentTypeController.deletePaymentType(currPaymentType);

            if (error == "")
            {
                currPaymentType = null;
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ErrorMessage.Text = error;
            }
        }

        protected void linkSelect_Click(object sender, EventArgs e)
        {
            int paymentTypeID = Int32.Parse((sender as LinkButton).CommandArgument);
            currPaymentType = PaymentTypeController.getPaymentTypeByID(paymentTypeID);

            PaymentTypeNameBox.Text = currPaymentType.PaymentTypeName;

            UpdatePaymentTypeButton.Enabled = true;
            DeletePaymentTypeButton.Enabled = true;
        }

    }
}