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

namespace MuslimAID.MURABAHA
{
    public partial class family_appraisal : System.Web.UI.Page
    {
        string strCC; string strCAC;
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
                        //strCC = Request.QueryString["CC"];
                        //strCAC = Request.QueryString["CA"];
                        strCC = "CO/CS/000004";
                        strCAC = "CO/1/01/02";

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

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
