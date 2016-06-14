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

namespace LoanSystem.Micro
{
    public partial class Loan_Position_Report : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

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
                Response.Redirect("../Default.aspx");
            }
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select l.contra_code,c.initial_name,l.service_charges,l.due_installment,l.current_loan_amount,l.monthly_instollment,l.loan_amount,l.loan_sta,l.chequ_deta_on from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_sta != 'C' and l.loan_approved = 'Y' and l.chequ_no != ''";
            if (cmbCityCode.SelectedIndex == 0 && cmbCompany.SelectedIndex == 0)
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by l.idloan_details asc";
            }
            else if (cmbCompany.SelectedIndex != 0 && cmbCityCode.SelectedIndex == 0)
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.company_code = '" + cmbCompany.SelectedValue.ToString() + "' order by l.idloan_details asc";
            }
            else if (cmbCompany.SelectedIndex != 0 && cmbCityCode.SelectedIndex != 0)
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.company_code = '" + cmbCompany.SelectedValue.ToString() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "' order by l.idloan_details asc";
            }
            else if (cmbCompany.SelectedIndex == 0 && cmbCityCode.SelectedIndex != 0)
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "' order by l.idloan_details asc";
            }

            string strQRY = hstrSelectQuery.Value;
            DataSet dsGetTrans = objDBTask.selectData(strQRY);

            if (dsGetTrans.Tables[0].Rows.Count > 0)
            {
                pnlSummery.Visible = true;
                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("C Code");
                dt.Columns.Add("Name");
                dt.Columns.Add("Loan Amount");
                dt.Columns.Add("Serv Charges");
                dt.Columns.Add("Weekly Inst");
                dt.Columns.Add("Loan Grant Date");
                dt.Columns.Add("No of Due");
                dt.Columns.Add("Due Amount");
                dt.Columns.Add("Paid Amount");
                dt.Columns.Add("No of Colle Inst");
                dt.Columns.Add("Advance Payment");
                dt.Columns.Add("Last Pay Date");
                dt.Columns.Add("Loan Balance");
                dt.Columns.Add("With OP Rec %");
                dt.Columns.Add("Without OP Rec %");

                decimal decTSC = 0;
                decimal decTLB = 0;
                decimal decTOP = 0;
                decimal decTPA = 0;
                decimal decTLA = 0;
                decimal decTDA = 0;

                for (int i = 0; i < dsGetTrans.Tables[0].Rows.Count; i++)
                {
                    string strCCode = dsGetTrans.Tables[0].Rows[i]["contra_code"].ToString();
                    string strName = dsGetTrans.Tables[0].Rows[i]["initial_name"].ToString();
                    string strSC = Convert.ToDecimal(dsGetTrans.Tables[0].Rows[i]["service_charges"].ToString()).ToString("#,##0.00");
                    string strDI = dsGetTrans.Tables[0].Rows[i]["due_installment"].ToString();
                    string strCLoanA = Convert.ToDecimal(dsGetTrans.Tables[0].Rows[i]["current_loan_amount"].ToString()).ToString("#,##0.00");
                    string strDInstallment = dsGetTrans.Tables[0].Rows[i]["monthly_instollment"].ToString();
                    string strLA = dsGetTrans.Tables[0].Rows[i]["loan_amount"].ToString();
                    string strStatus = dsGetTrans.Tables[0].Rows[i]["loan_sta"].ToString();
                    string strGDate = dsGetTrans.Tables[0].Rows[i]["chequ_deta_on"].ToString();

                    decimal decDI = Convert.ToDecimal(strDInstallment);
                    decimal decSC = Convert.ToDecimal(strSC);
                    decimal decCLoanBalance = Convert.ToDecimal(strCLoanA);
                    decimal decLA = Convert.ToDecimal(strLA);

                    //Total SC
                    decTSC = decTSC + decSC;

                    //Total LB
                    decTLB = decTLB + decCLoanBalance;

                    //Total LA
                    decTLA = decTLA + decLA;

                    //Get Due Count
                    int intDCount = Convert.ToInt32(strDI);
                    string strNewDueCount = "0";
                    int intDueCount = 0;
                    decimal decDueCount = 0;
                    //if (intDCount > 0 && strStatus == "P")
                    //{
                    //    intDueCount = intDCount - 1;
                    //    decDueCount = Convert.ToDecimal(intDueCount);
                    //    strNewDueCount = Convert.ToString(intDueCount);
                    //}
                    if (intDCount > 0)
                    {
                        intDueCount = intDCount;
                        decDueCount = Convert.ToDecimal(intDueCount);
                        strNewDueCount = Convert.ToString(intDueCount);
                    }
                    else
                    {
                        strNewDueCount = "0";
                    }

                    //Total Due Amount
                    decimal decTotalDAmount = decimal.Round(decDI * decDueCount, 2, MidpointRounding.AwayFromZero);
                    string strTDAmount = decTotalDAmount.ToString("#,##0.00");
                    decTDA = decTDA + decTotalDAmount;

                    //Get Paid Amount
                    string strPAmount = "0";
                    decimal decPAmount = 0;
                    string strNOCollInst = "0";
                    string strLastPDate = "-";
                    DataSet dsGetPaidAmount = objDBTask.selectData("select sum(p.paied_amount) from micro_pais_history p,micro_basic_detail c where p.tra_description = 'WI' and p.pay_status = 'D' and p.contra_code = c.contract_code and c.contract_code = '" + strCCode + "'");
                    if (dsGetPaidAmount.Tables[0].Rows[0][0].ToString() == "")
                    {

                    }
                    else
                    {
                        strPAmount = Convert.ToDecimal(dsGetPaidAmount.Tables[0].Rows[0][0].ToString()).ToString("#,##0.00");
                        decPAmount = Convert.ToDecimal(strPAmount);
                        DataSet dsGetLastPDate = objDBTask.selectData("select p.date_time from micro_payme_summery p,micro_basic_detail c where p.p_type = 'WI' and p.p_status = 'D' and p.contra_code = c.contract_code and c.contract_code = '" + strCCode + "' order by idcons_payme_summery desc limit 1");
                        if (dsGetLastPDate.Tables[0].Rows.Count > 0)
                        {
                            strLastPDate = dsGetLastPDate.Tables[0].Rows[0]["date_time"].ToString();
                        }
                        //Get Total Paid Amount
                        decTPA = decTPA + decPAmount;
                    }

                    //Get Over Payment
                    decimal decOP = 0;
                    string strRR = "100%";
                    string strWORR = "100%";
                    if (decPAmount > decTotalDAmount)
                    {
                        decOP = decPAmount - decTotalDAmount;
                        //Get Total Over Payment
                        decTOP = decTOP + decOP;

                        if (decTotalDAmount == 0)
                        {
                            strWORR = "-";
                        }
                        else
                        {
                            decimal decRR = decimal.Round(decPAmount / decTotalDAmount * 100, 2, MidpointRounding.AwayFromZero);
                            strWORR = Convert.ToString(decRR) + "%";
                        }

                    }
                    else if (decPAmount == 0 && decTotalDAmount == 0)
                    {
                        strRR = "0%";
                        strWORR = "0%";
                    }
                    else
                    {
                        decimal decRR = decimal.Round(decPAmount / decTotalDAmount * 100, 2, MidpointRounding.AwayFromZero);
                        strRR = Convert.ToString(decRR) + "%";
                        /*strWORR = Convert.ToString(decRR) + "%";*/
                        strWORR = "0%";
                    }

                    string strOP = decOP.ToString("#,##0.00");

                    //Get No of Collected Count
                    decimal decCCount = decimal.Round(decPAmount / decDI, 2, MidpointRounding.AwayFromZero);
                    int intCCount = Convert.ToInt32(decCCount);
                    string strCCount = Convert.ToString(intCCount);

                    //Reacovery Rate
                    //decimal decRR = 

                    dr = dt.NewRow();
                    dr["C Code"] = strCCode;
                    dr["Name"] = strName;
                    dr["Loan Amount"] = Convert.ToDecimal(strLA).ToString("#,##0.00");
                    dr["Serv Charges"] = strSC;
                    dr["Weekly Inst"] = Convert.ToDecimal(strDInstallment).ToString("#,##0.00");
                    dr["Loan Grant Date"] = strGDate;
                    dr["No of Due"] = strNewDueCount;
                    dr["Due Amount"] = strTDAmount;
                    dr["Paid Amount"] = strPAmount;
                    dr["No of Colle Inst"] = strCCount;
                    dr["Advance Payment"] = strOP;
                    dr["Last Pay Date"] = strLastPDate;
                    dr["Loan Balance"] = strCLoanA;
                    dr["With OP Rec %"] = strWORR;
                    dr["Without OP Rec %"] = strRR;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();


                }

                grvMIn.DataSource = dt;
                grvMIn.DataBind();

                lblLBalance.Text = decTLB.ToString("#,##0.00");
                lblOp.Text = decTOP.ToString("#,##0.00");
                lblPA.Text = decTPA.ToString("#,##0.00");
                lblSC.Text = decTSC.ToString("#,##0.00");
                lblLA.Text = decTLA.ToString("#,##0.00");
                lblDA.Text = decTDA.ToString("#,##0.00");

                decimal decWithOutOP = decTPA - decTOP;

                decimal decTotalRR = decimal.Round((decWithOutOP / decTDA) * 100, 2, MidpointRounding.AwayFromZero);
                lblTRR.Text = decTotalRR.ToString("#,##0.00");
            }
            else
            {
                pnlSummery.Visible = false;
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            pnlSummery.Visible = false;
            grvMIn.DataSource = null;
            grvMIn.DataBind();

            GetSearch();
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
            grvMIn.DataSource = dsSelectData;
            grvMIn.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlSummery.Visible = true;

                //if (txtCC.Text.Trim() != "")
                //{

                //}
                //else
                //{
                //    lblMsg.Text = "Please enter Contract Code.";
                //}

            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }



        protected void grvMIn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[13].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
}
