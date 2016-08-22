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
using System.Data;
using System.Text.RegularExpressions;

namespace MuslimAID.MURABHA
{
    public partial class business_details : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();
        string strCC, strCAC;

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
            lblMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Contract Code";
            }
            else if (txtCACode.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter CA Code";
            }
            else if (cmbPeriod.Text.Trim() == "")
            {
                lblMsg.Text = "Please Choose Period";
            }
            else if (cmbBPopulation.Text.Trim() == "")
            {
                lblMsg.Text = "Please Choose Business Population";
            }
            else if (txtBIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Business Income";
            }
            else if (txtOIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Other Income";
            }
            else if (txtTotalIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Total Income";
            }
            else if (txtDCost.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Direct Cost";
            }
            else if (txtICost.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter InDirect Cost";
            }
            else if (txtOExpenses.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Other Expenses";
            }
            else if (txtPAndL.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Business P & L";
            }
            else if (txtFExpenses.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Family Expenses";
            }
            else
            {
                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_business_details(contract_code,business_name,busi_duration,busi_address,busi_income,other_income,total_income,direct_cost,indirect_cost,other_expenses,total_expenses,profit_lost,family_expenses,net_income,create_user_nic,user_ip,date_time)VALUES(@contract_code,@business_name,@busi_duration,@busi_address,@busi_income,@other_income,@total_income,@direct_cost,@indirect_cost,@other_expenses,@total_expenses,@profit_lost,@family_expenses,@net_income,@create_user_nic,@user_ip,@date_time)");

                #region GetValues
                string strIp = Request.UserHostAddress;
                string strloginID = Session["NIC"].ToString();
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strCC = txtCC.Text.Trim();
                string strCA = txtCACode.Text.Trim();
                string strBN = txtBuss.Text.Trim();
                string strDur = cmbPeriod.SelectedValue;
                string strBAdd = txtBisAddress.Text.Trim();
                string strBPopu = cmbBPopulation.SelectedValue;
                string strNature = txtBNature.Text.Trim();
                string strKeyPerson = cmbKeyPerson.SelectedValue;
                string strNoOfPpl = txtNoOfPpl.Text.Trim();
                string strBrNo = txtBRNo.Text.Trim();
                string strBContcact = txtOffContact.Text.Trim();

                string strBIn = txtBIncome.Text.Trim();
                string strCIn = txtCrdtIncome.Text.Trim();
                string strOIn = txtOIncome.Text.Trim();
                string strTotalIn = txtTotalIncome.Text.Trim();

                string strDcost = txtDCost.Text.Trim();
                string strICost = txtICost.Text.Trim();
                string strTotPurchase = txtTotPurchase.Text.Trim();

                string strRent = txtRent.Text.Trim();
                string strWET = txtWET.Text.Trim();
                string strWages = txtWages.Text.Trim();
                string strFLA = txtFLA.Text.Trim();
                string strTravelTrans = txtTravelTrans.Text.Trim();
                string strRepairMain = txtRepairMain.Text.Trim();
               
                string strTotalEx = txtTExpenses.Text.Trim();
                string strBPL = txtPAndL.Text.Trim();
                #endregion

                #region DeclareValues
                cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@business_name", MySqlDbType.VarChar, 100);
                cmdInsert.Parameters.Add("@busi_duration", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@busi_address", MySqlDbType.VarChar, 255);
                cmdInsert.Parameters.Add("@busi_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@other_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@total_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@direct_cost", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@indirect_cost", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@other_expenses", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@total_expenses", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@profit_lost", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@family_expenses", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@net_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                #endregion

                #region AssignValues
                cmdInsert.Parameters["@contract_code"].Value = strCC;
                cmdInsert.Parameters["@business_name"].Value = strBN;
                cmdInsert.Parameters["@busi_duration"].Value = strDur;
                cmdInsert.Parameters["@busi_address"].Value = strBAdd;
                cmdInsert.Parameters["@busi_income"].Value = strBIn;
                cmdInsert.Parameters["@other_income"].Value = strOIn;
                cmdInsert.Parameters["@total_income"].Value = strTotalIn;
                cmdInsert.Parameters["@direct_cost"].Value = strDcost;
                cmdInsert.Parameters["@indirect_cost"].Value = strICost;
                cmdInsert.Parameters["@other_expenses"].Value = strOEx;
                cmdInsert.Parameters["@total_expenses"].Value = strTotalEx;
                cmdInsert.Parameters["@profit_lost"].Value = strBPL;
                cmdInsert.Parameters["@family_expenses"].Value = strFEx;
                cmdInsert.Parameters["@net_income"].Value = strNet;
                cmdInsert.Parameters["@create_user_nic"].Value = strloginID;
                cmdInsert.Parameters["@user_ip"].Value = strIp;
                cmdInsert.Parameters["@date_time"].Value = strDateTime;
                #endregion

                try
                {
                    int i = objDBCon.insertEditData(cmdInsert);
                    if (i == 1)
                    {
                        //lblMsg.Text = "Success";
                        Response.Redirect("Loan_Details.aspx?CC=" + strCC + "&CA=" + strCA + "");
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Contract Code";
            }
            else if (txtCACode.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter CA Code";
            }
            else if (cmbPeriod.Text.Trim() == "")
            {
                lblMsg.Text = "Please Choose Period";
            }
            else if (cmbBPopulation.Text.Trim() == "")
            {
                lblMsg.Text = "Please Choose Business Population";
            }
            else if (txtBIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Business Income";
            }
            else if (txtOIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Other Income";
            }
            else if (txtTotalIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Total Income";
            }
            else if (txtDCost.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Direct Cost";
            }
            else if (txtICost.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter InDirect Cost";
            }
            else if (txtOExpenses.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Other Expenses";
            }
            else if (txtPAndL.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Business P & L";
            }
            else if (txtFExpenses.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Family Expenses";
            }
            else
            {
                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_business_details(contract_code, business_name, busi_duration, busi_address, busi_population, busi_nature, key_person, no_of_ppl, br_no, contact_no_ofc, busi_income, sales_credit, other_income, total_income, purchase_cash, purchase_credit, direct_cost, rent, water_elec_tele, wages, fla_rent, travel, maintenance, indirect_cost, other_expenses, total_expenses, profit_lost, family_expenses, net_income, create_user_nic, user_ip, date_time)VALUES(@contract_code, @business_name, @busi_duration, @busi_address, @busi_population, @busi_nature, @key_person, @no_of_ppl, @br_no, @contact_no_ofc, @busi_income, @sales_credit, @other_income, @total_income, @purchase_cash, @purchase_credit, @direct_cost, @rent, @water_elec_tele, @wages, @fla_rent, @travel, @maintenance, @indirect_cost, @other_expenses, @total_expenses, @profit_lost, @family_expenses, @net_income, @create_user_nic, @user_ip, @date_time)");

                #region GetValues
                string strIp = Request.UserHostAddress;
                string strloginID = Session["NIC"].ToString();
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strCC = txtCC.Text.Trim();
                string strCA = txtCACode.Text.Trim();
                string strBN = txtBuss.Text.Trim();
                string strDur = cmbPeriod.SelectedValue;
                string strBAdd = txtBisAddress.Text.Trim();
                string strBPopu = cmbBPopulation.SelectedValue;
                string strBIn = txtBIncome.Text.Trim();
                string strOIn = txtOIncome.Text.Trim();
                string strTotalIn = txtTotalIncome.Text.Trim();
                string strDcost = txtDCost.Text.Trim();
                string strICost = txtICost.Text.Trim();
                string strOEx = txtOExpenses.Text.Trim();
                string strTotalEx = txtTExpenses.Text.Trim();
                string strBPL = txtPAndL.Text.Trim();
                string strFEx = txtFExpenses.Text.Trim();
                string strNet = txtNetIncome.Text.Trim();
                #endregion

                #region DeclareValues
                cmdInsert.Parameters.Add("@contract_code", MySqlDbType.VarChar, 12);
                cmdInsert.Parameters.Add("@business_name", MySqlDbType.VarChar, 100);
                cmdInsert.Parameters.Add("@busi_duration", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@busi_address", MySqlDbType.VarChar, 255);
                cmdInsert.Parameters.Add("@busi_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@other_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@total_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@direct_cost", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@indirect_cost", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@other_expenses", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@total_expenses", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@profit_lost", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@family_expenses", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@net_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                #endregion

                #region AssignValues
                cmdInsert.Parameters["@contract_code"].Value = strCC;
                cmdInsert.Parameters["@business_name"].Value = strBN;
                cmdInsert.Parameters["@busi_duration"].Value = strDur;
                cmdInsert.Parameters["@busi_address"].Value = strBAdd;
                cmdInsert.Parameters["@busi_income"].Value = strBIn;
                cmdInsert.Parameters["@other_income"].Value = strOIn;
                cmdInsert.Parameters["@total_income"].Value = strTotalIn;
                cmdInsert.Parameters["@direct_cost"].Value = strDcost;
                cmdInsert.Parameters["@indirect_cost"].Value = strICost;
                cmdInsert.Parameters["@other_expenses"].Value = strOEx;
                cmdInsert.Parameters["@total_expenses"].Value = strTotalEx;
                cmdInsert.Parameters["@profit_lost"].Value = strBPL;
                cmdInsert.Parameters["@family_expenses"].Value = strFEx;
                cmdInsert.Parameters["@net_income"].Value = strNet;
                cmdInsert.Parameters["@create_user_nic"].Value = strloginID;
                cmdInsert.Parameters["@user_ip"].Value = strIp;
                cmdInsert.Parameters["@date_time"].Value = strDateTime;
                #endregion

                try
                {
                    int i = objDBCon.insertEditData(cmdInsert);
                    if (i == 1)
                    {
                        //lblMsg.Text = "Success";
                        Response.Redirect("Loan_Details.aspx?CC=" + strCC + "&CA=" + strCA + "");
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
