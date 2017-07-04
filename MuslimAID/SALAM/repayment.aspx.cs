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
using System.Text;

namespace MuslimAID.SALAM
{
    public partial class repayment : System.Web.UI.Page
    {
        string strCC, strCAC;
        cls_Connection conn = new cls_Connection();



        protected void cmbIncomeSource2_a_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_income_type_2_a(Convert.ToInt32(cmbIncomeSource2_a.SelectedIndex));
        }
        protected void get_income_type_2_a(int param)
        {
            DataSet dsINS;
            MySqlCommand cmdinsource = new MySqlCommand("SELECT * FROM salam_income_type_2 where income_type_1 = '" + param + "';");

            cmbIncomeSource2_b.Items.Clear();
            cmbIncomeSource2_b.Items.Add("~~ Select one ~~");
            dsINS = conn.selectData(cmdinsource);
            if (dsINS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsINS.Tables[0].Rows.Count; i++)
                {
                    cmbIncomeSource2_b.Items.Add(dsINS.Tables[0].Rows[i][1].ToString());
                    cmbIncomeSource2_b.Items[i + 1].Value = dsINS.Tables[0].Rows[i][0].ToString();
                }
            }
        }

        protected void cmbIncomeSource2_b_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_income_type_2_b(Convert.ToInt32(cmbIncomeSource2_b.SelectedValue));
        }

        protected void get_income_type_2_b(int param)
        {
            DataSet dsINS;
            MySqlCommand cmdinsource = new MySqlCommand("SELECT * FROM salam_income_type_3 where income_type_2 ='" + param + "';");

            cmbIncomeSource2_c.Items.Clear();
            cmbIncomeSource2_c.Items.Add("~~ Select one ~~");
            dsINS = conn.selectData(cmdinsource);
            if (dsINS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsINS.Tables[0].Rows.Count; i++)
                {
                    cmbIncomeSource2_c.Items.Add(dsINS.Tables[0].Rows[i][1].ToString());
                    cmbIncomeSource2_c.Items[i + 1].Value = dsINS.Tables[0].Rows[i][0].ToString();
                }
            }
        }


        protected void cmbIncomeSource1_b_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_income_type_1_b(cmbIncomeSource1_b.SelectedIndex);
        }

        protected void get_income_type_1_b(int param)
        {
            DataSet dsINS;
            MySqlCommand cmdinsource = new MySqlCommand("SELECT * FROM salam_income_type_3 where income_type_2 ='" + param + "';");

            cmbIncomeSource1_c.Items.Clear();
            cmbIncomeSource1_c.Items.Add("~~ Select one ~~");
            dsINS = conn.selectData(cmdinsource);
            if (dsINS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsINS.Tables[0].Rows.Count; i++)
                {
                    cmbIncomeSource1_c.Items.Add(dsINS.Tables[0].Rows[i][1].ToString());
                    cmbIncomeSource1_c.Items[i + 1].Value = dsINS.Tables[0].Rows[i][0].ToString();
                }
            }
        }

        protected void cmbIncomeSource1_a_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_income_type_1_a(cmbIncomeSource1_a.SelectedIndex);
        }
        
        protected void get_income_type_1_a(int param)
        {
            DataSet dsINS;
            MySqlCommand cmdinsource = new MySqlCommand("SELECT * FROM salam_income_type_2 where income_type_1 = '" + param + "';");

            cmbIncomeSource1_b.Items.Clear();
            cmbIncomeSource1_b.Items.Add("~~ Select one ~~");
            dsINS = conn.selectData(cmdinsource);
            if (dsINS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsINS.Tables[0].Rows.Count; i++)
                {
                    cmbIncomeSource1_b.Items.Add(dsINS.Tables[0].Rows[i][1].ToString());
                    cmbIncomeSource1_b.Items[i + 1].Value = dsINS.Tables[0].Rows[i][0].ToString();
                }
            }
        }

        protected void get_income_type()
        {
            DataSet dsINS;
            MySqlCommand cmdinsource = new MySqlCommand("SELECT * FROM salam_income_type_1;");
            dsINS = conn.selectData(cmdinsource);
            cmbIncomeSource1_a.Items.Add("~~ Select one ~~");
            cmbIncomeSource2_a.Items.Add("~~ Select one ~~");
            if (dsINS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsINS.Tables[0].Rows.Count; i++)
                {
                    cmbIncomeSource1_a.Items.Add(dsINS.Tables[0].Rows[i][1].ToString());
                    cmbIncomeSource1_a.Items[i + 1].Value = dsINS.Tables[0].Rows[i][0].ToString();
                    cmbIncomeSource2_a.Items.Add(dsINS.Tables[0].Rows[i][1].ToString());
                    cmbIncomeSource2_a.Items[i + 1].Value = dsINS.Tables[0].Rows[i][0].ToString();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!IsPostBack)
                {
                    if (Session["LoggedIn"].ToString() == "True")
                    {
                        if (Session["UserType"] != "Cash Collector" || Session["UserType"] != "Cash Recovery Officer" || Session["UserType"] != "Special Recovery Officer")
                        {
                            strCC = Request.QueryString["CC"];
                            strCAC = Request.QueryString["CA"];

                            if (strCC != null && strCAC != null)
                            {
                                txtCC.Text = strCC;
                                //txtCACode.Text = strCAC;
                                txtCC.Enabled = false;
                                btnSubmit.Enabled = true;
                                get_income_type();
                            }
                            else
                            {
                                txtCC.Enabled = true;
                                btnSubmit.Enabled = true;
                                get_income_type();
                            }
                        }
                        else
                        {
                            Response.Redirect("salam.aspx");
                        }
                    }
                }
                else
                {
                    if (txtVariety1.Text != "")
                    {
                        txtMinimumPriceExpected.Text = txtVariety1.Text;
                        txtMinimumPriceExpected.Enabled = false;
                    }
                    if (txtVariety2.Text != "")
                    {
                        txtMaximumPriceExpected.Text = txtVariety2.Text;
                        txtQualityExpected.Text = txtVariety2.Text;
                        txtExpectedPricePerUnit.Text = txtVariety2.Text;
                        txtMaximumPriceExpected.Enabled = false;
                        txtQualityExpected.Enabled = false;
                        txtExpectedPricePerUnit.Enabled = false;
                    }
                    if (txtHarvestPeriod.Text != "")
                    {
                        txtPeriodRepayment.Text = txtHarvestPeriod.Text;
                        txtPeriodRepayment.Enabled = false;
                    }
                    if (txtHarvestTotal.Text != "")
                    {
                        txtNumberOfUnits.Text = txtHarvestTotal.Text;
                        txtNumberOfUnits.Enabled = false;
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO salam_loan_details (ccode, loan_amount, incomesource1_1, incomesource1_2, incomesource1_3, incomesource2_1, incomesource2_2, incomesource2_3, areaofFarming, typeofv1, typeofv2, ex_years, total_harvest, harvesting_period, seasons_for_year, rain_water, irrigation_water, bothRwNRw, min_expected_price, max_expected_price, unit, type_of_product, conditionExpected, agreedPrice1, agreedPrice2, discussed1, discussed2, client_Farmer_Association, insurance_for_farming, insurer_details, totalMonthINcome, totalMonthExpenseBusiness, totalMonthExpenseFamily, AdditionalIncome, CashBalanceMonth, re_pay_period, ex_price_per_unit, annual_rate, rate_for_period, exp_profit, exp_sale_price, exp_unit, loan_approved, loan_approved_user_nic, loan_approved_on, loan_sta, reg_approval) VALUES (@ccode, @loan_amount, @incomesource1_1, @incomesource1_2, @incomesource1_3, @incomesource2_1, @incomesource2_2, @incomesource2_3, @areaofFarming, @typeofv1, @typeofv2, @ex_years, @total_harvest, @harvesting_period, @seasons_for_year, @rain_water, @irrigation_water, @bothRwNRw, @min_expected_price, @max_expected_price, @unit, @type_of_product, @conditionExpected, @agreedPrice1, @agreedPrice2, @discussed1, @discussed2, @client_Farmer_Association, @insurance_for_farming, @insurer_details, @totalMonthINcome, @totalMonthExpenseBusiness, @totalMonthExpenseFamily, @AdditionalIncome, @CashBalanceMonth, @re_pay_period, @ex_price_per_unit, @annual_rate, @rate_for_period, @exp_profit, @exp_sale_price, @exp_unit, @loan_approved, @loan_approved_user_nic, @loan_approved_on, @loan_sta, @reg_approval)");

                cmdInsert.Parameters.AddWithValue("@ccode", txtCC.Text.Trim());
                //cmdInsert.Parameters.AddWithValue("@cacode", txtCACode.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@loan_amount", (txtFinancialAmount.Text.Trim() != "") ? Convert.ToInt32(txtFinancialAmount.Text.Trim()) : 00);
                cmdInsert.Parameters.AddWithValue("@incomesource1_1", cmbIncomeSource1_a.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@incomesource1_2", cmbIncomeSource1_b.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@incomesource1_3", cmbIncomeSource1_c.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@incomesource2_1", cmbIncomeSource2_a.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@incomesource2_2", cmbIncomeSource2_b.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@incomesource2_3", cmbIncomeSource2_c.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@areaofFarming", txtCultivation_Farming.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@typeofv1", txtVariety1.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@typeofv2", txtVariety2.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@ex_years", txtExperienceInYears.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@total_harvest", txtHarvestTotal.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@harvesting_period", (txtHarvestPeriod.Text.Trim() != "") ? Convert.ToInt32(txtHarvestPeriod.Text.Trim()) : 00);
                cmdInsert.Parameters.AddWithValue("@seasons_for_year", (txtSeasonsInYear.Text.Trim() != "") ? Convert.ToInt32(txtSeasonsInYear.Text.Trim()) : 00);
                if (rdoRW_Y.Checked) cmdInsert.Parameters.AddWithValue("@rain_water", "y");
                else cmdInsert.Parameters.AddWithValue("@rain_water", "n");
                if (rdoIW_Y.Checked) cmdInsert.Parameters.AddWithValue("@irrigation_water", "y");
                else cmdInsert.Parameters.AddWithValue("@irrigation_water", "n");
                if (rdoB_Y.Checked) cmdInsert.Parameters.AddWithValue("@bothRwNRw", "y");
                else cmdInsert.Parameters.AddWithValue("@bothRwNRw", "n");
                cmdInsert.Parameters.AddWithValue("@min_expected_price", (txtMinimumPriceExpected.Text.Trim()!="")?Convert.ToDecimal(txtMinimumPriceExpected.Text.Trim()):00);
                cmdInsert.Parameters.AddWithValue("@max_expected_price", (txtMaximumPriceExpected.Text.Trim()!="") ? Convert.ToDecimal(txtMaximumPriceExpected.Text.Trim()) : 00);
                cmdInsert.Parameters.AddWithValue("@unit", cmbUnits.SelectedItem.Text.ToString());
                cmdInsert.Parameters.AddWithValue("@re_pay_period", txtPeriodRepayment.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@ex_price_per_unit", (txtExpectedPricePerUnit.Text.Trim()!="") ? Convert.ToDecimal(txtExpectedPricePerUnit.Text.Trim()) : 00);
                cmdInsert.Parameters.AddWithValue("@annual_rate", txtAnnualRate.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@rate_for_period", txtRatePeriod.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@exp_profit", (txtExpectedProfit.Text.Trim()!="")? Convert.ToDecimal(txtExpectedProfit.Text.Trim()):00);
                cmdInsert.Parameters.AddWithValue("@exp_sale_price", (txtExpectedSellingPrice.Text.Trim()!="") ? Convert.ToDecimal(txtExpectedSellingPrice.Text.Trim()) : 00);
                cmdInsert.Parameters.AddWithValue("@exp_unit", txtExpectedUnit.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@loan_approved","P");
                cmdInsert.Parameters.AddWithValue("@loan_approved_user_nic", Session["NIC"].ToString());
                cmdInsert.Parameters.AddWithValue("@loan_approved_on", "");
                cmdInsert.Parameters.AddWithValue("@loan_sta", "P");
                cmdInsert.Parameters.AddWithValue("@reg_approval", "Y");

                cmdInsert.Parameters.AddWithValue("@type_of_product", txtTypeOfProducts.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@conditionExpected", txtQualityExpected.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@agreedPrice1", txtAgreedPrice.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@agreedPrice2", txtAgreedPrice2.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@discussed1", (rdoSellingOpt1Yes.Checked) ? 1 : 0);
                cmdInsert.Parameters.AddWithValue("@discussed2", (rdoSellingOpt2Yes.Checked) ? 1 : 0);
                cmdInsert.Parameters.AddWithValue("@client_Farmer_Association", (rdoGeneral1Yes.Checked) ? 1 : 0);
                cmdInsert.Parameters.AddWithValue("@insurance_for_farming", (rdoGeneral2Yes.Checked) ? 1 : 0);
                cmdInsert.Parameters.AddWithValue("@insurer_details", txtInsurerDetails.Text.Trim());

                cmdInsert.Parameters.AddWithValue("@totalMonthINcome", txtMonthlyIncome.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@totalMonthExpenseBusiness", txtMonthlyExpenceB.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@totalMonthExpenseFamily", txtMonthlyExpenceF.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@AdditionalIncome", txtAdditionalIn.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@CashBalanceMonth", txtCashBalance.Text.Trim());

                try
                {
                    int i = conn.insertEditData(cmdInsert);
                    DetailsOfAssets();
                    SavingsAndInsurance();
                    if (i == 1)
                    {
                        Clear();
                        lblMsg.Text = "Successfull";
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured";
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception) { }
        }

        private bool SavingsAndInsurance()
        { 
        }
        
        private bool DetailsOfAssets()
        {
            string strCC = txtCC.Text.Trim();
            StringBuilder strAssets = new StringBuilder();
            strAssets.Append("INSERT INTO salam_details_of_assets (ccode,typeOfAsset,value,source,status,create_user_nic,user_ip,date_time) VALUES ");
            if (cmbAssetType1.SelectedIndex > 0)
            {
                string source, status;
                if (rdoOther1.Checked) source = "o";
                else if (rdoGift1.Checked) source = "g";
                else if (rdoIncome1.Checked) source = "i";
                else { }

                if (rdoF1.Checked) status = "F";
                else if (rdoP1.Checked) status = "P";
                else if (rdoI1.Checked) status = "I";
                else { }
                strAssets.Append("('" + strCC + "', '" + cmbAssetType1.SelectedValue.ToString() + "','" + txtValue1.Text.Trim() + "','" + source + "','" + status);
            }
            if (cmbAssetType2.SelectedIndex > 0)
            {
                string source2, status2;
                if (rdoOther2.Checked) source = "o";
                else if (rdoGift2.Checked) source = "g";
                else if (rdoIncome2.Checked) source = "i";
                else { }

                if (rdoF2.Checked) status = "F";
                else if (rdoP2.Checked) status = "P";
                else if (rdoI2.Checked) status = "I";
                else { }
                strAssets.Append("),('" + strCC + "', '" + cmbAssetType2.SelectedValue.ToString() + "','" + txtValue2.Text.Trim() + "','" + source2 + "','" + status2);
            }
            if (cmbAssetType3.SelectedIndex > 0)
            {
                string source3, status3;
                if (rdoOther3.Checked) source = "o";
                else if (rdoGift3.Checked) source = "g";
                else if (rdoIncome3.Checked) source = "i";
                else { }

                if (rdoF3.Checked) status = "F";
                else if (rdoP3.Checked) status = "P";
                else if (rdoI3.Checked) status = "I";
                else { }
                strAssets.Append("),('" + strCC + "', '" + cmbAssetType3.SelectedValue.ToString() + "','" + txtValue3.Text.Trim() + "','" + source3 + "','" + status3);
            }
            if (cmbAssetType4.SelectedIndex > 0)
            {
                string source4, status4;
                if (rdoOther4.Checked) source = "o";
                else if (rdoGift4.Checked) source = "g";
                else if (rdoIncome4.Checked) source = "i";
                else { }

                if (rdoF4.Checked) status = "F";
                else if (rdoP4.Checked) status = "P";
                else if (rdoI4.Checked) status = "I";
                else { }
                strAssets.Append("),('" + strCC + "', '" + cmbAssetType4.SelectedValue.ToString() + "','" + txtValue4.Text.Trim() + "','" + source4 + "','" + status4);
            }
            if (cmbAssetType5.SelectedIndex > 0)
            {
                string source5, status5;
                if (rdoOther5.Checked) source = "o";
                else if (rdoGift5.Checked) source = "g";
                else if (rdoIncome5.Checked) source = "i";
                else { }

                if (rdoF5.Checked) status = "F";
                else if (rdoP5.Checked) status = "P";
                else if (rdoI5.Checked) status = "I";
                else { }
                strAssets.Append("),('" + strCC + "', '" + cmbAssetType5.SelectedValue.ToString() + "','" + txtValue5.Text.Trim() + "','" + source5 + "','" + status5);
            }

            strAssets.Append(")");

            return conn.insertEditData(strAssets.ToString());
        }

        protected void Clear()
        {
            txtCC.Text="";
            //txtCACode.Text="";
            cmbIncomeSource1_a.SelectedIndex = 0;
            cmbIncomeSource1_b.SelectedIndex = 0;
            cmbIncomeSource1_c.SelectedIndex = 0;
            cmbIncomeSource2_a.SelectedIndex = 0;
            cmbIncomeSource2_b.SelectedIndex = 0;
            cmbIncomeSource2_c.SelectedIndex = 0;
            txtCultivation_Farming.Text="";
            txtVariety1.Text="";
            txtVariety2.Text="";
            txtExperienceInYears.Text="";
            txtHarvestTotal.Text="";
            txtHarvestPeriod.Text="";
            txtSeasonsInYear.Text="";
            rdoRW_Y.Checked = true;
            rdoIW_Y.Checked = true;
            rdoB_Y.Checked = true;
            txtMinimumPriceExpected.Text = "";
            txtMaximumPriceExpected.Text = "";
            cmbUnits.SelectedIndex=0;
            txtPeriodRepayment.Text="";
            txtExpectedPricePerUnit.Text = "";
            txtAnnualRate.Text="";
            txtRatePeriod.Text="";
            txtExpectedProfit.Text="";
            txtExpectedSellingPrice.Text="";
            txtExpectedUnit.Text="";
        }
    }
}
