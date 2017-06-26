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
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;

namespace MuslimAID.MURABHA
{
    public partial class client_basic_details : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();
        DataSet dtCCode;
        string strTeamNo, strClientID, strPromiserID, strPromiserID2, strCACodeNew = "", strSoNumber="";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LoggedIn"].ToString() == "True")
                    {
                        string strType = Session["UserType"].ToString();
                        if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG" || 
                            strType == "FAO" || strType == "RMG" || strType == "RFA" || strType == "BMG" ||
                            strType == "BFA")
                        {
                            DataSet dsBranch = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");
                            cmbBranch.Items.Add("Select Branch");
                            for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                            {
                                cmbBranch.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                                cmbBranch.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                            }

                            DataSet dsNture = cls_Connection.getDataSet("SELECT * FROM micro_nature_of_business;");
                            cmbBNature.Items.Add("");
                            for (int i = 0; i < dsNture.Tables[0].Rows.Count; i++)
                            {
                                cmbBNature.Items.Add(dsNture.Tables[0].Rows[i]["natureOfBusiness"].ToString());
                                cmbBNature.Items[i + 1].Value = dsNture.Tables[0].Rows[i]["id"].ToString();
                            }

                            DataSet Occupation = cls_Connection.getDataSet("SELECT * FROM micro_occupation ORDER BY id");
                            cmbOccupation.Items.Add("Select Occupation/ Income Source");
                            cmbOccupa.Items.Add("Select Occupation/ Income Source");
                            for (int i = 0; i < Occupation.Tables[0].Rows.Count; i++)
                            {
                                cmbOccupation.Items.Add(Occupation.Tables[0].Rows[i]["occupation"].ToString());
                                cmbOccupation.Items[i + 1].Value = Occupation.Tables[0].Rows[i]["id"].ToString();
                                cmbOccupa.Items.Add(Occupation.Tables[0].Rows[i]["occupation"].ToString());
                                cmbOccupa.Items[i + 1].Value = Occupation.Tables[0].Rows[i]["id"].ToString();
                            }

                            cmbArea.Enabled = false;
                            cmbRoot.Enabled = false;
                            cmbVillage.Enabled = false;
                            cmbCenter.Enabled = false;

                            cmbTmePeriod.Items.Add("Select Period");
                            for (int i = 0; i < 24; i++)
                            {
                                cmbTmePeriod.Items.Add(i + 1 + " Month");
                                cmbTmePeriod.Items[i + 1].Value = (i + 1).ToString();
                            }
                            #region
                            txtNameOrg1.Enabled = false;
                            txtNameOrg2.Enabled = false;
                            txtNameOrg3.Enabled = false;
                            txtPurpos1.Enabled = false;
                            txtPurpos2.Enabled = false;
                            txtPurpos3.Enabled = false;
                            txtFAmount1.Enabled = false;
                            txtFAmount2.Enabled = false;
                            txtFAmount3.Enabled = false;
                            txtOutstandBal1.Enabled = false;
                            txtOutstandBal2.Enabled = false;
                            txtOutstandBal3.Enabled = false;
                            txtMonthInstal1.Enabled = false;
                            txtMonthInstal2.Enabled = false;
                            txtMonthInstal3.Enabled = false;
                            txtRemainInstal1.Enabled = false;
                            txtRemainInstal2.Enabled = false;
                            txtRemainInstal3.Enabled = false;
                            #endregion
                        }
                        else if (strType == "MFO")
                        {
                            string strUser = Session["NIC"].ToString();
                            DataSet dsExe = cls_Connection.getDataSet("SELECT * FROM micro_exective_root, branch, center_details WHERE micro_exective_root.exe_nic = '" + strUser + "' AND branch.b_code = center_details.city_code AND center_details.exective = micro_exective_root.exe_id;");

                            DataSet dsBrnh = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");
                            cmbBranch.Items.Add("Select Branch");
                            for (int i = 0; i < dsBrnh.Tables[0].Rows.Count; i++)
                            {
                                cmbBranch.Items.Add(dsBrnh.Tables[0].Rows[i][2].ToString());
                                cmbBranch.Items[i + 1].Value = dsBrnh.Tables[0].Rows[i][1].ToString();
                            }
                            cmbBranch.SelectedValue = dsExe.Tables[0].Rows[0]["branch_code"].ToString();
                            cmbBranch.Enabled = false;

                            DataSet dsArea = cls_Connection.getDataSet("SELECT * FROM area WHERE branch_code = '" + dsExe.Tables[0].Rows[0]["branch_code"].ToString() + "' ORDER BY area");
                            cmbArea.Items.Add("Select Area");
                            for (int i = 0; i < dsArea.Tables[0].Rows.Count; i++)
                            {
                                cmbArea.Items.Add(dsArea.Tables[0].Rows[i][1].ToString());
                                cmbArea.Items[i + 1].Value = dsArea.Tables[0].Rows[i][2].ToString();
                            }
                            cmbArea.SelectedValue = dsExe.Tables[0].Rows[0]["area_code"].ToString();

                            DataSet dsVillage = cls_Connection.getDataSet("SELECT * FROM villages_name WHERE city_code='"+dsExe.Tables[0].Rows[0]["branch_code"].ToString()+"' AND area_code = '"+dsExe.Tables[0].Rows[0]["area_code"].ToString()+"';");

                            cmbVillage.Items.Add("Select Village");
                            for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                            {
                                cmbVillage.Items.Add(dsVillage.Tables[0].Rows[i]["villages_name"].ToString());
                                cmbVillage.Items[i + 1].Value = dsVillage.Tables[0].Rows[i]["villages_code"].ToString();
                            }
                            cmbVillage.SelectedValue = dsExe.Tables[0].Rows[0]["villages"].ToString();

                            DataSet dsCenter = cls_Connection.getDataSet("SELECT * FROM center_details WHERE city_code='" + dsExe.Tables[0].Rows[0]["branch_code"].ToString() + "' AND area_code = '" + dsExe.Tables[0].Rows[0]["area_code"].ToString() + "' AND villages='" + dsExe.Tables[0].Rows[0]["villages"].ToString() + "';");
                            cmbCenter.Items.Add("Select Center");
                            for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                            {
                                cmbCenter.Items.Add(dsCenter.Tables[0].Rows[i]["center_name"].ToString());
                                cmbCenter.Items[i + 1].Value = dsCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                            }
                            cmbCenter.SelectedValue = dsExe.Tables[0].Rows[0]["idcenter_details"].ToString();
                            txtSoNumber.Text = dsExe.Tables[0].Rows[0]["idcenter_details"].ToString();

                            DataSet dsMFO = cls_Connection.getDataSet("SELECT * FROM micro_exective_root WHERE branch_code = '" + dsExe.Tables[0].Rows[0]["branch_code"].ToString() + "'");
                            cmbRoot.Items.Add("Select MFO");
                            for (int i = 0; i < dsMFO.Tables[0].Rows.Count; i++)
                            {
                                cmbRoot.Items.Add(dsMFO.Tables[0].Rows[i]["exe_name"].ToString());
                                cmbRoot.Items[i + 1].Value = dsMFO.Tables[0].Rows[i]["exe_id"].ToString();
                            }
                            cmbRoot.SelectedValue = dsExe.Tables[0].Rows[0]["exe_id"].ToString();
                            cmbRoot.Enabled = false;
                            ccsetup();
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
                else
                {
                    DateTime now = DateTime.UtcNow.Date;
                    DateTime dt, dtSo;
                    if (txtDOB.Text.Trim() != "")
                    {
                        dt = DateTime.Parse(txtDOB.Text.Trim(), new CultureInfo("en-CA"));
                        int age = now.Year - dt.Year;
                        lblAge.Text = age.ToString();
                    }
                    if (txtSoDOB.Text.Trim() != "")
                    {
                        dtSo = DateTime.Parse(txtSoDOB.Text.Trim(), new CultureInfo("en-CA"));
                        int ageSo = now.Year - dtSo.Year;
                        lblSoAge.Text = ageSo.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "client bsic details");
            }
        }

        protected void CC_Create(int intVal)
        {
            try
            {
                string strcitycode = cmbBranch.SelectedValue.ToString();
                string strconCode;
                //Last Basic Details code
                string strVal = DateTime.Now.Year.ToString();

                for (int i = (intVal.ToString()).Length; i < 4; i++)
                {
                    strVal += "0";
                }
                strVal += intVal.ToString();

                //Area Code
                string ac = cmbArea.SelectedValue.ToString();
                //Village Code
                string vc = cmbVillage.SelectedValue.ToString();
                //Center Code
                int CC = Convert.ToInt32(cmbCenter.SelectedValue.ToString());
                string cc = "";
                for (int i = (CC.ToString()).Length; i < 2; i++)
                {
                    cc += "0";
                }
                cc += CC.ToString();

                //city code/ Area code/ Village code / Center code / product code / year and product code
                //000      / 000      / 000          / 00          / 000          /20170000
                strconCode = strcitycode + "/" + ac + "/" + vc + "/" + cc + "/MBR/" + strVal; 
                hidCC.Value = strconCode;
                DataSet dtCount = cls_Connection.getDataSet("select count(b.nic) + 1 AS Count from micro_basic_detail b inner join micro_loan_details l on b.contract_code = l.contra_code where nic = '" + txtNIC.Text.Trim() + "' and l.loan_approved = 'Y' and l.loan_sta != 'C' and chequ_no != null;");
                if (dtCount.Tables[0].Rows[0][0].ToString() != "")
                {
                    if (dtCount.Tables[0].Rows[0][0].ToString().Length == 2)
                    {
                        hidCC.Value = hidCC.Value + "/" + dtCount.Tables[0].Rows[0][0].ToString();
                    }
                    else if (dtCount.Tables[0].Rows[0][0].ToString().Length == 1)
                    {
                        hidCC.Value = hidCC.Value + "/0" + dtCount.Tables[0].Rows[0][0].ToString();
                    }
                }


                txtCC.Text = hidCC.Value.Trim();
                txtCC.ReadOnly = true;
            }
            catch (Exception e)
            {
                cls_ErrorLog.createSErrorLog(e.Message, e.Source, "CC_Create");
            }
        }

        protected void ccsetup()
        {
            try
            {
                if (txtNIC.Text.Trim() == "")
                    upperMsg.Text = "Please enter your National Identity Card Number";
                else if (cmbBranch.SelectedIndex != 0)
                {
                    string strcitycode = cmbBranch.SelectedValue.ToString();
                    string strconCode;

                    dtCCode = cls_Connection.getDataSet("select max(idmicro_basic_detail) from micro_basic_detail");

                    int intVal = (dtCCode.Tables[0].Rows[0][0].ToString() != "") ? Convert.ToInt32(dtCCode.Tables[0].Rows[0][0].ToString()) + 1 : 1;

                    CC_Create(intVal);
                }
                else
                {
                    lblMsg.Text = "Please choose City Code";
                }
            }
            catch (Exception e)
            {
                cls_ErrorLog.createSErrorLog(e.Message, e.Source, "ccsetup");
            }
        }

        private void getArea()
        {
            //txtSoNumber.Text = "";
            lblMsg.Text = "";
            if (cmbBranch.SelectedIndex != 0)
            {
                if (cmbArea.Items.Count > 0)
                {
                    cmbArea.Items.Clear();
                }

                if (cmbVillage.Items.Count > 0)
                {
                    cmbVillage.Items.Clear();
                }

                try
                {
                    DataSet dsVillage = cls_Connection.getDataSet("select * from area where branch_code = '" + cmbBranch.SelectedItem.Value + "' ORDER BY area");
                    if (dsVillage.Tables[0].Rows.Count > 0)
                    {
                        cmbArea.Items.Add("Select Area");
                        btnSubmit.Enabled = true;

                        for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                        {
                            cmbArea.Items.Add(dsVillage.Tables[0].Rows[i][1].ToString());
                            cmbArea.Items[i+1].Value = dsVillage.Tables[0].Rows[i][2].ToString();
                        }
                        cmbArea.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "No record found...! Please chose other city code.";
                        btnSubmit.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load Area according to selected branch");
                    return;
                }

                try
                {
                    string strBranch = cmbBranch.SelectedItem.Value;

                    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");
                    if (cmbRoot.Items.Count > 0)
                    {
                        cmbRoot.Items.Clear();
                    }
                    cmbRoot.Items.Add("");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
                    }
                    //cmbRoot.Enabled = true;
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details form load MFO according to selected branch");
                    return;
                }
            }
            else
            {
                lblMsg.Text = "Please chose city code.";
                btnSubmit.Enabled = false;
            }
        }

        private void getVillage()
        {
            try
            {
                lblMsg.Text = "";
                if (cmbBranch.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please chose city code.";
                    btnSubmit.Enabled = false;
                }
                else if (cmbArea.SelectedIndex < 0)
                {
                    lblMsg.Text = "Please chose village name.";
                    btnSubmit.Enabled = false;
                }
                else
                {
                    if (cmbVillage.Items.Count > 0)
                    {
                        cmbVillage.Items.Clear();
                    }

                    DataSet dsSocietyName = cls_Connection.getDataSet("SELECT villages_code,villages_name FROM villages_name WHERE city_code = '" + cmbBranch.SelectedItem.Value + "' AND area_code ='" + cmbArea.SelectedItem.Value + "';");
                    if (dsSocietyName.Tables[0].Rows.Count > 0)
                    {
                        cmbVillage.Items.Add("Select Village");
                        for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
                        {
                            cmbVillage.Items.Add(dsSocietyName.Tables[0].Rows[i]["villages_name"].ToString());
                            cmbVillage.Items[i + 1].Value = dsSocietyName.Tables[0].Rows[i]["villages_code"].ToString();
                        }
                        cmbVillage.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "No record found...! Please chose other village name.";
                        btnSubmit.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details form load Villages according to selected Area");
                return;
            }
        }

        private void getSocity() {
            try {
                txtSoNumber.Text = "";
                lblMsg.Text = "";
                if (cmbVillage.SelectedIndex != 0 && cmbBranch.SelectedIndex != 0 && cmbArea.SelectedIndex != 0)
                {
                    DataSet dsSCenter = cls_Connection.getDataSet("SELECT idcenter_details, center_name, center_day FROM center_details WHERE city_code = '" + cmbBranch.SelectedItem.Value + "' AND area_code = '" + cmbArea.SelectedItem.Value + "' AND villages = '" + cmbVillage.SelectedItem.Value + "';");
                    cmbCenter.Items.Clear();
                    if (dsSCenter.Tables[0].Rows.Count > 0)
                    {
                        cmbCenter.Items.Add("Select Center");

                        for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                        {
                            cmbCenter.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                            cmbCenter.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                        }
                        cmbCenter.Enabled = true;
                    }
                    else {
                        lblMsg.Text = "There is no available centers...";
                    }
                    
                }
            }
            catch (Exception ex) { 
            }
        }
        private void socity()
        {
            try
            {
                txtSoNumber.Text = "";
                lblMsg.Text = "";
                if (cmbVillage.SelectedIndex != 0 && cmbBranch.SelectedIndex != 0 && cmbArea.SelectedIndex != 0)
                {
                    DataSet dsGetSocietyID = cls_Connection.getDataSet("select exective from center_details where city_code = '" + cmbBranch.SelectedItem.Value + "' and area_code = '" + cmbArea.SelectedItem.Value + "' and villages = '" + cmbVillage.SelectedItem.Value + "';");
                    if (dsGetSocietyID.Tables[0].Rows.Count > 0)
                    {
                        //txtSoNumber.Text = cmbSocietyName.SelectedItem.Value.ToString();

                        DataSet dsSCenter = cls_Connection.getDataSet("SELECT idcenter_details, center_name, center_day FROM center_details WHERE city_code = '" + cmbBranch.SelectedItem.Value + "' AND area_code = '" + cmbArea.SelectedItem.Value + "' AND villages = '" + cmbVillage.SelectedItem.Value + "';");
                        cmbCenter.Items.Clear();
                        if (dsSCenter.Tables[0].Rows.Count > 0)
                        {
                            cmbCenter.Items.Add("Select Center");

                            for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                            {
                                cmbCenter.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                                cmbCenter.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                            }
                        }
                        cmbCenter.Enabled = true;
                        //Edit 2014.09.18 CACode
                        //CACodeNew();
                        cmbRoot.SelectedValue = dsGetSocietyID.Tables[0].Rows[0]["exective"].ToString();
                        hidRoot.Value = dsGetSocietyID.Tables[0].Rows[0]["exective"].ToString();
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
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details form load centers according to selected village");
                return;
            }
        }

        private void Save()
        {
            try
            {
                lblMsg.Text = "";
                if (txtNIC.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter NIC No.";
                }
                else if (txtNicIssuDay.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter the NIC issued date.";
                }
                else if (cmbBranch.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select city code.";
                }
                else if (cmbArea.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select village name.";
                }
                else if (cmbVillage.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select society Name.";
                }
                else if (txtSoNumber.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Society Number.";
                }
                else if (txtGSWard.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter GS Ward.";
                }
                else if (txtFullName.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Full Name.";
                }
                else if (txtAddress.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Address.";
                }
                else if (txtInsDate.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter inspection date.";
                }
                else if (cmbOccupation.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please enter Occupation / Income Source.";
                }
                else
                {
                    btnSubmit.Enabled = false;

                    bool bolBasic = saveBasicDetails();
                    bool bolFamily = saveFamilyDetails();
                    bool bolBusiness = saveBUsinessDetails();
                    bool bolFRequirment = saveFacilityRequirment();
                    bool bolCOFacility = checkOtherFacility();
                    bool bolOtherFamily = otherFamilyDetails();
                    if (bolBasic && bolFamily && bolBusiness && bolFRequirment && bolCOFacility && bolOtherFamily) {
                        lblMsg.Text = "Successfully Added";
                        Response.Redirect("business_details.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + strCACodeNew);
                    }
                }
            }
            catch (Exception x)
            {
                cls_ErrorLog.createSErrorLog(x.Message, x.Source, "Save method");
                lblMsg.Text = x.ToString();
            }
        }

        protected bool saveBasicDetails() {
            string strloginID = Session["NIC"].ToString();

            MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_basic_detail(contract_code,ca_code,nic,city_code,society_id,gs_ward,full_name,marital_status,land_no,p_address,client_id,inspection_date,create_user_id,user_ip,date_time,village,root_id,nic_issue_date,dob,gender,r_address,income_source,team_id,promisers_id,promiser_id_2,area_code)VALUES(@contract_code,@ca_code,@nic,@city_code,@society_id,@gs_ward,@full_name,@marital_status,@land_no,@p_address,@client_id,@inspection_date,@create_user_id,@user_ip,@date_time,@village,@root_id,@nic_issue_date,@dob,@gender,@r_address,@income_source,@team_id,@promisers_id,@promiser_id_2,@area_code)");

            #region Get Values
            string strIp = Request.UserHostAddress;
            string strCC = hidCC.Value;

            int intVal;
            DataSet dtCCodeID = cls_Connection.getDataSet("select max(idmicro_basic_detail) from micro_basic_detail");
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


            string strNIC, strGroupID, strCityCode, strArea, strVillage, strSoName, strSoNumber, strProvince, strGSWard, strFullName, strGName, strIniName, strOName, strMaStatus, strEducation, strTNumber, strMobNo, strAddress, strCACode, strInspDate, strDateTime, strRootID, strPromiser2, strSubCenterCode;
            string strDOB, strGender, strRAddress, strOccupation, strNICIssuedDate;
            strNIC = txtNIC.Text.Trim();
            strNICIssuedDate = txtNicIssuDay.Text.Trim();
            strCityCode = cmbBranch.SelectedItem.Value; //This is the branch code
            strArea = cmbArea.SelectedItem.Value;
            strVillage = cmbVillage.SelectedItem.Value;
            strSoName = cmbCenter.SelectedItem.Value;
            strSoNumber = txtSoNumber.Text.Trim();
            //strSoName = cmbVillage.SelectedItem.Value;
            //strProvince = cmbProvince.SelectedItem.Value;
            strGSWard = txtGSWard.Text.Trim();
            strFullName = txtFullName.Text.Trim();
            //strGName = txtGivenName.Text.Trim();
            //strIniName = txtInwName.Text.Trim();
            //strOName = txtOtherName.Text.Trim();
            strDOB = txtDOB.Text.Trim();
            if (rdoMale.Checked)
                strGender = "1";
            else strGender = "0";
            strMaStatus = cmbMS.SelectedItem.Value;
            strRootID = hidRoot.Value.Trim().ToString();
            //strRootID = cmbRoot.SelectedItem.Value;
            //strEducation = cmbEducation.SelectedItem.Value;
            strTNumber = txtTele.Text.Trim();
            //strMobNo = txtMobileNo.Text.Trim();
            strAddress = txtAddress.Text.Trim();
            strRAddress = txtResiAddress.Text.Trim();
            strOccupation = cmbOccupation.SelectedValue.ToString();
            strInspDate = txtInsDate.Text.Trim();
            strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            #region Promisory
            DataSet dsGetLastValue = cls_Connection.getDataSet("SELECT team_id,client_id FROM micro_basic_detail WHERE city_code = '" + strCityCode + "'  AND area_code = '" + strArea + "'  AND village = '" + strVillage + "' AND society_id = '" + strSoNumber + "' ORDER BY idmicro_basic_detail DESC LIMIT 1;");
            if (dsGetLastValue.Tables[0].Rows.Count > 0)
            {
                string strLastTID = dsGetLastValue.Tables[0].Rows[0]["team_id"].ToString();
                string strLastCID = dsGetLastValue.Tables[0].Rows[0]["client_id"].ToString();

                if (strLastTID != "" && strLastCID != "")
                {
                    int intLastTID = Convert.ToInt32(strLastTID);
                    int intLastCID = Convert.ToInt32(strLastCID);

                    if (intLastCID == 1)
                    {
                        strTeamNo = strLastTID;
                        strClientID = "2";
                        strCACodeNew = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strLastTID + "/2";
                        hidCACode.Value = strCACodeNew;
                        strPromiserID = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strLastTID + "/1";
                        strPromiserID2 = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strLastTID + "/3";
                    }
                    else if (intLastCID == 2)
                    {
                        strTeamNo = strLastTID;
                        strClientID = "3";
                        strCACodeNew = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strTeamNo + "/3";
                        hidCACode.Value = strCACodeNew;
                        strPromiserID = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strTeamNo + "/2";
                        strPromiserID2 = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strTeamNo + "/1s";
                    }
                    else if (intLastCID == 3)
                    {
                        strTeamNo = Convert.ToString(intLastTID + 1);
                        strClientID = "1";
                        strCACodeNew = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strTeamNo + "/1";
                        hidCACode.Value = strCACodeNew;
                        strPromiserID = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strTeamNo + "/2";
                        strPromiserID2 = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/" + strTeamNo + "/3";
                    }
                }
                else
                {
                    strCACodeNew = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/1/1";
                    hidCACode.Value = strCACodeNew;
                    strPromiserID = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/1/2";
                    strPromiserID2 = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/1/3";
                    strTeamNo = "1";
                    strClientID = "1";
                }
            }
            else
            {
                strCACodeNew = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/1/1";
                hidCACode.Value = strCACodeNew;
                strPromiserID = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/1/2";
                strPromiserID2 = strCityCode + "/" + strArea + "/" + strVillage + "/" + strSoNumber + "/1/3";
                strTeamNo = "1";
                strClientID = "1";
            }
            #endregion

            #region DeclarareParamerts
            cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 30);
            cmdInsert.Parameters.Add("@ca_code", MySqlDbType.VarChar, 17);
            cmdInsert.Parameters.Add("@nic", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@city_code", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@area_code", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@village", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@society_id", MySqlDbType.VarChar, 6);
            //cmdInsert.Parameters.Add("@province", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@gs_ward", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@full_name", MySqlDbType.VarChar, 100);
            //cmdInsert.Parameters.Add("@initial_name", MySqlDbType.VarChar, 100);
            //cmdInsert.Parameters.Add("@other_name", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@marital_status", MySqlDbType.VarChar, 1);
            //cmdInsert.Parameters.Add("@education", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@land_no", MySqlDbType.VarChar, 10);
            //cmdInsert.Parameters.Add("@mobile_no", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@p_address", MySqlDbType.VarChar, 255);
            cmdInsert.Parameters.Add("@team_id", MySqlDbType.VarChar, 2);
            cmdInsert.Parameters.Add("@client_id", MySqlDbType.VarChar, 2);
            cmdInsert.Parameters.Add("@inspection_date", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@create_user_id", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@root_id", MySqlDbType.VarChar, 1);
            cmdInsert.Parameters.Add("@nic_issue_date", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@dob", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@gender", MySqlDbType.VarChar, 1);
            cmdInsert.Parameters.Add("@r_address", MySqlDbType.VarChar, 255);
            cmdInsert.Parameters.Add("@income_source", MySqlDbType.VarChar, 100);
            cmdInsert.Parameters.Add("@promisers_id", MySqlDbType.VarChar, 17);
            cmdInsert.Parameters.Add("@promiser_id_2", MySqlDbType.VarChar, 17);
            #endregion

            #region AssignParameters
            cmdInsert.Parameters["@contract_code"].Value = strCC;
            cmdInsert.Parameters["@ca_code"].Value = strCACodeNew;
            cmdInsert.Parameters["@nic"].Value = strNIC;
            cmdInsert.Parameters["@city_code"].Value = strCityCode;
            cmdInsert.Parameters["@area_code"].Value = strArea;
            cmdInsert.Parameters["@village"].Value = strVillage;
            cmdInsert.Parameters["@society_id"].Value = strSoNumber;
            //cmdInsert.Parameters["@province"].Value = strProvince;
            cmdInsert.Parameters["@gs_ward"].Value = strGSWard;
            cmdInsert.Parameters["@full_name"].Value = strFullName;
            //cmdInsert.Parameters["@initial_name"].Value = strIniName;
            //cmdInsert.Parameters["@other_name"].Value = strOName;
            cmdInsert.Parameters["@marital_status"].Value = strMaStatus;
            //cmdInsert.Parameters["@education"].Value = strEducation;
            cmdInsert.Parameters["@land_no"].Value = strTNumber;
            //cmdInsert.Parameters["@mobile_no"].Value = strMobNo;
            cmdInsert.Parameters["@p_address"].Value = strAddress;
            cmdInsert.Parameters["@team_id"].Value = strTeamNo;
            cmdInsert.Parameters["@client_id"].Value = strClientID;
            cmdInsert.Parameters["@inspection_date"].Value = strInspDate;
            cmdInsert.Parameters["@create_user_id"].Value = strloginID;
            cmdInsert.Parameters["@user_ip"].Value = strIp;
            cmdInsert.Parameters["@date_time"].Value = strDateTime;
            cmdInsert.Parameters["@root_id"].Value = strRootID;
            cmdInsert.Parameters["@nic_issue_date"].Value = strNICIssuedDate;
            cmdInsert.Parameters["@dob"].Value = strDOB;
            cmdInsert.Parameters["@gender"].Value = strGender;
            cmdInsert.Parameters["@r_address"].Value = strRAddress;
            cmdInsert.Parameters["@income_source"].Value = strOccupation;
            cmdInsert.Parameters["@promisers_id"].Value = strPromiserID;
            cmdInsert.Parameters["@promiser_id_2"].Value = strPromiserID2;
            #endregion

            try
            {
                int i = objDBCon.insertEditData(cmdInsert);
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    lblMsg.Text = "Error Occured";
                    return false;
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Inserting basic details");
                return false;
            }
        }
        protected bool saveFamilyDetails()
        {
            MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_family_details(contract_code,spouse_nic,spouse_nic_issued_date,spouse_name,occupation,spouse_dob,spouse_gender,spouse_contact_no,spouse_relationship_with_applicant,create_user_nic,user_ip,date_time) VALUES(@contract_code,@spouse_nic,@spouse_nic_issued_date,@spouse_name,@occupation,@spouse_dob,@spouse_gender,@spouse_contact_no,@spouse_relationship_with_applicant,@create_user_nic,@user_ip,@date_time);");

            #region Values
            string strIp = Request.UserHostAddress;
            string strCCode = txtCC.Text.Trim();
            //string strCACode = txtCACode.Text.Trim();
            string strloginID = Session["NIC"].ToString();
            string strNIC = txtSoNIC.Text.Trim();
            string strNICissueDate = txtSoNicIssuedDate.Text.Trim();
            string strSDob = txtDOB.Text.Trim();
            string strSGender;
            if (rdoSoMale.Checked)
                strSGender = "0";
            else
                strSGender = "1";
            string strName = txtSoName.Text.Trim();
            string strSContact = txtSoContactNo.Text.Trim();
            string strRelation = cmbRelation.SelectedItem.Text;
            string strOcc = cmbOccupa.SelectedValue;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            #region Declare Parameters
            cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 15);
            cmdInsert.Parameters.Add("@spouse_nic", MySqlDbType.VarChar, 12);
            cmdInsert.Parameters.Add("@spouse_nic_issued_date", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@spouse_name", MySqlDbType.VarChar, 100);
            cmdInsert.Parameters.Add("@spouse_dob", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@spouse_gender", MySqlDbType.VarChar, 1);
            cmdInsert.Parameters.Add("@spouse_contact_no", MySqlDbType.VarChar, 15);
            cmdInsert.Parameters.Add("@spouse_relationship_with_applicant", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@occupation", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
            cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
            cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
            #endregion

            #region Assign Values
            cmdInsert.Parameters["@contract_code"].Value = strCCode;
            cmdInsert.Parameters["@spouse_nic"].Value = strNIC;
            cmdInsert.Parameters["@spouse_nic_issued_date"].Value = strNICissueDate;
            cmdInsert.Parameters["@spouse_name"].Value = strName;
            cmdInsert.Parameters["@spouse_dob"].Value = strSDob;
            cmdInsert.Parameters["@spouse_gender"].Value = strSGender;
            cmdInsert.Parameters["@spouse_contact_no"].Value = strSContact;
            cmdInsert.Parameters["@spouse_relationship_with_applicant"].Value = strRelation;
            cmdInsert.Parameters["@occupation"].Value = strOcc;
            cmdInsert.Parameters["@create_user_nic"].Value = strloginID;
            cmdInsert.Parameters["@user_ip"].Value = strIp;
            cmdInsert.Parameters["@date_time"].Value = strDateTime;
            #endregion
            try
            {
                int i = objDBCon.insertEditData(cmdInsert);
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    lblMsg.Text = "Error Occured";
                    return false;
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Inserting family details");
                return false;
            }
        }
        protected bool saveBUsinessDetails()
        {
            MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_business_details(contract_code,business_name,busi_duration,busi_address,busi_nature,key_person,no_of_ppl,br_no,contact_no_ofc,create_user_nic,user_ip,date_time)VALUES(@contract_code, @business_name, @busi_duration, @busi_address, @busi_nature, @key_person, @no_of_ppl, @br_no, @contact_no_ofc, @create_user_nic, @user_ip, @date_time)");

            #region GetValues
            string strIp = Request.UserHostAddress;
            string strloginID = Session["NIC"].ToString();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strCC = hidCC.Value.Trim();

            string strBN = txtBusiness.Text.Trim();
            string strNature = cmbBNature.SelectedValue;
            string strDur = cmbPeriod.SelectedValue;
            string strBAdd = txtBisAddress.Text.Trim();
            string strKPerson = cmbKeyPerson.SelectedValue;
            string strNoOfPpl = txtNoOfPpl.Text.Trim();
            string strBrNo = txtBRNo.Text.Trim();
            string strBContact = txtBContact.Text.Trim();
            #endregion

            #region GetValues
            cmdInsert.Parameters.AddWithValue("@contract_code", strCC);
            cmdInsert.Parameters.AddWithValue("@business_name", strBN);
            cmdInsert.Parameters.AddWithValue("@busi_nature", strNature);
            cmdInsert.Parameters.AddWithValue("@contact_no_ofc", strBContact);
            cmdInsert.Parameters.AddWithValue("@busi_duration", strDur);
            cmdInsert.Parameters.AddWithValue("@busi_address", strBAdd);
            cmdInsert.Parameters.AddWithValue("@key_person", strKPerson);
            cmdInsert.Parameters.AddWithValue("@no_of_ppl", (strNoOfPpl != "") ? Convert.ToInt32(strNoOfPpl) : 00);
            cmdInsert.Parameters.AddWithValue("@br_no", strBrNo);
            cmdInsert.Parameters.AddWithValue("@create_user_nic", strloginID);
            cmdInsert.Parameters.AddWithValue("@user_ip", strIp);
            cmdInsert.Parameters.AddWithValue("@date_time", strDateTime);
            #endregion

            try
            {
                int i = objDBCon.insertEditData(cmdInsert);
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    lblMsg.Text = "Error Occured";
                    return false;
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Inserting Business details");
                return false;
            }
        }
        protected bool saveFacilityRequirment()
        {
            string q = "INSERT INTO micro_loan_details(contra_code, loan_amount, period, reason_to_apply, any_unsettled_loans) VALUES (@contra_code, @loan_amount, @period, @reason_to_apply, @any_unsettled_loans)";


                if (txtLDLAmount.Text.Trim() == "")
                    lblMsg.Text = "Please enter Facility Amount/ Value";
                else if (txtNameOrg1.Text.Trim() != "")
                {
                    if (txtPurpos1.Text.Trim() == "") lblMsg.Text = "Please fill the field purpose 1";
                    if (txtFAmount1.Text.Trim() == "") lblMsg.Text = "Please fill the field facility amount 1";
                    if (txtOutstandBal1.Text.Trim() == "") lblMsg.Text = "Please fill the field outstanding balance 1";
                    if (txtMonthInstal1.Text.Trim() == "") lblMsg.Text = "Please fill the field monthly installment 1";
                    if (txtRemainInstal1.Text.Trim() == "") lblMsg.Text = "Please fill the field remaining no of installment 1";

                    else if (txtNameOrg2.Text.Trim() != "")
                    {
                        if (txtPurpos2.Text.Trim() == "") lblMsg.Text = "Please fill the field purpose 2";
                        if (txtFAmount2.Text.Trim() == "") lblMsg.Text = "Please fill the field facility amount 2";
                        if (txtOutstandBal2.Text.Trim() == "") lblMsg.Text = "Please fill the field outstanding balance 2";
                        if (txtMonthInstal2.Text.Trim() == "") lblMsg.Text = "Please fill the field monthly installment 2";
                        if (txtRemainInstal2.Text.Trim() == "") lblMsg.Text = "Please fill the field remaining no of installment 1";
                    }

                    else if (txtNameOrg3.Text.Trim() != "")
                    {
                        if (txtPurpos3.Text.Trim() == "") lblMsg.Text = "Please fill the field purpose 3";
                        if (txtFAmount3.Text.Trim() == "") lblMsg.Text = "Please fill the field facility amount 3";
                        if (txtOutstandBal3.Text.Trim() == "") lblMsg.Text = "Please fill the field outstanding balance 3";
                        if (txtMonthInstal3.Text.Trim() == "") lblMsg.Text = "Please fill the field monthly installment 3";
                        if (txtRemainInstal3.Text.Trim() == "") lblMsg.Text = "Please fill the field remaining no of installment 3";
                    }
                }

                MySqlCommand cmdInsert = new MySqlCommand(q);
                #region Parameter Declarations
                cmdInsert.Parameters.AddWithValue("@contra_code", txtCC.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@loan_amount", Convert.ToDecimal((txtLDLAmount.Text.Trim() != "") ? txtLDLAmount.Text.Trim() : "0.00"));
                cmdInsert.Parameters.AddWithValue("@period", cmbTmePeriod.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@reason_to_apply", txtResonToApply.Text.Trim());
                if (rdoYes.Checked)
                {
                    cmdInsert.Parameters.AddWithValue("@any_unsettled_loans", 1);
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@any_unsettled_loans", 0);
                }
                #endregion
                try
                {
                    int i = objDBCon.insertEditData(cmdInsert);
                    if (i > 0)
                    {
                        if (checkOtherFacility())
                            return true;
                        else
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Data Sending error");
                    return false;
                }
                return false;
        }
        protected bool checkOtherFacility()
        {
            try
            {
                string strOtherFacility = "";
                strOtherFacility = "INSERT INTO `micro_other_unsetteled_loans`(contra_code,organization,purpos,facility_amount,outstanding,monthly_installment,remaining_number_of_installment) VALUES ";
                if (txtNameOrg1.Text.Trim() != "")
                {
                    strOtherFacility += "('" + txtCC.Text.Trim() + "','" + txtNameOrg1.Text.Trim() + "','" + txtPurpos1.Text.Trim() + "'," + txtFAmount1.Text.Trim() + "," + txtOutstandBal1.Text.Trim() + "," + txtMonthInstal1.Text.Trim() + "," + txtRemainInstal1.Text.Trim() + ")";
                }
                if (txtNameOrg2.Text.Trim() != "")
                {
                    strOtherFacility += ",('" + txtCC.Text.Trim() + "','" + txtNameOrg2.Text.Trim() + "','" + txtPurpos2.Text.Trim() + "'," + txtFAmount2.Text.Trim() + "," + txtOutstandBal2.Text.Trim() + "," + txtMonthInstal2.Text.Trim() + "," + txtRemainInstal2.Text.Trim() + ")";
                }
                if (txtNameOrg3.Text.Trim() != "")
                {
                    strOtherFacility += ",('" + txtCC.Text.Trim() + "','" + txtNameOrg3.Text.Trim() + "','" + txtPurpos3.Text.Trim() + "'," + txtFAmount3.Text.Trim() + "," + txtOutstandBal3.Text.Trim() + "," + txtMonthInstal3.Text.Trim() + "," + txtRemainInstal3.Text.Trim() + ")";
                }

                cls_Connection.setData(strOtherFacility.ToString());
                return true;
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Inserting other facility details");
                return false;
            }
            //int i = cls_Connection.setData(strOtherFacility.ToString());
        }
        protected bool otherFamilyDetails() 
        {
            try
            {
                string strCCode = hidCC.Value.Trim();
                string strIp = Request.UserHostAddress;
                string strloginID = Session["NIC"].ToString();
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                StringBuilder strRelat = new StringBuilder();
                string strQry2 = "INSERT INTO family_relationship_details (contract_code,name, relationship, nic, dob, occupation, income,create_user_nic,user_ip,date_time) VALUES ";
                if (txtName1.Text.Trim() != "")
                    strRelat.Append("('" + strCCode + "','" + txtName1.Text.Trim() + "','" + cmbRelation1.SelectedItem.Text + "','" + txtNIC1.Text.Trim() + "','" + txtDOB1.Text.Trim() + "','" + txtOcc1.Text.Trim() + "','" + txtInCome1.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);

                if (txtName2.Text.Trim() != "")
                    strRelat.Append("'),('" + strCCode + "','" + txtName2.Text.Trim() + "','" + cmbRelation2.SelectedItem.Text + "','" + txtNIC2.Text.Trim() + "','" + txtDOB2.Text.Trim() + "','" + txtOcc2.Text.Trim() + "','" + txtInCome2.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);
                if (txtName3.Text.Trim() != "")
                    strRelat.Append("'),('" + strCCode + "','" + txtName3.Text.Trim() + "','" + cmbRelation3.SelectedItem.Text + "','" + txtNIC3.Text.Trim() + "','" + txtDOB3.Text.Trim() + "','" + txtOcc3.Text.Trim() + "','" + txtInCome3.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);
                if (txtName4.Text.Trim() != "")
                    strRelat.Append("'),('" + strCCode + "','" + txtName4.Text.Trim() + "','" + cmbRelation4.SelectedItem.Text + "','" + txtNIC4.Text.Trim() + "','" + txtDOB4.Text.Trim() + "','" + txtOcc4.Text.Trim() + "','" + txtInCome4.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);
                if (txtName5.Text.Trim() != "")
                    strRelat.Append("'),('" + strCCode + "','" + txtName5.Text.Trim() + "','" + cmbRelation5.SelectedItem.Text + "','" + txtNIC5.Text.Trim() + "','" + txtDOB5.Text.Trim() + "','" + txtOcc5.Text.Trim() + "','" + txtInCome5.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);
                if (txtName6.Text.Trim() != "")
                    strRelat.Append("'),('" + strCCode + "','" + txtName6.Text.Trim() + "','" + cmbRelation6.SelectedItem.Text + "','" + txtNIC6.Text.Trim() + "','" + txtDOB6.Text.Trim() + "','" + txtOcc6.Text.Trim() + "','" + txtInCome6.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);
                if (txtName7.Text.Trim() != "")
                    strRelat.Append("'),('" + strCCode + "','" + txtName7.Text.Trim() + "','" + cmbRelation7.SelectedItem.Text + "','" + txtNIC7.Text.Trim() + "','" + txtDOB7.Text.Trim() + "','" + txtOcc7.Text.Trim() + "','" + txtInCome7.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);
                if (txtName8.Text.Trim() != "")
                    strRelat.Append("'),('" + strCCode + "','" + txtName8.Text.Trim() + "','" + cmbRelation8.SelectedItem.Text + "','" + txtNIC8.Text.Trim() + "','" + txtDOB8.Text.Trim() + "','" + txtOcc8.Text.Trim() + "','" + txtInCome8.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);
                if (txtName9.Text.Trim() != "")
                    strRelat.Append("'),('" + strCCode + "','" + txtName9.Text.Trim() + "','" + cmbRelation9.SelectedItem.Text + "','" + txtNIC9.Text.Trim() + "','" + txtDOB9.Text.Trim() + "','" + txtOcc9.Text.Trim() + "','" + txtInCome9.Text.Trim() + "','" + strloginID + "','" + strIp + "','" + strDateTime);


                string strQry3 = "')";

                int i = objDBCon.insertEditData(strQry2 + strRelat.ToString() + strQry3);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    lblMsg.Text = "Error Occured";
                    return false;
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Inserting other family details");
                return false;
            }
        }

        private void Update()
        {
            try
            {
                lblMsg.Text = "";
                if (txtNIC.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter NIC No.";
                }
                else if (cmbBranch.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select city code.";
                }
                else if (cmbArea.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select village name.";
                }
                else if (txtSoNumber.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Society Number.";
                }
                //else if (txtGroupID.Text.Trim() == "")
                //{
                //    lblMsg.Text = "Please enter Group ID";
                //}
                else if (txtGSWard.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter GS Ward.";
                }
                else if (txtFullName.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Full Name.";
                }
                //else if (txtInwName.Text.Trim() == "")
                //{
                //    lblMsg.Text = "Please enter Initial Name.";
                //}
                //else if (txtTNo.Text.Trim() == "")
                //{
                //    lblMsg.Text = "Please enter Phone Number.";
                //}
                //else if (txtMobileNo.Text.Trim() == "")
                //{
                //    lblMsg.Text = "Please enter Mobile Number.";
                //}
                else if (txtAddress.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Address.";
                }
                else
                {
                    string strloginID = Session["NIC"].ToString();

                    //Create Facility Code
                    //ccsetup();

                    //Create Capital Applicant Code
                    //CACodeNew();

                    #region Get Values
                    string strIp = Request.UserHostAddress;
                    string strCC = hidCC.Value;
                    string strNIC, strCityCode, strVillage, strSoName, strSoNumber, strProvince, strGSWard, strFullName, strGName, strIniName, strOName;
                    string strEducation, strTNumber, strMobNo, strAddress, strCACode, strInspDate, strDateTime, strRootID, strPromiser2;
                    string strDOB, strGender, strRAddress, strOccupation, strNICIssuedDate, strMaStatus;

                    strNIC = txtNIC.Text.Trim();
                    strCityCode = cmbBranch.SelectedItem.Value;
                    strVillage = cmbArea.SelectedItem.Value;
                    strSoName = cmbVillage.SelectedItem.Value;
                    strSoNumber = txtSoNumber.Text.Trim();
                    //strProvince = cmbProvince.SelectedItem.Value;
                    strGSWard = txtGSWard.Text.Trim();
                    strFullName = txtFullName.Text.Trim();
                    //strGName = txtGivenName.Text.Trim();
                    //strIniName = txtInwName.Text.Trim();
                    //strOName = txtOtherName.Text.Trim();
                    strMaStatus = cmbMS.SelectedItem.Value;
                    strRootID = hidRoot.Value.Trim().ToString();
                    //strRootID = cmbRoot.SelectedItem.Value;                    
                    //strEducation = cmbEducation.SelectedItem.Value;
                    strTNumber = txtTele.Text.Trim();
                    //strMobNo = txtMobileNo.Text.Trim();
                    strAddress = txtAddress.Text.Trim();
                    strInspDate = txtInsDate.Text.Trim();
                    strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    strNICIssuedDate = txtNicIssuDay.Text.Trim();
                    strDOB = txtDOB.Text.Trim();

                    if (rdoMale.Checked)
                        strGender = "1";
                    else strGender = "0";

                    strRAddress = txtResiAddress.Text.Trim();
                    strOccupation = cmbOccupation.SelectedValue.ToString();
                    #endregion

                    //MySqlCommand cmdInsert = new MySqlCommand("UPDATE micro_basic_detail SET nic = '" + strNIC + "',city_code = '" + strCityCode + "',society_id = '" + strSoNumber + "',province = '" + strProvince + "',gs_ward = '" + strGSWard + "',full_name = '" + strFullName + "',initial_name = '" + strIniName + "',other_name='" + strOName + "',marital_status='" + strMaStatus + "',education='" + strEducation + "',land_no='" + strTNumber + "',mobile_no='" + strMobNo + "',p_address='" + strAddress + "',client_id='" + strClientID + "',inspection_date='" + strInspDate + "',village='" + strVillage + "',root_id='" + strRootID + "',nic_issue_date='"+strNICIssuedDate+"',dob='"+strDOB+"',gender='"+strGender+"',r_address='"+strRAddress+"',income_source='"+strOccupation+"' WHERE idmicro_basic_detail = '" + hf3.Value + "';");

                    MySqlCommand cmdInsert = new MySqlCommand("UPDATE micro_basic_detail SET nic = '" + strNIC + "',city_code = '" + strCityCode + "',society_id = '" + strSoNumber + "',gs_ward = '" + strGSWard + "',full_name = '" + strFullName + "',marital_status='" + strMaStatus + "',land_no='" + strTNumber + "',p_address='" + strAddress + "',client_id='" + strClientID + "',inspection_date='" + strInspDate + "',village='" + strVillage + "',root_id='" + strRootID + "',nic_issue_date='" + strNICIssuedDate + "',dob='" + strDOB + "',gender='" + strGender + "',r_address='" + strRAddress + "',income_source='" + strOccupation + "' WHERE idmicro_basic_detail = '" + hf3.Value + "';");

                    try
                    {
                        int i = objDBCon.insertEditData(cmdInsert);
                        if (i == 1)
                        {
                            //Response.Redirect("Family_Details.aspx?CC=" + strCC + "&CA=" + strCACode + "");
                            lblMsg.Text = "Update Successfull..";
                        }
                        else
                        {
                            lblMsg.Text = "Error Occured";
                        }
                    }
                    catch (Exception ex)
                    {
                        cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Updating basic details");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Updating basic details");
                return;
            }
        }

        #region NICnumberValidation_old
        private bool IsValidNIC(string NIC)
        {
            string pattern = @"\d{9}[V|v|x|X]";
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            bool valid = false;
            if (string.IsNullOrEmpty(NIC))
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(NIC);
            }
            return valid;
        }
        #endregion

        #region NICnumberValidation_new
        private bool IsValidNewNIC(string NIC)
        {
            string pattern = @"\d{12}";
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            bool valid = false;
            if (string.IsNullOrEmpty(NIC))
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(NIC);
            }
            return valid;
        }
        #endregion

        private void IsExist()
        {
            try
            {
                lblMsg.Text = "";
                lblMsg0.Text = "";
                if (txtNIC.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter NIC Number.";
                    btnSubmit.Enabled = false;
                }
                else
                {
                    if (txtNIC.Text.Length == 10)
                    {
                        if (IsValidNIC(txtNIC.Text) == false)
                        {
                            lblMsg0.Text = "Please enter valid NIC No.";
                            txtNIC.Focus();
                            return;
                        }
                    }
                    else if (txtNIC.Text.Length == 12)
                    {
                        if (IsValidNewNIC(txtNIC.Text) == false)
                        {
                            lblMsg0.Text = "Please enter valid NIC No.";
                            txtNIC.Focus();
                            return;
                        }
                    }
                    else
                    {
                        lblMsg0.Text = "Please enter valid NIC No.";
                        txtNIC.Focus();
                        return;
                    }
                    lblMsg0.Text = "";
                    DataSet dsGetExsiNIC = cls_Connection.getDataSet("select * from micro_basic_detail where nic = '" + txtNIC.Text.Trim() + "';");
                    if (dsGetExsiNIC.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsGetExsiLoan = cls_Connection.getDataSet("select * from micro_loan_details where contra_code = '" + dsGetExsiNIC.Tables[0].Rows[0]["contract_code"].ToString() + "';");

                        if (dsGetExsiLoan.Tables[0].Rows[0]["loan_sta"].ToString() == "S" || dsGetExsiLoan.Tables[0].Rows[0]["loan_sta"].ToString() == "C")
                        {
                            lblMsg.Text = "Please complete the loan application form, unless you cannot be modify basic details...";
                            return;
                        }
                        else if (dsGetExsiLoan.Tables[0].Rows[0]["loan_sta"].ToString() == "P" && dsGetExsiLoan.Tables[0].Rows[0]["loan_approved"].ToString() == "Y" && dsGetExsiLoan.Tables[0].Rows[0]["chequ_no"].ToString() == "")
                        {
                            hf3.Value = dsGetExsiNIC.Tables[0].Rows[0]["idmicro_basic_detail"].ToString();
                            cmbBranch.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["city_code"].ToString();
                            getArea();
                            
                            cmbArea.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["area"].ToString();
                            
                            getVillage();

                            getSocity();
                            txtSoNumber.Text = dsGetExsiNIC.Tables[0].Rows[0]["society_id"].ToString();
                            
                            txtGSWard.Text = dsGetExsiNIC.Tables[0].Rows[0]["gs_ward"].ToString();
                            txtFullName.Text = dsGetExsiNIC.Tables[0].Rows[0]["full_name"].ToString();
                            rdoMale.Checked = dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0" ? true : false;
                            txtDOB.Text = dsGetExsiNIC.Tables[0].Rows[0]["dob"].ToString();

                            DateTime now = DateTime.UtcNow.Date;
                            DateTime dt = DateTime.Parse(dsGetExsiNIC.Tables[0].Rows[0]["dob"].ToString(), new CultureInfo("en-CA"));
                            int age = now.Year - dt.Year;

                            lblAge.Text = age.ToString();
                            rdoFeMale.Checked = dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0" ? true : false;
                            
                            txtTele.Text = dsGetExsiNIC.Tables[0].Rows[0]["land_no"].ToString();
                            txtAddress.Text = dsGetExsiNIC.Tables[0].Rows[0]["p_address"].ToString();
                            txtResiAddress.Text = dsGetExsiNIC.Tables[0].Rows[0]["r_address"].ToString();
                            cmbOccupation.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["income_source"].ToString();
                            try
                            {
                                cmbVillage.Text = dsGetExsiNIC.Tables[0].Rows[0]["center_name"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                cmbRoot.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["root_id"].ToString();
                                hidRoot.Value = dsGetExsiNIC.Tables[0].Rows[0]["root_id"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            txtInsDate.Text = dsGetExsiNIC.Tables[0].Rows[0]["inspection_date"].ToString();

                            lblMsg.Text = "";
                            btnSubmit.Enabled = false;
                            btnSubmit.Visible = false;
                            btnUpdate.Visible = true;
                            string strloginID = Session["NIC"].ToString();
                            DataSet dsUserTy = cls_Connection.getDataSet("select user_type,module_name,company_code from users where nic = '" + strloginID + "';");
                            if (dsUserTy.Tables[0].Rows.Count > 0)
                            {
                                if (dsUserTy.Tables[0].Rows[0]["user_type"].ToString() == "Top Management" || dsUserTy.Tables[0].Rows[0]["user_type"].ToString() == "Admin")
                                {
                                    btnSubmit.Enabled = true;
                                    btnUpdate.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            #region Basic Details
                            hf3.Value = dsGetExsiNIC.Tables[0].Rows[0]["idmicro_basic_detail"].ToString();
                            txtNicIssuDay.Text = dsGetExsiNIC.Tables[0].Rows[0]["nic_issue_date"].ToString();
                            cmbBranch.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["city_code"].ToString();
                            getArea();
                            
                            cmbArea.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["area_code"].ToString();
                            
                            getVillage();
                            cmbVillage.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["village"].ToString();

                            getSocity();
                            cmbCenter.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["society_id"].ToString();
                            txtSoNumber.Text = dsGetExsiNIC.Tables[0].Rows[0]["society_id"].ToString();
                            txtCC.Text = dsGetExsiNIC.Tables[0].Rows[0]["contract_code"].ToString();
                            txtCC.ReadOnly = true;

                            txtGSWard.Text = dsGetExsiNIC.Tables[0].Rows[0]["gs_ward"].ToString();
                            txtFullName.Text = dsGetExsiNIC.Tables[0].Rows[0]["full_name"].ToString();
                            rdoMale.Checked = dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0" ? true : false;
                            rdoFeMale.Checked = dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0" ? true : false;
                            
                            txtTele.Text = dsGetExsiNIC.Tables[0].Rows[0]["land_no"].ToString();
                            txtAddress.Text = dsGetExsiNIC.Tables[0].Rows[0]["p_address"].ToString();

                            cmbOccupation.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["income_source"].ToString();
                            txtDOB.Text = dsGetExsiNIC.Tables[0].Rows[0]["dob"].ToString();

                            //DateTime now = new DateTime();
                            DateTime dt = DateTime.Parse(dsGetExsiNIC.Tables[0].Rows[0]["dob"].ToString(), new CultureInfo("en-CA"));
                            lblAge.Text = (DateTime.Now.Year - dt.Year).ToString();

                            cmbMS.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["marital_status"].ToString();
                            if (dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0")
                            {
                                rdoMale.Checked = true;
                            }
                            else
                            {
                                rdoFeMale.Checked = true;
                            }
                            #endregion
                            #region Family Details
                            DataSet dsFD = cls_Connection.getDataSet("SELECT * FROM micro_family_details WHERE contract_code = '" + txtCC.Text.Trim() + "';");
                            if (dsFD.Tables[0].Rows.Count > 0)
                            {
                                txtSoNIC.Text = dsFD.Tables[0].Rows[0]["spouse_nic"].ToString();
                                txtSoNicIssuedDate.Text = dsFD.Tables[0].Rows[0]["spouse_nic_issued_date"].ToString();
                                txtSoDOB.Text = dsFD.Tables[0].Rows[0]["spouse_dob"].ToString();
                                DateTime dtSo = DateTime.Parse(dsFD.Tables[0].Rows[0]["spouse_dob"].ToString(), new CultureInfo("en-CA"));
                                lblSoAge.Text = (DateTime.Now.Year - dtSo.Year).ToString();
                                
                                string strSGender;
                                if (dsFD.Tables[0].Rows[0]["spouse_dob"].ToString() == "0")
                                    rdoSoMale.Checked = true;
                                else
                                    rdoSoFeMale.Checked = true;

                                txtSoName.Text = dsFD.Tables[0].Rows[0]["spouse_name"].ToString();
                                txtSoContactNo.Text = dsFD.Tables[0].Rows[0]["spouse_contact_no"].ToString();
                                cmbRelation.SelectedValue = dsFD.Tables[0].Rows[0]["spouse_relationship_with_applicant"].ToString();
                                cmbOccupa.SelectedValue = dsFD.Tables[0].Rows[0]["occupation"].ToString();
                            }
                            #endregion
                            #region Business Details
                            DataSet dsBD = cls_Connection.getDataSet("SELECT * FROM micro_business_details WHERE contract_code = '" + txtCC.Text.Trim() + "';");
                            if (dsBD.Tables[0].Rows.Count > 0)
                            {
                                txtBusiness.Text = dsBD.Tables[0].Rows[0]["business_name"].ToString();
                                cmbBNature.SelectedValue = dsBD.Tables[0].Rows[0]["busi_nature"].ToString();
                                cmbPeriod.SelectedValue = dsBD.Tables[0].Rows[0]["busi_duration"].ToString();
                                txtBisAddress.Text = dsBD.Tables[0].Rows[0]["busi_address"].ToString();
                                cmbKeyPerson.SelectedValue = dsBD.Tables[0].Rows[0]["key_person"].ToString();
                                txtNoOfPpl.Text = dsBD.Tables[0].Rows[0]["no_of_ppl"].ToString();
                                txtBRNo.Text = dsBD.Tables[0].Rows[0]["br_no"].ToString();
                                txtBContact.Text = dsBD.Tables[0].Rows[0]["contact_no_ofc"].ToString();
                            }
                            #endregion
                            #region Facility Requirment

                            DataSet dsFR = cls_Connection.getDataSet("SELECT * FROM micro_loan_details WHERE contra_code = '" + txtCC.Text.Trim() + "';");
                            if (dsFR.Tables[0].Rows.Count > 0)
                            {
                                txtResonToApply.Text = dsFR.Tables[0].Rows[0]["reason_to_apply"].ToString();
                                txtLDLAmount.Text = dsFR.Tables[0].Rows[0]["loan_amount"].ToString();
                                cmbTmePeriod.SelectedValue = dsFR.Tables[0].Rows[0]["period"].ToString();
                                if (dsFR.Tables[0].Rows[0]["any_unsettled_loans"].ToString() == "1")
                                {
                                    DataSet dsUnSLons = cls_Connection.getDataSet("SELECT * FROM micro_other_unsetteled_loans WHERE contra_code = '" + txtCC.Text.Trim() + "';");
                                    if (dsUnSLons.Tables[0].Rows.Count > 0)
                                    {
                                        //rdoOFDy.Checked = true;

                                        for (int i = 0; i < dsUnSLons.Tables[0].Rows.Count; i++)
                                        {
                                            if (i == 0)
                                            {
                                                txtNameOrg1.Text = dsUnSLons.Tables[0].Rows[i]["organization"].ToString();
                                                txtPurpos1.Text = dsUnSLons.Tables[0].Rows[i]["purpos"].ToString();
                                                txtFAmount1.Text = dsUnSLons.Tables[0].Rows[i]["facility_amount"].ToString();
                                                txtOutstandBal1.Text = dsUnSLons.Tables[0].Rows[i]["outstanding"].ToString();
                                                txtMonthInstal1.Text = dsUnSLons.Tables[0].Rows[i]["monthly_installment"].ToString();
                                                txtRemainInstal1.Text = dsUnSLons.Tables[0].Rows[i]["remaining_number_of_installment"].ToString();
                                            }
                                            else if (i == 1)
                                            {
                                                txtNameOrg2.Text = dsUnSLons.Tables[0].Rows[i]["organization"].ToString();
                                                txtPurpos2.Text = dsUnSLons.Tables[0].Rows[i]["purpos"].ToString();
                                                txtFAmount2.Text = dsUnSLons.Tables[0].Rows[i]["facility_amount"].ToString();
                                                txtOutstandBal2.Text = dsUnSLons.Tables[0].Rows[i]["outstanding"].ToString();
                                                txtMonthInstal2.Text = dsUnSLons.Tables[0].Rows[i]["monthly_installment"].ToString();
                                                txtRemainInstal2.Text = dsUnSLons.Tables[0].Rows[i]["remaining_number_of_installment"].ToString();
                                            }
                                            else if (i == 3)
                                            {
                                                txtNameOrg3.Text = dsUnSLons.Tables[0].Rows[i]["organization"].ToString();
                                                txtPurpos3.Text = dsUnSLons.Tables[0].Rows[i]["purpos"].ToString();
                                                txtFAmount3.Text = dsUnSLons.Tables[0].Rows[i]["facility_amount"].ToString();
                                                txtOutstandBal3.Text = dsUnSLons.Tables[0].Rows[i]["outstanding"].ToString();
                                                txtMonthInstal3.Text = dsUnSLons.Tables[0].Rows[i]["monthly_installment"].ToString();
                                                txtRemainInstal3.Text = dsUnSLons.Tables[0].Rows[i]["remaining_number_of_installment"].ToString();
                                            }
                                            else { }
                                        }
                                    }
                                }
                            }
                            #endregion
                            #region Other Family Details
                            DataSet dsOFD = cls_Connection.getDataSet("SELECT * FROM family_relationship_details WHERE contract_code = '" + txtCC.Text.Trim() + "';");
                            if (dsOFD.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsOFD.Tables[0].Rows.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        txtName1.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation1.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC1.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB1.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc1.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome1.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                    else if (i == 1)
                                    {
                                        txtName2.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation2.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC2.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB2.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc2.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome2.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                    else if (i == 2)
                                    {
                                        txtName3.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation3.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC3.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB3.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc3.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome3.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                    else if (i == 3)
                                    {
                                        txtName4.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation4.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC4.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB4.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc4.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome4.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                    else if (i == 4)
                                    {
                                        txtName5.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation5.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC5.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB5.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc5.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome5.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                    else if (i == 5)
                                    {
                                        txtName6.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation6.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC6.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB6.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc6.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome6.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                    else if (i == 6)
                                    {
                                        txtName7.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation7.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC7.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB7.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc7.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome7.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                    else if (i == 7)
                                    {
                                        txtName8.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation8.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC8.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB8.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc8.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome8.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                    else if (i == 8)
                                    {
                                        txtName9.Text = dsOFD.Tables[0].Rows[i]["name"].ToString();
                                        cmbRelation9.SelectedValue = dsOFD.Tables[0].Rows[i]["relationship"].ToString();
                                        txtNIC9.Text = dsOFD.Tables[0].Rows[i]["nic"].ToString();
                                        txtDOB9.Text = dsOFD.Tables[0].Rows[i]["dob"].ToString();
                                        txtOcc9.Text = dsOFD.Tables[0].Rows[i]["occupation"].ToString();
                                        txtInCome9.Text = dsOFD.Tables[0].Rows[i]["income"].ToString();
                                    }
                                }
                            }
                            
                            #endregion

                            try
                            {
                                cmbVillage.Text = dsGetExsiNIC.Tables[0].Rows[0]["center_name"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                cmbRoot.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["root_id"].ToString();
                                hidRoot.Value = dsGetExsiNIC.Tables[0].Rows[0]["root_id"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            txtInsDate.Text = dsGetExsiNIC.Tables[0].Rows[0]["inspection_date"].ToString();

                            txtNIC.Enabled = false;
                            lblMsg.Text = "This nic number is already used...!";
                            btnSubmit.Enabled = false;
                            btnSubmit.Visible = false;
                            btnUpdate.Visible = true;
                            string strloginID = Session["NIC"].ToString();
                            DataSet dsUserTy = cls_Connection.getDataSet("select user_type,module_name,company_code from users where nic = '" + strloginID + "';");
                            if (dsUserTy.Tables[0].Rows.Count > 0)
                            {
                                if (dsUserTy.Tables[0].Rows[0]["user_type"].ToString() == "Top Management" || dsUserTy.Tables[0].Rows[0]["user_type"].ToString() == "Admin")
                                {
                                    btnSubmit.Enabled = true;
                                    btnUpdate.Enabled = true;
                                }
                            }
                            if (hf3.Value != "")
                            {
                                btnSubmit.Visible = false;
                                btnUpdate.Visible = true;
                            }
                            else
                            {
                                btnSubmit.Visible = true;
                                btnUpdate.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        txtNIC.Enabled = true;
                        lblMsg.Text = "";
                        btnSubmit.Enabled = true;
                        btnSubmit.Visible = true;
                        btnUpdate.Visible = false;
                        if (hf3.Value != "")
                        {
                            btnSubmit.Visible = false;
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            btnSubmit.Visible = true;
                            btnUpdate.Visible = false;
                        }
                    }
                }
            }  
            catch (Exception e)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        protected void txtNIC_TextChanged(object sender, EventArgs e)
        {
            string strType = Session["UserType"].ToString();
            if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG" ||
                            strType == "FAO" || strType == "RMG" || strType == "RFA" || strType == "BMG" ||
                            strType == "BFA")
            {
                IsExist(); txtNicIssuDay.Focus();
            }
            else
            {
                ccsetup(); txtNicIssuDay.Focus();
            }
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            getArea();
        }

        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            getVillage();
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            socity();
        }

        protected void cmbCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsSubCenter = cls_Connection.getDataSet("SELECT * FROM center_details WHERE city_code = '"+cmbBranch.SelectedValue.ToString()+"' AND area_code = '"+cmbArea.SelectedValue.ToString()+"' and villages = '"+cmbVillage.SelectedValue.ToString()+"' and idcenter_details = '" + cmbCenter.SelectedValue.ToString() + "';");

            if (dsSubCenter.Tables[0].Rows.Count > 0)
            {
                txtSoNumber.Text = dsSubCenter.Tables[0].Rows[0]["idcenter_details"].ToString();
                strSoNumber = dsSubCenter.Tables[0].Rows[0]["idcenter_details"].ToString();
                txtSoNumber.Enabled = false;
                cmbRoot.Enabled = true;
                cmbRoot.SelectedValue = dsSubCenter.Tables[0].Rows[0]["exective"].ToString();
                hidRoot.Value = dsSubCenter.Tables[0].Rows[0]["exective"].ToString();
                cmbRoot.Enabled = false;
                ccsetup();
            }
        }

        protected void rdoYes_CheckedChanged(object sender, EventArgs e)
        {

            #region
            txtNameOrg1.Enabled = true;
            txtNameOrg2.Enabled = true;
            txtNameOrg3.Enabled = true;
            txtPurpos1.Enabled = true;
            txtPurpos2.Enabled = true;
            txtPurpos3.Enabled = true;
            txtFAmount1.Enabled = true;
            txtFAmount2.Enabled = true;
            txtFAmount3.Enabled = true;
            txtOutstandBal1.Enabled = true;
            txtOutstandBal2.Enabled = true;
            txtOutstandBal3.Enabled = true;
            txtMonthInstal1.Enabled = true;
            txtMonthInstal2.Enabled = true;
            txtMonthInstal3.Enabled = true;
            txtRemainInstal1.Enabled = true;
            txtRemainInstal2.Enabled = true;
            txtRemainInstal3.Enabled = true;
            #endregion
        }

        protected void rdoNo_CheckedChanged(object sender, EventArgs e)
        {

            #region
            txtNameOrg1.Enabled = false;
            txtNameOrg2.Enabled = false;
            txtNameOrg3.Enabled = false;
            txtPurpos1.Enabled = false;
            txtPurpos2.Enabled = false;
            txtPurpos3.Enabled = false;
            txtFAmount1.Enabled = false;
            txtFAmount2.Enabled = false;
            txtFAmount3.Enabled = false;
            txtOutstandBal1.Enabled = false;
            txtOutstandBal2.Enabled = false;
            txtOutstandBal3.Enabled = false;
            txtMonthInstal1.Enabled = false;
            txtMonthInstal2.Enabled = false;
            txtMonthInstal3.Enabled = false;
            txtRemainInstal1.Enabled = false;
            txtRemainInstal2.Enabled = false;
            txtRemainInstal3.Enabled = false;
            #endregion
        }     

        protected void cmbOccupation_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName1.Text = txtFullName.Text.Trim();
            txtNIC1.Text = txtNIC.Text.Trim();
            cmbRelation1.SelectedIndex = 1;
            txtDOB1.Text = txtDOB.Text.Trim();
            txtOcc1.Text = cmbOccupation.SelectedItem.Text.Trim();
            txtInsDate.Focus();
        }

        protected void cmbOccupa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName2.Text = txtSoName.Text.Trim();
            txtNIC2.Text = txtSoNIC.Text.Trim();
            cmbRelation2.SelectedValue = cmbRelation.SelectedValue;
            txtDOB2.Text = txtSoDOB.Text.Trim();
            txtOcc2.Text = cmbOccupa.SelectedItem.Text.Trim();
            cmbBNature.Focus();
        }
    }
}
