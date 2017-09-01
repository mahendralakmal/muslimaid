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
using System.Text;

namespace MuslimAID.MURABAHA
{
    public partial class loan_approval : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    if (!this.IsPostBack)
                    {
                        //GetDate();
                        string strBranch = Session["Branch"].ToString(); 
                        string strType = Session["UserType"].ToString();
                        if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG" ||
                            strType == "RMG" || strType == "BMG")
                        {
                            DataSet dsBranch;
                            MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                            dsBranch = objDBTask.selectData(cmdBranch);
                            cmbBranch.Items.Add("");
                            for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                            {
                                cmbBranch.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                                cmbBranch.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                            }
                        }
                        else
                        {
                            Response.Redirect("murabha.aspx");
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

        protected void GetDate()
        {
            try
            {
                string strBranch = Session["Branch"].ToString();
                string strUserType = Session["UserType"].ToString();

                if (cmbBranch.SelectedIndex == 0)
                    lblMsg.Text = "Please Select the branch...";
                else
                {
                    string strType = Session["UserType"].ToString();
                    StringBuilder strBQ = new StringBuilder("SELECT * FROM micro_full_details WHERE team_id != '' AND loan_approved = 'P' AND loan_sta = 'P' AND reg_approval = 'Y'");

                    if (cmbBranch.SelectedIndex > 0)
                        strBQ.Append(" AND city_code = '" + cmbBranch.SelectedValue.ToString() + "'");
                    if(cmbArea.SelectedIndex > 0)
                        strBQ.Append(" AND area_code ='" + cmbArea.SelectedValue.ToString() + "'");
                    if (cmbVillage.SelectedIndex > 0)
                        strBQ.Append(" AND villages_code = '" + cmbVillage.SelectedValue.ToString() + "'");
                    if (cmdSocietyNo.SelectedIndex > 0)
                        strBQ.Append(" AND society_id = '" + cmdSocietyNo.SelectedValue.ToString() + "'");
                    //if (strType == "BMG")
                    //    strBQ.Append(" AND loan_amount BETWEEN 0 AND 30000");
                    //if (strType == "RMG")
                    //    strBQ.Append(" AND loan_amount BETWEEN 0 AND 50000");
                    //if (strType == "OMG")
                    //    strBQ.Append(" AND loan_amount BETWEEN 0 AND 75000");
                    //if (strType == "CMG")
                    //    strBQ.Append(" AND loan_amount BETWEEN 0 AND 100000");
                    //if (strType == "BOD" || strType == "ADM")
                    //    strBQ.Append(" AND loan_amount > 0");
                    strBQ.Append(";");
                    DataSet dsLD = new DataSet();
                    dsLD = cls_Connection.getDataSet(strBQ.ToString());
                    
                    if (dsLD.Tables[0].Rows.Count > 0)
                    {
                        grvLoanAppr.DataSource = dsLD;
                        grvLoanAppr.DataBind();
                    }
                    else
                    {
                        lblMsg.Text = "No records found for your search criteria. Please try again.";
                    }
                }
            }
            catch (Exception ex)
            {
            }            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            grvLoanAppr.DataSource = null;
            grvLoanAppr.DataBind();
            GetDate();
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.Items.Count > 0)
            {
                cmbArea.Items.Clear();
            }

            if (cmbVillage.Items.Count > 0)
            {
                cmbVillage.Items.Clear();
            }

            try
            {
                DataSet dsVillage = cls_Connection.getDataSet("select * from area where branch_code = '" + cmbBranch.SelectedItem.Value + "' ORDER BY area");
                if (dsVillage.Tables[0].Rows.Count > 0)
                {
                    cmbArea.Items.Add("Select Area");
                    //btnSubmit.Enabled = true;

                    for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                    {
                        cmbArea.Items.Add(dsVillage.Tables[0].Rows[i][1].ToString());
                        cmbArea.Items[i + 1].Value = dsVillage.Tables[0].Rows[i][2].ToString();
                    }
                    cmbArea.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "No record found...! Please chose other city code.";
                   // btnSubmit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (cmbBranch.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select branch.";
                    //btnSubmit.Enabled = false;
                }
                else if (cmbArea.SelectedIndex < 0)
                {
                    lblMsg.Text = "Please select area.";
                    //btnSubmit.Enabled = false;
                }
                else
                {
                    if (cmbVillage.Items.Count > 0)
                    {
                        cmbVillage.Items.Clear();
                    }

                    DataSet dsSocietyName = cls_Connection.getDataSet("SELECT villages_code,villages_name FROM villages_name WHERE city_code = '" + cmbBranch.SelectedItem.Value + "' AND area_code ='" + cmbArea.SelectedItem.Value + "';");
                    if (dsSocietyName.Tables[0].Rows.Count > 0)
                    {
                        cmbVillage.Items.Add("Select Village");
                        for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
                        {
                            cmbVillage.Items.Add(dsSocietyName.Tables[0].Rows[i]["villages_name"].ToString());
                            cmbVillage.Items[i + 1].Value = dsSocietyName.Tables[0].Rows[i]["villages_code"].ToString();
                        }
                        cmbVillage.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "No record found...! Please chose other village name.";
                        //btnSubmit.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //txtSoNumber.Text = "";
                lblMsg.Text = "";
                if (cmbVillage.SelectedIndex != 0 && cmbBranch.SelectedIndex != 0 && cmbArea.SelectedIndex != 0)
                {
                    DataSet dsSCenter = cls_Connection.getDataSet("SELECT idcenter_details, center_name, center_day FROM center_details WHERE city_code = '" + cmbBranch.SelectedItem.Value + "' AND area_code = '" + cmbArea.SelectedItem.Value + "' AND villages = '" + cmbVillage.SelectedItem.Value + "';");
                    cmdSocietyNo.Items.Clear();
                    if (dsSCenter.Tables[0].Rows.Count > 0)
                    {
                        cmdSocietyNo.Items.Add("Select Center");

                        for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                        {
                            cmdSocietyNo.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                            cmdSocietyNo.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                        }
                        cmdSocietyNo.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "There is no available centers...";
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
