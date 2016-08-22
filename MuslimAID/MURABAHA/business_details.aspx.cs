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
using System.Data;
using System.Text.RegularExpressions;

namespace MuslimAID.MURABHA
{
    public partial class business_details : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();
        string strCC, strCAC;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!IsPostBack)
                {
                    if (Session["LoggedIn"].ToString() == "True")
                    {
                        strCC = Request.QueryString["CC"];
                        strCAC = Request.QueryString["CA"];

                        if (strCC != null && strCAC != null)
                        {
                            txtCC.Text = strCC;
                            txtCACode.Text = strCAC;
                            txtCC.Enabled = false;
                            btnSubmit.Enabled = true;
                        }
                        else
                        {
                            txtCC.Enabled = true;
                            btnSubmit.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
    }
}
