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
    public partial class Family_Details : System.Web.UI.Page
    {
        string strCC;
        string strCAC;
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBCon = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    strCC = Request.QueryString["CC"];
                    strCAC = Request.QueryString["CA"];
                    //strCC = "CO/CS/000004";
                    //strCAC = "CO/1/01/02";

                    if (strCC != null && strCAC != null)
                    {
                        txtCC.Text = strCC;
                        txtCACode.Text = strCAC;
                        txtCC.Enabled = false;
                    }
                    else
                    {
                        txtCC.Enabled = true;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Contract Code";
            }
            else if (txtCACode.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter CA Code";
            }
            else if (txtNIC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter NIC";
            }
            else if (cmbOccupa.Text.Trim() == "")
            {
                lblMsg.Text = "Please Choose Occupation";
            }
            else if (txtNoFMembers.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter No.Family Members";
            }
            else if (cmbEducation.Text.Trim() == "")
            {
                lblMsg.Text = "Please Choose Education";
            }
            else if (txtDepen.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Dependers";
            }
            else
            {

                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_family_details(contract_code,spouse_nic,spouse_name,occupation,no_of_fami_memb,education,dependers,spouse_income,other_fami_mem_income,moveable_property,immoveable_property,saving,create_user_nic,user_ip,date_time) VALUES(@contract_code,@spouse_nic,@spouse_name,@occupation,@no_of_fami_memb,@education,@dependers,@spouse_income,@other_fami_mem_income,@moveable_property,@immoveable_property,@saving,@create_user_nic,@user_ip,@date_time);");

                #region Values
                string strIp = Request.UserHostAddress;
                string strCCode = txtCC.Text.Trim();
                string strCACode = txtCACode.Text.Trim();
                string strloginID = Session["NIC"].ToString();
                string strNIC = txtNIC.Text.Trim();
                string strSPName = txtSoName.Text.Trim();
                string strOcc = cmbOccupa.SelectedValue;
                string strNFM = txtNoFMembers.Text.Trim();
                string strEdu = cmbEducation.SelectedValue;
                string strDep = txtDepen.Text.Trim();
                string  strSPIncome = txtSIncome.Text.Trim();
                string strOFMIncome = txtFMIncome.Text.Trim();
                string strMP = txtMProperty.Text.Trim();
                string strIMPro = txtIProperty.Text.Trim();
                string strsaving = txtSaving.Text.Trim();
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                #endregion

                #region Declare Parameters
                cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@spouse_nic", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@spouse_name", MySqlDbType.VarChar, 100);
                cmdInsert.Parameters.Add("@occupation", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@no_of_fami_memb", MySqlDbType.VarChar, 2);
                cmdInsert.Parameters.Add("@education", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@dependers", MySqlDbType.VarChar, 2);
                cmdInsert.Parameters.Add("@spouse_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@other_fami_mem_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@moveable_property", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@immoveable_property", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@saving", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                #endregion

                #region Assign Values
                cmdInsert.Parameters["@contract_code"].Value = strCCode;
                cmdInsert.Parameters["@spouse_nic"].Value = strNIC;
                cmdInsert.Parameters["@spouse_name"].Value = strSPName;
                cmdInsert.Parameters["@occupation"].Value = strOcc;
                cmdInsert.Parameters["@no_of_fami_memb"].Value = strNFM;
                cmdInsert.Parameters["@education"].Value = strEdu;
                cmdInsert.Parameters["@dependers"].Value = strDep;
                cmdInsert.Parameters["@spouse_income"].Value = strSPIncome;
                cmdInsert.Parameters["@other_fami_mem_income"].Value = strOFMIncome;
                cmdInsert.Parameters["@moveable_property"].Value = strMP;
                cmdInsert.Parameters["@immoveable_property"].Value = strIMPro;
                cmdInsert.Parameters["@saving"].Value = strsaving;
                cmdInsert.Parameters["@create_user_nic"].Value = strloginID;
                cmdInsert.Parameters["@user_ip"].Value = strIp;
                cmdInsert.Parameters["@date_time"].Value = strDateTime;
                #endregion

                try
                {
                    int i = objDBCon.insertEditData(cmdInsert);
                    if (i == 1)
                    {
                        //lblMsg.Text = "Success";
                        Response.Redirect("Business_Details.aspx?CC=" + strCCode + "&CA=" + strCACode + "");
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Contract Code";
            }
            else if (txtNIC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter NIC";
            }
            else if (cmbOccupa.Text.Trim() == "")
            {
                lblMsg.Text = "Please Choose Occupation";
            }
            else if (txtNoFMembers.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter No.Family Members";
            }
            else if (cmbEducation.Text.Trim() == "")
            {
                lblMsg.Text = "Please Choose Education";
            }
            else if (txtDepen.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Dependers";
            }
            else if (txtSIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Spouse Income";
            }
            else if (txtFMIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Other F. Member Income";
            }
            else
            {
                string strCCode = txtCC.Text.Trim();
                DataSet dsGetDetail = objDBCon.selectData("select * from micro_family_details where contract_code = '" + strCCode + "';");
                if (dsGetDetail.Tables[0].Rows.Count > 0)
                {
                    Update();

                }
                else
                {
                    DataSet dsGetBasicDetail = objDBCon.selectData("select * from micro_basic_detail where contract_code = '" + strCCode + "';");
                    if (dsGetBasicDetail.Tables[0].Rows.Count > 0)
                    {
                        Update();
                    }
                    else
                    {
                        btnSubmit.Enabled = false;
                        btnUpdate.Enabled = false;
                        lblMsg.Text = "Invalid Contract Code.";
                    }
                }
            }
        }

        protected void Update()
        {
            #region Values
            string strIp = Request.UserHostAddress;
            string strCCode = txtCC.Text.Trim();
            string strCACode = txtCACode.Text.Trim();
            string strloginID = Session["NIC"].ToString();
            string strNIC = txtNIC.Text.Trim();
            string strSPName = txtSoName.Text.Trim();
            string strOcc = cmbOccupa.SelectedValue;
            string strNFM = txtNoFMembers.Text.Trim();
            string strEdu = cmbEducation.SelectedValue;
            string strDep = txtDepen.Text.Trim();
            string strSPIncome = txtSIncome.Text.Trim();
            string strOFMIncome = txtFMIncome.Text.Trim();
            string strMP = txtMProperty.Text.Trim();
            string strIMPro = txtIProperty.Text.Trim();
            string strsaving = txtSaving.Text.Trim();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE micro_family_details SET spouse_nic = '" + strNIC + "',spouse_name = '" + strSPName + "',occupation = '" + strOcc + "',no_of_fami_memb = '" + strNFM + "',education = '" + strEdu + "',dependers = '" + strDep + "',spouse_income = '" + strSPIncome + "',other_fami_mem_income = '" + strOFMIncome + "',moveable_property = '" + strMP + "',immoveable_property = '" + strIMPro + "',saving = '" + strsaving + "',create_user_nic = '" + strloginID + "',user_ip = '" + strIp + "',date_time = '" + strDateTime + "' WHERE contract_code = '" + strCCode + "';");

            try
            {
                int i;
                i = objDBCon.insertEditData(cmdUpdateQRY);

                Clear();
                lblMsg.Text = "Update Success.";

                

                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        protected void Clear()
        {
            txtCACode.Text = "";
            txtCC.Text = "";
            txtDepen.Text = "";
            txtFMIncome.Text = "";
            txtIProperty.Text = "";
            txtMProperty.Text = "";
            txtNIC.Text = "";
            txtNoFMembers.Text = "";
            txtSaving.Text = "";
            txtSIncome.Text = "";
            txtSoName.Text = "";
            cmbEducation.SelectedIndex = 0;
            cmbOccupa.SelectedIndex = 0;
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Contract Code";
            }
            else
            {
                string strCCode = txtCC.Text.Trim();
                DataSet dsGetDetail = objDBCon.selectData("select * from micro_family_details where contract_code = '" + strCCode + "';");
                if (dsGetDetail.Tables[0].Rows.Count > 0)
                {
                    btnSubmit.Enabled = false;
                    btnUpdate.Enabled = true;


                }
                else
                {
                    DataSet dsGetBasicDetail = objDBCon.selectData("select * from micro_basic_detail where contract_code = '" + strCCode + "';");
                    if (dsGetBasicDetail.Tables[0].Rows.Count > 0)
                    {
                        btnSubmit.Enabled = true;
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        btnSubmit.Enabled = false;
                        btnUpdate.Enabled = false;
                        lblMsg.Text = "Invalid Contract Code.";
                    }
                }
            }
        }
    }
}
