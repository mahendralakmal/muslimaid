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
using Microsoft.VisualBasic;

namespace MuslimAID.MURABHA
{
    public partial class Report_Arrears_Details : System.Web.UI.Page
    {
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

        protected void GetSearch()
        {
            try
            {
                lblMsg.Text = "";
                hstrSelectQuery.Value = "";

                hstrSelectQuery.Value = "select e.exe_name AS `CRO`,cs.center_name AS `Center`,c.team_id AS `Group`,l.contra_code AS `Facility No`, c.initial_name AS `Customer Name`, c.ca_code AS `Customer Code`, FORMAT(l.loan_amount,2) AS `Loan Amount`, FORMAT(0.00,2) `Capital Outstanding`,FORMAT(l.arres_amou,2) AS `Total Arrears`,FORMAT(l.current_loan_amount,2) AS `Total Outstanding`, 0 `Last Payment Amount`, MAX(DATE_FORMAT(P.date_time,'%Y-%m-%d')) `Last Payment date`,l.loan_sta AS `Facility Status` from micro_basic_detail c inner join micro_loan_details l on l.contra_code = c.contract_code inner join micro_payme_summery p on l.contra_code = p.contra_code inner join micro_exective_root e on c.root_id = e.exe_id AND c.city_code = e.branch_code inner join center_details cs on c.society_id = cs.idcenter_details and c.city_code = cs.city_code where  l.arres_amou > 0 and l.loan_sta != 'C' ";
                if (cmbCityCode.SelectedIndex != 0 || cmbRoot.SelectedIndex != 0 || cmbVillagr.SelectedIndex != 0 || txtContraCode.Text.Trim() != "" || cmbStatus.SelectedIndex != -1 || cmbACount.SelectedIndex != 0)
                {
                    if (cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                        if (cmbRoot.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.root_id = '" + cmbRoot.SelectedValue.ToString() + "' ";
                        }
                        if (cmbVillagr.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.society_id = '" + cmbVillagr.SelectedValue.ToString() + "' ";
                        }
                    }
                    
                    if (txtContraCode.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' ";
                    }
                    if (cmbStatus.SelectedValue.ToString() == "D")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = 'E' ";
                    }
                    if (cmbACount.SelectedIndex != 0)
                    {
                        if (cmbACount.SelectedIndex < 5)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and (l.arres_amou/l.monthly_instollment) <= '" + (cmbACount.SelectedValue) + "' and (l.arres_amou/l.monthly_instollment) > '" + (cmbACount.SelectedValue) + "' - 1 ";
                        }
                        else
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and (l.arres_amou/l.monthly_instollment) > 4 ";
                        }
                    }
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " group by P.contra_code having sum(P.debit) !=0 order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " group by P.contra_code having sum(P.debit) !=0 order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
            }
            catch (Exception)
            {
            }
        }

        private string LastPaymentAmount(string CusCode)
        {
            try
            {
                string LastPaymentAmount = "0.00";
                string strQRY = "SELECT IFNULL(amount, 0) AS amount FROM micro_payme_summery  WHERE contra_code = '" + CusCode + "' AND p_type = 'WI' AND p_status = 'D' and amount <> 0 ORDER BY date_time DESC LIMIT 1;";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    LastPaymentAmount = dsAllData.Tables[0].Rows[0]["amount"].ToString();
                }
                else
                {
                    LastPaymentAmount = "0.00";
                }
                return LastPaymentAmount;
            }
            catch (Exception)
            {
                return "0.00";
            }
        }

        private string LastPaymentDate(string CusCode)
        {
            try
            {
                string LastPaymentDate = "0.00";
                string strQRY = "SELECT DATE_FORMAT(date_time,'%Y-%m-%d') date_time FROM micro_payme_summery  WHERE contra_code = '" + CusCode + "' AND p_type = 'WI' AND p_status = 'D' and amount <> 0 ORDER BY date_time DESC LIMIT 1;";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    LastPaymentDate = dsAllData.Tables[0].Rows[0]["date_time"].ToString();
                }
                else
                {
                    LastPaymentDate = "";
                }
                return LastPaymentDate;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private decimal CapitalOutstanding(string CusCode, decimal LoanAmount)
        {
            try
            {
                decimal TotalCapital = 0;
                string strQRY = "SELECT IFNULL(sum(paid_capital), 0) AS capital FROM paid_cap_int WHERE contra_code = '" + CusCode + "';;";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    TotalCapital = LoanAmount - Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["capital"]);
                }
                else
                {
                    TotalCapital = 0;
                }
                return TotalCapital;
            }
            catch (Exception)
            {
                return 0;
            }
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

                DataTable dtS = new DataTable();
                DataColumn pCRO = new DataColumn("CRO", Type.GetType("System.String"));
                DataColumn pCenter = new DataColumn("Center", Type.GetType("System.String"));
                DataColumn pGROUP = new DataColumn("Group", Type.GetType("System.String"));
                DataColumn pFacility_No = new DataColumn("Facility No", Type.GetType("System.String"));
                DataColumn pClient_Name = new DataColumn("Customer Name", Type.GetType("System.String"));
                DataColumn pCustomerCode = new DataColumn("Customer Code", Type.GetType("System.String"));
                DataColumn pLoan_Amount = new DataColumn("Loan Amount", Type.GetType("System.String"));
                DataColumn pCapitalOutstanding = new DataColumn("Capital Outstanding", Type.GetType("System.String"));
                DataColumn pTotalOutstanding = new DataColumn("Total Outstanding", Type.GetType("System.String"));
                DataColumn pTotalArrears = new DataColumn("Total Arrears", Type.GetType("System.String"));
                DataColumn pLastPaymentAmount = new DataColumn("Last Payment Amount", Type.GetType("System.String"));
                DataColumn pLastPaymentdate = new DataColumn("Last Payment date", Type.GetType("System.String"));
                DataColumn pFacility_Status = new DataColumn("Facility Status", Type.GetType("System.String"));

                dtS.Columns.Add(pCRO);
                dtS.Columns.Add(pCenter);
                dtS.Columns.Add(pGROUP);
                dtS.Columns.Add(pFacility_No);
                dtS.Columns.Add(pClient_Name);
                dtS.Columns.Add(pCustomerCode);
                dtS.Columns.Add(pLoan_Amount);
                dtS.Columns.Add(pCapitalOutstanding);
                dtS.Columns.Add(pTotalOutstanding);
                dtS.Columns.Add(pTotalArrears);
                dtS.Columns.Add(pLastPaymentAmount);
                dtS.Columns.Add(pLastPaymentdate);
                dtS.Columns.Add(pFacility_Status);

                for (int i = 0; i < dsSelectData.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dtS.NewRow();
                    dr["CRO"] = dsSelectData.Tables[0].Rows[i]["CRO"].ToString();
                    dr["Center"] = dsSelectData.Tables[0].Rows[i]["Center"].ToString();
                    dr["Group"] = dsSelectData.Tables[0].Rows[i]["Group"].ToString();
                    dr["Facility No"] = dsSelectData.Tables[0].Rows[i]["Facility No"].ToString();
                    dr["Customer Name"] = dsSelectData.Tables[0].Rows[i]["Customer Name"].ToString();
                    dr["Customer Code"] = dsSelectData.Tables[0].Rows[i]["Customer Code"].ToString();
                    dr["Loan Amount"] = dsSelectData.Tables[0].Rows[i]["Loan Amount"].ToString();
                    dr["Capital Outstanding"] = CapitalOutstanding(dsSelectData.Tables[0].Rows[i]["Facility No"].ToString(), Convert.ToDecimal(dsSelectData.Tables[0].Rows[i]["Loan Amount"])).ToString();
                    dr["Total Outstanding"] = dsSelectData.Tables[0].Rows[i]["Total Outstanding"].ToString();
                    dr["Total Arrears"] = dsSelectData.Tables[0].Rows[i]["Total Arrears"].ToString();
                    dr["Last Payment Amount"] = LastPaymentAmount(dsSelectData.Tables[0].Rows[i]["Facility No"].ToString()).ToString();
                    dr["Last Payment date"] = LastPaymentDate(dsSelectData.Tables[0].Rows[i]["Facility No"].ToString()).ToString();
                    dr["Facility Status"] = dsSelectData.Tables[0].Rows[i]["Facility Status"].ToString();
                    dtS.Rows.Add(dr);
                }

                grvArRep.DataSource = dtS;
                grvArRep.DataBind();

                if (dsSelectData.Tables[0].Rows.Count > 0)
                {
                    pnlSummery.Visible = true;
                    string strSummery = "";
                    hstrSelectQuery1.Value = "";

                    hstrSelectQuery1.Value = "select count(l.contra_code),sum(l.arres_amou) from micro_basic_detail c, micro_loan_details l where l.contra_code = c.contract_code and l.arres_amou > 0 and l.loan_sta != 'C'";
                    if (cmbCityCode.SelectedIndex != 0 || cmbRoot.SelectedIndex != 0 || cmbVillagr.SelectedIndex != 0 || txtContraCode.Text.Trim() != "" || cmbStatus.SelectedIndex != -1 || cmbACount.SelectedIndex != 0)
                    {
                        if (cmbCityCode.SelectedIndex != 0)
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                            if (cmbRoot.SelectedIndex != 0)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.root_id = '" + cmbRoot.SelectedValue.ToString() + "' ";
                            }
                            if (cmbVillagr.SelectedIndex != 0)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.society_id = '" + cmbVillagr.SelectedValue.ToString() + "' ";
                            }
                        }
                        
                        if (txtContraCode.Text.Trim() != "")
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' ";
                        }
                        if (cmbStatus.SelectedValue.ToString() == "D")
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.loan_sta = 'E' ";
                        }
                        if (cmbACount.SelectedIndex != 0)
                        {
                            if (cmbACount.SelectedIndex < 5)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and (l.arres_amou/l.monthly_instollment) <= '" + (cmbACount.SelectedValue) + "' and (l.arres_amou/l.monthly_instollment) > '" + (cmbACount.SelectedValue) + "' - 1 ";
                            }
                            else
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and (l.arres_amou/l.monthly_instollment) > 4 ";
                            }
                        }
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    }
                    else
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    }

                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
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

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            lblNoArres.Text = "";
            lblMsg.Text = "";
            lblArreAmount.Text = "";
            pnlSummery.Visible = false;
            grvArRep.DataSource = null;
            grvArRep.DataBind();

            GetSearch();
        }

        //Export Excel----------------------------------
        protected void exportExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Arrears_Details_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages

                    grvArRep.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in grvArRep.HeaderRow.Cells)
                    {
                        cell.BackColor = grvArRep.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in grvArRep.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grvArRep.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grvArRep.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grvArRep.RenderControl(hw);

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
                if (cmbCityCode.SelectedIndex != 0)
                {
                    cmbRoot.Enabled = true;
                    cmbVillagr.Enabled = true;

                    if (cmbVillagr.Items.Count > 0)
                    {
                        cmbVillagr.Items.Clear();
                    }

                    if (cmbRoot.Items.Count > 0)
                    {
                        cmbRoot.Items.Clear();
                    }

                    string strBranch = cmbCityCode.SelectedItem.Value;

                    //Get Center
                    DataSet dsGetVillge = cls_Connection.getDataSet("select villages,center_name,idcenter_details from center_details where city_code = '" + strBranch + "'");
                    if (dsGetVillge.Tables[0].Rows.Count > 0)
                    {
                        cmbVillagr.Items.Add("");
                        for (int i = 0; i < dsGetVillge.Tables[0].Rows.Count; i++)
                        {                            
                            cmbVillagr.Items.Add(dsGetVillge.Tables[0].Rows[i]["center_name"].ToString());
                            cmbVillagr.Items[i + 1].Value = dsGetVillge.Tables[0].Rows[i]["idcenter_details"].ToString();
                        }
                    }

                    //Get CRO
                    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");

                    cmbRoot.Items.Add("");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbRoot.Items.Add(dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
                    }
                }
                else
                {
                    if (cmbRoot.Items.Count > 0)
                    {
                        cmbRoot.Items.Clear();
                    }

                    if (cmbVillagr.Items.Count > 0)
                    {
                        cmbVillagr.Items.Clear();
                    }

                    cmbVillagr.Enabled = false;

                    cmbRoot.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
