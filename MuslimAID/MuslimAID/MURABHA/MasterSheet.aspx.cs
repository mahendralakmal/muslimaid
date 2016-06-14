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
    public partial class MasterSheet : System.Web.UI.Page
    {
        DBTasks objDBTask = new DBTasks();
        private static MySqlConnection connect = null;

        public void GetToGrid(string contractcode, string FromDate,string ToDate)
        {
            connect = objDBTask.establishConnection();
            string rtn = "USP_M_MASTERSHEET";
            MySqlCommand cmd = new MySqlCommand(rtn, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@ContractCode", contractcode);
            DataSet ds = objDBTask.selectData(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvMasterSheet.DataSource = ds.Tables[0];
                gdvMasterSheet.DataBind();
                btnPrint.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            if (txtContraCode.Text != "" && txtFromDate.Text != "" && txtToDate.Text != "")
            {
                gdvMasterSheet.DataSource = null;
                gdvMasterSheet.DataBind();
                GetToGrid(txtContraCode.Text, txtFromDate.Text, txtToDate.Text);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
