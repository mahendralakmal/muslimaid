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

namespace MuslimAID
{
    public partial class add_area : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        cls_ErrorLog error = new cls_ErrorLog();
        string strloginID, strBranch, strUserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strType = Session["UserType"].ToString();
                if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG")
                {
                    strBranch = Session["Branch"].ToString();
                    strUserType = Session["UserType"].ToString();
                    if (!this.IsPostBack)
                    {
                        DataSet dsBranch = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");

                        cmbCityCode.Items.Add("");
                        for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                        {
                            cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                            cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                        }

                        cmbCityCode.Text = strBranch;
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select branch.";
            }
            else if (txtArea.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Area.";
            }
            else if (txtAreaCode.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Area Code.";
            }
            else
            {
                strloginID = Session["NIC"].ToString();
                string strIP = Request.UserHostAddress;
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                MySqlCommand cmdArea = new MySqlCommand("INSERT INTO area(branch_code, area, area_code)VALUES(@branch_code, @area, @area_code)");

                cmdArea.Parameters.AddWithValue("@branch_code", cmbCityCode.SelectedValue.ToString());
                cmdArea.Parameters.AddWithValue("@area", txtArea.Text.Trim());
                cmdArea.Parameters.AddWithValue("@area_code", txtAreaCode.Text.Trim().ToString());

                try
                {
                    int i = objDBTask.insertEditData(cmdArea);
                    if (i == 1)
                    {
                        lblMsg.Text = "Successfully Added Area";
                        Clear();

                    }
                    else
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {                            
                    //error.createErrorLog(ex.Message, ex.Source, ex.StackTrace);
                }
            }
        }

        protected void Clear()
        {
            cmbCityCode.SelectedIndex = 0;
            txtArea.Text = "";
            txtAreaCode.Text = "";
        }

        protected void txtVillage_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select branch.";
            }
            else if (txtArea.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Area.";
            }
            else if (txtAreaCode.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Area Code.";
            }
            else
            {
                try
                {
                    DataSet dsGetVillage = cls_Connection.getDataSet("select * from area where branch_code = '" + cmbCityCode.SelectedValue.ToString() + "' and area = '" + txtArea.Text.Trim() + "';");
                    if (dsGetVillage.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "Successfully created.";
                        btnSubmit.Enabled = false;
                    }
                    else
                    {
                        btnSubmit.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    //error.createErrorLog(ex.Message, ex.Source, ex.StackTrace);
                }
            }
        }


    }
}
