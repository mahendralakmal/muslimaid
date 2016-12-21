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
                            btnSubmit.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO `muslimaid`.`salam_repay` ( `ccode`, `cacode`, `incomesource1_1`, `incomesource1_2`, `incomesource1_3`, `incomesource2_1`, `incomesource2_2`, `incomesource2_3`, `areaofFarming`, `typeofv1`, `typeofv2`, `ex_years`, `total_harvest`, `harvesting_period`, `seasons_for_year`, `rain_water`, `irrigation_water`, `both`, `min_expected_price`, `max_expected_price`, `unit`, `re_pay_period`, `ex_price_per_unit`, `annual_rate`, `rate_for_period`, `exp_profit`, `exp_sale_price`, `exp_unit` ) VALUES ( `@ccode`, `@cacode`, `@incomesource1_1`, `@incomesource1_2`, `@incomesource1_3`, `@incomesource2_1`, `@incomesource2_2`, `@incomesource2_3`, `@areaofFarming`, `@typeofv1`, `@typeofv2`, `@ex_years`, `@total_harvest`, `@harvesting_period`, `@seasons_for_year`, `@rain_water`, `@irrigation_water`, `@both`, `@min_expected_price`, `@max_expected_price`, `@unit`, `@re_pay_period`, `@ex_price_per_unit`, `@annual_rate`, `@rate_for_period`, `@exp_profit`, `@exp_sale_price`, `@exp_unit` )");

                cmdInsert.Parameters.AddWithValue("`@ccode`", txtCC.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@cacode`", txtCACode.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@incomesource1_1`", cmbIncomeSource1_a.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("`@incomesource1_2`", cmbIncomeSource1_b.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("`@incomesource1_3`", cmbIncomeSource1_c.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("`@incomesource2_1`", cmbIncomeSource2_a.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("`@incomesource2_2`", cmbIncomeSource2_b.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("`@incomesource2_3`", cmbIncomeSource2_c.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("`@areaofFarming`", txtCultivation_Farming.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@typeofv1`", txtVariety1.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@typeofv2`", txtVariety2.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@ex_years`", txtExperienceInYears.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@total_harvest`", txtHarvestTotal.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@harvesting_period`", txtHarvestPeriod.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@seasons_for_year`", txtSeasonsInYear.Text.Trim());
                if (rdoRW_Y.Checked) cmdInsert.Parameters.AddWithValue("`@rain_water`", "y");
                else cmdInsert.Parameters.AddWithValue("`@rain_water`", "n");
                if (rdoIW_Y.Checked) cmdInsert.Parameters.AddWithValue("`@irrigation_water`", "y");
                else cmdInsert.Parameters.AddWithValue("`@irrigation_water`", "n");
                if (rdoB_Y.Checked) cmdInsert.Parameters.AddWithValue("`@both`", "y");
                else cmdInsert.Parameters.AddWithValue("`@both`", "n");
                cmdInsert.Parameters.AddWithValue("`@min_expected_price`", txtMinimumPriceExpected.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@max_expected_price`", txtMaximumPriceExpected.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@unit`", cmbUnits.SelectedItem.Text.ToString());
                cmdInsert.Parameters.AddWithValue("`@re_pay_period`", txtPeriodRepayment.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@ex_price_per_unit`", txtExpectedPricePerUnit.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@annual_rate`", txtAnnualRate.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@rate_for_period`", txtRatePeriod.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@exp_profit`", txtExpectedProfit.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@exp_sale_price`", txtExpectedSellingPrice.Text.Trim());
                cmdInsert.Parameters.AddWithValue("`@exp_unit", txtExpectedUnit.Text.Trim());

                try
                {
                    int i = conn.insertEditData(cmdInsert);
                    if (i == 1)
                    {
                        //Response.Redirect("family_details.aspx?CC=" + strCC + "&CA=" + strCACodeNew + "");
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
    }
}
