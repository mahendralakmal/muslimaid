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
    public partial class Change_CRO : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    string strBranch = Session["Branch"].ToString();
                    lblBranch.Text = strBranch;

                    DataSet dsGetRootID = objDBTask.selectData("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");

                    cmbRoot.Items.Add("");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();

                    }
                }
            }
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (lblBranch.Text.Trim() == "")
            {
                lblMsg.Text = "Invalid Transaction.";
            }
            else if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Contract Code.";
            }
            else
            {
                DataSet dsGetValid = objDBTask.selectData("select * from micro_basic_detail where city_code = '" + lblBranch.Text.Trim() + "' and contract_code = '" + txtCC.Text.Trim() + "'");
                if (dsGetValid.Tables[0].Rows.Count > 0)
                {
                    btnSubmit.Enabled = true;
                }
                else
                {

                    btnSubmit.Enabled = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (lblBranch.Text.Trim() == "")
            {
                lblMsg.Text = "Invalid Transaction.";
            }
            else if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Contract Code.";
            }
            else if (cmbRoot.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select CRO.";
            }
            else
            {
                MySqlCommand cmdUpdateChequ = new MySqlCommand("Update micro_basic_detail set root_id = '" + cmbRoot.SelectedItem.Value + "' where contract_code = '" + txtCC.Text.Trim() + "';");
                int i;
                i = objDBTask.insertEditData(cmdUpdateChequ);

                lblMsg.Text = "Updated Successfully";

                txtCC.Text = "";
            }
        }
    }
}
