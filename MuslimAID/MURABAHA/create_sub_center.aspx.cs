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

namespace MuslimAID.MURABAHA
{
    public partial class create_sub_center : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        cls_ErrorLog error = new cls_ErrorLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    string strloginID = Session["NIC"].ToString();
                    if (Session["UserType"].ToString() == "Manager" || Session["UserType"].ToString() == "Top Management" || Session["UserType"].ToString() == "Admin")
                    {
                        DataSet dsCenter = cls_Connection.getDataSet("SELECT * FROM center_details");
                        if (dsCenter.Tables[0].Rows.Count > 0)
                        {
                            cmbCenterCode.Items.Add("Select Center");
                            for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                            {
                                cmbCenterCode.Items.Add(dsCenter.Tables[0].Rows[i]["center_name"].ToString());
                                cmbCenterCode.Items[i + 1].Value = dsCenter.Tables[0].Rows[i]["auto_id"].ToString();
                            }
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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbCenterCode.SelectedIndex < 0) 
                lblMsg.Text = "Please select a center";
            else if (txtSCName.Text.Trim() == "")
                lblMsg.Text = "Please enter sub center name";
            else
            {
                DataSet dsQ = cls_Connection.getDataSet("SELECT max(sub_center_on_center) FROM sub_center_tbl WHERE center_id ='"+ cmbCenterCode.SelectedValue +"'");

                int index = (dsQ.Tables[0].Rows[0][0].ToString() != "") ? Convert.ToInt32(dsQ.Tables[0].Rows[0][0].ToString()) + 1 : 1;
                MySqlCommand cmdSubCenter = new MySqlCommand("INSERT INTO sub_center_tbl (name, center_id, sub_center_on_center) VALUE (@name, @center_id, @sub_center_on_center)");

                cmdSubCenter.Parameters.AddWithValue("@name",txtSCName.Text.Trim());
                cmdSubCenter.Parameters.AddWithValue("@center_id", cmbCenterCode.SelectedIndex);
                cmdSubCenter.Parameters.AddWithValue("@sub_center_on_center", index);

                try
                {
                    if (objDBTask.insertEditData(cmdSubCenter) == 1062)
                        lblMsg.Text = "Duplicate entry please change the sub ceter";
                    else if (objDBTask.insertEditData(cmdSubCenter) > 0)
                    {
                        lblMsg.Text = "Successfully added";
                        clean();
                    }
                    else
                        lblMsg.Text = "Error Occured";
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Inserting basic details");
                }
            }
        }

        protected void clean() {
            cmbCenterCode.SelectedIndex = 0;
            txtSCName.Text = "";
        }
    }
}
