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
using System.IO;
using System.Drawing;

namespace MuslimAID.MURABHA
{
    public partial class Client_Basic_Details_Report : System.Web.UI.Page
    {
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    try
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
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            grvCliDeta.DataSource = null;
            grvCliDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            try
            {
                lblMsg.Text = "";
                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = "SELECT c.center_name AS Center,b.team_id,b.ca_code nic, b.contract_code ,b.initial_name full_name, b.p_address, b.mobile_no FROM micro_basic_detail b left outer join center_details c on b.city_code = c.city_code and b.society_id = c.idcenter_details left outer join micro_exective_root e on b.root_id = e.exe_id and e.branch_code = b.city_code WHERE idmicro_basic_detail > 0 ";
                if (cmbCityCode.SelectedIndex != 0 || ddlCro.SelectedIndex != 0 || ddlCenter.SelectedIndex != 0 || txtDateFrom.Text.Trim() != "" || cmbCenterDay.SelectedIndex != 0)
                {
                    if (cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.city_code = '" + cmbCityCode.SelectedValue.ToString() + "' ";
                        if (ddlCro.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and e.exe_id = '" + ddlCro.SelectedValue.ToString() + "' ";
                        }
                        if (ddlCenter.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + ddlCenter.SelectedValue.ToString() + "' ";
                        }
                    }
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and (DATE_FORMAT((b.date_time),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    if (cmbCenterDay.SelectedIndex != 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.center_day = '" + cmbCenterDay.SelectedValue.ToString() + "' ";
                    }
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void loadDataToRepeater(string strQRY)
        {
            //COUNT ALL RECORDS 
            DataSet dsAllData = cls_Connection.getDataSet(strQRY);
            MySqlCommand cmd = new MySqlCommand(strQRY, cls_Connection.DBConnect());
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            DataSet ds = objDBTask.selectData(cmd);
            DataTable dt = new DataTable();

            DataColumn pCenter = new DataColumn("Center", Type.GetType("System.String"));
            DataColumn pnic = new DataColumn("nic", Type.GetType("System.String"));
            DataColumn pcontra_code = new DataColumn("contra_code", Type.GetType("System.String"));
            DataColumn pfull_name = new DataColumn("full_name", Type.GetType("System.String"));
            DataColumn pp_address = new DataColumn("p_address", Type.GetType("System.String"));
            DataColumn pmobile_no = new DataColumn("mobile_no", Type.GetType("System.String"));
            dt.Columns.Add(pCenter);
            dt.Columns.Add(pcontra_code);
            dt.Columns.Add(pnic);
            dt.Columns.Add(pfull_name);
            dt.Columns.Add(pp_address);
            dt.Columns.Add(pmobile_no);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Center"] = ds.Tables[0].Rows[i]["Center"].ToString();
                    dr["nic"] = ds.Tables[0].Rows[i]["nic"].ToString();
                    dr["contra_code"] = ds.Tables[0].Rows[i]["contract_code"].ToString();
                    dr["full_name"] = ds.Tables[0].Rows[i]["full_name"].ToString();
                    dr["p_address"] = ds.Tables[0].Rows[i]["p_address"].ToString();
                    dr["mobile_no"] = ds.Tables[0].Rows[i]["mobile_no"].ToString();
                    dt.Rows.Add(dr);
                }

                grvCliDeta.DataSource = dt;
                grvCliDeta.DataBind();
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
                Response.AddHeader("content-disposition", "attachment;filename=Client_Basic_Details_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages

                    grvCliDeta.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in grvCliDeta.HeaderRow.Cells)
                    {
                        cell.BackColor = grvCliDeta.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in grvCliDeta.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grvCliDeta.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grvCliDeta.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grvCliDeta.RenderControl(hw);

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

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCro.Items.Count > 0)
                {
                    ddlCro.Items.Clear();
                }

                if (ddlCenter.Items.Count > 0)
                {
                    ddlCenter.Items.Clear();
                }
                DataSet dsCro;
                MySqlCommand cmdCro = new MySqlCommand("SELECT exe_id, exe_name FROM micro_exective_root WHERE branch_code = '" + cmbCityCode.SelectedValue.ToString() + "';");
                dsCro = objDBTask.selectData(cmdCro);
                ddlCro.Items.Add("Select CRO");
                for (int i = 0; i < dsCro.Tables[0].Rows.Count; i++)
                {
                    ddlCro.Items.Add(dsCro.Tables[0].Rows[i][1].ToString());
                    ddlCro.Items[i + 1].Value = dsCro.Tables[0].Rows[i][0].ToString();
                }

                DataSet dsCenter;
                MySqlCommand cmdCenter = new MySqlCommand("SELECT idcenter_details,concat(center_name, '-',villages) FROM center_details WHERE city_code = '" + cmbCityCode.SelectedValue.ToString() + "'");
                dsCenter = objDBTask.selectData(cmdCenter);
                ddlCenter.Items.Add("Select Center");
                for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                {
                    ddlCenter.Items.Add(dsCenter.Tables[0].Rows[i][1].ToString());
                    ddlCenter.Items[i + 1].Value = dsCenter.Tables[0].Rows[i][0].ToString();
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
