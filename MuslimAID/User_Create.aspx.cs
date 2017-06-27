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
                GetUserDetails(); 
                string strloginID = Session["NIC"].ToString();
                DataSet dsBranch = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");
                cmbBranch.Items.Clear();
                cmbBranch.Items.Add("");
                for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                {
                    cmbBranch.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                    cmbBranch.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                }

                DataSet dsUserTy = cls_Connection.getDataSet("SELECT user_type FROM users WHERE nic = '" + strloginID + "';");
                if (dsUserTy.Tables[0].Rows.Count > 0)
                {
                    strType = dsUserTy.Tables[0].Rows[0]["user_type"].ToString();
                    if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG")
                    {
                        btnSubmit.Enabled = true;
                        btnUpdate.Enabled = false;
                        btnDactivate.Enabled = false;
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
                        txtEPF_No.Enabled = true;
                        txtMobile.Enabled = true;
                        txtTele.Enabled = true;
                        //cmbBranch.Enabled = false;
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
                        txtEPF_No.Enabled = false;
                        txtMobile.Enabled = false;
                        txtTele.Enabled = false;
                        //cmbBranch.Enabled = false;
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

        private void GetUserDetails()
        {
            DataSet dsUsers = cls_Connection.getDataSet("SELECT * FROM users");
            // WHERE idusers != 1

            if(dsUsers.Tables[0].Rows.Count > 0){
                StringBuilder strUsers = new StringBuilder();
                strUsers.Append("<table class='table'>");
                strUsers.Append("<tr>");
                strUsers.Append("<td class='tblHead'>ID</td>");
                strUsers.Append("<td class='tblHead'>User Id</td>");
                strUsers.Append("<td class='tblHead'>First Name</td>");
                strUsers.Append("<td class='tblHead'>Last Name</td>");
                strUsers.Append("<td class='tblHead'>User Type</td>");
                strUsers.Append("</tr>");

                for (int i = 0; i < dsUsers.Tables[0].Rows.Count; i++)
                {
                    strUsers.Append("<tr>");
                    strUsers.Append("<td class='tblBody'>" + dsUsers.Tables[0].Rows[i]["idusers"].ToString() + "</td>");
                    strUsers.Append("<td class='tblBody'>" + dsUsers.Tables[0].Rows[i]["nic"].ToString() + "</td>");
                    strUsers.Append("<td class='tblBody'>" + dsUsers.Tables[0].Rows[i]["first_name"].ToString() + "</td>");
                    strUsers.Append("<td class='tblBody'>" + dsUsers.Tables[0].Rows[i]["last_name"].ToString() + "</td>");
                    strUsers.Append("<td class='tblBody'>");
                    if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "MFO")
                        strUsers.Append("Micro Finance Officer");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "BFA")
                        strUsers.Append("Branch Finance & Admin Officer");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "BMG")
                        strUsers.Append("Branch Manager");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "RFA")
                        strUsers.Append("Regional Finance & Admin Officer");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "RMG")
                        strUsers.Append("Regional Manager");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "FAO")
                        strUsers.Append("Finance & Admin Officer");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "OMG")
                        strUsers.Append("Oparations Manager");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "CMG")
                        strUsers.Append("Chief Manager");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "BOD")
                        strUsers.Append("BOD");
                    else if (dsUsers.Tables[0].Rows[i]["user_type"].ToString() == "ADM")
                        strUsers.Append("Admin");
                    else { }
                    strUsers.Append("</td>");
                    strUsers.Append("</tr>");
                }

                strUsers.Append("</table>");
                userTBL.Text = strUsers.ToString();
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
            cmbBranch.SelectedIndex = 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if(validatefrm("S"))
            {
                MySqlCommand cmdInsertQRY = new MySqlCommand("insert into users(nic,user_password,first_name,last_name,user_type,designation,deleted,current_status,created_on,last_accessed_on,last_accessed_ip,created_user_nic,photo_path,user_address,date_of_birth,user_title, branch_code, company_code, EPFNo, Mobile_No, Tele_No) values(@NIC,@PASS,@FNAME,@LNAME,@UTYPE,@DESIG,@DEL,@CSTAT,@CREATEON,@LACCESS,@LASTIP,@CREATEDUNIC,@photo_path,@user_address,@date_of_birth,@user_title,@branch_code, @company_code, @EPFNo, @Mobile_No, @Tele_No)");

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
                cmdInsertQRY.Parameters.Add("@branch_code", MySqlDbType.VarChar, 4);
                cmdInsertQRY.Parameters.Add("@company_code", MySqlDbType.VarChar, 4);
                #endregion

                #region Declare Parameters
                cmdInsertQRY.Parameters["@NIC"].Value = txtUserName.Text.Trim();
                cmdInsertQRY.Parameters["@PASS"].Value = strPassw;
                cmdInsertQRY.Parameters["@FNAME"].Value = txtFirstName.Text.Trim();
                cmdInsertQRY.Parameters["@LNAME"].Value = txtLastName.Text.Trim();
                cmdInsertQRY.Parameters["@UTYPE"].Value = cmbUserType.SelectedValue.ToString();
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
                cmdInsertQRY.Parameters["@branch_code"].Value = cmbBranch.SelectedValue.ToString();
                cmdInsertQRY.Parameters["@company_code"].Value = "MAID";
                cmdInsertQRY.Parameters["@EPFNo"].Value = txtEPF_No.Text.Trim();
                cmdInsertQRY.Parameters["@Mobile_No"].Value = txtMobile.Text.Trim();
                cmdInsertQRY.Parameters["@Tele_No"].Value = txtTele.Text.Trim();
                #endregion

                try
                {
                    int i = 0;
                    i = objDBTask.insertEditData(cmdInsertQRY);
                    if (i == 1)
                    {
                        if(cmbUserType.SelectedValue.ToString() == "MFO")
                            create_mfo();

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
                cmbUserType.SelectedValue = dtNIC.Tables[0].Rows[0]["user_type"].ToString();
                cmbBranch.SelectedValue = dtNIC.Tables[0].Rows[0]["branch_code"].ToString();
                txtEPF_No.Text = dtNIC.Tables[0].Rows[0]["EPFNo"].ToString();
                txtMobile.Text = dtNIC.Tables[0].Rows[0]["Mobile_No"].ToString();
                txtTele.Text = dtNIC.Tables[0].Rows[0]["Tele_No"].ToString();
                lblMsg.Text = "User NIC Already used...!";
                btnSubmit.Enabled = false;
                btnUpdate.Enabled = true;
                btnDactivate.Enabled = true;
                txtPassword.Focus();
            }
            else
            {
                btnSubmit.Enabled = true;
                txtPassword.Focus();
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

                q.Append("UPDATE users SET user_password='" + passwd + "', user_title='" + cmbTitle.SelectedValue.ToString() + "', first_name='" + txtFirstName.Text.Trim() + "', last_name='" + txtLastName.Text.Trim() + "', user_address='" + txtAddress.Text.Trim() + "',date_of_birth='" + txtDateOfBirth.Text.Trim() + "', user_type='" + cmbUserType.SelectedValue.ToString() + "', designation='" + txtDesignation.Text.Trim() + "', branch_code='" + cmbBranch.SelectedValue.ToString() + "', EPFNo='" + txtEPF_No.Text.Trim() + "', Mobile_No='" + txtMobile.Text.Trim() + "', Tele_No='" + txtTele.Text.Trim() + "'");

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
                        update_mfo();
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
                lblMsg.Text = "Please enter NIC."; return false;
            }
            else if (txtPassword.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Password."; return false;
            }
            else if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                lblMsg.Text = "Password didn't Match."; return false;
            }
            else if (txtConfirmPass.Text.Trim() == "")
            {
                lblMsg.Text = "Please Re Enter Password"; return false;
            }
            else if (txtFirstName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter First name"; return false;
            }
            else if (txtFirstName.Text.Length < 3)
            {
                lblMsg.Text = "First name must be more than 3 characters"; return false;
            }
            else if (txtLastName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Last name"; return false;
            }
            else if (txtLastName.Text.Length < 3)
            {
                lblMsg.Text = "Last name must be more than 3 characters"; return false;
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
                    return false;
                }
                else
                    return true;
            }
            else if (txtDesignation.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Designation"; return false;
            }
            else if (cmbUserType.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select user type"; return false;
            }
            else if (cmbBranch.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select branch."; cmbBranch.Focus(); return false;
            }
            else if (txtEPF_No.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter users epf no."; txtEPF_No.Focus(); return false;
            }
            else if (txtMobile.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter users mobile no."; txtMobile.Focus(); return false;
            }
            else if (txtTele.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter users telephone no."; txtTele.Focus(); return false;
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

        private bool create_mfo()
        {
            cls_Connection objDBCon = new cls_Connection();
            DataSet dsGetCurrPassword = cls_Connection.getDataSet("select (IFNULL(MAX(exe_id),0) + 1) AS MAX from micro_exective_root where branch_code ='" + cmbBranch.SelectedValue.ToString() + "'");

            MySqlCommand cmdInsertQRY = new MySqlCommand("INSERT INTO micro_exective_root(exe_id,exe_name,exe_nic, branch_code,create_user_id,create_ip,create_date_time,EPFNo,Mobile_No,Land_No,Address,Designation)VALUES(@exe_id,@exe_name, @exe_nic, @branch_code,@create_user_id,@create_ip,@create_date_time,@EPFNo,@Mobile_No,@Land_No,@Address,@Designation);");

            #region assignment
            //string rootName = (txtFirstName.Text.Trim() != "") ? txtFirstName.Text.Trim() : "" + txtLastName.Text.Trim();
            #endregion
            #region Assign Parameters
            cmdInsertQRY.Parameters.Add("@exe_id", MySqlDbType.VarChar, 2);
            cmdInsertQRY.Parameters.Add("@exe_name", MySqlDbType.VarChar, 200);
            cmdInsertQRY.Parameters.Add("@exe_nic", MySqlDbType.VarChar, 12);
            cmdInsertQRY.Parameters.Add("@branch_code", MySqlDbType.VarChar, 10);
            cmdInsertQRY.Parameters.Add("@create_user_id", MySqlDbType.VarChar, 10);
            cmdInsertQRY.Parameters.Add("@create_ip", MySqlDbType.VarChar, 45);
            cmdInsertQRY.Parameters.Add("@create_date_time", MySqlDbType.VarChar, 20);
            cmdInsertQRY.Parameters.Add("@EPFNo", MySqlDbType.VarChar, 20);
            cmdInsertQRY.Parameters.Add("@Mobile_No", MySqlDbType.VarChar, 20);
            cmdInsertQRY.Parameters.Add("@Land_No", MySqlDbType.VarChar, 20);
            cmdInsertQRY.Parameters.Add("@Address", MySqlDbType.VarChar, 20);
            cmdInsertQRY.Parameters.Add("@Designation", MySqlDbType.VarChar, 20);
            #endregion

            #region DEclare Parametes
            cmdInsertQRY.Parameters["@exe_id"].Value = dsGetCurrPassword.Tables[0].Rows[0][0].ToString();
            cmdInsertQRY.Parameters["@exe_name"].Value = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            cmdInsertQRY.Parameters["@exe_nic"].Value = txtUserName.Text.Trim();
            cmdInsertQRY.Parameters["@branch_code"].Value = cmbBranch.SelectedValue.ToString();
            cmdInsertQRY.Parameters["@create_user_id"].Value = Session["NIC"].ToString();
            cmdInsertQRY.Parameters["@create_ip"].Value = Request.UserHostAddress;
            cmdInsertQRY.Parameters["@create_date_time"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cmdInsertQRY.Parameters["@EPFNo"].Value = txtEPF_No.Text.Trim();
            cmdInsertQRY.Parameters["@Mobile_No"].Value = txtMobile.Text.Trim();
            cmdInsertQRY.Parameters["@Land_No"].Value = txtTele.Text.Trim();
            cmdInsertQRY.Parameters["@Address"].Value = txtAddress.Text.Trim();
            cmdInsertQRY.Parameters["@Designation"].Value = txtDesignation.Text.Trim();
            #endregion

            if (objDBCon.insertEditData(cmdInsertQRY) > 0)
                return true;
            else
                return false;
        }

        private bool update_mfo()
        {
            cls_Connection objDBCon = new cls_Connection();
            string strUPQ = "UPDATE micro_exective_root SET exe_name='" + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim() + "', branch_code='" + cmbBranch.SelectedValue.ToString() + "',updated_user_id='" + Session["NIC"].ToString() + "',create_ip='" + Request.UserHostAddress.ToString() + "',create_date_time='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',EPFNo='"+txtEPF_No.Text.Trim()+"',Mobile_No='"+txtMobile.Text.Trim()+"',Land_No='"+txtTele.Text.Trim()+"',Address='"+txtAddress.Text.Trim()+"',Designation='"+txtDesignation.Text.Trim()+"' WHERE exe_nic ='" + txtUserName.Text.Trim() + "'";

            MySqlCommand cmdUPQ = new MySqlCommand(strUPQ);
            if (objDBCon.insertEditData(cmdUPQ) > 0)
            {
                Reset();
                return true;
            }
            else
                return false;
        }

    }
}
