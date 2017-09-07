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
    public partial class Report_Loan_Detail : System.Web.UI.Page
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
            grvLoanDeta.DataSource = null;
            grvLoanDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            try
            {
                lblMsg.Text = "";
                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = "select l.contra_code,FORMAT(l.loan_amount,2) loan_amount,FORMAT(l.service_charges,2) service_charges,FORMAT(l.other_charges,2) other_charges,l.interest_rate,FORMAT(l.interest_amount,2) interest_amount,l.period,FORMAT(l.monthly_instollment,2) monthly_instollment,FORMAT(l.walfare_fee,2) walfare_fee,FORMAT(l.registration_fee,2) registration_fee,center_name,c.full_name AS initial_name,exe_name,team_id,chequ_deta_on from micro_loan_details l, micro_basic_detail c , center_details f, micro_exective_root e where c.contract_code = l.contra_code and c.society_id = f.idcenter_details AND f.city_code = c.city_code and c.root_id = e.exe_id AND c.city_code = e.branch_code ";

                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0 || cmbVillagr.SelectedIndex != 0 || cmbRoot.SelectedIndex != 0 || cmbStatus.SelectedIndex != 0)
                {
                    if (cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                        if (cmbRoot.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.root_id = '" + cmbRoot.SelectedItem.Value + "'";
                        }
                        if (cmbVillagr.SelectedIndex != 0)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.society_id = '" + cmbVillagr.SelectedValue.ToString() + "' ";
                        }
                    }
                    if (cmbStatus.SelectedIndex != 0)
                    {
                        if (cmbStatus.SelectedIndex == 1)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = 'P' and loan_approved = 'P'";
                        }
                        else if (cmbStatus.SelectedIndex == 2)
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = 'P' and loan_approved = 'Y'";
                        }
                        else
                        {
                            hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = '" + cmbStatus.SelectedItem.Value + "'";
                        }
                    }
                    if (txtContraCode.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                    {
                        hstrSelectQuery.Value = hstrSelectQuery.Value + " and (DATE_FORMAT((l.created_on),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' ";
                    }
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void loadDataToRepeater(string strQRY)
        {
            try
            {
                double dblCount_IA = 0;
                //int iCurrentPage = Convert.ToInt32(strCurrentPage);
                //COUNT ALL RECORDS
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                //iAllRows = dsAllData.Tables[0].Rows.Count;

                //GET RELEVANT DATA
                MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, cls_Connection.DBConnect());
                DataSet dsSelectData = new DataSet();
                daData.Fill(dsSelectData);

                if (dsSelectData.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    DataColumn pcontra_code = new DataColumn("contra_code", Type.GetType("System.String"));
                    DataColumn ploan_amount = new DataColumn("loan_amount", Type.GetType("System.String"));
                    DataColumn pservice_charges = new DataColumn("service_charges", Type.GetType("System.String"));
                    DataColumn pother_charges = new DataColumn("other_charges", Type.GetType("System.String"));
                    DataColumn pinterest_rate = new DataColumn("interest_rate", Type.GetType("System.String"));
                    DataColumn pinterest_amount = new DataColumn("interest_amount", Type.GetType("System.String"));
                    DataColumn pperiod = new DataColumn("period", Type.GetType("System.String"));
                    DataColumn pmonthly_instollment = new DataColumn("monthly_instollment", Type.GetType("System.String"));
                    DataColumn pwalfare_fee = new DataColumn("walfare_fee", Type.GetType("System.String"));
                    DataColumn pregistration_fee = new DataColumn("registration_fee", Type.GetType("System.String"));
                    DataColumn pcenter_name = new DataColumn("center_name", Type.GetType("System.String"));
                    DataColumn pinitial_name = new DataColumn("initial_name", Type.GetType("System.String"));
                    DataColumn pexe_name = new DataColumn("exe_name", Type.GetType("System.String"));
                    DataColumn pteam_id = new DataColumn("team_id", Type.GetType("System.String"));
                    DataColumn pchequ_deta_on = new DataColumn("chequ_deta_on", Type.GetType("System.String"));
                    DataColumn pIRR = new DataColumn("IRR", Type.GetType("System.String"));

                    dt.Columns.Add(pcontra_code);
                    dt.Columns.Add(ploan_amount);
                    dt.Columns.Add(pservice_charges);
                    dt.Columns.Add(pother_charges);
                    dt.Columns.Add(pinterest_rate);
                    dt.Columns.Add(pinterest_amount);
                    dt.Columns.Add(pperiod);
                    dt.Columns.Add(pmonthly_instollment);
                    dt.Columns.Add(pwalfare_fee);
                    dt.Columns.Add(pregistration_fee);
                    dt.Columns.Add(pcenter_name);
                    dt.Columns.Add(pinitial_name);
                    dt.Columns.Add(pexe_name);
                    dt.Columns.Add(pteam_id);
                    dt.Columns.Add(pchequ_deta_on);
                    dt.Columns.Add(pIRR);
                    for (int i = 0; i < dsSelectData.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["contra_code"] = dsSelectData.Tables[0].Rows[i]["contra_code"].ToString();
                        dr["loan_amount"] = dsSelectData.Tables[0].Rows[i]["loan_amount"].ToString() != "" ? dsSelectData.Tables[0].Rows[i]["loan_amount"].ToString() : "0.00";
                        dr["service_charges"] = dsSelectData.Tables[0].Rows[i]["service_charges"].ToString();
                        dr["other_charges"] = dsSelectData.Tables[0].Rows[i]["other_charges"].ToString();
                        dr["interest_rate"] = dsSelectData.Tables[0].Rows[i]["interest_rate"].ToString();

                        if ((dsSelectData.Tables[0].Rows[i]["period"].ToString() != "") && (dsSelectData.Tables[0].Rows[i]["period"].ToString() != "Select Period"))
                            dr["period"] = dsSelectData.Tables[0].Rows[i]["period"].ToString();
                        else
                            dr["period"] = "0";

                        dr["monthly_instollment"] = dsSelectData.Tables[0].Rows[i]["monthly_instollment"].ToString() != "" ? dsSelectData.Tables[0].Rows[i]["monthly_instollment"].ToString() : "0.00";
                        dr["walfare_fee"] = dsSelectData.Tables[0].Rows[i]["walfare_fee"].ToString();
                        dr["registration_fee"] = dsSelectData.Tables[0].Rows[i]["registration_fee"].ToString();
                        dr["center_name"] = dsSelectData.Tables[0].Rows[i]["center_name"].ToString();
                        dr["initial_name"] = dsSelectData.Tables[0].Rows[i]["initial_name"].ToString();
                        dr["exe_name"] = dsSelectData.Tables[0].Rows[i]["exe_name"].ToString();
                        dr["team_id"] = dsSelectData.Tables[0].Rows[i]["team_id"].ToString();
                        dr["chequ_deta_on"] = dsSelectData.Tables[0].Rows[i]["chequ_deta_on"].ToString();

                        string strLA = (dr["loan_amount"].ToString()!="")?dr["loan_amount"].ToString():"0.00";
                        string strMI = (dr["monthly_instollment"].ToString()!="")?dr["monthly_instollment"].ToString():"0.00";
                        string strIR = (dr["interest_rate"].ToString()!="")?dr["interest_rate"].ToString():"0";
                        string strP = (dr["period"].ToString()!="")?dr["period"].ToString():"0";
                        
                        if (dsSelectData.Tables[0].Rows[i]["interest_amount"].ToString() != "")
                            dr["interest_amount"] = dsSelectData.Tables[0].Rows[i]["interest_amount"].ToString();
                        else
                        {
                            double dblIA = Convert.ToDouble(strLA) * Convert.ToDouble(strIR)/100;
                            dblCount_IA += dblIA;
                            dr["interest_amount"] = Convert.ToDecimal(dblIA).ToString("#,##0.00");
                        }
                        dr["IRR"] = IRRMethod(Convert.ToDouble(strLA),Convert.ToDouble(strMI),Convert.ToInt32(strP));
                       
                        dt.Rows.Add(dr);
                    }
                    grvLoanDeta.DataSource = dt;
                    grvLoanDeta.DataBind();
                }

                if (dsSelectData.Tables[0].Rows.Count > 0)
                {
                    pnlSummery.Visible = true;
                    string strSummery;
                    lblDisb.Text = "0.00";
                    lblIAmount.Text = "0.00";
                    lblNoContra.Text = "0";
                    lblSCharges.Text = "0.00";
                    hstrSelectQuery1.Value = "";
                    hstrSelectQuery1.Value = "select count(l.contra_code),sum(l.loan_amount),sum(l.service_charges),sum(l.interest_amount) from micro_loan_details l, micro_basic_detail c , center_details f, micro_exective_root e where c.contract_code = l.contra_code and c.society_id = f.idcenter_details AND f.city_code = c.city_code and c.root_id = e.exe_id AND c.city_code = e.branch_code ";
                    if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0 || cmbVillagr.SelectedIndex != 0 || cmbRoot.SelectedIndex != 0 || cmbStatus.SelectedIndex != 0)
                    {
                        if (cmbCityCode.SelectedIndex != 0)
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                            if (cmbRoot.SelectedIndex != 0)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.root_id = '" + cmbRoot.SelectedItem.Value + "'";
                            }
                            if (cmbVillagr.SelectedIndex != 0)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.society_id = '" + cmbVillagr.SelectedValue.ToString() + "' ";
                            }
                        }
                        if (cmbStatus.SelectedIndex != 0)
                        {
                            if (cmbStatus.SelectedIndex == 1)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.loan_sta = 'P' and loan_approved = 'P'";
                            }
                            else if (cmbStatus.SelectedIndex == 2)
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.loan_sta = 'P' and loan_approved = 'Y'";
                            }
                            else
                            {
                                hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.loan_sta = '" + cmbStatus.SelectedItem.Value + "'";
                            }
                        }
                        if (txtContraCode.Text.Trim() != "")
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "'";
                        }
                        if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and (DATE_FORMAT((l.created_on),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' ";
                        }

                        strSummery = hstrSelectQuery1.Value;
                        DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                        if (dsSummery.Tables[0].Rows[0][0].ToString() != "")
                        {
                            lblNoContra.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                            lblDisb.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                            lblSCharges.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][2].ToString()).ToString("#,##0.00");
                            if (dsSummery.Tables[0].Rows[0][3].ToString()!="")
                                lblIAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][3].ToString()).ToString("#,##0.00");
                            else lblIAmount.Text = Convert.ToDecimal(dblCount_IA).ToString("#,##0.00");
                        }
                    }
                    else
                    {
                        strSummery = hstrSelectQuery1.Value;
                        DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                        if (dsSummery.Tables[0].Rows[0][0].ToString() != "")
                        {
                            lblNoContra.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                            lblDisb.Text = Convert.ToDecimal((dsSummery.Tables[0].Rows[0][1].ToString()!="")?dsSummery.Tables[0].Rows[0][1].ToString():"0.00").ToString("#,##0.00");
                            lblSCharges.Text = Convert.ToDecimal((dsSummery.Tables[0].Rows[0][2].ToString()!="")?dsSummery.Tables[0].Rows[0][2].ToString():"0.00").ToString("#,##0.00");
                            if (dsSummery.Tables[0].Rows[0][3].ToString() != "")
                                lblIAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][3].ToString()).ToString("#,##0.00");
                            else lblIAmount.Text = Convert.ToDecimal(dblCount_IA).ToString("#,##0.00");
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "No records found for your search criteria. Please try again.";
                    lblNoContra.Text = "0";
                    lblDisb.Text = "0.00";
                    lblSCharges.Text = "0.00";
                    lblIAmount.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
            }
        }

        private decimal IRRMethod(double LoanAmount, double Installment, int Period)
        {
            int x = Period;
            double[] tmpCashflows = new double[x + 1];

            tmpCashflows[0] = (-1) * LoanAmount;

            for (int i = 1; i < Period + 1; i++)
            {
                tmpCashflows[i] = Installment;
            }

            decimal irr = 0;
            try
            {
                double Guess = 0.00;
                double tmpIrr = Financial.IRR(ref tmpCashflows, Guess);
                irr = Convert.ToDecimal(tmpIrr * 100.00) * Period;
            }
            catch (Exception ex)
            {
                irr = 0;
            }
            return irr;
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            #region comment
            //if (cmbCityCode.SelectedIndex != 0)
            //{
            //    cmbRoot.Enabled = true;
            //    cmbVillagr.Enabled = true;

            //    if (cmbVillagr.Items.Count > 0)
            //    {
            //        cmbVillagr.Items.Clear();
            //    }

            //    if (cmbRoot.Items.Count > 0)
            //    {
            //        cmbRoot.Items.Clear();
            //    }

            //    string strBranch = cmbCityCode.SelectedItem.Value;

            //    //Get Viilage
            //    DataSet dsGetVillge = cls_Connection.getDataSet("select villages,center_name,idcenter_details from center_details where city_code = '" + strBranch + "'");
            //    if (dsGetVillge.Tables[0].Rows.Count > 0)
            //    {
            //        cmbVillagr.Items.Add("");
            //        for (int i = 0; i < dsGetVillge.Tables[0].Rows.Count; i++)
            //        {
            //            //cmbVillagr.Items.Add("[" + dsGetVillge.Tables[0].Rows[i]["villages"] + "] - " + dsGetVillge.Tables[0].Rows[i]["center_name"].ToString());
            //            cmbVillagr.Items.Add(dsGetVillge.Tables[0].Rows[i]["center_name"].ToString());
            //            cmbVillagr.Items[i + 1].Value = dsGetVillge.Tables[0].Rows[i]["villages"].ToString() + "-" + dsGetVillge.Tables[0].Rows[i]["idcenter_details"].ToString();
            //        }
            //    }

            //    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");

            //    cmbRoot.Items.Add("");

            //    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
            //    {
            //        cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
            //        cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
            //    }
            //}
            //else
            //{
            //    if (cmbRoot.Items.Count > 0)
            //    {
            //        cmbRoot.Items.Clear();
            //    }

            //    if (cmbVillagr.Items.Count > 0)
            //    {
            //        cmbVillagr.Items.Clear();
            //    }

            //    cmbVillagr.Enabled = false;

            //    cmbRoot.Enabled = false;
            //}
            #endregion

        }

        //Export Excel----------------------------------
        protected void exportExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Loan_Detail_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages

                    grvLoanDeta.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in grvLoanDeta.HeaderRow.Cells)
                    {
                        cell.BackColor = grvLoanDeta.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in grvLoanDeta.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grvLoanDeta.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grvLoanDeta.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grvLoanDeta.RenderControl(hw);

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
