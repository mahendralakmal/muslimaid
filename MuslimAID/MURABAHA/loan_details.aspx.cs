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

                        if (strCC != null && strCAC != null)
                        {
                            txtCC.Text = strCC;
                            //txtCACode.Text = strCAC;
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string q = "INSERT INTO micro_loan_details(contra_code, loan_amount, product_category, brand, model_no, selling_price, down_payment, service_charges, registration_fee, walfare_fee, other_charges, interest_rate, period, monthly_instollment, interest_amount, reason_to_apply, any_unsettled_loans, other_unsettled_facilities,reg_approval,loan_approved) VALUES (@contra_code, @loan_amount, @product_category, @brand, @model_no, @selling_price, @down_payment, @service_charges, @registration_fee, @walfare_fee, @other_charges, @interest_rate, @period, @monthly_instollment, @interest_amount, @reason_to_apply, @any_unsettled_loans, @other_unsettled_facilities,@reg_approval,@loan_approved)";

            try
            {
                if (txtCC.Text.Trim() == "")
                    lblMsg.Text = "Facility Code cannot be empty";
                else if (txtLDIntRate.Text.Trim() == "")
                    lblMsg.Text = "Please enter Facility Amount/ Value";
                else if (txtNameOrg1.Text.Trim() != "")
                {
                    if (txtPurpos1.Text.Trim() == "") lblMsg.Text = "Please fill the field purpose 1";
                    if (txtFAmount1.Text.Trim() == "") lblMsg.Text = "Please fill the field facility amount 1";
                    if (txtOutstandBal1.Text.Trim() == "") lblMsg.Text = "Please fill the field outstanding balance 1";
                    if (txtMonthInstal1.Text.Trim() == "") lblMsg.Text = "Please fill the field monthly installment 1";
                    if (txtRemainInstal1.Text.Trim() == "") lblMsg.Text = "Please fill the field remaining no of installment 1";

                    else if (txtNameOrg2.Text.Trim() != "")
                    {
                        if (txtPurpos2.Text.Trim() == "") lblMsg.Text = "Please fill the field purpose 2";
                        if (txtFAmount2.Text.Trim() == "") lblMsg.Text = "Please fill the field facility amount 2";
                        if (txtOutstandBal2.Text.Trim() == "") lblMsg.Text = "Please fill the field outstanding balance 2";
                        if (txtMonthInstal2.Text.Trim() == "") lblMsg.Text = "Please fill the field monthly installment 2";
                        if (txtRemainInstal2.Text.Trim() == "") lblMsg.Text = "Please fill the field remaining no of installment 1";
                    }

                    else if (txtNameOrg3.Text.Trim() != "")
                    {
                        if (txtPurpos3.Text.Trim() == "") lblMsg.Text = "Please fill the field purpose 3";
                        if (txtFAmount3.Text.Trim() == "") lblMsg.Text = "Please fill the field facility amount 3";
                        if (txtOutstandBal3.Text.Trim() == "") lblMsg.Text = "Please fill the field outstanding balance 3";
                        if (txtMonthInstal3.Text.Trim() == "") lblMsg.Text = "Please fill the field monthly installment 3";
                        if (txtRemainInstal3.Text.Trim() == "") lblMsg.Text = "Please fill the field remaining no of installment 3";
                    }
                }
                
                MySqlCommand cmdInsert = new MySqlCommand(q);
                #region Parameter Declarations
                cmdInsert.Parameters.AddWithValue("@contra_code", txtCC.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@loan_amount", Convert.ToDecimal(txtLDLAmount.Text.Trim()));
                cmdInsert.Parameters.AddWithValue("@product_category", txtProdCate.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@brand", txtBrand.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@model_no", txtProdCate.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@selling_price", txtSellPrice.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@down_payment", txtDownPay.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@service_charges", Convert.ToDecimal(txtLDSerCharges.Text.Trim()));
                cmdInsert.Parameters.AddWithValue("@registration_fee", Convert.ToDecimal(txtRegistrationFee.Text.Trim()));
                cmdInsert.Parameters.AddWithValue("@walfare_fee", Convert.ToDecimal(txtWalfareFee.Text.Trim()));
                cmdInsert.Parameters.AddWithValue("@other_charges", Convert.ToDecimal(txtLDOtherCharg.Text.Trim()));
                cmdInsert.Parameters.AddWithValue("@interest_rate", txtLDIntRate.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@period", cmbPeriod.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@monthly_instollment", Convert.ToDecimal(txtLDMInstoll.Text.Trim()));
                cmdInsert.Parameters.AddWithValue("@interest_amount", Convert.ToDecimal(txtLDMInterest.Text.Trim()));
                cmdInsert.Parameters.AddWithValue("@reason_to_apply", txtResonToApply.Text.Trim());
                if (rdoYes.Checked)
                {
                    cmdInsert.Parameters.AddWithValue("@any_unsettled_loans", 1);
                    //cmdInsert.Parameters.AddWithValue("@other_unsettled_facilities", checkOtherFacility());
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@any_unsettled_loans", 0);
                    //cmdInsert.Parameters.AddWithValue("@other_unsettled_facilities", "[]");
                }
                cmdInsert.Parameters.AddWithValue("@reg_approval", "Y");
                cmdInsert.Parameters.AddWithValue("@loan_approved", "P");
                #endregion
                try
                {
                    int i = objDBCon.insertEditData(cmdInsert);
                    if (i > 0)
                    {
                        checkOtherFacility();
                        Response.Redirect("supplier.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + strCAC + "");
                    }
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Data Sending error");
                }
            }
            catch (Exception ml)
            {
                cls_ErrorLog.createSErrorLog(ml.Message, ml.Source, "Data Sending error");
            }
        }

        protected void clean()
        {
            txtBrand.Text = "";
            txtCC.Text = "";
            txtDownPay.Text = "";
            txtFAmount1.Text = "";
            txtFAmount2.Text = "";
            txtFAmount3.Text = "";
            txtLDIntRate.Text = "";
            txtLDLAmount.Text = "";
            txtLDMInstoll.Text = "";
            txtLDMInterest.Text = "";
            txtLDOtherCharg.Text = "";
            txtLDSerCharges.Text = "";
            txtModelNo.Text = "";
            txtMonthInstal1.Text = "";
            txtMonthInstal2.Text = "";
            txtMonthInstal3.Text = "";
            txtNameOrg1.Text = "";
            txtNameOrg2.Text = "";
            txtNameOrg3.Text = "";
            txtOutstandBal1.Text = "";
            txtOutstandBal2.Text = "";
            txtOutstandBal3.Text = "";
            txtProdCate.Text = "";
            txtPurpos1.Text = "";
            txtPurpos2.Text = "";
            txtPurpos3.Text = "";
            txtRegistrationFee.Text = "";
            txtRemainInstal1.Text = "";
            txtRemainInstal2.Text = "";
            txtRemainInstal3.Text = "";
            txtResonToApply.Text = "";
            txtSellPrice.Text = "";
            txtWalfareFee.Text = "";
            cmbPeriod.SelectedIndex = 0;
        }

        protected Boolean checkOtherFacility()
        {
            string strOtherFacility = "";
            strOtherFacility = "INSERT INTO `micro_other_unsetteled_loans`(contra_code,organization,purpos,facility_amount,outstanding,monthly_installment,remaining_number_of_installment) VALUES ";
            if (txtNameOrg1.Text.Trim() != "")
            {
                strOtherFacility += "('" + txtCC.Text.Trim() + "','" + txtNameOrg1.Text.Trim() + "','" + txtPurpos1.Text.Trim() + "'," + txtFAmount1.Text.Trim() + "," + txtOutstandBal1.Text.Trim() + "," + txtMonthInstal1.Text.Trim() + "," + txtRemainInstal1.Text.Trim() + ")";
            }
            if (txtNameOrg2.Text.Trim() != "")
            {
                strOtherFacility += ",('" + txtCC.Text.Trim() + "','" + txtNameOrg2.Text.Trim() + "','" + txtPurpos2.Text.Trim() + "'," + txtFAmount2.Text.Trim() + "," + txtOutstandBal2.Text.Trim() + "," + txtMonthInstal2.Text.Trim() + "," + txtRemainInstal2.Text.Trim() + ")";
            }
            if (txtNameOrg3.Text.Trim() != "")
            {
                strOtherFacility += ",('" + txtCC.Text.Trim() + "','" + txtNameOrg3.Text.Trim() + "','" + txtPurpos3.Text.Trim() + "'," + txtFAmount3.Text.Trim() + "," + txtOutstandBal3.Text.Trim() + "," + txtMonthInstal3.Text.Trim() + "," + txtRemainInstal3.Text.Trim() + ")";
            }

            cls_Connection.setData(strOtherFacility.ToString());
            return true;
            //int i = cls_Connection.setData(strOtherFacility.ToString());
        }

        protected Boolean UpdateOtherFacility()
        {
            string strOtherFacility = "";
            
            if (txtNameOrg1.Text.Trim() != "")
            {
                strOtherFacility += "UPDATE `micro_other_unsetteled_loans` SET organization='" + txtNameOrg1.Text.Trim() + "',purpos='" + txtPurpos1.Text.Trim() + "',facility_amount=" + txtFAmount1.Text.Trim() + ",outstanding=" + txtOutstandBal1.Text.Trim() + ",monthly_installment=" + txtMonthInstal1.Text.Trim() + ",remaining_number_of_installment=" + txtRemainInstal1.Text.Trim() + " WHERE contra_code ='" + txtCC.Text.Trim() + "';";
            }
            if (txtNameOrg2.Text.Trim() != "")
            {
                strOtherFacility += "UPDATE `micro_other_unsetteled_loans` SET organization='" + txtNameOrg2.Text.Trim() + "',purpos='" + txtPurpos2.Text.Trim() + "',facility_amount=" + txtFAmount2.Text.Trim() + ",outstanding=" + txtOutstandBal2.Text.Trim() + ",monthly_installment=" + txtMonthInstal2.Text.Trim() + ",remaining_number_of_installment=" + txtRemainInstal2.Text.Trim() + " WHERE contra_code ='" + txtCC.Text.Trim() + "';";
            }
            if (txtNameOrg3.Text.Trim() != "")
            {
                strOtherFacility += "UPDATE `micro_other_unsetteled_loans` SET organization='" + txtNameOrg3.Text.Trim() + "',purpos='" + txtPurpos3.Text.Trim() + "',facility_amount=" + txtFAmount3.Text.Trim() + ",outstanding=" + txtOutstandBal3.Text.Trim() + ",monthly_installment=" + txtMonthInstal3.Text.Trim() + ",remaining_number_of_installment=" + txtRemainInstal3.Text.Trim() + " WHERE contra_code ='" + txtCC.Text.Trim() + "';";
            }

            int i = objDBCon.insertEditData(strOtherFacility.ToString());
            return true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int strAnyOtherFacility;
            if (rdoYes.Checked)
            {
                strAnyOtherFacility = 1;
            }
            else strAnyOtherFacility = 0;

            string q = "UPDATE `micro_loan_details` SET loan_amount ='" + Convert.ToDecimal(txtLDLAmount.Text.Trim()) + "', product_category ='" + txtProdCate.Text.Trim() + "', brand ='" + txtBrand.Text.Trim() + "', model_no ='" + txtModelNo.Text.Trim() + "', selling_price ='" + txtSellPrice.Text.Trim() + "', down_payment ='" + txtDownPay.Text.Trim() + "', service_charges ='" + txtLDSerCharges.Text.Trim() + "', registration_fee = '" + txtRegistrationFee.Text.Trim() + "', walfare_fee ='" + txtWalfareFee.Text.Trim() + "', other_charges ='" + Convert.ToDecimal(txtLDOtherCharg.Text.Trim()) + "', interest_rate ='" + Convert.ToDecimal(txtLDIntRate.Text.Trim()) + "', period ='" + Convert.ToDecimal(cmbPeriod.SelectedValue.ToString()) + "', monthly_instollment ='" + Convert.ToDecimal(txtLDMInstoll.Text.Trim()) + "', reason_to_apply ='" + txtResonToApply.Text.Trim() + "', any_unsettled_loans ='" + strAnyOtherFacility + "' WHERE `contra_code` ='" + txtCC.Text.Trim() + "'";
            try
            {
                int i = objDBCon.insertEditData(q);
                if (i > 0)
                {
                    UpdateOtherFacility();
                    lblMsg.Text = "Successfull";
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Data Sending error");
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

                DataSet dsGetDetail = cls_Connection.getDataSet("SELECT * FROM micro_loan_details WHERE contra_code ='" + strCCode + "';");

                txtLDLAmount.Text = dsGetDetail.Tables[0].Rows[0]["loan_amount"].ToString();
                txtProdCate.Text = dsGetDetail.Tables[0].Rows[0]["product_category"].ToString();
                txtBrand.Text = dsGetDetail.Tables[0].Rows[0]["brand"].ToString();
                txtModelNo.Text = dsGetDetail.Tables[0].Rows[0]["model_no"].ToString();
                txtSellPrice.Text = dsGetDetail.Tables[0].Rows[0]["selling_price"].ToString();
                txtDownPay.Text = dsGetDetail.Tables[0].Rows[0]["down_payment"].ToString();
                txtLDSerCharges.Text = dsGetDetail.Tables[0].Rows[0]["service_charges"].ToString();
                txtRegistrationFee.Text = dsGetDetail.Tables[0].Rows[0]["registration_fee"].ToString();
                txtWalfareFee.Text = dsGetDetail.Tables[0].Rows[0]["walfare_fee"].ToString();
                txtLDOtherCharg.Text = dsGetDetail.Tables[0].Rows[0]["other_charges"].ToString();
                txtLDIntRate.Text = dsGetDetail.Tables[0].Rows[0]["interest_rate"].ToString();
                cmbPeriod.SelectedIndex = Convert.ToInt16(dsGetDetail.Tables[0].Rows[0]["period"].ToString());
                txtLDMInterest.Text = dsGetDetail.Tables[0].Rows[0]["interest_amount"].ToString();
                txtLDMInstoll.Text = dsGetDetail.Tables[0].Rows[0]["monthly_instollment"].ToString();
                txtResonToApply.Text = dsGetDetail.Tables[0].Rows[0]["reason_to_apply"].ToString();
                if (dsGetDetail.Tables[0].Rows[0]["any_unsettled_loans"].ToString() == "1"){
                    rdoYes.Checked = true;
                    DataSet dsOLoans = cls_Connection.getDataSet("SELECT * FROM micro_other_unsetteled_loans WHERE contra_code='" + strCCode + "'");
                    if (dsOLoans.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsOLoans.Tables[0].Rows.Count; i++)
                        {
                            if (i + 1 == 1)
                            {
                                txtNameOrg1.Text = dsOLoans.Tables[0].Rows[0]["organization"].ToString();
                                txtPurpos1.Text = dsOLoans.Tables[0].Rows[0]["purpos"].ToString();
                                txtFAmount1.Text = dsOLoans.Tables[0].Rows[0]["facility_amount"].ToString();
                                txtOutstandBal1.Text = dsOLoans.Tables[0].Rows[0]["outstanding"].ToString();
                                txtMonthInstal1.Text = dsOLoans.Tables[0].Rows[0]["monthly_installment"].ToString();
                                txtRemainInstal1.Text = dsOLoans.Tables[0].Rows[0]["remaining_number_of_installment"].ToString();
                            }
                            if (i + 1 == 2)
                            {
                                txtNameOrg2.Text = dsOLoans.Tables[0].Rows[1]["organization"].ToString();
                                txtPurpos2.Text = dsOLoans.Tables[0].Rows[1]["purpos"].ToString();
                                txtFAmount2.Text = dsOLoans.Tables[0].Rows[1]["facility_amount"].ToString();
                                txtOutstandBal2.Text = dsOLoans.Tables[0].Rows[1]["outstanding"].ToString();
                                txtMonthInstal2.Text = dsOLoans.Tables[0].Rows[1]["monthly_installment"].ToString();
                                txtRemainInstal2.Text = dsOLoans.Tables[0].Rows[1]["remaining_number_of_installment"].ToString();
                            }
                            if (i + 1 == 3)
                            {
                                txtNameOrg3.Text = dsOLoans.Tables[0].Rows[2]["organization"].ToString();
                                txtPurpos3.Text = dsOLoans.Tables[0].Rows[2]["purpos"].ToString();
                                txtFAmount3.Text = dsOLoans.Tables[0].Rows[2]["facility_amount"].ToString();
                                txtOutstandBal3.Text = dsOLoans.Tables[0].Rows[2]["outstanding"].ToString();
                                txtMonthInstal3.Text = dsOLoans.Tables[0].Rows[2]["monthly_installment"].ToString();
                                txtRemainInstal3.Text = dsOLoans.Tables[0].Rows[2]["remaining_number_of_installment"].ToString();
                            }
                        }
                    }
                }
                else{
                    rdoNo.Checked = true;
                }
            }
        }
    }
}
