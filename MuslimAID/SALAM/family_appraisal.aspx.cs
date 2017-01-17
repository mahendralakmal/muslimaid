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
                        //strCC = "CO/CS/000004";
                        //strCAC = "CO/1/01/02";

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
                else
                {
                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO `muslimaid`.`salam_family_appraisal`(`contract_code`,`salary_n_wages`,`rentIncome`,`rent_income_other`,`net_Income_business`,`other_income`,`food_ex`,`education_ex`,`wet_ex`,`health_n_sanitation`,`rent_ex`,`other_facility_ex`,`travel_n_transport`,`clothes_ex`,`other_ex`,`amount_opex`,`amount_fex`,`fr_period`,`mad`,`mdaaip`,`rapsa`,`create_date`,`update_date`,`create_user`,`update_user`) VALUES (`@contract_code`,`@salary_n_wages`,`@rentIncome`,`@rent_income_other`,`@net_Income_business`,`@other_income`,`@food_ex`,`@education_ex`,`@wet_ex`,`@health_n_sanitation`,`@rent_ex`,`@other_facility_ex`,`@travel_n_transport`,`@clothes_ex`,`@other_ex`,`@amount_opex`,`@amount_fex`,`@fr_period`,`@mad`,`@mdaaip`,`@rapsa`,`@create_date`,`@update_date`,`@create_user`,`@update_user`)");

                    #region Parameter Declarations
                    cmdInsert.Parameters.AddWithValue("`@contract_code`", txtCC.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("`@salary_n_wages`",  Convert.ToDecimal(txtSalWages.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@rentIncome`", Convert.ToDecimal(txtRentBuildingIn.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@rent_income_other`", Convert.ToDecimal(txtRentInOther.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@net_Income_business`", Convert.ToDecimal(txtNetBusinesIn.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@other_income`", Convert.ToDecimal(txtInO.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@food_ex`", Convert.ToDecimal(txtFoodEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@education_ex`", Convert.ToDecimal(txtEduEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@wet_ex`", Convert.ToDecimal(txtWETEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@health_n_sanitation`", Convert.ToDecimal(txtHSEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@rent_ex`", Convert.ToDecimal(txtRenPayEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@other_facility_ex`", Convert.ToDecimal(txtOFAIEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@travel_n_transport`", Convert.ToDecimal(txtTTransEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@clothes_ex`", Convert.ToDecimal(txtClothsEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@other_ex`", Convert.ToDecimal(txtOthersEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@amount_opex`", Convert.ToDecimal(txtAmountOPEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@amount_fex`", Convert.ToDecimal(txtAmountFEx.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@fr_period`", Convert.ToDecimal(txtFRPriod.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@mad`", Convert.ToDecimal(txtMAD.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@mdaaip`", Convert.ToDecimal(txtMDAAIP.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@rapsa`", Convert.ToDecimal(txtRAPSA.Text.Trim()));
                    cmdInsert.Parameters.AddWithValue("`@create_date`", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmdInsert.Parameters.AddWithValue("`@create_user`", Request.UserHostAddress);
                    #endregion

                    try {
                        int i = objDBCon.insertEditData(cmdInsert);

                        if (i > 0)
                        {
                            Response.Redirect("supplier.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + txtCACode.Text.Trim());
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
            MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE `muslimaid`.`salam_family_appraisal` SET `salary_n_wages` = '" + txtSalWages.Text.Trim() + "',`rentIncome` = '" + txtRentBuildingIn.Text.Trim() + "',`rent_income_other` = '" + txtRentInOther.Text.Trim() + "',`net_Income_business` = '" + txtNetBusinesIn.Text.Trim() + "',`other_income` = '" + txtInO.Text.Trim() + "',`food_ex` = '" + txtFoodEx.Text.Trim() + "',`education_ex` = '" + txtEduEx.Text.Trim() + "',`wet_ex` = '" + txtWETEx.Text.Trim() + "',`health_n_sanitation` = '" + txtHSEx.Text.Trim() + "',`rent_ex` = '" + txtRenPayEx.Text.Trim() + "',`other_facility_ex` = '" + txtOFAIEx.Text.Trim() + "',`travel_n_transport` = '" + txtTTransEx.Text.Trim() + "',`clothes_ex` = '" + txtClothsEx.Text.Trim() + "',`other_ex` = '" + txtOthersEx.Text.Trim() + "',`amount_opex` = '" + txtAmountOPEx.Text.Trim() + "',`amount_fex` = '" + txtAmountFEx.Text.Trim() + "',`fr_period` = '" + txtFRPriod.Text.Trim() + "',`mad` = '" + txtMAD.Text.Trim() + "',`mdaaip` = '" + txtMDAAIP.Text.Trim() + "',`rapsa` = '" + txtRAPSA.Text.Trim() + "',`update_date` = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',`update_user` = '" + Request.UserHostAddress + "' WHERE `contract_code` = '" + txtCC.Text.Trim() + "';");

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
