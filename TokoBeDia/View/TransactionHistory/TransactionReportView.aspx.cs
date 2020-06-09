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
            report.SetDataSource(GenerateTransactionLogs(TransactionController.GetAllTransactionsList()));
        }

        protected void toTransactionHistory(object sender, EventArgs e)
        {
            Response.Redirect("/View/TransactionHistory/TransactionHistory.aspx");
        }

        private TransactionDatas GenerateTransactionLogs(List<HeaderTransaction> transactionList)
        {
            TransactionDatas newDatas = new TransactionDatas();
            var headerTransactionTable = newDatas.HeaderTransaction;
            var detailTransactionTable = newDatas.DetailTransaction;

            foreach (var ht in transactionList)
            {
                var headerTransactionRow = headerTransactionTable.NewRow();

                headerTransactionRow["Transaction ID"] = ht.ID;
                headerTransactionRow["Transaction Date"] = ht.Date;
                headerTransactionRow["User Name"] = ht.User.Name;
                headerTransactionRow["User Email"] = ht.User.Email;
                headerTransactionRow["Payment Type"] = ht.PaymentType.PaymentTypeName;
                headerTransactionTable.Rows.Add(headerTransactionRow);

                foreach (var dt in ht.DetailTransactions)
                {
                    var detailTransactionRow = detailTransactionTable.NewRow();

                    detailTransactionRow["Transaction ID"] = dt.TransactionID;
                    detailTransactionRow["Product ID"] = dt.Product.ID;
                    detailTransactionRow["Product Name"] = dt.Product.Name;
                    detailTransactionRow["Product Price"] = dt.Product.Price;
                    detailTransactionRow["Product Quantity"] = dt.Quantity;
                    detailTransactionRow["Total Price"] = dt.Product.Price * dt.Quantity;
                    detailTransactionTable.Rows.Add(detailTransactionRow);
                }
            }
            return newDatas;
        }
    }
}