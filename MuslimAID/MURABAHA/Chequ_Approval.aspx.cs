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
    public partial class Chequ_Approval : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (Session["UserType"].ToString() == "Manager" || Session["UserType"].ToString() == "Top Management" || Session["UserType"].ToString() == "Admin")
                {
                    if (!this.IsPostBack)
                    {
                        string strBranch = Session["Branch"].ToString();
                        string strUserType = Session["UserType"].ToString();

                        DataSet dsBranch;
                        MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                        dsBranch = objDBTask.selectData(cmdBranch);
                        cmbBranch.Items.Add("");
                        for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                        {
                            cmbBranch.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                            cmbBranch.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                        }

                        DataSet dsCenter = new DataSet();
                        if (strUserType == "Top Management")
                        {
                            dsCenter = cls_Connection.getDataSet("select idcenter_details,center_name,villages from center_details ORDER BY idcenter_details asc");
                        }
                        else
                        {
                            dsCenter = cls_Connection.getDataSet("select idcenter_details,center_name,villages from center_details where city_code = '" + strBranch + "' ORDER BY idcenter_details asc");
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

        protected void GetDate()
        {
            try
            {
                string strBranch = Session["Branch"].ToString();
                string strUserType = Session["UserType"].ToString();

                if (cmbBranch.SelectedIndex == 0)
                    lblMsg.Text = "Please Select the branch...";
                //else if (cmdSocietyNo.SelectedIndex == 0)
                //    lblMsg.Text = "Please Select the Center...";
                else {
                    DataSet dsLD = new DataSet();

                    if (strUserType == "Top Management")
                    {
                        if (cmdSocietyNo.SelectedIndex == 0)
                        {
                            dsLD = cls_Connection.getDataSet("SELECT * FROM micro_full_details WHERE loan_approved = 'Y' AND chequ_no IS NULL AND loan_sta = 'P';");
                        }
                        else
                        {
                            strBranch = cmbBranch.SelectedValue.ToString();
                            string strSoNo = cmdSocietyNo.SelectedItem.Value;

                            dsLD = cls_Connection.getDataSet("SELECT * FROM micro_full_details WHERE loan_approved = 'Y' AND chequ_no IS NULL AND loan_sta = 'P' AND society_id = '" + strSoNo + "' AND city_code = '" + strBranch + "';");
                        }
                    }
                    else
                    {
                        strBranch = cmbBranch.SelectedValue.ToString();
                        string strSoNo = cmdSocietyNo.SelectedItem.Value;
                        if (cmdSocietyNo.SelectedIndex == 0)
                        {
                            dsLD = cls_Connection.getDataSet("SELECT * FROM micro_full_details WHERE loan_approved = 'Y' AND chequ_no IS NULL AND loan_sta = 'P' AND society_id = '" + strSoNo + "' AND city_code = '" + strBranch + "';");
                        }
                        else
                        {
                            dsLD = cls_Connection.getDataSet("SELECT * FROM micro_full_details WHERE loan_approved = 'Y' AND chequ_no IS NULL AND loan_sta = 'P' AND society_id = '" + strSoNo + "' AND city_code = '" + strBranch + "';");
                        }
                    }

                    if (dsLD.Tables[0].Rows.Count > 0)
                    {
                        grvChequAppr.DataSource = dsLD;
                        grvChequAppr.DataBind();
                    }
                    else
                    {
                        lblMsg.Text = "No records found for your search criteria. Please try again.";
                    }
                }                
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Cheque Approval");
                grvChequAppr.DataSource = null;
                grvChequAppr.DataBind();
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            grvChequAppr.DataSource = null;
            grvChequAppr.DataBind();
            GetDate();
            //lblMsg.Text = "Tempoaraly suspance the cheque printing option. Please Contact Finance Section.";
        }

        protected void grvChequAppr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            grvChequAppr.PageIndex = e.NewPageIndex;
            // Rebind the GridView control to  
            // show data in the new page.
            GetDate();
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdSocietyNo.Items.Count > 0)
            {
                cmdSocietyNo.Items.Clear();
            }

            DataSet dsCenter = new DataSet();
            string strBranchh = cmbBranch.SelectedItem.Value;
            dsCenter = cls_Connection.getDataSet("select idcenter_details,center_name,villages from center_details where city_code = '" + strBranchh + "' ORDER BY idcenter_details asc");

            //dsCenter = objDBTask.selectData(cmdCenter);
            cmdSocietyNo.Items.Add("");

            for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
            {
                cmdSocietyNo.Items.Add(dsCenter.Tables[0].Rows[i]["center_name"] + "] - " + dsCenter.Tables[0].Rows[i]["villages"].ToString());
                cmdSocietyNo.Items[i + 1].Value = dsCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
            }
        }
    }
}
