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

namespace MuslimAID.MURABHA
{
    public partial class ViewChequDetails : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        string strCC, strloginID;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ChqDate = DateTime.Now.ToString("yyyy-MM-dd");
                if (Session["LoggedIn"].ToString() == "True")
                {
                    if (!this.IsPostBack)
                    {
                        Bank();
                        strCC = Request.QueryString["ConCode"].ToString();
                        lblCC.Text = strCC;

                        DataSet dsLDCheck = cls_Connection.getDataSet("select * from micro_loan_details where loan_approved = 'Y' and chequ_no is null and contra_code = '" + strCC + "';");
                        if (dsLDCheck.Tables[0].Rows.Count > 0)
                        {
                            DataSet dsLD = cls_Connection.getDataSet("select loan_amount, s.name as acc_name, s.bank, s.branch, s.account_no from micro_loan_details l INNER JOIN micro_supplier_details s on l.contra_code = s.contract_code where l.contra_code = '" + strCC + "';");
                            if (dsLD.Tables[0].Rows.Count > 0)
                            {
                                txtCAmount.Text = dsLD.Tables[0].Rows[0]["loan_amount"].ToString();
                                txtChequName.Text = dsLD.Tables[0].Rows[0]["acc_name"].ToString();
                                cmbBankName.SelectedValue = dsLD.Tables[0].Rows[0]["bank"].ToString();
                                //txtBankName.Text = cmbBankName.Sele
                                txtAccNo.Text = dsLD.Tables[0].Rows[0]["account_no"].ToString();

                                txtDate1.Text = ChqDate.Substring(8, 1).ToString();
                                txtDate2.Text = ChqDate.Substring(9, 1).ToString();
                                txtMonth1.Text = ChqDate.Substring(5, 1).ToString();
                                txtMonth2.Text = ChqDate.Substring(6, 1).ToString();
                                txtYear1.Text = ChqDate.Substring(2, 1).ToString();
                                txtYear2.Text = ChqDate.Substring(3, 1).ToString();
                                try
                                {
                                    //Add Bank
                                    DataSet dsCheqNo;
                                    MySqlCommand cmdCheqNo = new MySqlCommand("SELECT cheq_no FROM chequebook_registry where status = 1;");
                                    dsCheqNo = objDBTask.selectData(cmdCheqNo);
                                    cmbChqNo.Items.Add("");
                                    for (int i = 0; i < dsCheqNo.Tables[0].Rows.Count; i++)
                                    {
                                        cmbChqNo.Items.Add(dsCheqNo.Tables[0].Rows[i][0].ToString());
                                        cmbChqNo.Items[i + 1].Value = dsCheqNo.Tables[0].Rows[i][0].ToString();
                                    }
                                    cmbChqNo.SelectedIndex = 1;
                                    txtCNumber.Text = cmbChqNo.SelectedValue;
                                }
                                catch (Exception)
                                {
                                }
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
                    Response.Redirect("../Login.aspx");
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
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
                else if (txtDate1.Text.Trim() == "")
                {
                    lblCDMsg.Text = "Please enter Day.";
                }
                else if (txtDate2.Text.Trim() == "")
                {
                    lblCDMsg.Text = "Please enter Day 2.";
                }
                else if (txtMonth1.Text.Trim() == "")
                {
                    lblCDMsg.Text = "Please enter Month.";
                }
                else if (txtMonth2.Text.Trim() == "")
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
                    //string strDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string strChePriDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string strDay1 = txtDate1.Text.Trim();
                    string strDay2 = txtDate2.Text.Trim();
                    string strMon1 = txtMonth1.Text.Trim();
                    string strMon2 = txtMonth2.Text.Trim();
                    string strYear1 = txtYear1.Text.Trim();
                    string strYear2 = txtYear2.Text.Trim();

                    string strDate = "20" + strYear1 + strYear2 + "-" + strMon1 + strMon2 + "-" + strDay1 + strDay2;

                    string strOCha, strIAmou, strPeriod, strBranchCode, strCenterDay,CenterCode;

                    DataSet dsLDOCha = cls_Connection.getDataSet("select l.other_charges,l.interest_amount,l.period,b.city_code,c.center_day,l.next_center_day,society_id from micro_loan_details l, micro_basic_detail b, center_details c where b.contract_code = l.contra_code and b.city_code = c.city_code and b.society_id = c.idcenter_details and l.contra_code = '" + strCCode + "';");

                    strOCha = dsLDOCha.Tables[0].Rows[0]["other_charges"].ToString();
                    strIAmou = (dsLDOCha.Tables[0].Rows[0]["interest_amount"].ToString()) == "" ? "0.00" : dsLDOCha.Tables[0].Rows[0]["interest_amount"].ToString();
                    strPeriod = dsLDOCha.Tables[0].Rows[0]["period"].ToString();
                    strBranchCode = dsLDOCha.Tables[0].Rows[0]["city_code"].ToString();
                    strCenterDay = dsLDOCha.Tables[0].Rows[0]["center_day"].ToString();
                    CenterCode = dsLDOCha.Tables[0].Rows[0]["society_id"].ToString();
                    decimal decOCha = Convert.ToDecimal(strOCha);
                    decimal decIAmo = Convert.ToDecimal(strIAmou);
                    decimal decLA = Convert.ToDecimal(strCA);

                    int intPeriod = Convert.ToInt32(strPeriod) * 7;

                    decimal decPayedAmou = decIAmo + decLA;
                    string strPayAmount = Convert.ToString(decPayedAmou);

                    DateTime now = DateTime.Now;
                    //DateTime due = now.AddDays(7);

                    //Set Active Date with Center Day
                    DateTime due = CenterActiveDay(strCenterDay);
                    //-----
                    //Check Next Center Day
                    if (dsLDOCha.Tables[0].Rows[0]["next_center_day"].ToString() == "1")
                    {
                        due = due.AddDays(7);
                    }

                    string strDue = due.ToString("yyyy-MM-dd");

                    //Chk Holiday
                    try
                    {
                        DataSet dsHoliday = cls_Connection.getDataSet("select holiday_date from recovery_holiday where date_sta = 'A' and holiday_date = '" + strDue + "' and branch_code = 'AL' and center_id = 'AL' ;");
                        if (dsHoliday.Tables[0].Rows.Count > 0)
                        {
                            due = due.AddDays(7);
                        }
                        else
                        {
                            DataSet dsHday = cls_Connection.getDataSet("select holiday_date from recovery_holiday where date_sta = 'A' and holiday_date = '" + strDue + "' and branch_code = '" + strBranchCode + "' and center_id = '" + CenterCode + "' ;");
                            if (dsHday.Tables[0].Rows.Count > 0)
                            {
                                due = due.AddDays(7);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    //-----

                    DateTime dtMatuDate = now.AddDays(intPeriod);
                    string strMatuDate = dtMatuDate.ToString("yyyy-MM-dd");
                    strDue = due.ToString("yyyy-MM-dd");

                    MySqlCommand cmdUpdateChequ = new MySqlCommand("Update micro_loan_details set current_loan_amount = '" + strPayAmount + "',chequ_no = '" + strCN + "',chequ_amount = '" + strCA + "',chequ_deta_on = '" + strDate + "',cheq_detai_app_nic = '" + strloginID + "',due_date = '" + strDue + "',maturity_date = '" + strMatuDate + "',bank_name = '" + txtBankName.Text + "' where contra_code = '" + strCCode + "';");

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
                            DataSet dsGetExciting = cls_Connection.getDataSet("select * from target_detail where t_year = '" + strYear + "' and t_month = '" + strMonth + "' and branch_code = '" + strBranchCode + "' and b_module = 'CS';");
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

                            //Inser Cheque
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

                            //Update Cheque No
                            try
                            {
                                MySqlCommand cmdUpdateChequNo = new MySqlCommand("UPDATE chequebook_registry SET `status` = 0 WHERE cheq_no = '" + txtCNumber.Text + "'; ");
                                int o;
                                o = objDBTask.insertEditData(cmdUpdateChequNo);
                            }
                            catch (Exception)
                            {

                            }

                            //Insert Voucher
                            string voucher_no = "0";
                            DataSet dsGetMaxVouchNo = cls_Connection.getDataSet("SELECT ifnull(max(voucher_no),0)+1 AS voucher_no FROM micro_voucher_print;");
                            if (dsGetMaxVouchNo.Tables[0].Rows.Count > 0)
                            {
                                voucher_no = dsGetMaxVouchNo.Tables[0].Rows[0]["voucher_no"].ToString();
                            }
                            MySqlCommand cmdVoucher = new MySqlCommand("INSERT INTO micro_voucher_print(`voucher_no`,`contract_code`,`voucher_date`,`print_date`,`print_user`,`isPrint`,`status`)VALUES(@voucher_no,@contract_code,@voucher_date,@print_date,@print_user,@isPrint,@status);");

                            #region DeclarareParamerts
                            cmdVoucher.Parameters.Add("@voucher_no", MySqlDbType.VarChar, 11);
                            cmdVoucher.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                            cmdVoucher.Parameters.Add("@voucher_date", MySqlDbType.VarChar, 45);
                            cmdVoucher.Parameters.Add("@print_date", MySqlDbType.VarChar, 45);
                            cmdVoucher.Parameters.Add("@print_user", MySqlDbType.VarChar, 45);
                            cmdVoucher.Parameters.Add("@isPrint", MySqlDbType.VarChar, 1);
                            cmdVoucher.Parameters.Add("@status", MySqlDbType.VarChar, 1);
                            #endregion

                            #region AssignParameters
                            cmdVoucher.Parameters["@voucher_no"].Value = voucher_no;
                            cmdVoucher.Parameters["@contract_code"].Value = strCCode;
                            cmdVoucher.Parameters["@voucher_date"].Value = strDate;
                            cmdVoucher.Parameters["@print_date"].Value = strDate;
                            cmdVoucher.Parameters["@print_user"].Value = strloginID;
                            cmdVoucher.Parameters["@isPrint"].Value = 0;
                            cmdVoucher.Parameters["@status"].Value = 1;
                            #endregion

                            try
                            {
                                int f;
                                f = objDBTask.insertEditData(cmdVoucher);
                                if (f == 1)
                                {
                                }
                                else
                                {
                                }
                            }
                            catch (Exception ex)
                            {
                            }

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
            catch (Exception em)
            {
            }
        }

        private DateTime CenterActiveDay(string strCenterDay)
        {
            //Set Active Date with Center Day
            string[] strDayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            string nowDay = DateTime.Now.DayOfWeek.ToString();
            DateTime nowDate = DateTime.Now;
            DateTime dueDate;
            string CenterDay = "";
            int intToDay = 0, intCenterDay = 0;
            try
            {
                //Get Center Day
                switch (strCenterDay)
                {
                    case "MO":
                        CenterDay = "Monday";
                        break;
                    case "TU":
                        CenterDay = "Tuesday";
                        break;
                    case "WE":
                        CenterDay = "Wednesday";
                        break;
                    case "TH":
                        CenterDay = "Thursday";
                        break;
                    case "FR":
                        CenterDay = "Friday";
                        break;
                }
                for (int i = 1; i < 6; i++)
                {
                    if (CenterDay == strDayOfWeek[i - 1])
                    {
                        intCenterDay = i;
                    }
                    if (nowDay == strDayOfWeek[i - 1])
                    {
                        intToDay = i;
                    }
                }

                if (nowDay == CenterDay)
                {
                    dueDate = nowDate.AddDays(7);
                }
                else if (intToDay < intCenterDay)
                {
                    dueDate = nowDate.AddDays(intCenterDay - intToDay);
                }
                else
                {
                    dueDate = nowDate.AddDays(7 - (intToDay - intCenterDay));
                }
            }
            catch (Exception)
            {
                dueDate = nowDate.AddDays(7);
            }
            return dueDate;
        }

        protected void cmbChqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCNumber.Text = cmbChqNo.SelectedItem.Value;
            }
            catch (Exception)
            {
            }
        }

        protected void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankName.SelectedIndex == 0)
                {
                    txtBankName.Text = "";
                }
                else
                {
                    string strBank = cmbBankName.SelectedItem.Text;
                    txtBankName.Text = strBank;                    
                }
            }
            catch (Exception)
            {
            }
        }

        private void Bank()
        {
            try
            {
                if (cmbBankName.Items.Count > 0)
                {
                    cmbBankName.Items.Clear();
                }
                //Add Bank
                DataSet dsBank;
                MySqlCommand cmdBank = new MySqlCommand("select * from bank_tbl ORDER BY 2");
                dsBank = objDBTask.selectData(cmdBank);
                cmbBankName.Items.Add("");
                for (int i = 0; i < dsBank.Tables[0].Rows.Count; i++)
                {
                    cmbBankName.Items.Add(dsBank.Tables[0].Rows[i][1].ToString());
                    cmbBankName.Items[i + 1].Value = dsBank.Tables[0].Rows[i][0].ToString();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
