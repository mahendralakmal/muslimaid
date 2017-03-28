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
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Facility Code";
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
            //else if (txtOIncome.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter Other Income";
            //}
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
                MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_business_details(contract_code,business_name,busi_duration,busi_address,busi_population,busi_nature,key_person,no_of_ppl,br_no,contact_no_ofc,busi_income,sales_credit,other_income,total_income,purchase_cash,purchase_credit,grossProfit,rent,water_elec_tele,wages,fla_rent,travel,maintenance,total_expenses,profit_lost,create_user_nic,user_ip,date_time)VALUES(@contract_code,@business_name,@busi_duration,@busi_address,@busi_population,@busi_nature,@key_person,@no_of_ppl,@br_no,@contact_no_ofc,@busi_income,@sales_credit,other_income,@total_income,@purchase_cash,@direct_cost,@grossProfit,@rent,@water_elec_tele,@wages,@fla_rent,@travel,@maintenance,@total_expenses,@profit_lost,@create_user_nic,@user_ip,@date_time)");

                #region GetValues
                string strIp = Request.UserHostAddress;
                string strloginID = Session["NIC"].ToString();
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strCC = txtCC.Text.Trim();
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
                string strToEx = txtTotPurchase.Text.Trim();

                string strGrossP = hidGross.Value.Trim();

                string strRent = txtRent.Text.Trim();
                string strWet = txtWET.Text.Trim();
                string strWages = txtWages.Text.Trim();
                string strFla = txtFLA.Text.Trim();
                string strTravelTrans = txtTravelTrans.Text.Trim();
                string strRepairMain = txtRepairMain.Text.Trim();

                string strTotalEx = txtTExpenses.Text.Trim();
                string strBPL = txtPAndL.Text.Trim();
                #endregion

                #region GetValues
                cmdInsert.Parameters.AddWithValue("@contract_code", strCC);
                cmdInsert.Parameters.AddWithValue("@business_name", strBN);
                cmdInsert.Parameters.AddWithValue("@busi_duration", strDur);
                cmdInsert.Parameters.AddWithValue("@busi_address", strBAdd);
                cmdInsert.Parameters.AddWithValue("@busi_population", strBPopu);
                cmdInsert.Parameters.AddWithValue("@busi_nature", strBNature);
                cmdInsert.Parameters.AddWithValue("@key_person", strKPerson);
                cmdInsert.Parameters.AddWithValue("@no_of_ppl", (strNoOfPpl!="")?Convert.ToInt32(strNoOfPpl):00);
                cmdInsert.Parameters.AddWithValue("@br_no", strBrNo);
                cmdInsert.Parameters.AddWithValue("@contact_no_ofc", strOfcContactNo);
                cmdInsert.Parameters.AddWithValue("@busi_income", (strBIn != "") ? Convert.ToDecimal(strBIn) : 00);
                cmdInsert.Parameters.AddWithValue("@sales_credit", (strCIn != "") ? Convert.ToDecimal(strCIn) : 00);
                cmdInsert.Parameters.AddWithValue("@other_income", (strOIn != "") ? Convert.ToDecimal(strOIn) : 00);
                cmdInsert.Parameters.AddWithValue("@total_income", (strTotalIn != "") ? Convert.ToDecimal(strTotalIn) : 00);
                cmdInsert.Parameters.AddWithValue("@purchase_cash", (strDcost != "") ? Convert.ToDecimal(strDcost) : 00);
                cmdInsert.Parameters.AddWithValue("@purchase_credit", (strICost != "") ? Convert.ToDecimal(strICost) : 00);
                cmdInsert.Parameters.AddWithValue("@direct_cost", (strToEx != "") ? Convert.ToDecimal(strToEx) : 00);
                cmdInsert.Parameters.AddWithValue("@grossProfit", (strGrossP != "") ? Convert.ToDecimal(strGrossP) : 00);
                cmdInsert.Parameters.AddWithValue("@rent", (strRent != "") ? Convert.ToDecimal(strRent) : 00);
                cmdInsert.Parameters.AddWithValue("@water_elec_tele", (strWet != "") ? Convert.ToDecimal(strWet) : 00);
                cmdInsert.Parameters.AddWithValue("@wages", (strWages != "") ? Convert.ToDecimal(strWages) : 00);
                cmdInsert.Parameters.AddWithValue("@fla_rent", (strFla != "") ? Convert.ToDecimal(strFla) : 00);
                cmdInsert.Parameters.AddWithValue("@travel", (strTravelTrans != "") ? Convert.ToDecimal(strTravelTrans) : 00);
                cmdInsert.Parameters.AddWithValue("@maintenance", (strRepairMain != "") ? Convert.ToDecimal(strRepairMain) : 00);
                cmdInsert.Parameters.AddWithValue("@total_expenses", (strTotalEx != "") ? Convert.ToDecimal(strTotalEx) : 00);
                cmdInsert.Parameters.AddWithValue("@profit_lost", (strBPL != "") ? Convert.ToDecimal(strBPL) : 00);
                cmdInsert.Parameters.AddWithValue("@create_user_nic", strloginID);
                cmdInsert.Parameters.AddWithValue("@user_ip", strIp);
                cmdInsert.Parameters.AddWithValue("@date_time", strDateTime);
                #endregion

                try
                {
                    int i = objDBCon.insertEditData(cmdInsert);
                    if (i == 1)
                    {
                        //lblMsg.Text = "Success";
                        Response.Redirect("family_appraisal.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + strCAC);
                        //Response.Redirect("supplier.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + txtCACode.Text.Trim());
                        //Response.Redirect("loan_details.aspx?CC=" + strCC + "&CA=" + strCA + "");
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
                lblMsg.Text = "Please Enter Facility Code";
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
                DataSet dsGetDetail = cls_Connection.getDataSet("select * from micro_business_details where contract_code = '" + strCCode + "';");
                if (dsGetDetail.Tables[0].Rows.Count > 0)
                {

                    Update();

                }
                else
                {
                    DataSet dsGetBasicDetail = cls_Connection.getDataSet("select * from micro_basic_detail where contract_code = '" + strCCode + "';");
                    if (dsGetBasicDetail.Tables[0].Rows.Count > 0)
                    {
                        Update();
                    }
                    else
                    {
                        btnSubmit.Enabled = false;
                        btnUpdate.Enabled = false;
                        lblMsg.Text = "Invalid Facility Code.";
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
            string strToEx = txtTotPurchase.Text.Trim();

            string strGrossP = hidGross.Value.Trim();

            string strRent = txtRent.Text.Trim();
            string strWet = txtWET.Text.Trim();
            string strWages = txtWages.Text.Trim();
            string strFla = txtFLA.Text.Trim();
            string strTravelTrans = txtTravelTrans.Text.Trim();
            string strRepairMain = txtRepairMain.Text.Trim();

            string strTotalEx = txtTExpenses.Text.Trim();
            string strBPL = txtPAndL.Text.Trim();
            #endregion

            MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE micro_business_details SET business_name ='" + strBN + "',busi_duration ='" + strDur + "',busi_address ='" + strBAdd + "',busi_income='" + strBIn + "',busi_population='" + strBPopu + "',busi_nature='" + strBNature + "',key_person='" + strKPerson + "',no_of_ppl='" + strNoOfPpl + "',br_no='" + strBrNo + "',contact_no_ofc='" + strOfcContactNo + "',sales_credit='" + strCIn + "',other_income='" + strOIn + "',total_income='" + strTotalIn + "',purchase_cash='" + strDcost + "',purchase_credit='" + strICost + "',direct_cost='" + strToEx + "', grossProfit='" + strGrossP + "',rent='" + strRent + "',water_elec_tele='" + strWet + "',wages='" + strWages + "',fla_rent='" + strFla + "',travel='" + strTravelTrans + "',maintenance='" + strRepairMain + "',total_expenses='" + strTotalEx + "',profit_lost='" + strBPL + "',create_user_nic='" + strloginID + "',user_ip ='" + strIp + "',date_time ='" + strDateTime + "' WHERE contract_code = '" + strCC + "';");

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
        string strDcost, strIcost="";
        protected void calcTotPurchase() {
            strDcost = txtDCost.Text == "" ? "0" : txtDCost.Text;
            strIcost = txtICost.Text == "" ? "0" : txtICost.Text;
            decimal intTot = Convert.ToDecimal(strDcost) + Convert.ToDecimal(strIcost);
            txtTotPurchase.Text = intTot.ToString();
            txtTotPurchase.Focus();
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
            string strTPu = txtTotPurchase.Text == "" ? "0" : txtTotPurchase.Text;
            txtPAndL.Text = (Convert.ToDecimal(strTin) - (Convert.ToDecimal(strTEx) + Convert.ToDecimal(strTPu))).ToString();
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
                DataSet dsGetDetail = cls_Connection.getDataSet("select * from micro_business_details where contract_code = '" + strCCode + "';");
                if (dsGetDetail.Tables[0].Rows.Count > 0)
                {
                    txtBuss.Text = dsGetDetail.Tables[0].Rows[0]["business_name"].ToString();
                    cmbPeriod.SelectedValue = dsGetDetail.Tables[0].Rows[0]["busi_duration"].ToString();
                    txtBisAddress.Text = dsGetDetail.Tables[0].Rows[0]["busi_address"].ToString();
                    cmbBPopulation.SelectedValue = dsGetDetail.Tables[0].Rows[0]["busi_population"].ToString();
                    txtBNature.Text = dsGetDetail.Tables[0].Rows[0]["busi_nature"].ToString();
                    cmbKeyPerson.SelectedValue = dsGetDetail.Tables[0].Rows[0]["key_person"].ToString();
                    txtNoOfPpl.Text = dsGetDetail.Tables[0].Rows[0]["no_of_ppl"].ToString();
                    txtBRNo.Text = dsGetDetail.Tables[0].Rows[0]["br_no"].ToString();
                    txtOffContact.Text = dsGetDetail.Tables[0].Rows[0]["contact_no_ofc"].ToString();
                    txtBIncome.Text = dsGetDetail.Tables[0].Rows[0]["busi_income"].ToString();
                    txtCrdtIncome.Text = dsGetDetail.Tables[0].Rows[0]["sales_credit"].ToString();
                    txtOIncome.Text = dsGetDetail.Tables[0].Rows[0]["other_income"].ToString();
                    txtTotalIncome.Text = dsGetDetail.Tables[0].Rows[0]["total_income"].ToString();
                    txtDCost.Text = dsGetDetail.Tables[0].Rows[0]["purchase_cash"].ToString();
                    txtICost.Text = dsGetDetail.Tables[0].Rows[0]["purchase_credit"].ToString();
                    txtTotPurchase.Text = dsGetDetail.Tables[0].Rows[0]["total_expenses"].ToString();
                    txtGrossProfit.Text = dsGetDetail.Tables[0].Rows[0]["grossProfit"].ToString();
                    txtRent.Text = dsGetDetail.Tables[0].Rows[0]["rent"].ToString();
                    txtWET.Text = dsGetDetail.Tables[0].Rows[0]["water_elec_tele"].ToString();
                    txtWages.Text = dsGetDetail.Tables[0].Rows[0]["wages"].ToString();
                    txtFLA.Text = dsGetDetail.Tables[0].Rows[0]["fla_rent"].ToString();
                    txtTravelTrans.Text = dsGetDetail.Tables[0].Rows[0]["travel"].ToString();
                    txtRepairMain.Text = dsGetDetail.Tables[0].Rows[0]["maintenance"].ToString();
                    txtTExpenses.Text = dsGetDetail.Tables[0].Rows[0]["total_expenses"].ToString();
                    txtPAndL.Text = dsGetDetail.Tables[0].Rows[0]["profit_lost"].ToString();

                    btnSubmit.Enabled = false;
                    btnUpdate.Enabled = true;
                    
                }
                else {
                    btnSubmit.Enabled = true;
                    btnUpdate.Enabled = false;
                }
            }
        }
    }
}
