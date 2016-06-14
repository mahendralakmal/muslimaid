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

namespace LoanSystem.Micro
{
    public partial class Center_details_Report : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

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
                    Response.Redirect("../Default.aspx");
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
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select c.idcenter_details,c.center_name,b.b_name,c.villages,c.leader_name,c.conta_no from center_details c, branch b where b.b_code = c.city_code";
            if (txtCenterID.Text.Trim() != "" || cmbBranch.SelectedIndex != 0 || txtCName.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "")
            {
                if (txtCenterID.Text.Trim() != "" && cmbBranch.SelectedIndex != 0 && txtCName.Text.Trim() != "" && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + txtCenterID.Text.Trim() + "' and c.center_name = '" + txtCName.Text.Trim() + "' and b.b_code = '" + cmbBranch.Text.Trim() + "' and date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() != "" && cmbBranch.SelectedIndex != 0 && txtCName.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + txtCenterID.Text.Trim() + "' and c.center_name = '" + txtCName.Text.Trim() + "' and b.b_code = '" + cmbBranch.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() != "" && cmbBranch.SelectedIndex == 0 && txtCName.Text.Trim() != "" && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + txtCenterID.Text.Trim() + "' and c.center_name = '" + txtCName.Text.Trim() + "' and date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() != "" && cmbBranch.SelectedIndex != 0 && txtCName.Text.Trim() == "" && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + txtCenterID.Text.Trim() + "' and b.b_code = '" + cmbBranch.Text.Trim() + "' and date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() != "" && cmbBranch.SelectedIndex != 0 && txtCName.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + txtCenterID.Text.Trim() + "' and b.b_code = '" + cmbBranch.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() != "" && cmbBranch.SelectedIndex == 0 && txtCName.Text.Trim() == "" && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + txtCenterID.Text.Trim() + "' and date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() != "" && cmbBranch.SelectedIndex == 0 && txtCName.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + txtCenterID.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() == "" && cmbBranch.SelectedIndex != 0 && txtCName.Text.Trim() != "" && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.center_name = '" + txtCName.Text.Trim() + "' and b.b_code = '" + cmbBranch.Text.Trim() + "' and date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() == "" && cmbBranch.SelectedIndex != 0 && txtCName.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.center_name = '" + txtCName.Text.Trim() + "' and b.b_code = '" + cmbBranch.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() == "" && cmbBranch.SelectedIndex == 0 && txtCName.Text.Trim() != "" && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.center_name = '" + txtCName.Text.Trim() + "' and date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() == "" && cmbBranch.SelectedIndex != 0 && txtCName.Text.Trim() == "" && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.b_code = '" + cmbBranch.Text.Trim() + "' and date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() == "" && cmbBranch.SelectedIndex != 0 && txtCName.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.b_code = '" + cmbBranch.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() == "" && cmbBranch.SelectedIndex == 0 && txtCName.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.center_name = '" + txtCName.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtCenterID.Text.Trim() == "" && cmbBranch.SelectedIndex == 0 && txtCName.Text.Trim() == "" && txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() != "")
                {
                    lblMsg.Text = "Please enter From Date.";
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter To Date.";
                }
            }
            else
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idcenter_details asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
        }

        protected void loadDataToRepeater(string strQRY)
        {
            //int iCurrentPage = Convert.ToInt32(strCurrentPage);
            //COUNT ALL RECORDS
            DataSet dsAllData = objDBTask.selectData(strQRY);
            //iAllRows = dsAllData.Tables[0].Rows.Count;

            //GET RELEVANT DATA
            MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, objDBTask.establishConnection());
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

        protected void exportExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                //grvCenDeta.AllowPaging = false;
                //this.BindGrid();

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

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    exportExcel();
        //}

        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
        //       server control at run time. */
        //}
    }
}
