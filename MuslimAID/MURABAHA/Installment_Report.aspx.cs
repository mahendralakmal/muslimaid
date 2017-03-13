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
    public partial class Installment_Report : System.Web.UI.Page
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
                        cmbBranch.Items.Add("");
                        for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                        {
                            cmbBranch.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                            cmbBranch.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
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
                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbRoot.SelectedIndex != 0 || cmbBranch.SelectedIndex != 0)
                {
                    if (cmbBranch.SelectedIndex != 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.city_code = '" + cmbBranch.SelectedValue.ToString() + "'";
                        if (cmbRoot.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and e.exe_id = '" + cmbRoot.SelectedValue.ToString() + "'";
                        }
                        if (cmbCenter.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and society_id = '" + cmbCenter.SelectedValue.ToString() + "'";
                        }
                    }
                    if (txtContraCode.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and p.contra_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and (DATE_FORMAT((p.date_time),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
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
                    if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbRoot.SelectedIndex != 0 || cmbBranch.SelectedIndex != 0)
                    {
                        if (cmbBranch.SelectedIndex != 0)
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.city_code = '" + cmbBranch.SelectedValue.ToString() + "'";
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
            try
            {
                if (cmbRoot.Items.Count > 0)
                {
                    cmbRoot.Items.Clear();
                }
                if (cmbCenter.Items.Count > 0)
                {
                    cmbCenter.Items.Clear();
                }

                DataSet dsCro;
                MySqlCommand cmdCro = new MySqlCommand("SELECT exe_id, exe_name FROM micro_exective_root WHERE branch_code = '" + cmbBranch.SelectedValue.ToString() + "';");
                dsCro = objDBTask.selectData(cmdCro);
                cmbRoot.Items.Add("Select CRO");
                for (int i = 0; i < dsCro.Tables[0].Rows.Count; i++)
                {
                    cmbRoot.Items.Add(dsCro.Tables[0].Rows[i][1].ToString());
                    cmbRoot.Items[i + 1].Value = dsCro.Tables[0].Rows[i][0].ToString();
                }

                DataSet dsCenter;
                MySqlCommand cmdCenter = new MySqlCommand("SELECT idcenter_details,concat(center_name, '-',villages) FROM center_details WHERE city_code = '" + cmbBranch.SelectedValue.ToString() + "'");
                dsCenter = objDBTask.selectData(cmdCenter);
                cmbCenter.Items.Add("Select Center");
                for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                {
                    cmbCenter.Items.Add(dsCenter.Tables[0].Rows[i][1].ToString());
                    cmbCenter.Items[i + 1].Value = dsCenter.Tables[0].Rows[i][0].ToString();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
