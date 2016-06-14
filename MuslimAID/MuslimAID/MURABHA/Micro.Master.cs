using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace LoanSystem.Micro
{
    public partial class Micro : System.Web.UI.MasterPage
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strloginID = Session["NIC"].ToString();

                DataSet dsUserTy = objDBTask.selectData("select user_type,module_name,company_code from users where nic = '" + strloginID + "';");
                if (dsUserTy.Tables[0].Rows.Count > 0)
                {
                    string strType = dsUserTy.Tables[0].Rows[0]["user_type"].ToString();
                    string strModul = dsUserTy.Tables[0].Rows[0]["module_name"].ToString();
                    string strCompanyName = dsUserTy.Tables[0].Rows[0]["company_code"].ToString();
                    if (strCompanyName == "PCA")
                    {
                        if (strModul == "A" || strModul == "CS")
                        {
                            if (strType == "Top Managment")
                            {
                                pnlTop.Visible = true;
                                pnlExe.Visible = false;
                                pnlCashir.Visible = false;
                                pnlDocument.Visible = false;
                                pnlManager.Visible = false;
                                pnlRegiManager.Visible = false;
                            }
                            else if (strType == "Regional Manager CS")
                            {
                                pnlTop.Visible = false;
                                pnlExe.Visible = false;
                                pnlCashir.Visible = false;
                                pnlDocument.Visible = false;
                                pnlManager.Visible = false;
                                pnlRegiManager.Visible = true;
                            }
                            else if (strType == "Manager")
                            {
                                pnlTop.Visible = false;
                                pnlExe.Visible = false;
                                pnlCashir.Visible = false;
                                pnlDocument.Visible = false;
                                pnlManager.Visible = true;
                                pnlRegiManager.Visible = false;
                            }
                            else if (strType == "Executive" || strType == "Team Leader")
                            {
                                pnlExe.Visible = true;
                                pnlTop.Visible = false;
                                pnlCashir.Visible = false;
                                pnlDocument.Visible = false;
                                pnlManager.Visible = false;
                                pnlRegiManager.Visible = false;
                            }
                            else if (strType == "Cashier")
                            {
                                pnlExe.Visible = false;
                                pnlTop.Visible = false;
                                pnlCashir.Visible = true;
                                pnlDocument.Visible = false;
                                pnlManager.Visible = false;
                                pnlRegiManager.Visible = false;
                            }
                            else if (strType == "Document Officer")
                            {
                                pnlExe.Visible = false;
                                pnlTop.Visible = false;
                                pnlCashir.Visible = false;
                                pnlDocument.Visible = true;
                                pnlManager.Visible = false;
                                pnlRegiManager.Visible = false;
                            }
                            else
                            {
                                Response.Redirect("../Default.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("../Default.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("../Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void lnkLO_Click(object sender, EventArgs e)
        {
            logout();
        }

        protected void logout()
        {
            Session["LoggedIn"] = "False";
            Session["NIC"] = "";

            //Response.Redirect("index.aspx");

            HttpCookie loginCookie = Request.Cookies["loginAuth"];

            //IF COOKIE IS EXISTS
            if (loginCookie != null)
            {
                Response.Cookies["loginAuth"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("../Default.aspx");
        }
    }
}
