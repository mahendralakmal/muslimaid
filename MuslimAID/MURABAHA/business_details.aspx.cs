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
                        if (Session["UserType"] != "Cash Collector" || Session["UserType"] != "Cash Recovery Officer" || Session["UserType"] != "Special Recovery Officer")
                        {
                            strCC = Request.QueryString["CC"];
                            strCAC = Request.QueryString["CA"];

                            if (strCC != null && strCAC != null)
                            {
                                txtCC.Text = strCC;
                                txtCC.Enabled = false;
                                //btnSubmit.Enabled = true;

                            }
                            else
                            {
                                txtCC.Enabled = true;
                                //btnSubmit.Enabled = false;
                            }
                        }
                        else
                        {
                            Response.Redirect("murabha.aspx");
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
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Facility Code";
            }
            //else if (cmbPeriod.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Choose Period";
            //}
            //else if (cmbBPopulation.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Choose Business Population";
            //}
            else if (txtBIncome.Text.Trim() == "" || txtBIncome.Text.Trim() == "0.00")
            {
                lblMsg.Text = "Please Enter Sales (Cash)";
            }
            //else if (txtOIncome.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter Other Income";
            //}
            else if (txtTotalIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Total Income";
            }
            else if (txtDCost.Text.Trim() == "" || txtDCost.Text.Trim() == "0.00")
            {
                lblMsg.Text = "Please Enter Purchases (Cash)";
            }
            /*else if (txtICost.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter InDirect Cost";
            }*/
            //else if (txtTExpenses.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter Other Expenses";
            //}
            else if (txtPAndL.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Business P & L";
            }

            else
            {
                Update();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtCC.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Facility Code";
            }
            //else if (cmbPeriod.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Choose Period";
            //}
            //else if (cmbBPopulation.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Choose Business Population";
            //}
            else if (txtBIncome.Text.Trim() == "" || txtBIncome.Text.Trim() == "0.00")
            {
                lblMsg.Text = "Please Enter Sales (Cash)";
            }
            //else if (txtOIncome.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter Other Income";
            //}
            else if (txtTotalIncome.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Total Income";
            }
            else if (txtDCost.Text.Trim() == "" || txtDCost.Text.Trim() == "0.00")
            {
                lblMsg.Text = "Please Enter Purchases (Cash)";
            }
            /*else if (txtICost.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter InDirect Cost";
            }*/
            //else if (txtTExpenses.Text.Trim() == "")
            //{
            //    lblMsg.Text = "Please Enter Other Expenses";
            //}
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
                        //btnSubmit.Enabled = false;
                        //btnUpdate.Enabled = false;
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
            string strCA = Request.QueryString["CA"];
            //string strBN = txtBuss.Text.Trim();
            //string strDur = cmbPeriod.SelectedValue;
            //string strBAdd = txtBisAddress.Text.Trim();
            //string strBPopu = cmbBPopulation.SelectedValue;
            //string strBNature = txtBNature.Text.Trim();
            //string strKPerson = cmbKeyPerson.SelectedValue;
            //string strNoOfPpl = txtNoOfPpl.Text.Trim();
            //string strBrNo = txtBRNo.Text.Trim();
            //string strOfcContactNo = txtOffContact.Text.Trim();

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

            MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE micro_business_details SET busi_income='" + strBIn + "',sales_credit='" + strCIn + "',other_income='" + strOIn + "',total_income='" + strTotalIn + "',purchase_cash='" + strDcost + "',purchase_credit='" + strICost + "',direct_cost='" + strToEx + "', grossProfit='" + strGrossP + "',rent='" + strRent + "',water_elec_tele='" + strWet + "',wages='" + strWages + "',fla_rent='" + strFla + "',travel='" + strTravelTrans + "',maintenance='" + strRepairMain + "',total_expenses='" + strTotalEx + "',profit_lost='" + strBPL + "',create_user_nic='" + strloginID + "',user_ip ='" + strIp + "',date_time ='" + strDateTime + "' WHERE contract_code = '" + strCC + "';");

            try
            {
                if (objDBCon.insertEditData(cmdUpdateQRY) > 0)
                {
                    Response.Redirect("family_appraisal.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + strCA);
                }
                else
                {
                    lblMsg.Text = "Error occured";
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void Clear()
        {
            txtBIncome.Text = "";
            //txtBisAddress.Text = "";
            //txtBuss.Text = "";
            txtCC.Text = "";
            txtDCost.Text = "";
            //txtBNature.Text = "";
            txtICost.Text = "";
            //txtBRNo.Text = "";
            //txtOffContact.Text = "";
            txtCrdtIncome.Text = "";
            txtOIncome.Text = "";
            txtPAndL.Text = "";
            //txtNoOfPpl.Text = "";
            txtTExpenses.Text = "";
            txtTotalIncome.Text = "";
            txtTotPurchase.Text = "";
            txtGrossProfit.Text = "";
            txtRent.Text = "";
            txtWET.Text = "";
            txtWages.Text = "";
            txtFLA.Text = "";
            txtTravelTrans.Text = "";
            txtRepairMain.Text = "";
            //cmbBPopulation.SelectedIndex = 0;
            //cmbPeriod.SelectedIndex = 0;

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
                    //txtBuss.Text = dsGetDetail.Tables[0].Rows[0]["business_name"].ToString();
                    //cmbPeriod.SelectedValue = dsGetDetail.Tables[0].Rows[0]["busi_duration"].ToString();
                    //txtBisAddress.Text = dsGetDetail.Tables[0].Rows[0]["busi_address"].ToString();
                    //cmbBPopulation.SelectedValue = dsGetDetail.Tables[0].Rows[0]["busi_population"].ToString();
                    //txtBNature.Text = dsGetDetail.Tables[0].Rows[0]["busi_nature"].ToString();
                    //cmbKeyPerson.SelectedValue = dsGetDetail.Tables[0].Rows[0]["key_person"].ToString();
                    //txtNoOfPpl.Text = dsGetDetail.Tables[0].Rows[0]["no_of_ppl"].ToString();
                    //txtBRNo.Text = dsGetDetail.Tables[0].Rows[0]["br_no"].ToString();
                    //txtOffContact.Text = dsGetDetail.Tables[0].Rows[0]["contact_no_ofc"].ToString();
                    txtBIncome.Text = dsGetDetail.Tables[0].Rows[0]["busi_income"].ToString();
                    txtCrdtIncome.Text = dsGetDetail.Tables[0].Rows[0]["sales_credit"].ToString();
                    txtOIncome.Text = dsGetDetail.Tables[0].Rows[0]["other_income"].ToString();
                    txtTotalIncome.Text = dsGetDetail.Tables[0].Rows[0]["total_income"].ToString();

                    hidtxtTotalIncome.Value = dsGetDetail.Tables[0].Rows[0]["total_income"].ToString();

                    txtDCost.Text = dsGetDetail.Tables[0].Rows[0]["purchase_cash"].ToString();
                    txtICost.Text = dsGetDetail.Tables[0].Rows[0]["purchase_credit"].ToString();
                    txtTotPurchase.Text = dsGetDetail.Tables[0].Rows[0]["total_expenses"].ToString();

                    hidtxtTotPurchase.Value = dsGetDetail.Tables[0].Rows[0]["total_expenses"].ToString();

                    txtGrossProfit.Text = dsGetDetail.Tables[0].Rows[0]["grossProfit"].ToString();
                    
                    txtRent.Text = dsGetDetail.Tables[0].Rows[0]["rent"].ToString();
                    txtWET.Text = dsGetDetail.Tables[0].Rows[0]["water_elec_tele"].ToString();
                    txtWages.Text = dsGetDetail.Tables[0].Rows[0]["wages"].ToString();
                    txtFLA.Text = dsGetDetail.Tables[0].Rows[0]["fla_rent"].ToString();
                    txtTravelTrans.Text = dsGetDetail.Tables[0].Rows[0]["travel"].ToString();
                    txtRepairMain.Text = dsGetDetail.Tables[0].Rows[0]["maintenance"].ToString();
                    txtTExpenses.Text = dsGetDetail.Tables[0].Rows[0]["total_expenses"].ToString();

                    hidtxtTExpenses.Value = dsGetDetail.Tables[0].Rows[0]["total_expenses"].ToString();

                    txtPAndL.Text = dsGetDetail.Tables[0].Rows[0]["profit_lost"].ToString();

                    //btnSubmit.Enabled = false;
                    btnUpdate.Enabled = true;
                    
                }
                else {
                    //btnSubmit.Enabled = true;
                    btnUpdate.Enabled = false;
                }
            }
        }
    }
}
