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

namespace MuslimAID
{
    public partial class Logout : System.Web.UI.Page
    {
        cls_Connection objDBTasks = new cls_Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    objDBTasks.insertEditData("UPDATE muslimaid.users SET current_status='N' WHERE nic='" + Session["NIC"] + "';");
            //}
            //catch (Exception ex) { cls_ErrorLog.createSErrorLog(ex.Message,ex.Source,"logout"); }
            Session["LoggedIn"] = "False";
            Session["NIC"] = null;
            Session["Branch"] = null;
            Session["UserType"] = null;
            
            Response.Redirect("Login.aspx");
        }
    }
}
