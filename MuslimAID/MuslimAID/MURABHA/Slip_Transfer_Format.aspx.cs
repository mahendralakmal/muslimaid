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
using System.IO;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace LoanSystem.Micro
{
    public partial class Slip_Transfer_Format : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    DataSet dsBranch;
                    MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                    dsBranch = objDBTask.selectData(cmdBranch);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                        cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                    }

                    //Add Bank
                    DataSet dsBank;
                    MySqlCommand cmdBank = new MySqlCommand("select * from bank_tbl ORDER BY 2");
                    dsBank = objDBTask.selectData(cmdBank);
                    cmbBank.Items.Add("");
                    for (int i = 0; i < dsBank.Tables[0].Rows.Count; i++)
                    {
                        cmbBank.Items.Add(dsBank.Tables[0].Rows[i][1].ToString());
                        cmbBank.Items[i + 1].Value = dsBank.Tables[0].Rows[i][0].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            grvCliDeta.DataSource = null;
            grvCliDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select c.nic,c.contract_code,c.initial_name,l.acc_number,b.BankName,bc.BranchName,FORMAT(l.loan_amount,2),FORMAT((l.service_charges + l.other_charges),2)Charges,FORMAT((l.loan_amount - l.service_charges - l.other_charges),2)Transfer_amount from micro_basic_detail c, micro_loan_details l, bank_tbl b, bankbranch_tbl bc where c.contract_code = l.contra_code and l.loan_approved = 'Y' and current_loan_amount is null and b.BankCode = l.bank_code and bc.BankCode = l.bank_code and bc.BranchCode = l.branch_code";
            if (txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
            {
                if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_approved_on between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_approved_on between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter To Date.";
                }
                else if (txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() != "")
                {
                    lblMsg.Text = "Please enter From Date.";
                }
            }
            else
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }


        }

        protected void loadDataToRepeater(string strQRY)
        {
            //int iCurrentPage = Convert.ToInt32(strCurrentPage);
            //COUNT ALL RECORDS
            DataSet dsAllData = objDBTask.selectData(strQRY);
            //iAllRows = dsAllData.Tables[0].Rows.Count;

            //GET RELEVANT DATA
            MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, objDBTask.establishConnection());
            DataSet dsSelectData = new DataSet();
            daData.Fill(dsSelectData);
            grvCliDeta.DataSource = dsSelectData;
            grvCliDeta.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                btnExport.Visible = true;
            }
            else
            {
                btnExport.Visible = false;
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (grvCliDeta.Rows.Count > 0)
            {
                if (lblTotal.Text.Trim() != "0.00")
                {
                    Insert();

                    //string strTransferID = Session["TransferID"].ToString();

                    //DataSet dt = objDBTask.selectData("SELECT l.chequ_amount,l.acc_name,l.acc_number,l.bank_code,l.branch_code FROM micro_loan_details l,micro_slip_transfer s where l.contra_code = s.contra_code and l.loan_approved = 'Y' and l.bank_code != '' and l.ser_char_sta = 'Y' and s.transfer_id = '" + strTransferID + "';");

                    //String fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
                    ////GridView1.DataSource = dt;
                    ////GridView1.DataBind();
                    //if (dt.Tables[0].Rows.Count > 0)
                    //{
                    //    //strServerImagePath = Server.MapPath(".") + "\\cs_client_ph";
                    //    //string path = Server.MapPath("exportedfiles\\");
                    //    string sPath = "";
                    //    try
                    //    {
                    //        string path = Server.MapPath(".") + "\\exportedfiles";

                    //        if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
                    //        {
                    //            Directory.CreateDirectory(path);
                    //        }
                    //        File.Delete(path + fileName); // DELETE THE FILE BEFORE CREATING A NEW ONE.
                    //        exportExcel(dt, fileName);

                    //        sPath = Server.MapPath(".") + "\\exportedfiles";
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        objCommonTask.createErrorLog(DateTime.Now, ex.ToString(), "File", "Test");
                    //        Console.WriteLine(ex.ToString());
                    //    }
                    //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                    //    Response.TransmitFile(sPath + "\\" + fileName);
                    //    Response.End();

                    grvCliDeta.DataSource = null;
                    grvCliDeta.DataBind();
                    lblTotal.Text = "0.00";
                    if (cmbBranch.Items.Count > 0)
                    {
                        cmbBranch.Items.Clear();
                    }

                    if (cmbAccNo.Items.Count > 0)
                    {
                        cmbAccNo.Items.Clear();
                    }
                    btnExport.Enabled = false;

                    //Session.Remove("TransferID");
                    //}
                }
                else
                {
                    lblMsg.Text = "Please select transaction...";
                }
            }
            else
            {
                lblMsg.Text = "Invalid...";
                btnExport.Visible = false;
            }
        }

        private void exportExcel(DataSet dt, string filename)
        {
            try
            {
                Excel.Application xlApp;
                Excel.Range range;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                //int j = 0;

                for (i = 0; i <= dt.Tables[0].Rows.Count - 1; i++)
                {
                    //DataGridViewCell cell = dt[j, i];
                    //Header Text
                    //xlWorkSheet.Cells[1, 1] = "";
                    //xlWorkSheet.Cells[1, 2] = "";
                    //xlWorkSheet.Cells[1, 3] = "";
                    //xlWorkSheet.Cells[1, 4] = "";
                    //xlWorkSheet.Cells[1, 5] = "";
                    //xlWorkSheet.Cells[1, 6] = "";
                    //xlWorkSheet.Cells[1, 7] = "";
                    //xlWorkSheet.Cells[1, 8] = "";
                    //xlWorkSheet.Cells[1, 9] = "";
                    //xlWorkSheet.Cells[1, 10] = "";
                    //xlWorkSheet.Cells[1, 11] = "";
                    //xlWorkSheet.Cells[1, 12] = "";
                    //xlWorkSheet.Cells[1, 13] = "";
                    //xlWorkSheet.Cells[1, 14] = "";
                    //xlWorkSheet.Cells[1, 15] = "";
                    //xlWorkSheet.Cells[1, 16] = "";
                    //xlWorkSheet.Cells[1, 17] = "";



                    xlWorkSheet.Cells[i + 1, 1] = "0000";
                    xlWorkSheet.Cells[i + 1, 2] = dt.Tables[0].Rows[i]["bank_code"].ToString();
                    xlWorkSheet.Cells[i + 1, 3] = dt.Tables[0].Rows[i]["branch_code"].ToString();
                    string strAccNo = dt.Tables[0].Rows[i]["acc_number"].ToString();
                    int intAccNoCount = strAccNo.Length;
                    if (intAccNoCount == 15)
                    {
                        strAccNo = strAccNo.Substring(3, 12);
                    }
                    else if (intAccNoCount == 14)
                    {
                        strAccNo = strAccNo.Substring(2, 12);
                    }
                    else if (intAccNoCount == 13)
                    {
                        strAccNo = strAccNo.Substring(1, 12);
                    }

                    xlWorkSheet.Cells[i + 1, 4] = strAccNo;
                    xlWorkSheet.Cells[i + 1, 5] = dt.Tables[0].Rows[i]["acc_name"].ToString();
                    xlWorkSheet.Cells[i + 1, 6] = "52";
                    xlWorkSheet.Cells[i + 1, 7] = "000000000";

                    decimal decLAmount = Convert.ToDecimal(dt.Tables[0].Rows[i]["chequ_amount"].ToString());
                    var Balance = decLAmount.ToString(CultureInfo.InvariantCulture).Split('.');
                    int FirstValue = int.Parse(Balance[0]);
                    int ScondValue = int.Parse(Balance[1]);
                    string strFirstValue = Convert.ToString(FirstValue);
                    string strSecondValue = "00";
                    if (ScondValue != 0)
                    {
                        strSecondValue = Convert.ToString(ScondValue);
                    }
                    string strFullValue = strFirstValue + strSecondValue;

                    xlWorkSheet.Cells[i + 1, 8] = strFullValue;
                    xlWorkSheet.Cells[i + 1, 9] = "SLR";
                    xlWorkSheet.Cells[i + 1, 10] = cmbBank.SelectedItem.Value; ;
                    xlWorkSheet.Cells[i + 1, 11] = cmbBranch.SelectedItem.Value;
                    xlWorkSheet.Cells[i + 1, 12] = cmbAccNo.SelectedItem.Value;
                    xlWorkSheet.Cells[i + 1, 13] = "M/S PROSPEROUS CAPITAL & Assurance (Pvt) Ltd";
                    xlWorkSheet.Cells[i + 1, 14] = "LOAN";
                    xlWorkSheet.Cells[i + 1, 15] = DateTime.Now.ToString("MMMM");
                    xlWorkSheet.Cells[i + 1, 16] = "150925";
                    xlWorkSheet.Cells[i + 1, 17] = "000000";

                    range = xlWorkSheet.Cells[i + 1, 1] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.NumberFormat = "0000";
                    range.ColumnWidth = 4;

                    range = xlWorkSheet.Cells[i + 1, 2] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 4;

                    range = xlWorkSheet.Cells[i + 1, 3] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 3;

                    range = xlWorkSheet.Cells[i + 1, 4] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.NumberFormat = "000000000000";
                    range.ColumnWidth = 12;

                    range = xlWorkSheet.Cells[i + 1, 5] as Excel.Range;
                    range.Font.Name = "Times New Roman"; ;
                    range.ColumnWidth = 20;

                    range = xlWorkSheet.Cells[i + 1, 6] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 2;

                    range = xlWorkSheet.Cells[i + 1, 7] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.NumberFormat = "000000000";
                    range.ColumnWidth = 9;

                    range = xlWorkSheet.Cells[i + 1, 8] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.NumberFormat = "000000000000";
                    range.ColumnWidth = 12;

                    range = xlWorkSheet.Cells[i + 1, 9] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 3;

                    range = xlWorkSheet.Cells[i + 1, 10] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 4;

                    range = xlWorkSheet.Cells[i + 1, 11] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.NumberFormat = "000";
                    range.ColumnWidth = 3;

                    range = xlWorkSheet.Cells[i + 1, 12] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.NumberFormat = "000000000000";
                    range.ColumnWidth = 12;

                    range = xlWorkSheet.Cells[i + 1, 13] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 20;

                    range = xlWorkSheet.Cells[i + 1, 14] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 15;

                    range = xlWorkSheet.Cells[i + 1, 15] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 15;

                    range = xlWorkSheet.Cells[i + 1, 16] as Excel.Range;
                    range.Font.Name = "Times New Roman";
                    range.ColumnWidth = 6;

                    range = xlWorkSheet.Cells[i + 1, 17] as Excel.Range;
                    //Color bgColor = dt.Rows[i][j].Style.BackColor;
                    range.Font.Name = "Times New Roman";
                    range.NumberFormat = "000000";
                    range.ColumnWidth = 6;

                }



                // SAVE THE FILE IN A FOLDER.
                string path = Server.MapPath(".") + "\\exportedfiles";
                //string path = Server.MapPath("exportedfiles\\");
                xlWorkBook.SaveAs(path + "\\" + filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                //xlWorkSheetToExport.SaveAs(path + "EmployeeDetails.xlsx");
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception ex)
            {
                objCommonTask.createErrorLog(DateTime.Now, ex.ToString(), "File", "Test");
                Console.WriteLine(ex.ToString());
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        protected void lnkTPayment_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblTotal.Text = "";
            decimal decX = 0;
            foreach (GridViewRow grows in grvCliDeta.Rows)
            { 
                CheckBox chkSele = grows.FindControl("chkvalue") as CheckBox;
                int id = grows.RowIndex;
                if (chkSele.Checked)
                {
                    string strLA = grvCliDeta.Rows[id].Cells[9].Text;
                    decimal decLA = Convert.ToDecimal(strLA);

                    decX = decX + decLA;

                    //string strX = Convert.ToString(decX);
                    lblTotal.Text = decX.ToString("#,##0.00");
                }
                else
                {
                    //lblMsg.Text = "Please select items";
                }
            }
        }

        protected void chkdele(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblTotal.Text = "";
            decimal decX = 0;
            foreach (GridViewRow grows in grvCliDeta.Rows)
            {
                CheckBox chkSele = grows.FindControl("chkvalue") as CheckBox;
                int id = grows.RowIndex;
                if (chkSele.Checked)
                {
                    string strLA = grvCliDeta.Rows[id].Cells[9].Text;
                    decimal decLA = Convert.ToDecimal(strLA);

                    decX = decX + decLA;

                    //string strX = Convert.ToString(decX);
                    lblTotal.Text = decX.ToString("#,##0.00");
                }
                else
                {
                    //lblMsg.Text = "Please select items";
                }
            }
        }

        protected void Insert()
        {
            //Get Max ID
            string strNewTransferID = "1";
            int inTransferID = 1;
            DataSet dsGetMaxID = objDBTask.selectData("select max(transfer_id) from micro_slip_transfer;");
            if (dsGetMaxID.Tables[0].Rows[0][0].ToString() != "")
            {
                string strTransferID = dsGetMaxID.Tables[0].Rows[0][0].ToString();
                inTransferID = Convert.ToInt32(strTransferID) + 1;
                strNewTransferID = Convert.ToString(inTransferID);
            }

            //Session["TransferID"] = strNewTransferID.ToString();

            string strloginID = Session["NIC"].ToString();
            string strIp = Request.UserHostAddress;

            foreach (GridViewRow grows in grvCliDeta.Rows)
            { 
                CheckBox chkSele = grows.FindControl("chkvalue") as CheckBox;
                int id = grows.RowIndex;
                if (chkSele.Checked)
                {
                    string strCC = grvCliDeta.Rows[id].Cells[1].Text;
                    string strDate = DateTime.Now.ToString("yyyy-MM-dd");

                    //Submit Loan Table----------------------------------------------------------------------------------
                    string strOCha, strIAmou, strPeriod, strBranchCode, strSCharges, strCA;

                    DataSet dsLDOCha = objDBTask.selectData("select l.loan_amount,l.service_charges,l.other_charges,l.interest_amount,l.period,b.city_code from micro_loan_details l, micro_basic_detail b where b.contract_code = l.contra_code and l.contra_code = '" + strCC + "';");

                    strCA = dsLDOCha.Tables[0].Rows[0]["loan_amount"].ToString();
                    strSCharges = dsLDOCha.Tables[0].Rows[0]["service_charges"].ToString();
                    strOCha = dsLDOCha.Tables[0].Rows[0]["other_charges"].ToString();
                    strIAmou = dsLDOCha.Tables[0].Rows[0]["interest_amount"].ToString();
                    strPeriod = dsLDOCha.Tables[0].Rows[0]["period"].ToString();
                    strBranchCode = dsLDOCha.Tables[0].Rows[0]["city_code"].ToString();

                    decimal decSCharges = Convert.ToDecimal(strSCharges);
                    decimal decOCha = Convert.ToDecimal(strOCha);
                    decimal decIAmo = Convert.ToDecimal(strIAmou);
                    decimal decLA = Convert.ToDecimal(strCA);

                    decimal decTotal = decSCharges + decOCha;
                    int intTotal = Convert.ToInt32(decTotal);
                    string strTotalAmount = Convert.ToString(decTotal);
                    string strTotalText = NumberToText(intTotal, true, false);

                    int intPeriod = Convert.ToInt32(strPeriod) * 7;

                    decimal decPayedAmou = decIAmo + decLA;
                    string strPayAmount = Convert.ToString(decPayedAmou);

                    decimal decCQAmount = decLA - decSCharges - decOCha;
                    string strCQAmount = Convert.ToString(decCQAmount);

                    DateTime now = DateTime.Now;
                    DateTime due = now.AddDays(7);

                    DateTime dtMatuDate = now.AddDays(intPeriod);
                    string strMatuDate = dtMatuDate.ToString("yyyy-MM-dd");

                    string strDue = due.ToString("yyyy-MM-dd");

                    MySqlCommand cmdUpdateChequ = new MySqlCommand("Update micro_loan_details set current_loan_amount = '" + strPayAmount + "',chequ_no = '" + strNewTransferID + "',chequ_amount = '" + strCQAmount + "',chequ_deta_on = '" + strDate + "',cheq_detai_app_nic = '" + strloginID + "',due_date = '" + strDue + "',ser_char_sta = 'Y',maturity_date = '" + strMatuDate + "' where contra_code = '" + strCC + "';");
                    try
                    {
                        int i;
                        i = objDBTask.insertEditData(cmdUpdateChequ);
                        if (i == 1)
                        {
                            //Service Charges 
                            MySqlCommand cmdInsertDocu = new MySqlCommand("INSERT INTO micro_service_charges(contract_code,document_amount,insurance_amount,city_code,user_nic,user_ip,date_time,total_amount_text,total_amount)VALUES(@contract_code,@document_amount,@insurance_amount,@city_code,@user_nic,@user_ip,@date_time,@total_amount_text,@total_amount);");

                            #region Assign Parameters
                            cmdInsertDocu.Parameters.Add("@contract_code", MySqlDbType.VarChar, 13);
                            cmdInsertDocu.Parameters.Add("@document_amount", MySqlDbType.Decimal, 10);
                            cmdInsertDocu.Parameters.Add("@insurance_amount", MySqlDbType.Decimal, 10);
                            cmdInsertDocu.Parameters.Add("@city_code", MySqlDbType.VarChar, 4);
                            cmdInsertDocu.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
                            cmdInsertDocu.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                            cmdInsertDocu.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                            cmdInsertDocu.Parameters.Add("@total_amount_text", MySqlDbType.VarChar, 255);
                            cmdInsertDocu.Parameters.Add("@total_amount", MySqlDbType.Decimal, 10);
                            #endregion

                            #region DEclare Parametes
                            cmdInsertDocu.Parameters["@contract_code"].Value = strCC;
                            cmdInsertDocu.Parameters["@document_amount"].Value = strSCharges;
                            cmdInsertDocu.Parameters["@insurance_amount"].Value = strOCha;
                            cmdInsertDocu.Parameters["@city_code"].Value = strBranchCode;
                            cmdInsertDocu.Parameters["@user_nic"].Value = strloginID;
                            cmdInsertDocu.Parameters["@user_ip"].Value = strIp;
                            cmdInsertDocu.Parameters["@date_time"].Value = strDate;
                            cmdInsertDocu.Parameters["@total_amount_text"].Value = strTotalText;
                            cmdInsertDocu.Parameters["@total_amount"].Value = strTotalAmount;
                            #endregion

                            int b;
                            b = objDBTask.insertEditData(cmdInsertDocu);

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
                                }
                                catch (Exception ex)
                                {
                                }
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

                    //----------------------------------------------------------------------------------------------
                    MySqlCommand cmdInsertMonthPaym = new MySqlCommand("INSERT INTO micro_slip_transfer(contra_code,date_time,user_loagging,ip,transfer_id,bank_code,branch_code,acc_no)VALUES(@contra_code,@date_time,@user_loagging,@ip,@transfer_id,@bank_code,@branch_code,@acc_no);");

                    #region Assign Parameters
                    cmdInsertMonthPaym.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
                    cmdInsertMonthPaym.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                    cmdInsertMonthPaym.Parameters.Add("@user_loagging", MySqlDbType.VarChar, 10);
                    cmdInsertMonthPaym.Parameters.Add("@ip", MySqlDbType.VarChar, 45);
                    cmdInsertMonthPaym.Parameters.Add("@transfer_id", MySqlDbType.Int32);
                    cmdInsertMonthPaym.Parameters.Add("@bank_code", MySqlDbType.VarChar, 4);
                    cmdInsertMonthPaym.Parameters.Add("@branch_code", MySqlDbType.VarChar, 3);
                    cmdInsertMonthPaym.Parameters.Add("@acc_no", MySqlDbType.VarChar, 20);
                    #endregion
                    
                    #region DEclare Parametes
                    cmdInsertMonthPaym.Parameters["@contra_code"].Value = strCC;
                    cmdInsertMonthPaym.Parameters["@date_time"].Value = strDate;
                    cmdInsertMonthPaym.Parameters["@user_loagging"].Value = strloginID;
                    cmdInsertMonthPaym.Parameters["@ip"].Value = strIp;
                    cmdInsertMonthPaym.Parameters["@transfer_id"].Value = strNewTransferID;
                    cmdInsertMonthPaym.Parameters["@bank_code"].Value = cmbBank.SelectedItem.Value;
                    cmdInsertMonthPaym.Parameters["@branch_code"].Value = cmbBranch.SelectedItem.Value;
                    cmdInsertMonthPaym.Parameters["@acc_no"].Value = cmbAccNo.SelectedItem.Value;
                    #endregion

                    try
                    {
                        int f;
                        f = objDBTask.insertEditData(cmdInsertMonthPaym);

                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    //lblMsg.Text = "Please select items";
                }
            }

            MySqlCommand cmdInsertTransferID = new MySqlCommand("INSERT INTO micro_slip_transfer_id(transfer_id,date_time)VALUES(@transfer_id,@date_time);");

            #region Assign Parameters
            cmdInsertTransferID.Parameters.Add("@transfer_id", MySqlDbType.VarChar, 10);
            cmdInsertTransferID.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
            #endregion

            #region DEclare Parametes
            cmdInsertTransferID.Parameters["@transfer_id"].Value = strNewTransferID;
            cmdInsertTransferID.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            #endregion

            int a;
            a = objDBTask.insertEditData(cmdInsertTransferID);

        }

        public static string NumberToText(int number, bool useAnd, bool useArab)
        {
            if (number == 0) return "Zero";

            string and = useAnd ? "and " : ""; // deals with using 'and' separator

            if (number == -2147483648) return "Minus Two Hundred " + and + "Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred " + and + "Forty Eight";

            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "ONE ", "TWO ", "THREE ", "FOUR ", "FIVE ", "SIX ", "SEVEN ", "EIGHT ", "NINE " };
            string[] words1 = { "TEN ", "ELEVEN ", "TWELVE ", "THIRTEEN ", "FOURTEEN ", "FIFTEEN ", "SIXTEEN ", "SEVENTEEN ", "EIGHTEEN ", "NINETEEN " };
            string[] words2 = { "TWENTY ", "THIRTY ", "FOURTY ", "FIFTY ", "SIXTY ", "SEVENTY ", "EIGHTY", "NINETY " };
            string[] words3 = { "THOUSAND ", "LAKH ", "CRORE " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }

            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;

                u = num[i] % 10; // ones 
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens

                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);

                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }

            string temp = sb.ToString().TrimEnd();

            if (useArab && Math.Abs(number) >= 1000000000)
            {
                int index = temp.IndexOf("Hundred Crore");
                if (index > -1) return temp.Substring(0, index) + "Arab" + temp.Substring(index + 13);
                index = temp.IndexOf("Hundred");
                return temp.Substring(0, index) + "Arab" + temp.Substring(index + 7);
            }
            return temp;
        }

        protected void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBranch.Items.Count > 0)
            {
                cmbBranch.Items.Clear();
            }

            if (cmbAccNo.Items.Count > 0)
            {
                cmbAccNo.Items.Clear();
            }

            if (cmbBank.SelectedIndex == 0)
            {
                btnExport.Enabled = false;
            }
            else
            {
                string strBank = cmbBank.SelectedItem.Value;
                //txtBankCode.Text = strBank;
                DataSet dsGetBranch = objDBTask.selectData("select * from bankbranch_tbl where BankCode = '" + strBank + "' ORDER BY 2;");
                cmbBranch.Items.Add("");
                for (int i = 0; i < dsGetBranch.Tables[0].Rows.Count; i++)
                {
                    cmbBranch.Items.Add(dsGetBranch.Tables[0].Rows[i][2].ToString());
                    cmbBranch.Items[i + 1].Value = dsGetBranch.Tables[0].Rows[i][1].ToString();
                }
            }
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccNo.Items.Count > 0)
            {
                cmbAccNo.Items.Clear();
            }

            if (cmbBranch.SelectedIndex == 0 || cmbBank.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select bank & Branch.";
                btnExport.Enabled = false;
            }
            else
            {
                string strBranch = cmbBranch.SelectedItem.Value;
                string strBank = cmbBank.SelectedItem.Value;
                DataSet dsGetBranch = objDBTask.selectData("select * from bank_acc_no where bank_code = '" + strBank + "' and branch_code = '" + strBranch + "' ORDER BY 2;");
                cmbAccNo.Items.Add("");
                for (int i = 0; i < dsGetBranch.Tables[0].Rows.Count; i++)
                {
                    cmbAccNo.Items.Add(dsGetBranch.Tables[0].Rows[i][3].ToString());
                    cmbAccNo.Items[i + 1].Value = dsGetBranch.Tables[0].Rows[i][3].ToString();
                }

                btnExport.Enabled = true;
            }
        }
    }
}
