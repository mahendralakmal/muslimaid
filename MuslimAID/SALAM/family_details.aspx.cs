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
using System.Text.RegularExpressions;
using System.Text;

namespace MuslimAID.SALAM
{
    public partial class family_details : System.Web.UI.Page
    {
        string strCC;
        string strCAC;
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
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
                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_family_details(contract_code,spouse_nic,spouse_nic_issued_date,spouse_name,occupation,education,spouse_income,other_fami_mem_income,spouse_dob,spouse_gender,spouse_contact_no,spouse_relationship_with_applicant,no_of_fami_memb,dependers,moveable_property,immoveable_property,saving,create_user_nic,user_ip,date_time) VALUES(@contract_code, @spouse_nic, @spouse_nic_issued_date, @spouse_name, @occupation, @education, @spouse_income, @other_fami_mem_income, @spouse_dob, @spouse_gender, @spouse_contact_no, @spouse_relationship_with_applicant, @no_of_fami_memb, @dependers, @moveable_property, @immoveable_property, @saving, @create_user_nic, @user_ip, @date_time);");

                    #region Values
                    string strIp = Request.UserHostAddress;
                    string strCCode = txtCC.Text.Trim();
                    string strCACode = txtCACode.Text.Trim();
                    string strloginID = Session["NIC"].ToString();
                    string strNIC = txtNIC.Text.Trim();
                    string strNICissueDate = txtNicIssuedDate.Text.Trim();
                    string strSDob = txtDOB.Text.Trim();
                    string strSGender;
                    if(rdoMale.Checked)
                        strSGender = "0";
                    else 
                        strSGender = "1";
                    string strName = txtSoName.Text.Trim();
                    string strSContact = txtContact.Text.Trim();
                    string strRelation = txtRelation.Text.Trim();
                    string strSPIncome = txtSIncome.Text.Trim();
                    string strOcc = cmbOccupa.SelectedValue;
                    string strNFM = txtNoFMembers.Text.Trim();
                    string strEdu = cmbEducation.SelectedValue;
                    string strDep = txtDepen.Text.Trim();
                    string strOFMIncome = txtFMIncome.Text.Trim();
                    string strMP = txtMProperty.Text.Trim();
                    string strIMPro = txtIProperty.Text.Trim();
                    string strsaving = txtSaving.Text.Trim();
                    string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion

                    #region Declare Parameters
                    cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                    cmdInsert.Parameters.Add("@spouse_nic", MySqlDbType.VarChar, 12);
                    cmdInsert.Parameters.Add("@spouse_nic_issued_date", MySqlDbType.VarChar, 10);
                    cmdInsert.Parameters.Add("@spouse_name", MySqlDbType.VarChar, 100);
                    cmdInsert.Parameters.Add("@spouse_dob", MySqlDbType.VarChar, 10);
                    cmdInsert.Parameters.Add("@spouse_gender", MySqlDbType.VarChar, 1);
                    cmdInsert.Parameters.Add("@spouse_contact_no", MySqlDbType.VarChar, 15);
                    cmdInsert.Parameters.Add("@spouse_relationship_with_applicant", MySqlDbType.VarChar, 45);
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
                    cmdInsert.Parameters["@spouse_nic_issued_date"].Value = strNICissueDate;
                    cmdInsert.Parameters["@spouse_name"].Value = strName;
                    cmdInsert.Parameters["@spouse_dob"].Value = strSDob;
                    cmdInsert.Parameters["@spouse_gender"].Value = strSGender;
                    cmdInsert.Parameters["@spouse_contact_no"].Value = strSContact;
                    cmdInsert.Parameters["@spouse_relationship_with_applicant"].Value = strRelation;
                    cmdInsert.Parameters["@occupation"].Value = strOcc;
                    cmdInsert.Parameters["@no_of_fami_memb"].Value = strNFM;
                    cmdInsert.Parameters["@education"].Value = strEdu;
                    cmdInsert.Parameters["@dependers"].Value = strDep;
                    cmdInsert.Parameters["@spouse_income"].Value = strSPIncome == "" ? 0 : Convert.ToDecimal(strSPIncome);
                    cmdInsert.Parameters["@other_fami_mem_income"].Value = strOFMIncome == "" ? 0 : Convert.ToDecimal(strOFMIncome);
                    cmdInsert.Parameters["@moveable_property"].Value = strMP == "" ? 0 : Convert.ToDecimal(strMP);
                    cmdInsert.Parameters["@immoveable_property"].Value = strIMPro == "" ? 0 : Convert.ToDecimal(strIMPro);
                    cmdInsert.Parameters["@saving"].Value = strsaving == "" ? 0 : Convert.ToDecimal(strsaving);
                    cmdInsert.Parameters["@create_user_nic"].Value = strloginID;
                    cmdInsert.Parameters["@user_ip"].Value = strIp;
                    cmdInsert.Parameters["@date_time"].Value = strDateTime;
                    #endregion

                    StringBuilder strRelat = new StringBuilder();
                    //string strName1, strName2, strName3, strName4, strName5, strName6, strName7, strName8, strName9, strName10;
                    //string strRelAp1, strRelAp2, strRelAp3, strRelAp4, strRelAp5, strRelAp6, strRelAp7, strRelAp8, strRelAp9, strRelAp10;
                    //string strAge1, strAge2, strAge3, strAge4, strAge5, strAge6, strAge7, strAge8, strAge9, strAge10;
                    //string strOcc1, strOcc2, strOcc3, strOcc4, strOcc5, strOcc6, strOcc7, strOcc8, strOcc9, strOcc10;
                    //string strIncom1, strIncom2, strIncom3, strIncom4, strIncom5, strIncom6, strIncom7, strIncom8, strIncom9, strIncom10;
                    strRelat.Append("INSERT INTO family_relationship_details (contract_code,name, relationship, age, occupation, income,create_user_nic,user_ip,date_time) VALUES ");
                    if (txtName1.Text.Trim() != "")
                        strRelat.Append("('" + strCCode +"','"+ txtName1.Text.Trim() + "','" + txtRelation1.Text.Trim() + "'," + txtAge1.Text.Trim() + ",'" + txtOcc1.Text.Trim() + "'," + txtInCome1.Text.Trim() + ",'"+strloginID +"','"+ strIp+"','"+ strDateTime);
                    if (txtName2.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName2.Text.Trim() + "','" + txtRelation2.Text.Trim() + "'," + txtAge2.Text.Trim() + ",'" + txtOcc2.Text.Trim() + "'," + txtInCome2.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);
                    if (txtName3.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName3.Text.Trim() + "','" + txtRelation3.Text.Trim() + "'," + txtAge3.Text.Trim() + ",'" + txtOcc3.Text.Trim() + "'," + txtInCome3.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);
                    if (txtName4.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName4.Text.Trim() + "','" + txtRelation4.Text.Trim() + "'," + txtAge4.Text.Trim() + ",'" + txtOcc4.Text.Trim() + "'," + txtInCome4.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);
                    if (txtName5.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName5.Text.Trim() + "','" + txtRelation5.Text.Trim() + "'," + txtAge5.Text.Trim() + ",'" + txtOcc5.Text.Trim() + "'," + txtInCome5.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);
                    if (txtName6.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName6.Text.Trim() + "','" + txtRelation6.Text.Trim() + "'," + txtAge6.Text.Trim() + ",'" + txtOcc6.Text.Trim() + "'," + txtInCome6.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);
                    if (txtName7.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName7.Text.Trim() + "','" + txtRelation7.Text.Trim() + "'," + txtAge7.Text.Trim() + ",'" + txtOcc7.Text.Trim() + "'," + txtInCome7.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);
                    if (txtName8.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName8.Text.Trim() + "','" + txtRelation8.Text.Trim() + "'," + txtAge8.Text.Trim() + ",'" + txtOcc8.Text.Trim() + "'," + txtInCome8.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);
                    if (txtName9.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName9.Text.Trim() + "','" + txtRelation9.Text.Trim() + "'," + txtAge9.Text.Trim() + ",'" + txtOcc9.Text.Trim() + "'," + txtInCome9.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);
                    if (txtName4.Text.Trim() != "")
                        strRelat.Append("'),('" + strCCode + "','" + txtName10.Text.Trim() + "','" + txtRelation10.Text.Trim() + "'," + txtAge10.Text.Trim() + ",'" + txtOcc10.Text.Trim() + "'," + txtInCome10.Text.Trim() + ",'" + strloginID + "','" + strIp + "','" + strDateTime);


                    strRelat.Append("');");

                    try
                    {
                        int i = objDBCon.insertEditData(cmdInsert);

                        int a = objDBCon.insertEditData(strRelat.ToString());
                        if (i == 1 && a > 0)
                        {
                            //lblMsg.Text = "Success";
                            Response.Redirect("family_appraisal.aspx?CC=" + strCCode + "&CA=" + strCACode);
                            //Response.Redirect("Business_Details.aspx?CC=" + strCCode + "&CA=" + strCACode + "");
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
            catch (Exception)
            {
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
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
                    DataSet dsGetDetail = cls_Connection.getDataSet("select * from micro_family_details where contract_code = '" + strCCode + "';");
                    if (dsGetDetail.Tables[0].Rows.Count > 0)
                    {
                        Update();

                    }
                    else
                    {
                        DataSet dsGetBasicDetail = cls_Connection.getDataSet("select * from micro_basic_detail where contract_code = '" + strCCode + "';");
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
            catch (Exception)
            {
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
                txtCC.Enabled = true;
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

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
