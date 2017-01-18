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
    public partial class WayOffAmount : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {

                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        private void Clear()
        {
            btnConfirm.Enabled = false;
            lblConCode.Text = "";
            lblName.Text = "";
            lblLoanAmou.Text = "";
            lblIAmount.Text = "";
            lblPeriod.Text = "";
            lblGrantDate.Text = "";
            lblTotCurrentBalance.Text = "";
            lblDueInstallment.Text = "";
            lblOverPayment.Text = "";
            lblTotalArreas.Text = "";
            lblTotalDefault.Text = "";
            lblLoanStock.Text = "";
            lblFutureCapital.Text = "";
            lblFutureInterest.Text = "";
            txtInterRebate.Text = "";
        }

        private void Load()
        {
            try
            {
                lblMsg.Text = "";
                hstrSelectQuery.Value = "";
                if (txtCC.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = "SELECT l.contra_code, b.initial_name, l.loan_amount, l.interest_amount, l.period, l.chequ_deta_on, l.current_loan_amount, l.due_installment, l.over_payment, l.arres_amou, l.def TotalDefault  FROM micro_loan_details l INNER JOIN micro_basic_detail b ON l.contra_code = b.contract_code WHERE l.contra_code = '" + txtCC.Text.Trim() + "' and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P' ;";

                    string strQRY = hstrSelectQuery.Value;
                    DataSet dsGetTrans = cls_Connection.getDataSet(strQRY);
                    Clear();
                    if (dsGetTrans.Tables[0].Rows.Count > 0)
                    {
                        lblConCode.Text = dsGetTrans.Tables[0].Rows[0]["contra_code"].ToString();
                        lblName.Text = dsGetTrans.Tables[0].Rows[0]["initial_name"].ToString();
                        lblLoanAmou.Text = dsGetTrans.Tables[0].Rows[0]["loan_amount"].ToString();
                        lblIAmount.Text = dsGetTrans.Tables[0].Rows[0]["interest_amount"].ToString();
                        lblPeriod.Text = dsGetTrans.Tables[0].Rows[0]["period"].ToString();
                        lblGrantDate.Text = dsGetTrans.Tables[0].Rows[0]["chequ_deta_on"].ToString();
                        lblTotCurrentBalance.Text = dsGetTrans.Tables[0].Rows[0]["current_loan_amount"].ToString();
                        lblDueInstallment.Text = dsGetTrans.Tables[0].Rows[0]["due_installment"].ToString();
                        lblOverPayment.Text = dsGetTrans.Tables[0].Rows[0]["over_payment"].ToString();
                        lblTotalArreas.Text = dsGetTrans.Tables[0].Rows[0]["arres_amou"].ToString();
                        lblTotalDefault.Text = dsGetTrans.Tables[0].Rows[0]["TotalDefault"].ToString();

                        lblLoanStock.Text = LoanStock(dsGetTrans.Tables[0].Rows[0]["contra_code"].ToString(), Convert.ToDecimal(dsGetTrans.Tables[0].Rows[0]["loan_amount"])).ToString();
                        lblFutureCapital.Text = FutureCapital(dsGetTrans.Tables[0].Rows[0]["contra_code"].ToString(), Convert.ToDecimal(dsGetTrans.Tables[0].Rows[0]["loan_amount"])).ToString();
                        lblFutureInterest.Text = FutureInterest(dsGetTrans.Tables[0].Rows[0]["contra_code"].ToString(), Convert.ToDecimal(dsGetTrans.Tables[0].Rows[0]["interest_amount"])).ToString();

                        txtInterRebate.Text = lblTotCurrentBalance.Text = dsGetTrans.Tables[0].Rows[0]["current_loan_amount"].ToString();
                        btnConfirm.Enabled = true;
                        //lblMsg.Text = "Can not Settle the Loan, Not exceeded the period";
                    }
                    else
                    {
                        lblMsg.Text = "No records found for your search Contract Code, Not activate or not approved. Please try again.";
                    }
                }
                else
                {
                    lblMsg.Text = "Please enter Contract Code.";
                }
            }
            catch (Exception)
            {
                Clear();
            }
        }

        //Future Capital 
        private decimal FutureCapital(string CusCode, decimal LoanAmount)
        {
            try
            {
                decimal TotalCapital = 0, CapitalOutstanding = 0;
                string strQRY = "SELECT IFNULL(sum(capital), 0) AS capital FROM micro_payme_summery  WHERE contra_code = '" + CusCode + "' AND p_type = 'DB' and p_status = 'D';";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    TotalCapital = Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["capital"]);
                    CapitalOutstanding = LoanAmount - TotalCapital;
                }
                else
                {
                    CapitalOutstanding = 0;
                }
                return CapitalOutstanding;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Future Interest 
        private decimal FutureInterest(string CusCode, decimal InterestAmount)
        {
            try
            {
                decimal TotalInterest = 0, FutureInterest = 0;
                string strQRY = "SELECT IFNULL(sum(interest), 0) AS capital FROM micro_payme_summery  WHERE contra_code = '" + CusCode + "' AND p_type = 'DB' and p_status = 'D';";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    TotalInterest = Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["capital"]);
                    FutureInterest = InterestAmount - TotalInterest;
                }
                else
                {
                    FutureInterest = 0;
                }
                return FutureInterest;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Loan Stock
        private decimal LoanStock(string CusCode, decimal LoanAmount)
        {
            try
            {
                decimal TotalCapital = 0, LoanStock = 0;
                string strQRY = "SELECT IFNULL(sum(capital), 0) AS capital FROM micro_payme_summery  WHERE contra_code = '" + CusCode + "' AND p_type = 'WI' and p_status = 'D';";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    TotalCapital = Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["capital"]);
                    LoanStock = LoanAmount - TotalCapital;
                }
                else
                {
                    LoanStock = 0;
                }
                return LoanStock;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void Submit()
        {
            try
            {
                if (txtInterRebate.Text!="")
                {
                    MySqlCommand cmdSelect = new MySqlCommand("select * from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code  and l.contra_code = '" + lblConCode.Text + "';");
                    DataSet dtLoanDet = cls_Connection.selectDataSet(cmdSelect);
                    if (dtLoanDet.Tables[0].Rows.Count > 0)
                    {
                        string strCCode = lblConCode.Text;
                        string DateT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set arres_amou = '0.00',def = '0.00',arres_count = '0',loan_sta = 'W',closing_date = '" + DateT + "',current_loan_amount = '0.00' where contra_code = '" + strCCode + "';");
                        int ii;
                        ii = objDBTask.insertEditData(cmdUpdateLoanAmou);
                        
                        //add payment summery
                        
                        string strNIC = dtLoanDet.Tables[0].Rows[0]["nic"].ToString();
                        string strDebitMI = txtInterRebate.Text;
                        string strZero = "0";

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
                        cmdInsertPaySumm.Parameters["@debit"].Value = "0.00";
                        cmdInsertPaySumm.Parameters["@c_default"].Value = strZero;
                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WR";
                        cmdInsertPaySumm.Parameters["@date_time"].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = 0;
                        #endregion

                        int w;
                        w = objDBTask.insertEditData(cmdInsertPaySumm);

                        Clear();
                        txtInterRebate.Text = "";
                        txtCC.Text = "";
                        lblMsg.Text = "Sucessfully";
                    } 
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Submit();
        }
    }
}
