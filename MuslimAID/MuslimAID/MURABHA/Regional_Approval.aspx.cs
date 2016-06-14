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
    public partial class Regional_Approval : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {

                if (!this.IsPostBack)
                {
                    //GetDate();
                    string strBranch = Session["Branch"].ToString();
                    string strUserType = Session["UserType"].ToString();

                    DataSet dsCenter = new DataSet();
                    if (strUserType == "Regional Manager CS")
                    {
                        dsCenter = objDBTask.selectData("select idcenter_details,center_name,villages from center_details ORDER BY idcenter_details asc");

                        //dsCenter = objDBTask.selectData(cmdCenter);
                        cmdSocietyNo.Items.Add("");

                        for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                        {
                            cmdSocietyNo.Items.Add("[" + dsCenter.Tables[0].Rows[i]["idcenter_details"] + "] - " + dsCenter.Tables[0].Rows[i]["center_name"] + "] - " + dsCenter.Tables[0].Rows[i]["villages"].ToString());
                            cmdSocietyNo.Items[i + 1].Value = dsCenter.Tables[0].Rows[i]["idcenter_details"].ToString();

                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                        //dsCenter = objDBTask.selectData("select idcenter_details,center_name,villages from center_details where city_code = '" + strBranch + "' ORDER BY idcenter_details asc");
                    }


                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void GetDate()
        {
            string strBranch = Session["Branch"].ToString();
            string strUserType = Session["UserType"].ToString();

            DataSet dsLD = new DataSet();
            if (strUserType == "Regional Manager CS")
            {
                if (cmdSocietyNo.SelectedIndex == 0)
                {
                    dsLD = objDBTask.selectData("select l.contra_code, d.ca_code, b.total_income, b.total_expenses, b.profit_lost,b.family_expenses,b.net_income,l.loan_amount,l.interest_rate,l.period,l.interest_amount,l.monthly_instollment from micro_loan_details l,micro_business_details b,micro_basic_detail d where b.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_approved = 'P' and l.loan_sta = 'P' and l.reg_approval is null;");
                }
                else
                {
                    string strSoNo = cmdSocietyNo.SelectedItem.Value;
                    dsLD = objDBTask.selectData("select l.contra_code, d.ca_code, b.total_income, b.total_expenses, b.profit_lost,b.family_expenses,b.net_income,l.loan_amount,l.interest_rate,l.period,l.interest_amount,l.monthly_instollment from micro_loan_details l,micro_business_details b,micro_basic_detail d where b.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_approved = 'P' and l.loan_sta = 'P' and l.reg_approval is null and d.society_id = '" + strSoNo + "';");
                }
            }
            //else if (strUserType == "Manager")
            //{
            //    if (cmdSocietyNo.SelectedIndex == 0)
            //    {
            //        dsLD = objDBTask.selectData("select l.contra_code, d.ca_code, b.total_income, b.total_expenses, b.profit_lost,b.family_expenses,b.net_income,l.loan_amount,l.interest_rate,l.period,l.interest_amount,l.monthly_instollment from micro_loan_details l,micro_business_details b,micro_basic_detail d where b.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_approved = 'P' and l.loan_sta = 'P' and d.city_code = '" + strBranch + "' and l.loan_amount < '75000';");
            //    }
            //    else
            //    {
            //        string strSoNo = cmdSocietyNo.SelectedItem.Value;
            //        dsLD = objDBTask.selectData("select l.contra_code, d.ca_code, b.total_income, b.total_expenses, b.profit_lost,b.family_expenses,b.net_income,l.loan_amount,l.interest_rate,l.period,l.interest_amount,l.monthly_instollment from micro_loan_details l,micro_business_details b,micro_basic_detail d where b.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_approved = 'P' and l.loan_sta = 'P' and d.society_id = '" + strSoNo + "' and d.city_code = '" + strBranch + "' and l.loan_amount < '75000';");
            //    }
            //}
            //else if (strUserType == "Team Leader")
            //{
            //    if (cmdSocietyNo.SelectedIndex == 0)
            //    {
            //        dsLD = objDBTask.selectData("select l.contra_code, d.ca_code, b.total_income, b.total_expenses, b.profit_lost,b.family_expenses,b.net_income,l.loan_amount,l.interest_rate,l.period,l.interest_amount,l.monthly_instollment from micro_loan_details l,micro_business_details b,micro_basic_detail d where b.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_approved = 'P' and l.loan_sta = 'P' and d.city_code = '" + strBranch + "' and l.loan_amount < '25000';");
            //    }
            //    else
            //    {
            //        string strSoNo = cmdSocietyNo.SelectedItem.Value;
            //        dsLD = objDBTask.selectData("select l.contra_code, d.ca_code, b.total_income, b.total_expenses, b.profit_lost,b.family_expenses,b.net_income,l.loan_amount,l.interest_rate,l.period,l.interest_amount,l.monthly_instollment from micro_loan_details l,micro_business_details b,micro_basic_detail d where b.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_approved = 'P' and l.loan_sta = 'P' and d.society_id = '" + strSoNo + "' and d.city_code = '" + strBranch + "' and l.loan_amount < '25000';");
            //    }
            //}


            if (dsLD.Tables[0].Rows.Count > 0)
            {
                grvLoanAppr.DataSource = dsLD;
                grvLoanAppr.DataBind();
            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            grvLoanAppr.DataSource = null;
            grvLoanAppr.DataBind();
            GetDate();
        }
    }
}
