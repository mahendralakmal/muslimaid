﻿using System;
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

namespace LoanSystem.Micro
{
    public partial class ViewLoanDetails : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        string strCC, strloginID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                strCC = Request.QueryString["ConCode"].ToString();
                lblCC.Text = strCC;
                DataSet dsLD = objDBTask.selectData("select * from micro_loan_details l,micro_business_details b where b.contract_code = l.contra_code and l.loan_approved = 'P' and l.contra_code = '" + strCC + "';");

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

        protected void btnApproved_Click(object sender, EventArgs e)
        {
            lblCAMsg.Text = "";

            strloginID = Session["NIC"].ToString();
            string strUserType = Session["UserType"].ToString();
            string strStatus = cmbApproval.SelectedValue.ToString();
            string strDescri = txtDescription.Text.Trim();
            string strCCode = lblCC.Text.Trim();
            string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (strUserType == "Top Managment")
            {
                MySqlCommand cmdUpdateChequ = new MySqlCommand("Update micro_loan_details set loan_approved = '" + strStatus + "', loan_approved_user_nic = '" + strloginID + "',loan_approved_on = '" + strDate + "',OtherDescription = '" + strDescri + "' where contra_code = '" + strCCode + "' and loan_approved = 'P' and reg_approval = 'Y';");
                //int i = objDBTask.insertEditData(cmdUpdateChequ);

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
            else if (strUserType == "Regional Manager CS")
            {
                MySqlCommand cmdUpdateChequ = new MySqlCommand("Update micro_loan_details set reg_approval = '" + strStatus + "', reg_approval_nic = '" + strloginID + "',reg_approval_on = '" + strDate + "',reg_approval_des = '" + strDescri + "' where contra_code = '" + strCCode + "' and reg_approval is null;");
                //int i = objDBTask.insertEditData(cmdUpdateChequ);

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
            else
            {
                string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                base.Response.Write(close);
            }
            

            
        }
    }
}