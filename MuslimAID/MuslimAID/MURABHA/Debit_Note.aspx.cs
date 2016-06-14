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
    public partial class Debit_Note : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();
        DataSet dtLoanDet = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnEndDay_Click(object sender, EventArgs e)
        {
            if (txtDate.Text !="")
            {
                lblMsg.Text = "";
                string strMDate = txtDate.Text.Trim();
                string strloginID = Session["NIC"].ToString();
                string strIp = Request.UserHostAddress;
                decimal decTotalDebit = 0;
                decimal decSo = 0;
                decimal decTm = 0;
                decimal decBE = 0;
                decimal decCo = 0;
                decimal decNr = 0;
                decimal decRp = 0;
                //string strCDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strCDate = strMDate + " 23:21:12";

                //string strDate = DateTime.Now.ToString("yyyy-MM-dd");
                string strDate = strMDate;

                MySqlCommand cmdSelect = new MySqlCommand("select * from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P' and l.due_date = '" + strDate + "';");
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
                        string strZero = "0";

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
                                DataSet dsGetDebit = objDBTask.selectData("select curr_balance from micro_payme_summery where contra_code = '" + strCCode + "' order by idcons_payme_summery desc limit 1;");
                                if (dsGetDebit.Tables[0].Rows.Count > 0)
                                {
                                    strCurBalance = dsGetDebit.Tables[0].Rows[0]["curr_balance"].ToString();
                                    decCurBalance = Convert.ToDecimal(strCurBalance);
                                }

                                decimal decDebit = 0;
                                string strDebitMI = "";

                                decDebit = decMI + decCurBalance;
                                strDebitMI = strMoIns;


                                string strDebit = Convert.ToString(decDebit);

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
                                cmdInsertPaySumm.Parameters["@capital"].Value = strZero;
                                cmdInsertPaySumm.Parameters["@interest"].Value = strZero;
                                cmdInsertPaySumm.Parameters["@debit"].Value = strDebitMI;
                                cmdInsertPaySumm.Parameters["@c_default"].Value = strZero;
                                cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                                cmdInsertPaySumm.Parameters["@p_type"].Value = "DB";
                                cmdInsertPaySumm.Parameters["@date_time"].Value = strCDate;
                                cmdInsertPaySumm.Parameters["@curr_balance"].Value = strDebit;
                                #endregion

                                int w;
                                w = objDBTask.insertEditData(cmdInsertPaySumm);

                                DateTime dtNow = DateTime.Now.AddDays(7);
                                DateTime dtMNow = Convert.ToDateTime(strMDate);
                                DateTime dtMDue = dtMNow.AddDays(7);
                                //string strDueDate = dtNow.ToString("yyyy-MM-dd");
                                string strDueDate = dtMDue.ToString("yyyy-MM-dd");
                                string strCountOne = "1";

                                if (decCurrLoanAmount >= decMI)
                                {
                                    decTotalDebit = decTotalDebit + decMI;
                                    if (strBranchCode == "SO")
                                    {
                                        decSo = decSo + decMI;
                                    }
                                    else if (strBranchCode == "TM")
                                    {
                                        decTm = decTm + decMI;
                                    }
                                    else if (strBranchCode == "BE")
                                    {
                                        decBE = decBE + decMI;
                                    }
                                    else if (strBranchCode == "CO")
                                    {
                                        decCo = decCo + decMI;
                                    }
                                    else if (strBranchCode == "NR")
                                    {
                                        decNr = decNr + decMI;
                                    }
                                    else if (strBranchCode == "RP")
                                    {
                                        decRp = decRp + decMI;
                                    }
                                }
                                else
                                {
                                    decTotalDebit = decTotalDebit + decCurrLoanAmount;
                                    if (strBranchCode == "SO")
                                    {
                                        decSo = decSo + decCurrLoanAmount;
                                    }
                                    else if (strBranchCode == "TM")
                                    {
                                        decTm = decTm + decCurrLoanAmount;
                                    }
                                    else if (strBranchCode == "BE")
                                    {
                                        decBE = decBE + decCurrLoanAmount;
                                    }
                                    else if (strBranchCode == "CO")
                                    {
                                        decCo = decCo + decCurrLoanAmount;
                                    }
                                    else if (strBranchCode == "NR")
                                    {
                                        decNr = decNr + decCurrLoanAmount;
                                    }
                                    else if (strBranchCode == "RP")
                                    {
                                        decRp = decRp + decCurrLoanAmount;
                                    }
                                }

                                //Add Arreas 
                                if (decDebit > 0)
                                {
                                    decimal decArreas = decDebit;
                                    int intArreasCount = Convert.ToInt32(decArreas) / Convert.ToInt32(decMI);



                                    if (intArreasCount > 3)
                                    {
                                        //Add Default Charges
                                        decimal decAPras = decArreas * 60 / 100;
                                        decimal decODefa = decimal.Round(decAPras / 360, 2, MidpointRounding.AwayFromZero);

                                        string strODefa = Convert.ToString(decODefa);

                                        decimal decRealArres = decimal.Round(decODefa + decArreas, 2, MidpointRounding.AwayFromZero);

                                        decimal decDArresCount = decRealArres / decMI;
                                        int intDArreasCount = Convert.ToInt32(decDArresCount);

                                        //Get Current Balance
                                        string strOCurBalance;
                                        decimal decOCurBalance = 0;
                                        DataSet dsGetDefault = objDBTask.selectData("select curr_balance from micro_payme_summery where contra_code = '" + strCCode + "' order by idcons_payme_summery desc limit 1;");
                                        if (dsGetDefault.Tables[0].Rows.Count > 0)
                                        {
                                            strOCurBalance = dsGetDefault.Tables[0].Rows[0]["curr_balance"].ToString();
                                            decOCurBalance = Convert.ToDecimal(strOCurBalance);
                                        }

                                        decimal decODefau = 0;

                                        decODefau = decimal.Round(decODefa + decOCurBalance, 2, MidpointRounding.AwayFromZero);
                                        string strODefau = Convert.ToString(decODefau);

                                        string strDCount = Convert.ToString(intDArreasCount);
                                        string strDArreaas = Convert.ToString(decRealArres);

                                        MySqlCommand cmdInsertPaySummD = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySummD.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
                                        cmdInsertPaySummD.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
                                        cmdInsertPaySummD.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
                                        cmdInsertPaySummD.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
                                        cmdInsertPaySummD.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
                                        cmdInsertPaySummD.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
                                        cmdInsertPaySummD.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
                                        cmdInsertPaySummD.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
                                        cmdInsertPaySummD.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
                                        cmdInsertPaySummD.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                        cmdInsertPaySummD.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySummD.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySummD.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySummD.Parameters["@amount"].Value = strODefa;
                                        cmdInsertPaySummD.Parameters["@capital"].Value = strZero;
                                        cmdInsertPaySummD.Parameters["@interest"].Value = strZero;
                                        cmdInsertPaySummD.Parameters["@debit"].Value = strZero;
                                        cmdInsertPaySummD.Parameters["@c_default"].Value = strODefa;
                                        cmdInsertPaySummD.Parameters["@rcp_no"].Value = "-";
                                        cmdInsertPaySummD.Parameters["@p_type"].Value = "D";
                                        cmdInsertPaySummD.Parameters["@date_time"].Value = strCDate;
                                        cmdInsertPaySummD.Parameters["@curr_balance"].Value = strODefau;
                                        #endregion

                                        int ww;
                                        ww = objDBTask.insertEditData(cmdInsertPaySummD);

                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount + '" + strODefa + "',due_date = '" + strDueDate + "',arres_amou = '" + strDArreaas + "',def = def + '" + strODefa + "',over_payment = '" + strZero + "',arres_count = '" + strDCount + "',due_installment = due_installment + '" + strCountOne + "' where contra_code = '" + strCCode + "';");
                                        int ii;
                                        ii = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                    }
                                    else
                                    {
                                        string strCount = Convert.ToString(intArreasCount);
                                        string strArreaas = Convert.ToString(decArreas);

                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueDate + "',arres_amou = '" + strArreaas + "',over_payment = '" + strZero + "',arres_count = '" + strCount + "',due_installment = due_installment + '" + strCountOne + "' where contra_code = '" + strCCode + "';");
                                        int ii;
                                        ii = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                    }
                                }
                                else
                                {
                                    string strCount = "0";
                                    string strArreaas = "0";

                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueDate + "',arres_amou = '" + strArreaas + "',over_payment = '" + strZero + "',arres_count = '" + strCount + "',due_installment = due_installment + '" + strCountOne + "' where contra_code = '" + strCCode + "';");
                                    int ii;
                                    ii = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }
                            }
                        }
                    }
                }

                string strTotalDebit = Convert.ToString(decTotalDebit);
                string strSo = Convert.ToString(decSo);
                string strTm = Convert.ToString(decTm);
                string strBe = Convert.ToString(decBE);
                string strCo = Convert.ToString(decCo);
                string strNr = Convert.ToString(decNr);
                string strRp = Convert.ToString(decRp);
                //string strManulDate = "2015-04-26";
                DataSet dsGetDueID = objDBTask.selectData("select * from due_history where update_date = '" + strDate + "';");
                if (dsGetDueID.Tables[0].Rows.Count > 0)
                {
                    MySqlCommand cmdUpdateDueAmou = new MySqlCommand("Update due_history set micro = '" + strTotalDebit + "',micro_so = '" + strSo + "',micro_tm = '" + strTm + "',micro_be = '" + strBe + "',micro_co = '" + strCo + "',micro_nr = '" + strNr + "',micro_rp = '" + strRp + "' where update_date = '" + strDate + "';");
                    int z;
                    z = objDBTask.insertEditData(cmdUpdateDueAmou);
                }
                else
                {
                    MySqlCommand cmdInsertDue = new MySqlCommand("insert into due_history (update_date,micro,create_user_nic,create_ip,date_time,micro_so,micro_tm,micro_be,micro_co,micro_nr,micro_rp)value(@update_date,@micro,@create_user_nic,@create_ip,@date_time,@micro_so,@micro_tm,@micro_be,@micro_co,@micro_nr,@micro_rp);");

                    #region Assign Parameters
                    cmdInsertDue.Parameters.Add("@update_date", MySqlDbType.VarChar, 45);
                    cmdInsertDue.Parameters.Add("@micro", MySqlDbType.Decimal, 12);
                    cmdInsertDue.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
                    cmdInsertDue.Parameters.Add("@create_ip", MySqlDbType.VarChar, 45);
                    cmdInsertDue.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                    cmdInsertDue.Parameters.Add("@micro_so", MySqlDbType.Decimal, 12);
                    cmdInsertDue.Parameters.Add("@micro_tm", MySqlDbType.Decimal, 12);
                    cmdInsertDue.Parameters.Add("@micro_be", MySqlDbType.Decimal, 12);
                    cmdInsertDue.Parameters.Add("@micro_co", MySqlDbType.Decimal, 12);
                    cmdInsertDue.Parameters.Add("@micro_nr", MySqlDbType.Decimal, 12);
                    cmdInsertDue.Parameters.Add("@micro_rp", MySqlDbType.Decimal, 12);
                    #endregion

                    #region DEclare Parametes
                    cmdInsertDue.Parameters["@update_date"].Value = strDate;
                    cmdInsertDue.Parameters["@micro"].Value = strTotalDebit;
                    cmdInsertDue.Parameters["@create_user_nic"].Value = strloginID;
                    cmdInsertDue.Parameters["@create_ip"].Value = strIp;
                    cmdInsertDue.Parameters["@date_time"].Value = strCDate;
                    cmdInsertDue.Parameters["@micro_so"].Value = strSo;
                    cmdInsertDue.Parameters["@micro_tm"].Value = strTm;
                    cmdInsertDue.Parameters["@micro_be"].Value = strBe;
                    cmdInsertDue.Parameters["@micro_co"].Value = strCo;
                    cmdInsertDue.Parameters["@micro_nr"].Value = strNr;
                    cmdInsertDue.Parameters["@micro_rp"].Value = strRp;
                    #endregion

                    int s;
                    s = objDBTask.insertEditData(cmdInsertDue);
                }

                lblMsg.Text = "Succsesfully Completed."; 
            }
            else
            {
                lblMsg.Text = "Can not be empty"; 
            }
        }
    }
}
