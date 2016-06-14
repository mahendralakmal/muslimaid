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
    public partial class Ledger_Card : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {

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
            //hstrSelectQuery.Value = "select (c.capital + c.interest) as credit,(c.debit + c.c_default) as debit,c.rcp_no,t.descr,c.date_time,c.payment_type,c.curr_balance from micro_payme_summery c, tra_descri t where t.code_tra = c.p_type";
            hstrSelectQuery.Value = "select amount,rcp_no,p_type,date_time,payment_type,curr_balance,p_status from micro_payme_summery";
            if (txtCC.Text.Trim() != "")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " where contra_code = '" + txtCC.Text.Trim() + "' order by idcons_payme_summery asc;";

                //loadDataToRepeater(hstrSelectQuery.Value);

                string strQRY = hstrSelectQuery.Value;
                DataSet dsGetTrans = objDBTask.selectData(strQRY);

                if (dsGetTrans.Tables[0].Rows.Count > 0)
                {
                    pnlSummery.Visible = true;
                    DataTable dt = new DataTable();
                    DataRow dr;

                    dt.Columns.Add("Date Time");
                    dt.Columns.Add("Rec No.");
                    dt.Columns.Add("Type");
                    dt.Columns.Add("Cash/CHQ");
                    dt.Columns.Add("Debit");
                    dt.Columns.Add("Credit");
                    dt.Columns.Add("Balance");
                    dt.Columns.Add("Status");


                    for (int i = 0; i < dsGetTrans.Tables[0].Rows.Count; i++)
                    {
                        string strCredit = dsGetTrans.Tables[0].Rows[i]["amount"].ToString();
                        //string strDebit = dsGetTrans.Tables[0].Rows[i]["debit"].ToString();
                        string strRcpNo = dsGetTrans.Tables[0].Rows[i]["rcp_no"].ToString();
                        string strType = dsGetTrans.Tables[0].Rows[i]["p_type"].ToString();
                        string strDateTime = dsGetTrans.Tables[0].Rows[i]["date_time"].ToString();
                        string strPType = dsGetTrans.Tables[0].Rows[i]["payment_type"].ToString();
                        string strBalance = dsGetTrans.Tables[0].Rows[i]["curr_balance"].ToString();
                        string strStatus = dsGetTrans.Tables[0].Rows[i]["p_status"].ToString();

                        string strLiveStatus = "Paid";
                        if (strStatus == "C")
                        {
                            strLiveStatus = "Cancel";
                        }

                        if (strType == "WI")
                        {
                            dr = dt.NewRow();
                            dr["Date Time"] = strDateTime;
                            dr["Rec No."] = strRcpNo;
                            dr["Type"] = "Weekly Installment";
                            dr["Cash/CHQ"] = strPType;
                            dr["Debit"] = "0.00";
                            dr["Credit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            dr["Balance"] = Convert.ToDecimal(strBalance).ToString("#,##0.00");
                            dr["Status"] = strLiveStatus;
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                        else if (strType == "DB")
                        {
                            dr = dt.NewRow();
                            dr["Date Time"] = strDateTime;
                            dr["Rec No."] = strRcpNo;
                            dr["Type"] = "Debit";
                            dr["Cash/CHQ"] = strPType;
                            dr["Debit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            dr["Credit"] = "0.00";
                            dr["Balance"] = Convert.ToDecimal(strBalance).ToString("#,##0.00");
                            dr["Status"] = strLiveStatus;
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                        else if (strType == "D")
                        {
                            dr = dt.NewRow();
                            dr["Date Time"] = strDateTime;
                            dr["Rec No."] = strRcpNo;
                            dr["Type"] = "Default";
                            dr["Cash/CHQ"] = strPType;
                            dr["Debit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            dr["Credit"] = "0.00";
                            dr["Balance"] = Convert.ToDecimal(strBalance).ToString("#,##0.00");
                            dr["Status"] = strLiveStatus;
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                        else if (strType == "RC")
                        {
                            dr = dt.NewRow();
                            dr["Date Time"] = strDateTime;
                            dr["Rec No."] = strRcpNo;
                            dr["Type"] = "Receipt Cancel";
                            dr["Cash/CHQ"] = strPType;
                            dr["Debit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            dr["Credit"] = "0.00";
                            dr["Balance"] = Convert.ToDecimal(strBalance).ToString("#,##0.00");
                            dr["Status"] = strLiveStatus;
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                    }

                    DataSet dsSummery = objDBTask.selectData("select l.contra_code,c.initial_name,l.loan_amount,l.current_loan_amount,l.interest_amount,l.period,l.monthly_instollment,l.chequ_deta_on,l.arres_amou,l.due_installment,l.loan_sta,c.village,v.center_name,e.exe_name,l.maturity_date from micro_loan_details l,micro_basic_detail c, center_details v, micro_exective_root e where c.contract_code = l.contra_code and v.idcenter_details = c.society_id and c.city_code = v.city_code and v.villages = c.village and c.city_code = e.branch_code and e.exe_id = c.root_id and l.contra_code = '" + txtCC.Text.Trim() + "';");
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblConCode.Text = dsSummery.Tables[0].Rows[0]["contra_code"].ToString();
                        lblContrDate.Text = dsSummery.Tables[0].Rows[0]["chequ_deta_on"].ToString();
                        lblCuBala.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0]["current_loan_amount"].ToString()).ToString("#,##0.00");
                        string strInterest = dsSummery.Tables[0].Rows[0]["interest_amount"].ToString();
                        decimal decInterest = Convert.ToDecimal(strInterest);
                        lblIAmount.Text = Convert.ToDecimal(strInterest).ToString("#,##0.00");
                        lblInstall.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0]["monthly_instollment"].ToString()).ToString("#,##0.00");
                        string strLAmount = dsSummery.Tables[0].Rows[0]["loan_amount"].ToString();
                        decimal decLAmount = Convert.ToDecimal(strLAmount);
                        lblLoanAmou.Text = Convert.ToDecimal(strLAmount).ToString("#,##0.00");
                        decimal decAValue = decInterest + decLAmount;
                        lblAValue.Text = decAValue.ToString("#,##0.00");
                        lblName.Text = dsSummery.Tables[0].Rows[0]["initial_name"].ToString();
                        lblPeriod.Text = dsSummery.Tables[0].Rows[0]["period"].ToString();
                        lblArre.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0]["arres_amou"].ToString()).ToString("#,##0.00");
                        lblDueCount.Text = dsSummery.Tables[0].Rows[0]["due_installment"].ToString();
                        string strStatus = dsSummery.Tables[0].Rows[0]["loan_sta"].ToString();
                        string strVillage = dsSummery.Tables[0].Rows[0]["village"].ToString();
                        string strCenterName = dsSummery.Tables[0].Rows[0]["center_name"].ToString();
                        lblCenterName.Text = strVillage + " - " + strCenterName;
                        lblCRO.Text = dsSummery.Tables[0].Rows[0]["exe_name"].ToString();
                        lblMatuDate.Text = dsSummery.Tables[0].Rows[0]["maturity_date"].ToString();

                        if (strStatus == "S")
                        {
                            lblStatus.Text = "Settle";
                        }
                        else if (strStatus == "E")
                        {
                            lblStatus.Text = "Matured";
                        }
                        else if (strStatus == "C")
                        {
                            lblStatus.Text = "Cancel";
                        }
                        else if (strStatus == "P")
                        {
                            lblStatus.Text = "Active";
                        }
                    }

                    //grvSumm.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grvSumm.DataSource = dt;
                    grvSumm.DataBind();
                }
                else
                {
                    pnlSummery.Visible = false;
                    lblMsg.Text = "No records found for your search criteria. Please try again.";
                }
            }
            else
            {
                pnlSummery.Visible = false;
                lblMsg.Text = "Please enter Contract Code.";
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            lblConCode.Text = "";
            lblMsg.Text = "";
            lblContrDate.Text = "";
            lblInstall.Text = "";
            lblLoanAmou.Text = "";
            lblName.Text = "";
            lblArre.Text = "";
            lblCuBala.Text = "";
            lblPeriod.Text = "";
            pnlSummery.Visible = false;
            grvSumm.DataSource = null;
            grvSumm.DataBind();

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
            grvSumm.DataSource = dsSelectData;
            grvSumm.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlSummery.Visible = true;

                if (txtCC.Text.Trim() != "")
                {

                }
                else
                {
                    lblMsg.Text = "Please enter Contract Code.";
                }

            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }



        protected void grvSumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
            }
        }
    }
}
