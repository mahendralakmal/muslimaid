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
                hstrSelectQuery.Value = "SELECT s.contract_code,b.nic,b.initial_name,b.p_address,b.dob,s.city_code,format(l.loan_amount,2),l.period,f.spouse_name,f.spouse_nic,(DATE_FORMAT((l.chequ_deta_on),'%Y-%m-%d')) date_time,f.spouse_relationship_with_applicant,f.spouse_dob Sdateofbirth FROM micro_service_charges s,micro_basic_detail b,micro_loan_details l,micro_family_details f WHERE b.contract_code = s.contract_code AND f.contract_code = s.contract_code AND f.contract_code = l.contra_code AND s.payment_status = 'D'";
                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
                {
                    if (cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " AND s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    if (txtContraCode.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " AND s.contract_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " AND (DATE_FORMAT((s.date_time),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' AND '" + txtDateTo.Text.Trim() + "'";
                    }
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " ORDER BY s.idmicro_service_charges ASC;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " ORDER BY s.idmicro_service_charges ASC;";
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
    }
}
