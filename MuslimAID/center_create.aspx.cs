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
    public partial class center_create : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        string strloginID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strType = Session["UserType"].ToString();
                if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG")
                {
                    if (!this.IsPostBack)
                    {
                        DataSet dsBranch = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");
                        cmbBranch.Items.Add("Select Branch");
                        for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                        {
                            cmbBranch.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                            cmbBranch.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (txtCenterName.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter center name.";
                }
                else if (cmbBranch.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please chose city code.";
                }
                else if (cmbExecative.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please chose CRO.";
                }
                else if (cmbArea.SelectedIndex < 0)
                {
                    lblMsg.Text = "Please chose Area name.";
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
                else
                {
                    string strCenterName, strCityCode, strVillage, strLName, strContactNO, strIP, strDateTime, strCenterDay, strExecative, strArea;
                    string Longitude, Latitude;
                    strCenterName = hidCenterName.Value.Trim();
                    strCityCode = cmbBranch.SelectedItem.Value;
                    strVillage = cmbVillages.SelectedItem.Value;
                    strArea = cmbArea.SelectedValue.ToString();
                    strLName = txtLName.Text.Trim();
                    strContactNO = txtContactNo.Text.Trim();
                    strCenterDay = cmbCenterDay.SelectedValue.ToString();
                    strloginID = Session["NIC"].ToString();
                    strIP = Request.UserHostAddress;
                    strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    strExecative = cmbExecative.SelectedItem.Value;

                    string strMaxID = "1";
                    int intMaxID = 1;
                    DataSet dsGetMaxID = cls_Connection.getDataSet("select max(idcenter_details) from center_details where city_code = '" + strCityCode + "' AND area_code = '"+ strArea +"' AND villages = '"+ strVillage +"';");
                    if (dsGetMaxID.Tables[0].Rows[0][0].ToString() != "")
                    {
                        string strGetMaxID = dsGetMaxID.Tables[0].Rows[0][0].ToString();
                        intMaxID = Convert.ToInt32(strGetMaxID) + 1;
                        strMaxID = Convert.ToString(intMaxID);
                    }

                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO center_details(idcenter_details,center_name,city_code,villages,leader_name,conta_no,create_userID,create_ip,date_time,center_day,area_code,exective)VALUES(@idcenter_details,@center_name,@city_code,@villages,@leader_name,@conta_no,@create_userID,@create_ip,@date_time,@center_day,@area_code,@exective);");

                    #region DeclarareParamerts
                    cmdInsert.Parameters.Add("@idcenter_details", MySqlDbType.Int32);
                    cmdInsert.Parameters.Add("@center_name", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@city_code", MySqlDbType.VarChar, 3);
                    cmdInsert.Parameters.Add("@area_code", MySqlDbType.VarChar, 3);
                    cmdInsert.Parameters.Add("@villages", MySqlDbType.VarChar, 3);
                    cmdInsert.Parameters.Add("@leader_name", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@conta_no", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@create_userID", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@create_ip", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@center_day", MySqlDbType.VarChar, 10);
                    cmdInsert.Parameters.Add("@exective", MySqlDbType.VarChar, 45);
                    //cmdInsert.Parameters.Add("@Longitude", MySqlDbType.VarChar, 45);
                    //cmdInsert.Parameters.Add("@Latitude", MySqlDbType.VarChar, 45);
                    #endregion

                    #region AssignParameters
                    cmdInsert.Parameters["@idcenter_details"].Value = intMaxID;
                    cmdInsert.Parameters["@center_name"].Value = strCenterName;
                    cmdInsert.Parameters["@city_code"].Value = strCityCode;
                    cmdInsert.Parameters["@area_code"].Value = strArea;
                    cmdInsert.Parameters["@villages"].Value = strVillage;
                    cmdInsert.Parameters["@leader_name"].Value = strLName;
                    cmdInsert.Parameters["@conta_no"].Value = strContactNO;
                    cmdInsert.Parameters["@create_userID"].Value = strloginID;
                    cmdInsert.Parameters["@create_ip"].Value = strIP;
                    cmdInsert.Parameters["@date_time"].Value = strDateTime;
                    cmdInsert.Parameters["@center_day"].Value = strCenterDay;
                    cmdInsert.Parameters["@exective"].Value = strExecative;
                    //cmdInsert.Parameters["@Longitude"].Value = Longitude;
                    //cmdInsert.Parameters["@Latitude"].Value = Latitude;
                    #endregion

                    try
                    {
                        int i = objDBTask.insertEditData(cmdInsert);
                        if (i == 1)
                        {
                            //Get Center ID
                            string strCenterID = "";
                            DataSet dsCenterID = cls_Connection.getDataSet("select idcenter_details from center_details where city_code = '" + strCityCode + "' and date_time = '" + strDateTime + "' and center_name = '" + strCenterName + "';");
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
            catch (Exception)
            {
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (txtCenterName.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter center name.";
                }
                else if (cmbBranch.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please chose city code.";
                }
                else if (cmbExecative.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please chose CRO.";
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
                else
                {
                    string strArea, strCenterName, strCityCode, strVillage, strLName, strContactNO, strIP, strDateTime, strCenterDay, strExecative;
                    string Longitude, Latitude;
                    strCenterName = hidCenterName.Value.Trim();
                    strCityCode = cmbBranch.SelectedItem.Value;
                    strVillage = cmbVillages.SelectedItem.Value;
                    strArea = cmbArea.SelectedValue.ToString();
                    strLName = txtLName.Text.Trim();
                    strContactNO = txtContactNo.Text.Trim();
                    //strCenterDay = txtCenDate.Text.Trim();
                    strCenterDay = cmbCenterDay.SelectedValue.ToString();
                    strloginID = Session["NIC"].ToString();
                    strIP = Request.UserHostAddress;
                    strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    strExecative = cmbExecative.SelectedItem.Value;
                    //Longitude = txtLongitude.Text == "" ? "0.00" : txtLongitude.Text;
                    //Latitude = txtLatitude.Text == "" ? "0.00" : txtLatitude.Text;

                    string strMaxID = txtCenterID.Text.Trim();

                    MySqlCommand cmdInsert = new MySqlCommand("update center_details set center_name = @center_name,city_code = @city_code,villages = @villages, area_code = @area_code, leader_name = @leader_name,conta_no = @conta_no,center_day = @center_day,Latitude = @Latitude,Longitude = @Longitude,exective = @exective where idcenter_details = @idcenter_details;");

                    #region DeclarareParamerts
                    cmdInsert.Parameters.Add("@idcenter_details", MySqlDbType.Int32);
                    cmdInsert.Parameters.Add("@center_name", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@city_code", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@villages", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@area_code", MySqlDbType.VarChar, 3);
                    cmdInsert.Parameters.Add("@leader_name", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@conta_no", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@create_userID", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@create_ip", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@center_day", MySqlDbType.VarChar, 10);
                    cmdInsert.Parameters.Add("@exective", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@Longitude", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@Latitude", MySqlDbType.VarChar, 45);
                    #endregion

                    #region AssignParameters
                    cmdInsert.Parameters["@idcenter_details"].Value = strMaxID;
                    cmdInsert.Parameters["@center_name"].Value = strCenterName;
                    cmdInsert.Parameters["@city_code"].Value = strCityCode;
                    cmdInsert.Parameters["@villages"].Value = strVillage;
                    cmdInsert.Parameters["@area_code"].Value = strArea;
                    cmdInsert.Parameters["@leader_name"].Value = strLName;
                    cmdInsert.Parameters["@conta_no"].Value = strContactNO;
                    cmdInsert.Parameters["@create_userID"].Value = strloginID;
                    cmdInsert.Parameters["@create_ip"].Value = strIP;
                    cmdInsert.Parameters["@date_time"].Value = strDateTime;
                    cmdInsert.Parameters["@center_day"].Value = strCenterDay;
                    cmdInsert.Parameters["@exective"].Value = strExecative;
                    #endregion

                    try
                    {
                        int i = objDBTask.insertEditData(cmdInsert);

                        lblMsg.Text = "Successfully Created Center. Center ID - " + strMaxID;
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Clear()
        {
            txtCenterName.Text = "";
            txtContactNo.Text = "";
            txtLName.Text = "";
            cmbBranch.SelectedIndex = 0;
            cmbVillages.Items.Clear();
            cmbCenterDay.SelectedIndex = 0;
            cmbExecative.SelectedIndex = 0;
            txtCenterID.Text = "";
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            cmbArea.SelectedIndex = 0;
        }

        protected void txtCenterName_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbBranch.SelectedIndex == 0)
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
                DataSet dsGetCenterName = cls_Connection.getDataSet("select * from center_details where city_code = '" + cmbBranch.SelectedItem.Value + "' and villages = '" + cmbVillages.SelectedItem.Value + "' and center_name = '" + txtCenterName.Text.Trim() + "';");
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

        protected void txtCenterID_TextChanged(object sender, EventArgs e)
        {
            if (txtCenterID.Text != "")
            {
                try
                {
                    DataSet dsGetCenterName = cls_Connection.getDataSet("select * from center_details where city_code = '" + cmbBranch.SelectedItem.Value + "' and idcenter_details = '" + txtCenterID.Text.Trim() + "';");
                    if (dsGetCenterName.Tables[0].Rows.Count > 0)
                    {
                        cmbVillages.SelectedValue = dsGetCenterName.Tables[0].Rows[0]["villages"].ToString();
                        cmbExecative.SelectedValue = dsGetCenterName.Tables[0].Rows[0]["exective"].ToString();
                        txtCenterName.Text = dsGetCenterName.Tables[0].Rows[0]["center_name"].ToString();
                        txtLName.Text = dsGetCenterName.Tables[0].Rows[0]["leader_name"].ToString();
                        txtContactNo.Text = dsGetCenterName.Tables[0].Rows[0]["conta_no"].ToString();
                        cmbCenterDay.SelectedValue = dsGetCenterName.Tables[0].Rows[0]["center_day"].ToString();
                        cmbCenterDay.SelectedValue = dsGetCenterName.Tables[0].Rows[0]["center_day"].ToString();
                        //txtLatitude.Text = dsGetCenterName.Tables[0].Rows[0]["Latitude"].ToString();
                        //txtLongitude.Text = dsGetCenterName.Tables[0].Rows[0]["Longitude"].ToString();
                        btnUpdate.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                        btnSubmit.Visible = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsVillage = cls_Connection.getDataSet("select * from villages_name where city_code = '" + cmbBranch.SelectedItem.Value.ToString() + "' AND area_code = '"+cmbArea.SelectedValue.ToString()+"' ORDER BY villages_name");
            cmbVillages.Items.Clear();
            cmbVillages.Items.Add("Select Village");
            cmbVillages.Items[0].Value = "";
            for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
            {
                cmbVillages.Items.Add(dsVillage.Tables[0].Rows[i]["villages_name"].ToString());
                cmbVillages.Items[i + 1].Value = dsVillage.Tables[0].Rows[i]["villages_code"].ToString();
            }
        }

        protected void cmbVillages_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select MFO
            DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + cmbBranch.SelectedValue.ToString() + "';");

            cmbExecative.Items.Clear();
            cmbExecative.Items.Add("Select MFO");
            for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
            {
                cmbExecative.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                cmbExecative.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
            }

            //Center Code
            string strMaxID = "1";
            int intMaxID = 1;
            DataSet dsGetMaxID = cls_Connection.getDataSet("SELECT max(idcenter_details) FROM center_details WHERE city_code = '" + cmbBranch.SelectedValue.ToString() + "' AND area_code = '" + cmbArea.SelectedValue.ToString()+ "' AND villages = '"+ cmbVillages.SelectedValue.ToString()+"';");
            if (dsGetMaxID.Tables[0].Rows[0][0].ToString() != "")
            {
                string strGetMaxID = dsGetMaxID.Tables[0].Rows[0][0].ToString();
                strMaxID = (Convert.ToInt32(strGetMaxID) + 1).ToString();
                txtCenterID.Text = strMaxID;
                txtCenterName.Text = cmbVillages.SelectedItem.Text + "-" + strMaxID;
                hidCenterName.Value = cmbVillages.SelectedItem.Text + "-" + strMaxID;
            }
            else
            {
                txtCenterID.Text = "1";
                txtCenterName.Text = cmbVillages.SelectedItem.Text + "-1";
                hidCenterName.Value = cmbVillages.SelectedItem.Text + "-1";
            }
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (cmbBranch.SelectedIndex != 0)
                {
                    cmbArea.Items.Clear();
                    DataSet dsArea = cls_Connection.getDataSet("SELECT * FROM area WHERE branch_code = '" + cmbBranch.SelectedValue.ToString() + "' ORDER BY 2");
                    cmbArea.Items.Clear();
                    if (dsArea.Tables[0].Rows.Count > 0)
                    {
                        cmbArea.Items.Add("Select Area");
                        for (int i = 0; i < dsArea.Tables[0].Rows.Count; i++)
                        {
                            cmbArea.Items.Add(dsArea.Tables[0].Rows[i][1].ToString());
                            cmbArea.Items[i + 1].Value = dsArea.Tables[0].Rows[i][2].ToString();
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "Please chose city code.";
                    btnSubmit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Data Reteave error");
            }
        }
    }
}
