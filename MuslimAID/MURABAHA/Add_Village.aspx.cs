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
    public partial class add_village : System.Web.UI.Page
    {
        cls_Connection objConn = new cls_Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True") {
                string strType = Session["UserType"].ToString();
                if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG")
                {
                    if (!this.IsPostBack)
                    {
                        DataSet dsBranch = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");
                        if (dsBranch.Tables[0].Rows.Count > 0)
                        {
                            cmbCityCode.Items.Add("");
                            for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                            {
                                cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                                cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("murabha.aspx");
                }
            }
            else {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsArea = cls_Connection.getDataSet("SELECT * FROM area WHERE branch_code = '"+ cmbCityCode.SelectedValue.ToString() +"' ORDER BY 2");
            cmbArea.Items.Clear();
            if (dsArea.Tables[0].Rows.Count > 0) {
                cmbArea.Items.Add("");
                for (int i = 0; i < dsArea.Tables[0].Rows.Count; i++)
                {
                    cmbArea.Items.Add(dsArea.Tables[0].Rows[i][1].ToString());
                    cmbArea.Items[i + 1].Value = dsArea.Tables[0].Rows[i][2].ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strloginID = Session["NIC"].ToString();
                string strUserType = Session["UserType"].ToString();
                string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strIp = Request.UserHostAddress;

                if (cmbCityCode.SelectedIndex == 0)
                    lblMsg.Text = "Please select the Branch";
                else if (cmbArea.SelectedIndex == 0)
                    lblMsg.Text = "Please select the Area";
                else if (txtVillage.Text.Trim() == "")
                    lblMsg.Text = "Please enter the Village Name";
                else if (txtVillageCode.Text.Trim() == "")
                    lblMsg.Text = "Please enter the Village Code";
                else
                {
                    MySqlCommand cmdVillage = new MySqlCommand("INSERT INTO villages_name (city_code,area_code, villages_code, villages_name, create_user_nic, user_ip, date_time) VALUES (@city_code,@area_code, @villages_code, @villages_name, @create_user_nic, @user_ip, @date_time)");

                    cmdVillage.Parameters.AddWithValue("@city_code", cmbCityCode.SelectedValue.ToString());
                    cmdVillage.Parameters.AddWithValue("@area_code", cmbArea.SelectedValue.ToString());
                    cmdVillage.Parameters.AddWithValue("@villages_name", txtVillage.Text.Trim());
                    cmdVillage.Parameters.AddWithValue("@villages_code", txtVillageCode.Text.Trim());
                    cmdVillage.Parameters.AddWithValue("@create_user_nic", strloginID);
                    cmdVillage.Parameters.AddWithValue("@user_ip", strIp);
                    cmdVillage.Parameters.AddWithValue("@date_time", strDate);

                    if (objConn.insertEditData(cmdVillage) > 0)
                    {
                        clear();
                        lblMsg.Text = "Successfully created.";
                    }
                    else
                        lblMsg.Text = "Error Occured";
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void clear()
        {
            cmbCityCode.SelectedIndex = 0;
            cmbArea.SelectedIndex = 0;
            txtVillage.Text = "";
            txtVillageCode.Text = "";
        }
    }
}
