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
    public partial class Loan_Cancel : System.Web.UI.Page
    {
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
                Response.Redirect("../Login.aspx");
            }
        }

        private void ClearT()
        {
            txtContractCode.Text = "";
            txtDescription.Text = "";
            lblName.Text = "";
            lblNIC.Text = "";
            lblBusinessIncome.Text = "";
            lblTotalIncome.Text = "";
            lblDirectCost.Text = "";
            lblTotalExpences.Text = "";
            lblLoanAmount.Text = "";
            lblPeriod.Text = "";
            lblInterestRate.Text = "";
        }

        protected void GetDate()
        {
            try
            {
                string strBranch = Session["Branch"].ToString();
                string strUserType = Session["UserType"].ToString();

                DataSet dsLD = new DataSet();
                if (strUserType == "Top Managment")
                {
                    dsLD = cls_Connection.getDataSet("select c.full_name, c.nic, f.contract_code,f.busi_income,f.total_income,f.direct_cost,f.total_expenses,l.loan_amount,l.period,l.interest_rate,l.chequ_no from micro_business_details f, micro_loan_details l, micro_basic_detail c where f.contract_code = l.contra_code and c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.loan_sta = 'P' and c.contract_code = '" + txtContractCode.Text + "';");
                    if (dsLD.Tables[0].Rows.Count > 0)
                    {
                        string Cheq = dsLD.Tables[0].Rows[0]["chequ_no"].ToString();
                        DataSet dsLD1 = new DataSet();
                        dsLD1 = cls_Connection.getDataSet("select * from chequebook_registry where chq_status = 'C' and cheq_no = '" + Cheq + "';");
                        if (dsLD1.Tables[0].Rows.Count == 0)
                        {
                            lblName.Text = dsLD.Tables[0].Rows[0]["full_name"].ToString();
                            lblNIC.Text = dsLD.Tables[0].Rows[0]["nic"].ToString();
                            lblBusinessIncome.Text = dsLD.Tables[0].Rows[0]["busi_income"].ToString();
                            lblBusinessIncome.Text = dsLD.Tables[0].Rows[0]["busi_income"].ToString();
                            lblTotalIncome.Text = dsLD.Tables[0].Rows[0]["total_income"].ToString();
                            lblDirectCost.Text = dsLD.Tables[0].Rows[0]["direct_cost"].ToString();
                            lblTotalExpences.Text = dsLD.Tables[0].Rows[0]["total_expenses"].ToString();
                            lblLoanAmount.Text = dsLD.Tables[0].Rows[0]["loan_amount"].ToString();
                            lblPeriod.Text = dsLD.Tables[0].Rows[0]["period"].ToString();
                            lblInterestRate.Text = dsLD.Tables[0].Rows[0]["interest_rate"].ToString();
                        }
                        else
                        {
                            lblMsg.Text = "Cancel " + Cheq + " Cheque. Then Cancel the Loan.";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "No records found for your search criteria. Please try again.";
                    }
                }
                else
                {
                    lblMsg.Text = "No Access.";
                }
            }
            catch (Exception)
            {
            }
        }

        private void Approval()
        {
            try
            {
                lblMsg.Text = "";
                string strloginID = Session["NIC"].ToString();
                string strUserType = Session["UserType"].ToString();
                string strStatus = cmbApproval.SelectedValue.ToString();
                string strDescri = txtDescription.Text.Trim();
                string strCCode = txtContractCode.Text.Trim();
                string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strIp = Request.UserHostAddress;

                if (strUserType == "Top Managment")
                {
                    MySqlCommand cmdUpdateChequ = new MySqlCommand("Update micro_loan_details set loan_sta = '" + strStatus + "' where contra_code = '" + strCCode + "' and loan_approved = 'Y'");

                    try
                    {
                        int i;
                        i = objDBTask.insertEditData(cmdUpdateChequ);
                        if (i == 1)
                        {
                            MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_loan_cancel(contra_code,date_time,user_nic,ip,comment) VALUES ('" + strCCode + "','" + strDate + "','" + strloginID + "','" + strIp + "','" + strDescri + "');");

                            i = objDBTask.insertEditData(cmdInsert);
                            if (i == 1)
                            {
                                ClearT();
                                lblMsg.Text = "Updated Successfully";
                            }
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
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {
            if (txtContractCode.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Contract Code.";
            }
            else if (txtDescription.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Description.";
            }
            else
            {
                Approval();
            }

        }

        protected void txtContractCode_TextChanged(object sender, EventArgs e)
        {
            if (txtContractCode.Text != "")
            {
                GetDate();
            }
            else
            {
                ClearT();
                lblMsg.Text = "Please enter Contract Code.";
            }
        }
    }
}
