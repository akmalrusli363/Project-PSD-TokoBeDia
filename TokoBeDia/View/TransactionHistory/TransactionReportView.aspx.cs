using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View.TransactionHistory
{
    public partial class TransactionReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !UserController.isAdmin(Int32.Parse(Session["user"].ToString())))
            {
                Response.Redirect("/View/Home.aspx");
                return;
            }

            TransactionReport report = new TransactionReport();
            CrystalReportViewer1.ReportSource = report;
            report.SetDataSource(TransactionController.GenerateTransactionLogs(TransactionController.GetAllTransactionsList()));
        }

        protected void toTransactionHistory(object sender, EventArgs e)
        {
            Response.Redirect("/View/TransactionHistory/TransactionHistory.aspx");
        }
    }
}