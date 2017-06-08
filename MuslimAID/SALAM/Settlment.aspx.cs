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

namespace MuslimAID.SALAM
{
    public partial class Settlment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!IsPostBack)
                {
                    if (Session["LoggedIn"].ToString() == "True")
                    {
                        if (Session["UserType"] != "Cash Collector" || Session["UserType"] != "Cash Recovery Officer" || Session["UserType"] != "Special Recovery Officer")
                        {
                            //strCC = Request.QueryString["CC"];
                            //strCAC = Request.QueryString["CA"];

                            //if (strCC != null && strCAC != null)
                            //{
                            //    txtCC.Text = strCC;
                            //    txtCACode.Text = strCAC;
                            //    txtCC.Enabled = false;
                            //    btnSubmit.Enabled = true;
                            //}
                            //else
                            //{
                            //    txtCC.Enabled = true;
                            //    btnSubmit.Enabled = false;
                            //}
                        }
                        else { Response.Redirect("salam.aspx"); }
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }
    }
}
