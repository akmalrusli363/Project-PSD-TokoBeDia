using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.View.Carts
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }

            int sum = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                int subTotal = 0;
                subTotal = Int32.Parse(GridView1.Rows[i].Cells[4].Text);
                sum = sum + subTotal;
            }
            totalLabelValue.Text = sum.ToString();
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            int userID = Int32.Parse(Session["user"].ToString());
            CartController.DoDeleteCart(id,userID);
            GridView1.DataBind();
        }

        protected void lbUpdate_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            Response.Redirect("UpdateCart.aspx?id=" + id);
        }

        protected void CheckoutButton1_Click(object sender, EventArgs e)
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
            CheckoutButton1.Visible = true;
            labelPayment.Visible = true;
            listPaymentType.Visible = true;
        }
    }
}