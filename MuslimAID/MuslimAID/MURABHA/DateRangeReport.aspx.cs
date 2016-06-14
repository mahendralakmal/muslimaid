using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace LoanSystem.Micro
{
    public partial class DateRangeReport : System.Web.UI.Page
    {
        DBTasks objDBTask = new DBTasks();
        private static MySqlConnection connect = null;

        public void GetToGrid(string FromDate, string ToDate)
        {
            connect = objDBTask.establishConnection();
            string rtn = "USP_M_COLLECTION_REPORT";
            MySqlCommand cmd = new MySqlCommand(rtn, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            DataSet ds = objDBTask.selectData(cmd);
            gdvVoucher.DataSource = ds.Tables[0];
            gdvVoucher.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnPrint.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            if (true)
            {
                gdvVoucher.DataSource = null;
                gdvVoucher.DataBind();
                GetToGrid(txtFromDate.Text, txtToDate.Text);  
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
