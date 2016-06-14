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
    public partial class End_of_Day : System.Web.UI.Page
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
            lblMsg.Text = "";

            string strloginID = Session["NIC"].ToString();
            string strIp = Request.UserHostAddress;

            MySqlCommand cmdSelect = new MySqlCommand("select * from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P' or c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'D';");
            dtLoanDet = objDBTask.selectData(cmdSelect);

            if (dtLoanDet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtLoanDet.Tables[0].Rows.Count; i++)
                {
                    string strCurrentLoanAmoun = dtLoanDet.Tables[0].Rows[i]["current_loan_amount"].ToString();
                    string strCreteDate = dtLoanDet.Tables[0].Rows[i]["chequ_deta_on"].ToString();
                    string strDDate = dtLoanDet.Tables[0].Rows[i]["due_date"].ToString();
                    string strCCode = dtLoanDet.Tables[0].Rows[i]["contra_code"].ToString();
                    string strNIC = dtLoanDet.Tables[0].Rows[i]["nic"].ToString();
                    string strMoIns = dtLoanDet.Tables[0].Rows[i]["monthly_instollment"].ToString();
                    string strArr = dtLoanDet.Tables[0].Rows[i]["arres_amou"].ToString();
                    string strOverPay = dtLoanDet.Tables[0].Rows[i]["over_payment"].ToString();
                    string strStatus = dtLoanDet.Tables[0].Rows[i]["loan_sta"].ToString();

                    decimal decOverPay = Convert.ToDecimal(strOverPay);
                    decimal decMIns = Convert.ToDecimal(strMoIns);
                    decimal decOldArr = Convert.ToDecimal(strArr);
                    string strCDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    DateTime dtDDate = Convert.ToDateTime(strDDate);
                    DateTime dtCDate = Convert.ToDateTime(strCDate);
                    DateTime dtCeqDate = Convert.ToDateTime(strCreteDate);

                    TimeSpan tsArias = dtDDate.Subtract(dtCeqDate);
                    string strResult = tsArias.Days.ToString();
                    //Update 2014.06.01
                    int intResu = Convert.ToInt32(strResult);
                    int intWeek = intResu / 7;
                    //Check Due
                    DateTime now = Convert.ToDateTime(strDDate);
                    DateTime Curre = DateTime.Now;
                    TimeSpan tsLive = Curre.Subtract(now);
                    string strLive = tsLive.Days.ToString();
                    //Update 2014.06.01
                    int intLive = Convert.ToInt32(strLive);
                    DateTime dueNew;
                    decimal decWeek = 0;
                    if (intLive <= 0)
                    {
                        dueNew = now;
                        decWeek = Convert.ToDecimal(intWeek) - 1;
                    }
                    else
                    {
                        decWeek = Convert.ToDecimal(intWeek);
                        dueNew = now.AddDays(7);
                    }

                    
                    
                    string strTotPaym, strTotaDefua;
                    decimal decToPaym, decTotDafua, decArresCount;
                    int intArresCount;

                    DataSet dsChkPayHiss = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
                    if (dsChkPayHiss.Tables[0].Rows[0][0].ToString() != "")
                    {
                        strTotPaym = dsChkPayHiss.Tables[0].Rows[0][0].ToString();
                        decToPaym = Convert.ToDecimal(strTotPaym);

                        DataSet dsChkDefauu = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'D';");
                        if (dsChkDefauu.Tables[0].Rows[0][0].ToString() != "")
                        {
                            strTotaDefua = dsChkDefauu.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            strTotaDefua = "0";
                        }

                        decTotDafua = Convert.ToDecimal(strTotaDefua);
                    }
                    else
                    {
                        decToPaym = 0;
                        DataSet dsChkDefauu = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'D';");
                        if (dsChkDefauu.Tables[0].Rows[0][0].ToString() != "")
                        {
                            strTotaDefua = dsChkDefauu.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            strTotaDefua = "0";
                        }

                        decTotDafua = Convert.ToDecimal(strTotaDefua);
                    }

                    decimal decToPay = (decMIns * decWeek) + decTotDafua;
                    //decimal decPaiedTotal = decToPaym + decTotDafua;
                    decimal decArres = decToPay - decToPaym;
                    if (decArres > 0)
                    {
                        decArresCount = decArres / decMIns;
                        intArresCount = Convert.ToInt32(decArresCount);
                    }
                    else
                    {
                        intArresCount = 0;
                    }

                    string strZero = "0";
                    string strArresCount = Convert.ToString(intArresCount);

                    //DateTime prev = now.AddMonths(-1);
                    decimal decOVerPay = decToPaym - decToPay;
                    decimal decROVerPay = decimal.Round(decOVerPay, 2, MidpointRounding.AwayFromZero);
                    string strOVerrPay = Convert.ToString(decROVerPay);

                    string strDueNew = dueNew.ToString("yyyy-MM-dd HH:mm:ss");
                    //if (strResult == "1")
                    if (intArresCount > 4)
                    {
                        //Arrers Interest

                        decimal decInsInterests = (decMIns * 5) / 100;
                        decimal decInsInterest = decimal.Round(decInsInterests, 2, MidpointRounding.AwayFromZero);
                        string strDefu = Convert.ToString(decInsInterest);

                        string strArreInter = Convert.ToString(decInsInterest);

                        if (decOldArr <= 0)
                        {
                            if (decOverPay >= decMIns)
                            {
                                MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueNew + "',over_payment = over_payment - '" + strMoIns + "',arres_count = '" + strZero + "' where contra_code = '" + strCCode + "';");
                                int c;
                                c = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                            }
                            else
                            {
                                //DataSet dsChkPayHis = objDBTask.selectData("select sum(amount) from rbf_payme_summery where contra_code = '" + strCCode + "' and p_type = 'DI';");
                                if (dsChkPayHiss.Tables[0].Rows[0][0].ToString() != "")
                                {
                                    if (decToPaym >= decToPay)
                                    {
                                        MySqlCommand cmdUpdateLoanAmouuu = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueNew + "',over_payment = '" + strOVerrPay + "',arres_count = '" + strZero + "' where contra_code = '" + strCCode + "';");
                                        int k;
                                        k = objDBTask.insertEditData(cmdUpdateLoanAmouuu);
                                    }
                                    else
                                    {
                                        decimal decArrAmount = (decToPay - decToPaym) + decInsInterest;
                                        string strArreAmoun = Convert.ToString(decArrAmount);

                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount + '" + strArreInter + "',due_date = '" + strDueNew + "',over_payment = '" + strZero + "',arres_amou = arres_amou + '" + strArreAmoun + "',def = def + '" + strDefu + "',arres_count = '" + strArresCount + "' where contra_code = '" + strCCode + "';");
                                        int ii;
                                        ii = objDBTask.insertEditData(cmdUpdateLoanAmou);

                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time);");

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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strDefu;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strZero;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strZero;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strZero;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDefu;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "D";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strCDate;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                }
                                else
                                {
                                    decimal decArrAmount = decMIns + decInsInterest;
                                    string strArreAmoun = Convert.ToString(decArrAmount);

                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount + '" + strArreInter + "',due_date = '" + strDueNew + "',over_payment = '" + strZero + "',arres_amou = arres_amou + '" + strArreAmoun + "',def = def + '" + strDefu + "',arres_count = '" + strArresCount + "' where contra_code = '" + strCCode + "';");
                                    int ii;
                                    ii = objDBTask.insertEditData(cmdUpdateLoanAmou);

                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time);");

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
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strDefu;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strZero;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strZero;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strZero;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDefu;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "D";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strCDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }

                            }
                        }
                        else
                        {
                            decimal decNewDef2 = ((decOldArr + decMIns) * 5) / 100;
                            decimal decNewDef2Rou = decimal.Round(decNewDef2, 2, MidpointRounding.AwayFromZero);
                            string strNewDef2 = Convert.ToString(decNewDef2Rou);

                            decimal decCurrentLA = Convert.ToDecimal(strCurrentLoanAmoun);
                            decimal decNewToArre = 0;
                            string strNewToAree = "";
                            if (strStatus == "D")
                            {
                                decNewToArre = decNewDef2Rou + decCurrentLA;
                                strNewToAree = Convert.ToString(decNewToArre);

                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount + '" + strNewDef2 + "',due_date = '" + strDueNew + "',over_payment = '" + strZero + "',arres_amou = arres_amou + '" + strNewDef2 + "',def = def + '" + strNewDef2 + "',arres_count = '" + strArresCount + "' where contra_code = '" + strCCode + "';");
                                int ii;
                                ii = objDBTask.insertEditData(cmdUpdateLoanAmou);

                                //add payment summery
                                MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time);");

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
                                #endregion

                                #region DEclare Parametes
                                cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                cmdInsertPaySumm.Parameters["@amount"].Value = strNewDef2;
                                cmdInsertPaySumm.Parameters["@capital"].Value = strZero;
                                cmdInsertPaySumm.Parameters["@interest"].Value = strZero;
                                cmdInsertPaySumm.Parameters["@debit"].Value = strZero;
                                cmdInsertPaySumm.Parameters["@c_default"].Value = strNewDef2;
                                cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                                cmdInsertPaySumm.Parameters["@p_type"].Value = "D";
                                cmdInsertPaySumm.Parameters["@date_time"].Value = strCDate;
                                #endregion

                                int w;
                                w = objDBTask.insertEditData(cmdInsertPaySumm);
                            }
                            else
                            {
                                //DataSet dsChkPayHis = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
                                if (dsChkPayHiss.Tables[0].Rows[0][0].ToString() != "")
                                {
                                    if (decToPaym >= decToPay)
                                    {
                                        MySqlCommand cmdUpdateLoanAmouuu = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueNew + "',over_payment = '" + strOVerrPay + "',arres_count = '" + strZero + "' where contra_code = '" + strCCode + "';");
                                        int k;
                                        k = objDBTask.insertEditData(cmdUpdateLoanAmouuu);
                                    }
                                    else
                                    {
                                        decimal decArrAmount = (decToPay - decToPaym) + decNewDef2Rou;
                                        string strArreAmoun = Convert.ToString(decArrAmount);

                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount + '" + strNewDef2 + "',due_date = '" + strDueNew + "',over_payment = '" + strZero + "',arres_amou = '" + strArreAmoun + "',def = def + '" + strNewDef2 + "',arres_count = '" + strArresCount + "' where contra_code = '" + strCCode + "';");
                                        int ii;
                                        ii = objDBTask.insertEditData(cmdUpdateLoanAmou);

                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time);");

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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strNewDef2;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strZero;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strZero;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strZero;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strNewDef2;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "D";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strCDate;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);

                                    }
                                }
                                else
                                {
                                    decimal decArrAmount = decMIns + decNewDef2Rou + decOldArr;
                                    string strArreAmoun = Convert.ToString(decArrAmount);

                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount + '" + strNewDef2 + "',due_date = '" + strDueNew + "',over_payment = '" + strZero + "',arres_amou = '" + strArreAmoun + "',def = def + '" + strNewDef2 + "',arres_count = '" + strArresCount + "' where contra_code = '" + strCCode + "';");
                                    int ii;
                                    ii = objDBTask.insertEditData(cmdUpdateLoanAmou);

                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time);");

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
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strNewDef2;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strZero;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strZero;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strZero;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strNewDef2;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "D";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strCDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                            }
                        }
                    }
                    else if (intArresCount >= 1 && intArresCount <= 4)
                    {
                        //DateTime dtN = DateTime.Now;
                        //DateTime dtPDay = dtN.AddDays(7);
                        if (intLive <= 0)
                        {
                            dueNew = now;
                        }
                        else
                        {
                            dueNew = now.AddDays(7);
                        }
                        string strNOw = dueNew.ToString("yyyy-MM-dd HH:mm:ss");
                        //DataSet dsChkPayHis = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
                        if (dsChkPayHiss.Tables[0].Rows[0][0].ToString() != "")
                        {
                            if (decToPaym >= decToPay)
                            {
                                decimal decOP = decToPaym - decToPay;
                                string strOP = Convert.ToString(decOP);
                                MySqlCommand cmdUpdateLoanAmouuu = new MySqlCommand("Update micro_loan_details set due_date = '" + strNOw + "',over_payment = '" + strOVerrPay + "',arres_amou = '" + strZero + "',over_payment = '" + strOP + "',arres_count = '" + strZero + "' where contra_code = '" + strCCode + "';");
                                int k;
                                k = objDBTask.insertEditData(cmdUpdateLoanAmouuu);
                            }
                            else
                            {
                                decimal decArrAmount = (decToPay - decToPaym);
                                string strArreAmoun = Convert.ToString(decArrAmount);

                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set due_date = '" + strNOw + "',arres_amou = '" + strArreAmoun + "',def = def + '" + strTotaDefua + "',over_payment = '" + strZero + "',arres_count = '" + strArresCount + "' where contra_code = '" + strCCode + "';");
                                int ii;
                                ii = objDBTask.insertEditData(cmdUpdateLoanAmou);

                            }
                        }
                        else
                        {
                            string strToDe = "";
                            DataSet dsChkDefalt = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'D';");
                            if (dsChkDefalt.Tables[0].Rows[0][0].ToString() != "")
                            {
                                strToDe = dsChkDefalt.Tables[0].Rows[0][0].ToString();
                            }
                            else
                            {
                                strToDe = "0";
                            }

                            decimal decTotDaf = Convert.ToDecimal(strToDe);

                            decimal decCount = Convert.ToDecimal(intArresCount);
                            decimal decArrAmount = (decMIns * decCount) + decTotDaf;
                            string strArreAmoun = Convert.ToString(decArrAmount);

                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set due_date = '" + strDueNew + "',arres_amou = '" + strArreAmoun + "',over_payment = '" + strZero + "',arres_count = '" + strArresCount + "' where contra_code = '" + strCCode + "';");
                            int ii;
                            ii = objDBTask.insertEditData(cmdUpdateLoanAmou);

                        }
                    }
                }
            }

        }
    }
}
