using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;

namespace TokoBeDia.View.TransactionHistory
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                int userId = Convert.ToInt32(Session["user"]);
                if (UserController.isAdmin(userId) == false)
                {
                    viewTransactionHistory.DataSource = TransactionHistoryController.getAllTransactionHistoryById(userId);
                    viewTransactionHistory.DataBind();
                    viewTransactionReport.Visible = false;
                }
                else
                {
                    viewTransactionHistory.DataSource = TransactionHistoryController.getAllTransactionHistory();
                    viewTransactionHistory.DataBind();
                }
                    
            }
            else
            {
                Response.Redirect("/View/Home.aspx");
            }
         
        }

        protected void toTransactionReport(object sender, EventArgs e)
        {
            Response.Redirect("/View/TransactionHistory/TransactionReportView.aspx");
        }
    }
}