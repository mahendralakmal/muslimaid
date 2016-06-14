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

namespace LoanSystem.Micro
{
    public partial class ViewChequDetails : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        string strCC, strloginID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    strCC = Request.QueryString["ConCode"].ToString();
                    lblCC.Text = strCC;

                    DataSet dsLDCheck = objDBTask.selectData("select * from micro_loan_details where loan_approved = 'Y' and chequ_no is null and contra_code = '" + strCC + "';");
                    if (dsLDCheck.Tables[0].Rows.Count > 0)
                    {

                        DataSet dsLD = objDBTask.selectData("select loan_amount,acc_name,bank_name from micro_loan_details where contra_code = '" + strCC + "';");
                        if (dsLD.Tables[0].Rows.Count > 0)
                        {
                            txtCAmount.Text = dsLD.Tables[0].Rows[0]["loan_amount"].ToString();
                            txtChequName.Text = dsLD.Tables[0].Rows[0]["acc_name"].ToString();
                            txtBankName.Text = dsLD.Tables[0].Rows[0]["bank_name"].ToString();
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
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblCDMsg.Text = "";
            if (txtCNumber.Text.Trim() == "")
            {
                lblCDMsg.Text = "Please enter Chequ Number.";
            }
            else if (txtCAmount.Text.Trim() == "")
            {
                lblCDMsg.Text = "Please enter Chequ Amount.";
            }
            else if (txtBankName.Text.Trim() == "")
            {
                lblCDMsg.Text = "Please enter Bank Name.";
            }
            else if (txtChequName.Text.Trim() == "")
            {
                lblCDMsg.Text = "Please enter Chequ Name.";
            }
                else if(txtDate1.Text.Trim() == "")
            {
                lblCDMsg.Text="Please enter Day.";
                }
                else if(txtDate2.Text.Trim()=="")
            {
                    lblCDMsg.Text="Please enter Day 2.";
                }
                else if(txtMonth1.Text.Trim()=="")
            {
                    lblCDMsg.Text="Please enter Month.";
                }
                else if(txtMonth2.Text.Trim() == "")
            {
                lblCDMsg.Text = "Please enter Month 2";
                }
            else if (txtYear1.Text.Trim() == "")
            {
                lblCDMsg.Text = "Please enter Year.";
            }
            else if (txtYear2.Text.Trim() == "")
            {
                lblCDMsg.Text = "Please enter Year2.";
            }
            else
            {
                string strCA = txtCAmount.Text.Trim();
                string strCN = txtCNumber.Text.Trim();
                string strIp = Request.UserHostAddress;
                strloginID = Session["NIC"].ToString();
                string strIP = Request.UserHostAddress;
                string strName = txtChequName.Text.Trim();
                string strCCode = lblCC.Text.Trim();
                string strDate = DateTime.Now.ToString("yyyy-MM-dd");
                string strChePriDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string strDay1 = txtDate1.Text.Trim();
                string strDay2 = txtDate2.Text.Trim();
                string strMon1 = txtMonth1.Text.Trim();
                string strMon2 = txtMonth2.Text.Trim();
                string strYear1 = txtYear1.Text.Trim();
                string strYear2 = txtYear2.Text.Trim();
                
                //string strDate = 

                string strOCha, strIAmou, strPeriod, strBranchCode, strCenterDate;

                DataSet dsLDOCha = objDBTask.selectData("select l.other_charges,l.interest_amount,l.period,b.city_code,c.center_day from micro_loan_details l, micro_basic_detail b, center_details c where b.contract_code = l.contra_code and b.city_code = c.city_code and c.villages = b.village and b.society_id = c.idcenter_details and l.contra_code = '" + strCCode + "';");

                strOCha = dsLDOCha.Tables[0].Rows[0]["other_charges"].ToString();
                strIAmou = dsLDOCha.Tables[0].Rows[0]["interest_amount"].ToString();
                strPeriod = dsLDOCha.Tables[0].Rows[0]["period"].ToString();
                strBranchCode = dsLDOCha.Tables[0].Rows[0]["city_code"].ToString();
                strCenterDate = dsLDOCha.Tables[0].Rows[0]["center_day"].ToString();

                decimal decOCha = Convert.ToDecimal(strOCha);
                decimal decIAmo = Convert.ToDecimal(strIAmou);
                decimal decLA = Convert.ToDecimal(strCA);

                int intPeriod = Convert.ToInt32(strPeriod) * 7;

                decimal decPayedAmou = decIAmo + decLA;
                string strPayAmount = Convert.ToString(decPayedAmou);

                DateTime now = DateTime.Now;
                DateTime due = now.AddDays(7);

                DateTime dtMatuDate = now.AddDays(intPeriod);
                string strMatuDate = dtMatuDate.ToString("yyyy-MM-dd");

                string strDue = due.ToString("yyyy-MM-dd");

                MySqlCommand cmdUpdateChequ = new MySqlCommand("Update micro_loan_details set current_loan_amount = '" + strPayAmount + "',chequ_no = '" + strCN + "',chequ_amount = '" + strCA + "',chequ_deta_on = '" + strDate + "',cheq_detai_app_nic = '" + strloginID + "',due_date = '" + strCenterDate + "',maturity_date = '" + strMatuDate + "' where contra_code = '" + strCCode + "';");

                try
                {
                    int i;
                    i = objDBTask.insertEditData(cmdUpdateChequ);
                    if (i == 1)
                    {
                        lblCDMsg.Text = "Updated Successfully";

                        //Update Target
                        string strYear = DateTime.Now.Year.ToString();
                        string strMonth = DateTime.Now.Month.ToString();
                        DataSet dsGetExciting = objDBTask.selectData("select * from target_detail where t_year = '" + strYear + "' and t_month = '" + strMonth + "' and branch_code = '" + strBranchCode + "' and b_module = 'CS';");
                        if (dsGetExciting.Tables[0].Rows.Count > 0)
                        {
                            MySqlCommand cmdUpdateTarget = new MySqlCommand("Update target_detail set b_archi = b_archi + '" + strCA + "' where t_year = '" + strYear + "' and t_month = '" + strMonth + "' and b_module = 'CS' and live_status = 'L' and branch_code = '" + strBranchCode + "'; ");
                            int o;
                            o = objDBTask.insertEditData(cmdUpdateTarget);
                        }
                        else
                        {
                            MySqlCommand cmdInsertQRY = new MySqlCommand("INSERT INTO target_detail(t_year,t_month,branch_code,b_module,b_target,b_archi,live_status,create_user_nic,create_ip,date_time)VALUES(@t_year,@t_month,@branch_code,@b_module,@b_target,@b_archi,@live_status,@create_user_nic,@create_ip,@date_time);");

                            #region Assign Parameters
                            cmdInsertQRY.Parameters.Add("@t_year", MySqlDbType.VarChar, 4);
                            cmdInsertQRY.Parameters.Add("@t_month", MySqlDbType.VarChar, 2);
                            cmdInsertQRY.Parameters.Add("@branch_code", MySqlDbType.VarChar, 2);
                            cmdInsertQRY.Parameters.Add("@b_module", MySqlDbType.VarChar, 4);
                            cmdInsertQRY.Parameters.Add("@b_target", MySqlDbType.Decimal, 12);
                            cmdInsertQRY.Parameters.Add("@b_archi", MySqlDbType.Decimal, 12);
                            cmdInsertQRY.Parameters.Add("@live_status", MySqlDbType.VarChar, 1);
                            cmdInsertQRY.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
                            cmdInsertQRY.Parameters.Add("@create_ip", MySqlDbType.VarChar, 45);
                            cmdInsertQRY.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                            #endregion

                            #region DEclare Parametes
                            cmdInsertQRY.Parameters["@t_year"].Value = strYear;
                            cmdInsertQRY.Parameters["@t_month"].Value = strMonth;
                            cmdInsertQRY.Parameters["@branch_code"].Value = strBranchCode;
                            cmdInsertQRY.Parameters["@b_module"].Value = "CS";
                            cmdInsertQRY.Parameters["@b_target"].Value = "6000000";
                            cmdInsertQRY.Parameters["@b_archi"].Value = strCA;
                            cmdInsertQRY.Parameters["@live_status"].Value = "L";
                            cmdInsertQRY.Parameters["@create_user_nic"].Value = strloginID;
                            cmdInsertQRY.Parameters["@create_ip"].Value = strIp;
                            cmdInsertQRY.Parameters["@date_time"].Value = strDate;
                            #endregion

                            try
                            {
                                int ii;
                                ii = objDBTask.insertEditData(cmdInsertQRY);
                                if (ii == 1)
                                {

                                }
                                else
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO chq_date(contract_code,amount,chq_name,day1,day2,month1,month2,year1,year2,user_nic,user_ip,date_time)VALUES(@contract_code,@amount,@chq_name,@day1,@day2,@month1,@month2,@year1,@year2,@user_nic,@user_ip,@date_time);");

                        #region DeclarareParamerts
                        cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                        cmdInsert.Parameters.Add("@amount", MySqlDbType.Decimal, 12);
                        cmdInsert.Parameters.Add("@chq_name", MySqlDbType.VarChar, 100);
                        cmdInsert.Parameters.Add("@day1", MySqlDbType.VarChar, 1);
                        cmdInsert.Parameters.Add("@day2", MySqlDbType.VarChar, 1);
                        cmdInsert.Parameters.Add("@month1", MySqlDbType.VarChar, 1);
                        cmdInsert.Parameters.Add("@month2", MySqlDbType.VarChar, 1);
                        cmdInsert.Parameters.Add("@year1", MySqlDbType.VarChar, 1);
                        cmdInsert.Parameters.Add("@year2", MySqlDbType.VarChar, 1);
                        cmdInsert.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
                        cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                        cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                        #endregion

                        #region AssignParameters
                        cmdInsert.Parameters["@contract_code"].Value = strCCode;
                        cmdInsert.Parameters["@amount"].Value = strCA;
                        cmdInsert.Parameters["@chq_name"].Value = strName;
                        cmdInsert.Parameters["@day1"].Value = strDay1;
                        cmdInsert.Parameters["@day2"].Value = strDay2;
                        cmdInsert.Parameters["@month1"].Value = strMon1;
                        cmdInsert.Parameters["@month2"].Value = strMon2;
                        cmdInsert.Parameters["@year1"].Value = strYear1;
                        cmdInsert.Parameters["@year2"].Value = strYear2;
                        cmdInsert.Parameters["@user_nic"].Value = strloginID;
                        cmdInsert.Parameters["@user_ip"].Value = strIP;
                        cmdInsert.Parameters["@date_time"].Value = strChePriDateTime;
                        #endregion

                        try
                        {
                            int f;
                            f = objDBTask.insertEditData(cmdInsert);
                            if (f == 1)
                            {
                                Response.Redirect("Chequ_Print.aspx?CC=" + strCCode + "");
                            }
                            else
                            {
                                
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                        base.Response.Write(close);
                    }
                    else
                    {
                        lblCDMsg.Text = "Error occurred. Please try again.";
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
