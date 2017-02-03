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

namespace MuslimAID
{
    public partial class User_Create : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        DataSet dtNIC = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strloginID = Session["NIC"].ToString();

                DataSet dsUserTy = cls_Connection.getDataSet("select user_type from users where nic = '" + strloginID + "';");
                if (dsUserTy.Tables[0].Rows.Count > 0)
                {
                    string strType = dsUserTy.Tables[0].Rows[0]["user_type"].ToString();
                    if (strType == "Top Managment" || strType == "Manager")
                    {
                        
                    }
                    else
                    {
                        Response.Redirect("muslimaid.aspx");
                    }

                }
                else
                {
                    Response.Redirect("muslimaid.aspx");
                }
            }
            else
            {
                Response.Redirect("muslimaid.aspx");
            }
        }

        protected void Reset()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
            txtDesignation.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDateOfBirth.Text = "";
            txtAddress.Text = "";
            cmbTitle.SelectedIndex = 0;
            cmbUserType.SelectedIndex = 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your NIC.";
            }
            else if (txtPassword.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your Password.";
            }
            else if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                lblMsg.Text = "Password didn't Match.";
            }
            else if (txtConfirmPass.Text.Trim() == "")
            {
                lblMsg.Text = "Please Re Enter your Password";
            }
            else if (txtFirstName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your First name";
            }
            else if (txtLastName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your Last name";
            }
            else if (txtAddress.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Address.";
            }
            else if (txtDateOfBirth.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Date Of Birth.";
            }
            else if (!fuPhoto.HasFile)
            {
                lblMsg.Text = "Please Add User Photo.";
            }
            else if (txtDesignation.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your Designation";
            }
            else
            {
                MySqlCommand cmdInsertQRY = new MySqlCommand("insert into users(nic,user_password,first_name,last_name,user_type,designation,deleted,current_status,created_on,last_accessed_on,last_accessed_ip,created_user_nic,photo_path,user_address,date_of_birth,user_title) values(@NIC,@PASS,@FNAME,@LNAME,@UTYPE,@DESIG,@DEL,@CSTAT,@CREATEON,@LACCESS,@LASTIP,@CREATEDUNIC,@photo_path,@user_address,@date_of_birth,@user_title)");

                string strDel, strCStat, strPassw;
                strDel = "N";
                strCStat = "D";

                //Encrypt Password
                strPassw = EncodePasswordToBase64(txtPassword.Text.Trim());

                string strCid, strIp;
                #region Get Values
                //strCid = Session["CId"].ToString();
                strIp = Request.UserHostAddress;
                string strloginID = Session["NIC"].ToString();

                string strNewImaID = txtUserName.Text.Trim();

                string strServerImagePath;
                string strPostedFileName;
                string strImageType;
                //string strLastID = hifRefID.Value;
                //string strNIC = Session["NICNo"].ToString();
                string strNewFileName;

                strServerImagePath = Server.MapPath(".") + "\\User_Photos";

                if (fuPhoto.HasFile)
                {
                    strPostedFileName = fuPhoto.PostedFile.FileName;
                    strImageType = strPostedFileName.Substring(strPostedFileName.LastIndexOf("."));
                    strNewFileName = strNewImaID + "-1" + strImageType;
                    fuPhoto.PostedFile.SaveAs(strServerImagePath + "\\" + strNewFileName);
                    hf1.Value = "User_Photos" + "\\" + strNewFileName;
                }
                else
                {
                    hf1.Value = "";
                }

                string strTital = cmbTitle.SelectedItem.Value;
                string strAddress = txtAddress.Text.Trim();
                string strDateOfBirth = txtDateOfBirth.Text.Trim();
                #endregion

                #region Assign Parameters
                cmdInsertQRY.Parameters.Add("@NIC", MySqlDbType.VarChar, 10);
                cmdInsertQRY.Parameters.Add("@PASS", MySqlDbType.VarChar, 10);
                cmdInsertQRY.Parameters.Add("@FNAME", MySqlDbType.VarChar, 45);
                cmdInsertQRY.Parameters.Add("@LNAME", MySqlDbType.VarChar, 45);
                cmdInsertQRY.Parameters.Add("@UTYPE", MySqlDbType.VarChar, 15);
                cmdInsertQRY.Parameters.Add("@DESIG", MySqlDbType.VarChar, 45);
                cmdInsertQRY.Parameters.Add("@DEL", MySqlDbType.VarChar, 1);
                cmdInsertQRY.Parameters.Add("@CSTAT", MySqlDbType.VarChar, 1);
                cmdInsertQRY.Parameters.Add("@CREATEON", MySqlDbType.VarChar, 45);
                cmdInsertQRY.Parameters.Add("@LACCESS", MySqlDbType.VarChar, 45);
                cmdInsertQRY.Parameters.Add("@LASTIP", MySqlDbType.VarChar, 45);
                cmdInsertQRY.Parameters.Add("@CREATEDUNIC", MySqlDbType.VarChar, 10);
                cmdInsertQRY.Parameters.Add("@photo_path", MySqlDbType.VarChar, 100);
                cmdInsertQRY.Parameters.Add("@user_address", MySqlDbType.VarChar, 255);
                cmdInsertQRY.Parameters.Add("@date_of_birth", MySqlDbType.VarChar, 45);
                cmdInsertQRY.Parameters.Add("@user_title", MySqlDbType.VarChar, 10);
                #endregion

                #region Declare Parameters
                cmdInsertQRY.Parameters["@NIC"].Value = txtUserName.Text.Trim();
                cmdInsertQRY.Parameters["@PASS"].Value = strPassw;
                cmdInsertQRY.Parameters["@FNAME"].Value = txtFirstName.Text.Trim();
                cmdInsertQRY.Parameters["@LNAME"].Value = txtLastName.Text.Trim();
                cmdInsertQRY.Parameters["@UTYPE"].Value = cmbUserType.SelectedItem.ToString();
                cmdInsertQRY.Parameters["@DESIG"].Value = txtDesignation.Text.Trim();
                cmdInsertQRY.Parameters["@DEL"].Value = strDel;
                cmdInsertQRY.Parameters["@CSTAT"].Value = strCStat;
                cmdInsertQRY.Parameters["@CREATEON"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                cmdInsertQRY.Parameters["@LACCESS"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                cmdInsertQRY.Parameters["@LASTIP"].Value = strIp;
                cmdInsertQRY.Parameters["@CREATEDUNIC"].Value = strloginID;
                cmdInsertQRY.Parameters["@photo_path"].Value = hf1.Value;
                cmdInsertQRY.Parameters["@user_address"].Value = strAddress;
                cmdInsertQRY.Parameters["@date_of_birth"].Value = strDateOfBirth;
                cmdInsertQRY.Parameters["@user_title"].Value = strTital;
                #endregion

                try
                {
                    int i = 0;
                    i = objDBTask.insertEditData(cmdInsertQRY);
                    if (i == 1)
                    {
                        Reset();
                        lblMsg.Text = "User created Success";
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured...!";
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            MySqlCommand cmdSelect = new MySqlCommand("select nic from users where nic='" + txtUserName.Text + "'");

            dtNIC = objDBTask.selectData(cmdSelect);
            if (dtNIC.Tables[0].Rows.Count == 1)
            {
                lblMsg.Text = "User NIC Already used...!";
                btnSubmit.Enabled = false;
            }
            else
            {
                btnSubmit.Enabled = true;
            }
        }
    }
}
