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
            string q = "INSERT INTO `muslimaid`.`micro_loan_details`(`contra_code`,`loan_amount`,`current_loan_amount`,`service_charges`,`other_charges`,`interest_rate`,`interest_amount`,`period`,`monthly_instollment`,`created_on`,`created_user_nic`,`created_user_ip`,`chequ_no`,`chequ_amount`,`chequ_deta_on`,`loan_approved`,`loan_approved_user_nic`,`loan_approved_on`,`OtherDescription`,`cheq_detai_app_nic`,`due_date`,`arres_amou`,`acc_name`,`acc_branch`,`acc_number`,`bank_name`,`def`,`over_payment`,`arres_count`,`loan_sta`,`ser_char_sta`,`closing_date`,`maturity_date`,`due_installment`,`reg_approval_nic`,`reg_approval_on`,`reg_approval_des`,`reg_approval`,`bank_code`,`branch_code`,`registration_fee`,`walfare_fee`)VALUES(`@contra_code`,`@loan_amount`,`@current_loan_amount`,`@service_charges`,`@other_charges`,`@interest_rate`,`@interest_amount`,`@period`,`@monthly_instollment`,`@created_on`,`@created_user_nic`,`@created_user_ip`,`@chequ_no`,`@chequ_amount`,`@chequ_deta_on`,`@loan_approved`,`@loan_approved_user_nic`,`@loan_approved_on`,`@OtherDescription`,`@cheq_detai_app_nic`,`@due_date`,`@arres_amou`,`@acc_name`,`@acc_branch`,`@acc_number`,`@bank_name`,`@def`,`@over_payment`,`@arres_count`,`@loan_sta`,`@ser_char_sta`,`@closing_date`,`@maturity_date`,`@due_installment`,`@reg_approval_nic`,`@reg_approval_on`,`@reg_approval_des`,`@reg_approval`,`@bank_code`,`@branch_code`,`@registration_fee`,`@walfare_fee`)";

            try
            {
                if (txtCC.Text.Trim() == "")
                    lblMsg.Text = "Contract Code cannot be empty";
                else if (txtLDIntRate.Text.Trim() == "")
                    lblMsg.Text = "Please enter Facility Amount/ Value";
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

                    if(rdoYes.Checked)
                        cmdInsert.Parameters.AddWithValue("`@any_unsettled_loans`", 1);
                    else cmdInsert.Parameters.AddWithValue("`@any_unsettled_loans`", 0);
                    

                    //cmdInsert.Parameters.AddWithValue("`@service_charges`", txtSupplier.Text.Trim());
                    //cmdInsert.Parameters.AddWithValue("`@service_charges`", txtSupplierTelephone.Text.Trim());
                    //cmdInsert.Parameters.AddWithValue("`@service_charges`", txtSupplierMobile.Text.Trim());
                    //cmdInsert.Parameters.AddWithValue("`@service_charges`", txtSupplierAddress.Text.Trim());

                    

                    //cmdInsert.Parameters.AddWithValue("`@created_on`", Convert.ToDecimal(txtAccountName.Text.Trim()));
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
    }
}
