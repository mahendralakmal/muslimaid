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

namespace LoanSystem.Micro
{
    public partial class Center_Create : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();
        string strloginID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    DataSet dsBranch;
                    MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                    dsBranch = objDBTask.selectData(cmdBranch);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                        cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCenterName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter center name.";
            }
            else if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please chose city code.";
            }
            else if (cmbVillages.SelectedIndex < 0)
            {
                lblMsg.Text = "Please chose Village name.";
            }
            else if (txtLName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Leader Name.";
            }
            else if (txtContactNo.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Contact No.";
            }
            //else if (txtCenDate.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please enter center date.";
            //}
            else
            {
                string strCenterName, strCityCode, strVillage, strLName, strContactNO, strIP, strDateTime, strCenterDay;

                strCenterName = txtCenterName.Text.Trim();
                strCityCode = cmbCityCode.SelectedItem.Value;
                strVillage = cmbVillages.SelectedItem.Value;
                strLName = txtLName.Text.Trim();
                strContactNO = txtContactNo.Text.Trim();
                //strCenterDay = txtCenDate.Text.Trim();
                strCenterDay = cmbCenterDay.SelectedValue.ToString();
                strloginID = Session["NIC"].ToString();
                strIP = Request.UserHostAddress;
                strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string strMaxID = "1";
                int intMaxID = 1;
                DataSet dsGetMaxID = objDBTask.selectData("select max(idcenter_details) from center_details where city_code = '" + strCityCode + "';");
                if (dsGetMaxID.Tables[0].Rows[0][0].ToString() != "")
                {
                    string strGetMaxID = dsGetMaxID.Tables[0].Rows[0][0].ToString();
                    intMaxID = Convert.ToInt32(strGetMaxID) + 1;
                    strMaxID = Convert.ToString(intMaxID);
                }

                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO center_details(idcenter_details,center_name,city_code,villages,leader_name,conta_no,create_userID,create_ip,date_time,center_day)VALUES(@idcenter_details,@center_name,@city_code,@villages,@leader_name,@conta_no,@create_userID,@create_ip,@date_time,@center_day);");

                #region DeclarareParamerts
                cmdInsert.Parameters.Add("@idcenter_details", MySqlDbType.Int32);
                cmdInsert.Parameters.Add("@center_name", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@city_code", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@villages", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@leader_name", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@conta_no", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@create_userID", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@create_ip", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@center_day", MySqlDbType.VarChar, 10);
                #endregion

                #region AssignParameters
                cmdInsert.Parameters["@idcenter_details"].Value = intMaxID;
                cmdInsert.Parameters["@center_name"].Value = strCenterName;
                cmdInsert.Parameters["@city_code"].Value = strCityCode;
                cmdInsert.Parameters["@villages"].Value = strVillage;
                cmdInsert.Parameters["@leader_name"].Value = strLName;
                cmdInsert.Parameters["@conta_no"].Value = strContactNO;
                cmdInsert.Parameters["@create_userID"].Value = strloginID;
                cmdInsert.Parameters["@create_ip"].Value = strIP;
                cmdInsert.Parameters["@date_time"].Value = strDateTime;
                cmdInsert.Parameters["@center_day"].Value = strCenterDay;
                #endregion

                try
                {
                    int i = objDBTask.insertEditData(cmdInsert);
                    if (i == 1)
                    {
                        //Get Center ID
                        string strCenterID = "";
                        DataSet dsCenterID = objDBTask.selectData("select idcenter_details from center_details where city_code = '" + strCityCode + "' and date_time = '" + strDateTime + "' and center_name = '" + strCenterName + "';");
                        if (dsCenterID.Tables[0].Rows.Count > 0)
                        {
                            strCenterID = dsCenterID.Tables[0].Rows[0]["idcenter_details"].ToString();
                        }

                        lblMsg.Text = "Successfully Created Center. Center ID - " + strCenterID;
                        Clear();

                    }
                    else
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void Clear()
        {
            txtCenterName.Text = "";
            txtContactNo.Text = "";
            txtLName.Text = "";
            cmbCityCode.SelectedIndex = 0;
            //cmbVillages.SelectedIndex = 0;
            cmbVillages.Items.Clear();
            //txtCenDate.Text = "";
            cmbCenterDay.SelectedIndex = 0;
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex != 0)
            {
                if (cmbVillages.Items.Count > 0)
                {
                    //cmbVillages.Items.RemoveAt(0);
                    cmbVillages.Items.Clear();
                }

                DataSet dsVillage;
                MySqlCommand cmdVillage = new MySqlCommand("select * from villages_name where city_code = '" + cmbCityCode.SelectedItem.Value + "'");
                dsVillage = objDBTask.selectData(cmdVillage);
                for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                {
                    cmbVillages.Items.Add(dsVillage.Tables[0].Rows[i][2].ToString());
                    //cmdVillage.Items[i].Value = dsVillage.Tables[0].Rows[i][1].ToString();
                }
            }
            else
            {
                lblMsg.Text = "Please chose city code.";
                btnSubmit.Enabled = false;
            }
        }

        protected void txtCenterName_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please chose city code.";
            }
            else if (cmbVillages.SelectedItem.Value == "")
            {
                lblMsg.Text = "Please chose village name.";
            }
            else if (txtCenterName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter center name.";
            }
            else
            {
                DataSet dsGetCenterName = objDBTask.selectData("select * from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "' and villages = '" + cmbVillages.SelectedItem.Value + "' and center_name = '" + txtCenterName.Text.Trim() + "';");
                if (dsGetCenterName.Tables[0].Rows.Count > 0)
                {
                    lblMsg.Text = "This center name is already used...!";
                    btnSubmit.Enabled = false;
                }
                else
                {
                    btnSubmit.Enabled = true;
                }
            }
        }
    }
}
