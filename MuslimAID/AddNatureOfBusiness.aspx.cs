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
    public partial class AddNatureOfBusiness : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    string strType = Session["UserType"].ToString();
                    if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG")
                    {

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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNature.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter nature of business";
            }
            else
            {
                MySqlCommand cmdNature = new MySqlCommand("INSERT INTO micro_nature_of_business (natureOfBusiness) VALUES (@natureOfBusiness);");

                cmdNature.Parameters.AddWithValue("@natureOfBusiness", txtNature.Text.Trim());
                cls_Connection objDb = new cls_Connection();

                if (objDb.insertEditData(cmdNature)>0)
                    lblMsg.Text = "Successfully inseted";
                else
                    lblMsg.Text = "Error occured";
            }
        }
    }
}
