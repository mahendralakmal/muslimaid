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

namespace MuslimAID.SALAM
{
    public partial class Chequ_Cancel : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (Session["UserType"] != "Cash Collector" || Session["UserType"] != "Cash Recovery Officer" || Session["UserType"] != "Special Recovery Officer")
                {
                    txtOther.Visible = false;
                }
                else { Response.Redirect("salam.aspx"); }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void Clear()
        {
            lblAmount.Text = "";
            lblContractCode.Text = "";
            lblName.Text = "";
            lblNIC.Text = "";
            txtComment.Text = "";
            lblChequeDate.Text = "";
            lblAccountNo.Text = "";
        }

        private void ExistCheq()
        {
            try
            {
                lblMsg.Text = "";
                Clear();
                if (txtRNo.Text.Trim() != "")
                {
                    string strRNo = txtRNo.Text.Trim();
                    DataSet dsChequeNo = cls_Connection.getDataSet("select * from chequebook_registry where cheq_no = '" + strRNo + "' ;");

                    if (dsChequeNo.Tables[0].Rows.Count > 0)
                    {
                        if (dsChequeNo.Tables[0].Rows[0]["chq_status"].ToString() == "A")
                        {
                            DataSet dsCD = cls_Connection.getDataSet("select c.contract_code,c.nic,c.initial_name,h.amount AS paied_amount,concat('20',year1,year2,'-',month1,month2,'-',day1,day2) as ChequeDate from chq_date h inner join salam_basic_detail c on c.contract_code = h.contract_code inner join salam_loan_details l on l.contra_code = c.contract_code where l.chequ_no = '" + strRNo + "' and chq_status = 'A' and loan_sta != 'C';");
                            if (dsCD.Tables[0].Rows.Count > 0)
                            {
                                lblAmount.Text = dsCD.Tables[0].Rows[0]["paied_amount"].ToString();
                                lblContractCode.Text = dsCD.Tables[0].Rows[0]["contract_code"].ToString();
                                lblNIC.Text = dsCD.Tables[0].Rows[0]["nic"].ToString();
                                lblName.Text = dsCD.Tables[0].Rows[0]["initial_name"].ToString();
                                lblChequeDate.Text = dsCD.Tables[0].Rows[0]["ChequeDate"].ToString();
                                lblAccountNo.Text = dsChequeNo.Tables[0].Rows[0]["AccountNo"].ToString();
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
                            lblMsg.Text = "This cheque number is already Cancel";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "No Record Found.";
                    }
                }
                else
                {
                    lblMsg.Text = "Please enter Cheque No.";
                    btnPeied.Enabled = false;
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "No Record Found.";
            }
        }

        private void SaveCheqCancel()
        {
            try
            {
                lblMsg.Text = "";
                if (txtRNo.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Cheque No.";
                }
                else if (lblAmount.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Amount.";
                }
                else if (lblContractCode.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Facility Code.";
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
                    if (txtComment.SelectedItem.Text == "Other")
                    {
                        strComment = txtOther.Text.Trim();
                    }
                    string strChequeDate = lblChequeDate.Text;
                    string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string strIp = Request.UserHostAddress;
                    string strAccount = lblAccountNo.Text;
                    string strloginID = Session["NIC"].ToString();

                    MySqlCommand cmdUpdateCheque = new MySqlCommand("Update salam_loan_details set chequ_no = null,chequ_amount = 0.00,chequ_deta_on = '',cheq_detai_app_nic = '',due_date = '',maturity_date = '' where contra_code = '" + strCCode + "';");
                    try
                    {
                        int f;
                        f = objDBTask.insertEditData(cmdUpdateCheque);
                        if (f == 1)
                        {
                            MySqlCommand cmdUpdateChequeNo = new MySqlCommand("Update chequebook_registry set chq_status = 'C', status = 0 where cheq_no = '" + strRNo + "';");
                            try
                            {
                                int g;
                                g = objDBTask.insertEditData(cmdUpdateChequeNo);
                                if (g == 1)
                                { }
                            }
                            catch (Exception ex)
                            {
                            }

                            MySqlCommand cmdUpdateChe = new MySqlCommand("INSERT INTO chequebookCancel(`cheq_no`,`contract_code`,`chequ_deta_on`,`cancel_date`,`cancel_user`,`ChequeAmount`,`AccountNo`,Comment) values ('" + strRNo + "','" + strCCode + "','" + strChequeDate + "','" + strDate + "','" + strloginID + "','" + decAmou + "','" + strAccount + "','" + strComment + "');");
                            try
                            {
                                int g;
                                g = objDBTask.insertEditData(cmdUpdateChe);
                                if (g == 1)
                                { }
                            }
                            catch (Exception ex)
                            {
                            }

                            MySqlCommand cmdUChequeNo = new MySqlCommand("Update chq_date set chq_status = 'C' where contract_code = '" + strCCode + "';");
                            try
                            {
                                int g;
                                g = objDBTask.insertEditData(cmdUChequeNo);
                                if (g == 1)
                                { }
                            }
                            catch (Exception ex)
                            {
                            }
                            lblMsg.Text = "Cheque is Cancel.";
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
                        lblMsg.Text = "Error Occured!";
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void txtRNo_TextChanged(object sender, EventArgs e)
        {
            ExistCheq();
        }

        protected void btnPeied_Click(object sender, EventArgs e)
        {
            SaveCheqCancel();
        }

        protected void txtComment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtComment.SelectedItem.Text == "Other")
            {
                txtOther.Visible = true;
                txtOther.Text = "";
                txtOther.Focus();
            }
            else
            {
                txtOther.Visible = false;
                txtOther.Text = "";
            }
        }
    }
}
