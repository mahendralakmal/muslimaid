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

namespace MuslimAID.MURABAHA
{
    public partial class Edit_Center_Detail : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        string strloginID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    string strBranch = Session["Branch"].ToString();

                    DataSet dsBranch;
                    MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch where b_code = '" + strBranch + "' ORDER BY 2");
                    dsBranch = objDBTask.selectData(cmdBranch);
                    //cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                        cmbCityCode.Items[i].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                    }

                    //Add Villege
                    DataSet dsVillage;
                    MySqlCommand cmdVillage = new MySqlCommand("select * from villages_name where city_code = '" + strBranch + "'");
                    dsVillage = objDBTask.selectData(cmdVillage);
                    cmbVillages.Items.Add("");
                    for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                    {
                        cmbVillages.Items.Add(dsVillage.Tables[0].Rows[i][2].ToString());
                        //cmdVillage.Items[i].Value = dsVillage.Tables[0].Rows[i][1].ToString();
                    }

                    //Add Root
                    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");

                    //cmbRoot.Items.Add("");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbRoot.Items[i].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();

                    }

                    //cmbCityCode.SelectedItem.Value = strBranch;
                    cmbCityCode.Enabled = true;
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void cmbVillages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbCenterName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
