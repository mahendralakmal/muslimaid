using System;
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

namespace LoanSystem.Micro
{
    public partial class Repayment_Sheet : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    DataSet dsCity;
                    MySqlCommand cmdCity = new MySqlCommand("SELECT b_code,b_name FROM branch ORDER BY 2");
                    dsCity = objDBTask.selectData(cmdCity);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsCity.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add("[" + dsCity.Tables[0].Rows[i]["b_code"] + "] - " + dsCity.Tables[0].Rows[i]["b_name"].ToString());
                        cmbCityCode.Items[i + 1].Value = dsCity.Tables[0].Rows[i]["b_code"].ToString();
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
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex != 0)
            {
                if (cmbSocietyID.Items.Count > 0)
                {
                    cmbSocietyID.Items.Clear();
                }

                if (cmbRoot.Items.Count > 0)
                {
                    cmbRoot.Items.Clear();
                }

                DataSet dsCenter;
                MySqlCommand cmdCenter = new MySqlCommand("select idcenter_details,center_name,villages from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "'");
                dsCenter = objDBTask.selectData(cmdCenter);
                if (dsCenter.Tables[0].Rows.Count > 0)
                {
                    //cmbSocietyID.Items.Add("");
                    btnSerch.Enabled = true;

                    for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                    {
                        cmbSocietyID.Items.Add("[" + dsCenter.Tables[0].Rows[i]["idcenter_details"] + "] - " + dsCenter.Tables[0].Rows[i]["villages"].ToString() + "-" + dsCenter.Tables[0].Rows[i]["center_name"].ToString());
                        cmbSocietyID.Items[i].Value = dsCenter.Tables[0].Rows[i]["idcenter_details"].ToString();

                        //cmbAds.Items.Add("[" + dsData.Tables[0].Rows[i]["advertisementid"] + "] - " + dsData.Tables[0].Rows[i]["makename"].ToString() + "-" + dsData.Tables[0].Rows[i]["model"].ToString() + " - " + dsData.Tables[0].Rows[i]["submodel"].ToString());
                        //cmbAds.Items[i].Value = dsData.Tables[0].Rows[i]["advertisementid"].ToString();
                    }
                }
                else
                {
                    lblMsg.Text = "No record found...! Please chose other city code.";
                    btnSerch.Enabled = false;
                }

                DataSet dsGetRootID = objDBTask.selectData("select exe_id,exe_name from micro_exective_root where branch_code = '" + cmbCityCode.SelectedItem.Value + "';");

                cmbRoot.Items.Add("");

                for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                {
                    cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                    cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();

                }

            }
            else
            {
                if (cmbSocietyID.Items.Count > 0)
                {
                    cmbSocietyID.Items.Clear();
                }

                if (cmbRoot.Items.Count > 0)
                {
                    cmbRoot.Items.Clear();
                }

                lblMsg.Text = "Please chose city code.";
                btnSerch.Enabled = false;
            }
        }

        protected void GetSearch()
        { 
            lblMsg.Text = "";
            pnlViewData.Visible = false;
            pnlSearch.Visible = true;
            if(cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select Branch code.";
            }
            else if(cmbSocietyID.SelectedIndex < 0 || cmbRoot.SelectedIndex < 0)
            {
                lblMsg.Text = "Please select Other Branch Code.";
            }
            else if (cmbRoot.SelectedIndex == 0 && cmbSocietyID.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select CRO or Center.";
            }
            else
            {
                string strCityCode = cmbCityCode.SelectedValue;
                

                if (cmbSocietyID.SelectedIndex != 0)
                {
                    string strSocietyID = cmbSocietyID.SelectedValue;
                    DataSet dsGetSocietyName = objDBTask.selectData("select villages from center_details where city_code = '" + strCityCode + "' and idcenter_details = '" + strSocietyID + "';");
                    lblSocietyName.Text = dsGetSocietyName.Tables[0].Rows[0][0].ToString();
                    lblBranchCode.Text = strCityCode;
                }

                //string strBranch = Session["Branch"].ToString();
                //string strUserType = Session["UserType"].ToString();
                string strQRY = "";
                if (cmbSocietyID.SelectedIndex != 0 && cmbRoot.SelectedIndex == 0 && txtDate.Text.Trim() == "")
                {
                    strQRY = "select l.contra_code,c.initial_name,format(l.loan_amount,2),format(l.monthly_instollment,2),c.team_id from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.loan_sta != 'C' and l.chequ_no != '' and l.current_loan_amount > 0 and c.city_code = '" + strCityCode + "' and c.society_id = '" + cmbSocietyID.SelectedValue + "';";
                }
                else if (cmbSocietyID.SelectedIndex != 0 && cmbRoot.SelectedIndex != 0 && txtDate.Text.Trim() == "")
                {
                    strQRY = "select l.contra_code,c.initial_name,format(l.loan_amount,2),format(l.monthly_instollment,2),c.team_id from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.loan_sta != 'C' and l.chequ_no != '' and l.current_loan_amount > 0 and c.city_code = '" + strCityCode + "' and c.society_id = '" + cmbSocietyID.SelectedValue + "' and c.root_id = '" + cmbRoot.SelectedItem.Value + "';";
                }
                else if (cmbSocietyID.SelectedIndex != 0 && cmbRoot.SelectedIndex != 0 && txtDate.Text.Trim() != "")
                {
                    strQRY = "select l.contra_code,c.initial_name,format(l.loan_amount,2),format(l.monthly_instollment,2),c.team_id from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.loan_sta != 'C' and l.chequ_no != '' and l.current_loan_amount > 0 and c.city_code = '" + strCityCode + "' and c.society_id = '" + cmbSocietyID.SelectedValue + "' and c.root_id = '" + cmbRoot.SelectedItem.Value + "' and l.due_date = '" + txtDate.Text.Trim() + "';";
                }
                else if (cmbSocietyID.SelectedIndex == 0 && cmbRoot.SelectedIndex != 0 && txtDate.Text.Trim() != "")
                {
                    strQRY = "select l.contra_code,c.initial_name,format(l.loan_amount,2),format(l.monthly_instollment,2),c.team_id from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.loan_sta != 'C' and l.chequ_no != '' and l.current_loan_amount > 0 and c.city_code = '" + strCityCode + "' and c.root_id = '" + cmbRoot.SelectedItem.Value + "' and l.due_date = '" + txtDate.Text.Trim() + "';";
                }
                else
                {
                    strQRY = "select l.contra_code,c.initial_name,format(l.loan_amount,2),format(l.monthly_instollment,2),c.team_id from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.loan_sta != 'C' and l.chequ_no != '' and l.current_loan_amount > 0 and c.city_code = '" + strCityCode + "' and c.society_id = '" + cmbSocietyID.SelectedValue + "' and l.due_date = '" + txtDate.Text.Trim() + "';";
                }
                
                //string strQRY = "select b.ca_code,b.initial_name,b.team_id,format(l.loan_amount,2),format(l.current_loan_amount,2),format(l.monthly_instollment,2) from micro_basic_detail b,micro_loan_details l where l.contra_code = b.contract_code and loan_sta = 'P' and city_code = '" + strCityCode + "' and society_id = '" + strSocietyID + "' or l.contra_code = b.contract_code and loan_sta = 'E' and city_code = '" + strCityCode + "' and society_id = '" + strSocietyID + "' order by idmicro_basic_detail asc;";
                //loadDataToRepeater(strQRY);

                DataSet dsGetData = objDBTask.selectData(strQRY);

                DateTime dtNow = DateTime.Now;
                string strDate = dtNow.ToString("yyyy-MM-dd");

                //string strAtt = "Att";

                if (dsGetData.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    DataRow dr;

                    dt.Columns.Add("Group");
                    dt.Columns.Add("C Code");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Loan Amount");
                    dt.Columns.Add("Install");
                    dt.Columns.Add("Collection Amount"); ;


                    for (int i = 0; i < dsGetData.Tables[0].Rows.Count; i++)
                    {
                        string strCCode = dsGetData.Tables[0].Rows[i]["contra_code"].ToString();
                        string strName = dsGetData.Tables[0].Rows[i]["initial_name"].ToString();
                        string strLAmount = dsGetData.Tables[0].Rows[i]["format(l.loan_amount,2)"].ToString();
                        string strDI = dsGetData.Tables[0].Rows[i]["format(l.monthly_instollment,2)"].ToString();
                        string strGroup = dsGetData.Tables[0].Rows[i]["team_id"].ToString();
                        string strPCount = "0";

                        //DataSet dsGetPaidCount = objDBTask.selectData("select count(contra_code) from micro_payme_summery where contra_code = '" + strCCode + "' and p_type = 'WI' and p_status = 'D';");
                        //if (dsGetPaidCount.Tables[0].Rows[0][0].ToString() != "")
                        //{
                        //    strPCount = dsGetPaidCount.Tables[0].Rows[0][0].ToString();
                        //}

                        dr = dt.NewRow();
                        dr["Group"] = strGroup;
                        dr["C Code"] = strCCode;
                        dr["Name"] = strName;
                        dr["Loan Amount"] = strLAmount;
                        dr["Install"] = strDI;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }

                    pnlViewData.Visible = true;
                    pnlSearch.Visible = false;
                    lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    grvRepaySheet.DataSource = dt;
                    grvRepaySheet.DataBind();

                }
                else
                {
                    pnlViewData.Visible = false;
                    lblMsg.Text = "No records found for your search criteria. Please try again.";
                }

            }
        }

        protected void loadDataToRepeater(string strQRY)
        {
            //int iCurrentPage = Convert.ToInt32(strCurrentPage);
            //COUNT ALL RECORDS
            DataSet dsAllData = objDBTask.selectData(strQRY);
            //iAllRows = dsAllData.Tables[0].Rows.Count;

            //GET RELEVANT DATA
            MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, objDBTask.establishConnection());
            DataSet dsSelectData = new DataSet();
            daData.Fill(dsSelectData);
            grvRepaySheet.DataSource = dsSelectData;
            grvRepaySheet.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlViewData.Visible = true;
                pnlSearch.Visible = false;
                
                lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                pnlViewData.Visible = false;
                pnlSearch.Visible = true;
                lblDate.Text = "";
                lblSocietyName.Text = "";
                lblBranchCode.Text = "";
                
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            GetSearch();
        }
    }
}
