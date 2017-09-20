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
using System.Globalization;

namespace MuslimAID.MURABHA
{
    public partial class Report_Installment : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
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

        protected void GetSearch()
        {
            try
            {               
                lblMsg.Text = "";
                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = @"select p.idpais_history,e.exe_name,b.team_id,cs.center_name society_id,1 NoCustomer,p.contra_code,b.ca_code nic,b.initial_name,l.loan_amount,FORMAT(p.paied_amount,2) paied_amount,(DATE_FORMAT((p.date_time),'%Y-%m-%d')) date_time,remark from micro_basic_detail b inner join micro_pais_history p on p.contra_code = b.contract_code inner join micro_exective_root e on b.root_id = e.exe_id and b.city_code = e.branch_code inner join micro_loan_details l on l.contra_code = b.contract_code inner join center_details cs on b.society_id = cs.idcenter_details and b.city_code = cs.city_code where p.tra_description = 'WI' and p.pay_status = 'D' ";
                if (cmbCityCode.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and b.city_code = '" + cmbCityCode.SelectedValue.ToString() + "' ";
                if (cmbArea.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and b.area_code = '" + cmbArea.SelectedValue.ToString() + "' ";
                if (cmbVillage.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and b.village = '" + cmbVillage.SelectedValue.ToString() + "' ";
                if (cmbCenter.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and b.society_id = '" + cmbCenter.SelectedValue.ToString() + "' ";
                if (cmbRoot.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and e.exe_id = '" + cmbRoot.SelectedValue.ToString() + "' ";
                if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    DateTime strTo = DateTime.ParseExact(txtDateTo.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    DateTime strStart = DateTime.ParseExact(txtDateFrom.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    hstrSelectQuery.Value += " and c.date_time BETWEEN '" + strStart.ToString() + "' and '" + strTo.ToString() + "'";
                }
                if(txtContraCode.Text.ToString() != "")
                    hstrSelectQuery.Value += " and b.contract_code = '" + txtContraCode.Text.ToString() + "' ";
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                loadDataToRepeater(hstrSelectQuery.Value);

            }
            catch (Exception)
            {

            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            lblInsAmount.Text = "";
            lblMsg.Text = "";
            lblNoIns.Text = "";
            pnlSummery.Visible = false;
            grvMIn.DataSource = null;
            grvMIn.DataBind();

            GetSearch();
        }

        protected void loadDataToRepeater(string strQRY)
        {
            try
            {
                //int iCurrentPage = Convert.ToInt32(strCurrentPage);
                //COUNT ALL RECORDS
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                //iAllRows = dsAllData.Tables[0].Rows.Count;

                //GET RELEVANT DATA
                MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, cls_Connection.DBConnect());
                DataSet dsSelectData = new DataSet();
                daData.Fill(dsSelectData);
                grvMIn.DataSource = dsSelectData;
                grvMIn.DataBind();

                if (dsSelectData.Tables[0].Rows.Count > 0)
                {
                    pnlSummery.Visible = true;
                    string strSummery;
                    hstrSelectQuery1.Value = "";
                    hstrSelectQuery1.Value = "select count(p.contra_code),sum(p.paied_amount) from micro_pais_history p,micro_basic_detail c where p.tra_description = 'WI' and p.pay_status = 'D' and p.contra_code = c.contract_code";
                    if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbRoot.SelectedIndex != 0 || cmbCityCode.SelectedIndex != 0)
                    {
                        if (cmbCityCode.SelectedIndex != 0)
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                            if (cmbCenter.SelectedIndex != 0)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and society_id = '" + cmbCenter.SelectedValue.ToString() + "'";
                            }
                            if (cmbRoot.SelectedIndex != 0)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.root_id = '" + cmbRoot.SelectedValue.ToString() + "'";
                            }
                        }
                        if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and (DATE_FORMAT((p.date_time),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                        }
                        if (txtContraCode.Text.Trim() != "")
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and p.contra_code = '" + txtContraCode.Text.Trim() + "'";
                        }

                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by p.idpais_history asc;";
                        strSummery = hstrSelectQuery1.Value;
                        DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                        if (dsSummery.Tables[0].Rows.Count > 0)
                        {
                            lblNoIns.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                            lblInsAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                        }
                    }
                    else
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by p.idpais_history asc;";
                        strSummery = hstrSelectQuery1.Value;
                        DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                        if (dsSummery.Tables[0].Rows.Count > 0)
                        {
                            lblNoIns.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                            lblInsAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "No records found for your search criteria. Please try again.";
                }
            }
            catch (Exception)
            {
            }
        }

        //Export Excel----------------------------------
        protected void exportExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Collection_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages

                    grvMIn.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in grvMIn.HeaderRow.Cells)
                    {
                        cell.BackColor = grvMIn.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in grvMIn.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grvMIn.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grvMIn.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grvMIn.RenderControl(hw);

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
    }
}
