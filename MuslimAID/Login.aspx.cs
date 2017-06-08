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

namespace MuslimAID
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        HttpCookie loginCookie = new HttpCookie("loginAuth");
        cls_Connection objDBTasks = new cls_Connection();

        protected void publishLogOnDetails()
        {
            HttpCookie loginCookie = Request.Cookies["loginAuth"];
            if (loginCookie != null)
            {
                Session["NIC"] = Request.Cookies["loginAuth"].Values["NIC"];
            }
            Session["LoggedIn"] = "True";

            string strNIC, strIp, strCurruntSta, strDate;
            #region Get Values
            strNIC = Session["NIC"].ToString();
            strIp = Request.UserHostAddress;
            strCurruntSta = "L";
            strDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            Response.Redirect("muslimaid.aspx");
        }

        private void UserLogin()
        {
            //try
            //{
                lblMsgs.Text = "";
                lblMsgs.Visible = true;
                if (txtUsername.Text.Trim() != "" && txtPassword.Text.Trim() != "")
                {
                    string strNIC = txtUsername.Text.Trim();
                    DataSet dsUserSta = cls_Connection.getDataSet("select * from users where nic = '" + strNIC + "';");
                    int intDeleCou = dsUserSta.Tables[0].Rows.Count;
                    if (intDeleCou > 0)
                    {
                        if (dsUserSta.Tables[0].Rows[0]["deleted"].ToString() == "N")
                        {
                            //if (dsUserSta.Tables[0].Rows[0]["current_status"].ToString() == "N" || dsUserSta.Tables[0].Rows[0]["current_status"].ToString() == "D")
                            //{
                                Boolean bolAuthLogin = objDBTasks.loginValidation(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                                //try
                                //{
                                //    objDBTasks.insertEditData("UPDATE muslimaid.users SET current_status='L' WHERE nic='" + strNIC + "';");
                                //}
                                //catch (Exception e) { cls_ErrorLog.createSErrorLog(e.Message, e.Source, "login"); }

                                if (bolAuthLogin == true)
                                {
                                    publishLogOnDetails();
                                }
                                else
                                {
                                    lblMsgs.Text = "Invalid User Name or Password......";
                                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblMsgs.ClientID + "').style.display='none'\",3000)</script>");
                                }
                            //}
                            //else
                            //{
                            //    lblMsgs.Text = "This user already loged in......";
                            //    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblMsgs.ClientID + "').style.display='none'\",3000)</script>");
                            //}
                        }
                        else
                        {
                            lblMsgs.Text = "This user may be deleted or deactivated......";
                            ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblMsgs.ClientID + "').style.display='none'\",3000)</script>");
                        }
                    }
                    else
                    {
                        lblMsgs.Text = "Invalid User Name or Password......";
                    }
                }
                else
                {
                    lblMsgs.Text = "Please enter user details.";
                }
            //}
            //catch (Exception ex)
            //{
            //    lblMsgs.Text = "Database Conection fail...";
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() != "True")
            {
                HttpCookie loginCookie = Request.Cookies["loginAuth"];
                //IF COOKIE IS EXISTS
                if (loginCookie != null)
                {
                    Session["LoggedIn"] = "True";
                    Session["NIC"] = Request.Cookies["loginAuth"].Values["NIC"];

                    publishLogOnDetails();
                }
                //IF COOKIE DOES NOT EXIST
                else
                {
                    //IF USER HAS NOT LOGGED IN
                    if (Session["LoggedIn"].ToString() != "True")
                    {
                        Session["LoggedIn"] = "False";
                    }
                    //IF USER HAS LOGGED IN TO THE SYSTEM
                    else
                    {
                        publishLogOnDetails();
                    }
                }
            }
            else
            {
                publishLogOnDetails();
            }
            txtUsername.Focus();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserLogin();
        }
    }
}
