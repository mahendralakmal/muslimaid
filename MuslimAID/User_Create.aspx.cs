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
using System.Text;

namespace MuslimAID
{
    public partial class User_Create : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        cls_ErrorLog er_log = new cls_ErrorLog();
        DataSet dtNIC = new DataSet();
        string strType = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strloginID = Session["NIC"].ToString();

                DataSet dsUserTy = cls_Connection.getDataSet("select user_type from users where nic = '" + strloginID + "';");
                if (dsUserTy.Tables[0].Rows.Count > 0)
                {
                    strType = dsUserTy.Tables[0].Rows[0]["user_type"].ToString();
                    if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG")
                    {
                        btnSubmit.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDactivate.Enabled = true;
                        btnUpdate.Visible = true;
                        btnDactivate.Visible = true;
                        txtUserName.Enabled = true;
                        txtFirstName.Enabled = true;
                        txtLastName.Enabled = true;
                        txtAddress.Enabled = true;
                        txtDesignation.Enabled = true;
                        txtDateOfBirth.Enabled = true;
                        cmbTitle.Enabled = true;
                        cmbUserType.Enabled = true;
                        fuPhoto.Enabled = true;
                        txtPassword.Enabled = true;
                        txtConfirmPass.Enabled = true;
                    }
                    else if (strType == "FAO" || strType == "RMG" || strType == "RFA" || strType == "BMG" || strType == "BFA" || strType == "MFO") 
                    {
                        txtUserName.Text = Session["NIC"].ToString();
                        DataSet dsUser = cls_Connection.getDataSet("SELECT * FROM users WHERE nic = '" + Session["NIC"].ToString() + "'");

                        cmbTitle.SelectedValue = dsUser.Tables[0].Rows[0]["user_title"].ToString();
                        txtFirstName.Text = dsUser.Tables[0].Rows[0]["first_name"].ToString();
                        txtLastName.Text = dsUser.Tables[0].Rows[0]["last_name"].ToString();
                        txtAddress.Text = dsUser.Tables[0].Rows[0]["user_address"].ToString();
                        txtDateOfBirth.Text = dsUser.Tables[0].Rows[0]["date_of_birth"].ToString();
                        txtDesignation.Text = dsUser.Tables[0].Rows[0]["designation"].ToString();
                        cmbUserType.SelectedValue = dsUser.Tables[0].Rows[0]["user_type"].ToString();
                        img_path.Text = dsUser.Tables[0].Rows[0]["photo_path"].ToString();
                        hid_img_path.Value = dsUser.Tables[0].Rows[0]["photo_path"].ToString();
                        
                        txtUserName.Enabled = false;

                        btnSubmit.Visible = false;
                        btnDactivate.Visible = false;
                        btnUpdate.Enabled = true;
                        btnUpdate.Visible = true;

                        fuPhoto.Enabled = true;
                        txtPassword.Enabled = true;
                        txtConfirmPass.Enabled = true;
                        txtFirstName.Enabled = false;
                        txtLastName.Enabled = false;
                        txtAddress.Enabled = false;
                        txtDesignation.Enabled = false;
                        txtDateOfBirth.Enabled = false;
                        cmbTitle.Enabled = false;
                        cmbUserType.Enabled = false;
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
            img_path.Text = "";
            cmbTitle.SelectedIndex = 0;
            cmbUserType.SelectedIndex = 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if(validatefrm("S"))
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
                    er_log.createErrorLog(ex.Message, ex.Source, "User Create");
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
            MySqlCommand cmdSelect = new MySqlCommand("select * from users where nic='" + txtUserName.Text + "'");

            dtNIC = objDBTask.selectData(cmdSelect);
            if (dtNIC.Tables[0].Rows.Count == 1)
            {
                cmbTitle.SelectedItem.Text = dtNIC.Tables[0].Rows[0]["user_title"].ToString();
                txtAddress.Text = dtNIC.Tables[0].Rows[0]["user_address"].ToString();
                txtDateOfBirth.Text = dtNIC.Tables[0].Rows[0]["date_of_birth"].ToString();
                txtDesignation.Text = dtNIC.Tables[0].Rows[0]["designation"].ToString();
                txtFirstName.Text = dtNIC.Tables[0].Rows[0]["first_name"].ToString();
                txtLastName.Text = dtNIC.Tables[0].Rows[0]["last_name"].ToString();
                img_path.Text = dtNIC.Tables[0].Rows[0]["photo_path"].ToString();
                hid_img_path.Value = dtNIC.Tables[0].Rows[0]["photo_path"].ToString();
                lblMsg.Text = "User NIC Already used...!";
                btnSubmit.Enabled = false;
                btnUpdate.Enabled = true;
                btnDactivate.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validatefrm("U"))
            {
                string passwd = EncodePasswordToBase64(txtPassword.Text.Trim());
                string strServerImagePath;
                string strPostedFileName;
                string strImageType;
                string strNewFileName;
                string fpath = "";

                strServerImagePath = Server.MapPath(".") + "\\User_Photos";

                if (fuPhoto.HasFile)
                {
                    strPostedFileName = fuPhoto.PostedFile.FileName;
                    strImageType = strPostedFileName.Substring(strPostedFileName.LastIndexOf("."));
                    strNewFileName = txtUserName.Text.Trim() + "-1" + strImageType;
                    fuPhoto.PostedFile.SaveAs(strServerImagePath + "\\" + strNewFileName);
                    hf1.Value = "User_Photos" + "\\" + strNewFileName;
                    fpath = "User_Photos" + "\\" + strNewFileName;
                }

                StringBuilder q = new StringBuilder();

                q.Append("UPDATE users SET user_password='" + passwd + "', user_title='" + cmbTitle.SelectedValue.ToString() + "', first_name='" + txtFirstName.Text.Trim() + "', last_name='" + txtLastName.Text.Trim() + "', user_address='" + txtAddress.Text.Trim() + "',date_of_birth='" + txtDateOfBirth.Text.Trim() + "', user_type='" + cmbUserType.SelectedValue.ToString() + "', designation='"+ txtDesignation.Text.Trim()+"'");

                if (fpath != "")
                {
                    q.Append(", photo_path='" + fpath + "'");
                }

                q.Append(" WHERE nic = '" + txtUserName.Text.Trim() + "'");

                try
                {
                    MySqlCommand cmdQ = new MySqlCommand(q.ToString());
                    if (objDBTask.insertEditData(cmdQ) == 1)
                    {
                        Reset();
                        lblMsg.Text = "User updated success";
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured...!";
                    }
                }
                catch (Exception ex)
                {
                    er_log.createErrorLog(ex.Message, ex.Source, "User Update");
                }
            }
        }

        protected bool validatefrm(string param)
        {
            if (txtUserName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your NIC."; return false;
            }
            else if (txtPassword.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your Password."; return false;
            }
            else if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                lblMsg.Text = "Password didn't Match."; return false;
            }
            else if (txtConfirmPass.Text.Trim() == "")
            {
                lblMsg.Text = "Please Re Enter your Password"; return false;
            }
            else if (txtFirstName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your First name"; return false;
            }
            else if (txtLastName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your Last name"; return false;
            }
            else if (txtAddress.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Address."; return false;
            }
            else if (txtDateOfBirth.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Date Of Birth."; return false;
            }
            else if (param == "S")
            {
                if (!fuPhoto.HasFile)
                {
                    lblMsg.Text = "Please Add User Photo.";
                }
                return false;
            }
            else if (txtDesignation.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter your Designation"; return false;
            }
            else if (cmbUserType.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select user type"; return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnDactivate_Click(object sender, EventArgs e)
        {
            try
            {
                cls_Connection.setData("UPDATE users SET deleted='D' WHERE nic='" + txtUserName.Text.Trim() + "';");
            }
            catch (Exception x) { cls_ErrorLog.createSErrorLog(x.Message, x.Source, "deactivate"); }
        }
    }
}
