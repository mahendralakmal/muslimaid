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
    public partial class Bulk_Payment : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    DataSet dsCity;
                    MySqlCommand cmdCity = new MySqlCommand("SELECT b_code,b_name FROM branch ORDER BY 2");
                    dsCity = objDBTask.selectData(cmdCity);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsCity.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add("[" + dsCity.Tables[0].Rows[i]["b_code"] + "] - " + dsCity.Tables[0].Rows[i]["b_name"].ToString());
                        cmbCityCode.Items[i+1].Value = dsCity.Tables[0].Rows[i]["b_code"].ToString();
                    }
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            grvPayment.DataSource = null;
            grvPayment.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex != 0 && cmbSocietyID.SelectedIndex >= 0)
            {
                string strCityCode = cmbCityCode.SelectedValue;
                string strSocietyID = cmbSocietyID.SelectedValue;

                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = "select b.contract_code,b.ca_code,b.nic,b.initial_name,l.monthly_instollment,l.current_loan_amount from micro_basic_detail b,micro_loan_details l where b.city_code = '" + strCityCode + "' and b.society_id = '" + strSocietyID + "' and b.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P' or b.city_code = '" + strCityCode + "' and b.society_id = '" + strSocietyID + "' and b.contract_code = l.contra_code and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'E' order by b.idmicro_basic_detail asc;";
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
            if (cmbCityCode.SelectedIndex != 0)
            {
                if (cmbSocietyID.Items.Count > 0)
                {
                    cmbSocietyID.Items.Clear();
                }

                DataSet dsCenter;
                MySqlCommand cmdCenter = new MySqlCommand("select idcenter_details,center_name,villages from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "'");
                dsCenter = objDBTask.selectData(cmdCenter);
                if (dsCenter.Tables[0].Rows.Count > 0)
                {
                    //cmbSocietyID.Items.Add("");
                    btnSerch.Enabled = true;

                    for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                    {
                        cmbSocietyID.Items.Add("[" + dsCenter.Tables[0].Rows[i]["idcenter_details"] + "] - " + dsCenter.Tables[0].Rows[i]["villages"].ToString() + "-" + dsCenter.Tables[0].Rows[i]["center_name"].ToString());
                        cmbSocietyID.Items[i].Value = dsCenter.Tables[0].Rows[i]["idcenter_details"].ToString();

                        //cmbAds.Items.Add("[" + dsData.Tables[0].Rows[i]["advertisementid"] + "] - " + dsData.Tables[0].Rows[i]["makename"].ToString() + "-" + dsData.Tables[0].Rows[i]["model"].ToString() + " - " + dsData.Tables[0].Rows[i]["submodel"].ToString());
                        //cmbAds.Items[i].Value = dsData.Tables[0].Rows[i]["advertisementid"].ToString();
                    }
                }
                else
                {
                    lblMsg.Text = "No record found...! Please chose other city code.";
                    btnSerch.Enabled = false;
                }
            }
            else
            {
                if (cmbSocietyID.Items.Count > 0)
                {
                    cmbSocietyID.Items.Clear();
                }
                lblMsg.Text = "Please chose city code.";
                btnSerch.Enabled = false;
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
            lblMsg.Text = "";
            foreach (GridViewRow grows in grvPayment.Rows)
            { 
                TextBox txtPayment = grows.FindControl("txtPaidAmount") as TextBox;
                int id = grows.RowIndex;
                if (txtPayment.Text.Trim() != "")
                {
                    //Edit
                    string strAmo = txtPayment.Text.Trim();
                    string strloginID = Session["NIC"].ToString();
                    string strCCode = grvPayment.Rows[id].Cells[0].Text;
                    string strNIC = grvPayment.Rows[id].Cells[2].Text;
                    string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string strIp = Request.UserHostAddress;
                    string strPayType = "Cash";
                    string strChqNo = "";
                    string strBank = "";

                    MySqlCommand cmdInsertMonthPaym = new MySqlCommand("INSERT INTO micro_pais_history(contra_code,NIC,paied_amount,date_time,user_nic,user_ip,tra_description,pay_status,reson,payment_type,chq_No,chq_bank)VALUES(@contra_code,@NIC,@paied_amount,@date_time,@user_nic,@user_ip,@tra_description,@pay_status,@reson,@payment_type,@chq_No,@chq_bank);");

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
                    cmdInsertMonthPaym.Parameters["@reson"].Value = "";
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
                    DataSet dsGetReciNum = objDBTask.selectData("select max(idpais_history) from micro_pais_history where contra_code = '" + strCCode + "' and date_time = '" + strDate + "';");
                    strRNum = dsGetReciNum.Tables[0].Rows[0][0].ToString();

                    decimal decAmou = Convert.ToDecimal(strAmo);

                    DataSet dsCheckArre = objDBTask.selectData("select current_loan_amount,interest_amount,period,monthly_instollment,chequ_deta_on,due_date,arres_amou,def from micro_loan_details where contra_code = '" + strCCode + "';");
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
                        decimal decIA = Convert.ToDecimal(strIA);
                        decimal decPe = Convert.ToDecimal(strP);
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
                        DataSet dsGetDebit = objDBTask.selectData("select curr_balance from micro_payme_summery where contra_code = '" + strCCode + "' order by idcons_payme_summery desc limit 1;");
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
                            DataSet dsCheckInter = objDBTask.selectData("select sum(interest) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
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


                    DataSet dsCheckMonIns = objDBTask.selectData("select * from micro_loan_details where contra_code = '" + strCCode + "';");

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
                        DataSet dsChkPayHis = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI';");
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
                            DataSet dsChkDefau = objDBTask.selectData("select sum(amount) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'D';");
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
    }
}
