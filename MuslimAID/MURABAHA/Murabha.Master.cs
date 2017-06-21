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

namespace MuslimAID.MURABHA
{
    public partial class Murabha : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strType = Session["UserType"].ToString();
            if (strType == "ADM" || strType == "BOD" || strType == "CMG")
            {
                pnlFullControl.Visible = true;
                pnlOMG.Visible = false;
                pnlFAO.Visible = false;
                pnlRMG.Visible = false;
                pnlRFA.Visible = false;
                pnlBMG.Visible = false;
                pnlBFA.Visible = false;
                pnlMFO.Visible = false;
            }
            else if (strType == "OMG")
            {
                pnlFullControl.Visible = false;
                pnlOMG.Visible = true;
                pnlFAO.Visible = false;
                pnlRMG.Visible = false;
                pnlRFA.Visible = false;
                pnlBMG.Visible = false;
                pnlBFA.Visible = false;
                pnlMFO.Visible = false;
            }
            else if (strType == "FAO")
            {
                pnlFullControl.Visible = false;
                pnlOMG.Visible = false;
                pnlFAO.Visible = true;
                pnlRMG.Visible = false;
                pnlRFA.Visible = false;
                pnlBMG.Visible = false;
                pnlBFA.Visible = false;
                pnlMFO.Visible = false;
            }
            else if (strType == "RMG")
            {
                pnlFullControl.Visible = false;
                pnlOMG.Visible = false;
                pnlFAO.Visible = false;
                pnlRMG.Visible = true;
                pnlBMG.Visible = false;
                pnlBFA.Visible = false;
                pnlMFO.Visible = false;
                pnlRFA.Visible = false;
            }
            else if (strType == "RFA")
            {
                pnlFullControl.Visible = false;
                pnlOMG.Visible = false;
                pnlFAO.Visible = false;
                pnlRMG.Visible = false;
                pnlBMG.Visible = false;
                pnlBFA.Visible = false;
                pnlMFO.Visible = false;
                pnlRFA.Visible = true;
            }
            else if (strType == "BMG")
            {
                pnlFullControl.Visible = false;
                pnlOMG.Visible = false;
                pnlFAO.Visible = false;
                pnlRMG.Visible = false;
                pnlBMG.Visible = true;
                pnlBFA.Visible = false;
                pnlMFO.Visible = false;
                pnlRFA.Visible = false;
            }
            else if (strType == "BFA")
            {
                pnlFullControl.Visible = false;
                pnlOMG.Visible = false;
                pnlFAO.Visible = false;
                pnlRMG.Visible = false;
                pnlBMG.Visible = false;
                pnlBFA.Visible = true;
                pnlMFO.Visible = false;
                pnlRFA.Visible = false;
            }
            else
            {
                pnlFullControl.Visible = false;
                pnlOMG.Visible = false;
                pnlFAO.Visible = false;
                pnlRMG.Visible = false;
                pnlBMG.Visible = false;
                pnlBFA.Visible = false;
                pnlMFO.Visible = true;
                pnlRFA.Visible = false;
            }
            
        }
    }
}
