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
    public partial class family_appraisal : System.Web.UI.Page
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
                            txtCACode.Text = strCAC;
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
            catch (Exception)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCC.Text.Trim() == "")
                {
                    lblMsg.Text = "Please Enter Facility Code";
                }
                else if (txtCACode.Text.Trim() == "")
                {
                    lblMsg.Text = "Please Enter CA Code";
                }
                else if (txtSalWages.Text.Trim() == "")
                {
                    lblMsg.Text = "Please Enter Salary & Wages";
                }
                else
                {
                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO salam_family_appraisal(contract_code,salary_n_wages,rentIncome,rent_income_other,net_Income_business,other_income,total_annual_family_in, food_ex,education_ex,wet_ex,health_n_sanitation,rent_ex,other_facility_ex,travel_n_transport,clothes_ex,other_ex,total_annual_family_ex,net_annual_family_in,amount_opex,amount_fex,fr_period,mad,mdaaip,rapsa,create_date,create_user) VALUES (@contract_code,@salary_n_wages,@rentIncome,@rent_income_other,@net_Income_business,@other_income,@total_annual_family_in,@food_ex,@education_ex,@wet_ex,@health_n_sanitation,@rent_ex,@other_facility_ex,@travel_n_transport,@clothes_ex,@other_ex,@total_annual_family_ex,@net_annual_family_in,@amount_opex,@amount_fex,@fr_period,@mad,@mdaaip,@rapsa,@create_date,@create_user)");

                    #region Parameter Declarations
                    cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 15);
                    cmdInsert.Parameters.Add("@salary_n_wages", MySqlDbType.Decimal,10);
                    cmdInsert.Parameters.Add("@rentIncome", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@rent_income_other", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@net_Income_business", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@other_income", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@total_annual_family_in", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@food_ex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@education_ex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@wet_ex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@health_n_sanitation", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@rent_ex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@other_facility_ex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@travel_n_transport", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@clothes_ex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@other_ex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@total_annual_family_ex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@net_annual_family_in", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@amount_opex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@amount_fex", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@fr_period", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@mad", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@mdaaip", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@rapsa", MySqlDbType.Decimal, 10);
                    cmdInsert.Parameters.Add("@create_date", MySqlDbType.VarChar, 45);
                    cmdInsert.Parameters.Add("@create_user", MySqlDbType.VarChar, 45);

                    cmdInsert.Parameters["@contract_code"].Value = txtCC.Text.Trim();
                    cmdInsert.Parameters["@salary_n_wages"].Value = (txtSalWages.Text.Trim()!="")?Convert.ToDecimal(txtSalWages.Text.Trim()):00;
                    cmdInsert.Parameters["@rentIncome"].Value = (txtRentBuildingIn.Text.Trim() != "") ? Convert.ToDecimal(txtRentBuildingIn.Text.Trim()) : 00;
                    cmdInsert.Parameters["@rent_income_other"].Value = (txtRentInOther.Text.Trim() != "") ? Convert.ToDecimal(txtRentInOther.Text.Trim()):00;
                    cmdInsert.Parameters["@net_Income_business"].Value = (txtNetBusinesIn.Text.Trim() != "") ? Convert.ToDecimal(txtNetBusinesIn.Text.Trim()):00;
                    cmdInsert.Parameters["@other_income"].Value = (txtInO.Text.Trim() != "") ? Convert.ToDecimal(txtInO.Text.Trim()):00;
                    cmdInsert.Parameters["@total_annual_family_in"].Value = (txtFamilyIn.Text.Trim()!="") ? Convert.ToDecimal(txtFamilyIn.Text.Trim()) : 00;
                    cmdInsert.Parameters["@food_ex"].Value = (txtFoodEx.Text.Trim()!="") ? Convert.ToDecimal(txtFoodEx.Text.Trim()):00;
                    cmdInsert.Parameters["@education_ex"].Value = (txtEduEx.Text.Trim() != "") ? Convert.ToDecimal(txtEduEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@wet_ex"].Value = (txtWETEx.Text.Trim() != "") ? Convert.ToDecimal(txtWETEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@health_n_sanitation"].Value = (txtHSEx.Text.Trim() != "") ? Convert.ToDecimal(txtHSEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@rent_ex"].Value = (txtRenPayEx.Text.Trim() != "") ? Convert.ToDecimal(txtRenPayEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@other_facility_ex"].Value = (txtOFAIEx.Text.Trim() != "") ? Convert.ToDecimal(txtOFAIEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@travel_n_transport"].Value = (txtTTransEx.Text.Trim() != "") ? Convert.ToDecimal(txtTTransEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@clothes_ex"].Value = (txtClothsEx.Text.Trim() != "") ? Convert.ToDecimal(txtClothsEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@other_ex"].Value = (txtOthersEx.Text.Trim() != "") ? Convert.ToDecimal(txtOthersEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@total_annual_family_ex"].Value = (txtFExpense.Text.Trim() != "") ? Convert.ToDecimal(txtFExpense.Text.Trim()) : 00;
                    cmdInsert.Parameters["@net_annual_family_in"].Value = (txtNetAnualFIn.Text.Trim() != "") ? Convert.ToDecimal(txtNetAnualFIn.Text.Trim()) : 00;
                    cmdInsert.Parameters["@amount_opex"].Value = (txtAmountOPEx.Text.Trim() != "") ? Convert.ToDecimal(txtAmountOPEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@amount_fex"].Value = (txtAmountFEx.Text.Trim() != "") ? Convert.ToDecimal(txtAmountFEx.Text.Trim()) : 00;
                    cmdInsert.Parameters["@fr_period"].Value = (txtFRPriod.Text.Trim() != "") ? Convert.ToDecimal(txtFRPriod.Text.Trim()) : 00;
                    cmdInsert.Parameters["@mad"].Value = (txtMAD.Text.Trim() != "") ? Convert.ToDecimal(txtMAD.Text.Trim()) : 00;
                    cmdInsert.Parameters["@mdaaip"].Value = (txtMDAAIP.Text.Trim() != "") ? Convert.ToDecimal(txtMDAAIP.Text.Trim()) : 00;
                    cmdInsert.Parameters["@rapsa"].Value = (txtRAPSA.Text.Trim() != "") ? Convert.ToDecimal(txtRAPSA.Text.Trim()) : 00;
                    cmdInsert.Parameters["@create_date"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    cmdInsert.Parameters["@create_user"].Value = Request.UserHostAddress;
                    #endregion

                    try {
                        int i = objDBCon.insertEditData(cmdInsert);

                        if (i > 0)
                        {
                            Response.Redirect("repayment.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + txtCACode.Text.Trim() + "");
                        }
                        else
                        {
                            lblMsg.Text = "Error Occured";
                        }
                    }
                    catch (Exception ex) { 
                    
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE muslimaid.micro_family_appraisal SET salary_n_wages = '" + txtSalWages.Text.Trim() + "',rentIncome = '" + txtRentBuildingIn.Text.Trim() + "',rent_income_other = '" + txtRentInOther.Text.Trim() + "',net_Income_business = '" + txtNetBusinesIn.Text.Trim() + "',other_income = '" + txtInO.Text.Trim() + "',food_ex = '" + txtFoodEx.Text.Trim() + "',education_ex = '" + txtEduEx.Text.Trim() + "',wet_ex = '" + txtWETEx.Text.Trim() + "',health_n_sanitation = '" + txtHSEx.Text.Trim() + "',rent_ex = '" + txtRenPayEx.Text.Trim() + "',other_facility_ex = '" + txtOFAIEx.Text.Trim() + "',travel_n_transport = '" + txtTTransEx.Text.Trim() + "',clothes_ex = '" + txtClothsEx.Text.Trim() + "',other_ex = '" + txtOthersEx.Text.Trim() + "',amount_opex = '" + txtAmountOPEx.Text.Trim() + "',amount_fex = '" + txtAmountFEx.Text.Trim() + "',fr_period = '" + txtFRPriod.Text.Trim() + "',mad = '" + txtMAD.Text.Trim() + "',mdaaip = '" + txtMDAAIP.Text.Trim() + "',rapsa = '" + txtRAPSA.Text.Trim() + "',update_date = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',update_user = '" + Request.UserHostAddress + "' WHERE contract_code = '" + txtCC.Text.Trim() + "';");

            try
            {
                int i = objDBCon.insertEditData(cmdUpdateQRY);

                if (i > 0)
                {
                    Clear();
                    lblMsg.Text = "Update Success.";
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

        protected void Clear()
        {
            txtAmountFEx.Text = "";
            txtAmountOPEx.Text = "";
            txtCACode.Text = "";
            txtCC.Text = "";
            txtClothsEx.Text = "";
            txtEduEx.Text = "";
            txtFamilyIn.Text = "";
            txtFExpense.Text = "";
            txtFoodEx.Text = "";
            txtFRPriod.Text = "";
            txtHSEx.Text = "";
            txtInO.Text = "";
            txtMAD.Text = "";
            txtMDAAIP.Text = "";
            txtNetAnualFIn.Text = "";
            txtNetBusinesIn.Text = "";
            txtOFAIEx.Text = "";
            txtOthersEx.Text = "";
            txtRAPSA.Text = "";
            txtRenPayEx.Text = "";
            txtRentBuildingIn.Text = "";
            txtRentInOther.Text = "";
            txtSalWages.Text = "";
            txtTTransEx.Text = "";
            txtWETEx.Text = "";
        }
    }
}
