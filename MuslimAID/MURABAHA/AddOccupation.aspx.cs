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

namespace MuslimAID.MURABAHA
{
    public partial class AddOccupation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strloginID = Session["NIC"].ToString();

                string strType = Session["UserType"].ToString();
                if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG")
                {
                    if (!this.IsPostBack)
                    {

                    }
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

        protected void btnChange_Click(object sender, EventArgs e)
        {
            cls_Connection obj = new cls_Connection();
            try {
                if (txtOccupation.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter occupation";
                }
                else
                {
                    MySqlCommand cmdOcc = new MySqlCommand("INSERT INTO micro_occupation (occupation) VALUES(@occupation);");
                    cmdOcc.Parameters.AddWithValue("@occupation", txtOccupation.Text.Trim());

                    if(obj.insertEditData(cmdOcc) == 1062)
                        lblMsg.Text = "This occupation is alredy exists";
                    else if (obj.insertEditData(cmdOcc) > 0)
                        lblMsg.Text = "Successfully Upadted";
                    else
                        lblMsg.Text = "Error occured";
                }
            }
            catch (Exception ex) { }
        }
    }
}
