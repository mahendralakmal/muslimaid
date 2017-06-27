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
    public partial class Report_Guarantor_Details : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        string Promisers1ContractCode = "", Promisers1Name = "", mobile_no;

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
                Response.Redirect("../Default.aspx");
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
                hstrSelectQuery.Value = "SELECT c.center_name AS Center,b.team_id,b.ca_code nic, l.contra_code ,b.full_name,b.land_no, b.promisers_id, '' promisers1_contra_code,'' promisers1_full_name, '' land_no1, b.promiser_id_2, '' promisers2_contra_code,'' promisers2_full_name, '' land_no2 FROM center_details c, micro_loan_details l, micro_basic_detail b, micro_exective_root e WHERE b.contract_code= l.contra_code AND b.city_code = c.city_code AND b.root_id = e.exe_id AND b.society_id = c.idcenter_details AND e.branch_code = b.city_code and b.team_id != '' ";
                if (cmbCityCode.SelectedIndex != 0 || cmbRoot.SelectedIndex != 0 || cmbCenter.SelectedIndex != 0 || txtDateFrom.Text.Trim() != "" || cmbCenterDay.SelectedIndex != 0)
                {
                    if (cmbCityCode.SelectedIndex != 0 && cmbCityCode.SelectedIndex > 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and city_code = '" + cmbCityCode.SelectedValue.ToString() + "' ";

                        if (cmbArea.SelectedIndex != 0 && cmbArea.SelectedIndex > 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and area_code = '" + cmbArea.SelectedValue.ToString() + "' ";
                        }
                        if (cmbVillage.SelectedIndex != 0 && cmbVillage.SelectedIndex > 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and villages_code = '" + cmbVillage.SelectedValue.ToString() + "' ";
                        }
                        if (cmbRoot.SelectedIndex != 0 && cmbRoot.SelectedIndex > 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and exe_id = '" + cmbRoot.SelectedValue.ToString() + "' ";
                        }
                        if (cmbCenter.SelectedIndex != 0 && cmbCenter.SelectedIndex > 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and auto_id = '" + cmbCenter.SelectedValue.ToString() + "' ";
                        }
                    }
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and (DATE_FORMAT((date_time),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    if (cmbCenterDay.SelectedIndex != 0 && cmbCenterDay.SelectedIndex > 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and center_day = '" + cmbCenterDay.SelectedValue.ToString() + "' ";
                    }
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
            }
            catch (Exception e)
            {
                cls_ErrorLog.createSErrorLog(e.Message, e.Source, "Guaranter details");
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
            DataColumn pteam_id = new DataColumn("team_id", Type.GetType("System.String"));
            DataColumn pnic = new DataColumn("nic", Type.GetType("System.String"));
            DataColumn pcontra_code = new DataColumn("contra_code", Type.GetType("System.String"));
            DataColumn pfull_name = new DataColumn("full_name", Type.GetType("System.String"));
            DataColumn pmobile_no = new DataColumn("mobile_no", Type.GetType("System.String"));
            DataColumn ppromisers_id = new DataColumn("promisers_id", Type.GetType("System.String"));
            DataColumn ppromisers1_contra_code = new DataColumn("promisers1_contra_code", Type.GetType("System.String"));
            DataColumn promisers1_full_name = new DataColumn("promisers1_full_name", Type.GetType("System.String"));
            DataColumn pmobile_no1 = new DataColumn("mobile_no1", Type.GetType("System.String"));
            DataColumn ppromiser_id_2 = new DataColumn("promiser_id_2", Type.GetType("System.String"));
            DataColumn ppromisers2_contra_code = new DataColumn("promisers2_contra_code", Type.GetType("System.String"));
            DataColumn ppromisers2_full_name = new DataColumn("promisers2_full_name", Type.GetType("System.String"));
            DataColumn pmobile_no2 = new DataColumn("mobile_no2", Type.GetType("System.String"));

            dt.Columns.Add(pCenter);
            dt.Columns.Add(pteam_id);
            dt.Columns.Add(pcontra_code);
            dt.Columns.Add(pnic);
            dt.Columns.Add(pfull_name);
            dt.Columns.Add(pmobile_no);
            dt.Columns.Add(ppromisers_id);
            dt.Columns.Add(ppromisers1_contra_code);
            dt.Columns.Add(promisers1_full_name);
            dt.Columns.Add(pmobile_no1);
            dt.Columns.Add(ppromiser_id_2);
            dt.Columns.Add(ppromisers2_contra_code);
            dt.Columns.Add(ppromisers2_full_name);
            dt.Columns.Add(pmobile_no2);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Center"] = ds.Tables[0].Rows[i]["Center"].ToString();
                    dr["team_id"] = ds.Tables[0].Rows[i]["team_id"].ToString();
                    dr["nic"] = ds.Tables[0].Rows[i]["nic"].ToString();
                    dr["contra_code"] = ds.Tables[0].Rows[i]["contra_code"].ToString();
                    dr["full_name"] = ds.Tables[0].Rows[i]["full_name"].ToString();
                    dr["mobile_no"] = ds.Tables[0].Rows[i]["land_no"].ToString();
                    dr["promisers_id"] = ds.Tables[0].Rows[i]["promisers_id"].ToString();
                    Promisers(ds.Tables[0].Rows[i]["promisers_id"].ToString());
                    dr["promisers1_contra_code"] = Promisers1ContractCode;
                    dr["promisers1_full_name"] = Promisers1Name;
                    dr["mobile_no1"] = mobile_no;
                    Promisers(ds.Tables[0].Rows[i]["promiser_id_2"].ToString());
                    dr["promiser_id_2"] = ds.Tables[0].Rows[i]["promiser_id_2"].ToString();
                    dr["promisers2_contra_code"] = Promisers1ContractCode;
                    dr["promisers2_full_name"] = Promisers1Name;
                    dr["mobile_no2"] = mobile_no;
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

        private void Promisers(string ca_code)
        {
            try
            {
                string strQRY = "select contract_code, full_name,land_no from micro_basic_detail where ca_code = '" + ca_code + "'";
                MySqlCommand cmd = new MySqlCommand(strQRY, cls_Connection.DBConnect());
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                DataSet ds = objDBTask.selectData(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Promisers1ContractCode = ds.Tables[0].Rows[0]["contract_code"].ToString();
                    Promisers1Name = ds.Tables[0].Rows[0]["full_name"].ToString();
                    mobile_no = ds.Tables[0].Rows[0]["land_no"].ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex != 0)
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
                    DataSet dsVillage = cls_Connection.getDataSet("select * from area where branch_code = '" + cmbCityCode.SelectedItem.Value + "' ORDER BY area");
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
                    string strBranch = cmbCityCode.SelectedItem.Value;

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
        }

        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (cmbCityCode.SelectedIndex == 0)
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

                    DataSet dsSocietyName = cls_Connection.getDataSet("SELECT villages_code,villages_name FROM villages_name WHERE city_code = '" + cmbCityCode.SelectedItem.Value + "' AND area_code ='" + cmbArea.SelectedItem.Value + "';");
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
                if (cmbVillage.SelectedIndex != 0 && cmbCityCode.SelectedIndex != 0 && cmbArea.SelectedIndex != 0)
                {
                    DataSet dsGetSocietyID = cls_Connection.getDataSet("select exective from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "' and area_code = '" + cmbArea.SelectedItem.Value + "' and villages = '" + cmbVillage.SelectedItem.Value + "';");
                    if (dsGetSocietyID.Tables[0].Rows.Count > 0)
                    {
                        //txtSoNumber.Text = cmbSocietyName.SelectedItem.Value.ToString();

                        DataSet dsSCenter = cls_Connection.getDataSet("SELECT idcenter_details, center_name, center_day FROM center_details WHERE city_code = '" + cmbCityCode.SelectedItem.Value + "' AND area_code = '" + cmbArea.SelectedItem.Value + "' AND villages = '" + cmbVillage.SelectedItem.Value + "';");
                        cmbCenter.Items.Clear();
                        if (dsSCenter.Tables[0].Rows.Count > 0)
                        {
                            cmbCenter.Items.Add("Select Center");

                            for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                            {
                                cmbCenter.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                                cmbCenter.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                            }
                        }
                        cmbCenter.Enabled = true;
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

        protected void View_Click(object sender, EventArgs e)
        {
            exportExcel();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        //Export Excel----------------------------------
        protected void exportExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Guarantor_Details.xls");
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
    }
}
