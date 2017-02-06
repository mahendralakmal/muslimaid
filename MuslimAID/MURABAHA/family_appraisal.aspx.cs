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
                    lblMsg.Text = "Please Enter Contract Code";
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
                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_family_appraisal(contract_code,salary_n_wages,rentIncome,rent_income_other,net_Income_business,other_income,total_annual_family_in, food_ex,education_ex,wet_ex,health_n_sanitation,rent_ex,other_facility_ex,travel_n_transport,clothes_ex,other_ex,total_annual_family_ex,net_annual_family_in,amount_opex,amount_fex,fr_period,mad,mdaaip,rapsa,create_date,create_user) VALUES (@contract_code,@salary_n_wages,@rentIncome,@rent_income_other,@net_Income_business,@other_income,@total_annual_family_in,@food_ex,@education_ex,@wet_ex,@health_n_sanitation,@rent_ex,@other_facility_ex,@travel_n_transport,@clothes_ex,@other_ex,@total_annual_family_ex,@net_annual_family_in,@amount_opex,@amount_fex,@fr_period,@mad,@mdaaip,@rapsa,@create_date,@create_user)");

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
                    cmdInsert.Parameters["@salary_n_wages"].Value = Convert.ToDecimal(txtSalWages.Text.Trim());
                    cmdInsert.Parameters["@rentIncome"].Value = Convert.ToDecimal(txtRentBuildingIn.Text.Trim());
                    cmdInsert.Parameters["@rent_income_other"].Value = Convert.ToDecimal(txtRentInOther.Text.Trim());
                    cmdInsert.Parameters["@net_Income_business"].Value = Convert.ToDecimal(txtNetBusinesIn.Text.Trim());
                    cmdInsert.Parameters["@other_income"].Value = Convert.ToDecimal(txtInO.Text.Trim());
                    cmdInsert.Parameters["@total_annual_family_in"].Value = Convert.ToDecimal(txtFamilyIn.Text.Trim());
                    cmdInsert.Parameters["@food_ex"].Value = Convert.ToDecimal(txtFoodEx.Text.Trim());
                    cmdInsert.Parameters["@education_ex"].Value = Convert.ToDecimal(txtEduEx.Text.Trim());
                    cmdInsert.Parameters["@wet_ex"].Value = Convert.ToDecimal(txtWETEx.Text.Trim());
                    cmdInsert.Parameters["@health_n_sanitation"].Value = Convert.ToDecimal(txtHSEx.Text.Trim());
                    cmdInsert.Parameters["@rent_ex"].Value = Convert.ToDecimal(txtRenPayEx.Text.Trim());
                    cmdInsert.Parameters["@other_facility_ex"].Value = Convert.ToDecimal(txtOFAIEx.Text.Trim());
                    cmdInsert.Parameters["@travel_n_transport"].Value = Convert.ToDecimal(txtTTransEx.Text.Trim());
                    cmdInsert.Parameters["@clothes_ex"].Value = Convert.ToDecimal(txtClothsEx.Text.Trim());
                    cmdInsert.Parameters["@other_ex"].Value = Convert.ToDecimal(txtOthersEx.Text.Trim());
                    cmdInsert.Parameters["@total_annual_family_ex"].Value = Convert.ToDecimal(txtFExpense.Text.Trim());
                    cmdInsert.Parameters["@net_annual_family_in"].Value = Convert.ToDecimal(txtNetAnualFIn.Text.Trim());
                    cmdInsert.Parameters["@amount_opex"].Value = Convert.ToDecimal(txtAmountOPEx.Text.Trim());
                    cmdInsert.Parameters["@amount_fex"].Value = Convert.ToDecimal(txtAmountFEx.Text.Trim());
                    cmdInsert.Parameters["@fr_period"].Value = Convert.ToDecimal(txtFRPriod.Text.Trim());
                    cmdInsert.Parameters["@mad"].Value = Convert.ToDecimal(txtMAD.Text.Trim());
                    cmdInsert.Parameters["@mdaaip"].Value = Convert.ToDecimal(txtMDAAIP.Text.Trim());
                    cmdInsert.Parameters["@rapsa"].Value = Convert.ToDecimal(txtRAPSA.Text.Trim());
                    cmdInsert.Parameters["@create_date"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    cmdInsert.Parameters["@create_user"].Value = Request.UserHostAddress;
                    #endregion

                    try {
                        int i = objDBCon.insertEditData(cmdInsert);

                        if (i > 0)
                        {
                            Response.Redirect("business_details.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + txtCACode.Text.Trim() + "");
                            //Response.Redirect("supplier.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + txtCACode.Text.Trim());
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
