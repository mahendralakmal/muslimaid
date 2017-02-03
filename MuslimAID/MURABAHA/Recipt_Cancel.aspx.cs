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
    public partial class Recipt_Cancel : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            { }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void txtRNo_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            Clear();
            if (txtRNo.Text.Trim() != "")
            {
                string strRNo = txtRNo.Text.Trim();
                DataSet dsCD = cls_Connection.getDataSet("select c.contract_code,c.nic,c.initial_name,h.paied_amount,h.payment_type from micro_payme_summery s, micro_pais_history h, micro_basic_detail c where c.contract_code = s.contra_code and s.contra_code = h.contra_code and h.idpais_history = s.rcp_no and h.pay_status = 'D' and h.idpais_history = '" + strRNo + "';");
                if (dsCD.Tables[0].Rows.Count > 0)
                {
                    lblAmount.Text = dsCD.Tables[0].Rows[0]["paied_amount"].ToString();
                    lblContractCode.Text = dsCD.Tables[0].Rows[0]["contract_code"].ToString();
                    lblNIC.Text = dsCD.Tables[0].Rows[0]["nic"].ToString();
                    lblName.Text = dsCD.Tables[0].Rows[0]["initial_name"].ToString();
                    lblType.Text = dsCD.Tables[0].Rows[0]["payment_type"].ToString();

                    btnPeied.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "No Record Found.";
                    btnPeied.Enabled = false;
                }
            }
            else
            {
                lblMsg.Text = "Please enter Receipt No.";
                btnPeied.Enabled = false;
            }
        }

        protected void Clear()
        {
            lblAmount.Text = "";
            lblContractCode.Text = "";
            lblName.Text = "";
            lblNIC.Text = "";
            lblType.Text = "";
            txtComment.Text = "";
        }

        protected void btnPeied_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtRNo.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Receipt No.";
            }
            else if (lblAmount.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Amount.";
            }
            else if (lblContractCode.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Contract Code.";
            }
            else if (lblName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Name.";
            }
            else if (lblNIC.Text.Trim() == "")
            {
                lblNIC.Text = "Please enter NIC.";
            }
            else if (txtComment.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Comment.";
            }
            else
            {
                string strRNo = txtRNo.Text.Trim();
                string strCCode = lblContractCode.Text.Trim();
                string strAmount = lblAmount.Text.Trim();
                decimal decAmou = Convert.ToDecimal(strAmount);
                string strComment = txtComment.Text.Trim();
                string strStatus = "C";
                string strType = lblType.Text.Trim();

                string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strIp = Request.UserHostAddress;
                string strloginID = Session["NIC"].ToString();

                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount + '" + strAmount + "' where contra_code = '" + strCCode + "';");
                int i;
                i = objDBTask.insertEditData(cmdUpdateLoanAmou);

                MySqlCommand cmdDeletePaymentSumm = new MySqlCommand("Update micro_payme_summery set p_status = '" + strStatus + "' WHERE rcp_no='" + strRNo + "' and contra_code='" + strCCode + "';");
                int x;
                x = objDBTask.insertEditData(cmdDeletePaymentSumm);

                //Get Current Debit
                string strCurBalance;
                decimal decCurBalance = 0;
                DataSet dsGetDebit = cls_Connection.getDataSet("select curr_balance from micro_payme_summery where contra_code = '" + strCCode + "' order by idcons_payme_summery desc limit 1;");
                if (dsGetDebit.Tables[0].Rows.Count > 0)
                {
                    strCurBalance = dsGetDebit.Tables[0].Rows[0]["curr_balance"].ToString();
                    decCurBalance = Convert.ToDecimal(strCurBalance);
                }

                decimal decPHCuBalance = decCurBalance + decAmou;
                string strPHCuBalance = Convert.ToString(decPHCuBalance);


                DataSet dsGetClieDeta = cls_Connection.getDataSet("select nic from micro_basic_detail where contract_code = '" + strCCode + "';");
                string strNIC = dsGetClieDeta.Tables[0].Rows[0]["nic"].ToString();

                string strZero = "0";
                string strCDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //add payment summery
                MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,curr_balance,p_status)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@curr_balance,@p_status);");

                #region Assign Parameters
                cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 13);
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
                cmdInsertPaySumm.Parameters.Add("@p_status", MySqlDbType.VarChar, 1);
                #endregion

                #region DEclare Parametes
                cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                cmdInsertPaySumm.Parameters["@amount"].Value = strAmount;
                cmdInsertPaySumm.Parameters["@capital"].Value = strZero;
                cmdInsertPaySumm.Parameters["@interest"].Value = strZero;
                cmdInsertPaySumm.Parameters["@debit"].Value = strAmount;
                cmdInsertPaySumm.Parameters["@c_default"].Value = strZero;
                cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNo;
                cmdInsertPaySumm.Parameters["@p_type"].Value = "RC";
                cmdInsertPaySumm.Parameters["@date_time"].Value = strCDate;
                cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                cmdInsertPaySumm.Parameters["@p_status"].Value = "D";
                #endregion

                int w;
                w = objDBTask.insertEditData(cmdInsertPaySumm);



                MySqlCommand cmdUpdatePaHis = new MySqlCommand("Update micro_pais_history set pay_status = '" + strStatus + "',reson = '" + strComment + "' where idpais_history = '" + strRNo + "' and contra_code = '" + strCCode + "';");
                int y;
                y = objDBTask.insertEditData(cmdUpdatePaHis);

                MySqlCommand cmdInsertCansel = new MySqlCommand("INSERT INTO micro_cansel_receipt(contra_code,rec_no,amount,user_nic,user_ip,date_time,reson)VALUES(@contra_code,@rec_no,@amount,@user_nic,@user_ip,@date_time,@reson);");

                #region Assign Parameters
                cmdInsertCansel.Parameters.Add("@contra_code", MySqlDbType.VarChar, 15);
                cmdInsertCansel.Parameters.Add("@rec_no", MySqlDbType.VarChar, 10);
                cmdInsertCansel.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
                cmdInsertCansel.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
                cmdInsertCansel.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsertCansel.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                cmdInsertCansel.Parameters.Add("@reson", MySqlDbType.VarChar, 255);
                #endregion

                #region DEclare Parametes
                cmdInsertCansel.Parameters["@contra_code"].Value = strCCode;
                cmdInsertCansel.Parameters["@rec_no"].Value = strRNo;
                cmdInsertCansel.Parameters["@amount"].Value = strAmount;
                cmdInsertCansel.Parameters["@user_nic"].Value = strloginID;
                cmdInsertCansel.Parameters["@user_ip"].Value = strIp;
                cmdInsertCansel.Parameters["@date_time"].Value = strDate;
                cmdInsertCansel.Parameters["@reson"].Value = strComment;
                #endregion

                try
                {
                    int f;
                    f = objDBTask.insertEditData(cmdInsertCansel);
                    if (f == 1)
                    {
                        lblMsg.Text = "Receipt is cancel.";
                        btnPeied.Enabled = false;
                        Clear();
                        txtRNo.Text = "";
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
}
