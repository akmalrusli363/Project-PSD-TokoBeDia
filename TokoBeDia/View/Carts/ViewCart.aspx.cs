using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Handler;

namespace TokoBeDia.View.Carts
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                int subTotal = 0;
                subTotal = Int32.Parse(GridView1.Rows[i].Cells[4].Text);
                sum = sum + subTotal;
            }
            totalLabel1.Text = sum.ToString();
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            int userID = Int32.Parse(Session["user"].ToString());
            CartHandler.deleteCartProduct(id,userID);
            GridView1.DataBind();
        }

        protected void lbUpdate_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            Response.Redirect("UpdateCart.aspx?id=" + id);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Session["user"].ToString());
            int paymentID = Int32.Parse(listPaymentType.Text);
            ErrorMessage.Text = CartController.checkout(listPaymentType.Text,userID);
            if (ErrorMessage.Text=="")
            {
                TransactionController.CheckOut(userID,paymentID);
                GridView1.DataBind();
                ErrorMessage.Text = "Checkout Success";
            }
        }
        protected void CheckoutButton2_Click(object sender, EventArgs e)
        {
            CheckoutButton2.Visible = false;
            Button1.Visible = true;
            labelPayment.Visible = true;
            listPaymentType.Visible = true;
        }
    }
}