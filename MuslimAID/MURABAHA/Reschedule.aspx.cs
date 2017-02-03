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
    public partial class Reschedule : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        DataSet dsCCode;
        string strTeamNo, strClientID, strPromiserID, hidCC;

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
                Response.Redirect("Login.aspx");
            }
        }

        private void Clear()
        {
            btnSubmit.Enabled = false;
            lblConCode.Text = "";
            lblName.Text = "";
            lblLoanAmou.Text = "";
            lblIAmount.Text = "";
            lblPeriod.Text = "";
            lblGrantDate.Text = "";
            lblTotCurrentBalance.Text = "";
            lblDueInstallment.Text = "";
            lblOverPayment.Text = "";
            lblTotalArreas.Text = "";
            lblTotalDefault.Text = "";
            lblLoanStock.Text = "";
            lblFutureCapital.Text = "";
            lblFutureInterest.Text = "";
            txtReschedulePeriod.Text = "";
            txtRSInterestRate.Text = "";
            txtRSLoanAmount.Text = "";
            txtRSLoanInstallment.Text = "";
        }

        private void Load()
        {
            try
            {
                lblMsg.Text = "";
                hstrSelectQuery.Value = "";
                if (txtCC.Text.Trim() != "")
                {
                    hstrSelectQuery.Value = "SELECT l.contra_code, b.initial_name, l.loan_amount, l.interest_amount, l.period, l.chequ_deta_on, l.current_loan_amount, l.due_installment, l.over_payment, l.arres_amou, l.def TotalDefault  FROM micro_loan_details l INNER JOIN micro_basic_detail b ON l.contra_code = b.contract_code WHERE l.contra_code = '" + txtCC.Text.Trim() + "' and l.loan_approved = 'Y' and l.chequ_no != '' and l.loan_sta = 'P' ;";

                    string strQRY = hstrSelectQuery.Value;
                    DataSet dsGetTrans = cls_Connection.getDataSet(strQRY);
                    Clear();
                    if (dsGetTrans.Tables[0].Rows.Count > 0)
                    {
                        lblConCode.Text = dsGetTrans.Tables[0].Rows[0]["contra_code"].ToString();
                        lblName.Text = dsGetTrans.Tables[0].Rows[0]["initial_name"].ToString();
                        lblLoanAmou.Text = dsGetTrans.Tables[0].Rows[0]["loan_amount"].ToString();
                        lblIAmount.Text = dsGetTrans.Tables[0].Rows[0]["interest_amount"].ToString();
                        lblPeriod.Text = dsGetTrans.Tables[0].Rows[0]["period"].ToString();
                        lblGrantDate.Text = dsGetTrans.Tables[0].Rows[0]["chequ_deta_on"].ToString();
                        lblTotCurrentBalance.Text = dsGetTrans.Tables[0].Rows[0]["current_loan_amount"].ToString();
                        lblDueInstallment.Text = dsGetTrans.Tables[0].Rows[0]["due_installment"].ToString();
                        lblOverPayment.Text = dsGetTrans.Tables[0].Rows[0]["over_payment"].ToString();
                        lblTotalArreas.Text = dsGetTrans.Tables[0].Rows[0]["arres_amou"].ToString();
                        lblTotalDefault.Text = dsGetTrans.Tables[0].Rows[0]["TotalDefault"].ToString();

                        lblLoanStock.Text = LoanStock(dsGetTrans.Tables[0].Rows[0]["contra_code"].ToString(), Convert.ToDecimal(dsGetTrans.Tables[0].Rows[0]["loan_amount"])).ToString();
                        lblFutureCapital.Text = FutureCapital(dsGetTrans.Tables[0].Rows[0]["contra_code"].ToString(), Convert.ToDecimal(dsGetTrans.Tables[0].Rows[0]["loan_amount"])).ToString();
                        lblFutureInterest.Text = FutureInterest(dsGetTrans.Tables[0].Rows[0]["contra_code"].ToString(), Convert.ToDecimal(dsGetTrans.Tables[0].Rows[0]["interest_amount"])).ToString();

                        txtRSLoanAmount.Text = lblTotCurrentBalance.Text = dsGetTrans.Tables[0].Rows[0]["current_loan_amount"].ToString();
                        btnSubmit.Enabled = true;
                        //lblMsg.Text = "Can not Settle the Loan, Not exceeded the period";
                    }
                    else
                    {
                        lblMsg.Text = "No records found for your search Contract Code, Not activate or not approved. Please try again.";
                    }
                }
                else
                {
                    lblMsg.Text = "Please enter Contract Code.";
                }
            }
            catch (Exception)
            {

            }
        }

        //Future Capital 
        private decimal FutureCapital(string CusCode, decimal LoanAmount)
        {
            try
            {
                decimal TotalCapital = 0, CapitalOutstanding = 0;
                string strQRY = "SELECT IFNULL(sum(capital), 0) AS capital FROM micro_payme_summery  WHERE contra_code = '" + CusCode + "' AND p_type = 'DB' and p_status = 'D';";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    TotalCapital = Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["capital"]);
                    CapitalOutstanding = LoanAmount - TotalCapital;
                }
                else
                {
                    CapitalOutstanding = 0;
                }
                return CapitalOutstanding;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Future Interest 
        private decimal FutureInterest(string CusCode, decimal InterestAmount)
        {
            try
            {
                decimal TotalInterest = 0, FutureInterest = 0;
                string strQRY = "SELECT IFNULL(sum(interest), 0) AS capital FROM micro_payme_summery  WHERE contra_code = '" + CusCode + "' AND p_type = 'DB' and p_status = 'D';";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    TotalInterest = Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["capital"]);
                    FutureInterest = InterestAmount - TotalInterest;
                }
                else
                {
                    FutureInterest = 0;
                }
                return FutureInterest;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Loan Stock
        private decimal LoanStock(string CusCode, decimal LoanAmount)
        {
            try
            {
                decimal TotalCapital = 0, LoanStock = 0;
                string strQRY = "SELECT IFNULL(sum(capital), 0) AS capital FROM micro_payme_summery  WHERE contra_code = '" + CusCode + "' AND p_type = 'WI' and p_status = 'D';";
                DataSet dsAllData = cls_Connection.getDataSet(strQRY);
                if (dsAllData.Tables[0].Rows.Count > 0)
                {
                    TotalCapital = Convert.ToDecimal(dsAllData.Tables[0].Rows[0]["capital"]);
                    LoanStock = LoanAmount - TotalCapital;
                }
                else
                {
                    LoanStock = 0;
                }
                return LoanStock;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected void ccsetup(string CityCode)
        {
            try
            {
                string strcitycode = CityCode;
                string strconCode;

                dsCCode = cls_Connection.getDataSet("select max(idmicro_basic_detail) from micro_basic_detail");
                if (dsCCode.Tables[0].Rows[0][0].ToString() != "")
                {
                    string strVal = dsCCode.Tables[0].Rows[0][0].ToString();
                    int intVal = (Convert.ToInt32(strVal) + 1);
                    strVal = intVal.ToString();
                    if (((intVal).ToString()).Length < 2)
                        strVal = "00000" + strVal;
                    else if (((intVal).ToString()).Length < 3)
                        strVal = "0000" + strVal;
                    else if (((intVal).ToString()).Length < 4)
                        strVal = "000" + strVal;
                    else if (((intVal).ToString()).Length < 5)
                        strVal = "00" + strVal;
                    else if (((intVal).ToString()).Length < 6)
                        strVal = "0" + strVal;
                    else
                    { }
                    strconCode = strcitycode + "/MF/" + strVal;
                    hidCC = strconCode;
                }
                else
                {
                    strconCode = strcitycode + "/MF/" + "000001";
                    hidCC = strconCode;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Save()
        {
            try
            {
                lblMsg.Text = "";

                string strloginID = Session["NIC"].ToString();

                DataSet dtData = cls_Connection.getDataSet("select * from micro_basic_detail where contract_code = '" + lblConCode.Text + "';");
                //Create Contract Code
                string Branch = dtData.Tables[0].Rows[0]["city_code"].ToString();
                ccsetup(Branch);
                //CO/MF/000001/1
                string NIC = dtData.Tables[0].Rows[0]["nic"].ToString();
                DataSet dtCount = cls_Connection.getDataSet("select count(b.nic) + 1 AS Count from micro_basic_detail b inner join micro_loan_details l on b.contract_code = l.contra_code where nic = '" + NIC + "' and l.loan_approved = 'Y' and l.loan_sta != 'C' and chequ_no != null;");
                if (dtCount.Tables[0].Rows[0][0].ToString() != "")
                {
                    hidCC = hidCC + "/" + dtCount.Tables[0].Rows[0][0].ToString();
                }

                // Insert Basic Details-----------------------------------------------------------------

                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_basic_detail(contract_code,ca_code,nic,city_code,society_id,province,gs_ward,full_name,initial_name,other_name,marital_status,education,land_no,mobile_no,p_address,client_id,inspection_date,create_user_id,user_ip,date_time,village,root_id,cli_photo,bb_photo,team_id,promisers_id,promiser_id_2)VALUES(@contract_code,@ca_code,@nic,@city_code,@society_id,@province,@gs_ward,@full_name,@initial_name,@other_name,@marital_status,@education,@land_no,@mobile_no,@p_address,@client_id,@inspection_date,@create_user_id,@user_ip,@date_time,@village,@root_id,@cli_photo,@bb_photo,@team_id,@promisers_id,@promiser_id_2);");

                #region Get Values
                string strIp = Request.UserHostAddress;
                string strCC = hidCC;

                int intVal;
                DataSet dtCCodeID = cls_Connection.getDataSet("select max(idmicro_basic_detail) from micro_basic_detail");
                if (dtCCodeID.Tables[0].Rows[0][0].ToString() != "")
                {
                    string strVal = dtCCodeID.Tables[0].Rows[0][0].ToString();

                    intVal = (Convert.ToInt32(strVal) + 1);
                }
                else
                {
                    intVal = 1;
                }

                string strNewImaID = Convert.ToString(intVal);

                string hf1, hf2;
                hf1 = "";

                hf2 = "";

                string strNIC, strCityCode, strVillage, strSoNumber, strProvince, strGSWard, strFullName, strIniName, strOName, strMaStatus;
                string strEducation, strTNumber, strMobNo, strAddress, strCACodeNew, strInspDate, strDateTime, strRootID, strPromiser2;

                strCACodeNew = dtData.Tables[0].Rows[0]["ca_code"].ToString();
                strTeamNo = dtData.Tables[0].Rows[0]["team_id"].ToString();
                strPromiserID = dtData.Tables[0].Rows[0]["promisers_id"].ToString();
                strPromiser2 = dtData.Tables[0].Rows[0]["promiser_id_2"].ToString();
                strNIC = dtData.Tables[0].Rows[0]["nic"].ToString();
                strCityCode = dtData.Tables[0].Rows[0]["city_code"].ToString();
                strVillage = dtData.Tables[0].Rows[0]["village"].ToString();
                strSoNumber = dtData.Tables[0].Rows[0]["society_id"].ToString();
                strProvince = dtData.Tables[0].Rows[0]["province"].ToString();
                strGSWard = dtData.Tables[0].Rows[0]["gs_ward"].ToString();
                strFullName = dtData.Tables[0].Rows[0]["full_name"].ToString();
                strIniName = dtData.Tables[0].Rows[0]["initial_name"].ToString();
                strOName = dtData.Tables[0].Rows[0]["other_name"].ToString();
                strRootID = dtData.Tables[0].Rows[0]["root_id"].ToString();
                strMaStatus = dtData.Tables[0].Rows[0]["marital_status"].ToString();
                strEducation = dtData.Tables[0].Rows[0]["education"].ToString();
                strTNumber = dtData.Tables[0].Rows[0]["land_no"].ToString();
                strMobNo = dtData.Tables[0].Rows[0]["mobile_no"].ToString();
                strAddress = dtData.Tables[0].Rows[0]["p_address"].ToString();
                strInspDate = dtData.Tables[0].Rows[0]["inspection_date"].ToString();
                strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                hf1 = dtData.Tables[0].Rows[0]["cli_photo"].ToString();
                hf2 = dtData.Tables[0].Rows[0]["bb_photo"].ToString();
                #endregion

                #region DeclarareParamerts
                cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@ca_code", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@nic", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@city_code", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@society_id", MySqlDbType.VarChar, 6);
                cmdInsert.Parameters.Add("@province", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@gs_ward", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@full_name", MySqlDbType.VarChar, 100);
                cmdInsert.Parameters.Add("@initial_name", MySqlDbType.VarChar, 100);
                cmdInsert.Parameters.Add("@other_name", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@marital_status", MySqlDbType.VarChar, 1);
                cmdInsert.Parameters.Add("@education", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@land_no", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@mobile_no", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@p_address", MySqlDbType.VarChar, 255);
                cmdInsert.Parameters.Add("@team_id", MySqlDbType.VarChar, 2);
                cmdInsert.Parameters.Add("@client_id", MySqlDbType.VarChar, 2);
                cmdInsert.Parameters.Add("@inspection_date", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@create_user_id", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@promisers_id", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@village", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@root_id", MySqlDbType.VarChar, 1);
                cmdInsert.Parameters.Add("@cli_photo", MySqlDbType.VarChar, 200);
                cmdInsert.Parameters.Add("@bb_photo", MySqlDbType.VarChar, 200);
                cmdInsert.Parameters.Add("@promiser_id_2", MySqlDbType.VarChar, 12);
                #endregion

                #region AssignParameters
                cmdInsert.Parameters["@contract_code"].Value = strCC;
                cmdInsert.Parameters["@ca_code"].Value = strCACodeNew;
                cmdInsert.Parameters["@nic"].Value = strNIC;
                cmdInsert.Parameters["@city_code"].Value = strCityCode;
                cmdInsert.Parameters["@society_id"].Value = strSoNumber;
                cmdInsert.Parameters["@province"].Value = strProvince;
                cmdInsert.Parameters["@gs_ward"].Value = strGSWard;
                cmdInsert.Parameters["@full_name"].Value = strFullName;
                cmdInsert.Parameters["@initial_name"].Value = strIniName;
                cmdInsert.Parameters["@other_name"].Value = strOName;
                cmdInsert.Parameters["@marital_status"].Value = strMaStatus;
                cmdInsert.Parameters["@education"].Value = strEducation;
                cmdInsert.Parameters["@land_no"].Value = strTNumber;
                cmdInsert.Parameters["@mobile_no"].Value = strMobNo;
                cmdInsert.Parameters["@p_address"].Value = strAddress;
                cmdInsert.Parameters["@team_id"].Value = strTeamNo;
                cmdInsert.Parameters["@client_id"].Value = strClientID;
                cmdInsert.Parameters["@inspection_date"].Value = strInspDate;
                cmdInsert.Parameters["@create_user_id"].Value = strloginID;
                cmdInsert.Parameters["@user_ip"].Value = strIp;
                cmdInsert.Parameters["@date_time"].Value = strDateTime;
                cmdInsert.Parameters["@promisers_id"].Value = strPromiserID;
                cmdInsert.Parameters["@village"].Value = strVillage;
                cmdInsert.Parameters["@root_id"].Value = strRootID;
                cmdInsert.Parameters["@cli_photo"].Value = hf1;
                cmdInsert.Parameters["@bb_photo"].Value = hf2;
                cmdInsert.Parameters["@promiser_id_2"].Value = strPromiser2;
                #endregion

                try
                {
                    int i = objDBTask.insertEditData(cmdInsert);
                    if (i == 1)
                    {
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured";
                    }
                }
                catch (Exception ex)
                {
                }

                //Insert Loan Details ---------------------------------------------------------

                DataSet dtDataL = cls_Connection.getDataSet("select * from micro_loan_details where contra_code = '" + lblConCode.Text + "';");

                MySqlCommand cmdInsertLDQRY = new MySqlCommand("INSERT INTO micro_loan_details(contra_code,loan_amount,service_charges,other_charges,interest_rate,interest_amount,period,monthly_instollment,created_on,created_user_nic,created_user_ip,loan_approved,acc_name,branch_code,acc_number,bank_code,registration_fee,walfare_fee,reg_approval)VALUES(@contra_code,@loan_amount,@service_charges,@other_charges,@interest_rate,@interest_amount,@period,@monthly_instollment,@created_on,@created_user_nic,@created_user_ip,@loan_approved,@acc_name,@branch_code,@acc_number,@bank_code,@registration_fee,@walfare_fee,'Y');");

                string strLDContrCode, strLDLAmount, strRegistrationFee, strWalfairFee;
                string strLDSerCharg, strLDOCharg, strLDInRate, strLDInAmount, strLDPeriod, strLDMonInsto, strAccName, strAccBranch, strAccNumber, strBank;

                #region Assign Values
                strLDContrCode = strCC;
                strLDLAmount = txtRSLoanAmount.Text.Trim();
                strLDSerCharg = dtDataL.Tables[0].Rows[0]["service_charges"].ToString();
                strLDOCharg = "0.00";
                strLDInRate = txtRSInterestRate.Text.Trim();
                strLDPeriod = txtReschedulePeriod.Text.Trim();
                strLDMonInsto = txtRSLoanInstallment.Text.Trim();
                strRegistrationFee = dtDataL.Tables[0].Rows[0]["registration_fee"].ToString();
                strWalfairFee = dtDataL.Tables[0].Rows[0]["walfare_fee"].ToString();

                decimal decLA = Convert.ToDecimal(strLDLAmount);
                decimal decIR = Convert.ToDecimal(strLDInRate);
                decimal decIA = (decLA * decIR) / 100;

                decimal decP = Convert.ToDecimal(strLDPeriod);

                //One Week
                decimal decOneMonth = (decIA / 48) * decP;

                strLDInAmount = Convert.ToString(decOneMonth);

                strAccBranch = dtDataL.Tables[0].Rows[0]["acc_branch"].ToString();
                strAccName = dtDataL.Tables[0].Rows[0]["acc_name"].ToString();
                strAccNumber = dtDataL.Tables[0].Rows[0]["acc_number"].ToString();
                strBank = dtDataL.Tables[0].Rows[0]["bank_name"].ToString();
                #endregion

                #region Assign Parameters
                cmdInsertLDQRY.Parameters.Add("@contra_code", MySqlDbType.VarChar, 10);
                cmdInsertLDQRY.Parameters.Add("@loan_amount", MySqlDbType.Decimal, 9);
                cmdInsertLDQRY.Parameters.Add("@service_charges", MySqlDbType.Decimal, 9);
                cmdInsertLDQRY.Parameters.Add("@other_charges", MySqlDbType.Decimal, 9);
                cmdInsertLDQRY.Parameters.Add("@interest_rate", MySqlDbType.VarChar, 4);
                cmdInsertLDQRY.Parameters.Add("@interest_amount", MySqlDbType.Decimal, 9);
                cmdInsertLDQRY.Parameters.Add("@period", MySqlDbType.VarChar, 45);
                cmdInsertLDQRY.Parameters.Add("@monthly_instollment", MySqlDbType.Decimal, 9);
                cmdInsertLDQRY.Parameters.Add("@created_on", MySqlDbType.VarChar, 45);
                cmdInsertLDQRY.Parameters.Add("@created_user_nic", MySqlDbType.VarChar, 10);
                cmdInsertLDQRY.Parameters.Add("@created_user_ip", MySqlDbType.VarChar, 20);
                cmdInsertLDQRY.Parameters.Add("@loan_approved", MySqlDbType.VarChar, 1);
                cmdInsertLDQRY.Parameters.Add("@acc_name", MySqlDbType.VarChar, 45);
                cmdInsertLDQRY.Parameters.Add("@branch_code", MySqlDbType.VarChar, 3);
                cmdInsertLDQRY.Parameters.Add("@acc_number", MySqlDbType.VarChar, 15);
                cmdInsertLDQRY.Parameters.Add("@bank_code", MySqlDbType.VarChar, 4);
                cmdInsertLDQRY.Parameters.Add("@registration_fee", MySqlDbType.Decimal, 10);
                cmdInsertLDQRY.Parameters.Add("@walfare_fee", MySqlDbType.Decimal, 10);
                #endregion

                #region Declare Parametes
                cmdInsertLDQRY.Parameters["@contra_code"].Value = strLDContrCode;
                cmdInsertLDQRY.Parameters["@loan_amount"].Value = strLDLAmount;
                cmdInsertLDQRY.Parameters["@service_charges"].Value = strLDSerCharg;
                cmdInsertLDQRY.Parameters["@other_charges"].Value = strLDOCharg;
                cmdInsertLDQRY.Parameters["@interest_rate"].Value = strLDInRate;
                cmdInsertLDQRY.Parameters["@interest_amount"].Value = strLDInAmount;
                cmdInsertLDQRY.Parameters["@period"].Value = strLDPeriod;
                cmdInsertLDQRY.Parameters["@monthly_instollment"].Value = strLDMonInsto;
                cmdInsertLDQRY.Parameters["@created_on"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                cmdInsertLDQRY.Parameters["@created_user_nic"].Value = strloginID;
                cmdInsertLDQRY.Parameters["@created_user_ip"].Value = strIp;
                cmdInsertLDQRY.Parameters["@loan_approved"].Value = "P";
                cmdInsertLDQRY.Parameters["@acc_name"].Value = strAccName;
                cmdInsertLDQRY.Parameters["@branch_code"].Value = strAccBranch;
                cmdInsertLDQRY.Parameters["@acc_number"].Value = strAccNumber;
                cmdInsertLDQRY.Parameters["@bank_code"].Value = strBank;
                cmdInsertLDQRY.Parameters["@registration_fee"].Value = strRegistrationFee;
                cmdInsertLDQRY.Parameters["@walfare_fee"].Value = strWalfairFee;
                #endregion

                try
                {
                    int f;
                    f = objDBTask.insertEditData(cmdInsertLDQRY);
                    if (f == 1)
                    {
                        lblMsg.Text = "Successfully Added.";
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {
                }

                //Insert Family Details----------------------------------------------------------------

                DataSet dtDataF = cls_Connection.getDataSet("select * from micro_family_details where contract_code = '" + lblConCode.Text + "';");

                MySqlCommand cmdInsertF = new MySqlCommand("INSERT INTO micro_family_details(contract_code,spouse_nic,mobileno,spouse_name,occupation,no_of_fami_memb,education,dependers,spouse_income,other_fami_mem_income,moveable_property,immoveable_property,saving,create_user_nic,user_ip,date_time) VALUES(@contract_code,@spouse_nic,@mobileno,@spouse_name,@occupation,@no_of_fami_memb,@education,@dependers,@spouse_income,@other_fami_mem_income,@moveable_property,@immoveable_property,@saving,@create_user_nic,@user_ip,@date_time);");

                #region Get Values
                strIp = Request.UserHostAddress;
                string strCCode = strCC;
                string strCACode = strCACodeNew;
                string strSNIC = dtDataF.Tables[0].Rows[0]["spouse_nic"].ToString();
                string strmobileno = dtDataF.Tables[0].Rows[0]["mobileno"].ToString();
                string strSPName = dtDataF.Tables[0].Rows[0]["spouse_name"].ToString();
                string strOcc = dtDataF.Tables[0].Rows[0]["occupation"].ToString();
                string strNFM = dtDataF.Tables[0].Rows[0]["no_of_fami_memb"].ToString();
                string strEdu = dtDataF.Tables[0].Rows[0]["education"].ToString();
                string strDep = dtDataF.Tables[0].Rows[0]["dependers"].ToString();
                string strSPIncome = dtDataF.Tables[0].Rows[0]["spouse_income"].ToString();
                string strOFMIncome = dtDataF.Tables[0].Rows[0]["other_fami_mem_income"].ToString();
                string strMP = dtDataF.Tables[0].Rows[0]["moveable_property"].ToString();
                string strIMPro = dtDataF.Tables[0].Rows[0]["immoveable_property"].ToString();
                string strsaving = dtDataF.Tables[0].Rows[0]["saving"].ToString();

                #endregion

                #region Declare Parameters
                cmdInsertF.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                cmdInsertF.Parameters.Add("@spouse_nic", MySqlDbType.VarChar, 10);
                cmdInsertF.Parameters.Add("@mobileno", MySqlDbType.VarChar, 10);
                cmdInsertF.Parameters.Add("@spouse_name", MySqlDbType.VarChar, 100);
                cmdInsertF.Parameters.Add("@occupation", MySqlDbType.VarChar, 45);
                cmdInsertF.Parameters.Add("@no_of_fami_memb", MySqlDbType.VarChar, 2);
                cmdInsertF.Parameters.Add("@education", MySqlDbType.VarChar, 45);
                cmdInsertF.Parameters.Add("@dependers", MySqlDbType.VarChar, 2);
                cmdInsertF.Parameters.Add("@spouse_income", MySqlDbType.Decimal, 10);
                cmdInsertF.Parameters.Add("@other_fami_mem_income", MySqlDbType.Decimal, 10);
                cmdInsertF.Parameters.Add("@moveable_property", MySqlDbType.Decimal, 10);
                cmdInsertF.Parameters.Add("@immoveable_property", MySqlDbType.Decimal, 10);
                cmdInsertF.Parameters.Add("@saving", MySqlDbType.Decimal, 10);
                cmdInsertF.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
                cmdInsertF.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsertF.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                #endregion

                #region Assign Values
                cmdInsertF.Parameters["@contract_code"].Value = strCCode;
                cmdInsertF.Parameters["@spouse_nic"].Value = strSNIC;
                cmdInsertF.Parameters["@mobileno"].Value = strmobileno;
                cmdInsertF.Parameters["@spouse_name"].Value = strSPName;
                cmdInsertF.Parameters["@occupation"].Value = strOcc;
                cmdInsertF.Parameters["@no_of_fami_memb"].Value = strNFM;
                cmdInsertF.Parameters["@education"].Value = strEdu;
                cmdInsertF.Parameters["@dependers"].Value = strDep;
                cmdInsertF.Parameters["@spouse_income"].Value = strSPIncome == "" ? 0 : Convert.ToDecimal(strSPIncome);
                cmdInsertF.Parameters["@other_fami_mem_income"].Value = strOFMIncome == "" ? 0 : Convert.ToDecimal(strOFMIncome);
                cmdInsertF.Parameters["@moveable_property"].Value = strMP == "" ? 0 : Convert.ToDecimal(strMP);
                cmdInsertF.Parameters["@immoveable_property"].Value = strIMPro == "" ? 0 : Convert.ToDecimal(strIMPro);
                cmdInsertF.Parameters["@saving"].Value = strsaving == "" ? 0 : Convert.ToDecimal(strsaving);
                cmdInsertF.Parameters["@create_user_nic"].Value = strloginID;
                cmdInsertF.Parameters["@user_ip"].Value = strIp;
                cmdInsertF.Parameters["@date_time"].Value = strDateTime;
                #endregion

                try
                {
                    int i = objDBTask.insertEditData(cmdInsertF);
                    if (i == 1)
                    {
                        lblMsg.Text = "Success";
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured";
                    }
                }
                catch (Exception ex)
                {
                }

                //Insert Business Details--------------------------------------------------------------------------

                DataSet dtDataB = cls_Connection.getDataSet("select * from micro_business_details where contract_code = '" + lblConCode.Text + "';");

                MySqlCommand cmdInsertB = new MySqlCommand("INSERT INTO micro_business_details(contract_code,business_name,busi_duration,busi_address,busi_income,other_income,total_income,direct_cost,indirect_cost,other_expenses,total_expenses,profit_lost,family_expenses,net_income,create_user_nic,user_ip,date_time)VALUES(@contract_code,@business_name,@busi_duration,@busi_address,@busi_income,@other_income,@total_income,@direct_cost,@indirect_cost,@other_expenses,@total_expenses,@profit_lost,@family_expenses,@net_income,@create_user_nic,@user_ip,@date_time)");

                #region GetValues
                string strBN = dtDataB.Tables[0].Rows[0]["business_name"].ToString();
                string strDur = dtDataB.Tables[0].Rows[0]["busi_duration"].ToString();
                string strBAdd = dtDataB.Tables[0].Rows[0]["busi_address"].ToString();
                string strBIn = dtDataB.Tables[0].Rows[0]["busi_income"].ToString();
                string strOIn = dtDataB.Tables[0].Rows[0]["other_income"].ToString();
                string strTotalIn = dtDataB.Tables[0].Rows[0]["total_income"].ToString();
                string strDcost = dtDataB.Tables[0].Rows[0]["direct_cost"].ToString();
                string strICost = dtDataB.Tables[0].Rows[0]["indirect_cost"].ToString();
                string strOEx = dtDataB.Tables[0].Rows[0]["other_expenses"].ToString();
                string strTotalEx = dtDataB.Tables[0].Rows[0]["total_expenses"].ToString();
                string strBPL = dtDataB.Tables[0].Rows[0]["profit_lost"].ToString();
                string strFEx = dtDataB.Tables[0].Rows[0]["family_expenses"].ToString();
                string strNet = dtDataB.Tables[0].Rows[0]["net_income"].ToString();
                #endregion

                #region DeclareValues
                cmdInsertB.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                cmdInsertB.Parameters.Add("@business_name", MySqlDbType.VarChar, 100);
                cmdInsertB.Parameters.Add("@busi_duration", MySqlDbType.VarChar, 45);
                cmdInsertB.Parameters.Add("@busi_address", MySqlDbType.VarChar, 255);
                cmdInsertB.Parameters.Add("@busi_income", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@other_income", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@total_income", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@direct_cost", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@indirect_cost", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@other_expenses", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@total_expenses", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@profit_lost", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@family_expenses", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@net_income", MySqlDbType.Decimal, 10);
                cmdInsertB.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
                cmdInsertB.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsertB.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                #endregion

                #region AssignValues
                cmdInsertB.Parameters["@contract_code"].Value = strCC;
                cmdInsertB.Parameters["@business_name"].Value = strBN;
                cmdInsertB.Parameters["@busi_duration"].Value = strDur;
                cmdInsertB.Parameters["@busi_address"].Value = strBAdd;
                cmdInsertB.Parameters["@busi_income"].Value = strBIn;
                cmdInsertB.Parameters["@other_income"].Value = strOIn;
                cmdInsertB.Parameters["@total_income"].Value = strTotalIn;
                cmdInsertB.Parameters["@direct_cost"].Value = strDcost;
                cmdInsertB.Parameters["@indirect_cost"].Value = strICost;
                cmdInsertB.Parameters["@other_expenses"].Value = strOEx;
                cmdInsertB.Parameters["@total_expenses"].Value = strTotalEx;
                cmdInsertB.Parameters["@profit_lost"].Value = strBPL;
                cmdInsertB.Parameters["@family_expenses"].Value = strFEx;
                cmdInsertB.Parameters["@net_income"].Value = strNet;
                cmdInsertB.Parameters["@create_user_nic"].Value = strloginID;
                cmdInsertB.Parameters["@user_ip"].Value = strIp;
                cmdInsertB.Parameters["@date_time"].Value = strDateTime;
                #endregion

                try
                {
                    int i = objDBTask.insertEditData(cmdInsertB);
                    if (i == 1)
                    {
                        MySqlCommand cmdUpdateChequ = new MySqlCommand("Update micro_loan_details set loan_sta = 'R' where contra_code = '" + lblConCode.Text + "' and loan_approved = 'Y';");
                        int iReS;
                        iReS = objDBTask.insertEditData(cmdUpdateChequ);

                        Clear();
                        txtCC.Text = "";
                        lblMsg.Text = "Successfully Rescheduled.";
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception x)
            {
                lblMsg.Text = x.ToString();
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            Load();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void txtRSInterestRate_TextChanged(object sender, EventArgs e)
        {
            CalculateRSInstallment();
        }

        private void CalculateRSInstallment()
        {
            try
            {
                decimal InterestRate = 0, RSLoanAmount = 0;
                int Period = 0;
                RSLoanAmount = txtRSLoanAmount.Text == "" ? 0 : Convert.ToDecimal(txtRSLoanAmount.Text);
                InterestRate = txtRSInterestRate.Text == "" ? 0 : Convert.ToDecimal(txtRSInterestRate.Text);
                Period = txtReschedulePeriod.Text == "" ? 0 : Convert.ToInt32(txtReschedulePeriod.Text);

                decimal decToInte = (RSLoanAmount * InterestRate) / 100;

                //One Week
                decimal decToPeriod = (decToInte / 48) * Period;

                decimal decMI = (RSLoanAmount + decToPeriod) / Period;
                decimal round = decimal.Round(decMI, 2, MidpointRounding.AwayFromZero);

                string strMI = Convert.ToString(round);

                txtRSLoanInstallment.Text = strMI;
            }
            catch (Exception)
            {
            }
        }

        protected void txtReschedulePeriod_TextChanged(object sender, EventArgs e)
        {
            CalculateRSInstallment();
        }
    }
}
