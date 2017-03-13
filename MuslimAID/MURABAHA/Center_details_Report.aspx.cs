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

namespace MuslimAID.MURABHA
{
    public partial class Center_details_Report : System.Web.UI.Page
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
                hstrSelectQuery.Value = "select c.idcenter_details,c.center_name,b.b_name,c.villages,c.leader_name,c.conta_no,exe_name,case center_day when 'MO' then 'Monday' when 'TU' then 'Tuesday' when 'WE' then 'Wednsday' when 'TH' then 'Thursday' when 'FR' then 'Friday' when 'SA' then 'Saturday' when 'SU' then 'Sunday' end as center_day from center_details c, branch b,micro_exective_root e where b.b_code = c.city_code and c.city_code = e.branch_code and c.exective = e.exe_id";
                if (txtCenterID.Text.Trim() != "" || cmbBranch.SelectedIndex != 0 || cmbCenterName.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbRoot.Text.Trim() != "")
                {
                    if (txtCenterID.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + txtCenterID.Text.Trim() + "'";
                    }
                    if (cmbBranch.SelectedIndex != 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.b_code = '" + cmbBranch.Text.Trim() + "'";

                        if (cmbCenterName.Text.Trim() != "")
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.center_name = '" + cmbCenterName.Text.Trim() + "'";
                        }
                        if (cmbRoot.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.exective = '" + cmbRoot.SelectedValue + "'";
                        }
                    }
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and (DATE_FORMAT((date_time),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    if (cmbCenterDay.Text != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and center_day = '" + cmbCenterDay.Text.Trim() + "'";
                    }

                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
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
            if (cmbBranch.SelectedIndex > -1)
            {
                if (cmbCenterName.Items.Count > 0)
                {
                    cmbCenterName.Items.Clear();
                }
                DataSet dsSocietyName;
                MySqlCommand cmdSocietyName = new MySqlCommand("select center_name from center_details where city_code = '" + cmbBranch.SelectedItem.Value + "' ;");
                dsSocietyName = objDBTask.selectData(cmdSocietyName);
                if (dsSocietyName.Tables[0].Rows.Count > 0)
                {
                    cmbCenterName.Items.Add("");
                    for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
                    {
                        cmbCenterName.Items.Add(dsSocietyName.Tables[0].Rows[i]["center_name"].ToString());
                    }
                }

                string strBranch = cmbBranch.SelectedItem.Value;

                DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");
                if (cmbRoot.Items.Count > 0)
                {
                    cmbRoot.Items.Clear();
                }
                cmbRoot.Items.Add("");

                for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                {
                    cmbRoot.Items.Add(dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                    cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
                }
            }
        }

        protected void cmbSocietyName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
