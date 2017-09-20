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
    public partial class Report_Insurance : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
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
                hstrSelectQuery.Value = "SELECT i.contact_code,b.date_time,b.nic,b.full_name,b.p_address,b.dob AS dateofbirth,b.city_code,format(l.loan_amount,2),l.period,i.insurance_code,i.insured FROM insurance_details i,micro_basic_detail b,micro_loan_details l,micro_family_details f WHERE b.contract_code = i.contact_code AND f.contract_code = i.contact_code AND f.contract_code = l.contra_code AND i.module = 'MBR'";
                if (cmbCityCode.SelectedIndex > 0)
                    hstrSelectQuery.Value += " AND b.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                if (cmbArea.SelectedIndex > 0)
                    hstrSelectQuery.Value += " AND b.area_code ='" + cmbArea.SelectedValue.ToString() + "'";
                if(cmbVillage.SelectedIndex >0)
                    hstrSelectQuery.Value += " AND b.village ='" + cmbVillage.SelectedValue.ToString() + "'";
                if (txtContraCode.Text.Trim() != "")
                    hstrSelectQuery.Value += " AND i.contact_code = '" + txtContraCode.Text.Trim() + "'";
                if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    DateTime strTo = DateTime.ParseExact(txtDateTo.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    DateTime strStart = DateTime.ParseExact(txtDateFrom.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    hstrSelectQuery.Value += " AND i.created_date BETWEEN '" + strStart.ToString("yyyy-MM-dd") + "' AND '" + strTo.ToString("yyyy-MM-dd") + "'";
                }
                hstrSelectQuery.Value = hstrSelectQuery.Value + " ORDER BY i.auto_id ASC;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            catch (Exception ex)
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
            grvCliDeta.DataSource = dsSelectData;
            grvCliDeta.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlClientDetail.Visible = true;
                pnlSummery.Visible = true;
                pnlNoData.Visible = false;

                string strSummery;
                hstrSelectQuery1.Value = "";
                hstrSelectQuery1.Value = "select count(s.contract_code),sum(l.loan_amount) from micro_service_charges s,micro_basic_detail b,micro_loan_details l,micro_family_details f where b.contract_code = s.contract_code and f.contract_code = s.contract_code and f.contract_code = l.contra_code and s.payment_status = 'D'";
                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
                {
                    if (cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    if (txtContraCode.Text.Trim() != "")
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and s.contract_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and (DATE_FORMAT((s.date_time),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by s.idmicro_service_charges asc;";             
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        string strCount = dsSummery.Tables[0].Rows[0][0].ToString();
                        decimal decCount = Convert.ToDecimal(strCount);
                        lblNoIns.Text = strCount;
                        string strLoan = dsSummery.Tables[0].Rows[0][1].ToString();
                        decimal decAmount = Convert.ToDecimal(strLoan);
                        lblInsAmount.Text = decAmount.ToString("#,##0.00");
                    }
                }
                else
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by s.idmicro_service_charges asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        string strCount = dsSummery.Tables[0].Rows[0][0].ToString();
                        decimal decCount = Convert.ToDecimal(strCount);
                        lblNoIns.Text = strCount;
                        string strLoan = dsSummery.Tables[0].Rows[0][1].ToString();
                        decimal decAmount = Convert.ToDecimal(strLoan);
                        lblInsAmount.Text = decAmount.ToString("#,##0.00");
                    }
                }
            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
                pnlClientDetail.Visible = false;
                pnlSummery.Visible = false;
                pnlNoData.Visible = false;
            }
        }

        //Export Excel----------------------------------
        protected void exportExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Insurance_Report.xls");
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


        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbVillage.Items.Count > 0)
                cmbVillage.Items.Clear();

            if (cmbVillagr.Items.Count > 0)
                cmbVillagr.Items.Clear();

            txtContraCode.Text = "";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";

            try
            {


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
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load villages according to selected area");
                return;
            }
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVillagr.Items.Count > 0)
                cmbVillagr.Items.Clear();

            txtContraCode.Text = "";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";

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
                        cmbVillagr.Items.Clear();
                        if (dsSCenter.Tables[0].Rows.Count > 0)
                        {
                            cmbVillagr.Items.Add("Select Center");

                            for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                            {
                                cmbVillagr.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                                cmbVillagr.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                            }
                        }
                        cmbVillagr.Enabled = true;
                        //Edit 2014.09.18 CACode
                        //CACodeNew();
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

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCityCode.SelectedIndex != 0)
            {
                if (cmbArea.Items.Count > 0)
                    cmbArea.Items.Clear();

                if (cmbVillage.Items.Count > 0)
                    cmbVillage.Items.Clear();

                if (cmbVillagr.Items.Count > 0)
                    cmbVillagr.Items.Clear();

                txtContraCode.Text = "";
                txtDateFrom.Text = "";
                txtDateTo.Text = "";

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
            }
            else
            {
                lblMsg.Text = "Please select branch";
                btnSerch.Enabled = false;
            }
        }
    }
}
