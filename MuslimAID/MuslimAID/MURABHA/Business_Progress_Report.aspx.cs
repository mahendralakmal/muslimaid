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
    public partial class Business_Progress_Report : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    string strloginID = Session["NIC"].ToString();

                    DataSet dsUserTy = objDBTask.selectData("select nic from users where nic = '" + strloginID + "';");
                    if (dsUserTy.Tables[0].Rows.Count > 0)
                    {
                        string strNIC = dsUserTy.Tables[0].Rows[0]["nic"].ToString();
                        if (strNIC == "902554203V" || strNIC == "822030955V" || strNIC == "863511860V")
                        {
                            clear();
                        }
                        else
                        {
                            Response.Redirect("../Default.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            clear();
            if (txtDateFrom.Text.Trim() == "")
            {
                decimal decNoActiveClient = 0;
                decimal decActiveLoAmount = 0;
                decimal decActiveInterAmount = 0;
                DataSet dsGetNoActiveClient = objDBTask.selectData("select count(l.contra_code),sum(l.loan_amount),sum(l.interest_amount) from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P';");
                if (dsGetNoActiveClient.Tables[0].Rows[0][0].ToString() != "0")
                {
                    string strNoActiveClient = dsGetNoActiveClient.Tables[0].Rows[0][0].ToString();
                    string strActiveLoAmount = dsGetNoActiveClient.Tables[0].Rows[0][1].ToString();
                    string strActiveInterAmount = dsGetNoActiveClient.Tables[0].Rows[0][2].ToString();
                    decNoActiveClient = Convert.ToDecimal(strNoActiveClient);
                    decActiveLoAmount = Convert.ToDecimal(strActiveLoAmount);
                    decActiveInterAmount = Convert.ToDecimal(strActiveInterAmount);
                    lblActive.Text = strNoActiveClient;
                }
                else
                {
                    lblActive.Text = "0";
                }


                decimal decSettleLoAmount = 0;
                decimal decNoSettleClient = 0;
                decimal decSettleInterAmount = 0;
                DataSet dsGetNoSettleClient = objDBTask.selectData("select count(l.contra_code),sum(l.loan_amount),sum(l.interest_amount) from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'S';");
                if (dsGetNoSettleClient.Tables[0].Rows[0][0].ToString() != "0")
                {
                    string strNoSettleClient = dsGetNoSettleClient.Tables[0].Rows[0][0].ToString();
                    string strSettleLoAmount = dsGetNoSettleClient.Tables[0].Rows[0][1].ToString();
                    string strSettleInterAmount = dsGetNoSettleClient.Tables[0].Rows[0][2].ToString();
                    decSettleLoAmount = Convert.ToDecimal(strSettleLoAmount);
                    decNoSettleClient = Convert.ToDecimal(strNoSettleClient);
                    decSettleInterAmount = Convert.ToDecimal(strSettleInterAmount);
                    lblSettle.Text = strNoSettleClient;

                    lblDueSCapital.Text = decSettleLoAmount.ToString("#,##0.00");
                    lblDueSInterest.Text = decSettleInterAmount.ToString("#,##0.00");
                }
                else
                {
                    lblSettle.Text = "0";
                    lblDueSCapital.Text = "0.00";
                    lblDueSInterest.Text = "0.00";
                }



                decimal decMaturityLoAmount = 0;
                decimal decNoMaturityClient = 0;
                decimal decMatuInterAmount = 0;
                DataSet dsGetNoMaturityClient = objDBTask.selectData("select count(l.contra_code),sum(l.loan_amount),sum(l.interest_amount) from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'E';");
                if (dsGetNoMaturityClient.Tables[0].Rows[0][0].ToString() != "0")
                {
                    string strNoMaturityClient = dsGetNoMaturityClient.Tables[0].Rows[0][0].ToString();
                    string strMaturityLoAmount = dsGetNoMaturityClient.Tables[0].Rows[0][1].ToString();
                    string strMatuInterAmount = dsGetNoMaturityClient.Tables[0].Rows[0][2].ToString();
                    decMaturityLoAmount = Convert.ToDecimal(strMaturityLoAmount);
                    decNoMaturityClient = Convert.ToDecimal(strNoMaturityClient);
                    decMatuInterAmount = Convert.ToDecimal(strMatuInterAmount);
                    lblMatu.Text = strNoMaturityClient;
                }
                else
                {
                    lblMatu.Text = "0";
                }


                //Get Maturity Due Details
                lblDueMCapital.Text = decMaturityLoAmount.ToString("#,##0.00");
                lblDueMInterest.Text = decMatuInterAmount.ToString("#,##0.00");

                decimal decDueMaToCapInter = decMaturityLoAmount + decMatuInterAmount;

                DataSet dsGetMatDefault = objDBTask.selectData("select l.contra_code from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'E';");
                if (dsGetMatDefault.Tables[0].Rows.Count > 0)
                {
                    decimal decHPDefault = 0;
                    decimal decCollCapital = 0;
                    decimal decCollInterest = 0;
                    decimal decCollDefa = 0;
                    for (int i = 0; i < dsGetMatDefault.Tables[0].Rows.Count; i++)
                    {
                        string strCC = dsGetMatDefault.Tables[0].Rows[i]["contra_code"].ToString();

                        //Get Default Amount
                        DataSet dsGetHPDefault = objDBTask.selectData("select sum(c_default) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'D';");
                        if (dsGetHPDefault.Tables[0].Rows[0][0].ToString() != "")
                        {
                            decimal decOneDefault = Convert.ToDecimal(dsGetHPDefault.Tables[0].Rows[0][0].ToString());
                            decHPDefault = decHPDefault + decOneDefault;
                        }

                        //Get Collected Amount
                        DataSet dsGetHPCollAmount = objDBTask.selectData("select sum(capital),sum(interest),sum(c_default),sum(debit) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'WI';");
                        if (dsGetHPCollAmount.Tables[0].Rows[0][0].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][1].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][2].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][3].ToString() != "")
                        {
                            decimal decOneCapital = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][0].ToString());
                            decimal decOneInterest = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][1].ToString());
                            decimal decOneDefa = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][2].ToString());
                            decimal decOneDebit = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][3].ToString());
                            decCollCapital = decCollCapital + decOneCapital + decOneDebit;
                            decCollInterest = decCollInterest + decOneInterest;
                            decCollDefa = decCollDefa + decOneDefa;
                        }
                    }
                    lblDueMDefault.Text = decHPDefault.ToString("#,##0.00");

                    lblCollMCapital.Text = decCollCapital.ToString("#,##0.00");
                    lblCollMInterest.Text = decCollInterest.ToString("#,##0.00");
                    lblCollMDefault.Text = decCollDefa.ToString("#,##0.00");
                }

                decimal decGrantedLoAmount = decActiveLoAmount + decSettleLoAmount + decMaturityLoAmount;
                lblGLoanAmount.Text = decGrantedLoAmount.ToString("#,##0.00");

                decimal decExpecInterAmount = decActiveInterAmount + decSettleInterAmount + decMatuInterAmount;
                lblEInterestIncome.Text = decExpecInterAmount.ToString("#,##0.00");

                decimal decTotalLoanAmount = decGrantedLoAmount + decExpecInterAmount;
                lblVTotal.Text = decTotalLoanAmount.ToString("#,##0.00");

                decimal decNoTotalClient = decNoActiveClient + decNoMaturityClient + decNoSettleClient;
                lblTotal.Text = decNoTotalClient.ToString();

                decimal decDueAcToCapitalInte = 0;
                //Get Active Due Details
                DataSet dsGetDueRental = objDBTask.selectData("select l.contra_code,l.period,l.chequ_deta_on,l.monthly_instollment,l.interest_amount from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P';");
                if (dsGetDueRental.Tables[0].Rows.Count > 0)
                {
                    decimal decToCapital = 0;
                    decimal decToInterest = 0;
                    decimal decHPDefault = 0;
                    decimal decCollCapital = 0;
                    decimal decCollInterest = 0;
                    decimal decCollDefa = 0;
                    for (int i = 0; i < dsGetDueRental.Tables[0].Rows.Count; i++)
                    {
                        string strCC = dsGetDueRental.Tables[0].Rows[i]["contra_code"].ToString();
                        string strPeriod = dsGetDueRental.Tables[0].Rows[i]["period"].ToString();
                        string strCDate = dsGetDueRental.Tables[0].Rows[i]["chequ_deta_on"].ToString();
                        string strMI = dsGetDueRental.Tables[0].Rows[i]["monthly_instollment"].ToString();
                        string strIAmount = dsGetDueRental.Tables[0].Rows[i]["interest_amount"].ToString();

                        int intPeriod = Convert.ToInt32(strPeriod);
                        decimal decPeriod = Convert.ToDecimal(strPeriod);
                        decimal decMI = Convert.ToDecimal(strMI);
                        decimal decIA = Convert.ToDecimal(strIAmount);

                        decimal decOneMonthIterest = decimal.Round(decIA / decPeriod, 2, MidpointRounding.AwayFromZero);
                        decimal decOneMonthCapital = decimal.Round(decMI - decOneMonthIterest, 2, MidpointRounding.AwayFromZero);

                        int intX = 0;

                        DateTime dtCDate = Convert.ToDateTime(strCDate);
                        DateTime dtCloseDate = dtCDate.AddMonths(intPeriod);
                        TimeSpan tsFullDays = dtCloseDate.Subtract(dtCDate);
                        int intFullDays = tsFullDays.Days;
                        decimal decFullDays = Convert.ToDecimal(intFullDays);
                        DateTime dtNow = DateTime.Now;
                        TimeSpan tsCurrDays = dtNow.Subtract(dtCDate);
                        int intCurrDays = tsCurrDays.Days;

                        intX = intCurrDays / 7;

                        decimal decX = Convert.ToDecimal(intX);

                        decimal decOneCliTotalInterest = 0;
                        decimal decOneCliTotalCapital = 0;

                        if (decX <= decPeriod)
                        {
                            decOneCliTotalInterest = decimal.Round(decX * decOneMonthIterest, 2, MidpointRounding.AwayFromZero);
                            decOneCliTotalCapital = decimal.Round(decX * decOneMonthCapital, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            decOneCliTotalInterest = decimal.Round(decPeriod * decOneMonthIterest, 2, MidpointRounding.AwayFromZero);
                            decOneCliTotalCapital = decimal.Round(decPeriod * decOneMonthCapital, 2, MidpointRounding.AwayFromZero);
                        }


                        decToCapital = decToCapital + decOneCliTotalCapital;
                        decToInterest = decToInterest + decOneCliTotalInterest;

                        //Get Default Amount
                        DataSet dsGetHPDefault = objDBTask.selectData("select sum(c_default) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'D';");
                        if (dsGetHPDefault.Tables[0].Rows[0][0].ToString() != "")
                        {
                            decimal decOneDefault = Convert.ToDecimal(dsGetHPDefault.Tables[0].Rows[0][0].ToString());
                            decHPDefault = decHPDefault + decOneDefault;
                        }

                        //Get Collected Amount
                        DataSet dsGetHPCollAmount = objDBTask.selectData("select sum(capital),sum(interest),sum(c_default),sum(debit) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'WI';");
                        if (dsGetHPCollAmount.Tables[0].Rows[0][0].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][1].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][2].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][3].ToString() != "")
                        {
                            decimal decOneCapital = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][0].ToString());
                            decimal decOneInterest = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][1].ToString());
                            decimal decOneDefa = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][2].ToString());
                            decimal decOneDebit = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][3].ToString());
                            decCollCapital = decCollCapital + decOneCapital + decOneDebit;
                            decCollInterest = decCollInterest + decOneInterest;
                            decCollDefa = decCollDefa + decOneDefa;

                        }
                    }
                    lblDueADefault.Text = decHPDefault.ToString("#,##0.00");
                    lblDueACapital.Text = decToCapital.ToString("#,##0.00");
                    lblDueAInterest.Text = decToInterest.ToString("#,##0.00");

                    lblCollACapital.Text = decCollCapital.ToString("#,##0.00");
                    lblCollAInterest.Text = decCollInterest.ToString("#,##0.00");
                    lblCollADefault.Text = decCollDefa.ToString("#,##0.00");

                    decDueAcToCapitalInte = decToCapital + decToInterest;
                }


                //Get Settle Due Details
                DataSet dsGetDueSettleRental = objDBTask.selectData("select l.contra_code,l.period,l.chequ_deta_on,l.monthly_instollment,l.interest_amount from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'S';");
                if (dsGetDueSettleRental.Tables[0].Rows.Count > 0)
                {
                    decimal decToCapital = 0;
                    decimal decToInterest = 0;
                    decimal decHPDefault = 0;
                    decimal decCollCapital = 0;
                    decimal decDebit = 0;
                    decimal decCollInterest = 0;
                    decimal decCollDefa = 0;
                    for (int i = 0; i < dsGetDueSettleRental.Tables[0].Rows.Count; i++)
                    {
                        string strCC = dsGetDueSettleRental.Tables[0].Rows[i]["contra_code"].ToString();

                        //Get Default Amount
                        DataSet dsGetHPDefault = objDBTask.selectData("select sum(c_default) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'D';");
                        if (dsGetHPDefault.Tables[0].Rows[0][0].ToString() != "")
                        {
                            decimal decOneDefault = Convert.ToDecimal(dsGetHPDefault.Tables[0].Rows[0][0].ToString());
                            decHPDefault = decHPDefault + decOneDefault;
                        }

                        //Get Collected Amount
                        DataSet dsGetHPCollAmount = objDBTask.selectData("select sum(capital),sum(interest),sum(c_default),sum(debit) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'WI';");
                        if (dsGetHPCollAmount.Tables[0].Rows[0][0].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][1].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][2].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][3].ToString() != "")
                        {
                            decimal decOneCapital = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][0].ToString());
                            decimal decOneInterest = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][1].ToString());
                            decimal decOneDefa = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][2].ToString());
                            decimal decOneDebit = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][3].ToString());
                            decCollCapital = decCollCapital + decOneCapital + decOneDebit;
                            decCollInterest = decCollInterest + decOneInterest;
                            decCollDefa = decCollDefa + decOneDefa;
                            decDebit = decDebit + decOneDebit;
                        }
                    }

                    lblDueSDefault.Text = decHPDefault.ToString("#,##0.00");


                    lblCollSCapital.Text = decCollCapital.ToString("#,##0.00");
                    lblCollSInterest.Text = decCollInterest.ToString("#,##0.00");
                    lblCollSDefault.Text = decCollDefa.ToString("#,##0.00");
                }

                decimal decDueSeDefault = Convert.ToDecimal(lblDueSDefault.Text);
                decimal decDueSeCapital = Convert.ToDecimal(lblDueSCapital.Text);
                decimal decDueSeInterest = Convert.ToDecimal(lblDueSInterest.Text);

                decimal decDueAcDefault = Convert.ToDecimal(lblDueADefault.Text);
                decimal decDueAcCapital = Convert.ToDecimal(lblDueACapital.Text);
                decimal decDueAcInterest = Convert.ToDecimal(lblDueAInterest.Text);

                decimal decDueMeDefault = Convert.ToDecimal(lblDueMDefault.Text);
                decimal decDueMeCapital = Convert.ToDecimal(lblDueMCapital.Text);
                decimal decDueMeInterest = Convert.ToDecimal(lblDueMInterest.Text);

                decimal decToDueCapital = decDueSeCapital + decDueAcCapital + decDueMeCapital;
                decimal decToDueInterest = decDueSeInterest + decDueAcInterest + decDueMeInterest;
                decimal decTODueDefault = decDueSeDefault + decDueAcDefault + decDueMeDefault;

                lblDueTCapital.Text = decToDueCapital.ToString("#,##0.00");
                lblDueTDefault.Text = decTODueDefault.ToString("#,##0.00");
                lblDueTInterest.Text = decToDueInterest.ToString("#,##0.00");

                //Get Collectd Detail
                decimal decCollSeDefault = Convert.ToDecimal(lblCollSDefault.Text);
                decimal decCollSeCapital = Convert.ToDecimal(lblCollSCapital.Text);
                decimal decCollSeInterest = Convert.ToDecimal(lblCollSInterest.Text);


                decimal decCollAcDefault = Convert.ToDecimal(lblCollADefault.Text);
                decimal decCollAcCapital = Convert.ToDecimal(lblCollACapital.Text);
                decimal decCollAcInterest = Convert.ToDecimal(lblCollAInterest.Text);

                decimal decActCollCapInter = decCollAcCapital + decCollAcInterest;

                decimal decCollMeDefault = Convert.ToDecimal(lblCollMDefault.Text);
                decimal decCollMeCapital = Convert.ToDecimal(lblCollMCapital.Text);
                decimal decCollMeInterest = Convert.ToDecimal(lblCollMInterest.Text);

                decimal decMatCollCapInter = decCollMeCapital + decCollMeInterest;

                decimal decToCollCapital = decCollSeCapital + decCollAcCapital + decCollMeCapital;
                decimal decToCollInterest = decCollSeInterest + decCollAcInterest + decCollMeInterest;
                decimal decTOCollDefault = decCollSeDefault + decCollAcDefault + decCollMeDefault;

                lblCollTCapital.Text = decToCollCapital.ToString("#,##0.00");
                lblCollTDefault.Text = decTOCollDefault.ToString("#,##0.00");
                lblCollTInterest.Text = decToCollInterest.ToString("#,##0.00");

                //Get Recovery Ration
                decimal decRRatio = decimal.Round(((decActCollCapInter + decMatCollCapInter) / (decDueAcToCapitalInte + decDueMaToCapInter)) * 100, 2, MidpointRounding.AwayFromZero);
                lblRecoveryRatio.Text = decRRatio.ToString();

                //Service Charges
                decimal decSerCharges = 0;
                decimal decOtherCharges = 0;
                decimal decToCharges = 0;
                DataSet dsGetServiceCharges = objDBTask.selectData("select sum(service_charges),sum(other_charges) from micro_loan_details where loan_approved = 'Y' and chequ_no != '' and loan_sta != 'C';");
                if (dsGetServiceCharges.Tables[0].Rows.Count > 0)
                {
                    string strSerCharges = dsGetServiceCharges.Tables[0].Rows[0][0].ToString();
                    string strOtherCha = dsGetServiceCharges.Tables[0].Rows[0][1].ToString();
                    decSerCharges = Convert.ToDecimal(strSerCharges);
                    decOtherCharges = Convert.ToDecimal(strOtherCha);
                    decToCharges = decSerCharges + decOtherCharges;
                }
                lblDocumentCharges.Text = decToCharges.ToString("#,##0.00");
            }
            else if (txtDateFrom.Text.Trim() != "")
            {
                string strFrom = "2013-12-01";
                string strTo = txtDateFrom.Text.Trim();

                decimal decNoActiveClient = 0;
                decimal decActiveLoAmount = 0;
                decimal decActiveInterAmount = 0;
                DataSet dsGetNoActiveClient = objDBTask.selectData("select count(l.contra_code),sum(l.loan_amount),sum(l.interest_amount) from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P' and l.chequ_deta_on <= '" + strTo + "' and l.maturity_date >= '" + strTo + "';");
                if (dsGetNoActiveClient.Tables[0].Rows[0][0].ToString() != "0")
                {
                    string strNoActiveClient = dsGetNoActiveClient.Tables[0].Rows[0][0].ToString();
                    string strActiveLoAmount = dsGetNoActiveClient.Tables[0].Rows[0][1].ToString();
                    string strActiveInterAmount = dsGetNoActiveClient.Tables[0].Rows[0][2].ToString();
                    decNoActiveClient = Convert.ToDecimal(strNoActiveClient);
                    decActiveLoAmount = Convert.ToDecimal(strActiveLoAmount);
                    decActiveInterAmount = Convert.ToDecimal(strActiveInterAmount);
                    lblActive.Text = strNoActiveClient;
                }
                else
                {
                    lblActive.Text = "0";
                }


                decimal decSettleLoAmount = 0;
                decimal decNoSettleClient = 0;
                decimal decSettleInterAmount = 0;
                DataSet dsGetNoSettleClient = objDBTask.selectData("select count(l.contra_code),sum(l.loan_amount),sum(l.interest_amount) from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'S' and l.chequ_deta_on <= '" + strTo + "' and l.maturity_date >= '" + strTo + "';");
                if (dsGetNoSettleClient.Tables[0].Rows[0][0].ToString() != "0")
                {
                    string strNoSettleClient = dsGetNoSettleClient.Tables[0].Rows[0][0].ToString();
                    string strSettleLoAmount = dsGetNoSettleClient.Tables[0].Rows[0][1].ToString();
                    string strSettleInterAmount = dsGetNoSettleClient.Tables[0].Rows[0][2].ToString();
                    decSettleLoAmount = Convert.ToDecimal(strSettleLoAmount);
                    decNoSettleClient = Convert.ToDecimal(strNoSettleClient);
                    decSettleInterAmount = Convert.ToDecimal(strSettleInterAmount);
                    lblSettle.Text = strNoSettleClient;

                    lblDueSCapital.Text = decSettleLoAmount.ToString("#,##0.00");
                    lblDueSInterest.Text = decSettleInterAmount.ToString("#,##0.00");
                }
                else
                {
                    lblSettle.Text = "0";
                    lblDueSCapital.Text = "0.00";
                    lblDueSInterest.Text = "0.00";
                }



                decimal decMaturityLoAmount = 0;
                decimal decNoMaturityClient = 0;
                decimal decMatuInterAmount = 0;
                DataSet dsGetNoMaturityClient = objDBTask.selectData("select count(l.contra_code),sum(l.loan_amount),sum(l.interest_amount) from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'D' and l.maturity_date <= '" + strTo + "';");
                if (dsGetNoMaturityClient.Tables[0].Rows[0][0].ToString() != "0")
                {
                    string strNoMaturityClient = dsGetNoMaturityClient.Tables[0].Rows[0][0].ToString();
                    string strMaturityLoAmount = dsGetNoMaturityClient.Tables[0].Rows[0][1].ToString();
                    string strMatuInterAmount = dsGetNoMaturityClient.Tables[0].Rows[0][2].ToString();
                    decMaturityLoAmount = Convert.ToDecimal(strMaturityLoAmount);
                    decNoMaturityClient = Convert.ToDecimal(strNoMaturityClient);
                    decMatuInterAmount = Convert.ToDecimal(strMatuInterAmount);
                    lblMatu.Text = strNoMaturityClient;
                }
                else
                {
                    lblMatu.Text = "0";
                }


                //Get Maturity Due Details
                lblDueMCapital.Text = decMaturityLoAmount.ToString("#,##0.00");
                lblDueMInterest.Text = decMatuInterAmount.ToString("#,##0.00");

                decimal decDueMaToCapInter = decMaturityLoAmount + decMatuInterAmount;

                DataSet dsGetMatDefault = objDBTask.selectData("select l.contra_code from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'D' and l.maturity_date <= '" + strTo + "';");
                if (dsGetMatDefault.Tables[0].Rows.Count > 0)
                {
                    decimal decHPDefault = 0;
                    decimal decCollCapital = 0;
                    decimal decCollInterest = 0;
                    decimal decCollDefa = 0;
                    for (int i = 0; i < dsGetMatDefault.Tables[0].Rows.Count; i++)
                    {
                        string strCC = dsGetMatDefault.Tables[0].Rows[i]["contra_code"].ToString();

                        //Get Default Amount
                        DataSet dsGetHPDefault = objDBTask.selectData("select sum(c_default) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'D' and date_time between '" + strFrom + "' and '" + strTo + "';");
                        if (dsGetHPDefault.Tables[0].Rows[0][0].ToString() != "")
                        {
                            decimal decOneDefault = Convert.ToDecimal(dsGetHPDefault.Tables[0].Rows[0][0].ToString());
                            decHPDefault = decHPDefault + decOneDefault;
                        }

                        //Get Collected Amount
                        DataSet dsGetHPCollAmount = objDBTask.selectData("select sum(capital),sum(interest),sum(c_default),sum(debit) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'WI' and date_time between '" + strFrom + "' and '" + strTo + "';");
                        if (dsGetHPCollAmount.Tables[0].Rows[0][0].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][1].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][2].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][3].ToString() != "")
                        {
                            decimal decOneCapital = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][0].ToString());
                            decimal decOneInterest = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][1].ToString());
                            decimal decOneDefa = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][2].ToString());
                            decimal decOneDebit = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][3].ToString());
                            decCollCapital = decCollCapital + decOneCapital + decOneDebit;
                            decCollInterest = decCollInterest + decOneInterest;
                            decCollDefa = decCollDefa + decOneDefa;
                        }
                    }
                    lblDueMDefault.Text = decHPDefault.ToString("#,##0.00");

                    lblCollMCapital.Text = decCollCapital.ToString("#,##0.00");
                    lblCollMInterest.Text = decCollInterest.ToString("#,##0.00");
                    lblCollMDefault.Text = decCollDefa.ToString("#,##0.00");
                }

                decimal decGrantedLoAmount = decActiveLoAmount + decSettleLoAmount + decMaturityLoAmount;
                lblGLoanAmount.Text = decGrantedLoAmount.ToString("#,##0.00");

                decimal decExpecInterAmount = decActiveInterAmount + decSettleInterAmount + decMatuInterAmount;
                lblEInterestIncome.Text = decExpecInterAmount.ToString("#,##0.00");

                decimal decTotalLoanAmount = decGrantedLoAmount + decExpecInterAmount;
                lblVTotal.Text = decTotalLoanAmount.ToString("#,##0.00");

                decimal decNoTotalClient = decNoActiveClient + decNoMaturityClient + decNoSettleClient;
                lblTotal.Text = decNoTotalClient.ToString();

                decimal decDueAcToCapitalInte = 0;
                //Get Active Due Details
                DataSet dsGetDueRental = objDBTask.selectData("select l.contra_code,l.period,l.chequ_deta_on,l.monthly_instollment,l.interest_amount from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P' and l.chequ_deta_on <= '" + strTo + "' and l.maturity_date >= '" + strTo + "';");
                if (dsGetDueRental.Tables[0].Rows.Count > 0)
                {
                    decimal decToCapital = 0;
                    decimal decToInterest = 0;
                    decimal decHPDefault = 0;
                    decimal decCollCapital = 0;
                    decimal decCollInterest = 0;
                    decimal decCollDefa = 0;
                    for (int i = 0; i < dsGetDueRental.Tables[0].Rows.Count; i++)
                    {
                        string strCC = dsGetDueRental.Tables[0].Rows[i]["contra_code"].ToString();
                        string strPeriod = dsGetDueRental.Tables[0].Rows[i]["period"].ToString();
                        string strCDate = dsGetDueRental.Tables[0].Rows[i]["chequ_deta_on"].ToString();
                        string strMI = dsGetDueRental.Tables[0].Rows[i]["monthly_instollment"].ToString();
                        string strIAmount = dsGetDueRental.Tables[0].Rows[i]["interest_amount"].ToString();

                        int intPeriod = Convert.ToInt32(strPeriod);
                        decimal decPeriod = Convert.ToDecimal(strPeriod);
                        decimal decMI = Convert.ToDecimal(strMI);
                        decimal decIA = Convert.ToDecimal(strIAmount);

                        decimal decOneMonthIterest = decimal.Round(decIA / decPeriod, 2, MidpointRounding.AwayFromZero);
                        decimal decOneMonthCapital = decimal.Round(decMI - decOneMonthIterest, 2, MidpointRounding.AwayFromZero);

                        int intX = 0;

                        DateTime dtCDate = Convert.ToDateTime(strCDate);
                        //DateTime dtCloseDate = dtCDate.AddMonths(intPeriod);
                        //TimeSpan tsFullDays = dtCloseDate.Subtract(dtCDate);
                        //int intFullDays = tsFullDays.Days;
                        //decimal decFullDays = Convert.ToDecimal(intFullDays);
                        DateTime dtNow = Convert.ToDateTime(strTo);
                        TimeSpan tsCurrDays = dtNow.Subtract(dtCDate);
                        int intCurrDays = tsCurrDays.Days;

                        intX = intCurrDays / 7;

                        decimal decX = Convert.ToDecimal(intX);

                        decimal decOneCliTotalInterest = 0;
                        decimal decOneCliTotalCapital = 0;

                        if (decX <= decPeriod)
                        {
                            decOneCliTotalInterest = decimal.Round(decX * decOneMonthIterest, 2, MidpointRounding.AwayFromZero);
                            decOneCliTotalCapital = decimal.Round(decX * decOneMonthCapital, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            decOneCliTotalInterest = decimal.Round(decPeriod * decOneMonthIterest, 2, MidpointRounding.AwayFromZero);
                            decOneCliTotalCapital = decimal.Round(decPeriod * decOneMonthCapital, 2, MidpointRounding.AwayFromZero);
                        }


                        decToCapital = decToCapital + decOneCliTotalCapital;
                        decToInterest = decToInterest + decOneCliTotalInterest;

                        //Get Default Amount
                        DataSet dsGetHPDefault = objDBTask.selectData("select sum(c_default) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'D' and date_time between '" + strFrom + "' and '" + strTo + "';");
                        if (dsGetHPDefault.Tables[0].Rows[0][0].ToString() != "")
                        {
                            decimal decOneDefault = Convert.ToDecimal(dsGetHPDefault.Tables[0].Rows[0][0].ToString());
                            decHPDefault = decHPDefault + decOneDefault;
                        }

                        //Get Collected Amount
                        DataSet dsGetHPCollAmount = objDBTask.selectData("select sum(capital),sum(interest),sum(c_default),sum(debit) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'WI' and date_time between '" + strFrom + "' and '" + strTo + "';");
                        if (dsGetHPCollAmount.Tables[0].Rows[0][0].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][1].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][2].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][3].ToString() != "")
                        {
                            decimal decOneCapital = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][0].ToString());
                            decimal decOneInterest = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][1].ToString());
                            decimal decOneDefa = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][2].ToString());
                            decimal decOneDebit = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][3].ToString());
                            decCollCapital = decCollCapital + decOneCapital + decOneDebit;
                            decCollInterest = decCollInterest + decOneInterest;
                            decCollDefa = decCollDefa + decOneDefa;

                        }
                    }
                    lblDueADefault.Text = decHPDefault.ToString("#,##0.00");
                    lblDueACapital.Text = decToCapital.ToString("#,##0.00");
                    lblDueAInterest.Text = decToInterest.ToString("#,##0.00");

                    lblCollACapital.Text = decCollCapital.ToString("#,##0.00");
                    lblCollAInterest.Text = decCollInterest.ToString("#,##0.00");
                    lblCollADefault.Text = decCollDefa.ToString("#,##0.00");

                    decDueAcToCapitalInte = decToCapital + decToInterest;
                }


                //Get Settle Due Details
                DataSet dsGetDueSettleRental = objDBTask.selectData("select l.contra_code,l.period,l.chequ_deta_on,l.monthly_instollment,l.interest_amount from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'S' and l.chequ_deta_on <= '" + strTo + "' and l.maturity_date >= '" + strTo + "';");
                if (dsGetDueSettleRental.Tables[0].Rows.Count > 0)
                {
                    decimal decToCapital = 0;
                    decimal decToInterest = 0;
                    decimal decHPDefault = 0;
                    decimal decCollCapital = 0;
                    decimal decDebit = 0;
                    decimal decCollInterest = 0;
                    decimal decCollDefa = 0;
                    for (int i = 0; i < dsGetDueSettleRental.Tables[0].Rows.Count; i++)
                    {
                        string strCC = dsGetDueSettleRental.Tables[0].Rows[i]["contra_code"].ToString();

                        //Get Default Amount
                        DataSet dsGetHPDefault = objDBTask.selectData("select sum(c_default) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'D';");
                        if (dsGetHPDefault.Tables[0].Rows[0][0].ToString() != "")
                        {
                            decimal decOneDefault = Convert.ToDecimal(dsGetHPDefault.Tables[0].Rows[0][0].ToString());
                            decHPDefault = decHPDefault + decOneDefault;
                        }

                        //Get Collected Amount
                        DataSet dsGetHPCollAmount = objDBTask.selectData("select sum(capital),sum(interest),sum(c_default),sum(debit) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'WI';");
                        if (dsGetHPCollAmount.Tables[0].Rows[0][0].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][1].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][2].ToString() != "" || dsGetHPCollAmount.Tables[0].Rows[0][3].ToString() != "")
                        {
                            decimal decOneCapital = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][0].ToString());
                            decimal decOneInterest = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][1].ToString());
                            decimal decOneDefa = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][2].ToString());
                            decimal decOneDebit = Convert.ToDecimal(dsGetHPCollAmount.Tables[0].Rows[0][3].ToString());
                            decCollCapital = decCollCapital + decOneCapital + decOneDebit;
                            decCollInterest = decCollInterest + decOneInterest;
                            decCollDefa = decCollDefa + decOneDefa;
                            decDebit = decDebit + decOneDebit;
                        }
                    }

                    lblDueSDefault.Text = decHPDefault.ToString("#,##0.00");


                    lblCollSCapital.Text = decCollCapital.ToString("#,##0.00");
                    lblCollSInterest.Text = decCollInterest.ToString("#,##0.00");
                    lblCollSDefault.Text = decCollDefa.ToString("#,##0.00");
                }

                decimal decDueSeDefault = Convert.ToDecimal(lblDueSDefault.Text);
                decimal decDueSeCapital = Convert.ToDecimal(lblDueSCapital.Text);
                decimal decDueSeInterest = Convert.ToDecimal(lblDueSInterest.Text);

                decimal decDueAcDefault = Convert.ToDecimal(lblDueADefault.Text);
                decimal decDueAcCapital = Convert.ToDecimal(lblDueACapital.Text);
                decimal decDueAcInterest = Convert.ToDecimal(lblDueAInterest.Text);

                decimal decDueMeDefault = Convert.ToDecimal(lblDueMDefault.Text);
                decimal decDueMeCapital = Convert.ToDecimal(lblDueMCapital.Text);
                decimal decDueMeInterest = Convert.ToDecimal(lblDueMInterest.Text);

                decimal decToDueCapital = decDueSeCapital + decDueAcCapital + decDueMeCapital;
                decimal decToDueInterest = decDueSeInterest + decDueAcInterest + decDueMeInterest;
                decimal decTODueDefault = decDueSeDefault + decDueAcDefault + decDueMeDefault;

                lblDueTCapital.Text = decToDueCapital.ToString("#,##0.00");
                lblDueTDefault.Text = decTODueDefault.ToString("#,##0.00");
                lblDueTInterest.Text = decToDueInterest.ToString("#,##0.00");

                //Get Collectd Detail
                decimal decCollSeDefault = Convert.ToDecimal(lblCollSDefault.Text);
                decimal decCollSeCapital = Convert.ToDecimal(lblCollSCapital.Text);
                decimal decCollSeInterest = Convert.ToDecimal(lblCollSInterest.Text);


                decimal decCollAcDefault = Convert.ToDecimal(lblCollADefault.Text);
                decimal decCollAcCapital = Convert.ToDecimal(lblCollACapital.Text);
                decimal decCollAcInterest = Convert.ToDecimal(lblCollAInterest.Text);

                decimal decActCollCapInter = decCollAcCapital + decCollAcInterest;

                decimal decCollMeDefault = Convert.ToDecimal(lblCollMDefault.Text);
                decimal decCollMeCapital = Convert.ToDecimal(lblCollMCapital.Text);
                decimal decCollMeInterest = Convert.ToDecimal(lblCollMInterest.Text);

                decimal decMatCollCapInter = decCollMeCapital + decCollMeInterest;

                decimal decToCollCapital = decCollSeCapital + decCollAcCapital + decCollMeCapital;
                decimal decToCollInterest = decCollSeInterest + decCollAcInterest + decCollMeInterest;
                decimal decTOCollDefault = decCollSeDefault + decCollAcDefault + decCollMeDefault;

                lblCollTCapital.Text = decToCollCapital.ToString("#,##0.00");
                lblCollTDefault.Text = decTOCollDefault.ToString("#,##0.00");
                lblCollTInterest.Text = decToCollInterest.ToString("#,##0.00");

                //Get Recovery Ration
                decimal decRRatio = decimal.Round(((decActCollCapInter + decMatCollCapInter) / (decDueAcToCapitalInte + decDueMaToCapInter)) * 100, 2, MidpointRounding.AwayFromZero);
                lblRecoveryRatio.Text = decRRatio.ToString();

                //Service Charges
                decimal decSerCharges = 0;
                decimal decOtherCharges = 0;
                decimal decToCharges = 0;
                DataSet dsGetServiceCharges = objDBTask.selectData("select sum(service_charges),sum(other_charges) from micro_loan_details where loan_approved = 'Y' and chequ_no != '' and loan_sta != 'C' and chequ_deta_on between '" + strFrom + "' and '" + strTo + "';");
                if (dsGetServiceCharges.Tables[0].Rows.Count > 0)
                {
                    string strSerCharges = dsGetServiceCharges.Tables[0].Rows[0][0].ToString();
                    string strOtherCha = dsGetServiceCharges.Tables[0].Rows[0][1].ToString();
                    decSerCharges = Convert.ToDecimal(strSerCharges);
                    decOtherCharges = Convert.ToDecimal(strOtherCha);
                    decToCharges = decSerCharges + decOtherCharges;
                }
                lblDocumentCharges.Text = decToCharges.ToString("#,##0.00");
            }
        }

        protected void clear()
        {
            lblActive.Text = "0";
            lblCollACapital.Text = "0.00";
            lblCollADefault.Text = "0.00";
            lblCollAInterest.Text = "0.00";
            lblCollSCapital.Text = "0.00";
            lblCollSDefault.Text = "0.00";
            lblMatu.Text = "0";
            lblCollSInterest.Text = "0.00";
            lblCollTCapital.Text = "0.00";
            lblCollTDefault.Text = "0.00";
            lblCollTInterest.Text = "0.00";
            lblDocumentCharges.Text = "0.00";
            lblDueACapital.Text = "0.00";
            lblDueADefault.Text = "0.00";
            lblDueAInterest.Text = "0.00";
            lblDueSCapital.Text = "0.00";
            lblDueSDefault.Text = "0.00";
            lblDueSInterest.Text = "0.00";
            lblDueTCapital.Text = "0.00";
            lblDueTDefault.Text = "0.00";
            lblDueTInterest.Text = "0.00";
            lblEInterestIncome.Text = "0.00";
            lblGLoanAmount.Text = "0.00";
            lblIncomeGrowth.Text = "0.00";
            lblNonPerfoPort.Text = "0.00";
            lblOtherDefaultColl.Text = "0.00";
            lblPortGrowth.Text = "0.00";
            lblRecoveryRatio.Text = "0";
            lblSettle.Text = "0";
            lblTotal.Text = "0";
            lblVTotal.Text = "0.00";
            lblDueMCapital.Text = "0.00";
            lblDueMDefault.Text = "0.00";
            lblDueMInterest.Text = "0.00";
            lblCollMCapital.Text = "0.00";
            lblCollMDefault.Text = "0.00";
            lblCollMInterest.Text = "0.00";
        }
    }
}
