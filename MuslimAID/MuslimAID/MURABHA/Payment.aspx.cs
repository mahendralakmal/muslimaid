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
    public partial class Payment : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            { }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void txtContrCod_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            txtAmount.Text = "";
            txtNIC.Text = "";
            if (txtContrCod.Text.Trim() != "")
            {
                string strCC = txtContrCod.Text.Trim();
                DataSet dsCD = objDBTask.selectData("select c.nic,l.current_loan_amount,l.monthly_instollment,l.arres_amou,c.initial_name from micro_loan_details l, micro_basic_detail c where l.contra_code = c.contract_code and l.contra_code = '" + strCC + "' and l.loan_approved = 'Y' and l.chequ_no != '';");
                if (dsCD.Tables[0].Rows.Count > 0)
                {
                    txtNIC.Text = dsCD.Tables[0].Rows[0]["nic"].ToString();
                    lblFullBala.Text = dsCD.Tables[0].Rows[0]["current_loan_amount"].ToString();
                    lblMIns.Text = dsCD.Tables[0].Rows[0]["monthly_instollment"].ToString();
                    lblArre.Text = dsCD.Tables[0].Rows[0]["arres_amou"].ToString();
                    lblName.Text = dsCD.Tables[0].Rows[0]["initial_name"].ToString();
                    btnPeied.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "Invalid Contract Code.";
                    btnPeied.Enabled = false;
                }
            }
            else
            {
                lblMsg.Text = "Please enter Contract Code.";
            }
        }

        protected void btnPeied_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtContrCod.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Contract Code.";
            }
            else if (txtNIC.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter NIC/Passport No/DL.";
            }
            else if (txtAmount.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Amount";
            }
            else
            {
                string strAmo = txtAmount.Text.Trim();
                string strloginID = Session["NIC"].ToString();
                string strCCode = txtContrCod.Text.Trim();
                string strNIC = txtNIC.Text.Trim();
                string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strIp = Request.UserHostAddress;

                MySqlCommand cmdInsertMonthPaym = new MySqlCommand("INSERT INTO micro_pais_history(contra_code,NIC,paied_amount,date_time,user_nic,user_ip,tra_description,pay_status,reson)VALUES(@contra_code,@NIC,@paied_amount,@date_time,@user_nic,@user_ip,@tra_description,@pay_status,@reson);");

                #region Assign Parameters
                cmdInsertMonthPaym.Parameters.Add("@contra_code", MySqlDbType.VarChar, 13);
                cmdInsertMonthPaym.Parameters.Add("@NIC", MySqlDbType.VarChar, 15);
                cmdInsertMonthPaym.Parameters.Add("@paied_amount", MySqlDbType.Decimal, 9);
                cmdInsertMonthPaym.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                cmdInsertMonthPaym.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
                cmdInsertMonthPaym.Parameters.Add("@user_ip", MySqlDbType.VarChar, 20);
                cmdInsertMonthPaym.Parameters.Add("@tra_description", MySqlDbType.VarChar, 3);
                cmdInsertMonthPaym.Parameters.Add("@pay_status", MySqlDbType.VarChar, 1);
                cmdInsertMonthPaym.Parameters.Add("@reson", MySqlDbType.VarChar, 45);
                #endregion

                #region DEclare Parametes
                cmdInsertMonthPaym.Parameters["@contra_code"].Value = strCCode;
                cmdInsertMonthPaym.Parameters["@NIC"].Value = strNIC;
                cmdInsertMonthPaym.Parameters["@paied_amount"].Value = strAmo;
                cmdInsertMonthPaym.Parameters["@date_time"].Value = strDate;
                cmdInsertMonthPaym.Parameters["@user_nic"].Value = strloginID;
                cmdInsertMonthPaym.Parameters["@user_ip"].Value = strIp;
                cmdInsertMonthPaym.Parameters["@tra_description"].Value = "WI";
                cmdInsertMonthPaym.Parameters["@pay_status"].Value = "D";
                cmdInsertMonthPaym.Parameters["@reson"].Value = "";
                #endregion

                try
                {
                    int f;
                    f = objDBTask.insertEditData(cmdInsertMonthPaym);
                    if (f == 1)
                    {
                        lblMsg.Text = "Payment is Succsessfuled.";
                        btnPeied.Enabled = false;
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {
                }

                //Get Recipt Number
                string strRNum;
                DataSet dsGetReciNum = objDBTask.selectData("select max(idpais_history) from micro_pais_history where contra_code = '" + strCCode + "' and date_time = '" + strDate + "';");
                strRNum = dsGetReciNum.Tables[0].Rows[0][0].ToString();

                decimal decAmou = Convert.ToDecimal(strAmo);

                DataSet dsCheckArre = objDBTask.selectData("select current_loan_amount,interest_amount,period,monthly_instollment,chequ_deta_on,due_date,arres_amou,def from micro_loan_details where contra_code = '" + strCCode + "';");
                if (dsCheckArre.Tables[0].Rows.Count != 0)
                {
                    string strCuLoanAmount = dsCheckArre.Tables[0].Rows[0]["current_loan_amount"].ToString();
                    string strIA = dsCheckArre.Tables[0].Rows[0]["interest_amount"].ToString();
                    string strP = dsCheckArre.Tables[0].Rows[0]["period"].ToString();
                    string strOldMI = dsCheckArre.Tables[0].Rows[0]["monthly_instollment"].ToString();
                    string strChequDate = dsCheckArre.Tables[0].Rows[0]["chequ_deta_on"].ToString();
                    string strDueD = dsCheckArre.Tables[0].Rows[0]["due_date"].ToString();
                    string strOldArre = dsCheckArre.Tables[0].Rows[0]["arres_amou"].ToString();
                    string strDefult = dsCheckArre.Tables[0].Rows[0]["def"].ToString();
                    decimal decDefult = Convert.ToDecimal(strDefult);
                    decimal decDebit = decAmou - decDefult;
                    string strDebit = Convert.ToString(decDebit);
                    decimal decOMI = Convert.ToDecimal(strOldMI);
                    decimal decOA = Convert.ToDecimal(strOldArre);
                    decimal decDebit2 = decOA - decDefult;
                    string strDebit2 = Convert.ToString(decDebit2);
                    decimal decDueAmou = decOMI + decOA;
                    decimal decIA = Convert.ToDecimal(strIA);
                    decimal decPe = Convert.ToDecimal(strP);
                    decimal decOneIn = decIA / decPe;
                    decimal decroundOnIn = decimal.Round(decOneIn, 2, MidpointRounding.AwayFromZero);
                    string strOneIn = Convert.ToString(decroundOnIn);
                    decimal decArrIntePlu = decAmou - (decOA + decroundOnIn);
                    int intArrIntePlu = Convert.ToInt32(decArrIntePlu);
                    string strCapi = Convert.ToString(decArrIntePlu);
                    decimal decOverPay = decOA + decOMI;
                    decimal decOverPayAmou = decAmou - decOverPay;
                    string strOverPayAmou = Convert.ToString(decOverPayAmou);
                    string strDef = "0";
                    decimal decCuLoaAmount = Convert.ToDecimal(strCuLoanAmount);

                    if (decOA > 0)
                    {
                        if (decAmou >= decOA)
                        {
                            if (decOverPay >= decAmou)
                            {
                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = '" + strDef + "',def = '" + strDef + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
                                int i;
                                i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                            }
                            else
                            {
                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = over_payment + '" + strOverPayAmou + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
                                int i;
                                i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                            }

                            if (decArrIntePlu > 0)
                            {
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
                                cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                cmdInsertPaySumm.Parameters["@capital"].Value = strCapi;
                                cmdInsertPaySumm.Parameters["@interest"].Value = strOneIn;
                                cmdInsertPaySumm.Parameters["@debit"].Value = strDebit2;
                                cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                #endregion

                                int w;
                                w = objDBTask.insertEditData(cmdInsertPaySumm);
                            }
                            else if (decArrIntePlu == 0)
                            {
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
                                cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@interest"].Value = strOneIn;
                                cmdInsertPaySumm.Parameters["@debit"].Value = strDebit2;
                                cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                #endregion

                                int w;
                                w = objDBTask.insertEditData(cmdInsertPaySumm);
                            }
                            else
                            {
                                decimal decMinInt = decAmou - decOA;
                                string strMinInt = Convert.ToString(decMinInt);
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
                                cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@interest"].Value = strMinInt;
                                cmdInsertPaySumm.Parameters["@debit"].Value = strDebit2;
                                cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                #endregion

                                int w;
                                w = objDBTask.insertEditData(cmdInsertPaySumm);
                            }
                        }
                        else
                        {
                            if (decDefult > 0)
                            {
                                if (decDefult >= decAmou)
                                {
                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = arres_amou - '" + strAmo + "',def = def - '" + strAmo + "'  where contra_code = '" + strCCode + "';");
                                    int i;
                                    i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }
                                else
                                {
                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = arres_amou - '" + strAmo + "',def = '" + strDef + "'  where contra_code = '" + strCCode + "';");
                                    int i;
                                    i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }
                            }
                            else
                            {
                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = arres_amou - '" + strAmo + "' where contra_code = '" + strCCode + "';");
                                int i;
                                i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                            }


                            if (decDefult >= decAmou)
                            {
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
                                cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@c_default"].Value = strAmo;
                                cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                #endregion

                                int w;
                                w = objDBTask.insertEditData(cmdInsertPaySumm);
                            }
                            else
                            {
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
                                cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@debit"].Value = strDebit;
                                cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                #endregion

                                int w;
                                w = objDBTask.insertEditData(cmdInsertPaySumm);
                            }
                        }
                    }
                    else
                    {
                        if (decOMI >= decAmou)
                        {
                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "' where contra_code = '" + strCCode + "';");
                            int i;
                            i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                        }
                        else
                        {
                            decimal decOP2 = decAmou - decOMI;
                            string strOP2 = Convert.ToString(decOP2);
                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',over_payment = over_payment + '" + strOP2 + "' where contra_code = '" + strCCode + "';");
                            int i;
                            i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                        }

                        //CHECK NOW--------------Edit 2014.08.18
                        DataSet dsCheckInter = objDBTask.selectData("select sum(interest) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
                        if (dsCheckInter.Tables[0].Rows[0][0].ToString() != "")
                        {
                            string strPaidInte = dsCheckInter.Tables[0].Rows[0][0].ToString();
                            decimal decCuPaidIn = Convert.ToDecimal(strPaidInte);
                            if (decCuLoaAmount > decAmou)
                            {
                                DateTime dtDueDate = Convert.ToDateTime(strDueD);
                                DateTime dtCheqDate = Convert.ToDateTime(strChequDate);
                                TimeSpan tsTotalDay = dtDueDate.Subtract(dtCheqDate);
                                string strTotalDay = tsTotalDay.Days.ToString();
                                int intTotalDay = Convert.ToInt32(strTotalDay);
                                int intToMonth = intTotalDay / 7;
                                decimal decToMonth = Convert.ToDecimal(intToMonth);
                                decimal decCurrPayIn = decToMonth * decOneIn;
                                decimal decInteBala = decCurrPayIn - decCuPaidIn;
                                decimal decRoundIB = decimal.Round(decInteBala, 2, MidpointRounding.AwayFromZero);
                                string strInterBalan = Convert.ToString(decRoundIB);
                                if (decInteBala <= 0)
                                {
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
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else if (decInteBala > 0 && decAmou > decInteBala)
                                {
                                    decimal decMainCap = decAmou - decRoundIB;
                                    string strMainCap = Convert.ToString(decMainCap);

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
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strMainCap;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strInterBalan;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else if (decInteBala > 0 && decAmou <= decInteBala)
                                {
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
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                            }
                            else
                            {
                                decimal decBalaInte = decIA - decCuPaidIn;
                                string strBalaInte = Convert.ToString(decBalaInte);
                                if (decBalaInte <= 0)
                                {
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
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else if (decBalaInte > 0 && decAmou > decBalaInte)
                                {
                                    decimal decNowCredit = decAmou - decBalaInte;
                                    string strNowCredit = Convert.ToString(decNowCredit);

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
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strNowCredit;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strBalaInte;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else if (decBalaInte > 0 && decAmou <= decBalaInte)
                                {
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
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                            }
                        }
                        else
                        {
                            if (decCuLoaAmount > decAmou)
                            {
                                DateTime dtDueDate = Convert.ToDateTime(strDueD);
                                DateTime dtCheqDate = Convert.ToDateTime(strChequDate);
                                TimeSpan tsTotalDay = dtDueDate.Subtract(dtCheqDate);
                                string strTotalDay = tsTotalDay.Days.ToString();
                                int intTotalDay = Convert.ToInt32(strTotalDay);
                                int intToMonth = intTotalDay / 7;
                                decimal decToMonth = Convert.ToDecimal(intToMonth);
                                decimal decCurrPayIn = decToMonth * decOneIn;
                                decimal decRoundCurrPay = decimal.Round(decCurrPayIn, 2, MidpointRounding.AwayFromZero);
                                string strCuI = Convert.ToString(decRoundCurrPay);
                                if (decCurrPayIn >= decAmou)
                                {
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
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else
                                {
                                    decimal decMina = decAmou - decRoundCurrPay;
                                    string strCapii = Convert.ToString(decMina);

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
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strCapii;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strCuI;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                            }
                            else
                            {
                                decimal decCap = decAmou - decIA;
                                string strCapit = Convert.ToString(decCap);

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
                                cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                cmdInsertPaySumm.Parameters["@capital"].Value = strCapit;
                                cmdInsertPaySumm.Parameters["@interest"].Value = strIA;
                                cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                #endregion

                                int w;
                                w = objDBTask.insertEditData(cmdInsertPaySumm);
                            }
                        }
                    }
                }

                //Add Due Date


                DataSet dsCheckMonIns = objDBTask.selectData("select * from micro_loan_details where contra_code = '" + strCCode + "';");

                string strCreteDate = dsCheckMonIns.Tables[0].Rows[0]["chequ_deta_on"].ToString();
                string strMoIns = dsCheckMonIns.Tables[0].Rows[0]["monthly_instollment"].ToString();
                string strDueDate = dsCheckMonIns.Tables[0].Rows[0]["due_date"].ToString();
                string strArreAmou = dsCheckMonIns.Tables[0].Rows[0]["arres_amou"].ToString();

                decimal decMoIns = Convert.ToDecimal(strMoIns);
                decimal decArreAmo = Convert.ToDecimal(strArreAmou);
                DateTime dtDDate = Convert.ToDateTime(strDueDate);

                if (decArreAmo <= 0)
                {
                    DataSet dsChkPayHis = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
                    if (dsChkPayHis.Tables[0].Rows[0][0].ToString() != "")
                    {
                        string strTotPaym = dsChkPayHis.Tables[0].Rows[0][0].ToString();
                        decimal decToPaym = Convert.ToDecimal(strTotPaym);
                        DateTime dtCreDate = Convert.ToDateTime(strCreteDate);
                        TimeSpan tsTotaDay = dtDDate.Subtract(dtCreDate);
                        string strToDay = tsTotaDay.Days.ToString();
                        int intToDay = Convert.ToInt32(strToDay);
                        decimal decDays = Convert.ToDecimal(intToDay) / 7;
                        //int intMonth = intToDay / 30;
                        //decimal decMonth = Convert.ToDecimal(intMonth);
                        string strTotaDefua;
                        DataSet dsChkDefau = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'D';");
                        if (dsChkDefau.Tables[0].Rows[0][0].ToString() != "")
                        {
                            strTotaDefua = dsChkDefau.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            strTotaDefua = "0";
                        }
                        decimal decTotDafua = Convert.ToDecimal(strTotaDefua);
                        decimal decTotPayAmou = 0;
                        if (decDays <= 1)
                        {
                            decTotPayAmou = (decMoIns * 1) + decTotDafua;
                        }
                        else
                        {
                            decTotPayAmou = (decMoIns * decDays) + decTotDafua;
                        }

                        decTotPayAmou = (decMoIns * decDays) + decTotDafua;
                        decimal decRoundPayAmo = decimal.Round(decTotPayAmou, 2, MidpointRounding.AwayFromZero);
                        if (decToPaym >= decRoundPayAmo)
                        {
                            DateTime due;
                            //string strDayName = dtDDate.DayOfWeek.ToString();
                            //if (strDayName == "Thursday")
                            //{
                            //    due = dtDDate.AddDays(3);
                            //}
                            //else
                            //{
                            //    due = dtDDate.AddDays(1);
                            //}
                            due = dtDDate.AddDays(7);

                            string strDue = Convert.ToString(due);
                            string strZero = "0";

                            MySqlCommand cmdUpdateLoanDueDa = new MySqlCommand("Update micro_loan_details set due_date = '" + strDue + "',arres_count = '" + strZero + "' where contra_code = '" + strCCode + "';");

                            try
                            {
                                int b;
                                b = objDBTask.insertEditData(cmdUpdateLoanDueDa);
                                if (b == 1)
                                {
                                    lblMsg.Text = "Updated Successfully";

                                    //Session["contraCode"] = strCCode;
                                    //Session["amount"] = strAmo;
                                    Session["recno"] = strRNum;

                                    txtAmount.Text = "";
                                    txtContrCod.Text = "";
                                    txtNIC.Text = "";
                                    lblName.Text = "";
                                    lblArre.Text = "";
                                    lblFullBala.Text = "";
                                    lblMIns.Text = "";

                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ppUp", "PopUP();", true);

                                }
                                else
                                {
                                    lblMsg.Text = "Error occurred. Please try again.";
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            lblMsg.Text = "Updated Successfully";

                            //Session["contraCode"] = strCCode;
                            //Session["amount"] = strAmo;
                            Session["recno"] = strRNum;

                            txtAmount.Text = "";
                            txtContrCod.Text = "";
                            txtNIC.Text = "";
                            lblName.Text = "";
                            lblArre.Text = "";
                            lblFullBala.Text = "";
                            lblMIns.Text = "";

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ppUp", "PopUP();", true);
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "Updated Successfully";

                    //Session["contraCode"] = strCCode;
                    //Session["amount"] = strAmo;
                    Session["recno"] = strRNum;

                    txtAmount.Text = "";
                    txtContrCod.Text = "";
                    txtNIC.Text = "";
                    lblName.Text = "";
                    lblArre.Text = "";
                    lblFullBala.Text = "";
                    lblMIns.Text = "";

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ppUp", "PopUP();", true);
                }
            }
        }
    }
}
