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
    public partial class Loan_Details : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();
        string strloginID, strIp;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    string strCC = Request.QueryString["CC"];
                    string strCAC = Request.QueryString["CA"];
                    //string strCC = "CO/CS/000004";
                    //string strCAC = "CO/1/01/02";

                    if (strCC != null && strCAC != null)
                    {
                        txtCC.Text = strCC;
                        txtCACode.Text = strCAC;

                        DataSet dsGetNIC = objDBTask.selectData("select nic from micro_basic_detail where contract_code = '" + strCC + "';");
                        if (dsGetNIC.Tables[0].Rows.Count > 0)
                        {
                            string strNIC = dsGetNIC.Tables[0].Rows[0][0].ToString();
                            DataSet dsGetNoofLoan = objDBTask.selectData("select count(nic) from micro_basic_detail b, micro_loan_details l where b.contract_code = l.contra_code and b.nic = '" + strNIC + "' and l.chequ_no != '' and l.loan_approved = 'Y' and l.loan_sta != 'C';");
                            if(dsGetNoofLoan.Tables[0].Rows.Count > 0)
                            {
                                string strCount = dsGetNoofLoan.Tables[0].Rows[0][0].ToString();
                                int intCount = Convert.ToInt32(strCount);
                                if (strCount == "0")
                                {
                                    txtLDIntRate.Text = "28";
                                    txtRegistrationFee.Text = "500.00";
                                    txtWalfareFee.Text = "500.00";
                                    btnLDNext.Enabled = true;
                                    btnUpdate.Enabled = false;
                                }
                                else if (intCount == 1)
                                {
                                    txtLDIntRate.Text = "26";
                                }
                                else if (intCount >= 2)
                                {
                                    txtLDIntRate.Text = "24";
                                }
                            }

                            btnLDNext.Enabled = true;
                            btnUpdate.Enabled = false;
                        }
                        else
                        {
                            btnLDNext.Enabled = false;
                            btnUpdate.Enabled = false;
                            lblLDMsg.Text = "Invalid Contract Code.";
                        }
                        //btnLDNext.Enabled = true;
                        txtCC.Enabled = false;
                        //btnLDNext.Enabled = true;
                    }
                    else
                    {
                        txtCC.Enabled = true;
                        btnLDNext.Enabled = false;
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
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }

        protected void Clear()
        {
            //txtCC.Text = "";
            txtCACode.Text = "";
            //txtLDABranch.Text = "";

            if (cmbBranch.Items.Count > 0)
            {
                cmbBranch.Items.Clear();
            }
            txtLDAccName.Text = "";
            txtLDANumber.Text = "";
            //txtLDBName.Text = "";
            //if (cmbBankName.Items.Count > 0)
            //{
            //    cmbBankName.Items.Clear();
            //}
            cmbBankName.SelectedIndex = 0;
            //txtLDIntRate.Text = "";
            txtLDLAmount.Text = "";
            txtLDMInstoll.Text = "";
            txtLDOtherCharg.Text = "";
            cmbPeriod.SelectedIndex = 0;
            txtLDSerCharges.Text = "";
            txtBankCode.Text = "";
            txtBranchCode.Text = "";
            txtWalfareFee.Text = "";
            txtRegistrationFee.Text = "";
        }

        protected void btnLDNext_Click(object sender, EventArgs e)
        {
            lblLDMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Contract Code.";
            }
            else if (txtCACode.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Capital Aplicant Code.";
            }
            else if (txtLDLAmount.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Loan Amount.";
            }
            else if (txtLDOtherCharg.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Other Charges.";
            }
            else if (txtLDIntRate.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Interest Rate.";
            }
            else if (cmbPeriod.SelectedIndex != 0)
            {
                lblLDMsg.Text = "Please enter Loan Period.";
            }
            else if (txtLDMInstoll.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Instollment.";
            }
            else if (txtLDAccName.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Account Name.";
            }
            else if (cmbBranch.SelectedIndex == 0)
            {
                lblLDMsg.Text = "Please select Account branch.";
            }
            else if (txtLDANumber.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Account Number.";
            }
            else if (cmbBankName.SelectedIndex == 0)
            {
                lblLDMsg.Text = "Please select Bank Name.";
            }
            else if (txtRegistrationFee.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Registration Fee.";
            }
            else if (txtWalfareFee.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Walfare Fee.";
            }
            else
            {
                strloginID = Session["NIC"].ToString();
                string strIp = Request.UserHostAddress;

                MySqlCommand cmdInsertLDQRY = new MySqlCommand("INSERT INTO micro_loan_details(contra_code,loan_amount,service_charges,other_charges,interest_rate,interest_amount,period,monthly_instollment,created_on,created_user_nic,created_user_ip,loan_approved,acc_name,branch_code,acc_number,bank_code,registration_fee,walfare_fee)VALUES(@contra_code,@loan_amount,@service_charges,@other_charges,@interest_rate,@interest_amount,@period,@monthly_instollment,@created_on,@created_user_nic,@created_user_ip,@loan_approved,@acc_name,@branch_code,@acc_number,@bank_code,@registration_fee,@walfare_fee);");

                string strLDContrCode, strLDLAmount, strRegistrationFee, strWalfairFee;
                string strLDSerCharg, strLDOCharg, strLDInRate, strLDInAmount, strLDPeriod, strLDMonInsto, strAccName, strAccBranch, strAccNumber, strBank;

                #region Assign Values
                strLDContrCode = txtCC.Text.Trim();
                strLDLAmount = txtLDLAmount.Text.Trim();
                strLDSerCharg = txtLDSerCharges.Text.Trim();
                strLDOCharg = txtLDOtherCharg.Text.Trim();
                strLDInRate = txtLDIntRate.Text.Trim();
                strLDPeriod = cmbPeriod.SelectedItem.Value.ToString();
                strLDMonInsto = txtLDMInstoll.Text.Trim();
                strRegistrationFee = txtRegistrationFee.Text.Trim();
                strWalfairFee = txtWalfareFee.Text.Trim();

                decimal decLA = Convert.ToDecimal(strLDLAmount);
                decimal decIR = Convert.ToDecimal(strLDInRate);
                decimal decIA = (decLA * decIR) / 100;
                decimal decP = Convert.ToDecimal(strLDPeriod);

                //One Month
                //decimal decOneMonth = (decIA / 48) * decP;

                strLDInAmount = Convert.ToString(decIA);

                strAccBranch = txtBranchCode.Text.Trim();
                strAccName = txtLDAccName.Text.Trim();
                strAccNumber = txtLDANumber.Text.Trim();
                strBank = txtBankCode.Text.Trim();
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

                #region DEclare Parametes
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
                        Clear();
                        txtCC.Text = "";
                        btnLDNext.Enabled = false;
                        btnUpdate.Enabled = false;
                        lblLDMsg.Text = "Successfully Added.";
                    }
                    else
                    {
                        lblLDMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void txtLDLAmount_TextChanged(object sender, EventArgs e)
        {
            lblLDMsg.Text = "";
            if (txtLDLAmount.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Loan Amount.";
            }
            else
            {
                string strLAmount = txtLDLAmount.Text.Trim();
                decimal decLAmou = Convert.ToDecimal(strLAmount);

                string strSerCha;
                decimal decPras = 1;
                decimal decSerCha = (decLAmou * decPras) / 100;
                decimal decOriSerChar = decimal.Round(decSerCha, 2, MidpointRounding.AwayFromZero);
                strSerCha = Convert.ToString(decOriSerChar);
                

                //string strSerCha = Convert.ToString(decOriSerChar);
                txtLDSerCharges.Text = strSerCha;

                if (txtLDLAmount.Text.Trim() == "")
                {
                    lblLDMsg.Text = "Please enter Loan Amount.";
                }
                else if (txtLDIntRate.Text.Trim() == "")
                {
                    lblLDMsg.Text = "Please enter Interest Rate.";
                }
                else if (cmbPeriod.SelectedIndex != 0)
                {
                    lblLDMsg.Text = "Please select Loan Period.";
                }
                else
                {
                    string strLDLAmount = txtLDLAmount.Text.Trim();
                    //string strLDOCharg = txtLDOtherCharg.Text.Trim();
                    string strLDInRate = txtLDIntRate.Text.Trim();
                    string strLDPeriod = cmbPeriod.SelectedItem.Value.ToString();

                    decimal decLA = Convert.ToDecimal(strLDLAmount);
                    //decimal decOC = Convert.ToDecimal(strLDOCharg);
                    decimal decIR = Convert.ToDecimal(strLDInRate);
                    decimal decP = Convert.ToDecimal(strLDPeriod);

                    //decimal decToSeCh = (decLA * decSC) / 100;
                    decimal decToInte = (decLA * decIR) / 100;

                    //One Month
                    //decimal decToPeriod = (decToInte / 240) * decP;


                    decimal decMI = (decLA + decToInte) / decP;
                    decimal round = decimal.Round(decMI, 2, MidpointRounding.AwayFromZero);

                    string strMI = Convert.ToString(round);

                    txtLDMInstoll.Text = strMI;
                }
            }
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            lblLDMsg.Text = "";
            Clear();
            if (txtCC.Text.Trim() != "")
            {
                string strCoC = txtCC.Text.Trim();
                DataSet dtGDeta = objDBTask.selectData("select * from micro_loan_details where contra_code = '" + strCoC + "';");
                if (dtGDeta.Tables[0].Rows.Count > 0)
                {
                    DataSet dtRBFLoanDeta = objDBTask.selectData("select loan_approved from micro_loan_details where contra_code='" + txtCC.Text.Trim() + "';");
                    if (dtRBFLoanDeta.Tables[0].Rows.Count > 0)
                    {
                        if (dtRBFLoanDeta.Tables[0].Rows[0]["loan_approved"].ToString() == "Y")
                        {
                            btnLDNext.Enabled = false;
                            btnUpdate.Enabled = false;
                            lblLDMsg.Text = "Loan already approved, can't edit.";
                        }
                        else
                        {
                            string strBank = dtGDeta.Tables[0].Rows[0]["bank_code"].ToString();
                            string strBranchCode = dtGDeta.Tables[0].Rows[0]["branch_code"].ToString();

                            DataSet dsGetBranch = objDBTask.selectData("select * from bankbranch_tbl where BankCode = '" + strBank + "' ORDER BY 2;");
                            cmbBranch.Items.Add("");
                            for (int i = 0; i < dsGetBranch.Tables[0].Rows.Count; i++)
                            {
                                cmbBranch.Items.Add(dsGetBranch.Tables[0].Rows[i][2].ToString());
                                cmbBranch.Items[i + 1].Value = dsGetBranch.Tables[0].Rows[i][1].ToString();
                            }

                            cmbBranch.Text = strBranchCode;
                            txtBranchCode.Text = strBranchCode;
                            txtLDAccName.Text = dtGDeta.Tables[0].Rows[0]["acc_name"].ToString();
                            txtLDANumber.Text = dtGDeta.Tables[0].Rows[0]["acc_number"].ToString();
                            cmbBankName.Text = strBank;
                            txtBankCode.Text = strBank;
                            txtLDIntRate.Text = dtGDeta.Tables[0].Rows[0]["interest_rate"].ToString();
                            txtLDLAmount.Text = dtGDeta.Tables[0].Rows[0]["loan_amount"].ToString();
                            txtLDMInstoll.Text = dtGDeta.Tables[0].Rows[0]["monthly_instollment"].ToString();
                            txtLDOtherCharg.Text = dtGDeta.Tables[0].Rows[0]["other_charges"].ToString();
                            cmbPeriod.Text = dtGDeta.Tables[0].Rows[0]["period"].ToString();
                            txtLDSerCharges.Text = dtGDeta.Tables[0].Rows[0]["service_charges"].ToString();
                            txtRegistrationFee.Text = dtGDeta.Tables[0].Rows[0]["registration_fee"].ToString();
                            txtWalfareFee.Text = dtGDeta.Tables[0].Rows[0]["walfare_fee"].ToString();

                            btnLDNext.Enabled = false;
                            btnUpdate.Enabled = true;
                        }
                    }
                    else
                    {
                        string strBank = dtGDeta.Tables[0].Rows[0]["bank_code"].ToString();
                        string strBranchCode = dtGDeta.Tables[0].Rows[0]["branch_code"].ToString();

                        DataSet dsGetBranch = objDBTask.selectData("select * from bankbranch_tbl where BankCode = '" + strBank + "' ORDER BY 2;");
                        cmbBranch.Items.Add("");
                        for (int i = 0; i < dsGetBranch.Tables[0].Rows.Count; i++)
                        {
                            cmbBranch.Items.Add(dsGetBranch.Tables[0].Rows[i][2].ToString());
                            cmbBranch.Items[i + 1].Value = dsGetBranch.Tables[0].Rows[i][1].ToString();
                        }
                        cmbBranch.Text = strBranchCode;
                        txtBranchCode.Text = strBranchCode;
                        txtLDAccName.Text = dtGDeta.Tables[0].Rows[0]["acc_name"].ToString();
                        txtLDANumber.Text = dtGDeta.Tables[0].Rows[0]["acc_number"].ToString();
                        cmbBankName.Text = strBank;
                        txtBankCode.Text = strBank;
                        txtLDIntRate.Text = dtGDeta.Tables[0].Rows[0]["interest_rate"].ToString();
                        txtLDLAmount.Text = dtGDeta.Tables[0].Rows[0]["loan_amount"].ToString();
                        txtLDMInstoll.Text = dtGDeta.Tables[0].Rows[0]["monthly_instollment"].ToString();
                        txtLDOtherCharg.Text = dtGDeta.Tables[0].Rows[0]["other_charges"].ToString();
                        cmbPeriod.Text = dtGDeta.Tables[0].Rows[0]["period"].ToString();
                        txtLDSerCharges.Text = dtGDeta.Tables[0].Rows[0]["service_charges"].ToString();
                        txtRegistrationFee.Text = dtGDeta.Tables[0].Rows[0]["registration_fee"].ToString();
                        txtWalfareFee.Text = dtGDeta.Tables[0].Rows[0]["walfare_fee"].ToString();

                        btnLDNext.Enabled = false;
                        btnUpdate.Enabled = true;
                    }
                }
                else
                {
                    DataSet dsChkCli = objDBTask.selectData("select * from micro_basic_detail where contract_code = '" + strCoC + "';");
                    if (dsChkCli.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsGetNIC = objDBTask.selectData("select nic from micro_basic_detail where contract_code = '" + strCoC + "';");
                        if (dsGetNIC.Tables[0].Rows.Count > 0)
                        {
                            string strNIC = dsGetNIC.Tables[0].Rows[0][0].ToString();
                            DataSet dsGetNoofLoan = objDBTask.selectData("select count(nic) from micro_basic_detail b, micro_loan_details l where b.contract_code = l.contra_code and b.nic = '" + strNIC + "' and l.chequ_no != '' and l.loan_approved = 'Y' and l.loan_sta != 'C';");
                            if (dsGetNoofLoan.Tables[0].Rows.Count > 0)
                            {
                                string strCount = dsGetNoofLoan.Tables[0].Rows[0][0].ToString();
                                int intCount = Convert.ToInt32(strCount);
                                if (strCount == "0")
                                {
                                    btnLDNext.Enabled = true;
                                    btnUpdate.Enabled = false;
                                    txtLDIntRate.Text = "28";
                                    txtWalfareFee.Text = "500.00";
                                    txtRegistrationFee.Text = "500.00";
                                }
                                else if (intCount == 1)
                                {
                                    txtLDIntRate.Text = "26";
                                }
                                else if (intCount >= 2)
                                {
                                    txtLDIntRate.Text = "24";
                                }
                            }

                            btnLDNext.Enabled = true;
                            btnUpdate.Enabled = false;
                        }
                        else
                        {
                            btnLDNext.Enabled = false;
                            btnUpdate.Enabled = false;
                            lblLDMsg.Text = "Invalid Contract Code.";
                        }

                        //btnLDNext.Enabled = true;
                        //btnUpdate.Enabled = false;
                    }
                    else
                    {
                        btnLDNext.Enabled = false;
                        btnUpdate.Enabled = false;
                        lblLDMsg.Text = "Invalid Contract Code.";
                    }
                }
            }
            else
            {
                lblLDMsg.Text = "Please enter Contract Code.";
                btnLDNext.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblLDMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Contract Code.";
            }
            else if (txtLDLAmount.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Loan Amount.";
            }
            else if (txtLDOtherCharg.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Other Charges.";
            }
            else if (txtLDIntRate.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Interest Rate.";
            }
            else if (cmbPeriod.SelectedIndex != 0)
            {
                lblLDMsg.Text = "Please enter Loan Period.";
            }
            else if (txtLDMInstoll.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Instollment.";
            }
            else if (txtRegistrationFee.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Registration Fee.";
            }
            else if (txtWalfareFee.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Welfare Fee.";
            }
            else if (txtLDAccName.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Account Name.";
            }
            else if (cmbBranch.SelectedIndex == 0)
            {
                lblLDMsg.Text = "Please enter Account branch.";
            }
            else if (txtLDANumber.Text.Trim() == "")
            {
                lblLDMsg.Text = "Please enter Account Number.";
            }
            else if (cmbBankName.SelectedIndex == 0)
            {
                lblLDMsg.Text = "Please enter Bank Name.";
            }
            else
            {
                if (txtCC.Text.Trim() != "")
                {
                    string strCoC = txtCC.Text.Trim();
                    DataSet dtGDeta = objDBTask.selectData("select * from micro_loan_details where contra_code = '" + strCoC + "';");
                    if (dtGDeta.Tables[0].Rows.Count > 0)
                    {
                        DataSet dtRBFLoanDeta = objDBTask.selectData("select loan_approved from micro_loan_details where contra_code='" + txtCC.Text.Trim() + "';");
                        if (dtRBFLoanDeta.Tables[0].Rows.Count > 0)
                        {
                            if (dtRBFLoanDeta.Tables[0].Rows[0]["loan_approved"].ToString() == "Y")
                            {
                                btnLDNext.Enabled = false;
                                btnUpdate.Enabled = false;
                                lblLDMsg.Text = "Loan already approved, can't edit.";
                            }
                            else
                            {
                                Update();
                            }
                        }
                        else
                        {
                            Update();
                        }
                    }
                    else
                    {
                        DataSet dsChkCli = objDBTask.selectData("select * from micro_basic_detail where contract_code = '" + strCoC + "';");
                        if (dsChkCli.Tables[0].Rows.Count > 0)
                        {
                            btnLDNext.Enabled = true;
                            btnUpdate.Enabled = false;
                        }
                        else
                        {
                            btnLDNext.Enabled = false;
                            btnUpdate.Enabled = false;
                            lblLDMsg.Text = "Invalid Contract Code.";
                        }
                    }
                }
                else
                {
                    lblLDMsg.Text = "Please enter Contract Code.";
                    btnLDNext.Enabled = false;
                    btnUpdate.Enabled = false;
                }
            }
        }

        protected void Update()
        {
            string strLDContrCode, strLDLAmount, strWelfa, strRegisFee;
            string strLDSerCharg, strLDOCharg, strLDInRate, strLDInAmount, strLDPeriod, strLDMonInsto, strAccName, strAccBranch, strAccNumber, strBank;

            #region Assign Values
            strLDContrCode = txtCC.Text.Trim();
            strLDLAmount = txtLDLAmount.Text.Trim();
            strLDSerCharg = txtLDSerCharges.Text.Trim();
            strLDOCharg = txtLDOtherCharg.Text.Trim();
            strLDInRate = txtLDIntRate.Text.Trim();
            strLDPeriod = cmbPeriod.SelectedItem.Value.ToString();
            strLDMonInsto = txtLDMInstoll.Text.Trim();
            strWelfa = txtWalfareFee.Text.Trim();
            strRegisFee = txtRegistrationFee.Text.Trim();

            decimal decLA = Convert.ToDecimal(strLDLAmount);
            decimal decIR = Convert.ToDecimal(strLDInRate);
            decimal decIA = (decLA * decIR) / 100;
            decimal decP = Convert.ToDecimal(strLDPeriod);

            //One Month
            //decimal decOneMonth = (decIA / 48) * decP;

            strLDInAmount = Convert.ToString(decIA);

            strAccBranch = txtBranchCode.Text.Trim(); 
            strAccName = txtLDAccName.Text.Trim();
            strAccNumber = txtLDANumber.Text.Trim();
            strBank = txtBankCode.Text.Trim();
            #endregion

            MySqlCommand cmdUpdateLDetails = new MySqlCommand("update micro_loan_details set loan_amount = '" + strLDLAmount + "',service_charges = '" + strLDSerCharg + "',other_charges = '" + strLDOCharg + "',interest_rate = '" + strLDInRate + "',interest_amount = '" + strLDInAmount + "',period = '" + strLDPeriod + "',monthly_instollment = '" + strLDMonInsto + "',acc_name = '" + strAccName + "',branch_code = '" + strAccBranch + "',acc_number = '" + strAccNumber + "',bank_code = '" + strBank + "',registration_fee = '" + strRegisFee + "',walfare_fee = '" + strWelfa + "' where contra_code = '" + strLDContrCode + "';");

            try
            {
                int i = objDBTask.insertEditData(cmdUpdateLDetails);
                if (i == 1)
                {
                    lblLDMsg.Text = "Successfully Update.";
                    Clear();
                    btnLDNext.Enabled = false;
                    btnUpdate.Enabled = false;
                }
                else
                {
                    lblLDMsg.Text = "Error Occured!";
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBranch.Items.Count > 0)
            {
                cmbBranch.Items.Clear();
            }

            if (cmbBankName.SelectedIndex == 0)
            {
                txtBankCode.Text = "";
            }
            else
            {
                string strBank = cmbBankName.SelectedItem.Value;
                txtBankCode.Text = strBank;
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
            if (cmbBranch.SelectedIndex == 0)
            {
                txtBranchCode.Text = "";
            }
            else
            {
                string strBranch = cmbBranch.SelectedItem.Value;
                txtBranchCode.Text = strBranch;
            }
        }
    }
}
