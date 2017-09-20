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
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace MuslimAID.MURABAHA
{
    public partial class Bulk_Payment : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    string strType = Session["UserType"].ToString();
                    if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG" ||
                        strType == "FAO" || strType == "RFA" || strType == "BFA")
                    {
                        DataSet dsCity;
                        MySqlCommand cmdCity = new MySqlCommand("SELECT b_code,b_name FROM branch ORDER BY 2");
                        dsCity = objDBTask.selectData(cmdCity);
                        cmbCityCode.Items.Add("");
                        for (int i = 0; i < dsCity.Tables[0].Rows.Count; i++)
                        {
                            cmbCityCode.Items.Add("[" + dsCity.Tables[0].Rows[i]["b_code"] + "] - " + dsCity.Tables[0].Rows[i]["b_name"].ToString());
                            cmbCityCode.Items[i + 1].Value = dsCity.Tables[0].Rows[i]["b_code"].ToString();
                        }
                    }
                    else
                    {
                        Response.Redirect("murabha.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            grvPayment.DataSource = null;
            grvPayment.DataBind();
            if (cmbCityCode.SelectedIndex == 0)
                lblMsg2.Text = "Please select Branch";
            else
                GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex != 0)
            {
                string strCityCode = cmbCityCode.SelectedValue;
                string strArea = cmbArea.SelectedValue;
                string strVillage = cmbVillage.SelectedValue;
                string strSocietyID = cmbSocietyID.SelectedValue;

                lblMsg.Text = "";
                

                hstrSelectQuery.Value = "";

                hstrSelectQuery.Value = "select b.contract_code,b.ca_code,b.nic,b.initial_name,l.monthly_instollment,l.current_loan_amount from micro_basic_detail b,micro_loan_details l where b.city_code = '" + strCityCode;
                if(cmbArea.SelectedIndex > 0)
                    hstrSelectQuery.Value += "' and b.area_code = '" + strArea;
                else if(cmbVillage.SelectedIndex > 0)
                    hstrSelectQuery.Value += "' and b.village = '" + strVillage;
                else if (cmbSocietyID.SelectedIndex > 0)
                    hstrSelectQuery.Value += "' and b.society_id = '" + strSocietyID;
                else { }
                hstrSelectQuery.Value += "' and b.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P'";
                hstrSelectQuery.Value += "or b.city_code = '" + strCityCode;
                if (cmbArea.SelectedIndex > 0)
                    hstrSelectQuery.Value += "' and b.area_code = '" + strArea;
                else if (cmbVillage.SelectedIndex > 0)
                    hstrSelectQuery.Value += "' and b.village = '" + strVillage;
                else if (cmbSocietyID.SelectedIndex > 0)
                    hstrSelectQuery.Value += "' and b.society_id = '" + strSocietyID;
                else { }
                hstrSelectQuery.Value += "' and b.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'E' order by b.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);

            }
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            grvPayment.DataSource = null;
            grvPayment.DataBind();
            lblTotalPaied.Text = "";
            pnlPayment.Visible = false;
            cmbArea.Items.Clear();
            cmbVillage.Items.Clear();
            cmbSocietyID.Items.Clear();

            if (cmbArea.Items.Count > 0)
            {
                cmbArea.Items.Clear();
            }

            if (cmbVillage.Items.Count > 0)
            {
                cmbVillage.Items.Clear();
            }

            try
            {
                DataSet dsVillage = cls_Connection.getDataSet("select * from area where branch_code = '" + cmbCityCode.SelectedItem.Value + "' ORDER BY area");
                if (dsVillage.Tables[0].Rows.Count > 0)
                {
                    cmbArea.Items.Add("Select Area");
                    //btnSubmit.Enabled = true;

                    for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                    {
                        cmbArea.Items.Add(dsVillage.Tables[0].Rows[i][1].ToString());
                        cmbArea.Items[i + 1].Value = dsVillage.Tables[0].Rows[i][2].ToString();
                    }
                    cmbArea.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "No record found...! Please chose other city code.";
                    // btnSubmit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void loadDataToRepeater(string strQRY)
        {
            //int iCurrentPage = Convert.ToInt32(strCurrentPage);
            //COUNT ALL RECORDS
            DataSet dsAllData = cls_Connection.getDataSet(strQRY);
            //iAllRows = dsAllData.Tables[0].Rows.Count;

            //GET RELEVANT DATA
            MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, cls_Connection.DBConnect());
            DataSet dsSelectData = new DataSet();
            daData.Fill(dsSelectData);
            grvPayment.DataSource = dsSelectData;
            grvPayment.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlPayment.Visible = true;
            }
            else
            {
                pnlPayment.Visible = false;
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void lnkTPayment_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblTotalPaied.Text = "";
            decimal decX = 0;
            foreach (GridViewRow grows in grvPayment.Rows)
            {
                TextBox txtPayment = grows.FindControl("txtPaidAmount") as TextBox;
                int id = grows.RowIndex;
                if (txtPayment.Text.Trim() != "")
                {
                    string strPayment = txtPayment.Text.Trim();
                    decimal decPayment = Convert.ToDecimal(strPayment);

                    decX = decX + decPayment;
                    
                }
            }

            lblTotalPaied.Text = decX.ToString("#,##0.00");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //IRRPayment();
            //IRRPaymentNew();
            EqualPayment();
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

        ////Edit 2016-05-24 IRRPayment
        //protected void IRRPayment()
        //{
        //    lblMsg.Text = "";
        //    foreach (GridViewRow grows in grvPayment.Rows)
        //    {
        //        TextBox txtPayment = grows.FindControl("txtPaidAmount") as TextBox;
        //        int id = grows.RowIndex;
        //        if (txtPayment.Text.Trim() != "")
        //        {
        //            string strPayment = txtPayment.Text.Trim();
        //            string strloginID = Session["NIC"].ToString();
        //            string strCCode = grvPayment.Rows[id].Cells[0].Text;
        //            string strNIC = grvPayment.Rows[id].Cells[2].Text;
        //            string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            string strIp = Request.UserHostAddress;
        //            string strPayType = "Cash";
        //            string strChqNo = "";
        //            string strBank = "";

        //            MySqlCommand cmdInsertMonthPaym = new MySqlCommand("INSERT INTO micro_pais_history(contra_code,NIC,paied_amount,date_time,user_nic,user_ip,tra_description,pay_status,reson,payment_type,chq_No,chq_bank)VALUES(@contra_code,@NIC,@paied_amount,@date_time,@user_nic,@user_ip,@tra_description,@pay_status,@reson,@payment_type,@chq_No,@chq_bank);");

        //            #region Assign Parameters
        //            cmdInsertMonthPaym.Parameters.Add("@contra_code", MySqlDbType.VarChar, 13);
        //            cmdInsertMonthPaym.Parameters.Add("@NIC", MySqlDbType.VarChar, 15);
        //            cmdInsertMonthPaym.Parameters.Add("@paied_amount", MySqlDbType.Decimal, 9);
        //            cmdInsertMonthPaym.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
        //            cmdInsertMonthPaym.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
        //            cmdInsertMonthPaym.Parameters.Add("@user_ip", MySqlDbType.VarChar, 20);
        //            cmdInsertMonthPaym.Parameters.Add("@tra_description", MySqlDbType.VarChar, 3);
        //            cmdInsertMonthPaym.Parameters.Add("@pay_status", MySqlDbType.VarChar, 1);
        //            cmdInsertMonthPaym.Parameters.Add("@reson", MySqlDbType.VarChar, 45);
        //            cmdInsertMonthPaym.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
        //            cmdInsertMonthPaym.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
        //            cmdInsertMonthPaym.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
        //            #endregion

        //            #region Declare Parametes
        //            cmdInsertMonthPaym.Parameters["@contra_code"].Value = strCCode;
        //            cmdInsertMonthPaym.Parameters["@NIC"].Value = strNIC;
        //            cmdInsertMonthPaym.Parameters["@paied_amount"].Value = strPayment;
        //            cmdInsertMonthPaym.Parameters["@date_time"].Value = strDate;
        //            cmdInsertMonthPaym.Parameters["@user_nic"].Value = strloginID;
        //            cmdInsertMonthPaym.Parameters["@user_ip"].Value = strIp;
        //            cmdInsertMonthPaym.Parameters["@tra_description"].Value = "WI";
        //            cmdInsertMonthPaym.Parameters["@pay_status"].Value = "D";
        //            cmdInsertMonthPaym.Parameters["@reson"].Value = "";
        //            cmdInsertMonthPaym.Parameters["@payment_type"].Value = strPayType;
        //            cmdInsertMonthPaym.Parameters["@chq_No"].Value = strChqNo;
        //            cmdInsertMonthPaym.Parameters["@chq_bank"].Value = strBank;
        //            #endregion

        //            try
        //            {
        //                int f;
        //                f = objDBTask.insertEditData(cmdInsertMonthPaym);
        //                if (f == 1)
        //                {
        //                    lblMsg.Text = "Payment is Succsessfuled.";
        //                }
        //                else
        //                {
        //                    lblMsg.Text = "Error Occured!";
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //            }

        //            //Get Recipt Number
        //            string strRNum;
        //            DataSet dsGetReciNum = objDBTask.selectData("select max(idpais_history) from micro_pais_history where contra_code = '" + strCCode + "' and date_time = '" + strDate + "';");
        //            strRNum = dsGetReciNum.Tables[0].Rows[0][0].ToString();

        //            decimal decPayment = Convert.ToDecimal(strPayment);

        //            DataSet dsCheckArre = objDBTask.selectData("select current_loan_amount,interest_amount,period,monthly_instollment,chequ_deta_on,due_date,arres_amou,def,due_installment,loan_amount from micro_loan_details where contra_code = '" + strCCode + "';");
        //            if (dsCheckArre.Tables[0].Rows.Count != 0)
        //            {
        //                string strCuLoanAmount = dsCheckArre.Tables[0].Rows[0]["current_loan_amount"].ToString();
        //                string strIAmount = dsCheckArre.Tables[0].Rows[0]["interest_amount"].ToString();
        //                string strPeriod = dsCheckArre.Tables[0].Rows[0]["period"].ToString();
        //                string strWI = dsCheckArre.Tables[0].Rows[0]["monthly_instollment"].ToString();
        //                string strChequDate = dsCheckArre.Tables[0].Rows[0]["chequ_deta_on"].ToString();
        //                string strDueDate = dsCheckArre.Tables[0].Rows[0]["due_date"].ToString();
        //                string strArreas = dsCheckArre.Tables[0].Rows[0]["arres_amou"].ToString();
        //                string strDefult = dsCheckArre.Tables[0].Rows[0]["def"].ToString();
        //                string strDueInstallment = dsCheckArre.Tables[0].Rows[0]["due_installment"].ToString();
        //                string strLoanAmount = dsCheckArre.Tables[0].Rows[0]["loan_amount"].ToString();

        //                decimal decCurrentLAmont = Convert.ToDecimal(strCuLoanAmount);
        //                decimal decDefult = Convert.ToDecimal(strDefult);
        //                decimal decPayMinDefa = decPayment - decDefult;
        //                string strPayMinDefa = Convert.ToString(decPayMinDefa);
        //                decimal decWI = Convert.ToDecimal(strWI);
        //                decimal decArreas = Convert.ToDecimal(strArreas);
        //                decimal decArreasCount = (decArreas - decPayment) / decWI;
        //                int intArreasCount = Convert.ToInt32(decArreasCount);
        //                string strArreasCount = intArreasCount.ToString();
        //                decimal decArreMinDefa = decArreas - decDefult;
        //                string strArreMinDefa = Convert.ToString(decArreMinDefa);
        //                //decimal decNowDueAmount = decWI + decArreas;
        //                decimal decOverPayment = decPayment - decArreas;
        //                string strOverPayment = Convert.ToString(decOverPayment);

        //                decimal decIAmount = Convert.ToDecimal(strIAmount);
        //                decimal decPeriod = Convert.ToDecimal(strPeriod);
        //                decimal decDInstallment = Convert.ToDecimal(strDueInstallment);
        //                decimal decLoanAmount = Convert.ToDecimal(strLoanAmount);
        //                //New Edit IRR
        //                //Get Total Due & Due Capital, Interest
        //                decimal decToalDue = 0;
        //                decimal decDueCapital = 0;
        //                decimal decDueInterest = 0;
        //                DataSet dsGetTotalDue = objDBTask.selectData("select ifnull(sum(amount),0),ifnull(sum(capital),0),ifnull(sum(interest),0) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'DB' and p_status = 'D'; ");
        //                if (dsGetTotalDue.Tables[0].Rows[0][0].ToString() != "")
        //                {
        //                    string strTotalDue = dsGetTotalDue.Tables[0].Rows[0][0].ToString();
        //                    decToalDue = Convert.ToDecimal(strTotalDue);
        //                    string strDueCapital = dsGetTotalDue.Tables[0].Rows[0][1].ToString();
        //                    decDueCapital = Convert.ToDecimal(strDueCapital);
        //                    string strDueInterest = dsGetTotalDue.Tables[0].Rows[0][2].ToString();
        //                    decDueInterest = Convert.ToDecimal(strDueInterest);
        //                }

        //                decimal decToalCollected = 0;
        //                decimal decCollectedCapital = 0;
        //                decimal decCollectedInterest = 0;
        //                DataSet dsGetTotalCollected = objDBTask.selectData("select sum(amount),sum(capital),sum(interest) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI' and p_status = 'D';");
        //                if (dsGetTotalCollected.Tables[0].Rows[0][0].ToString() != "")
        //                {
        //                    string strTotalCollected = dsGetTotalCollected.Tables[0].Rows[0][0].ToString();
        //                    decToalCollected = Convert.ToDecimal(strTotalCollected);
        //                    string strCollectedCapital = dsGetTotalCollected.Tables[0].Rows[0][1].ToString();
        //                    decCollectedCapital = Convert.ToDecimal(strCollectedCapital);
        //                    string strCollectedInterest = dsGetTotalCollected.Tables[0].Rows[0][2].ToString();
        //                    decCollectedInterest = Convert.ToDecimal(strCollectedInterest);
        //                }

        //                decimal decArreasCapital = decDueCapital - decCollectedCapital;
        //                decimal decArreasInterest = decDueInterest - decCollectedInterest;
                        
        //                string strDef = "0";

        //                //Chk Ladger Balance
        //                string strCurBalance;
        //                decimal decCurBalance = 0;
        //                DataSet dsGetDebit = objDBTask.selectData("select curr_balance from micro_payme_summery where contra_code = '" + strCCode + "' order by idcons_payme_summery desc limit 1;");
        //                if (dsGetDebit.Tables[0].Rows.Count > 0)
        //                {
        //                    strCurBalance = dsGetDebit.Tables[0].Rows[0]["curr_balance"].ToString();
        //                    decCurBalance = Convert.ToDecimal(strCurBalance);
        //                }

        //                decimal decPHCuBalance = decCurBalance - decPayment;
        //                string strPHCuBalance = Convert.ToString(decPHCuBalance);

        //                if (decArreas > 0)
        //                {
        //                    if (decPayment >= decArreas)
        //                    {
        //                        if (decArreas == decPayment)
        //                        {
        //                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = '" + strDef + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
        //                            int i;
        //                            i = objDBTask.insertEditData(cmdUpdateLoanAmou);
        //                        }
        //                        else
        //                        {
        //                            if (decCurrentLAmont >= decPayment)
        //                            {
        //                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = over_payment + '" + strOverPayment + "',arres_count = '" + strDef + "',loan_sta = 'S' where contra_code = '" + strCCode + "';");
        //                                int i;
        //                                i = objDBTask.insertEditData(cmdUpdateLoanAmou);
        //                            }
        //                            else
        //                            {
        //                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = over_payment + '" + strOverPayment + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
        //                                int i;
        //                                i = objDBTask.insertEditData(cmdUpdateLoanAmou);
        //                            }
        //                        }

        //                        //add payment summery
        //                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

        //                        #region Assign Parameters
        //                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
        //                        cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
        //                        cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
        //                        cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
        //                        cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
        //                        cmdInsertPaySumm.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
        //                        cmdInsertPaySumm.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
        //                        cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
        //                        #endregion

        //                        #region DEclare Parametes
        //                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
        //                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
        //                        cmdInsertPaySumm.Parameters["@amount"].Value = strPayment;
        //                        cmdInsertPaySumm.Parameters["@capital"].Value = decArreasCapital.ToString();
        //                        cmdInsertPaySumm.Parameters["@interest"].Value = decArreasInterest.ToString();
        //                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
        //                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
        //                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
        //                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
        //                        cmdInsertPaySumm.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
        //                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
        //                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
        //                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = decPHCuBalance;
        //                        #endregion

        //                        int w;
        //                        w = objDBTask.insertEditData(cmdInsertPaySumm);

        //                    }
        //                    else
        //                    { 
        //                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = arres_amou - '" + strPayment + "',def = '" + strDef + "',over_payment = '" + strDef + "',arres_count = '" + strArreasCount + "' where contra_code = '" + strCCode + "';");
        //                        int i;
        //                        i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                

        //                        if (decArreasInterest > 0 && decArreasInterest >= decPayment)
        //                        {
        //                            //add payment summery
        //                            MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

        //                            #region Assign Parameters
        //                            cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
        //                            cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
        //                            cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
        //                            #endregion

        //                            #region DEclare Parametes
        //                            cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
        //                            cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
        //                            cmdInsertPaySumm.Parameters["@amount"].Value = strPayment;
        //                            cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@interest"].Value = strPayment;
        //                            cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
        //                            cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
        //                            cmdInsertPaySumm.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                            cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
        //                            cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
        //                            cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
        //                            cmdInsertPaySumm.Parameters["@curr_balance"].Value = decPHCuBalance;
        //                            #endregion

        //                            int w;
        //                            w = objDBTask.insertEditData(cmdInsertPaySumm);
        //                        }
        //                        else if (decArreasInterest < decPayment && decArreas > decPayment)
        //                        {
        //                            //Get Capital
        //                            decimal decPaidCapital = decPayment - decArreasInterest;
        //                            //add payment summery
        //                            MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

        //                            #region Assign Parameters
        //                            cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
        //                            cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
        //                            cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
        //                            #endregion

        //                            #region DEclare Parametes
        //                            cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
        //                            cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
        //                            cmdInsertPaySumm.Parameters["@amount"].Value = strPayment;
        //                            cmdInsertPaySumm.Parameters["@capital"].Value = decPaidCapital.ToString();
        //                            cmdInsertPaySumm.Parameters["@interest"].Value = decArreasInterest.ToString();
        //                            cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
        //                            cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
        //                            cmdInsertPaySumm.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                            cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
        //                            cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
        //                            cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
        //                            cmdInsertPaySumm.Parameters["@curr_balance"].Value = decPHCuBalance;
        //                            #endregion

        //                            int w;
        //                            w = objDBTask.insertEditData(cmdInsertPaySumm);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (strDueInstallment == "0")
        //                    {
        //                        double dbLA = Convert.ToDouble(strLoanAmount);
        //                        double dbWI = Convert.ToDouble(strWI);
        //                        int intPeriod = Convert.ToInt32(strPeriod);
        //                        decimal decDueOneIA = 0;
        //                        decimal decDueOneCapital = 0;
        //                        string strDueInte = "0";
        //                        string strDueCapita = "0";
        //                        //IRR
        //                        int x = intPeriod;
        //                        double[] tmpCashflows = new double[x + 1];

        //                        tmpCashflows[0] = (-1) * dbLA;

        //                        for (int ii = 1; ii < intPeriod + 1; ii++)
        //                        {
        //                            tmpCashflows[ii] = dbWI;
        //                        }

        //                        decimal irr = 0;
        //                        try
        //                        {
        //                            double Guess = 0.00;
        //                            double tmpIrr = Financial.IRR(ref tmpCashflows, Guess);
        //                            irr = Convert.ToDecimal(tmpIrr * 100.00) * intPeriod;
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            irr = 0;
        //                        }

        //                        decDueOneIA = decLoanAmount * ((irr / 100) / decPeriod);
        //                        decDueOneCapital = decWI - decDueOneIA;

        //                        strDueCapita = decDueOneCapital.ToString();
        //                        strDueInte = decDueOneIA.ToString();

        //                        if (decWI >= decPayment && decCurBalance >= decPayment)
        //                        {
        //                            decimal decOP = decPayment - decWI;
        //                            string strOP = decOP.ToString();
        //                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = over_payment + '" + strOP + "',arres_count = '" + strDef + "',loan_sta = 'S' where contra_code = '" + strCCode + "';");
        //                            int i;
        //                            i = objDBTask.insertEditData(cmdUpdateLoanAmou);
        //                        }
        //                        else if (decWI >= decPayment && decCurBalance < decPayment)
        //                        {
        //                            decimal decOP = decPayment - decWI;
        //                            string strOP = decOP.ToString();
        //                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = over_payment + '" + strOP + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
        //                            int i;
        //                            i = objDBTask.insertEditData(cmdUpdateLoanAmou);
        //                        }
        //                        else
        //                        {
        //                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
        //                            int i;
        //                            i = objDBTask.insertEditData(cmdUpdateLoanAmou);
        //                        }

        //                        if (decWI > decPayment && decDueOneIA == decPayment)
        //                        {
        //                            //add payment summery
        //                            MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

        //                            #region Assign Parameters
        //                            cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
        //                            cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
        //                            cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
        //                            #endregion

        //                            #region DEclare Parametes
        //                            cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
        //                            cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
        //                            cmdInsertPaySumm.Parameters["@amount"].Value = strPayment;
        //                            cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@interest"].Value = strPayment;
        //                            cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
        //                            cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
        //                            cmdInsertPaySumm.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                            cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
        //                            cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
        //                            cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
        //                            cmdInsertPaySumm.Parameters["@curr_balance"].Value = decPHCuBalance;
        //                            #endregion

        //                            int w;
        //                            w = objDBTask.insertEditData(cmdInsertPaySumm);
        //                        }
        //                        else if (decWI > decPayment && decDueOneIA < decPayment)
        //                        {
        //                            decimal decBalance = decPayment - decDueOneIA;
        //                            string strBalance = decBalance.ToString();
        //                            //add payment summery
        //                            MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

        //                            #region Assign Parameters
        //                            cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
        //                            cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
        //                            cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
        //                            #endregion

        //                            #region DEclare Parametes
        //                            cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
        //                            cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
        //                            cmdInsertPaySumm.Parameters["@amount"].Value = strPayment;
        //                            cmdInsertPaySumm.Parameters["@capital"].Value = strBalance;
        //                            cmdInsertPaySumm.Parameters["@interest"].Value = strDueInte;
        //                            cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
        //                            cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
        //                            cmdInsertPaySumm.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                            cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
        //                            cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
        //                            cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
        //                            cmdInsertPaySumm.Parameters["@curr_balance"].Value = decPHCuBalance;
        //                            #endregion

        //                            int w;
        //                            w = objDBTask.insertEditData(cmdInsertPaySumm);
        //                        }
        //                        else
        //                        {
        //                            decimal decBalance = decPayment - decDueOneIA;
        //                            string strBalance = decBalance.ToString();
        //                            if (decDueOneCapital >= decBalance)
        //                            {

        //                            }
        //                            else
        //                            {
        //                                strBalance =  decDueOneCapital.ToString();
        //                            }
                                    

        //                            MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

        //                            #region Assign Parameters
        //                            cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
        //                            cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
        //                            cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
        //                            cmdInsertPaySumm.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
        //                            cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
        //                            #endregion

        //                            #region DEclare Parametes
        //                            cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
        //                            cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
        //                            cmdInsertPaySumm.Parameters["@amount"].Value = strPayment;
        //                            cmdInsertPaySumm.Parameters["@capital"].Value = strBalance;
        //                            cmdInsertPaySumm.Parameters["@interest"].Value = strDueInte;
        //                            cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
        //                            cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
        //                            cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
        //                            cmdInsertPaySumm.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                            cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
        //                            cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
        //                            cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
        //                            cmdInsertPaySumm.Parameters["@curr_balance"].Value = decPHCuBalance;
        //                            #endregion

        //                            int w;
        //                            w = objDBTask.insertEditData(cmdInsertPaySumm);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (decCurBalance >= decPayment)
        //                        {
        //                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = over_payment + '" + strPayment + "',arres_count = '" + strDef + "',loan_sta = 'S' where contra_code = '" + strCCode + "';");
        //                            int i;
        //                            i = objDBTask.insertEditData(cmdUpdateLoanAmou);
        //                        }
        //                        else
        //                        {
        //                            MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = over_payment + '" + strPayment + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
        //                            int i;
        //                            i = objDBTask.insertEditData(cmdUpdateLoanAmou);
        //                        }

        //                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

        //                        #region Assign Parameters
        //                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
        //                        cmdInsertPaySumm.Parameters.Add("@nic", MySqlDbType.VarChar, 15);
        //                        cmdInsertPaySumm.Parameters.Add("@amount", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@capital", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@interest", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@debit", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@c_default", MySqlDbType.Decimal, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@rcp_no", MySqlDbType.VarChar, 45);
        //                        cmdInsertPaySumm.Parameters.Add("@p_type", MySqlDbType.VarChar, 45);
        //                        cmdInsertPaySumm.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
        //                        cmdInsertPaySumm.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
        //                        cmdInsertPaySumm.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
        //                        cmdInsertPaySumm.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
        //                        cmdInsertPaySumm.Parameters.Add("@curr_balance", MySqlDbType.Decimal, 12);
        //                        #endregion

        //                        #region DEclare Parametes
        //                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
        //                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
        //                        cmdInsertPaySumm.Parameters["@amount"].Value = strPayment;
        //                        cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
        //                        cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
        //                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
        //                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
        //                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
        //                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
        //                        cmdInsertPaySumm.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
        //                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
        //                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
        //                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = decPHCuBalance;
        //                        #endregion

        //                        int w;
        //                        w = objDBTask.insertEditData(cmdInsertPaySumm);
        //                    }
        //                }
                        
        //            }

        //            //Due Date
        //            DataSet dsCheckMonIns = objDBTask.selectData("select * from micro_loan_details where contra_code = '" + strCCode + "';");

        //            string strCLBalance = dsCheckMonIns.Tables[0].Rows[0]["current_loan_amount"].ToString();
        //            string strCreteDate = dsCheckMonIns.Tables[0].Rows[0]["chequ_deta_on"].ToString();
        //            string strMoIns = dsCheckMonIns.Tables[0].Rows[0]["monthly_instollment"].ToString();
        //            string strDueDate1 = dsCheckMonIns.Tables[0].Rows[0]["due_date"].ToString();
        //            string strArreAmou = dsCheckMonIns.Tables[0].Rows[0]["arres_amou"].ToString();

        //            int intAmount = Convert.ToInt32(decPayment);
        //            string strAmountText = NumberToText(intAmount, true, false);
        //            string strInvoiceDateRec = DateTime.Now.ToString("yyyy-MM-dd");

        //            MySqlCommand cmdInsertReci = new MySqlCommand("INSERT INTO micro_receipt_history(contract_code,rec_no,city_code,paied_amount,curr_arres,balance,due_date,invoice_date,cash_nic,amount_text)VALUES(@contract_code,@rec_no,@city_code,@paied_amount,@curr_arres,@balance,@due_date,@invoice_date,@cash_nic,@amount_text);");

        //            #region Assign Parameters
        //            cmdInsertReci.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
        //            cmdInsertReci.Parameters.Add("@rec_no", MySqlDbType.VarChar, 10);
        //            cmdInsertReci.Parameters.Add("@city_code", MySqlDbType.VarChar, 10);
        //            cmdInsertReci.Parameters.Add("@paied_amount", MySqlDbType.Decimal, 10);
        //            cmdInsertReci.Parameters.Add("@curr_arres", MySqlDbType.Decimal, 10);
        //            cmdInsertReci.Parameters.Add("@balance", MySqlDbType.Decimal, 10);
        //            cmdInsertReci.Parameters.Add("@due_date", MySqlDbType.VarChar, 45);
        //            cmdInsertReci.Parameters.Add("@invoice_date", MySqlDbType.VarChar, 45);
        //            cmdInsertReci.Parameters.Add("@cash_nic", MySqlDbType.VarChar, 10);
        //            cmdInsertReci.Parameters.Add("@amount_text", MySqlDbType.VarChar, 100);
        //            #endregion

        //            #region DEclare Parametes
        //            cmdInsertReci.Parameters["@contract_code"].Value = strCCode;
        //            cmdInsertReci.Parameters["@rec_no"].Value = strRNum;
        //            cmdInsertReci.Parameters["@city_code"].Value = cmbCityCode.SelectedValue;
        //            cmdInsertReci.Parameters["@paied_amount"].Value = strPayment;
        //            cmdInsertReci.Parameters["@curr_arres"].Value = strArreAmou;
        //            cmdInsertReci.Parameters["@balance"].Value = strCLBalance;
        //            cmdInsertReci.Parameters["@due_date"].Value = strDueDate1;
        //            cmdInsertReci.Parameters["@invoice_date"].Value = strInvoiceDateRec;
        //            cmdInsertReci.Parameters["@cash_nic"].Value = strloginID;
        //            cmdInsertReci.Parameters["@amount_text"].Value = strAmountText;
        //            #endregion


        //            int g;
        //            g = objDBTask.insertEditData(cmdInsertReci);
        //        }
        //    }

        //    grvPayment.DataSource = null;
        //    grvPayment.DataBind();
        //    pnlPayment.Visible = false;
        //    lblTotalPaied.Text = "";
        //    cmbCityCode.SelectedIndex = 0;
        //    if (cmbSocietyID.Items.Count > 0)
        //    {
        //        cmbSocietyID.Items.Clear();
        //    }
        //}

        //With Paid Capilat
        protected void IRRPaymentNew()
        {
            lblMsg.Text = "";
            foreach (GridViewRow grows in grvPayment.Rows)
            {
                TextBox txtPayment = grows.FindControl("txtPaidAmount") as TextBox;
                int id = grows.RowIndex;                
                if (txtPayment.Text.Trim() != "")
                {
                    if (Convert.ToDecimal(txtPayment.Text.Trim()) != 0)
                    {
                        string strPayment = txtPayment.Text.Trim();
                        string strAmount = txtPayment.Text.Trim();
                        string strloginID = Session["NIC"].ToString();
                        string strCCode = grvPayment.Rows[id].Cells[1].Text;
                        string strNIC = grvPayment.Rows[id].Cells[3].Text;
                        string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string strIp = Request.UserHostAddress;
                        string strPayType = "Cash";
                        string strChqNo = "";
                        string strBank = "";
                        string strDef = "0";
                        TextBox txtRemark = grows.FindControl("txtRemark") as TextBox;
                        string Remark = txtRemark.Text.Trim();

                        MySqlCommand cmdInsertMonthPaym = new MySqlCommand("INSERT INTO micro_pais_history(contra_code,NIC,paied_amount,date_time,user_nic,user_ip,tra_description,pay_status,reson,payment_type,chq_No,chq_bank,remark)VALUES(@contra_code,@NIC,@paied_amount,@date_time,@user_nic,@user_ip,@tra_description,@pay_status,@reson,@payment_type,@chq_No,@chq_bank,@remark);");

                        #region Assign Parameters
                        cmdInsertMonthPaym.Parameters.Add("@contra_code", MySqlDbType.VarChar, 13);
                        cmdInsertMonthPaym.Parameters.Add("@NIC", MySqlDbType.VarChar, 15);
                        cmdInsertMonthPaym.Parameters.Add("@paied_amount", MySqlDbType.Decimal, 9);
                        cmdInsertMonthPaym.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                        cmdInsertMonthPaym.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
                        cmdInsertMonthPaym.Parameters.Add("@user_ip", MySqlDbType.VarChar, 20);
                        cmdInsertMonthPaym.Parameters.Add("@tra_description", MySqlDbType.VarChar, 3);
                        cmdInsertMonthPaym.Parameters.Add("@pay_status", MySqlDbType.VarChar, 1);
                        cmdInsertMonthPaym.Parameters.Add("@reson", MySqlDbType.VarChar, 45);
                        cmdInsertMonthPaym.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
                        cmdInsertMonthPaym.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
                        cmdInsertMonthPaym.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
                        cmdInsertMonthPaym.Parameters.Add("@remark", MySqlDbType.VarChar, 45);
                        #endregion

                        #region Declare Parametes
                        cmdInsertMonthPaym.Parameters["@contra_code"].Value = strCCode;
                        cmdInsertMonthPaym.Parameters["@NIC"].Value = strNIC;
                        cmdInsertMonthPaym.Parameters["@paied_amount"].Value = strPayment;
                        cmdInsertMonthPaym.Parameters["@date_time"].Value = strDate;
                        cmdInsertMonthPaym.Parameters["@user_nic"].Value = strloginID;
                        cmdInsertMonthPaym.Parameters["@user_ip"].Value = strIp;
                        cmdInsertMonthPaym.Parameters["@tra_description"].Value = "WI";
                        cmdInsertMonthPaym.Parameters["@pay_status"].Value = "D";
                        cmdInsertMonthPaym.Parameters["@reson"].Value = "";
                        cmdInsertMonthPaym.Parameters["@payment_type"].Value = strPayType;
                        cmdInsertMonthPaym.Parameters["@chq_No"].Value = strChqNo;
                        cmdInsertMonthPaym.Parameters["@chq_bank"].Value = strBank;
                        cmdInsertMonthPaym.Parameters["@remark"].Value = Remark;
                        #endregion

                        try
                        {
                            int f;
                            f = objDBTask.insertEditData(cmdInsertMonthPaym);
                            if (f == 1)
                            {
                                lblMsg.Text = "Payment is Succsessfuled.";
                            }
                            else
                            {
                                lblMsg.Text = "Error Occured!";
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                        //Get Recipt Number
                        string strRNum;
                        DataSet dsGetReciNum = cls_Connection.getDataSet("select max(idpais_history) from micro_pais_history where contra_code = '" + strCCode + "' and date_time = '" + strDate + "';");
                        strRNum = dsGetReciNum.Tables[0].Rows[0][0].ToString();

                        decimal decAmount = Convert.ToDecimal(strPayment);

                        //Chk Ladger Balance
                        string strCurBalance;
                        decimal decCurBalance = 0;
                        DataSet dsGetDebit_ = cls_Connection.getDataSet("select curr_balance from micro_payme_summery where contra_code = '" + strCCode + "' order by date_time desc limit 1;");
                        if (dsGetDebit_.Tables[0].Rows.Count > 0)
                        {
                            strCurBalance = dsGetDebit_.Tables[0].Rows[0]["curr_balance"].ToString();
                            decCurBalance = Convert.ToDecimal(strCurBalance);
                        }

                        decimal decPHCuBalance = decCurBalance - decAmount;
                        string strPHCuBalance = Convert.ToString(decPHCuBalance);

                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance,remark)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance,@remark);");

                        #region Assign Parameters
                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
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
                        cmdInsertPaySumm.Parameters.Add("@remark", MySqlDbType.VarChar, 45);
                        #endregion

                        #region DEclare Parametes
                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                        cmdInsertPaySumm.Parameters["@amount"].Value = strPayment;
                        cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                        cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                        cmdInsertPaySumm.Parameters["@date_time"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = decPHCuBalance;
                        cmdInsertPaySumm.Parameters["@remark"].Value = Remark;
                        #endregion

                        int w_;
                        w_ = objDBTask.insertEditData(cmdInsertPaySumm);

                        DataSet dsGetDebit = cls_Connection.getDataSet("select * from micro_payme_summery where contra_code = '" + strCCode + "' and rcp_no = '" + strRNum + "' and p_type = 'WI';");
                        if (dsGetDebit.Tables[0].Rows.Count > 0)
                        {
                            DataSet dsGetOP = cls_Connection.getDataSet("select * from micro_loan_details where contra_code = '" + strCCode + "';");
                            if (dsGetOP.Tables[0].Rows.Count > 0)
                            {
                                string strWI = dsGetOP.Tables[0].Rows[0]["monthly_instollment"].ToString();
                                string strOP = dsGetOP.Tables[0].Rows[0]["over_payment"].ToString();
                                decimal decOP = Convert.ToDecimal(strOP);

                                if (decOP > 0)
                                {
                                    MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment + '" + strAmount + "' where contra_code = '" + strCCode + "';");
                                    int iii;
                                    iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                }
                                else
                                {
                                    decimal decDueCapital = 0;
                                    decimal decDueInterest = 0;

                                    DataSet dsGetDueCapInte = cls_Connection.getDataSet("select sum(capital),sum(interest) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'DB';");
                                    if (dsGetDueCapInte.Tables[0].Rows[0][0].ToString() == "")
                                    {
                                        MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment + '" + strAmount + "' where contra_code = '" + strCCode + "';");
                                        int iii;
                                        iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                    }
                                    else
                                    {
                                        string strDueCapital = dsGetDueCapInte.Tables[0].Rows[0][0].ToString();
                                        string strDueInterest = dsGetDueCapInte.Tables[0].Rows[0][1].ToString();

                                        decDueCapital = Convert.ToDecimal(strDueCapital);
                                        decDueInterest = Convert.ToDecimal(strDueInterest);
                                        decimal decTotalDue = decDueCapital + decDueInterest;

                                        DataSet dsGetPaidCapInte = cls_Connection.getDataSet("select sum(paid_capital),sum(paid_interest) from paid_cap_int where contra_code = '" + strCCode + "';");
                                        if (dsGetPaidCapInte.Tables[0].Rows[0][1].ToString() == "")
                                        {
                                            if (decAmount >= decTotalDue)
                                            {
                                                MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                #region Assign Parameters
                                                cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                #endregion

                                                #region DEclare Parametes
                                                cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                cmdInsertPaidDetail.Parameters["@paid_capital"].Value = strDueCapital;
                                                cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strDueInterest;
                                                cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                #endregion

                                                int w;
                                                w = objDBTask.insertEditData(cmdInsertPaidDetail);

                                                decimal decNowOP = decAmount - decTotalDue;
                                                if (decNowOP > 0)
                                                {
                                                    string strNowOP = Convert.ToString(decNowOP);

                                                    MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment + '" + strNowOP + "', where contra_code = '" + strCCode + "';");
                                                    int iii;
                                                    iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                                }
                                            }
                                            else
                                            {
                                                if (decAmount >= decDueInterest)
                                                {
                                                    decimal decNowCapital = decAmount - decDueInterest;
                                                    string strNowCapital = Convert.ToString(decNowCapital);

                                                    MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                    #region Assign Parameters
                                                    cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                    cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                    cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                    cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                    #endregion

                                                    #region DEclare Parametes
                                                    cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                    cmdInsertPaidDetail.Parameters["@paid_capital"].Value = strNowCapital;
                                                    cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strDueInterest;
                                                    cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                    #endregion

                                                    int w;
                                                    w = objDBTask.insertEditData(cmdInsertPaidDetail);
                                                }
                                                else
                                                {
                                                    MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                    #region Assign Parameters
                                                    cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                    cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                    cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                    cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                    #endregion

                                                    #region DEclare Parametes
                                                    cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                    cmdInsertPaidDetail.Parameters["@paid_capital"].Value = "0";
                                                    cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strAmount;
                                                    cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                    #endregion

                                                    int w;
                                                    w = objDBTask.insertEditData(cmdInsertPaidDetail);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string strPaidInterest = dsGetPaidCapInte.Tables[0].Rows[0][1].ToString();
                                            string strPaidCapital = "0";
                                            if (dsGetPaidCapInte.Tables[0].Rows[0][0].ToString() != "")
                                            {
                                                strPaidCapital = dsGetPaidCapInte.Tables[0].Rows[0][0].ToString();
                                            }

                                            decimal decPaidInterest = Convert.ToDecimal(strPaidInterest);
                                            decimal decPaidCapital = Convert.ToDecimal(strPaidCapital);
                                            decimal decTotalPaid = decPaidInterest + decPaidCapital;


                                            if (decTotalPaid >= decTotalDue)
                                            {
                                                decimal decOldOP = (decTotalPaid - decTotalDue) + decAmount;
                                                if (decOldOP > 0)
                                                {
                                                    string strOLDOP = Convert.ToString(decOldOP);

                                                    MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment + '" + strOLDOP + "' where contra_code = '" + strCCode + "';");
                                                    int iii;
                                                    iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                                }
                                            }
                                            else
                                            {
                                                decimal decBalanceCapital = decDueCapital - decPaidCapital;
                                                decimal decBalanceInterest = decDueInterest - decPaidInterest;

                                                string strBalanceCapital = Convert.ToString(decBalanceCapital);
                                                string strBalanceInterest = Convert.ToString(decBalanceInterest);

                                                if (decBalanceInterest > 0 && decBalanceCapital > 0)
                                                {
                                                    decimal decTotalBalance = decBalanceInterest + decBalanceCapital;

                                                    if (decAmount >= decTotalBalance)
                                                    {
                                                        MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                        #region Assign Parameters
                                                        cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                        #endregion

                                                        #region DEclare Parametes
                                                        cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                        cmdInsertPaidDetail.Parameters["@paid_capital"].Value = strBalanceCapital;
                                                        cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strBalanceInterest;
                                                        cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                        #endregion

                                                        int w;
                                                        w = objDBTask.insertEditData(cmdInsertPaidDetail);

                                                        decimal decBalanceOP = decAmount - decTotalBalance;
                                                        if (decBalanceOP > 0)
                                                        {
                                                            string BalanceOP = Convert.ToString(decBalanceOP);

                                                            MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment + '" + BalanceOP + "' where contra_code = '" + strCCode + "';");
                                                            int iii;
                                                            iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (decAmount >= decBalanceInterest)
                                                        {
                                                            decimal decBalanceCapBala = decAmount - decBalanceInterest;
                                                            string strBalanceCapBala = (decBalanceCapBala).ToString();

                                                            MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                            #region Assign Parameters
                                                            cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                            cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                            cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                            cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                            #endregion

                                                            #region DEclare Parametes
                                                            cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                            cmdInsertPaidDetail.Parameters["@paid_capital"].Value = strBalanceCapBala;
                                                            cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strBalanceInterest;
                                                            cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                            #endregion

                                                            int w;
                                                            w = objDBTask.insertEditData(cmdInsertPaidDetail);
                                                        }
                                                        else
                                                        {
                                                            MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                            #region Assign Parameters
                                                            cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                            cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                            cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                            cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                            #endregion

                                                            #region DEclare Parametes
                                                            cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                            cmdInsertPaidDetail.Parameters["@paid_capital"].Value = "0";
                                                            cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strAmount;
                                                            cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                            #endregion

                                                            int w;
                                                            w = objDBTask.insertEditData(cmdInsertPaidDetail);
                                                        }
                                                    }
                                                }
                                                else if (decBalanceInterest > 0 && decBalanceCapital <= 0)
                                                {
                                                    if (decAmount >= decBalanceInterest)
                                                    {
                                                        decimal decBalanceeOP = decAmount - decBalanceInterest;
                                                        string strBalanceeOP = Convert.ToString(decBalanceeOP);

                                                        MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                        #region Assign Parameters
                                                        cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                        #endregion

                                                        #region DEclare Parametes
                                                        cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                        cmdInsertPaidDetail.Parameters["@paid_capital"].Value = "0";
                                                        cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strBalanceInterest;
                                                        cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                        #endregion

                                                        int w;
                                                        w = objDBTask.insertEditData(cmdInsertPaidDetail);

                                                        if (decBalanceeOP > 0)
                                                        {
                                                            //string BalanceOP = Convert.ToString(decBalanceOP);

                                                            MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment + '" + strBalanceeOP + "' where contra_code = '" + strCCode + "';");
                                                            int iii;
                                                            iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                        #region Assign Parameters
                                                        cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                        #endregion

                                                        #region DEclare Parametes
                                                        cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                        cmdInsertPaidDetail.Parameters["@paid_capital"].Value = "0";
                                                        cmdInsertPaidDetail.Parameters["@paid_interest"].Value = strAmount;
                                                        cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                        #endregion

                                                        int w;
                                                        w = objDBTask.insertEditData(cmdInsertPaidDetail);
                                                    }
                                                }
                                                else if (decBalanceInterest <= 0 && decBalanceCapital > 0)
                                                {
                                                    if (decAmount >= decBalanceCapital)
                                                    {
                                                        decimal decBalanceeOPP = decAmount - decBalanceCapital;
                                                        string strBalanceeOPP = Convert.ToString(decBalanceeOPP);

                                                        MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                        #region Assign Parameters
                                                        cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                        #endregion

                                                        #region DEclare Parametes
                                                        cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                        cmdInsertPaidDetail.Parameters["@paid_capital"].Value = strBalanceCapital;
                                                        cmdInsertPaidDetail.Parameters["@paid_interest"].Value = "0";
                                                        cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                        #endregion

                                                        int w;
                                                        w = objDBTask.insertEditData(cmdInsertPaidDetail);

                                                        if (decBalanceeOPP > 0)
                                                        {
                                                            //string BalanceOP = Convert.ToString(decBalanceOP);

                                                            MySqlCommand cmdUpdateLoanAmouu = new MySqlCommand("Update micro_loan_details set over_payment = over_payment + '" + strBalanceeOPP + "' where contra_code = '" + strCCode + "';");
                                                            int iii;
                                                            iii = objDBTask.insertEditData(cmdUpdateLoanAmouu);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MySqlCommand cmdInsertPaidDetail = new MySqlCommand("INSERT INTO paid_cap_int(contra_code,paid_capital,paid_interest,date_time)VALUES(@contra_code,@paid_capital,@paid_interest,@date_time);");

                                                        #region Assign Parameters
                                                        cmdInsertPaidDetail.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_capital", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@paid_interest", MySqlDbType.Decimal, 12);
                                                        cmdInsertPaidDetail.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                                                        #endregion

                                                        #region DEclare Parametes
                                                        cmdInsertPaidDetail.Parameters["@contra_code"].Value = strCCode;
                                                        cmdInsertPaidDetail.Parameters["@paid_capital"].Value = strAmount;
                                                        cmdInsertPaidDetail.Parameters["@paid_interest"].Value = "0";
                                                        cmdInsertPaidDetail.Parameters["@date_time"].Value = strDate;
                                                        #endregion

                                                        int w;
                                                        w = objDBTask.insertEditData(cmdInsertPaidDetail);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                //Curre balance & Arreas
                                string strCurBalancee = "0";
                                decimal decCurBalancee = 0;
                                DataSet dsGetDebitt = cls_Connection.getDataSet("select curr_balance from micro_payme_summery where contra_code = '" + strCCode + "' order by date_time desc limit 1;");
                                if (dsGetDebitt.Tables[0].Rows.Count > 0)
                                {
                                    strCurBalancee = dsGetDebitt.Tables[0].Rows[0]["curr_balance"].ToString();
                                    decCurBalancee = Convert.ToDecimal(strCurBalancee);
                                }

                                if (decCurBalancee > 0)
                                {
                                    decimal decWI = Convert.ToDecimal(strWI);
                                    decimal decCount = decCurBalancee / decWI;
                                    int intCount = Convert.ToInt32(decCount);
                                    string strCount = Convert.ToString(intCount);


                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strCurBalancee + "',def = '" + strDef + "',over_payment = '" + strDef + "',arres_count = '" + strCount + "' where contra_code = '" + strCCode + "';");
                                    int i;
                                    i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }
                                else
                                {
                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strPayment + "',arres_amou = '" + strDef + "',def = '" + strDef + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
                                    int i;
                                    i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }

                                //Chk Settle
                                DataSet dsGetSettle = cls_Connection.getDataSet("select * from micro_loan_details where contra_code = '" + strCCode + "';");
                                if (dsGetSettle.Tables[0].Rows.Count > 0)
                                {
                                    string strCuBalance = dsGetSettle.Tables[0].Rows[0]["current_loan_amount"].ToString();
                                    decimal decCuBalance = Convert.ToDecimal(strCuBalance);

                                    if (decCuBalance <= 0)
                                    {
                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set loan_sta = 'S' where contra_code = '" + strCCode + "';");
                                        int i;
                                        i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                    }
                                }
                            }
                        }
                    } 
                }
            }

            grvPayment.DataSource = null;
            grvPayment.DataBind();
            pnlPayment.Visible = false;
            lblTotalPaied.Text = "";
            cmbCityCode.SelectedIndex = 0;
            if (cmbSocietyID.Items.Count > 0)
            {
                cmbSocietyID.Items.Clear();
            }
        }

        protected void EqualPayment()
        {
            lblMsg.Text = "";
            foreach (GridViewRow grows in grvPayment.Rows)
            {
                TextBox txtPayment = grows.FindControl("txtPaidAmount") as TextBox;
                TextBox txtRemark = grows.FindControl("txtRemark") as TextBox;
                int id = grows.RowIndex;
                if (txtPayment.Text.Trim() != "")
                {
                    //Edit
                    string strAmo = txtPayment.Text.Trim();
                    string strloginID = Session["NIC"].ToString();
                    string strCCode = grvPayment.Rows[id].Cells[1].Text;
                    string strNIC = grvPayment.Rows[id].Cells[2].Text;
                    string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string strIp = Request.UserHostAddress;
                    string strRemark = txtRemark.Text.Trim();
                    string strPayType = "Cash";
                    string strChqNo = "";
                    string strBank = "";

                    MySqlCommand cmdInsertMonthPaym = new MySqlCommand("INSERT INTO micro_pais_history(contra_code,NIC,paied_amount,date_time,user_nic,user_ip,tra_description,pay_status,remark,payment_type,chq_No,chq_bank)VALUES(@contra_code,@NIC,@paied_amount,@date_time,@user_nic,@user_ip,@tra_description,@pay_status,@remark,@payment_type,@chq_No,@chq_bank);");

                    #region Assign Parameters
                    cmdInsertMonthPaym.Parameters.Add("@contra_code", MySqlDbType.VarChar, 13);
                    cmdInsertMonthPaym.Parameters.Add("@NIC", MySqlDbType.VarChar, 15);
                    cmdInsertMonthPaym.Parameters.Add("@paied_amount", MySqlDbType.Decimal, 9);
                    cmdInsertMonthPaym.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                    cmdInsertMonthPaym.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
                    cmdInsertMonthPaym.Parameters.Add("@user_ip", MySqlDbType.VarChar, 20);
                    cmdInsertMonthPaym.Parameters.Add("@tra_description", MySqlDbType.VarChar, 3);
                    cmdInsertMonthPaym.Parameters.Add("@pay_status", MySqlDbType.VarChar, 1);
                    cmdInsertMonthPaym.Parameters.Add("@remark", MySqlDbType.VarChar, 45);
                    cmdInsertMonthPaym.Parameters.Add("@payment_type", MySqlDbType.VarChar, 4);
                    cmdInsertMonthPaym.Parameters.Add("@chq_No", MySqlDbType.VarChar, 10);
                    cmdInsertMonthPaym.Parameters.Add("@chq_bank", MySqlDbType.VarChar, 45);
                    #endregion

                    #region Declare Parametes
                    cmdInsertMonthPaym.Parameters["@contra_code"].Value = strCCode;
                    cmdInsertMonthPaym.Parameters["@NIC"].Value = strNIC;
                    cmdInsertMonthPaym.Parameters["@paied_amount"].Value = strAmo;
                    cmdInsertMonthPaym.Parameters["@date_time"].Value = strDate;
                    cmdInsertMonthPaym.Parameters["@user_nic"].Value = strloginID;
                    cmdInsertMonthPaym.Parameters["@user_ip"].Value = strIp;
                    cmdInsertMonthPaym.Parameters["@tra_description"].Value = "WI";
                    cmdInsertMonthPaym.Parameters["@pay_status"].Value = "D";
                    cmdInsertMonthPaym.Parameters["@remark"].Value = strRemark;
                    cmdInsertMonthPaym.Parameters["@payment_type"].Value = strPayType;
                    cmdInsertMonthPaym.Parameters["@chq_No"].Value = strChqNo;
                    cmdInsertMonthPaym.Parameters["@chq_bank"].Value = strBank;
                    #endregion

                    try
                    {
                        int f;
                        f = objDBTask.insertEditData(cmdInsertMonthPaym);
                        if (f == 1)
                        {
                            lblMsg.Text = "Payment is Succsessfuled.";
                            //btnPeied.Enabled = false;
                        }
                        else
                        {
                            lblMsg.Text = "Error Occured!";
                        }
                    }
                    catch (Exception ex)
                    {
                    }



                    //Get Recipt Number
                    string strRNum;
                    DataSet dsGetReciNum = cls_Connection.getDataSet("select max(idpais_history) from micro_pais_history where contra_code = '" + strCCode + "' and date_time = '" + strDate + "';");
                    strRNum = dsGetReciNum.Tables[0].Rows[0][0].ToString();

                    decimal decAmou = Convert.ToDecimal(strAmo);

                    DataSet dsCheckArre = cls_Connection.getDataSet("select current_loan_amount,interest_amount,period,monthly_instollment,chequ_deta_on,due_date,arres_amou,def from micro_loan_details where contra_code = '" + strCCode + "';");
                    if (dsCheckArre.Tables[0].Rows.Count != 0)
                    {
                        string strCuLoanAmount = dsCheckArre.Tables[0].Rows[0]["current_loan_amount"].ToString();
                        string strIA = dsCheckArre.Tables[0].Rows[0]["interest_amount"].ToString();
                        string strP = dsCheckArre.Tables[0].Rows[0]["period"].ToString();
                        string strOldMI = dsCheckArre.Tables[0].Rows[0]["monthly_instollment"].ToString();
                        string strChequDate = dsCheckArre.Tables[0].Rows[0]["chequ_deta_on"].ToString();
                        string strDueD = dsCheckArre.Tables[0].Rows[0]["due_date"].ToString();
                        string strOldArre = dsCheckArre.Tables[0].Rows[0]["arres_amou"].ToString();
                        string strDefult = dsCheckArre.Tables[0].Rows[0]["def"].ToString();
                        decimal decDefult = Convert.ToDecimal(strDefult);
                        decimal decDebit = decAmou - decDefult;
                        string strDebit = Convert.ToString(decDebit);
                        decimal decOMI = Convert.ToDecimal(strOldMI);
                        decimal decOA = Convert.ToDecimal(strOldArre);
                        decimal decDebit2 = decOA - decDefult;
                        string strDebit2 = Convert.ToString(decDebit2);
                        decimal decDueAmou = decOMI + decOA;
                        decimal decIA = Convert.ToDecimal((strIA != "")? strIA: "0.00");
                        decimal decPe = Convert.ToDecimal((strP != "")? strP: "0.00");
                        //R Balance 2016-03-24
                        decimal decFirstInter = decIA / 1176 * 48;

                        decimal decOneIn = decIA / decPe;
                        decimal decroundOnIn = decimal.Round(decOneIn, 2, MidpointRounding.AwayFromZero);
                        string strOneIn = Convert.ToString(decFirstInter);
                        decimal decArrIntePlu = decAmou - (decOA + decroundOnIn);


                        decimal decCapitalNew = decAmou - decFirstInter;
                        string strCapitalNew = Convert.ToString(decCapitalNew);
                        int intArrIntePlu = Convert.ToInt32(decArrIntePlu);
                        string strCapi = Convert.ToString(decArrIntePlu);
                        decimal decOverPay = decOA + decOMI;
                        decimal decOverPayAmou = decAmou - decOverPay;
                        string strOverPayAmou = Convert.ToString(decOverPayAmou);
                        string strDef = "0";
                        decimal decCuLoaAmount = Convert.ToDecimal(strCuLoanAmount);

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

                        if (decOA > 0)
                        {
                            if (decAmou >= decOA)
                            {
                                if (decOverPay >= decAmou)
                                {
                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = '" + strDef + "',def = '" + strDef + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
                                    int i;
                                    i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }
                                else
                                {
                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = '" + strDef + "',def = '" + strDef + "',over_payment = over_payment + '" + strOverPayAmou + "',arres_count = '" + strDef + "' where contra_code = '" + strCCode + "';");
                                    int i;
                                    i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }

                                if (decArrIntePlu > 0)
                                {
                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                    #region Assign Parameters
                                    cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 12);
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
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strCapitalNew;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strOneIn;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                    cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                    cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                    cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else if (decArrIntePlu == 0)
                                {
                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                    #region Assign Parameters
                                    cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strCapitalNew;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strOneIn;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                    cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                    cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                    cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else
                                {
                                    decimal decMinInt = decAmou - decOA;
                                    decimal decCapiBala = decAmou - decMinInt - decDefult;
                                    string strCapiBala = Convert.ToString(decCapiBala);
                                    string strMinInt = Convert.ToString(decMinInt);
                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                    #region Assign Parameters
                                    cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strCapiBala;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strMinInt;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                    cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                    cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                    cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                            }
                            else
                            {
                                if (decDefult > 0)
                                {
                                    if (decDefult >= decAmou)
                                    {
                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = arres_amou - '" + strAmo + "',def = def - '" + strAmo + "'  where contra_code = '" + strCCode + "';");
                                        int i;
                                        i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                    }
                                    else
                                    {
                                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = arres_amou - '" + strAmo + "',def = '" + strDef + "'  where contra_code = '" + strCCode + "';");
                                        int i;
                                        i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                    }
                                }
                                else
                                {
                                    MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',arres_amou = arres_amou - '" + strAmo + "' where contra_code = '" + strCCode + "';");
                                    int i;
                                    i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                                }


                                if (decDefult >= decAmou)
                                {
                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                    #region Assign Parameters
                                    cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                    cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                    cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                    cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else if (decDefult == 0)
                                {
                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                    #region Assign Parameters
                                    cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strCapitalNew;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strOneIn;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                    cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                    cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                    cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                                else if (decDefult < decAmou && decDefult != 0)
                                {
                                    decimal decDeuInter = decAmou - decDefult - decOneIn;
                                    string strCapitaNew2 = Convert.ToString(decDeuInter);

                                    if (decDeuInter >= 0)
                                    {
                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strCapitaNew2;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strOneIn;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                    else
                                    {
                                        decimal decInterMin2 = decAmou - decDefult;
                                        string strInterMin2 = Convert.ToString(decInterMin2);

                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strInterMin2;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDefult;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (decOMI >= decAmou)
                            {
                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "' where contra_code = '" + strCCode + "';");
                                int i;
                                i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                            }
                            else
                            {
                                decimal decOP2 = decAmou - decOMI;
                                string strOP2 = Convert.ToString(decOP2);
                                MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set current_loan_amount = current_loan_amount - '" + strAmo + "',over_payment = over_payment + '" + strOP2 + "' where contra_code = '" + strCCode + "';");
                                int i;
                                i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                            }

                            //CHECK NOW--------------Edit 2014.08.18
                            DataSet dsCheckInter = cls_Connection.getDataSet("select sum(interest) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
                            if (dsCheckInter.Tables[0].Rows[0][0].ToString() != "")
                            {
                                string strPaidInte = dsCheckInter.Tables[0].Rows[0][0].ToString();
                                decimal decCuPaidIn = Convert.ToDecimal(strPaidInte);
                                if (decCuLoaAmount > decAmou)
                                {
                                    DateTime dtDueDate = Convert.ToDateTime(strDueD);
                                    DateTime dtCheqDate = Convert.ToDateTime(strChequDate);
                                    TimeSpan tsTotalDay = dtDueDate.Subtract(dtCheqDate);
                                    string strTotalDay = tsTotalDay.Days.ToString();
                                    int intTotalDay = Convert.ToInt32(strTotalDay);
                                    int intToMonth = intTotalDay / 7;
                                    decimal decToMonth = Convert.ToDecimal(intToMonth);
                                    decimal decCurrPayIn = decToMonth * decOneIn;
                                    decimal decInteBala = decCurrPayIn - decCuPaidIn;
                                    decimal decRoundIB = decimal.Round(decInteBala, 2, MidpointRounding.AwayFromZero);
                                    string strInteBala = Convert.ToString(decRoundIB);
                                    if (decInteBala <= 0)
                                    {
                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                    else if (decInteBala > 0 && decAmou > decInteBala)
                                    {
                                        decimal decMainCap = decAmou - decRoundIB;
                                        string strMainCap = Convert.ToString(decMainCap);

                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strMainCap;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strInteBala;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                    else if (decInteBala > 0 && decAmou <= decInteBala)
                                    {
                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                }
                                else
                                {
                                    decimal decBalaInte = decIA - decCuPaidIn;
                                    string strBalaInte = Convert.ToString(decBalaInte);
                                    if (decBalaInte <= 0)
                                    {
                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                    else if (decBalaInte > 0 && decAmou > decBalaInte)
                                    {
                                        decimal decNowCredit = decAmou - decBalaInte;
                                        string strNowCredit = Convert.ToString(decNowCredit);

                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strNowCredit;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strBalaInte;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                    else if (decBalaInte > 0 && decAmou <= decBalaInte)
                                    {
                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                }
                            }
                            else
                            {
                                if (decCuLoaAmount > decAmou)
                                {
                                    DateTime dtDueDate = Convert.ToDateTime(strDueD);
                                    DateTime dtCheqDate = Convert.ToDateTime(strChequDate);
                                    TimeSpan tsTotalDay = dtDueDate.Subtract(dtCheqDate);
                                    string strTotalDay = tsTotalDay.Days.ToString();
                                    int intTotalDay = Convert.ToInt32(strTotalDay);
                                    int intToMonth = intTotalDay / 7;
                                    decimal decToMonth = Convert.ToDecimal(intToMonth);
                                    decimal decCurrPayIn = decToMonth * decOneIn;
                                    decimal decRoundCurrPay = decimal.Round(decCurrPayIn, 2, MidpointRounding.AwayFromZero);
                                    string strCuI = Convert.ToString(decRoundCurrPay);
                                    if (decCurrPayIn >= decAmou)
                                    {
                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                    else
                                    {
                                        decimal decMina = decAmou - decRoundCurrPay;
                                        string strCapii = Convert.ToString(decMina);

                                        //add payment summery
                                        MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                        #region Assign Parameters
                                        cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                        cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                        cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                        cmdInsertPaySumm.Parameters["@capital"].Value = strCapitalNew;
                                        cmdInsertPaySumm.Parameters["@interest"].Value = strOneIn;
                                        cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                        cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                        cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                        cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                        cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                        cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                        cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                        cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                        #endregion

                                        int w;
                                        w = objDBTask.insertEditData(cmdInsertPaySumm);
                                    }
                                }
                                else
                                {
                                    decimal decCap = decAmou - decIA;
                                    string strCapit = Convert.ToString(decCap);

                                    //add payment summery
                                    MySqlCommand cmdInsertPaySumm = new MySqlCommand("INSERT INTO micro_payme_summery(contra_code,nic,amount,capital,interest,debit,c_default,rcp_no,p_type,date_time,payment_type,chq_No,chq_bank,curr_balance)VALUES(@contra_code,@nic,@amount,@capital,@interest,@debit,@c_default,@rcp_no,@p_type,@date_time,@payment_type,@chq_No,@chq_bank,@curr_balance);");

                                    #region Assign Parameters
                                    cmdInsertPaySumm.Parameters.Add("@contra_code", MySqlDbType.VarChar, 14);
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
                                    #endregion

                                    #region DEclare Parametes
                                    cmdInsertPaySumm.Parameters["@contra_code"].Value = strCCode;
                                    cmdInsertPaySumm.Parameters["@nic"].Value = strNIC;
                                    cmdInsertPaySumm.Parameters["@amount"].Value = strAmo;
                                    cmdInsertPaySumm.Parameters["@capital"].Value = strCapit;
                                    cmdInsertPaySumm.Parameters["@interest"].Value = strIA;
                                    cmdInsertPaySumm.Parameters["@debit"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@c_default"].Value = strDef;
                                    cmdInsertPaySumm.Parameters["@rcp_no"].Value = strRNum;
                                    cmdInsertPaySumm.Parameters["@p_type"].Value = "WI";
                                    cmdInsertPaySumm.Parameters["@date_time"].Value = strDate;
                                    cmdInsertPaySumm.Parameters["@payment_type"].Value = strPayType;
                                    cmdInsertPaySumm.Parameters["@chq_No"].Value = strChqNo;
                                    cmdInsertPaySumm.Parameters["@chq_bank"].Value = strBank;
                                    cmdInsertPaySumm.Parameters["@curr_balance"].Value = strPHCuBalance;
                                    #endregion

                                    int w;
                                    w = objDBTask.insertEditData(cmdInsertPaySumm);
                                }
                            }
                        }
                    }

                    //Add Due Date


                    DataSet dsCheckMonIns = cls_Connection.getDataSet("select * from micro_loan_details where contra_code = '" + strCCode + "';");

                    string strCLBalance = dsCheckMonIns.Tables[0].Rows[0]["current_loan_amount"].ToString();
                    string strCreteDate = dsCheckMonIns.Tables[0].Rows[0]["chequ_deta_on"].ToString();
                    string strMoIns = dsCheckMonIns.Tables[0].Rows[0]["monthly_instollment"].ToString();
                    string strDueDate = dsCheckMonIns.Tables[0].Rows[0]["due_date"].ToString();
                    string strArreAmou = dsCheckMonIns.Tables[0].Rows[0]["arres_amou"].ToString();

                    decimal decCurrLA = Convert.ToDecimal(strCLBalance);
                    if (decCurrLA <= 0)
                    {
                        MySqlCommand cmdUpdateLoanAmou = new MySqlCommand("Update micro_loan_details set loan_sta = 'S' where contra_code = '" + strCCode + "';");
                        int i;
                        i = objDBTask.insertEditData(cmdUpdateLoanAmou);
                    }

                    decimal decMoIns = Convert.ToDecimal(strMoIns);
                    decimal decArreAmo = Convert.ToDecimal(strArreAmou);
                    DateTime dtDDate = Convert.ToDateTime(strDueDate);

                    int intAmount = Convert.ToInt32(decAmou);
                    string strAmountText = NumberToText(intAmount, true, false);
                    string strInvoiceDateRec = DateTime.Now.ToString("yyyy-MM-dd");

                    if (decArreAmo <= 0)
                    {
                        DataSet dsChkPayHis = cls_Connection.getDataSet("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
                        if (dsChkPayHis.Tables[0].Rows[0][0].ToString() != "")
                        {
                            string strTotPaym = dsChkPayHis.Tables[0].Rows[0][0].ToString();
                            decimal decToPaym = Convert.ToDecimal(strTotPaym);
                            DateTime dtCreDate = Convert.ToDateTime(strCreteDate);
                            TimeSpan tsTotaDay = dtDDate.Subtract(dtCreDate);
                            string strToDay = tsTotaDay.Days.ToString();
                            int intToDay = Convert.ToInt32(strToDay);
                            decimal decDays = Convert.ToDecimal(intToDay) / 7;
                            //int intMonth = intToDay / 30;
                            //decimal decMonth = Convert.ToDecimal(intMonth);
                            string strTotaDefua;
                            DataSet dsChkDefau = cls_Connection.getDataSet("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'D';");
                            if (dsChkDefau.Tables[0].Rows[0][0].ToString() != "")
                            {
                                strTotaDefua = dsChkDefau.Tables[0].Rows[0][0].ToString();
                            }
                            else
                            {
                                strTotaDefua = "0";
                            }
                            decimal decTotDafua = Convert.ToDecimal(strTotaDefua);
                            decimal decTotPayAmou = 0;
                            if (decDays <= 1)
                            {
                                decTotPayAmou = (decMoIns * 1) + decTotDafua;
                            }
                            else
                            {
                                decTotPayAmou = (decMoIns * decDays) + decTotDafua;
                            }

                            decTotPayAmou = (decMoIns * decDays) + decTotDafua;

                            decimal decRoundPayAmo = decimal.Round(decTotPayAmou, 2, MidpointRounding.AwayFromZero);
                            if (decToPaym >= decRoundPayAmo)
                            {
                                DateTime due;
                                due = dtDDate.AddDays(7);

                                string strDue = due.ToString("yyyy-MM-dd");
                                string strZero = "0";

                                MySqlCommand cmdUpdateLoanDueDa = new MySqlCommand("Update micro_loan_details set arres_count = '" + strZero + "' where contra_code = '" + strCCode + "';");

                                try
                                {
                                    int b;
                                    b = objDBTask.insertEditData(cmdUpdateLoanDueDa);
                                    if (b == 1)
                                    {
                                        //lblMsg.Text = "Updated Successfully";
                                        MySqlCommand cmdInsertReci = new MySqlCommand("INSERT INTO micro_receipt_history(contract_code,rec_no,city_code,paied_amount,curr_arres,balance,due_date,invoice_date,cash_nic,amount_text)VALUES(@contract_code,@rec_no,@city_code,@paied_amount,@curr_arres,@balance,@due_date,@invoice_date,@cash_nic,@amount_text);");

                                        #region Assign Parameters
                                        cmdInsertReci.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                                        cmdInsertReci.Parameters.Add("@rec_no", MySqlDbType.VarChar, 10);
                                        cmdInsertReci.Parameters.Add("@city_code", MySqlDbType.VarChar, 10);
                                        cmdInsertReci.Parameters.Add("@paied_amount", MySqlDbType.Decimal, 10);
                                        cmdInsertReci.Parameters.Add("@curr_arres", MySqlDbType.Decimal, 10);
                                        cmdInsertReci.Parameters.Add("@balance", MySqlDbType.Decimal, 10);
                                        cmdInsertReci.Parameters.Add("@due_date", MySqlDbType.VarChar, 45);
                                        cmdInsertReci.Parameters.Add("@invoice_date", MySqlDbType.VarChar, 45);
                                        cmdInsertReci.Parameters.Add("@cash_nic", MySqlDbType.VarChar, 10);
                                        cmdInsertReci.Parameters.Add("@amount_text", MySqlDbType.VarChar, 100);
                                        #endregion

                                        #region DEclare Parametes
                                        cmdInsertReci.Parameters["@contract_code"].Value = strCCode;
                                        cmdInsertReci.Parameters["@rec_no"].Value = strRNum;
                                        cmdInsertReci.Parameters["@city_code"].Value = cmbCityCode.SelectedValue;
                                        cmdInsertReci.Parameters["@paied_amount"].Value = strAmo;
                                        cmdInsertReci.Parameters["@curr_arres"].Value = strArreAmou;
                                        cmdInsertReci.Parameters["@balance"].Value = strCLBalance;
                                        cmdInsertReci.Parameters["@due_date"].Value = strDue;
                                        cmdInsertReci.Parameters["@invoice_date"].Value = strInvoiceDateRec;
                                        cmdInsertReci.Parameters["@cash_nic"].Value = strloginID;
                                        cmdInsertReci.Parameters["@amount_text"].Value = strAmountText;
                                        #endregion


                                        int g;
                                        g = objDBTask.insertEditData(cmdInsertReci);
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
                                //lblMsg.Text = "Updated Successfully";

                                MySqlCommand cmdInsertReci = new MySqlCommand("INSERT INTO micro_receipt_history(contract_code,rec_no,city_code,paied_amount,curr_arres,balance,due_date,invoice_date,cash_nic,amount_text)VALUES(@contract_code,@rec_no,@city_code,@paied_amount,@curr_arres,@balance,@due_date,@invoice_date,@cash_nic,@amount_text);");

                                #region Assign Parameters
                                cmdInsertReci.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                                cmdInsertReci.Parameters.Add("@rec_no", MySqlDbType.VarChar, 10);
                                cmdInsertReci.Parameters.Add("@city_code", MySqlDbType.VarChar, 10);
                                cmdInsertReci.Parameters.Add("@paied_amount", MySqlDbType.Decimal, 10);
                                cmdInsertReci.Parameters.Add("@curr_arres", MySqlDbType.Decimal, 10);
                                cmdInsertReci.Parameters.Add("@balance", MySqlDbType.Decimal, 10);
                                cmdInsertReci.Parameters.Add("@due_date", MySqlDbType.VarChar, 45);
                                cmdInsertReci.Parameters.Add("@invoice_date", MySqlDbType.VarChar, 45);
                                cmdInsertReci.Parameters.Add("@cash_nic", MySqlDbType.VarChar, 10);
                                cmdInsertReci.Parameters.Add("@amount_text", MySqlDbType.VarChar, 100);
                                #endregion

                                #region DEclare Parametes
                                cmdInsertReci.Parameters["@contract_code"].Value = strCCode;
                                cmdInsertReci.Parameters["@rec_no"].Value = strRNum;
                                cmdInsertReci.Parameters["@city_code"].Value = cmbCityCode.SelectedValue;
                                cmdInsertReci.Parameters["@paied_amount"].Value = strAmo;
                                cmdInsertReci.Parameters["@curr_arres"].Value = strArreAmou;
                                cmdInsertReci.Parameters["@balance"].Value = strCLBalance;
                                cmdInsertReci.Parameters["@due_date"].Value = strDueDate;
                                cmdInsertReci.Parameters["@invoice_date"].Value = strInvoiceDateRec;
                                cmdInsertReci.Parameters["@cash_nic"].Value = strloginID;
                                cmdInsertReci.Parameters["@amount_text"].Value = strAmountText;
                                #endregion


                                int g;
                                g = objDBTask.insertEditData(cmdInsertReci);


                            }
                        }
                    }
                    else
                    {
                        //lblMsg.Text = "Updated Successfully";

                        MySqlCommand cmdInsertReci = new MySqlCommand("INSERT INTO micro_receipt_history(contract_code,rec_no,city_code,paied_amount,curr_arres,balance,due_date,invoice_date,cash_nic,amount_text)VALUES(@contract_code,@rec_no,@city_code,@paied_amount,@curr_arres,@balance,@due_date,@invoice_date,@cash_nic,@amount_text);");

                        #region Assign Parameters
                        cmdInsertReci.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                        cmdInsertReci.Parameters.Add("@rec_no", MySqlDbType.VarChar, 10);
                        cmdInsertReci.Parameters.Add("@city_code", MySqlDbType.VarChar, 10);
                        cmdInsertReci.Parameters.Add("@paied_amount", MySqlDbType.Decimal, 10);
                        cmdInsertReci.Parameters.Add("@curr_arres", MySqlDbType.Decimal, 10);
                        cmdInsertReci.Parameters.Add("@balance", MySqlDbType.Decimal, 10);
                        cmdInsertReci.Parameters.Add("@due_date", MySqlDbType.VarChar, 45);
                        cmdInsertReci.Parameters.Add("@invoice_date", MySqlDbType.VarChar, 45);
                        cmdInsertReci.Parameters.Add("@cash_nic", MySqlDbType.VarChar, 10);
                        cmdInsertReci.Parameters.Add("@amount_text", MySqlDbType.VarChar, 100);
                        #endregion

                        #region DEclare Parametes
                        cmdInsertReci.Parameters["@contract_code"].Value = strCCode;
                        cmdInsertReci.Parameters["@rec_no"].Value = strRNum;
                        cmdInsertReci.Parameters["@city_code"].Value = cmbCityCode.SelectedValue;
                        cmdInsertReci.Parameters["@paied_amount"].Value = strAmo;
                        cmdInsertReci.Parameters["@curr_arres"].Value = strArreAmou;
                        cmdInsertReci.Parameters["@balance"].Value = strCLBalance;
                        cmdInsertReci.Parameters["@due_date"].Value = strDueDate;
                        cmdInsertReci.Parameters["@invoice_date"].Value = strInvoiceDateRec;
                        cmdInsertReci.Parameters["@cash_nic"].Value = strloginID;
                        cmdInsertReci.Parameters["@amount_text"].Value = strAmountText;
                        #endregion


                        int g;
                        g = objDBTask.insertEditData(cmdInsertReci);
                    }

                }
            }

            grvPayment.DataSource = null;
            grvPayment.DataBind();
            pnlPayment.Visible = false;
            lblTotalPaied.Text = "";
            cmbCityCode.SelectedIndex = 0;
            if (cmbSocietyID.Items.Count > 0)
            {
                cmbSocietyID.Items.Clear();
            }
            if (cmbArea.Items.Count > 0)
            {
                cmbArea.Items.Clear();
            }
            if (cmbVillage.Items.Count > 0)
            {
                cmbVillage.Items.Clear();
            }
        }

        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbVillage.Items.Clear();
            cmbSocietyID.Items.Clear();
            try
            {
                lblMsg.Text = "";
                if (cmbCityCode.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select branch.";
                    //btnSubmit.Enabled = false;
                }
                else if (cmbArea.SelectedIndex < 0)
                {
                    lblMsg.Text = "Please select area.";
                    //btnSubmit.Enabled = false;
                }
                else
                {
                    if (cmbVillage.Items.Count > 0)
                    {
                        cmbVillage.Items.Clear();
                    }

                    DataSet dsSocietyName = cls_Connection.getDataSet("SELECT villages_code,villages_name FROM villages_name WHERE city_code = '" + cmbCityCode.SelectedItem.Value + "' AND area_code ='" + cmbArea.SelectedItem.Value + "';");
                    if (dsSocietyName.Tables[0].Rows.Count > 0)
                    {
                        cmbVillage.Items.Add("Select Village");
                        for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
                        {
                            cmbVillage.Items.Add(dsSocietyName.Tables[0].Rows[i]["villages_name"].ToString());
                            cmbVillage.Items[i + 1].Value = dsSocietyName.Tables[0].Rows[i]["villages_code"].ToString();
                        }
                        cmbVillage.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "No record found...! Please chose other village name.";
                        //btnSubmit.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSocietyID.Items.Clear();
            try
            {
                //txtSoNumber.Text = "";
                lblMsg.Text = "";
                if (cmbVillage.SelectedIndex != 0 && cmbCityCode.SelectedIndex != 0 && cmbArea.SelectedIndex != 0)
                {
                    DataSet dsSCenter = cls_Connection.getDataSet("SELECT idcenter_details, center_name, center_day FROM center_details WHERE city_code = '" + cmbCityCode.SelectedItem.Value + "' AND area_code = '" + cmbArea.SelectedItem.Value + "' AND villages = '" + cmbVillage.SelectedItem.Value + "';");
                    cmbSocietyID.Items.Clear();
                    if (dsSCenter.Tables[0].Rows.Count > 0)
                    {
                        cmbSocietyID.Items.Add("Select Center");

                        for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                        {
                            cmbSocietyID.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                            cmbSocietyID.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                        }
                        cmbSocietyID.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "There is no available centers...";
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
