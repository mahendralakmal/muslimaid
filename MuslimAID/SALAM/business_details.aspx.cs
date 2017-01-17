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
    public partial class business_details : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();
        string strCC, strCAC;
        string strBInc, strBincc, strBino;

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
            //else if (txtTotalIncome.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter Total Income";
            //}
            else if (txtDCost.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Direct Cost";
            }
            else if (txtICost.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter InDirect Cost";
            }
            //else if (txtOExpenses.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter Other Expenses";
            //}
            else if (txtPAndL.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Business P & L";
            }
            //else if (txtFExpenses.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter Family Expenses";
            //}
            else
            {
                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO salam_business_details(contract_code,business_name,busi_duration,busi_address,busi_income,busi_population,busi_nature,key_person,no_of_ppl,br_no,contact_no_ofc,busi_income,sales_credit,other_income,total_income,purchase_cash,direct_cost,rent,water_elec_tele,wages,fla_rent,travel,maintenance,total_expenses,profit_lost,create_user_nic,user_ip,date_time)VALUES(@contract_code,@business_name,@busi_duration,@busi_address,@busi_income,@busi_population,@busi_nature,@key_person,@no_of_ppl,@br_no,@contact_no_ofc,@busi_income,@sales_credit,other_income,@total_income,@purchase_cash,@direct_cost,@rent,@water_elec_tele,@wages,@fla_rent,@travel,@maintenance,@total_expenses,@profit_lost,@create_user_nic,@user_ip,@date_time)");

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
                string strBNature = txtBNature.Text.Trim();
                string strKPerson = cmbKeyPerson.SelectedValue;
                string strNoOfPpl = txtNoOfPpl.Text.Trim();
                string strBrNo = txtBRNo.Text.Trim();
                string strOfcContactNo = txtOffContact.Text.Trim();

                string strBIn = txtBIncome.Text.Trim();
                string strCIn = txtCrdtIncome.Text.Trim();
                string strOIn = txtOIncome.Text.Trim();
                string strTotalIn = txtTotalIncome.Text.Trim();

                string strDcost = txtDCost.Text.Trim();
                string strICost = txtICost.Text.Trim();
                string strToEx = txtOExpenses.Text.Trim();

                string strRent = txtRent.Text.Trim();
                string strWet = txtWET.Text.Trim();
                string strWages = txtWages.Text.Trim();
                string strFla = txtFLA.Text.Trim();
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
                cmdInsert.Parameters.Add("@busi_population", MySqlDbType.VarChar, 2);
                cmdInsert.Parameters.Add("@busi_nature", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@key_person", MySqlDbType.Int32, 10);
                cmdInsert.Parameters.Add("@no_of_ppl", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@br_no", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@contact_no_ofc", MySqlDbType.VarChar, 15);
                cmdInsert.Parameters.Add("@busi_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@sales_credit", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@other_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@total_income", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@purchase_cash", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@purchase_credit", MySqlDbType.Decimal, 10);

                cmdInsert.Parameters.Add("@direct_cost", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@rent", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@water_elec_tele", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@wages", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@fla_rent", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@travel", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@maintenance", MySqlDbType.Decimal, 10);

                cmdInsert.Parameters.Add("@total_expenses", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@profit_lost", MySqlDbType.Decimal, 10);
                cmdInsert.Parameters.Add("@create_user_nic", MySqlDbType.VarChar, 10);
                cmdInsert.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                cmdInsert.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                #endregion

                #region AssignValues
                cmdInsert.Parameters["@contract_code"].Value = strCC;
                cmdInsert.Parameters["@business_name"].Value = strBN;
                cmdInsert.Parameters["@busi_duration"].Value = strDur;
                cmdInsert.Parameters["@busi_address"].Value = strBAdd;
                cmdInsert.Parameters["@busi_population"].Value = strBPopu;
                cmdInsert.Parameters["@busi_nature"].Value = strBNature;
                cmdInsert.Parameters["@key_person"].Value = strKPerson;
                cmdInsert.Parameters["@no_of_ppl"].Value = strNoOfPpl;
                cmdInsert.Parameters["@br_no"].Value = strBrNo;
                cmdInsert.Parameters["@contact_no_ofc"].Value = strOfcContactNo;

                cmdInsert.Parameters["@busi_income"].Value = strBIn;
                cmdInsert.Parameters["@sales_credit"].Value = strCIn;
                cmdInsert.Parameters["@other_income"].Value = strOIn;
                cmdInsert.Parameters["@total_income"].Value = strTotalIn;

                cmdInsert.Parameters["@purchase_cash"].Value = strDcost;
                cmdInsert.Parameters["@purchase_credit"].Value = strICost;
                cmdInsert.Parameters["@direct_cost"].Value = strToEx;
                cmdInsert.Parameters["@rent"].Value = strRent;
                cmdInsert.Parameters["@water_elec_tele"].Value = strWet;
                cmdInsert.Parameters["@wages"].Value = strWages;
                cmdInsert.Parameters["@fla_rent"].Value = strFla;
                cmdInsert.Parameters["@travel"].Value = strTravelTrans;
                cmdInsert.Parameters["@maintenance"].Value = strRepairMain;
                cmdInsert.Parameters["@total_expenses"].Value = strTotalEx;
                cmdInsert.Parameters["@profit_lost"].Value = strBPL;
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
                        Response.Redirect("loan_details.aspx?CC=" + strCC + "&CA=" + strCA + "");
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
            else if (txtTExpenses.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Other Expenses";
            }
            else if (txtPAndL.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Business P & L";
            }

            else
            {
                string strCCode = txtCC.Text.Trim();
                DataSet dsGetDetail = cls_Connection.getDataSet("select * from salam_business_details where contract_code = '" + strCCode + "';");
                if (dsGetDetail.Tables[0].Rows.Count > 0)
                {

                    Update();

                }
                else
                {
                    DataSet dsGetBasicDetail = cls_Connection.getDataSet("select * from salam_basic_detail where contract_code = '" + strCCode + "';");
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
            string strBNature = txtBNature.Text.Trim();
            string strKPerson = cmbKeyPerson.SelectedValue;
            string strNoOfPpl = txtNoOfPpl.Text.Trim();
            string strBrNo = txtBRNo.Text.Trim();
            string strOfcContactNo = txtOffContact.Text.Trim();

            string strBIn = txtBIncome.Text.Trim();
            string strCIn = txtCrdtIncome.Text.Trim();
            string strOIn = txtOIncome.Text.Trim();
            string strTotalIn = txtTotalIncome.Text.Trim();

            string strDcost = txtDCost.Text.Trim();
            string strICost = txtICost.Text.Trim();
            string strToEx = txtOExpenses.Text.Trim();

            string strRent = txtRent.Text.Trim();
            string strWet = txtWET.Text.Trim();
            string strWages = txtWages.Text.Trim();
            string strFla = txtFLA.Text.Trim();
            string strTravelTrans = txtTravelTrans.Text.Trim();
            string strRepairMain = txtRepairMain.Text.Trim();

            string strTotalEx = txtTExpenses.Text.Trim();
            string strBPL = txtPAndL.Text.Trim();
            #endregion

            MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE salam_business_details SET business_name ='" + strBN + "',busi_duration ='" + strDur + "',busi_address ='" + strBAdd + "'@busi_income'" + strBIn + "',@busi_population'" + strBPopu + "',@busi_nature='" + strBNature + "',@key_person'" + strKPerson + "',@no_of_ppl'" + strNoOfPpl + "',@br_no='" + strBrNo + "',@contact_no_ofc='" + strOfcContactNo + "',@sales_credit='" + strCIn + "',other_income='" + strOIn + "',@total_income='" + strTotalIn + "',@purchase_cash='" + strDcost + "',@purchase_credit='" + strICost + "',@direct_cost='" + strToEx + "',@rent='" + strRent + "',@water_elec_tele='" + strWet + "',@wages='" + strWages + "',@fla_rent='" + strFla + "',@travel='" + strTravelTrans + "',@maintenance='" + strRepairMain + "',@total_expenses='" + strTotalEx + "',@profit_lost='" + strBPL + "',@create_user_nic='" + strloginID + ",user_ip ='" + strIp + "',date_time ='" + strDateTime + "' WHERE contract_code = '" + strCC + "';");

            try
            {
                int i;
                i = objDBCon.insertEditData(cmdUpdateQRY);
                if (i == 1)
                {
                    Response.Redirect("family_details.aspx?CC=" + strCC + "&CA=" + txtCACode + "");
                }
                else
                {
                    lblMsg.Text = "Error Occured";
                }
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
            //txtFExpenses.Text = "";
            txtICost.Text = "";
            //txtNetIncome.Text = "";
            //txtOExpenses.Text = "";
            txtOIncome.Text = "";
            txtPAndL.Text = "";
            txtTExpenses.Text = "";
            txtTotalIncome.Text = "";
            cmbBPopulation.SelectedIndex = 0;
            cmbPeriod.SelectedIndex = 0;

        }

        protected void calcToTIn()
        {
            strBincc = txtCrdtIncome.Text == "" ? "0" : txtCrdtIncome.Text;
            strBino = txtBIncome.Text == "" ? "0" : txtBIncome.Text;
            strBInc = txtOIncome.Text == "" ? "0" : txtOIncome.Text;
            decimal intTot = Convert.ToDecimal(strBInc) + Convert.ToDecimal(strBincc) + Convert.ToDecimal(strBino);
            txtTotalIncome.Text = intTot.ToString();
            txtTotalIncome.Focus();
            catcPlb();
        }

        protected void txtBIncome_TextChanged(object sender, EventArgs e)
        {
            calcToTIn();
        }

        protected void txtCrdtIncome_TextChanged(object sender, EventArgs e)
        {
            calcToTIn();
        }

        protected void txtOIncome_TextChanged(object sender, EventArgs e)
        {
            calcToTIn();
        }
        string strDcost, strIcost = "";
        protected void calcTotPurchase()
        {
            strDcost = txtDCost.Text == "" ? "0" : txtDCost.Text;
            strIcost = txtICost.Text == "" ? "0" : txtICost.Text;
            decimal intTot = Convert.ToDecimal(strDcost) + Convert.ToDecimal(strIcost);
            txtOExpenses.Text = intTot.ToString();
            txtOExpenses.Focus();
            catcPlb();
        }
        protected void txtDCost_TextChanged(object sender, EventArgs e)
        {
            calcTotPurchase();
        }

        protected void txtICost_TextChanged(object sender, EventArgs e)
        {
            calcTotPurchase();
        }
        string strRent, strWet, strWages, strFla, strTravelTrans, strRepairMain = "";
        protected void calcTotBEx()
        {
            strRent = txtRent.Text == "" ? "0" : txtRent.Text;
            strWet = txtWET.Text == "" ? "0" : txtWET.Text;
            strWages = txtWages.Text == "" ? "0" : txtWages.Text;
            strFla = txtFLA.Text == "" ? "0" : txtFLA.Text;
            strTravelTrans = txtTravelTrans.Text == "" ? "0" : txtTravelTrans.Text;
            strRepairMain = txtRepairMain.Text == "" ? "0" : txtRepairMain.Text;
            decimal intTot = Convert.ToDecimal(strRent) + Convert.ToDecimal(strWet) + Convert.ToDecimal(strWages) + Convert.ToDecimal(strFla) + Convert.ToDecimal(strTravelTrans) + Convert.ToDecimal(strRepairMain);
            txtTExpenses.Text = intTot.ToString();
            txtTExpenses.Focus();
            catcPlb();
        }

        protected void txtRent_TextChanged(object sender, EventArgs e)
        {
            calcTotBEx();
        }

        protected void txtWET_TextChanged(object sender, EventArgs e)
        {
            calcTotBEx();
        }

        protected void txtWages_TextChanged(object sender, EventArgs e)
        {
            calcTotBEx();
        }

        protected void txtFLA_TextChanged(object sender, EventArgs e)
        {
            calcTotBEx();
        }

        protected void txtTravelTrans_TextChanged(object sender, EventArgs e)
        {
            calcTotBEx();
        }

        protected void txtRepairMain_TextChanged(object sender, EventArgs e)
        {
            calcTotBEx();
        }

        protected void catcPlb()
        {
            string strTin = txtTotalIncome.Text == "" ? "0" : txtTotalIncome.Text;
            string strTEx = txtTExpenses.Text == "" ? "0" : txtTExpenses.Text;
            string strTPu = txtOExpenses.Text == "" ? "0" : txtOExpenses.Text;
            txtPAndL.Text = (Convert.ToDecimal(strTin) - (Convert.ToDecimal(strTEx) + Convert.ToDecimal(strTPu))).ToString();
        }
    }
}
