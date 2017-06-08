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
    public partial class Edit_Guarantor : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        string strIniName, strCC1, strRID, strAddress, strMobNo, strNIC, strSoNumber, strRootID, strCityCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (Session["UserType"].ToString() != "Cash Collector" || Session["UserType"].ToString() != "Cash Recovery Officer" || Session["UserType"].ToString() != "Special Recovery Officer")
                {
                    txtTeamID.Enabled = false;
                }
                else
                {
                    Response.Redirect("murabha.aspx");
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void txtCCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (txtCCode.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter contract code.";
                }
                else
                {
                    string strCC = txtCCode.Text.Trim();

                    DataSet dsGetGura = cls_Connection.getDataSet("select * from micro_loan_details l, micro_basic_detail b where l.contra_code = b.contract_code and b.contract_code = '" + strCC + "'");
                    if (dsGetGura.Tables[0].Rows.Count > 0)
                    {
                        string strStatus = dsGetGura.Tables[0].Rows[0]["loan_sta"].ToString();
                        string strChqNo = dsGetGura.Tables[0].Rows[0]["chequ_no"].ToString();
                        string strApproval = dsGetGura.Tables[0].Rows[0]["loan_approved"].ToString();
                        string strBranch = dsGetGura.Tables[0].Rows[0]["city_code"].ToString();
                        string strSoNo = dsGetGura.Tables[0].Rows[0]["society_id"].ToString();
                        string strCACode = dsGetGura.Tables[0].Rows[0]["ca_code"].ToString();
                        hidCACode.Value = strCACode;

                        hidBranch.Value = strBranch;
                        hidSoID.Value = strSoNo;

                        DataSet dsGetGroup = cls_Connection.getDataSet("select max(team_id) from micro_basic_detail where city_code = '" + hidBranch.Value + "' and society_id = '" + hidSoID.Value + "';");
                        string strTeamID = dsGetGura.Tables[0].Rows[0]["team_id"].ToString();
                        string strGuar1 = dsGetGura.Tables[0].Rows[0]["promisers_id"].ToString();
                        string strGuar2 = dsGetGura.Tables[0].Rows[0]["promiser_id_2"].ToString();
                        string strNewGID = "1";
                        if (dsGetGroup.Tables[0].Rows[0][0].ToString() != "")
                        {
                            string strGID = dsGetGroup.Tables[0].Rows[0][0].ToString();
                            int intGID = Convert.ToInt32(strGID) + 1;
                            strNewGID = Convert.ToString(intGID);
                            txtTeamID.Text = strNewGID;
                        }
                        
                            btnChange.Enabled = true;
                            txtTeamID.Enabled = true;
                            txtTeamID.Text = strNewGID;
                            
                    }
                    else
                    {
                        lblMsg.Text = "Invalid Facility Code.";
                        btnChange.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCCode.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Facility Code";
            }
            else if (txtGuara1.Text.Trim() == ""/* && txtGura.Text.Trim() == ""*/)
            {
                lblMsg.Text = "Please ente Guarantor 1.";
            }
            else if (txtGuara2.Text.Trim() == ""/* && txtGura2Fron.Text.Trim() == ""*/)
            {
                lblMsg.Text = "Please ente Guarantor 2.";
            }
            else
            {
                string strCC = txtCCode.Text.Trim();
                string strGur1 = txtGuara1.Text.Trim();
                string strGur2 = txtGuara2.Text.Trim();
                string strNewGID = "1";
                if (txtTeamID.Text.Trim() == "")
                {
                    DataSet dsGetGroup = cls_Connection.getDataSet("select ifnull(max(team_id),0) from micro_basic_detail where city_code = '" + hidBranch.Value + "' and society_id = '" + hidSoID.Value + "';");
                    if (dsGetGroup.Tables[0].Rows[0][0].ToString() != "")
                    {
                        string strGID = dsGetGroup.Tables[0].Rows[0][0].ToString();
                        int intGID = Convert.ToInt32(strGID) + 1;
                        strNewGID = Convert.ToString(intGID);
                    }
                }
                else
                {
                    strNewGID = txtTeamID.Text.Trim();
                    DataSet dsGetGroup = cls_Connection.getDataSet("select * from micro_basic_detail where city_code = '" + hidBranch.Value + "' and society_id = '" + hidSoID.Value + "' and team_id = '" + strNewGID + "';");
                    if (dsGetGroup.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "Invalid Group ID.";
                    }
                }

                MySqlCommand cmdUpdateGuar = new MySqlCommand("Update micro_basic_detail set team_id = '" + strNewGID + "', promisers_id = '" + strGur1 + "',promiser_id_2 = '" + strGur2 + "' where contract_code = '" + strCC + "';");

                int i;
                i = objDBTask.insertEditData(cmdUpdateGuar);

                MySqlCommand cmdUpdateGuar1 = new MySqlCommand("Update micro_basic_detail set team_id = '" + strNewGID + "', promisers_id = '" + strGur1 + "',promiser_id_2 = '" + strGur2 + "' where contract_code = '" + strGur1 + "';");

                int ii;
                ii = objDBTask.insertEditData(cmdUpdateGuar1);

                MySqlCommand cmdUpdateGuar2 = new MySqlCommand("Update micro_basic_detail set team_id = '" + strNewGID + "', promisers_id = '" + strGur1 + "',promiser_id_2 = '" + strGur2 + "' where contract_code = '" + strGur2 + "';");

                int iii;
                iii = objDBTask.insertEditData(cmdUpdateGuar2);

                Clean();
                lblMsg.Text = "Updated Successfully";
            }
        }
        protected void Clean()
        {
            txtCCode.Text = "";
            txtGuara1.Text = "";
            txtGuara2.Text = "";
            txtTeamID.Text = "";
        }
    }
}
