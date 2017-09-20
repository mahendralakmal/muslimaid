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

namespace MuslimAID.MURABHA
{
    public partial class loan_details : System.Web.UI.Page
    {
        string strCC; string strCAC;
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LoggedIn"].ToString() == "True")
                    {
                        strCC = Request.QueryString["CC"];
                        strCAC = Request.QueryString["CA"];

                        cmbPeriod.Items.Add("Select Period");
                        for (int i = 0; i < 24; i++)
                        {
                            cmbPeriod.Items.Add(i+1 + " Month");
                            cmbPeriod.Items[i + 1].Value = (i+1).ToString();
                        }

                        if (strCC != null)
                        {
                            txtCC.Text = strCC;
                            txtLDIntRate.Text = "0";
                            txtLDMInterest.Text = "0";
                            DataSet dsLD = cls_Connection.getDataSet("SELECT loan_amount, period FROM micro_loan_details WHERE contra_code = '" + strCC + "';");
                            if (dsLD.Tables[0].Rows.Count > 0)
                            {
                                txtLDLAmount.Text = dsLD.Tables[0].Rows[0]["loan_amount"].ToString();
                                cmbPeriod.SelectedValue = dsLD.Tables[0].Rows[0]["period"].ToString();

                                TextBox1.Text = (Math.Round(Convert.ToDouble(dsLD.Tables[0].Rows[0]["loan_amount"].ToString()) / Convert.ToDouble(dsLD.Tables[0].Rows[0]["period"].ToString()), 2)).ToString();
                            }



                            DataSet dsSD = cls_Connection.getDataSet("SELECT invoice_value FROM micro_supplier_details WHERE contract_code = '" + strCC + "';");
                            if (dsSD.Tables[0].Rows.Count > 0)
                            {
                                txtSellPrice.Text = dsSD.Tables[0].Rows[0]["invoice_value"].ToString();
                            }
                            double IV = Convert.ToDouble(txtSellPrice.Text.Trim());
                            double FA = Convert.ToDouble(txtLDLAmount.Text.Trim());
                            if (IV > FA)
                                txtDownPay.Text = (IV - FA).ToString();
                            else
                                txtDownPay.Text = "0.00";
                                
                            txtCC.Enabled = false;
                        }
                        else
                        {
                            txtCC.Enabled = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("../Login.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Data Sending error");
            }
        }

        protected bool validate()
        {
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Facility Code cannot be empty"; return false;
            }
            else if (txtLDIntRate.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Facility Amount/ Value"; return false;
            }
            else if (txtLDIntRate.Text == "" || Convert.ToDouble(txtLDIntRate.Text.ToString()) <= 0)
            {
                lblMsg.Text = "Please enter Markup Rate"; return false;
            }
            else return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string q = "INSERT INTO micro_loan_details(contra_code, loan_amount, selling_price, down_payment, service_charges, registration_fee, walfare_fee, other_charges, interest_rate, period, monthly_instollment, interest_amount, reason_to_apply, any_unsettled_loans,reg_approval,loan_approved) VALUES (@contra_code, @loan_amount, @selling_price, @down_payment, @service_charges, @registration_fee, @walfare_fee, @other_charges, @interest_rate, @period, @monthly_instollment, @interest_amount, @reason_to_apply, @any_unsettled_loans,@reg_approval,@loan_approved)";

            try
            {
                if (txtCC.Text.Trim() == "")
                    lblMsg.Text = "Facility Code cannot be empty";
                else if (txtLDIntRate.Text.Trim() == "")
                    lblMsg.Text = "Please enter Facility Amount/ Value";
                else if (txtLDIntRate.Text == "" || Convert.ToDouble(txtLDIntRate.Text.ToString())<= 0)
                    lblMsg.Text = "Please enter Markup rate";
                else
                {
                    MySqlCommand cmdInsert = new MySqlCommand(q);
                    #region Parameter Declarations
                    cmdInsert.Parameters.AddWithValue("@contra_code", txtCC.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@loan_amount", Convert.ToDecimal((txtLDLAmount.Text.Trim() != "") ? txtLDLAmount.Text.Trim() : "0.00"));
                    cmdInsert.Parameters.AddWithValue("@selling_price", txtSellPrice.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@down_payment", txtDownPay.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@service_charges", Convert.ToDecimal((txtLDSerCharges.Text.Trim() != "") ? txtLDSerCharges.Text.Trim() : "0.00"));
                    cmdInsert.Parameters.AddWithValue("@registration_fee", Convert.ToDecimal((txtRegistrationFee.Text.Trim() != "") ? txtRegistrationFee.Text.Trim() : "0.00"));
                    cmdInsert.Parameters.AddWithValue("@walfare_fee", Convert.ToDecimal((txtWalfareFee.Text.Trim() != "") ? txtWalfareFee.Text.Trim() : "0.00"));
                    cmdInsert.Parameters.AddWithValue("@other_charges", Convert.ToDecimal((txtLDOtherCharg.Text.Trim() != "") ? txtLDOtherCharg.Text.Trim() : "0.00"));
                    cmdInsert.Parameters.AddWithValue("@interest_rate", txtLDIntRate.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@period", cmbPeriod.SelectedValue.ToString());
                    cmdInsert.Parameters.AddWithValue("@monthly_instollment", Convert.ToDecimal((txtLDMInstoll.Text.Trim() != "") ? txtLDMInstoll.Text.Trim() : "0.00"));
                    cmdInsert.Parameters.AddWithValue("@interest_amount", Convert.ToDecimal((txtLDMInterest.Text.Trim() != "") ? txtLDMInterest.Text.Trim() : "0.00"));

                    cmdInsert.Parameters.AddWithValue("@reg_approval", "Y");
                    cmdInsert.Parameters.AddWithValue("@loan_approved", "P");
                    #endregion
                    try
                    {
                        int i = objDBCon.insertEditData(cmdInsert);
                        if (i > 0)
                        {
                            Response.Redirect("client_basic_details.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Data Sending error");
                    }
                }
            }
            catch (Exception ml)
            {
                cls_ErrorLog.createSErrorLog(ml.Message, ml.Source, "Data Sending error");
            }
        }

        protected void clean()
        {
            txtCC.Text = "";
            txtDownPay.Text = "";
            txtLDIntRate.Text = "";
            txtLDLAmount.Text = "";
            txtLDMInstoll.Text = "";
            txtLDMInterest.Text = "";
            txtLDOtherCharg.Text = "";
            txtLDSerCharges.Text = "";
            txtRegistrationFee.Text = "";
            txtSellPrice.Text = "";
            txtWalfareFee.Text = "";
            cmbPeriod.SelectedIndex = 0;
            txtRTotal.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validate())
            {

                decimal decLA = (txtLDLAmount.Text.Trim() != "") ? Convert.ToDecimal(txtLDLAmount.Text.Trim()) : 00;
                string strSP = txtSellPrice.Text.Trim();
                string strDP = txtDownPay.Text.Trim();
                decimal decSC = (txtLDSerCharges.Text.Trim() != "") ? Convert.ToDecimal(txtLDSerCharges.Text.Trim()) : 00;
                string strRF = txtRegistrationFee.Text.Trim();
                string strWF = txtWalfareFee.Text.Trim();
                decimal decOC = (txtLDOtherCharg.Text.Trim() != "") ? Convert.ToDecimal(txtLDOtherCharg.Text.Trim()) : 00;
                string strIR = txtLDIntRate.Text.Trim();
                decimal decMI = (txtLDMInstoll.Text.Trim() != "") ? Convert.ToDecimal(txtLDMInstoll.Text.Trim()) : 00;
                string strPe = cmbPeriod.SelectedValue.ToString();

                string upq = "UPDATE micro_loan_details SET loan_amount ='" + decLA + "', selling_price ='" + strSP + "', down_payment='" + strDP + "', service_charges='" + decSC + "', registration_fee ='" + strRF + "', walfare_fee ='" + strWF + "', other_charges = '" + decOC + "', interest_rate='" + strIR + "', monthly_instollment='" + decMI + "', period ='" + strPe + "',reg_approval ='Y',loan_approved='P' WHERE contra_code ='" + txtCC.Text.Trim() + "';";

                try
                {
                    int i = objDBCon.insertEditData(upq);
                    if (i > 0)
                    {
                        clean();
                        lblMsg.Text = "Successfull";
                        Response.Redirect("client_basic_details.aspx");
                    }
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Data Sending error");
                }
            }
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Contract Code";
            }
            else
            {
                string strCCode = txtCC.Text.Trim();

                DataSet dsSD = cls_Connection.getDataSet("SELECT invoice_value FROM micro_supplier_details WHERE contract_code = '" + strCCode + "';");
                if (dsSD.Tables[0].Rows.Count > 0)
                {
                    txtSellPrice.Text = dsSD.Tables[0].Rows[0]["invoice_value"].ToString();
                }

                DataSet dsGetDetail = cls_Connection.getDataSet("SELECT * FROM micro_loan_details WHERE contra_code ='" + strCCode + "';");

                if (dsGetDetail.Tables[0].Rows.Count > 0)
                {
                    txtLDLAmount.Text = dsGetDetail.Tables[0].Rows[0]["loan_amount"].ToString();
                    txtLDSerCharges.Text = dsGetDetail.Tables[0].Rows[0]["service_charges"].ToString();
                    txtRegistrationFee.Text = dsGetDetail.Tables[0].Rows[0]["registration_fee"].ToString();
                    txtWalfareFee.Text = dsGetDetail.Tables[0].Rows[0]["walfare_fee"].ToString();
                    txtLDOtherCharg.Text = dsGetDetail.Tables[0].Rows[0]["other_charges"].ToString();
                    txtLDIntRate.Text = dsGetDetail.Tables[0].Rows[0]["interest_rate"].ToString();
                    cmbPeriod.SelectedIndex = Convert.ToInt16(dsGetDetail.Tables[0].Rows[0]["period"].ToString());
                    txtLDMInterest.Text = dsGetDetail.Tables[0].Rows[0]["interest_amount"].ToString();
                    txtLDMInstoll.Text = dsGetDetail.Tables[0].Rows[0]["monthly_instollment"].ToString();
                }
                
                double SC = (txtLDSerCharges.Text.Trim()!="")?Convert.ToDouble(txtLDSerCharges.Text.Trim()):0.00;
                double RF = (txtRegistrationFee.Text.Trim()!="")?Convert.ToDouble(txtRegistrationFee.Text.Trim()):0.00;
                double WF = (txtWalfareFee.Text.Trim() != "") ? Convert.ToDouble(txtWalfareFee.Text.Trim()) : 0.00;
                double OC = (txtLDOtherCharg.Text.Trim() != "") ? Convert.ToDouble(txtLDOtherCharg.Text.Trim()) : 0.00;
                double IV = (txtSellPrice.Text.Trim() != "") ? Convert.ToDouble(txtSellPrice.Text.Trim()) : 0.00;
                double FA = (txtLDLAmount.Text.Trim() != "") ? Convert.ToDouble(txtLDLAmount.Text.Trim()) : 0.00;
                int MR = (txtLDIntRate.Text.Trim() != "") ? Convert.ToInt32(txtLDIntRate.Text.Trim()) : 0;
                int P = (cmbPeriod.SelectedIndex.ToString() != "") ? Convert.ToInt32(cmbPeriod.SelectedIndex.ToString()) : 0;

                
                if (IV > FA)
                    txtDownPay.Text = (IV - FA).ToString();
                else
                    txtDownPay.Text = "0.00";

                txtLDMInterest.Text = Math.Round((((FA * MR) / 100) / P), 2).ToString();
                TextBox1.Text = Math.Round((FA / P), 2).ToString();

                txtRTotal.Text = Math.Round((SC + RF + WF + OC + (IV - FA) + ((((FA * MR) / 100)) + (FA))), 2).ToString();
            }
        }
    }
}
