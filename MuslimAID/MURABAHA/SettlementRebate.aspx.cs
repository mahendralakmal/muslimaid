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

namespace MuslimAID.MURABAHA
{
    public partial class SettlementRebate : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (Session["UserType"] != "Cash Collector" || Session["UserType"] != "Cash Recovery Officer" || Session["UserType"] != "Special Recovery Officer" || Session["UserType"] != "Cashier")
                {
                    if (!this.IsPostBack)
                    {

                    }
                }
                else { Response.Redirect("murabha.aspx"); }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        private void Clear()
        {
            txtNewIRate.Text = "";
            lblName.Text = "";
            lblNIC.Text = "";
            lblArre.Text = "";
            lblFullBala.Text = "";
            lblIAmount.Text = "";
            lblIRate.Text = "";
            lblMsg.Text = "";
            lblNewBala.Text = "";
            lblPeriod.Text = "";
            lblDeAmont.Text = "";
            lblCapiAmou.Text = "";
            lblIntBalance.Text = "";
            lblLAmount.Text = "";
            lblLoDate.Text = "";
            lblMIns.Text = "";
            lblName.Text = "";
            lblPaInAmou.Text = "";
            lblPaPeriod.Text = "";
        }

        private void IsExistContract()
        {
            try
            {
                Clear();
                if (txtCC.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter contract code.";
                    btnRequest.Enabled = false;
                }
                else
                {
                    string strCC = txtCC.Text.Trim();

                    DataSet dsGetDeta = cls_Connection.getDataSet("select c.nic,l.loan_amount,l.current_loan_amount,l.interest_rate,l.interest_amount,l.period,l.monthly_instollment,l.chequ_deta_on,l.arres_amou,c.initial_name last_name,loan_sta from micro_loan_details l, micro_basic_detail c where l.contra_code = c.contract_code and l.contra_code = '" + strCC + "' and l.loan_approved = 'Y' and l.chequ_no != '' ;");
                    
                    if (dsGetDeta.Tables[0].Rows.Count != 0)
                    {
                        string loan_sta = dsGetDeta.Tables[0].Rows[0]["loan_sta"].ToString();
                        if (loan_sta == "C")
                        {
                            Clear();
                            lblMsg.Text = "Canceled Loan";
                            btnRequest.Enabled = false;
                        }
                        else if (loan_sta == "S")
                        {
                            Clear();
                            lblMsg.Text = "Settled Loan";
                            btnRequest.Enabled = false;
                        }
                        else
                        {
                            lblNIC.Text = dsGetDeta.Tables[0].Rows[0]["nic"].ToString();
                            lblLAmount.Text = dsGetDeta.Tables[0].Rows[0]["loan_amount"].ToString();
                            lblArre.Text = dsGetDeta.Tables[0].Rows[0]["arres_amou"].ToString();
                            lblFullBala.Text = dsGetDeta.Tables[0].Rows[0]["current_loan_amount"].ToString();
                            string strIAmount = dsGetDeta.Tables[0].Rows[0]["interest_amount"].ToString();
                            lblIAmount.Text = strIAmount;
                            lblIRate.Text = dsGetDeta.Tables[0].Rows[0]["interest_rate"].ToString();
                            lblPeriod.Text = dsGetDeta.Tables[0].Rows[0]["period"].ToString();
                            lblMIns.Text = dsGetDeta.Tables[0].Rows[0]["monthly_instollment"].ToString();
                            string strLDate = dsGetDeta.Tables[0].Rows[0]["chequ_deta_on"].ToString();
                            lblLoDate.Text = strLDate;
                            lblName.Text = dsGetDeta.Tables[0].Rows[0]["last_name"].ToString();
                            decimal decToInte = Convert.ToDecimal(strIAmount);

                            DateTime dtLoanDate = Convert.ToDateTime(strLDate);
                            string strNowDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            DateTime dtNow = Convert.ToDateTime(strNowDate);

                            TimeSpan tsPassPer = dtNow.Subtract(dtLoanDate);
                            string strPassPer = tsPassPer.Days.ToString();
                            int intPassPer = Convert.ToInt32(strPassPer) / 30;
                            string strPassPeriod = Convert.ToString(intPassPer);

                            lblPaPeriod.Text = strPassPeriod + " Weeks";

                            DataSet dsGetPayHis = cls_Connection.getDataSet("select ifnull(sum(interest),0) from micro_payme_summery where contra_code = '" + strCC + "' and p_type = 'DB';");
                            decimal FutureInterest = 0;
                            if (dsGetPayHis.Tables[0].Rows[0][0].ToString() != "")
                            {
                                string strPaidInte = dsGetPayHis.Tables[0].Rows[0][0].ToString();
                                FutureInterest = decToInte - Convert.ToDecimal(strPaidInte);
                                lblIntBalance.Text = FutureInterest.ToString();

                                decimal TotalCapital = 0, TotalInterest = 0;
                                string strQRY = "SELECT IFNULL(sum(paid_capital), 0) AS capital,IFNULL(sum(paid_interest), 0) AS interest FROM paid_cap_int WHERE contra_code = '" + strCC + "';";
                                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                                if (dsAllData.Tables[0].Rows.Count > 0)
                                {
                                    TotalCapital = Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["capital"]);
                                    lblCapiAmou.Text = TotalCapital.ToString();

                                    TotalInterest = Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["interest"]);
                                    lblPaInAmou.Text = TotalInterest.ToString();
                                }
                            }
                            else
                            {
                                lblCapiAmou.Text = "0.00";
                                lblPaInAmou.Text = "0.00";
                                lblIntBalance.Text = strIAmount;
                            }

                            btnRequest.Enabled = true;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Invalid contract code.";
                        btnRequest.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "Error Occured!.";
            }
        }

        private void RequestRebate()
        {
            try
            {
                lblMsg.Text = "";
                if (txtCC.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter contract code.";
                }
                else if (lblNIC.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter NIC.";
                }
                else if (lblArre.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Arrears.";
                }
                else if (lblFullBala.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Loan Balance.";
                }
                else if (lblIRate.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Interest Rate (%).";
                }
                else if (lblIAmount.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Interesr Amount.";
                }
                else if (lblPeriod.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Period.";
                }
                else if (txtNewIRate.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter New Interest Rate.";
                }
                else if (lblDeAmont.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Deduction Amount.";
                }
                else if (lblNewBala.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter New Balance.";
                }
                else
                {
                    string strCC, strNIC, strArre, strLoBala, strIRate, strIAmount, strPeriod, strNewIRate, strNewBala, strDeduAmou, strDate;
                    strCC = txtCC.Text.Trim();

                    DataSet dsLD = cls_Connection.getDataSet("select * from rebate where sta='P' and contra_code = '" + strCC + "';");

                    if (dsLD.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "Request is pending.";
                    }
                    else
                    {
                        strArre = lblArre.Text.Trim();
                        strNIC = lblNIC.Text.Trim();
                        strLoBala = lblFullBala.Text.Trim();
                        strIRate = lblIRate.Text.Trim();
                        strIAmount = lblIAmount.Text.Trim();
                        strPeriod = lblPeriod.Text.Trim();
                        strNewIRate = txtNewIRate.Text.Trim();
                        strNewBala = lblNewBala.Text.Trim();
                        strDeduAmou = lblDeAmont.Text.Trim();
                        strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string strloginID = Session["NIC"].ToString();
                        string strIp = Request.UserHostAddress;

                        MySqlCommand cmdInsertReb = new MySqlCommand("INSERT INTO rebate(contra_code,nic,arrears,curr_balance,in_rate,in_amount,prio,new_inte_rate,min_amount,sta,new_loan_bala,user_nic,date_time,user_ip)VALUES(@contra_code,@nic,@arrears,@curr_balance,@in_rate,@in_amount,@prio,@new_inte_rate,@min_amount,@sta,@new_loan_bala,@user_nic,@date_time,@user_ip);");

                        #region Assign Parameters
                        cmdInsertReb.Parameters.Add("@contra_code", MySqlDbType.VarChar, 10);
                        cmdInsertReb.Parameters.Add("@nic", MySqlDbType.VarChar, 10);
                        cmdInsertReb.Parameters.Add("@arrears", MySqlDbType.Decimal, 10);
                        cmdInsertReb.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 10);
                        cmdInsertReb.Parameters.Add("@in_rate", MySqlDbType.VarChar, 5);
                        cmdInsertReb.Parameters.Add("@in_amount", MySqlDbType.Decimal, 10);
                        cmdInsertReb.Parameters.Add("@prio", MySqlDbType.VarChar, 5);
                        cmdInsertReb.Parameters.Add("@new_inte_rate", MySqlDbType.VarChar, 5);
                        cmdInsertReb.Parameters.Add("@min_amount", MySqlDbType.Decimal, 10);
                        cmdInsertReb.Parameters.Add("@sta", MySqlDbType.VarChar, 1);
                        cmdInsertReb.Parameters.Add("@new_loan_bala", MySqlDbType.Decimal, 10);
                        cmdInsertReb.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
                        cmdInsertReb.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                        cmdInsertReb.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                        #endregion

                        #region DEclare Parametes
                        cmdInsertReb.Parameters["@contra_code"].Value = strCC;
                        cmdInsertReb.Parameters["@nic"].Value = strNIC;
                        cmdInsertReb.Parameters["@arrears"].Value = strArre;
                        cmdInsertReb.Parameters["@curr_balance"].Value = strLoBala;
                        cmdInsertReb.Parameters["@in_rate"].Value = strIRate;
                        cmdInsertReb.Parameters["@in_amount"].Value = strIAmount;
                        cmdInsertReb.Parameters["@prio"].Value = strPeriod;
                        cmdInsertReb.Parameters["@new_inte_rate"].Value = strNewIRate;
                        cmdInsertReb.Parameters["@min_amount"].Value = strDeduAmou;
                        cmdInsertReb.Parameters["@sta"].Value = "P";
                        cmdInsertReb.Parameters["@new_loan_bala"].Value = strNewBala;
                        cmdInsertReb.Parameters["@user_nic"].Value = strloginID;
                        cmdInsertReb.Parameters["@date_time"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        cmdInsertReb.Parameters["@user_ip"].Value = strIp;
                        #endregion

                        try
                        {
                            int f;
                            f = objDBTask.insertEditData(cmdInsertReb);
                            if (f == 1)
                            {
                                Clear();
                                txtCC.Text = "";
                                lblMsg.Text = "Request is Succsessfuled.";
                            }
                            else
                            {
                                lblMsg.Text = "Error Occured!";
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "Error Occured!";
            }
        }

        private void IRate()
        {
            try
            {
                lblMsg.Text = "";
                if (txtCC.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter contract code.";
                }
                else if (lblFullBala.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Loan Balance.";
                }
                else if (lblIRate.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Interest Rate (%).";
                }
                else if (lblIAmount.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Interesr Amount.";
                }
                else if (txtNewIRate.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter New Interest Rate.";
                }
                else
                {
                    string strLoBala, strIRate, strNewIRate, strIAmount, strIAmountBala;

                    strLoBala = lblFullBala.Text.Trim();
                    strIRate = lblIRate.Text.Trim();
                    strNewIRate = txtNewIRate.Text.Trim();
                    strIAmountBala = lblIntBalance.Text.Trim();

                    decimal decIA = Convert.ToDecimal(strIAmountBala);
                    decimal decNewIR = Convert.ToDecimal(strNewIRate);
                    decimal decBala = Convert.ToDecimal(strLoBala);

                    decimal decMinAmou = (decIA * decNewIR) / 100;
                    decimal round = decimal.Round(decMinAmou, 2, MidpointRounding.AwayFromZero);
                    string strMinAmou = Convert.ToString(round);

                    decimal decNewBala = decBala - round;
                    string strNewBala = Convert.ToString(decNewBala);

                    lblDeAmont.Text = strMinAmou;
                    lblNewBala.Text = strNewBala;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            IsExistContract();
        }

        protected void txtNewIRate_TextChanged(object sender, EventArgs e)
        {
            IRate();
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            RequestRebate();
        }
    }
}
