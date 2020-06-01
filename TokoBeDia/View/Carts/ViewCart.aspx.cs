using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Repository;

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



    }
}