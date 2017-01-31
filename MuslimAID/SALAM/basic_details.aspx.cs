
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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace MuslimAID.SALAM
{
    public partial class basic_details : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();
        DataSet dtCCode;
        string strTeamNo, strClientID, strPromiserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LoggedIn"].ToString() == "True")
                    {
                        DataSet dsBranch = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");
                        //MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                        //dsBranch = objDBTask.selectData(cmdBranch);
                        cmbCityCode.Items.Add("");
                        for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                        {
                            cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                            cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                        }

                        DataSet dsProvince = cls_Connection.getDataSet("SELECT * FROM Province ORDER BY 2");
                        //MySqlCommand cmdProvince = new MySqlCommand("SELECT * FROM Province ORDER BY 2");
                        //dsProvince = objDBTask.selectData(cmdProvince);
                        for (int i = 0; i < dsProvince.Tables[0].Rows.Count; i++)
                        {
                            cmbProvince.Items.Add(dsProvince.Tables[0].Rows[i][2].ToString());
                            cmbProvince.Items[i].Value = dsProvince.Tables[0].Rows[i][1].ToString();
                        }

                        if (!this.IsPostBack)
                        {

                        }
                        cmbProvince.SelectedValue = "WP";
                    }
                    else
                    {
                        Response.Redirect("../salam.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void txtNIC_TextChanged(object sender, EventArgs e)
        {
            IsExist();
        }

        private void IsExist()
        {
            try
            {
                lblMsg.Text = "";
                //lblMsg0.Text = "";
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
                            lblMsg.Text = "Please enter valid NIC No.";
                            txtNIC.Focus();
                            return;
                        }
                    }
                    else if (txtNIC.Text.Length == 12)
                    {
                        if (IsValidNewNIC(txtNIC.Text) == false)
                        {
                            lblMsg.Text = "Please enter valid NIC No.";
                            txtNIC.Focus();
                            return;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Please enter valid NIC No.";
                        txtNIC.Focus();
                        return;
                    }
                    lblMsg.Text = "";
                    DataSet dsGetExsiNIC = cls_Connection.getDataSet("select * from salam_basic_detail where nic = '" + txtNIC.Text.Trim() + "';");
                    if (dsGetExsiNIC.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsGetExsiLoan = cls_Connection.getDataSet("select * from salam_loan_details where contra_code = '" + dsGetExsiNIC.Tables[0].Rows[0]["contract_code"].ToString() + "';");

                        if (dsGetExsiLoan.Tables[0].Rows[0]["loan_sta"].ToString() == "S" || dsGetExsiLoan.Tables[0].Rows[0]["loan_sta"].ToString() == "C")
                        {
                            return;
                        }
                        else if (dsGetExsiLoan.Tables[0].Rows[0]["loan_sta"].ToString() == "P" && dsGetExsiLoan.Tables[0].Rows[0]["loan_approved"].ToString() == "Y" && dsGetExsiLoan.Tables[0].Rows[0]["chequ_no"].ToString() == "")
                        {
                            hf3.Value = dsGetExsiNIC.Tables[0].Rows[0]["idmicro_basic_detail"].ToString();
                            cmbCityCode.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["city_code"].ToString();
                            City();
                            try
                            {
                                cmbVillages.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["village"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            Villege();
                            txtSoNumber.Text = dsGetExsiNIC.Tables[0].Rows[0]["society_id"].ToString();
                            try
                            {
                                cmbProvince.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["province"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            txtGSWard.Text = dsGetExsiNIC.Tables[0].Rows[0]["gs_ward"].ToString();
                            txtFullName.Text = dsGetExsiNIC.Tables[0].Rows[0]["full_name"].ToString();
                            txtInwName.Text = dsGetExsiNIC.Tables[0].Rows[0]["initial_name"].ToString();
                            txtOtherName.Text = dsGetExsiNIC.Tables[0].Rows[0]["other_name"].ToString();
                            rdoMale.Checked = dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0" ? true : false;
                            rdoFeMale.Checked = dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0" ? true : false;
                            //rdoMarried.Checked = dsGetExsiNIC.Tables[0].Rows[0]["marital_status"].ToString() == "M" ? true : false;
                            //rdoSingle.Checked = dsGetExsiNIC.Tables[0].Rows[0]["marital_status"].ToString() != "M" ? true : false;
                            cmbEducation.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["education"].ToString();
                            txtTele.Text = dsGetExsiNIC.Tables[0].Rows[0]["land_no"].ToString();
                            txtMobileNo.Text = dsGetExsiNIC.Tables[0].Rows[0]["mobile_no"].ToString();
                            txtAddress.Text = dsGetExsiNIC.Tables[0].Rows[0]["p_address"].ToString();
                            //txtGroupID.Text = dsGetExsiNIC.Tables[0].Rows[0]["team_id"].ToString();
                            try
                            {
                                cmbSocietyName.Text = dsGetExsiNIC.Tables[0].Rows[0]["center_name"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                cmbRoot.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["root_id"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            //txtPromiserID1.Text = dsGetExsiNIC.Tables[0].Rows[0]["promisers_id"].ToString();
                            //txtPromiser02.Text = dsGetExsiNIC.Tables[0].Rows[0]["promiser_id_2"].ToString();
                            //txtCACode1.Text = dsGetExsiNIC.Tables[0].Rows[0]["ca_code"].ToString();
                            txtInsDate.Text = dsGetExsiNIC.Tables[0].Rows[0]["inspection_date"].ToString();

                            fpPhoto.Enabled = false;
                            fpBBPhoto.Enabled = false;
                            lblMsg.Text = "";
                            btnSubmit.Enabled = false;
                            btnSubmit.Visible = false;
                            //btnUpdate.Visible = true;
                            string strloginID = Session["NIC"].ToString();
                            DataSet dsUserTy = cls_Connection.getDataSet("select user_type,module_name,company_code from users where nic = '" + strloginID + "';");
                            if (dsUserTy.Tables[0].Rows.Count > 0)
                            {
                                if (dsUserTy.Tables[0].Rows[0]["user_type"].ToString() == "Top Managment" || dsUserTy.Tables[0].Rows[0]["user_type"].ToString() == "Admin")
                                {
                                    btnSubmit.Enabled = true;
                                    //btnUpdate.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            hf3.Value = dsGetExsiNIC.Tables[0].Rows[0]["idmicro_basic_detail"].ToString();
                            cmbCityCode.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["city_code"].ToString();
                            City();
                            try
                            {
                                cmbVillages.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["village"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            Villege();
                            txtSoNumber.Text = dsGetExsiNIC.Tables[0].Rows[0]["society_id"].ToString();
                            try
                            {
                                cmbProvince.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["province"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            txtGSWard.Text = dsGetExsiNIC.Tables[0].Rows[0]["gs_ward"].ToString();
                            txtFullName.Text = dsGetExsiNIC.Tables[0].Rows[0]["full_name"].ToString();
                            txtInwName.Text = dsGetExsiNIC.Tables[0].Rows[0]["initial_name"].ToString();
                            txtOtherName.Text = dsGetExsiNIC.Tables[0].Rows[0]["other_name"].ToString();
                            rdoMale.Checked = dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0" ? true : false;
                            rdoFeMale.Checked = dsGetExsiNIC.Tables[0].Rows[0]["gender"].ToString() == "0" ? true : false;
                            //rdoMarried.Checked = dsGetExsiNIC.Tables[0].Rows[0]["marital_status"].ToString() == "M" ? true : false;
                            //rdoSingle.Checked = dsGetExsiNIC.Tables[0].Rows[0]["marital_status"].ToString() != "M" ? true : false;
                            cmbEducation.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["education"].ToString();
                            txtTele.Text = dsGetExsiNIC.Tables[0].Rows[0]["land_no"].ToString();
                            txtMobileNo.Text = dsGetExsiNIC.Tables[0].Rows[0]["mobile_no"].ToString();
                            txtAddress.Text = dsGetExsiNIC.Tables[0].Rows[0]["p_address"].ToString();
                            //txtGroupID.Text = dsGetExsiNIC.Tables[0].Rows[0]["team_id"].ToString();
                            try
                            {
                                cmbSocietyName.Text = dsGetExsiNIC.Tables[0].Rows[0]["center_name"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                cmbRoot.SelectedValue = dsGetExsiNIC.Tables[0].Rows[0]["root_id"].ToString();
                            }
                            catch (Exception)
                            {
                            }
                            //txtPromiserID1.Text = dsGetExsiNIC.Tables[0].Rows[0]["promisers_id"].ToString();
                            //txtPromiser02.Text = dsGetExsiNIC.Tables[0].Rows[0]["promiser_id_2"].ToString();
                            //txtCACode1.Text = dsGetExsiNIC.Tables[0].Rows[0]["ca_code"].ToString();
                            txtInsDate.Text = dsGetExsiNIC.Tables[0].Rows[0]["inspection_date"].ToString();

                            txtNIC.Enabled = false;
                            fpPhoto.Enabled = false;
                            fpBBPhoto.Enabled = false;
                            lblMsg.Text = "This nic number is already used...!";
                            btnSubmit.Enabled = false;
                            btnSubmit.Visible = false;
                            //btnUpdate.Visible = true;
                            string strloginID = Session["NIC"].ToString();
                            DataSet dsUserTy = cls_Connection.getDataSet("select user_type,module_name,company_code from users where nic = '" + strloginID + "';");
                            if (dsUserTy.Tables[0].Rows.Count > 0)
                            {
                                if (dsUserTy.Tables[0].Rows[0]["user_type"].ToString() == "Top Managment" || dsUserTy.Tables[0].Rows[0]["user_type"].ToString() == "Admin")
                                {
                                    btnSubmit.Enabled = true;
                                    //btnUpdate.Enabled = true;
                                }
                            }
                            if (hf3.Value != "")
                            {
                                btnSubmit.Visible = false;
                                //btnUpdate.Visible = true;
                            }
                            else
                            {
                                btnSubmit.Visible = true;
                                //btnUpdate.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        txtNIC.Enabled = true;
                        fpPhoto.Enabled = true;
                        fpBBPhoto.Enabled = true;
                        lblMsg.Text = "";
                        btnSubmit.Enabled = true;
                        btnSubmit.Visible = true;
                        //btnUpdate.Visible = false;
                        if (hf3.Value != "")
                        {
                            btnSubmit.Visible = false;
                            //btnUpdate.Visible = true;
                        }
                        else
                        {
                            btnSubmit.Visible = true;
                            //btnUpdate.Visible = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
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

        protected void ccsetup()
        {
            try
            {
                if (cmbCityCode.SelectedIndex != 0)
                {
                    string strcitycode = cmbCityCode.SelectedValue.ToString();
                    string strconCode;

                    dtCCode = cls_Connection.getDataSet("select max(idmicro_basic_detail) from salam_basic_detail");
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
                        strconCode = strcitycode + "/MB/" + strVal;
                        hidCC.Value = strconCode;
                        //btnSubmit.Enabled = true;
                        //cmbCityCode.Enabled = false;
                    }
                    else
                    {
                        //txtID.Text = "0001";
                        strconCode = strcitycode + "/MB/" + "000001";
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
            catch (Exception)
            {
            }
        }

        private void City()
        {
            txtSoNumber.Text = "";
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

                try
                {
                    DataSet dsVillage = cls_Connection.getDataSet("select * from villages_name where city_code = '" + cmbCityCode.SelectedItem.Value + "'");
                    if (dsVillage.Tables[0].Rows.Count > 0)
                    {
                        cmbVillages.Items.Add("");
                        btnSubmit.Enabled = true;

                        for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                        {
                            cmbVillages.Items.Add(dsVillage.Tables[0].Rows[i][2].ToString());
                        }
                    }
                    else
                    {
                        lblMsg.Text = "No record found...! Please chose other city code.";
                        btnSubmit.Enabled = false;
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    string strBranch = cmbCityCode.SelectedItem.Value;

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
                }
                catch (Exception)
                {

                }
            }
            else
            {
                lblMsg.Text = "Please chose city code.";
                btnSubmit.Enabled = false;
            }
        }

        private void socity()
        {
            try
            {
                txtSoNumber.Text = "";
                lblMsg.Text = "";
                if (cmbSocietyName.SelectedIndex != 0 && cmbCityCode.SelectedIndex != 0 && cmbVillages.SelectedIndex != 0)
                {
                    DataSet dsGetSocietyID = cls_Connection.getDataSet("select idcenter_details, exective from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "' and center_name = '" + cmbSocietyName.SelectedItem.Value + "' and villages = '" + cmbVillages.SelectedItem.Value + "';");
                    if (dsGetSocietyID.Tables[0].Rows.Count > 0)
                    {
                        txtSoNumber.Text = dsGetSocietyID.Tables[0].Rows[0]["idcenter_details"].ToString();
                        //Edit 2014.09.18 CACode
                        //CACodeNew();
                        cmbRoot.SelectedValue = dsGetSocietyID.Tables[0].Rows[0]["exective"].ToString();
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
            catch (Exception)
            {
            }
        }

        private void Villege()
        {
            try
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

                    DataSet dsSocietyName = cls_Connection.getDataSet("select center_name from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "' and villages = '" + cmbVillages.SelectedItem.Value + "';");
                    //MySqlCommand cmdSocietyName = new MySqlCommand("select center_name from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "' and villages = '" + cmbVillages.SelectedItem.Value + "';");
                    //dsSocietyName = objDBTask.selectData(cmdSocietyName);
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
            catch (Exception)
            {
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
                else if (!fpPhoto.HasFile)
                {
                    lblMsg.Text = "Please upload Client Photo";
                }
                else if (txtNicIssuDay.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter the NIC issued date.";
                }
                else if (cmbCityCode.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select city code.";
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
                    //CO/MF/000001/1
                    string NIC = txtNIC.Text.Trim();
                    DataSet dtCount = cls_Connection.getDataSet("select count(b.nic) + 1 AS Count from salam_basic_detail b inner join salam_loan_details l on b.contract_code = l.contra_code where nic = '" + NIC + "' and l.loan_approved = 'Y' and l.loan_sta != 'C' and chequ_no != null;");
                    if (dtCount.Tables[0].Rows[0][0].ToString() != "")
                    {
                        hidCC.Value = hidCC.Value + "/" + dtCount.Tables[0].Rows[0][0].ToString();
                    }

                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO salam_basic_detail(contract_code,ca_code,nic,city_code,society_id,province,gs_ward,full_name,initial_name,other_name,marital_status,education,land_no,mobile_no,p_address,client_id,inspection_date,create_user_id,user_ip,date_time,village,root_id,cli_photo,bb_photo,nic_issue_date,dob,gender,r_address,income_source)VALUES(@contract_code,@ca_code,@nic,@city_code,@society_id,@province,@gs_ward,@full_name,@initial_name,@other_name,@marital_status,@education,@land_no,@mobile_no,@p_address,@client_id,@inspection_date,@create_user_id,@user_ip,@date_time,@village,@root_id,@cli_photo,@bb_photo,@nic_issue_date,@dob,@gender,@r_address,@income_source)");

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

                    string strServerClientPhotoPath, strServerClientProductPath;
                    string strPostedFileName;
                    string strImageType;
                    //string strLastID = hifRefID.Value;
                    //string strNIC = Session["NICNo"].ToString();
                    string strNewFileName;

                    strServerClientPhotoPath = Server.MapPath(".") + "\\salam_client_photo";
                    strServerClientProductPath = Server.MapPath(".") + "\\salam_client_product";

                    if (fpPhoto.HasFile)
                    {
                        strPostedFileName = fpPhoto.PostedFile.FileName;
                        strImageType = strPostedFileName.Substring(strPostedFileName.LastIndexOf("."));
                        strNewFileName = strNewImaID + "-1" + strImageType;
                        fpPhoto.PostedFile.SaveAs(strServerClientPhotoPath + "\\" + strNewFileName);
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
                        fpBBPhoto.PostedFile.SaveAs(strServerClientProductPath + "\\" + strNewFileName);
                        hf2.Value = "cs_client_ph" + "\\" + strNewFileName;
                    }
                    else
                    {
                        hf2.Value = "";
                    }

                    string strNIC, strGroupID, strCityCode, strVillage, strSoName, strSoNumber, strProvince, strGSWard, strFullName, strGName, strIniName, strOName, strMaStatus;
                    string strEducation, strTNumber, strMobNo, strAddress, strCACode, strInspDate, strDateTime, strRootID, strPromiser2;
                    string strDOB, strGender, strRAddress, strOccupation, strNICIssuedDate;
                    strNIC = txtNIC.Text.Trim();
                    strNICIssuedDate = txtNicIssuDay.Text.Trim();
                    strCityCode = cmbCityCode.SelectedItem.Value; //This is the branch code
                    strVillage = cmbVillages.SelectedItem.Value;
                    strSoName = cmbSocietyName.SelectedItem.Value;
                    strSoNumber = txtSoNumber.Text.Trim();
                    strProvince = cmbProvince.SelectedItem.Value;
                    strGSWard = txtGSWard.Text.Trim();
                    strFullName = txtFullName.Text.Trim();
                    strGName = txtGivenName.Text.Trim();
                    strIniName = txtInwName.Text.Trim();
                    strOName = txtOtherName.Text.Trim();
                    strDOB = txtDOB.Text.Trim();
                    if (rdoMale.Checked)
                        strGender = "1";
                    else strGender = "0";
                    strMaStatus = cmbMS.SelectedItem.Value;
                    strRootID = cmbRoot.SelectedItem.Value;
                    strEducation = cmbEducation.SelectedItem.Value;
                    strTNumber = txtTele.Text.Trim();
                    strMobNo = txtMobileNo.Text.Trim();
                    strAddress = txtAddress.Text.Trim();
                    //strRAddress = txtResiAddress.Text.Trim();
                    strOccupation = txtOccupation.Text.Trim();
                    strInspDate = txtInsDate.Text.Trim();
                    strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion

                    //Create Capital Applicant Code
                    //CACodeNew();
                    string strCACodeNew = "";
                    DataSet dsGetMaxCliID = cls_Connection.getDataSet("select ifnull(max(CAST(client_id as SIGNED)),0) from salam_basic_detail where city_code = '" + strCityCode + "' and society_id = '" + strSoNumber + "';");
                    if (dsGetMaxCliID.Tables[0].Rows[0][0].ToString() != "")
                    {
                        string strMaxID = dsGetMaxCliID.Tables[0].Rows[0][0].ToString();
                        int intMaxID = Convert.ToInt32(strMaxID);
                        int intNewID = intMaxID + 1;
                        strClientID = Convert.ToString(intNewID);
                        strCACodeNew = strCityCode + "/" + strSoNumber + "/" + strClientID;
                    }

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
                    //cmdInsert.Parameters.Add("@team_id", MySqlDbType.VarChar, 2);
                    cmdInsert.Parameters.Add("@client_id", MySqlDbType.VarChar, 2);
                    cmdInsert.Parameters.Add("@inspection_date", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@create_user_id", MySqlDbType.VarChar, 10);
                    cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                    //cmdInsert.Parameters.Add("@promisers_id", MySqlDbType.VarChar, 12);
                    cmdInsert.Parameters.Add("@village", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@root_id", MySqlDbType.VarChar, 1);
                    cmdInsert.Parameters.Add("@cli_photo", MySqlDbType.VarChar, 200);
                    cmdInsert.Parameters.Add("@bb_photo", MySqlDbType.VarChar, 200);
                    cmdInsert.Parameters.Add("@nic_issue_date", MySqlDbType.VarChar, 10);
                    cmdInsert.Parameters.Add("@dob", MySqlDbType.VarChar, 10);
                    cmdInsert.Parameters.Add("@gender", MySqlDbType.VarChar, 1);
                    cmdInsert.Parameters.Add("@r_address", MySqlDbType.VarChar, 255);
                    cmdInsert.Parameters.Add("@income_source", MySqlDbType.VarChar, 100);
                    //cmdInsert.Parameters.Add("@promiser_id_2", MySqlDbType.VarChar, 12);
                    #endregion

                    #region AssignParameters
                    cmdInsert.Parameters["@contract_code"].Value = strCC;
                    cmdInsert.Parameters["@ca_code"].Value = strCACodeNew;
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
                    //cmdInsert.Parameters["@team_id"].Value = strTeamNo;
                    cmdInsert.Parameters["@client_id"].Value = strClientID;
                    cmdInsert.Parameters["@inspection_date"].Value = strInspDate;
                    cmdInsert.Parameters["@create_user_id"].Value = strloginID;
                    cmdInsert.Parameters["@user_ip"].Value = strIp;
                    cmdInsert.Parameters["@date_time"].Value = strDateTime;
                    //cmdInsert.Parameters["@promisers_id"].Value = strPromiserID;
                    cmdInsert.Parameters["@village"].Value = strVillage;
                    cmdInsert.Parameters["@root_id"].Value = strRootID;
                    cmdInsert.Parameters["@cli_photo"].Value = hf1.Value;
                    cmdInsert.Parameters["@bb_photo"].Value = hf2.Value;

                    cmdInsert.Parameters["@nic_issue_date"].Value = strNICIssuedDate;
                    cmdInsert.Parameters["@dob"].Value = strDOB;
                    cmdInsert.Parameters["@gender"].Value = strGender;
                    //cmdInsert.Parameters["@r_address"].Value = strRAddress;
                    cmdInsert.Parameters["@income_source"].Value = strOccupation;
                    //cmdInsert.Parameters["@promiser_id_2"].Value = strPromiser2;
                    #endregion

                    try
                    {
                        int i = objDBCon.insertEditData(cmdInsert);
                        if (i == 1)
                        {
                            Response.Redirect("business_details.aspx.aspx?CC=" + strCC + "&CA=" + strCACodeNew + "");
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
            catch (Exception x)
            {
                lblMsg.Text = x.ToString();
            }
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            City();
        }

        protected void cmbRoot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbVillages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Villege();
        }

        protected void cmbSocietyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            socity();
        }

    }
}
