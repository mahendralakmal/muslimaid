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
                        //strCC = Request.QueryString["CC"];
                        //strCAC = Request.QueryString["CA"];
                        strCC = "CO/CS/000004";
                        strCAC = "CO/1/01/02";

                        if (strCC != null && strCAC != null)
                        {
                            txtCC.Text = strCC;
                            //txtCACode.Text = strCAC;
                            txtCC.Enabled = false;

                            //DataSet ds = cls_Connection.getDataSet("select * from bank_tbl");
                            //cmbSupplierBank.Items.Add(new ListItem("Select Bank", ""));
                            //if (ds.Tables[0].Rows.Count > 0)
                            //{
                            //    foreach (DataRow drRow in ds.Tables[0].Rows)
                            //    {
                            //        cmbSupplierBank.Items.Add(new ListItem(drRow[1].ToString(), drRow[0].ToString()));
                            //    }
                            //}

                            //DataSet dsSC = cls_Connection.getDataSet("select * from supplier_category");
                            //cmbSupplierCategory.Items.Add(new ListItem("Select Supplier Category", ""));
                            //if (dsSC.Tables[0].Rows.Count > 0)
                            //{
                            //    foreach (DataRow drRow in dsSC.Tables[0].Rows)
                            //    {
                            //        cmbSupplierCategory.Items.Add(new ListItem(drRow[1].ToString(), drRow[0].ToString()));
                            //    }
                            //}
                        }
                        else
                        {
                            txtCC.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string q = "INSERT INTO `muslimaid`.`micro_loan_details`(contract_code,loan_amount,product_category,brand,model_no,selling_price,down_payment,service_charges,registration_fee,walfare_fee,other_charges,interest_rate,period,monthly_instollment,reason_to_apply,any_unsettled_loans,other_unsettled_facilities`) VALUES (@contract_code,@loan_amount,@product_category,@brand,@model_no,@selling_price,@down_payment,@service_charges,@registration_fee,@walfare_fee,@other_charges,@interest_rate,@period,@monthly_instollment,@reason_to_apply,@any_unsettled_loans,@other_unsettled_facilities)";

            try
            {
                if (txtCC.Text.Trim() == "")
                    lblMsg.Text = "Contract Code cannot be empty";
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
                
                else
                {
                    MySqlCommand cmdInsert = new MySqlCommand(q);
                    #region Parameter Declarations
                    cmdInsert.Parameters.AddWithValue("`@contract_code`", txtCC.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@loan_amount`", Convert.ToDecimal(txtLDLAmount.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@product_category`", txtProdCate.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@brand`", txtBrand.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@model_no`", txtProdCate.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@selling_price`", txtSellPrice.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@down_payment`", txtDownPay.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@service_charges`", txtLDSerCharges.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@registration_fee`", txtRegistrationFee.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@walfare_fee`", txtWalfareFee.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@other_charges`", Convert.ToDecimal(txtLDOtherCharg.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@interest_rate`", Convert.ToDecimal(txtLDIntRate.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@period`", Convert.ToDecimal(cmbPeriod.SelectedValue.ToString()));
                    cmdInsert.Parameters.AddWithValue("`@monthly_instollment`", Convert.ToDecimal(txtLDMInstoll.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@reason_to_apply`", txtResonToApply.Text.Trim());
                    if (rdoYes.Checked)
                    {
                        cmdInsert.Parameters.AddWithValue("`@any_unsettled_loans`", 1);
                        cmdInsert.Parameters.AddWithValue("`@other_unsettled_facilities`", checkOtherFacility());
                    }
                    else cmdInsert.Parameters.AddWithValue("`@any_unsettled_loans`", 0);
                    #endregion
                    try
                    {
                        int i = objDBCon.insertEditData(cmdInsert);
                        if (i > 0)
                        {
                            lblMsg.Text = "Successfull";
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected string checkOtherFacility() {
            string strOtherFacility = "";
            strOtherFacility = "[";
            if (txtNameOrg1.Text.Trim() != "")
            {
                strOtherFacility += "{'organization' = '" + txtNameOrg1.Text.Trim() + "','purpose' = '" + txtPurpos1.Text.Trim() + "','facilityAmount' = '" + txtFAmount1.Text.Trim() + "','outstanding' = '" + txtOutstandBal1.Text.Trim() + "','m_installment' = '" + txtMonthInstal1.Text.Trim() + "','re_no_of_installments' = '" + txtRemainInstal1.Text.Trim() + "'}]";
            }
            if (txtNameOrg2.Text.Trim() != "")
            {
                strOtherFacility += ",{'organization' = '" + txtNameOrg2.Text.Trim() + "','purpose' = '" + txtPurpos2.Text.Trim() + "','facilityAmount' = '" + txtFAmount2.Text.Trim() + "','outstanding' = '" + txtOutstandBal2.Text.Trim() + "','m_installment' = '" + txtMonthInstal2.Text.Trim() + "','re_no_of_installments' = '" + txtRemainInstal2.Text.Trim() + "'}";
            }
            if (txtNameOrg3.Text.Trim() != "")
            {
                strOtherFacility += ",{'organization' = '" + txtNameOrg3.Text.Trim() + "','purpose' = '" + txtPurpos3.Text.Trim() + "','facilityAmount' = '" + txtFAmount3.Text.Trim() + "','outstanding' = '" + txtOutstandBal3.Text.Trim() + "','m_installment' = '" + txtMonthInstal3.Text.Trim() + "','re_no_of_installments' = '" + txtRemainInstal3.Text.Trim() + "'}";
            }

            strOtherFacility += "]";

            return strOtherFacility.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int strAnyOtherFacility;
            if (rdoYes.Checked)
            {
                strAnyOtherFacility = 1;
            }
            else strAnyOtherFacility = 0;

            string q = "UPDATE `muslimaid`.`micro_loan_details` SET loan_amount ='" + Convert.ToDecimal(txtLDLAmount.Text.Trim()) + "', product_category ='" + txtProdCate.Text.Trim() + "', brand ='" + txtBrand.Text.Trim() + "', model_no ='" + txtModelNo.Text.Trim() + "', selling_price ='" + txtSellPrice.Text.Trim() + "', down_payment ='" + txtDownPay.Text.Trim() + "', service_charges ='" + txtLDSerCharges.Text.Trim() + "', registration_fee = '" + txtRegistrationFee.Text.Trim() + "', walfare_fee ='" + txtWalfareFee.Text.Trim() + "', other_charges ='" + Convert.ToDecimal(txtLDOtherCharg.Text.Trim()) + "', interest_rate ='" + Convert.ToDecimal(txtLDIntRate.Text.Trim()) + "', period ='" + Convert.ToDecimal(cmbPeriod.SelectedValue.ToString()) + "', monthly_instollment ='" + Convert.ToDecimal(txtLDMInstoll.Text.Trim()) + "', reason_to_apply ='" + txtResonToApply.Text.Trim() + "', any_unsettled_loans ='" + strAnyOtherFacility + "', other_unsettled_facilities ='" + checkOtherFacility() + "' WHERE `contra_code` ='" + txtCC.Text.Trim() + "'";
            try
            {
                int i = objDBCon.insertEditData(q);
                if (i > 0)
                {
                    lblMsg.Text = "Successfull";
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
