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
    public partial class Basic_Details : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();
        DataSet dtCCode;
        string strTeamNo, strClientID, strPromiserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    DataSet dsBranch;
                    MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                    dsBranch = objDBTask.selectData(cmdBranch);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                        cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                    }

                    DataSet dsProvince;
                    MySqlCommand cmdProvince = new MySqlCommand("SELECT * FROM Province ORDER BY 2");
                    dsProvince = objDBTask.selectData(cmdProvince);
                    for (int i = 0; i < dsProvince.Tables[0].Rows.Count; i++)
                    {
                        cmbProvince.Items.Add(dsProvince.Tables[0].Rows[i][2].ToString());
                        cmbProvince.Items[i].Value = dsProvince.Tables[0].Rows[i][1].ToString();
                    }

                    if (!this.IsPostBack)
                    {
                        string strBranch = Session["Branch"].ToString();

                        DataSet dsGetRootID = objDBTask.selectData("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");

                        cmbRoot.Items.Add("");

                        for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                        {
                            cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                            cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();

                        }
                    }
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoNumber.Text = "";
            txtCACode.Text = "";
            txtCACode1.Text = "";
            txtGroupID.Text = "";
            txtPromiserID1.Text = "";
            txtPromiserID.Text = "";
            txtPromiser02.Text = "";
            txtPromiser02_02.Text = "";
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex != 0)
            {
                if (cmbVillages.Items.Count > 0)
                {
                    cmbVillages.Items.Clear();
                }

                if (cmbSocietyName.Items.Count > 0)
                {
                    cmbSocietyName.Items.Clear();
                }

                DataSet dsVillage;
                MySqlCommand cmdVillage = new MySqlCommand("select * from villages_name where city_code = '" + cmbCityCode.SelectedItem.Value + "'");
                dsVillage = objDBTask.selectData(cmdVillage);
                if (dsVillage.Tables[0].Rows.Count > 0)
                {
                    cmbVillages.Items.Add("");
                    btnSubmit.Enabled = true;

                    for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                    {
                        cmbVillages.Items.Add(dsVillage.Tables[0].Rows[i][2].ToString());
                        //cmdVillage.Items[i].Value = dsVillage.Tables[0].Rows[i][1].ToString();
                    }
                }
                else
                {
                    lblMsg.Text = "No record found...! Please chose other city code.";
                    btnSubmit.Enabled = false;
                }
            }
            else
            {
                lblMsg.Text = "Please chose city code.";
                btnSubmit.Enabled = false;
            }
        }

        protected void cmbSocietyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoNumber.Text = "";
            txtCACode1.Text = "";
            txtCACode.Text = "";
            txtPromiserID.Text = "";
            txtPromiserID1.Text = "";
            txtGroupID.Text = "";
            lblMsg.Text = "";
            if (cmbSocietyName.SelectedIndex != 0 && cmbCityCode.SelectedIndex != 0 && cmbVillages.SelectedIndex != 0)
            {
                DataSet dsGetSocietyID = objDBTask.selectData("select idcenter_details from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "' and center_name = '" + cmbSocietyName.SelectedItem.Value + "' and villages = '" + cmbVillages.SelectedItem.Value + "';");
                if (dsGetSocietyID.Tables[0].Rows.Count > 0)
                {
                    txtSoNumber.Text = dsGetSocietyID.Tables[0].Rows[0]["idcenter_details"].ToString();
                    //Edit 2014.09.18 CACode
                    CACodeNew();
                    btnSubmit.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "Invalid City Code or Society Name.";
                    btnSubmit.Enabled = false;
                }
                
            }
            else
            {
                lblMsg.Text = "Please select city code or Society Name.";
                btnSubmit.Enabled = false;
            }
        }

        protected void CACodeNew()
        {
            lblMsg.Text = "";
            if (txtSoNumber.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Society ID.";
            }
            else if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select city code.";
            }
            else
            {
                string strSOID = txtSoNumber.Text.Trim();
                string strCityCode = cmbCityCode.SelectedItem.Value;

                DataSet dsGetMaxCliID = objDBTask.selectData("select max(CAST(client_id as SIGNED)) from micro_basic_detail where city_code = '" + strCityCode + "' and society_id = '" + strSOID + "';");
                if (dsGetMaxCliID.Tables[0].Rows[0][0].ToString() != "")
                {
                    string strMaxID = dsGetMaxCliID.Tables[0].Rows[0][0].ToString();
                    int intMaxID = Convert.ToInt32(strMaxID);
                    int intNewID = intMaxID + 1;
                    int intGroupID = 0;
                    //int intProMiserCliID = 0;
                    //int intGroupID = intNewID / 2 + 1;
                    int intModules = intNewID % 3;
                    decimal decMaxID = Convert.ToDecimal(intNewID);
                    decimal decGID = decMaxID / 3;
                    string strGID = Convert.ToString(decGID);
                    int intGID = Convert.ToInt32(decGID);
                    //Chk Integer
                    //Int32 Check_Integer;
                    //if (Int32.TryParse(strGID, out Check_Integer))
                    //{ }
                    //else
                    //{
                    //    intGID = intGID + 1;
                    //}
                    //int intGroupID = intNewID / 2 + 1;

                    string strNewID = Convert.ToString(intNewID);

                    txtCACode.Text = strNewID;
                    txtCACode1.Text = strCityCode + "/" + strSOID + "/";

                    if (intModules == 1)
                    {
                        txtPromiserID1.Text = strCityCode + "/" + strSOID + "/";
                        txtPromiserID.Text = Convert.ToString(intMaxID + 2);
                        txtPromiser02.Text = strCityCode + "/" + strSOID + "/";
                        txtPromiser02_02.Text = Convert.ToString(intMaxID + 3);
                        
                        Int32 Check_Integer;
                        if (Int32.TryParse(strGID, out Check_Integer))
                        { }
                        else
                        {
                            intGID = intGID + 1;
                        }
                        txtGroupID.Text = Convert.ToString(intGID);
                    }
                    else if (intModules == 2)
                    {
                        txtPromiserID1.Text = strCityCode + "/" + strSOID + "/";
                        txtPromiserID.Text = Convert.ToString(intMaxID);
                        txtPromiser02.Text = strCityCode + "/" + strSOID + "/";
                        txtPromiser02_02.Text = Convert.ToString(intMaxID + 2);
                        txtGroupID.Text = Convert.ToString(intGID);
                    }
                    else
                    {
                        txtPromiserID1.Text = strCityCode + "/" + strSOID + "/";
                        txtPromiserID.Text = Convert.ToString(intMaxID - 1);
                        txtPromiser02.Text = strCityCode + "/" + strSOID + "/";
                        txtPromiser02_02.Text = Convert.ToString(intMaxID);
                        txtGroupID.Text = Convert.ToString(intGID);
                    }
                    //string strNewID = Convert.ToString(intNewID);

                    //txtCACode.Text = strNewID;
                    //txtCACode1.Text = strCityCode + "/" + strSOID + "/";

                    //if (intNewID % 2 == 0)
                    //{
                    //    intGroupID = intNewID / 2;
                    //    intProMiserCliID = intNewID - 1;
                    //}
                    //else
                    //{
                    //    intGroupID = intNewID / 2 + 1;
                    //    intProMiserCliID = intNewID + 1;
                    //}

                    //string strPromiserCliID = Convert.ToString(intProMiserCliID);

                    //txtGroupID.Text = Convert.ToString(intGroupID);
                    //txtPromiserID1.Text = strCityCode + "/" + strSOID + "/";
                    //txtPromiserID.Text = strPromiserCliID;
                }
                else
                {
                    txtCACode1.Text = strCityCode + "/" + strSOID + "/";
                    txtCACode.Text = "1";
                    txtGroupID.Text = "1";
                    txtPromiserID1.Text = strCityCode + "/" + strSOID + "/";
                    txtPromiserID.Text = "2";
                    txtPromiser02.Text = strCityCode + "/" + strSOID + "/";
                    txtPromiser02_02.Text = "3";
                }
            }
        }

        protected void ccsetup()
        {
            if (cmbCityCode.SelectedIndex != 0)
            {
                string strcitycode = cmbCityCode.SelectedValue.ToString();
                string strconCode;

                dtCCode = objDBTask.selectData("select max(idmicro_basic_detail) from micro_basic_detail");
                if (dtCCode.Tables[0].Rows[0][0].ToString() != "")
                {
                    string strVal = dtCCode.Tables[0].Rows[0][0].ToString();
                    int intVal = (Convert.ToInt32(strVal) + 1);
                    strVal = intVal.ToString();
                    if (((intVal).ToString()).Length < 2)
                        strVal = "00000" + strVal;
                    else if (((intVal).ToString()).Length < 3)
                        strVal = "0000" + strVal;
                    else if (((intVal).ToString()).Length < 4)
                        strVal = "000" + strVal;
                    else if (((intVal).ToString()).Length < 5)
                        strVal = "00" + strVal;
                    else if (((intVal).ToString()).Length < 6)
                        strVal = "0" + strVal;
                    else
                    { }
                    //txtID.Text = strVal;
                    strconCode = strcitycode + "/CS/" + strVal;
                    hidCC.Value = strconCode;
                    //btnSubmit.Enabled = true;
                    //cmbCityCode.Enabled = false;
                }
                else
                {
                    //txtID.Text = "0001";
                    strconCode = strcitycode + "/CS/" + "000001";
                    hidCC.Value = strconCode;
                    //btnSubmit.Enabled = true;
                    //cmbCityCode.Enabled = false;
                }
            }
            else
            {
                lblMsg.Text = "Please choose City Code";

            }
        }

        protected void CACode()
        {
            string strCityCode = cmbCityCode.SelectedItem.Value;
            string strSoNum = txtSoNumber.Text.Trim();
            DataSet dsGetLastValue = objDBTask.selectData("select team_id,client_id from micro_basic_detail where city_code = '" + strCityCode + "' and society_id = '" + strSoNum + "' order by idmicro_basic_detail desc limit 1");
            if (dsGetLastValue.Tables[0].Rows.Count > 0)
            {
                string strLastTID = dsGetLastValue.Tables[0].Rows[0]["team_id"].ToString();
                string strLastCID = dsGetLastValue.Tables[0].Rows[0]["client_id"].ToString();
                int intLastTID = Convert.ToInt32(strLastTID);
                int intLastCID = Convert.ToInt32(strLastCID);

                if (intLastCID == 1)
                {
                    strTeamNo = strLastTID;
                    strClientID = "2";
                    string strCACode = strCityCode + "/" + strSoNum + "/" + strLastTID + "/2";
                    hidCACode.Value = strCACode;
                    strPromiserID = strCityCode + "/" + strSoNum + "/" + strLastTID + "/1";
                }
                else if (intLastCID == 2)
                {
                    strTeamNo = Convert.ToString(intLastTID + 1);
                    strClientID = "1";
                    string strCACode = strCityCode + "/" + strSoNum + "/" + strTeamNo + "/1";
                    hidCACode.Value = strCACode;
                    strPromiserID = strCityCode + "/" + strSoNum + "/" + strTeamNo + "/2";
                }
            }
            else
            {
                string strCACode = strCityCode + "/" + strSoNum + "/1/1";
                hidCACode.Value = strCACode;
                strPromiserID = strCityCode + "/" + strSoNum + "/1/2";
                strTeamNo = "1";
                strClientID = "1";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtNIC.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter NIC No.";
            }
            else if (!fpPhoto.HasFile)
            {
                lblMsg.Text = "Please upload Client Photo";
            }
            else if (!fpBBPhoto.HasFile)
            {
                lblMsg.Text = "Please upload Bank Book Photo";
            }
            else if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select city code.";
            }
            else if (cmbRoot.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select root id.";
            }
            else if (cmbVillages.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select village name.";
            }
            else if (cmbSocietyName.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select society Name.";
            }
            else if (txtSoNumber.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Society Number.";
            }
            else if (txtCACode.Text.Trim() == "" || txtCACode1.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Capital Applicant Code.";
            }
            else if (txtGroupID.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Group ID";
            }
            else if (txtPromiserID.Text.Trim() == "" || txtPromiserID1.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Promiser ID 1";
            }
            else if (txtPromiser02.Text.Trim() == "" || txtPromiser02_02.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Promiser ID 2";
            }
            else if (txtGSWard.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter GS Ward.";
            }
            else if (txtFullName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Full Name.";
            }
            else if (txtInwName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Initial Name.";
            }
            else if (txtTNo.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Phone Number.";
            }
            else if (txtMobileNo.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Mobile Number.";
            }
            else if (txtAddress.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Address.";
            }
            else
            {
                string strloginID = Session["NIC"].ToString();

                //Create Contract Code
                ccsetup();

                //Create Capital Applicant Code
                //CACodeNew();

                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_basic_detail(contract_code,ca_code,nic,city_code,society_id,province,gs_ward,full_name,initial_name,other_name,marital_status,education,land_no,mobile_no,p_address,team_id,client_id,inspection_date,create_user_id,user_ip,date_time,promisers_id,village,root_id,cli_photo,bb_photo,promiser_id_2)VALUES(@contract_code,@ca_code,@nic,@city_code,@society_id,@province,@gs_ward,@full_name,@initial_name,@other_name,@marital_status,@education,@land_no,@mobile_no,@p_address,@team_id,@client_id,@inspection_date,@create_user_id,@user_ip,@date_time,@promisers_id,@village,@root_id,@cli_photo,@bb_photo,@promiser_id_2);");

                #region Get Values
                string strIp = Request.UserHostAddress;
                string strCC = hidCC.Value;

                int intVal;
                DataSet dtCCodeID = objDBTask.selectData("select max(idmicro_basic_detail) from micro_basic_detail");
                if (dtCCodeID.Tables[0].Rows[0][0].ToString() != "")
                {
                    string strVal = dtCCodeID.Tables[0].Rows[0][0].ToString();

                    intVal = (Convert.ToInt32(strVal) + 1);
                }
                else
                {
                    intVal = 1;
                }


                string strNewImaID = Convert.ToString(intVal);

                string strServerImagePath;
                string strPostedFileName;
                string strImageType;
                //string strLastID = hifRefID.Value;
                //string strNIC = Session["NICNo"].ToString();
                string strNewFileName;

                strServerImagePath = Server.MapPath(".") + "\\cs_client_ph";

                if (fpPhoto.HasFile)
                {
                    strPostedFileName = fpPhoto.PostedFile.FileName;
                    strImageType = strPostedFileName.Substring(strPostedFileName.LastIndexOf("."));
                    strNewFileName = strNewImaID + "-1" + strImageType;
                    fpPhoto.PostedFile.SaveAs(strServerImagePath + "\\" + strNewFileName);
                    hf1.Value = "cs_client_ph" + "\\" + strNewFileName;
                }
                else
                {
                    hf1.Value = "";
                }

                if (fpBBPhoto.HasFile)
                {
                    strPostedFileName = fpBBPhoto.PostedFile.FileName;
                    strImageType = strPostedFileName.Substring(strPostedFileName.LastIndexOf("."));
                    strNewFileName = strNewImaID + "-2" + strImageType;
                    fpBBPhoto.PostedFile.SaveAs(strServerImagePath + "\\" + strNewFileName);
                    hf2.Value = "cs_client_ph" + "\\" + strNewFileName;
                }
                else
                {
                    hf2.Value = "";
                }

                string strNIC, strCityCode, strVillage, strSoName, strSoNumber, strProvince, strGSWard, strFullName, strGName, strIniName, strOName, strMaStatus;
                string strEducation, strTNumber, strMobNo, strAddress, strCACode, strInspDate, strDateTime, strRootID, strPromiser2;


                strCACode = txtCACode1.Text.Trim() + txtCACode.Text.Trim();
                strTeamNo = txtGroupID.Text.Trim();
                strPromiserID = txtPromiserID1.Text.Trim() + txtPromiserID.Text.Trim();
                strPromiser2 = txtPromiser02.Text.Trim() + txtPromiser02_02.Text.Trim();
                strNIC = txtNIC.Text.Trim();
                strCityCode = cmbCityCode.SelectedItem.Value;
                strClientID = txtCACode.Text.Trim();
                strVillage = cmbVillages.SelectedItem.Value;
                strSoName = cmbSocietyName.SelectedItem.Value;
                strSoNumber = txtSoNumber.Text.Trim();
                strProvince = cmbProvince.SelectedItem.Value;
                strGSWard = txtGSWard.Text.Trim();
                strFullName = txtFullName.Text.Trim();
                strGName = txtGivenName.Text.Trim();
                strIniName = txtInwName.Text.Trim();
                strOName = txtOtherName.Text.Trim();
                strMaStatus = "";
                strRootID = cmbRoot.SelectedItem.Value;
                if (rdoMarried.Checked == true)
                {
                    strMaStatus = "M";
                }
                else if (rdoSingle.Checked == true)
                {
                    strMaStatus = "S";
                }
                strEducation = cmbEducation.SelectedItem.Value;
                strTNumber = txtTNo.Text.Trim();
                strMobNo = txtMobileNo.Text.Trim();
                strAddress = txtAddress.Text.Trim();
                strInspDate = txtInsDate.Text.Trim();
                strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                #endregion

                #region DeclarareParamerts
                cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@ca_code", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@nic", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@city_code", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@society_id", MySqlDbType.VarChar, 6);
                cmdInsert.Parameters.Add("@province", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@gs_ward", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@full_name", MySqlDbType.VarChar, 100);
                cmdInsert.Parameters.Add("@initial_name", MySqlDbType.VarChar, 100);
                cmdInsert.Parameters.Add("@other_name", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@marital_status", MySqlDbType.VarChar, 1);
                cmdInsert.Parameters.Add("@education", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@land_no", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@mobile_no", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@p_address", MySqlDbType.VarChar, 255);
                cmdInsert.Parameters.Add("@team_id", MySqlDbType.VarChar, 2);
                cmdInsert.Parameters.Add("@client_id", MySqlDbType.VarChar, 2);
                cmdInsert.Parameters.Add("@inspection_date", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@create_user_id", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@promisers_id", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@village", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@root_id", MySqlDbType.VarChar, 1);
                cmdInsert.Parameters.Add("@cli_photo", MySqlDbType.VarChar, 200);
                cmdInsert.Parameters.Add("@bb_photo", MySqlDbType.VarChar, 200);
                cmdInsert.Parameters.Add("@promiser_id_2", MySqlDbType.VarChar, 12);
                #endregion

                #region AssignParameters
                cmdInsert.Parameters["@contract_code"].Value = strCC;
                cmdInsert.Parameters["@ca_code"].Value = strCACode;
                cmdInsert.Parameters["@nic"].Value = strNIC;
                cmdInsert.Parameters["@city_code"].Value = strCityCode;
                cmdInsert.Parameters["@society_id"].Value = strSoNumber;
                cmdInsert.Parameters["@province"].Value = strProvince;
                cmdInsert.Parameters["@gs_ward"].Value = strGSWard;
                cmdInsert.Parameters["@full_name"].Value = strFullName;
                cmdInsert.Parameters["@initial_name"].Value = strIniName;
                cmdInsert.Parameters["@other_name"].Value = strOName;
                cmdInsert.Parameters["@marital_status"].Value = strMaStatus;
                cmdInsert.Parameters["@education"].Value = strEducation;
                cmdInsert.Parameters["@land_no"].Value = strTNumber;
                cmdInsert.Parameters["@mobile_no"].Value = strMobNo;
                cmdInsert.Parameters["@p_address"].Value = strAddress;
                cmdInsert.Parameters["@team_id"].Value = strTeamNo;
                cmdInsert.Parameters["@client_id"].Value = strClientID;
                cmdInsert.Parameters["@inspection_date"].Value = strInspDate;
                cmdInsert.Parameters["@create_user_id"].Value = strloginID;
                cmdInsert.Parameters["@user_ip"].Value = strIp;
                cmdInsert.Parameters["@date_time"].Value = strDateTime;
                cmdInsert.Parameters["@promisers_id"].Value = strPromiserID;
                cmdInsert.Parameters["@village"].Value = strVillage;
                cmdInsert.Parameters["@root_id"].Value = strRootID;
                cmdInsert.Parameters["@cli_photo"].Value = hf1.Value;
                cmdInsert.Parameters["@bb_photo"].Value = hf2.Value;
                cmdInsert.Parameters["@promiser_id_2"].Value = strPromiser2;
                #endregion

                try
                {
                    int i = objDBTask.insertEditData(cmdInsert);
                    if (i == 1)
                    {
                        Response.Redirect("Family_Details.aspx?CC=" + strCC + "&CA=" + strCACode + "");
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured";
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void cmbVillages_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please chose city code.";
                btnSubmit.Enabled = false;
            }
            else if (cmbVillages.SelectedIndex < 0)
            {
                lblMsg.Text = "Please chose village name.";
                btnSubmit.Enabled = false;
            }
            else
            {
                if (cmbSocietyName.Items.Count > 0)
                {
                    cmbSocietyName.Items.Clear();
                }

                txtSoNumber.Text = "";
                txtCACode.Text = "";
                txtCACode1.Text = "";
                txtPromiserID1.Text = "";
                txtPromiserID.Text = "";
                txtGroupID.Text = "";
                
                DataSet dsSocietyName;
                MySqlCommand cmdSocietyName = new MySqlCommand("select center_name from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "' and villages = '" + cmbVillages.SelectedItem.Value + "';");
                dsSocietyName = objDBTask.selectData(cmdSocietyName);
                if (dsSocietyName.Tables[0].Rows.Count > 0)
                {
                    cmbSocietyName.Items.Add("");
                    for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
                    {
                        cmbSocietyName.Items.Add(dsSocietyName.Tables[0].Rows[i]["center_name"].ToString());
                        //cmbSocietyName.Items[i].Value = dsSocietyName.Tables[0].Rows[i]["idcenter_details"].ToString();
                    }
                    btnSubmit.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "No record found...! Please chose other village name.";
                    btnSubmit.Enabled = false;
                }
            }
        }

        protected void txtNIC_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtNIC.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter NIC Number.";
                btnSubmit.Enabled = false;
            }
            else
            {
                DataSet dsGetExsiNIC = objDBTask.selectData("select * from micro_basic_detail where nic = '" + txtNIC.Text.Trim() + "';");
                if (dsGetExsiNIC.Tables[0].Rows.Count > 0)
                {
                    lblMsg.Text = "This nic number is already used...!";
                    btnSubmit.Enabled = false;
                }
                else
                {
                    lblMsg.Text = "";
                    btnSubmit.Enabled = true;
                }
            }
        }

        protected void txtCACode_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCACode.Text.Trim() == "" || txtCACode1.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Capital Applicant Caod.";
                btnSubmit.Enabled = false;
            }
            else
            {
                string strCApplicantCode = txtCACode1.Text.Trim() + txtCACode.Text.Trim();
                DataSet dsGetExsiID = objDBTask.selectData("select l.loan_sta from micro_basic_detail b,micro_loan_details l where ca_code = '" + strCApplicantCode + "' and b.contract_code = l.contra_code;");
                if (dsGetExsiID.Tables[0].Rows.Count > 0)
                {
                    string strStatus = dsGetExsiID.Tables[0].Rows[0]["loan_sta"].ToString();
                    if (strStatus == "P" || strStatus == "D")
                    {
                        lblMsg.Text = "Alredy Used this CA Code & Active ID.";
                        btnSubmit.Enabled = false;
                    }
                    else
                    {
                        btnSubmit.Enabled = true;
                    }
                }
            }
        }

        protected void txtGroupID_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if(txtGroupID.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Group ID.";
                btnSubmit.Enabled = false;
            }
            else if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select city code.";
                btnSubmit.Enabled = false;
            }
            else if (cmbVillages.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select village name.";
                btnSubmit.Enabled = false;
            }
            else if (cmbSocietyName.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select society Name.";
                btnSubmit.Enabled = false;
            }
            else if (txtSoNumber.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Society Number.";
                btnSubmit.Enabled = false;
            }
            else if (txtCACode.Text.Trim() == "" || txtCACode1.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Capital Applicant Caod.";
                btnSubmit.Enabled = false;
            }
            else
            {
                string strGID = txtGroupID.Text.Trim();
                string strSociID = txtSoNumber.Text.Trim();
                DataSet dsGetExsiGID = objDBTask.selectData("select b.contract_code from micro_basic_detail b,micro_loan_details l where b.team_id = '" + strGID + "' and b.society_id = '" + strSociID + "' and b.contract_code = l.contra_code and l.loan_sta = 'P' or b.team_id = '" + strGID + "' and b.society_id = '" + strSociID + "' and b.contract_code = l.contra_code and l.loan_sta = 'D'");
                if (dsGetExsiGID.Tables[0].Rows.Count >= 2)
                {
                    lblMsg.Text = "Invalid Group ID. Alredy Used this group.";
                    btnSubmit.Enabled = false;
                }
                else
                {
                    btnSubmit.Enabled = true;
                }
            }
        }

        protected void txtPromiserID_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if(txtPromiserID.Text.Trim() == "" || txtPromiserID1.Text.Trim() == "")
            {
                lblMsg.Text="Please enter Promiser ID.";
                btnSubmit.Enabled = false;
            }
            else if (txtPromiserID.Text.Trim() == txtCACode.Text.Trim())
            {
                lblMsg.Text = "Equal to client CACode and Promiser ID.";
                btnSubmit.Enabled = false;
            }
            else
            {
                string strProID = txtPromiserID1.Text.Trim() + txtPromiserID.Text.Trim();
                DataSet dsGetProDeta = objDBTask.selectData("select b.contract_code from micro_basic_detail b,micro_loan_details l where b.promisers_id = '" + strProID + "' and b.contract_code = l.contra_code and l.loan_sta = 'P' or b.promisers_id = '" + strProID + "' and b.contract_code = l.contra_code and l.loan_sta = 'D';");
                if (dsGetProDeta.Tables[0].Rows.Count > 0)
                {
                    lblMsg.Text = "Alredy Used Promiser ID.";
                    btnSubmit.Enabled = false;
                }
                else
                {
                    btnSubmit.Enabled = true;
                }
            }
        }
    }
}
