﻿using System;
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

namespace MuslimAID.SALAM
{
    public partial class repayment : System.Web.UI.Page
    {
        string strCC, strCAC;
        cls_Connection conn = new cls_Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
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
                            txtCACode.Text = strCAC;
                            txtCC.Enabled = false;
                            btnSubmit.Enabled = true;
                        }
                        else
                        {
                            txtCC.Enabled = true;
                            btnSubmit.Enabled = true;
                        }
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
                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO salam_loan_details ( ccode, cacode, incomesource1_1, incomesource1_2, incomesource1_3, incomesource2_1, incomesource2_2, incomesource2_3, areaofFarming, typeofv1, typeofv2, ex_years, total_harvest, harvesting_period, seasons_for_year, rain_water, irrigation_water, bothRwNRw, min_expected_price, max_expected_price, unit, re_pay_period, ex_price_per_unit, annual_rate, rate_for_period, exp_profit, exp_sale_price, exp_unit, loan_approved, loan_approved_user_nic, loan_approved_on, loan_sta,reg_approval) VALUES ( @ccode, @cacode, @incomesource1_1, @incomesource1_2, @incomesource1_3, @incomesource2_1, @incomesource2_2, @incomesource2_3, @areaofFarming, @typeofv1, @typeofv2, @ex_years, @total_harvest, @harvesting_period, @seasons_for_year, @rain_water, @irrigation_water, @bothRwNRw, @min_expected_price, @max_expected_price, @unit, @re_pay_period, @ex_price_per_unit, @annual_rate, @rate_for_period, @exp_profit, @exp_sale_price, @exp_unit, @loan_approved, @loan_approved_user_nic, @loan_approved_on, @loan_sta,@reg_approval)");

                cmdInsert.Parameters.AddWithValue("@ccode", txtCC.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@cacode", txtCACode.Text.Trim());
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
                cmdInsert.Parameters.AddWithValue("loan_approved","P");
                cmdInsert.Parameters.AddWithValue("loan_approved_user_nic", Session["NIC"].ToString());
                cmdInsert.Parameters.AddWithValue("loan_approved_on", "");
                cmdInsert.Parameters.AddWithValue("loan_sta", "P");
                cmdInsert.Parameters.AddWithValue("reg_approval", "Y");

                try
                {
                    int i = conn.insertEditData(cmdInsert);
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

        protected void Clear()
        {
            txtCC.Text="";
            txtCACode.Text="";
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
