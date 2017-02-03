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
                txtTeamID.Enabled = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
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

                        if (strBranch != "PL1" || strBranch != "PL")
                        {
                            string strTeamID = dsGetGura.Tables[0].Rows[0]["team_id"].ToString();
                            string strGuar1 = dsGetGura.Tables[0].Rows[0]["promisers_id"].ToString();
                            string strGuar2 = dsGetGura.Tables[0].Rows[0]["promiser_id_2"].ToString();
                            string strNewGID = "1";
                            if (txtTeamID.Text.Trim() == "")
                            {
                                DataSet dsGetGroup = cls_Connection.getDataSet("select max(team_id) from micro_basic_detail where city_code = '" + hidBranch.Value + "' and society_id = '" + hidSoID.Value + "';");
                                if (dsGetGroup.Tables[0].Rows[0][0].ToString() != "")
                                {
                                    string strGID = dsGetGroup.Tables[0].Rows[0][0].ToString();
                                    int intGID = Convert.ToInt32(strGID) + 1;
                                    strNewGID = Convert.ToString(intGID);
                                    txtTeamID.Text = strNewGID;
                                }
                            }
                            hidBranch.Value = strBranch;
                            hidSoID.Value = strSoNo;

                            //if (strTeamID == "" && strGuar1 == "" && strGuar2 == "")
                            //{
                            btnChange.Enabled = true;
                            txtGura.Text = strBranch + "/" + strSoNo + "/";
                            txtGura2Fron.Text = strBranch + "/" + strSoNo + "/";
                            txtTeamID.Enabled = true;
                            txtGura.Enabled = true;
                            txtGura2Fron.Enabled = true;
                        }
                        else
                        {
                            if ((strApproval == "Y") && (strChqNo != "") && (strStatus != "C"))
                            {
                                lblMsg.Text = "Loan is Approved...";
                                btnChange.Enabled = false;
                            }
                            else
                            {
                                string strTeamID = dsGetGura.Tables[0].Rows[0]["team_id"].ToString();
                                string strGuar1 = dsGetGura.Tables[0].Rows[0]["promisers_id"].ToString();
                                string strGuar2 = dsGetGura.Tables[0].Rows[0]["promiser_id_2"].ToString();
                                string strNewGID = "1";
                                if (txtTeamID.Text.Trim() == "")
                                {
                                    DataSet dsGetGroup = cls_Connection.getDataSet("select max(team_id) from micro_basic_detail where city_code = '" + hidBranch.Value + "' and society_id = '" + hidSoID.Value + "';");
                                    if (dsGetGroup.Tables[0].Rows[0][0].ToString() != "")
                                    {
                                        string strGID = dsGetGroup.Tables[0].Rows[0][0].ToString();
                                        int intGID = Convert.ToInt32(strGID) + 1;
                                        strNewGID = Convert.ToString(intGID);
                                        txtTeamID.Text = strNewGID;
                                    }
                                }
                                hidBranch.Value = strBranch;
                                hidSoID.Value = strSoNo;

                                //if (strTeamID == "" && strGuar1 == "" && strGuar2 == "")
                                //{
                                btnChange.Enabled = true;
                                txtGura.Text = strBranch + "/" + strSoNo + "/";
                                txtGura2Fron.Text = strBranch + "/" + strSoNo + "/";
                                //}
                                //else
                                //{
                                //txtGuara1.Text = strGuar1;
                                //txtGuara2.Text = strGuar2;
                                //txtTeamID.Text = strTeamID;
                                //    btnChange.Enabled = false;
                                //    lblMsg.Text = "Alredy Change.";

                                //}
                            }
                            txtTeamID.Enabled = false;
                            txtGura.Enabled = false;
                            txtGura2Fron.Enabled = false;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Invalid Contract Code.";
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
                lblMsg.Text = "Please enter Contract Code";
            }
            else if (txtGuara1.Text.Trim() == "" && txtGura.Text.Trim() == "")
            {
                lblMsg.Text = "Please ente Guarantor 1.";
            }
            else if (txtGuara2.Text.Trim() == "" && txtGura2Fron.Text.Trim() == "")
            {
                lblMsg.Text = "Please ente Guarantor 2.";
            }
            else
            {
                string strCC = txtCCode.Text.Trim();
                string strGur1 = txtGura.Text.Trim() + txtGuara1.Text.Trim();
                string strGur2 = txtGura2Fron.Text.Trim() + txtGuara2.Text.Trim();
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

                MySqlCommand cmdUpdateGuar1 = new MySqlCommand("Update micro_basic_detail set team_id = '" + strNewGID + "', promisers_id = '" + hidCACode.Value + "',promiser_id_2 = '" + strGur2 + "' where ca_code = '" + strGur1 + "';");

                int ii;
                ii = objDBTask.insertEditData(cmdUpdateGuar1);

                MySqlCommand cmdUpdateGuar2 = new MySqlCommand("Update micro_basic_detail set team_id = '" + strNewGID + "', promisers_id = '" + hidCACode.Value + "',promiser_id_2 = '" + strGur1 + "' where ca_code = '" + strGur2 + "';");

                int iii;
                iii = objDBTask.insertEditData(cmdUpdateGuar2);

                //Update Customer to POS/////////////////////////////////////////////////////////////////////
                #region UpdateCustomertoPOS
                try
                {
                    try
                    {
                        DataSet dsData = cls_Connection.getDataSet("select contract_code,initial_name,society_id,city_code,p_address,mobile_no,nic,root_id from micro_basic_detail where contract_code = '" + strCC + "';");
                        if (dsData.Tables[0].Rows.Count > 0)
                        {
                            strCC1 = dsData.Tables[0].Rows[0]["contract_code"].ToString();
                            strIniName = dsData.Tables[0].Rows[0]["initial_name"].ToString();
                            strRootID = dsData.Tables[0].Rows[0]["root_id"].ToString();
                            strCityCode = dsData.Tables[0].Rows[0]["city_code"].ToString();
                            DataSet dsGetRoot = cls_Connection.getDataSet("select idrbf_exective_root from micro_exective_root where exe_id = '" + strRootID + "' and branch_code = '" + strCityCode + "' ;");
                            if (dsGetRoot.Tables[0].Rows.Count > 0)
                            {
                                strRID = dsGetRoot.Tables[0].Rows[0][0].ToString();
                            }
                            strAddress = dsData.Tables[0].Rows[0]["p_address"].ToString();
                            strMobNo = dsData.Tables[0].Rows[0]["mobile_no"].ToString();
                            strNIC = dsData.Tables[0].Rows[0]["nic"].ToString();
                            strSoNumber = dsData.Tables[0].Rows[0]["society_id"].ToString();
                            DataSet dsGetCenter = cls_Connection.getDataSet("select center_name from center_details where idcenter_details = '" + strSoNumber + "' and city_code = '" + strCityCode + "' ;");
                            if (dsGetCenter.Tables[0].Rows.Count > 0)
                            {
                                strSoNumber = strSoNumber + " " + dsGetCenter.Tables[0].Rows[0][0].ToString();
                            }
                        }
                        string str = @"{api_key:'a8ea3ba312d2aa892d525230eec6655ddf865ae7abca08505bc9684bc802c3e3', customers:'[{""name"":""" + strIniName + @""",""customer_code"":""" + strCC1 + @""",""collector_code"":""" + strRID + @""",""address"":""" + strAddress + @""",""mobile"":""" + strMobNo + @""",""nic"":""" + strNIC + @""",""group_name"":""" + strNewGID + @""",""center_name"":""" + strSoNumber + @"""}]'}";

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "updateCustGroup(" + str + ")", true);
                    }
                    catch (Exception)
                    {
                    }


                    DataSet dsCA_code = cls_Connection.getDataSet("select contract_code from micro_basic_detail where ca_code = '" + strGur1 + "';");
                    if (dsCA_code.Tables[0].Rows.Count > 0)
                    {
                        strCC = dsCA_code.Tables[0].Rows[0]["contract_code"].ToString();
                    }
                    try
                    {
                        DataSet dsData = cls_Connection.getDataSet("select contract_code,initial_name,society_id,city_code,p_address,mobile_no,nic,root_id from micro_basic_detail where contract_code = '" + strCC + "';");
                        if (dsData.Tables[0].Rows.Count > 0)
                        {
                            strCC1 = dsData.Tables[0].Rows[0]["contract_code"].ToString();
                            strIniName = dsData.Tables[0].Rows[0]["initial_name"].ToString();
                            strRootID = dsData.Tables[0].Rows[0]["root_id"].ToString();
                            strCityCode = dsData.Tables[0].Rows[0]["city_code"].ToString();
                            DataSet dsGetRoot = cls_Connection.getDataSet("select idrbf_exective_root from micro_exective_root where exe_id = '" + strRootID + "' and branch_code = '" + strCityCode + "' ;");
                            if (dsGetRoot.Tables[0].Rows.Count > 0)
                            {
                                strRID = dsGetRoot.Tables[0].Rows[0][0].ToString();
                            }
                            strAddress = dsData.Tables[0].Rows[0]["p_address"].ToString();
                            strMobNo = dsData.Tables[0].Rows[0]["mobile_no"].ToString();
                            strNIC = dsData.Tables[0].Rows[0]["nic"].ToString();
                            strSoNumber = dsData.Tables[0].Rows[0]["society_id"].ToString();
                            DataSet dsGetCenter = cls_Connection.getDataSet("select center_name from center_details where idcenter_details = '" + strSoNumber + "' and city_code = '" + strCityCode + "' ;");
                            if (dsGetCenter.Tables[0].Rows.Count > 0)
                            {
                                strSoNumber = strSoNumber + " " + dsGetCenter.Tables[0].Rows[0][0].ToString();
                            }
                        }
                        string str = @"{api_key:'a8ea3ba312d2aa892d525230eec6655ddf865ae7abca08505bc9684bc802c3e3', customers:'[{""name"":""" + strIniName + @""",""customer_code"":""" + strCC1 + @""",""collector_code"":""" + strRID + @""",""address"":""" + strAddress + @""",""mobile"":""" + strMobNo + @""",""nic"":""" + strNIC + @""",""group_name"":""" + strNewGID + @""",""center_name"":""" + strSoNumber + @"""}]'}";

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "updateCustGroup(" + str + ")", true);
                    }
                    catch (Exception)
                    {
                    }

                    DataSet dsCA_code1 = cls_Connection.getDataSet("select contract_code from micro_basic_detail where ca_code = '" + strGur2 + "';");
                    if (dsCA_code1.Tables[0].Rows.Count > 0)
                    {
                        strCC = dsCA_code1.Tables[0].Rows[0]["contract_code"].ToString();
                    }
                    try
                    {
                        DataSet dsData = cls_Connection.getDataSet("select contract_code,initial_name,society_id,city_code,p_address,mobile_no,nic,root_id from micro_basic_detail where contract_code = '" + strCC + "';");
                        if (dsData.Tables[0].Rows.Count > 0)
                        {
                            strCC1 = dsData.Tables[0].Rows[0]["contract_code"].ToString();
                            strIniName = dsData.Tables[0].Rows[0]["initial_name"].ToString();
                            strRootID = dsData.Tables[0].Rows[0]["root_id"].ToString();
                            strCityCode = dsData.Tables[0].Rows[0]["city_code"].ToString();
                            DataSet dsGetRoot = cls_Connection.getDataSet("select idrbf_exective_root from micro_exective_root where exe_id = '" + strRootID + "' and branch_code = '" + strCityCode + "' ;");
                            if (dsGetRoot.Tables[0].Rows.Count > 0)
                            {
                                strRID = dsGetRoot.Tables[0].Rows[0][0].ToString();
                            }
                            strAddress = dsData.Tables[0].Rows[0]["p_address"].ToString();
                            strMobNo = dsData.Tables[0].Rows[0]["mobile_no"].ToString();
                            strNIC = dsData.Tables[0].Rows[0]["nic"].ToString();
                            strSoNumber = dsData.Tables[0].Rows[0]["society_id"].ToString();
                            DataSet dsGetCenter = cls_Connection.getDataSet("select center_name from center_details where idcenter_details = '" + strSoNumber + "' and city_code = '" + strCityCode + "' ;");
                            if (dsGetCenter.Tables[0].Rows.Count > 0)
                            {
                                strSoNumber = strSoNumber + " " + dsGetCenter.Tables[0].Rows[0][0].ToString();
                            }
                        }
                        string str = @"{api_key:'a8ea3ba312d2aa892d525230eec6655ddf865ae7abca08505bc9684bc802c3e3', customers:'[{""name"":""" + strIniName + @""",""customer_code"":""" + strCC1 + @""",""collector_code"":""" + strRID + @""",""address"":""" + strAddress + @""",""mobile"":""" + strMobNo + @""",""nic"":""" + strNIC + @""",""group_name"":""" + strNewGID + @""",""center_name"":""" + strSoNumber + @"""}]'}";

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "updateCustGroup(" + str + ")", true);
                    }
                    catch (Exception)
                    {
                    }
                }
                catch (Exception)
                {
                }
                #endregion
                /////////////////////////////////////////////////////////////////////////////////////////////

                lblMsg.Text = "Updated Successfully";
            }
        }
    }
}
