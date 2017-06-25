using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MuslimAID;

namespace MuslimAID.MURABAHA
{
    public partial class Approved_rebate : System.Web.UI.Page
    {
        cls_Connection objCommonTask = new cls_Connection();
        cls_Connection objDBTask = new cls_Connection();
        string strCC, strloginID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                strCC = Request.QueryString["ConCode"].ToString();
                lblCC.Text = strCC;
                DataSet dsLD = cls_Connection.getDataSet("select * from rebate where sta='P' and contra_code = '" + strCC + "';");

                if (dsLD.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                    base.Response.Write(close);
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        private void ApprovedRebate()
        {
            lblCAMsg.Text = "";

            strloginID = Session["NIC"].ToString();
            string strStatus = cmbApproval.SelectedValue.ToString();
            string strDescri = txtDescription.Text.Trim();
            string strCCode = lblCC.Text.Trim();
            string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strIp = Request.UserHostAddress;

            //Add History record
            DataSet dsLD = cls_Connection.getDataSet("select nic,min_amount from rebate where sta='P' and contra_code = '" + strCCode + "';");
            if (dsLD.Tables[0].Rows.Count != 0)
            {
                string strNIC = dsLD.Tables[0].Rows[0]["nic"].ToString();
                string strMinAmou = dsLD.Tables[0].Rows[0]["min_amount"].ToString();
                decimal decAmou = Convert.ToDecimal(strMinAmou);
                string strDef = "0";

                //Update Loan Details Table
                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = 0, loan_sta = 'S' where contra_code = '" + strCCode + "';");
                int s;
                s = objDBTask.insertEditData(cmdUpdateLoanAmou);

                //Get Current Debit
                string strCurBalance;
                decimal decCurBalance = 0;
                DataSet dsGetDebit = cls_Connection.getDataSet("select curr_balance from micro_payme_summery where contra_code = '" + strCCode + "' order by idcons_payme_summery desc limit 1;");
                if (dsGetDebit.Tables[0].Rows.Count > 0)
                {
                    strCurBalance = dsGetDebit.Tables[0].Rows[0]["curr_balance"].ToString();
                    decCurBalance = Convert.ToDecimal(strCurBalance);
                }

                decimal decPHCuBalance = decCurBalance - decAmou;
                string strPHCuBalance = Convert.ToString(decPHCuBalance);

                //add payment summery
                MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance,p_status)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance,@p_status);");

                #region Assign Parameters
                cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 10);
                cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
                cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
                cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
                cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
                cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
                cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
                cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
                cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
                cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                cmdInsertPaySumm.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
                cmdInsertPaySumm.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
                cmdInsertPaySumm.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
                cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
                cmdInsertPaySumm.Parameters.Add("@p_status", MySqlDbType.VarChar, 1);
                #endregion

                #region DEclare Parametes
                cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                cmdInsertPaySumm.Parameters["@amount"].Value = strMinAmou;
                cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                cmdInsertPaySumm.Parameters["@interest"].Value = strMinAmou;
                cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                cmdInsertPaySumm.Parameters["@rcp_no"].Value = "-";
                cmdInsertPaySumm.Parameters["@p_type"].Value = "R";
                cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                cmdInsertPaySumm.Parameters["@payment_type"].Value = "";
                cmdInsertPaySumm.Parameters["@chq_No"].Value = "";
                cmdInsertPaySumm.Parameters["@chq_bank"].Value = "";
                cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                cmdInsertPaySumm.Parameters["@p_status"].Value = "D";
                #endregion

                int w;
                w = objDBTask.insertEditData(cmdInsertPaySumm);
            }

            //Update Rebate Table.

            MySqlCommand cmdUpdateChequ = new MySqlCommand("Update rebate set sta = '" + strStatus + "',descrip = '" + strDescri + "',auth_nic = '" + strloginID + "',auth_date_time = '" + strDate + "',auth_ip = '" + strIp + "' where contra_code = '" + strCCode + "' and sta = 'P';");

            try
            {
                int i;
                i = objDBTask.insertEditData(cmdUpdateChequ);
                if (i == 1)
                {
                    lblCAMsg.Text = "Updated Successfully";

                    string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                    base.Response.Write(close);
                }
                else
                {
                    lblCAMsg.Text = "Error occurred. Please try again.";
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {
            ApprovedRebate();
        }
    }
}
