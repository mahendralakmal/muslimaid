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
    public partial class Agreement : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            { 
            
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            pnlAgree.Visible = false;
            pnlNoAgree.Visible = false;

            if (txtCC.Text.Trim() == "")
            {
                pnlNoAgree.Visible = true;
                pnlAgree.Visible = false;
                lblMsg.Text = "Please enter contract code.";
            }
            else
            {
                DataSet dsGetAgree = objDBTask.selectData("select loan_approved from micro_loan_details where contra_code = '" + txtCC.Text.Trim() +"';");
                if (dsGetAgree.Tables[0].Rows.Count > 0)
                {
                    string strApproved = dsGetAgree.Tables[0].Rows[0]["loan_approved"].ToString();
                    if (strApproved == "Y")
                    {
                        pnlNoAgree.Visible = false;
                        pnlAgree.Visible = true;
                    }
                    else
                    {
                        pnlNoAgree.Visible = true;
                        pnlAgree.Visible = false;
                        lblMsg.Text = "Not Approved Loan.";
                    }
                }
                else
                {
                    pnlNoAgree.Visible = true;
                    pnlAgree.Visible = false;
                    lblMsg.Text = "Invalid Contract Code.";
                }
            }
        }

        protected void lnkPage1_Click(object sender, EventArgs e)
        {
            if (txtCC.Text.Trim() == "")
            {
                pnlNoAgree.Visible = true;
                pnlAgree.Visible = false;
                Session.Remove("agree");
                lblMsg.Text = "Please enter contract code.";
            }
            else
            {
                Session["agree"] = txtCC.Text.Trim();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ppUp", "PopUPCA();", true);
            }
        }

        protected void lnkPage2_Click(object sender, EventArgs e)
        {
            if (txtCC.Text.Trim() == "")
            {
                pnlNoAgree.Visible = true;
                pnlAgree.Visible = false;
                Session.Remove("agree");
                lblMsg.Text = "Please enter contract code.";
            }
            else
            {
                Session["agree"] = txtCC.Text.Trim();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ppUp", "PopUPCA2();", true);
            }
        }
    }
}
