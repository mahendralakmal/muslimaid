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
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace MuslimAID.MURABHA
{
    public partial class Debit_Note : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        DataSet dtLoanDet = new DataSet();

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

        protected void btnEndDay_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            string strMDate = txtDate.Text.Trim();
            string strloginID = Session["NIC"].ToString();
            string strIp = Request.UserHostAddress;
            decimal decTotalDebit = 0;
            //decimal decSo = 0;
            //decimal decTm = 0;
            //decimal decBE = 0;
            //decimal decCo = 0;
            //decimal decNr = 0;
            //decimal decRp = 0;
            //string strCDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strCDate = strMDate + " 23:21:12";
            string strCDate2 = strMDate + " 23:21:13";

            //string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            string strDate = strMDate;

            MySqlCommand cmdSelect = new MySqlCommand("select * from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P' and l.due_date = '" + strMDate + "';");
            dtLoanDet = objDBTask.selectData(cmdSelect);

            if (dtLoanDet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtLoanDet.Tables[0].Rows.Count; i++)
                {
                    string strCurrentLoanAmoun = dtLoanDet.Tables[0].Rows[i]["current_loan_amount"].ToString();
                    string strCCode = dtLoanDet.Tables[0].Rows[i]["contra_code"].ToString();
                    string strNIC = dtLoanDet.Tables[0].Rows[i]["nic"].ToString();
                    string strMoIns = dtLoanDet.Tables[0].Rows[i]["monthly_instollment"].ToString();
                    string strStatus = dtLoanDet.Tables[0].Rows[i]["loan_sta"].ToString();
                    string strPeriod = dtLoanDet.Tables[0].Rows[i]["period"].ToString();
                    string strDueCount = dtLoanDet.Tables[0].Rows[i]["due_installment"].ToString();
                    string strBranchCode = dtLoanDet.Tables[0].Rows[i]["city_code"].ToString();
                    string strLA = dtLoanDet.Tables[0].Rows[i]["loan_amount"].ToString();
                    string strIA = dtLoanDet.Tables[0].Rows[i]["interest_amount"].ToString();
                    string strOP = dtLoanDet.Tables[0].Rows[i]["over_payment"].ToString();
                    string BranchCode = dtLoanDet.Tables[0].Rows[i]["city_code"].ToString();
                    string CenterCode = dtLoanDet.Tables[0].Rows[i]["society_id"].ToString();
                    string strZero = "0";

                    double dbLA = Convert.ToDouble(strLA);
                    decimal decLA = Convert.ToDecimal(strLA);
                    double dbIA = Convert.ToDouble(strIA);
                    double dbInstaAmo = Convert.ToDouble(strMoIns);
                    decimal decInstaAmo = Convert.ToDecimal(strMoIns);
                    int intPeriod = Convert.ToInt32(strPeriod);
                    decimal decPeriod = Convert.ToDecimal(strPeriod);
                    decimal decOP = Convert.ToDecimal(strOP);

                    //string strCDate = "2015-03-21 23:21:12";

                    decimal decMI = Convert.ToDecimal(strMoIns);
                    decimal decCurrLoanAmount = Convert.ToDecimal(strCurrentLoanAmoun);

                    if (decCurrLoanAmount <= 0)
                    {
                        string strCount = "0";
                        string strArreaas = "0";
                        string strStatuss = "S";
                        //string strCloseDate = DateTime.Now.ToString("yyyy-MM-dd");
                        string strCloseDate = strMDate;

                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set arres_amou = '" + strArreaas + "',def = '" + strArreaas + "',arres_count = '" + strCount + "',loan_sta = '" + strStatuss + "',closing_date = '" + strCloseDate + "' where contra_code = '" + strCCode + "';");
                        int ii;
                        ii = objDBTask.insertEditData(cmdUpdateLoanAmou);
                    }
                    else
                    {
                        if (strDueCount == strPeriod)
                        {
                            string strStatusss = "E";
                            //string strCloseDatee = DateTime.Now.ToString("yyyy-MM-dd");
                            string strCloseDatee = strMDate;

                            MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set loan_sta = '" + strStatusss + "',closing_date = '" + strCloseDatee + "' where contra_code = '" + strCCode + "';");
                            int iii;
                            iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                        }
                        else
                        {
                            //Get Current Debit
                            string strCurBalance;
                            decimal decCurBalance = 0;
                            string strLastDate = "";
                            DataSet dsGetDebit = cls_Connection.getDataSet("select curr_balance,date_time from micro_payme_summery where contra_code = '" + strCCode + "' and date_time < '" + strCDate + "' order by date_time desc limit 1;");
                            if (dsGetDebit.Tables[0].Rows.Count > 0)
                            {
                                strCurBalance = dsGetDebit.Tables[0].Rows[0]["curr_balance"].ToString();
                                strLastDate = dsGetDebit.Tables[0].Rows[0]["date_time"].ToString();
                                decCurBalance = Convert.ToDecimal(strCurBalance);
                            }

                            decimal decDebit = 0;
                            string strDebitMI = "";

                            decDebit = decMI + decCurBalance;
                            strDebitMI = strMoIns;


                            string strDebit = Convert.ToString(decDebit);

                            //Edit 

                            DataSet dsHday = cls_Connection.getDataSet("select holiday_date from recovery_holiday where date_sta = 'A' and holiday_date = '" + strDate + "' and branch_code = '" + BranchCode + "' and center_id = '" + CenterCode + "' ;");

                            if (dsHday.Tables[0].Rows.Count == 0)
                            {
                                DataSet dsHoliday = cls_Connection.getDataSet("select holiday_date from recovery_holiday where date_sta = 'A' and holiday_date = '" + strDate + "' and branch_code = 'AL' and center_id = 'AL' ;");

                                if (dsHoliday.Tables[0].Rows.Count > 0)
                                {
                                    DateTime dtNow = Convert.ToDateTime(strMDate).AddDays(7);
                                    string strDueDate = dtNow.ToString("yyyy-MM-dd");

                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueDate + "' where contra_code = '" + strCCode + "';");
                                    int ii;
                                    ii = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }
                                else
                                {
                                    decimal decDueOneIA = 0;
                                    decimal decDueOneCapital = 0;
                                    string strDueInte = "0";
                                    string strDueCapita = "0";
                                    //IRR
                                    int x = intPeriod;
                                    double[] tmpCashflows = new double[x + 1];

                                    tmpCashflows[0] = (-1) * dbLA;

                                    for (int ii = 1; ii < intPeriod + 1; ii++)
                                    {
                                        tmpCashflows[ii] = dbInstaAmo;
                                    }

                                    decimal irr = 0;
                                    try
                                    {
                                        double Guess = 0.00;
                                        double tmpIrr = Financial.IRR(ref tmpCashflows, Guess);
                                        irr = Convert.ToDecimal(tmpIrr * 100.00) * intPeriod;
                                    }
                                    catch (Exception ex)
                                    {
                                        irr = 0;
                                    }
                                    //return irr;

                                    if (strDueCount == "0")
                                    {
                                        decDueOneIA = decLA * ((irr / 100) / decPeriod);
                                        decDueOneCapital = decInstaAmo - decDueOneIA;

                                        strDueCapita = decDueOneCapital.ToString();
                                        strDueInte = decDueOneIA.ToString();
                                    }
                                    else
                                    {
                                        DataSet dsGetCapInte = cls_Connection.getDataSet("select sum(capital) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'DB';");
                                        if (dsGetCapInte.Tables[0].Rows[0][0].ToString() != "")
                                        {
                                            string OLDCapital = dsGetCapInte.Tables[0].Rows[0][0].ToString();

                                            decimal decOLDCap = Convert.ToDecimal(OLDCapital);

                                            decimal decRemaiCapi = decLA - decOLDCap;

                                            decDueOneIA = decRemaiCapi * (irr / 100 / decPeriod);
                                            decDueOneCapital = decInstaAmo - decDueOneIA;

                                            strDueCapita = decDueOneCapital.ToString();
                                            strDueInte = decDueOneIA.ToString();
                                        }
                                    }

                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@curr_balance);");

                                    #region Assign Parameters
                                    cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
                                    cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
                                    cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
                                    cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
                                    cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
                                    cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
                                    cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
                                    cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
                                    cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
                                    cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                    cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strDebitMI;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strDueCapita;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strDueInte;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDebitMI;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strZero;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "DB";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strCDate;
                                    cmdInsertPaySumm.Parameters["@curr_balance"].Value = strDebit;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);

                                    //Edit Balance Colum....
                                    GetSearch(strCCode);

                                    //Chk OP
                                    if (decOP > 0)
                                    {
                                        decimal decOLDLCCapital = Convert.ToDecimal(strDueCapita);
                                        decimal decOLDLCInterest = Convert.ToDecimal(strDueInte);

                                        if (decOP >= decMI)
                                        {
                                            MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                            #region Assign Parameters
                                            cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                            cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                            cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                            cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                            #endregion

                                            #region DEclare Parametes
                                            cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                            cmdInsertPaidDetail.Parameters["@paid_capital"].Value = strDueCapita;
                                            cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strDueInte;
                                            cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                            #endregion

                                            int t;
                                            t = objDBTask.insertEditData(cmdInsertPaidDetail);

                                            MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment - '" + strMoIns + "' where contra_code = '" + strCCode + "';");
                                            int iii;
                                            iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                        }
                                        else
                                        {
                                            if (decOP >= decOLDLCInterest)
                                            {
                                                decimal decDBCapitalBala = decOP - decOLDLCInterest;
                                                string strDBCapitalBala = Convert.ToString(decDBCapitalBala);

                                                MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                #region Assign Parameters
                                                cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                #endregion

                                                #region DEclare Parametes
                                                cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                cmdInsertPaidDetail.Parameters["@paid_capital"].Value = strDBCapitalBala;
                                                cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strDueInte;
                                                cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                #endregion

                                                int t;
                                                t = objDBTask.insertEditData(cmdInsertPaidDetail);

                                                MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment - '" + strOP + "' where contra_code = '" + strCCode + "';");
                                                int iii;
                                                iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                            }
                                            else
                                            {
                                                MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                #region Assign Parameters
                                                cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                #endregion

                                                #region DEclare Parametes
                                                cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                cmdInsertPaidDetail.Parameters["@paid_capital"].Value = "0";
                                                cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strOP;
                                                cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                #endregion

                                                int t;
                                                t = objDBTask.insertEditData(cmdInsertPaidDetail);

                                                MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment - '" + strOP + "' where contra_code = '" + strCCode + "';");
                                                int iii;
                                                iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                            }
                                        }
                                    }

                                    DateTime dtNow = Convert.ToDateTime(strMDate).AddDays(7);
                                    //DateTime dtMNow = Convert.ToDateTime(strMDate);
                                    //DateTime dtMDue = dtMNow.AddDays(7);
                                    string strDueDate = dtNow.ToString("yyyy-MM-dd");
                                    ////Check Holiday Date
                                    //string strDueDate1 = dtMDue.ToString("yyyy-MM-dd");
                                    //DataSet dsGetHoliday = cls_Connection.getDataSet("select * from recovery_holiday where holiday_date = '" + strDueDate1 + "' and date_sta = 'A'");
                                    //if (dsGetHoliday.Tables[0].Rows.Count > 0)
                                    //{
                                    //    dtMDue = dtMDue.AddDays(7);
                                    //}
                                    //string strDueDate = dtMDue.ToString("yyyy-MM-dd");
                                    string strCountOne = "1";

                                    //Get Current Debit--------------------------------------
                                    string strCurBalancec;
                                    decimal decCurBalancec = 0;
                                    string strLastDatec = "";
                                    DataSet dsGetDebitc = cls_Connection.getDataSet("select curr_balance,date_time from micro_payme_summery where contra_code = '" + strCCode + "' order by date_time desc limit 1;");
                                    if (dsGetDebitc.Tables[0].Rows.Count > 0)
                                    {
                                        strCurBalancec = dsGetDebitc.Tables[0].Rows[0]["curr_balance"].ToString();
                                        strLastDatec = dsGetDebitc.Tables[0].Rows[0]["date_time"].ToString();
                                        decCurBalancec = Convert.ToDecimal(strCurBalancec);
                                    }

                                    decimal decDebitc = 0;
                                    string strDebitMIc = "";

                                    decDebitc = decCurBalancec;
                                    strDebitMIc = strMoIns;


                                    string strDebitc = Convert.ToString(decDebitc);

                                    //Add Arreas 
                                    //--------------------------------------------------------------------------------
                                    if (decDebitc > 0)
                                    {
                                        //decimal decArreas = decDebit;
                                        decimal decArreas = decDebitc;
                                        int intArreasCount = Convert.ToInt32(decArreas) / Convert.ToInt32(decMI);

                                        string strCount = Convert.ToString(intArreasCount);
                                        string strArreaas = Convert.ToString(decArreas);

                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueDate + "',arres_amou = '" + strArreaas + "',over_payment = '" + strZero + "',arres_count = '" + strCount + "',due_installment = due_installment + '" + strCountOne + "' where contra_code = '" + strCCode + "';");
                                        int ii;
                                        ii = objDBTask.insertEditData(cmdUpdateLoanAmou);

                                    }
                                    else
                                    {
                                        string strCount = "0";
                                        string strArreaas = "0";

                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueDate + "',arres_amou = '" + strArreaas + "',arres_count = '" + strCount + "',due_installment = due_installment + '" + strCountOne + "' where contra_code = '" + strCCode + "';");
                                        int ii;
                                        ii = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                    }
                                }
                            }
                            else
                            {
                                DateTime dtNow = Convert.ToDateTime(strMDate).AddDays(7);
                                string strDueDate = dtNow.ToString("yyyy-MM-dd");

                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueDate + "' where contra_code = '" + strCCode + "';");
                                int ii;
                                ii = objDBTask.insertEditData(cmdUpdateLoanAmou);
                            }

                        }
                    }
                    //Add Balance 2016-04-17
                    //GetSearch(strCCode);
                }
            }

            //Add DI Matuerd Contracts
            MySqlCommand cmdSelectDI = new MySqlCommand("select * from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'E' and l.due_date = '" + strMDate + "';");
            DataSet dtLoanDetDI = objDBTask.selectData(cmdSelectDI);
            if (dtLoanDetDI.Tables[0].Rows.Count > 0)
            {
                string strCloseDateDI = txtDate.Text.Trim();
                DateTime dtMNow = Convert.ToDateTime(strCloseDateDI);
                DateTime dtMDue = dtMNow.AddDays(7);
                //string strDueDate = dtNow.ToString("yyyy-MM-dd");
                string strDueDate1 = dtMDue.ToString("yyyy-MM-dd");
                DataSet dsGetHoliday = cls_Connection.getDataSet("select * from recovery_holiday where holiday_date = '" + strDueDate1 + "' and date_sta = 'A'");
                if (dsGetHoliday.Tables[0].Rows.Count > 0)
                {
                    dtMDue = dtMDue.AddDays(7);
                }

                string strDueDate = dtMDue.ToString("yyyy-MM-dd");

                for (int i = 0; i < dtLoanDetDI.Tables[0].Rows.Count; i++)
                {
                    string strCurrentLoanAmounDI = dtLoanDetDI.Tables[0].Rows[i]["current_loan_amount"].ToString();
                    string strCCodeDI = dtLoanDetDI.Tables[0].Rows[i]["contract_code"].ToString();
                    string strNICDI = dtLoanDetDI.Tables[0].Rows[i]["nic"].ToString();
                    string strMoInsDI = dtLoanDetDI.Tables[0].Rows[i]["monthly_instollment"].ToString();
                    string strStatusDI = dtLoanDetDI.Tables[0].Rows[i]["loan_sta"].ToString();
                    string strPeriodDI = dtLoanDetDI.Tables[0].Rows[i]["period"].ToString();
                    string strDueCountDI = dtLoanDetDI.Tables[0].Rows[i]["due_installment"].ToString();
                    string strBranchCodeDI = dtLoanDetDI.Tables[0].Rows[i]["city_code"].ToString();
                    string strZeroDI = "0";


                    decimal decMIDI = Convert.ToDecimal(strMoInsDI);
                    decimal decCurrLoanAmountDI = Convert.ToDecimal(strCurrentLoanAmounDI);

                    if (decCurrLoanAmountDI <= 0)
                    {
                        string strCountDI = "0";
                        string strArreaasDI = "0";
                        string strStatussDI = "S";


                        MySqlCommand cmdUpdateLoanAmouDI = new MySqlCommand("Update micro_loan_details set arres_amou = '" + strArreaasDI + "',def = '" + strArreaasDI + "',arres_count = '" + strCountDI + "',loan_sta = '" + strStatussDI + "',closing_date = '" + strCloseDateDI + "' where contra_code = '" + strCCodeDI + "';");
                        int ix;
                        ix = objDBTask.insertEditData(cmdUpdateLoanAmouDI);
                    }
                    else
                    { }

                    //Edit Ledger Card
                    //GetSearch(strCCodeDI);
                }
            }

            lblMsg.Text = "Succsesfully Completed.";
        }

        protected void GetSearch(string strCC)
        {
            //lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            //hstrSelectQuery.Value = "select (c.capital + c.interest) as credit,(c.debit + c.c_default) as debit,c.rcp_no,t.descr,c.date_time,c.payment_type,c.curr_balance from micro_payme_summery c, tra_descri t where t.code_tra = c.p_type";
            hstrSelectQuery.Value = "select idcons_payme_summery,amount,rcp_no,p_type,date_time,payment_type,curr_balance,p_status from micro_payme_summery";
            if (strCC != "")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " where contra_code = '" + strCC + "' order by date_time asc;";

                //loadDataToRepeater(hstrSelectQuery.Value);

                string strQRY = hstrSelectQuery.Value;
                DataSet dsGetTrans = cls_Connection.getDataSet(strQRY);

                if (dsGetTrans.Tables[0].Rows.Count > 0)
                {
                    //pnlSummery.Visible = true;
                    //DataTable dt = new DataTable();
                    //DataRow dr;
                    double Balance = 0;
                    //dt.Columns.Add("Date Time");
                    //dt.Columns.Add("Rec No.");
                    //dt.Columns.Add("Type");
                    //dt.Columns.Add("Cash/CHQ");
                    //dt.Columns.Add("Debit");
                    //dt.Columns.Add("Credit");
                    //dt.Columns.Add("Balance");
                    //dt.Columns.Add("Status");


                    for (int i = 0; i < dsGetTrans.Tables[0].Rows.Count; i++)
                    {
                        string strID = dsGetTrans.Tables[0].Rows[i]["idcons_payme_summery"].ToString();
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
                            //dr = dt.NewRow();
                            //dr["Date Time"] = strDateTime;
                            //dr["Rec No."] = strRcpNo;
                            if (true)
                            {

                            }
                            //dr["Type"] = "Weekly Installment";
                            //dr["Cash/CHQ"] = strPType;
                            //dr["Debit"] = "0.00";
                            //dr["Credit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            Balance = Balance - Convert.ToDouble(strCredit);
                            string strBala = Balance.ToString("0.00");//Convert.ToDecimal(strBalance).ToString("#,##0.00");

                            MySqlCommand cmdUpdateBala = new MySqlCommand("Update micro_payme_summery set curr_balance = '" + strBala + "' where idcons_payme_summery = '" + strID + "';");
                            int cc;
                            cc = objDBTask.insertEditData(cmdUpdateBala);
                            //dr["Status"] = strLiveStatus;
                            //dt.Rows.Add(dr);
                            //dt.AcceptChanges();
                        }
                        else if (strType == "DB")
                        {
                            //dr = dt.NewRow();
                            //dr["Date Time"] = strDateTime;
                            //dr["Rec No."] = strRcpNo;
                            if (true)
                            {

                            }
                            //dr["Type"] = "Debit";
                            //dr["Cash/CHQ"] = strPType;
                            //dr["Debit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            //dr["Credit"] = "0.00";
                            Balance = Balance + Convert.ToDouble(strCredit);
                            string strBala = Balance.ToString("0.00");// Convert.ToDecimal(strBalance).ToString("#,##0.00");

                            MySqlCommand cmdUpdateBala = new MySqlCommand("Update micro_payme_summery set curr_balance = '" + strBala + "' where idcons_payme_summery = '" + strID + "';");
                            int cc;
                            cc = objDBTask.insertEditData(cmdUpdateBala);
                            //dr["Status"] = strLiveStatus;
                            //dt.Rows.Add(dr);
                            //dt.AcceptChanges();
                        }
                        else if (strType == "D")
                        {
                            //dr = dt.NewRow();
                            //dr["Date Time"] = strDateTime;
                            //dr["Rec No."] = strRcpNo;
                            //dr["Type"] = "Default";
                            //dr["Cash/CHQ"] = strPType;
                            //dr["Debit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            //dr["Credit"] = "0.00";
                            Balance = Balance + Convert.ToDouble(strCredit);
                            string strBala = Balance.ToString("0.00");//Convert.ToDecimal(strBalance).ToString("#,##0.00");

                            MySqlCommand cmdUpdateBala = new MySqlCommand("Update micro_payme_summery set curr_balance = '" + strBala + "' where idcons_payme_summery = '" + strID + "';");
                            int cc;
                            cc = objDBTask.insertEditData(cmdUpdateBala);
                            //dr["Status"] = strLiveStatus;
                            //dt.Rows.Add(dr);
                            //dt.AcceptChanges();
                        }
                        else if (strType == "R")
                        {
                            //dr = dt.NewRow();
                            //dr["Date Time"] = strDateTime;
                            //dr["Rec No."] = strRcpNo;
                            //dr["Type"] = "Default";
                            //dr["Cash/CHQ"] = strPType;
                            //dr["Debit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            //dr["Credit"] = "0.00";
                            Balance = Balance - Convert.ToDouble(strCredit);
                            string strBala = Balance.ToString("0.00");//Convert.ToDecimal(strBalance).ToString("#,##0.00");

                            MySqlCommand cmdUpdateBala = new MySqlCommand("Update micro_payme_summery set curr_balance = '" + strBala + "' where idcons_payme_summery = '" + strID + "';");
                            int cc;
                            cc = objDBTask.insertEditData(cmdUpdateBala);
                            //dr["Status"] = strLiveStatus;
                            //dt.Rows.Add(dr);
                            //dt.AcceptChanges();
                        }
                        else if (strType == "RC")
                        {
                            //dr = dt.NewRow();
                            //dr["Date Time"] = strDateTime;
                            //dr["Rec No."] = strRcpNo;
                            //dr["Type"] = "Receipt Cancel";
                            //dr["Cash/CHQ"] = strPType;
                            //dr["Debit"] = Convert.ToDecimal(strCredit).ToString("#,##0.00");
                            //dr["Credit"] = "0.00";
                            Balance = Balance + Convert.ToDouble(strCredit);
                            string strBala = Balance.ToString("0.00");//Convert.ToDecimal(strBalance).ToString("#,##0.00");

                            MySqlCommand cmdUpdateBala = new MySqlCommand("Update micro_payme_summery set curr_balance = '" + strBala + "' where idcons_payme_summery = '" + strID + "';");
                            int cc;
                            cc = objDBTask.insertEditData(cmdUpdateBala);
                            //dr["Status"] = strLiveStatus;
                            //dt.Rows.Add(dr);
                            //dt.AcceptChanges();
                        }
                    }


                    //grvSumm.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    //grvSumm.DataSource = dt;
                    //grvSumm.DataBind();
                }
                else
                {
                    //pnlSummery.Visible = false;
                    //lblMsg.Text = "No records found for your search criteria. Please try again.";
                }
            }
            else
            {
                //pnlSummery.Visible = false;
                //lblMsg.Text = "Please enter Contract Code.";
            }
        }
    }
}
