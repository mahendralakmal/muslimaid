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
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace MuslimAID.MURABHA
{
    public partial class Report_Center_details : System.Web.UI.Page
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
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            grvCenDeta.DataSource = null;
            grvCenDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            try
            {
                lblMsg.Text = "";
                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = "SELECT c.idcenter_details,c.center_name,b.b_name, a.area,v.villages_name AS villages,c.leader_name,c.conta_no,exe_name,case center_day when 'MO' then 'Monday' when 'TU' then 'Tuesday' when 'WE' then 'Wednsday' when 'TH' then 'Thursday' when 'FR' then 'Friday' when 'SA' then 'Saturday' when 'SU' then 'Sunday' end as center_day FROM center_details c, branch b,micro_exective_root e, villages_name v, area a WHERE b.b_code = c.city_code AND c.city_code = e.branch_code AND c.exective = e.exe_id AND v.villages_code = c.villages AND a.area_code = c.area_code";

                if (cmbBranch.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and b.b_code = '" + cmbBranch.SelectedValue.ToString() + "' ";
                if (cmbArea.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and a.area_code = '" + cmbArea.SelectedValue.ToString() + "' ";
                if (cmbVillage.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and v.villages_code = '" + cmbVillage.SelectedValue.ToString() + "' ";
                if (cmbCenterName.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and c.idcenter_details = '" + cmbCenterName.SelectedValue.ToString() + "' ";
                if (cmbRoot.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and e.exe_id = '" + cmbRoot.SelectedValue.ToString() + "' ";
                if (cmbCenterDay.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and c.center_day = '" + cmbCenterDay.SelectedValue.ToString() + "' ";
                if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    DateTime strTo = DateTime.ParseExact(txtDateTo.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    DateTime strStart = DateTime.ParseExact(txtDateFrom.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    hstrSelectQuery.Value += " and c.date_time BETWEEN '" + strStart.ToString() + "' and '" + strTo.ToString() + "'";
                }
                hstrSelectQuery.Value = hstrSelectQuery.Value + " ORDER BY exe_name asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            catch (Exception)
            {
            }
        }

        protected void loadDataToRepeater(string strQRY)
        {
            //int iCurrentPage = Convert.ToInt32(strCurrentPage);
            //COUNT ALL RECORDS
            DataSet dsAllData = cls_Connection.getDataSet(strQRY);
            //iAllRows = dsAllData.Tables[0].Rows.Count;

            //GET RELEVANT DATA
            MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, cls_Connection.DBConnect());
            DataSet dsSelectData = new DataSet();
            daData.Fill(dsSelectData);
            grvCenDeta.DataSource = dsSelectData;
            grvCenDeta.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        //Export Excel----------------------------------
        protected void exportExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Center_details_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages

                    grvCenDeta.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in grvCenDeta.HeaderRow.Cells)
                    {
                        cell.BackColor = grvCenDeta.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in grvCenDeta.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grvCenDeta.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grvCenDeta.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grvCenDeta.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void View_Click(object sender, EventArgs e)
        {
            exportExcel();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbBranch.SelectedIndex != 0)
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
                        btnSerch.Enabled = true;

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
                        btnSerch.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load Areas according to selected branch");
                    return;
                }

                try
                {
                    string strBranch = cmbBranch.SelectedItem.Value;

                    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");
                    if (cmbRoot.Items.Count > 0)
                    {
                        cmbRoot.Items.Clear();
                    }
                    cmbRoot.Items.Add("");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
                    }
                    //cmbRoot.Enabled = true;
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load MFO according to selected branch");
                    return;
                }
            }
            else
            {
                lblMsg.Text = "Please select branch";
                btnSerch.Enabled = false;
            }
            #region comment
            //if (cmbBranch.SelectedIndex > -1)
            //{
            //    if (cmbCenterName.Items.Count > 0)
            //    {
            //        cmbCenterName.Items.Clear();
            //    }
            //    DataSet dsSocietyName;
            //    MySqlCommand cmdSocietyName = new MySqlCommand("select center_name from center_details where city_code = '" + cmbBranch.SelectedItem.Value + "' ;");
            //    dsSocietyName = objDBTask.selectData(cmdSocietyName);
            //    if (dsSocietyName.Tables[0].Rows.Count > 0)
            //    {
            //        cmbCenterName.Items.Add("");
            //        for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
            //        {
            //            cmbCenterName.Items.Add(dsSocietyName.Tables[0].Rows[i]["center_name"].ToString());
            //        }
            //    }

            //    string strBranch = cmbBranch.SelectedItem.Value;

            //    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");
            //    if (cmbRoot.Items.Count > 0)
            //    {
            //        cmbRoot.Items.Clear();
            //    }
            //    cmbRoot.Items.Add("");

            //    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
            //    {
            //        cmbRoot.Items.Add(dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
            //        cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
            //    }
            //}
            #endregion
        }

        protected void cmbSocietyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCenterID.Text = cmbCenterName.SelectedValue.ToString();
        }

        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (cmbBranch.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please chose city code.";
                    btnSerch.Enabled = false;
                }
                else if (cmbArea.SelectedIndex < 0)
                {
                    lblMsg.Text = "Please chose village name.";
                    btnSerch.Enabled = false;
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
                        btnSerch.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load villages according to selected area");
                return;
            }
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (cmbVillage.SelectedIndex != 0 && cmbBranch.SelectedIndex != 0 && cmbArea.SelectedIndex != 0)
                {
                    DataSet dsGetSocietyID = cls_Connection.getDataSet("select exective from center_details where city_code = '" + cmbBranch.SelectedItem.Value + "' and area_code = '" + cmbArea.SelectedItem.Value + "' and villages = '" + cmbVillage.SelectedItem.Value + "';");
                    if (dsGetSocietyID.Tables[0].Rows.Count > 0)
                    {
                        //txtSoNumber.Text = cmbSocietyName.SelectedItem.Value.ToString();

                        DataSet dsSCenter = cls_Connection.getDataSet("SELECT idcenter_details, center_name, center_day FROM center_details WHERE city_code = '" + cmbBranch.SelectedItem.Value + "' AND area_code = '" + cmbArea.SelectedItem.Value + "' AND villages = '" + cmbVillage.SelectedItem.Value + "';");
                        cmbCenterName.Items.Clear();
                        if (dsSCenter.Tables[0].Rows.Count > 0)
                        {
                            cmbCenterName.Items.Add("Select Center");

                            for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                            {
                                cmbCenterName.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                                cmbCenterName.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                            }
                        }
                        cmbCenterName.Enabled = true;
                        //Edit 2014.09.18 CACode
                        //CACodeNew();
                        cmbRoot.SelectedValue = dsGetSocietyID.Tables[0].Rows[0]["exective"].ToString();
                        btnSerch.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "Invalid City Code or Society Name.";
                        btnSerch.Enabled = false;
                    }
                }
                else
                {
                    lblMsg.Text = "Please select city code or Society Name.";
                    btnSerch.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load");
                return;
            }
        }
    }
}
