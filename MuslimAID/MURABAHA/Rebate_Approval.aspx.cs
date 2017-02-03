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
    public partial class Rebate_Approval : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                grvRebaAppr.AllowPaging = true;
                grvRebaAppr.PageSize = 30;

                if (!this.IsPostBack)
                {
                    GetDate();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void GetDate()
        {
            DataSet dsLD = cls_Connection.getDataSet("select contra_code,arrears,in_amount,prio,new_inte_rate,min_amount,new_loan_bala from rebate where sta='P';");

            if (dsLD.Tables[0].Rows.Count > 0)
            {
                grvRebaAppr.DataSource = dsLD;
                grvRebaAppr.DataBind();
            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void grvRebaAppr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            grvRebaAppr.PageIndex = e.NewPageIndex;
            // Rebind the GridView control to  
            // show data in the new page.
            GetDate();
        }
    }
}
