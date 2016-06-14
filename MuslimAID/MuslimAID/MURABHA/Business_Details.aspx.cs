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

namespace LoanSystem.Micro
{
    public partial class Business_Details : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBCon = new DBTasks();
        string strCC, strCAC;

        protected void Page_Load(object sender, EventArgs e)
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

        protected void txtOIncome_TextChanged(object sender, EventArgs e)
        {
            decimal decBIncome = Convert.ToDecimal(txtBIncome.Text);
            decimal decOIncome = Convert.ToDecimal(txtOIncome.Text);

            decimal decTotalIncome = decBIncome + decOIncome;

            txtTotalIncome.Text = Convert.ToString(decTotalIncome);
        }

        protected void txtBIncome_TextChanged(object sender, EventArgs e)
        {
            decimal decBIncome = Convert.ToDecimal(txtBIncome.Text);
            decimal decOIncome;
            decimal decTotalIncome;

            if (txtOIncome.Text.Trim() == "")
            {
                decOIncome = 0;
                decTotalIncome = decBIncome;
            }
            else
            {
                decOIncome = Convert.ToDecimal(txtOIncome.Text);
                decTotalIncome = decBIncome + decOIncome;
            }


            txtTotalIncome.Text = Convert.ToString(decTotalIncome);
        }

        protected void txtOExpenses_TextChanged(object sender, EventArgs e)
        {
            decimal decOEX;
            decimal decIDCost;
            decimal decDCost;

            if (txtOExpenses.Text.Trim() == "")
            {
                decOEX = 0;
            }
            else
            {
                decOEX = Convert.ToDecimal(txtOExpenses.Text);
            }
            
            if (txtICost.Text.Trim() == "")
            {
                decIDCost = 0;
            }
            else
            {
                decIDCost = Convert.ToDecimal(txtICost.Text);
            }

            if (txtDCost.Text.Trim() == "")
            {
                decDCost = 0;
            }
            else
            {
                decDCost = Convert.ToDecimal(txtDCost.Text);
            }
            
            

            decimal decTotalEx = decDCost + decIDCost + decOEX;

            txtTExpenses.Text = Convert.ToString(decTotalEx);

            if (txtTExpenses.Text != "" && txtTotalIncome.Text!="")
            {
                decimal decEx = Convert.ToDecimal(txtTExpenses.Text);
                decimal decIn = Convert.ToDecimal(txtTotalIncome.Text);

                decimal decPL = decIn - decEx;

                txtPAndL.Text = Convert.ToString(decPL);
            }
        }

        protected void txtDCost_TextChanged(object sender, EventArgs e)
        {
            decimal decDCost = Convert.ToDecimal(txtDCost.Text);
            decimal decIDCost;
            decimal decOEX;
            decimal decTotalEx;

            if (txtDCost.Text.Trim() != "" && txtICost.Text.Trim() == "" && txtOExpenses.Text.Trim() == "")
            {
                txtTExpenses.Text = Convert.ToString(decDCost);
            }
            else if (txtDCost.Text.Trim() != "" && txtICost.Text.Trim() != "" && txtOExpenses.Text.Trim() == "")
            {
                decIDCost = Convert.ToDecimal(txtICost.Text);
                decTotalEx = decDCost + decIDCost;

                txtTExpenses.Text = Convert.ToString(decTotalEx);
            }
            else if (txtDCost.Text.Trim() != "" && txtICost.Text.Trim() != "" && txtOExpenses.Text.Trim() != "")
            {
                decDCost = Convert.ToDecimal(txtDCost.Text);
                decIDCost = Convert.ToDecimal(txtICost.Text);
                decOEX = Convert.ToDecimal(txtOExpenses.Text);

                decTotalEx = decDCost + decIDCost + decOEX;

                txtTExpenses.Text = Convert.ToString(decTotalEx);
            }
        }

        protected void txtICost_TextChanged(object sender, EventArgs e)
        {
            decimal decDCost;
            decimal decOEX;
            decimal decTotalEx;
            if (txtICost.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Indirect Cost.";
            }
            else
            {
                decimal decIDCost = Convert.ToDecimal(txtICost.Text);


                if (txtDCost.Text.Trim() == "" && txtICost.Text.Trim() != "" && txtOExpenses.Text.Trim() == "")
                {
                    txtTExpenses.Text = Convert.ToString(decIDCost);
                }
                else if (txtDCost.Text.Trim() != "" && txtICost.Text.Trim() != "" && txtOExpenses.Text.Trim() == "")
                {
                    decDCost = Convert.ToDecimal(txtDCost.Text);
                    decTotalEx = decDCost + decIDCost;

                    txtTExpenses.Text = Convert.ToString(decTotalEx);
                }
                else if (txtDCost.Text.Trim() != "" && txtICost.Text.Trim() != "" && txtOExpenses.Text.Trim() != "")
                {
                    decDCost = Convert.ToDecimal(txtDCost.Text);
                    decIDCost = Convert.ToDecimal(txtICost.Text);
                    decOEX = Convert.ToDecimal(txtOExpenses.Text);

                    decTotalEx = decDCost + decIDCost + decOEX;

                    txtTExpenses.Text = Convert.ToString(decTotalEx);
                }
            }
        }

        protected void txtFExpenses_TextChanged(object sender, EventArgs e)
        {
            if (txtPAndL.Text != "")
            {
                decimal decFEx = Convert.ToDecimal(txtFExpenses.Text);
                decimal decProfit = Convert.ToDecimal(txtPAndL.Text);

                decimal decNetMoney = decProfit - decFEx;

                txtNetIncome.Text = Convert.ToString(decNetMoney);

                //btnSubmit.Enabled = true;
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
                DataSet dsGetDetail = objDBCon.selectData("select * from micro_business_details where contract_code = '" + strCCode + "';");
                if (dsGetDetail.Tables[0].Rows.Count > 0)
                {
                    btnSubmit.Enabled = false;
                    btnUpdate.Enabled = true;

                }
                else
                {
                    DataSet dsGetBasicDetail = objDBCon.selectData("select * from micro_basic_detail where contract_code = '" + strCCode + "';");
                    if (dsGetBasicDetail.Tables[0].Rows.Count > 0)
                    {
                        btnSubmit.Enabled = true;
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        btnSubmit.Enabled = false;
                        btnUpdate.Enabled = false;
                        lblMsg.Text = "Invalid Contract Code.";
                    }
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
                string strCCode = txtCC.Text.Trim();
                DataSet dsGetDetail = objDBCon.selectData("select * from micro_business_details where contract_code = '" + strCCode + "';");
                if (dsGetDetail.Tables[0].Rows.Count > 0)
                {

                    Update();

                }
                else
                {
                    DataSet dsGetBasicDetail = objDBCon.selectData("select * from micro_basic_detail where contract_code = '" + strCCode + "';");
                    if (dsGetBasicDetail.Tables[0].Rows.Count > 0)
                    {
                        Update();
                    }
                    else
                    {
                        btnSubmit.Enabled = false;
                        btnUpdate.Enabled = false;
                        lblMsg.Text = "Invalid Contract Code.";
                    }
                }
            }
        }

        protected void Update()
        {
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

            MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE micro_business_details SET business_name ='" + strBN + "',busi_duration ='" + strDur + "',busi_address ='" + strBAdd + "',busi_income ='" + strBIn + "',other_income ='" + strOIn + "',total_income ='" + strTotalIn + "',direct_cost ='" + strDcost + "',indirect_cost ='" + strICost + "',other_expenses ='" + strOEx + "',total_expenses ='" + strTotalEx + "',profit_lost ='" + strBPL + "',family_expenses ='" + strFEx + "',net_income ='" + strNet + "',create_user_nic ='" + strloginID + "',user_ip ='" + strIp + "',date_time ='" + strDateTime + "' WHERE contract_code = '" + strCC + "';");

            try
            {
                int i;
                i = objDBCon.insertEditData(cmdUpdateQRY);

                Clear();
                lblMsg.Text = "Update Success.";



                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        protected void Clear()
        {
            txtBIncome.Text = "";
            txtBisAddress.Text = "";
            txtBuss.Text = "";
            txtCACode.Text = "";
            txtCC.Text = "";
            txtDCost.Text = "";
            txtFExpenses.Text = "";
            txtICost.Text = "";
            txtNetIncome.Text = "";
            txtOExpenses.Text = "";
            txtOIncome.Text = "";
            txtPAndL.Text = "";
            txtTExpenses.Text = "";
            txtTotalIncome.Text = "";
            cmbBPopulation.SelectedIndex = 0;
            cmbPeriod.SelectedIndex = 0;
            
        }
    }
}
