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

namespace MuslimAID.MURABHA
{
    public partial class Add_Village : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        cls_ErrorLog error = new cls_ErrorLog();
        string strloginID, strBranch, strUserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                strBranch = Session["Branch"].ToString();
                strUserType = Session["UserType"].ToString();
                if (!this.IsPostBack)
                {
                    DataSet dsBranch = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");
                    //MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                    //dsBranch = objDBTask.selectData(cmdBranch);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                        cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                    }

                    if (strUserType == "Top Managment")
                    {

                    }
                    else
                    {
                        cmbCityCode.Text = strBranch;
                        cmbCityCode.Enabled = false;
                    }
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
            else if (txtVillage.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Village.";
            }
            else
            {
                string strVillage = txtVillage.Text.Trim();
                string strBranchCode = cmbCityCode.SelectedItem.Value;
                strloginID = Session["NIC"].ToString();
                string strIP = Request.UserHostAddress;
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO villages_name(city_code,villages_name,create_user_nic,user_ip,date_time)VALUES(@city_code,@villages_name,@create_user_nic,@user_ip,@date_time);");

                #region DeclarareParamerts
                cmdInsert.Parameters.Add("@city_code", MySqlDbType.VarChar, 3);
                cmdInsert.Parameters.Add("@villages_name", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                #endregion

                #region AssignParameters
                cmdInsert.Parameters["@city_code"].Value = strBranchCode;
                cmdInsert.Parameters["@villages_name"].Value = strVillage;
                cmdInsert.Parameters["@create_user_nic"].Value = strloginID;
                cmdInsert.Parameters["@user_ip"].Value = strIP;
                cmdInsert.Parameters["@date_time"].Value = strDateTime;
                #endregion

                try
                {
                    int i = objDBTask.insertEditData(cmdInsert);
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
            txtVillage.Text = "";

        }

        protected void txtVillage_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select branch.";
            }
            else if (txtVillage.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Area.";
            }
            else
            {
                try
                {
                    string strVillage = txtVillage.Text.Trim();
                    string strBranchCode = cmbCityCode.SelectedItem.Value;

                    DataSet dsGetVillage = cls_Connection.getDataSet("select * from villages_name where city_code = '" + strBranchCode + "' and villages_name = '" + strVillage + "';");
                    if (dsGetVillage.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "Alredy created.";
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
