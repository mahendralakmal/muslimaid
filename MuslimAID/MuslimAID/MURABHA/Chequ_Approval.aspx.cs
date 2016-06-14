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
    public partial class Chequ_Approval : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                

                if (!this.IsPostBack)
                {
                    string strBranch = Session["Branch"].ToString();
                    string strUserType = Session["UserType"].ToString();

                    DataSet dsCenter = new DataSet();
                    if (strUserType == "Top Managment")
                    {
                        dsCenter = objDBTask.selectData("select idcenter_details,center_name,villages from center_details ORDER BY idcenter_details asc");
                    }
                    else
                    {
                        dsCenter = objDBTask.selectData("select idcenter_details,center_name,villages from center_details where city_code = '" + strBranch + "' ORDER BY idcenter_details asc");
                    }

                    //dsCenter = objDBTask.selectData(cmdCenter);
                    cmdSocietyNo.Items.Add("");

                    for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                    {
                        cmdSocietyNo.Items.Add("[" + dsCenter.Tables[0].Rows[i]["idcenter_details"] + "] - " + dsCenter.Tables[0].Rows[i]["center_name"] + "] - " + dsCenter.Tables[0].Rows[i]["villages"].ToString());
                        cmdSocietyNo.Items[i + 1].Value = dsCenter.Tables[0].Rows[i]["idcenter_details"].ToString();

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

            //if (strBranch == "BE")
            //{

                DataSet dsLD = new DataSet();

                if (strUserType == "Top Managment")
                {
                    if (cmdSocietyNo.SelectedIndex == 0)
                    {
                        dsLD = objDBTask.selectData("select l.contra_code,l.loan_amount,l.interest_amount,l.period from micro_loan_details l, micro_basic_detail b where l.contra_code = b.contract_code and l.loan_approved = 'Y' and l.chequ_no is null and l.loan_sta = 'P';");
                    }
                    else
                    {
                        string strSoNo = cmdSocietyNo.SelectedItem.Value;

                        dsLD = objDBTask.selectData("select l.contra_code,l.loan_amount,l.interest_amount,l.period from micro_loan_details l,micro_basic_detail d where l.contra_code = d.contract_code and l.loan_approved = 'Y' and l.chequ_no is null and l.loan_sta = 'P' and d.society_id = '" + strSoNo + "';");
                    }
                }
                else
                {
                    if (cmdSocietyNo.SelectedIndex == 0)
                    {
                        dsLD = objDBTask.selectData("select l.contra_code,l.loan_amount,l.interest_amount,l.period from micro_loan_details l, micro_basic_detail b where l.contra_code = b.contract_code and l.loan_approved = 'Y' and l.chequ_no is null and l.loan_sta = 'P' and b.city_code = '" + strBranch + "';");
                    }
                    else
                    {
                        string strSoNo = cmdSocietyNo.SelectedItem.Value;

                        dsLD = objDBTask.selectData("select l.contra_code,l.loan_amount,l.interest_amount,l.period from micro_loan_details l,micro_basic_detail d where l.contra_code = d.contract_code and l.loan_approved = 'Y' and l.chequ_no is null and l.loan_sta = 'P' and d.society_id = '" + strSoNo + "' and d.city_code = '" + strBranch + "';");
                    }
                }


                if (dsLD.Tables[0].Rows.Count > 0)
                {
                    grvChequAppr.DataSource = dsLD;
                    grvChequAppr.DataBind();
                }
                else
                {
                    lblMsg.Text = "No records found for your search criteria. Please try again.";
                }
            //}
            //else
            //{
            //    lblMsg.Text = "Tempoaraly suspance the cheque printing option. Please Contact Finance Section.";
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            grvChequAppr.DataSource = null;
            grvChequAppr.DataBind();
            GetDate();

            //lblMsg.Text = "Tempoaraly suspance the cheque printing option. Please Contact Finance Section.";
        }

        protected void grvChequAppr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            grvChequAppr.PageIndex = e.NewPageIndex;


            // Rebind the GridView control to  
            // show data in the new page.
            GetDate();
        }
    }
}
