﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace MuslimAID.SALAM
{
    public partial class Full_Details : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        string strCC;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                strCC = Request.QueryString["ConCode"];
                lblCC.Text = strCC;
                if (strCC != null)
                {
                    //Get Full Detail
                    DataSet dsGetFullDetails = cls_Connection.getDataSet("SELECT * FROM full_detail_salam WHERE contract_code = '" + strCC + "';");
                    if (dsGetFullDetails.Tables[0].Rows.Count > 0)
                    {
                        lblAddress.Text = dsGetFullDetails.Tables[0].Rows[0]["p_address"].ToString();
                        lblBAddress.Text = dsGetFullDetails.Tables[0].Rows[0]["busi_address"].ToString();
                        lblBDCost.Text = (dsGetFullDetails.Tables[0].Rows[0]["direct_cost"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["direct_cost"].ToString()).ToString("#,##0.00"):"0.00";
                        lblBDuration.Text = dsGetFullDetails.Tables[0].Rows[0]["busi_duration"].ToString();
                        lblBICost.Text = (dsGetFullDetails.Tables[0].Rows[0]["indirect_cost"].ToString() != "") ? Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["indirect_cost"].ToString()).ToString("#,##0.00") : "0.00";
                        lblBIncome.Text = (dsGetFullDetails.Tables[0].Rows[0]["busi_income"].ToString()!="") ? Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["busi_income"].ToString()).ToString("#,##0.00") : "0.00";
                        lblBName.Text = dsGetFullDetails.Tables[0].Rows[0]["business_name"].ToString();
                        lblBOExpenses.Text = (dsGetFullDetails.Tables[0].Rows[0]["other_expenses"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["other_expenses"].ToString()).ToString("#,##0.00"):"0.00";
                        lblBOIncome.Text = (dsGetFullDetails.Tables[0].Rows[0]["other_income"].ToString()!="") ? Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["other_income"].ToString()).ToString("#,##0.00") : "0.00";
                        lblBPL.Text = (dsGetFullDetails.Tables[0].Rows[0]["profit_lost"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["profit_lost"].ToString()).ToString("#,##0.00"):"0.00";
                        lblBTExpenses.Text = (dsGetFullDetails.Tables[0].Rows[0]["total_expenses"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["total_expenses"].ToString()).ToString("#,##0.00"):"0.00";
                        lblBTIncome.Text = (dsGetFullDetails.Tables[0].Rows[0]["total_income"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["total_income"].ToString()).ToString("#,##0.00"):"0.00";
                        lblCACode.Text = dsGetFullDetails.Tables[0].Rows[0]["ca_code"].ToString();
                        lblCC.Text = dsGetFullDetails.Tables[0].Rows[0]["contract_code"].ToString();
                        //lblDep.Text = dsGetFullDetails.Tables[0].Rows[0]["dependers"].ToString();
                        lblEducation.Text = dsGetFullDetails.Tables[0].Rows[0]["education"].ToString();
                        lblFExpenses.Text = (dsGetFullDetails.Tables[0].Rows[0]["family_expenses"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["family_expenses"].ToString()).ToString("#,##0.00"):"0.00";
                        lblIAmount.Text = (dsGetFullDetails.Tables[0].Rows[0]["interest_amount"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["interest_amount"].ToString()).ToString("#,##0.00"):"0.00";
                        lblImmPrope.Text = (dsGetFullDetails.Tables[0].Rows[0]["immoveable_property"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["immoveable_property"].ToString()).ToString("#,##0.00"):"0.00";
                        lblInsDate.Text = dsGetFullDetails.Tables[0].Rows[0]["inspection_date"].ToString();
                        lblIRate.Text = dsGetFullDetails.Tables[0].Rows[0]["interest_rate"].ToString();
                        lblLAmount.Text = (dsGetFullDetails.Tables[0].Rows[0]["loan_amount"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["loan_amount"].ToString()).ToString("#,##0.00"):"0.00";
                        lblLandNo.Text = dsGetFullDetails.Tables[0].Rows[0]["land_no"].ToString();
                        lblMobNo.Text = dsGetFullDetails.Tables[0].Rows[0]["mobile_no"].ToString();
                        lblMovProperty.Text = (dsGetFullDetails.Tables[0].Rows[0]["moveable_property"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["moveable_property"].ToString()).ToString("#,##0.00"):"0.00";
                        lblAccName.Text = dsGetFullDetails.Tables[0].Rows[0]["acc_name"].ToString();
                        lblAccNo.Text = dsGetFullDetails.Tables[0].Rows[0]["acc_number"].ToString();

                        if (dsGetFullDetails.Tables[0].Rows[0]["bank_code"].ToString() != "")
                        {
                            DataSet dsGetBank = cls_Connection.getDataSet("select b.BankName,bc.BranchName from micro_loan_details l, bank_tbl b, bankbranch_tbl bc where b.BankCode = l.bank_code and bc.BankCode = l.bank_code and bc.BranchCode = l.branch_code and l.contra_code = '" + strCC + "'");
                            if (dsGetBank.Tables[0].Rows.Count > 0)
                            {
                                lblBankName.Text = dsGetBank.Tables[0].Rows[0]["BankName"].ToString();
                                lblBranch.Text = dsGetBank.Tables[0].Rows[0]["BranchName"].ToString();
                            }
                            else
                            {
                                lblBankName.Text = "-";
                                lblBranch.Text = "-";
                            }
                        }
                        else
                        {
                            lblBankName.Text = "-";
                            lblBranch.Text = "-";
                        }

                        string strMSta = dsGetFullDetails.Tables[0].Rows[0]["marital_status"].ToString();
                        if (strMSta == "S")
                        {
                            lblMStatus.Text = "Single";
                        }
                        else
                        {
                            lblMStatus.Text = "Married";
                        }

                        lblName.Text = dsGetFullDetails.Tables[0].Rows[0]["full_name"].ToString();
                        lblNetIncome.Text = (dsGetFullDetails.Tables[0].Rows[0]["net_income"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["net_income"].ToString()).ToString("#,##0.00"):"0.00";
                        lblNIC.Text = dsGetFullDetails.Tables[0].Rows[0]["nic"].ToString();
                        lblOccupation.Text = dsGetFullDetails.Tables[0].Rows[0]["occupation"].ToString();
                        lblOCharge.Text = dsGetFullDetails.Tables[0].Rows[0]["other_charges"].ToString();
                        lblOMemIncoem.Text = (dsGetFullDetails.Tables[0].Rows[0]["other_fami_mem_income"].ToString()!="") ? Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["other_fami_mem_income"].ToString()).ToString("#,##0.00") : "0.00";
                        lblPeriod.Text = dsGetFullDetails.Tables[0].Rows[0]["period"].ToString();
                        lblSaving.Text = (dsGetFullDetails.Tables[0].Rows[0]["saving"].ToString()!="") ? Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["saving"].ToString()).ToString("#,##0.00") : "0.00";
                        lblSCharge.Text = (dsGetFullDetails.Tables[0].Rows[0]["service_charges"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["service_charges"].ToString()).ToString("#,##0.00"):"0.00";
                        lblSDenders.Text = dsGetFullDetails.Tables[0].Rows[0]["dependers"].ToString();
                        lblSIncome.Text = (dsGetFullDetails.Tables[0].Rows[0]["spouse_income"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["spouse_income"].ToString()).ToString("#,##0.00"):"0.00";
                        lblSName.Text = dsGetFullDetails.Tables[0].Rows[0]["spouse_name"].ToString();
                        lblSpouseNIC.Text = dsGetFullDetails.Tables[0].Rows[0]["spouse_nic"].ToString();
                        lblMobileNo.Text = dsGetFullDetails.Tables[0].Rows[0]["mobile_no"].ToString();
                        lblWInstallment.Text = (dsGetFullDetails.Tables[0].Rows[0]["monthly_instollment"].ToString()!="")?Convert.ToDecimal(dsGetFullDetails.Tables[0].Rows[0]["monthly_instollment"].ToString()).ToString("#,##0.00"):"0.00";
                        lblWelfareFee.Text = dsGetFullDetails.Tables[0].Rows[0]["walfare_fee"].ToString();
                        lblRegistrationFee.Text = dsGetFullDetails.Tables[0].Rows[0]["registration_fee"].ToString();

                        string strProID = dsGetFullDetails.Tables[0].Rows[0]["promisers_id"].ToString();

                        hstrSelectQueryImg.Value = "select cli_photo,bb_photo from micro_basic_detail where contract_code = '" + strCC + "';";
                        loadDataToRepeaterImg(hstrSelectQueryImg.Value);
                        

                        //Get Promiser Details
                        DataSet dsGetPromiser = cls_Connection.getDataSet("select contract_code,nic,initial_name,mobile_no,p_address from micro_basic_detail where promisers_id ='" + strProID + "';");
                        if (dsGetPromiser.Tables[0].Rows.Count > 0)
                        {
                            lblProAddress.Text = dsGetPromiser.Tables[0].Rows[0]["p_address"].ToString();
                            lblProID.Text = dsGetPromiser.Tables[0].Rows[0]["contract_code"].ToString();
                            lblProMob.Text = dsGetPromiser.Tables[0].Rows[0]["mobile_no"].ToString();
                            lblProName.Text = dsGetPromiser.Tables[0].Rows[0]["initial_name"].ToString();
                            lblProNIC.Text = dsGetPromiser.Tables[0].Rows[0]["nic"].ToString();

                        }
                        else
                        { 
                            lblProAddress.Text = "No records found";
                            lblProID.Text = "No records found";
                            lblProMob.Text = "No records found";
                            lblProName.Text = "No records found";
                            lblProNIC.Text = "No records found";
                            
                        }
                    }
                    else
                    {
                        string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                        base.Response.Write(close);
                    }
                }
                else
                {
                    string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                    base.Response.Write(close);
                }
            }
            else
            {
                string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                base.Response.Write(close);
            }
        }

        protected void loadDataToRepeaterImg(string strQRY)
        {
            //int iCurrentPage = Convert.ToInt32(strCurrentPage);
            //COUNT ALL RECORDS
            DataSet dsAllData = cls_Connection.getDataSet(strQRY);
            //iAllRows = dsAllData.Tables[0].Rows.Count;
            //iAllCol = dsAllData.Tables[0].Columns.Count;

            //GET RELEVANT DATA
            MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, cls_Connection.DBConnect());
            DataSet dsSelectData = new DataSet();
            daData.Fill(dsSelectData);

            rpImg.DataSource = dsSelectData;
            rpImg.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlNoImg.Visible = false;
                pnlImg.Visible = true;
            }
            else
            {
                pnlNoImg.Visible = true;
                lblImgMsg.Text = "No Photos.";
                pnlImg.Visible = false;
            }
        }
    }
}
