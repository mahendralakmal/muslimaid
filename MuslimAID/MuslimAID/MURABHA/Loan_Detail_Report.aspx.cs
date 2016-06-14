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
    public partial class Loan_Detail_Report : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    DataSet dsBranch;
                    MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                    dsBranch = objDBTask.selectData(cmdBranch);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                        cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            grvLoanDeta.DataSource = null;
            grvLoanDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select l.contra_code,FORMAT(l.loan_amount,2),FORMAT(l.service_charges,2),FORMAT(l.other_charges,2),l.interest_rate,FORMAT(l.interest_amount,2),l.period,FORMAT(l.monthly_instollment,2) from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code";
            if (cmbCityCode.SelectedIndex != 0 && cmbRoot.SelectedIndex != 0 && cmbVillagr.SelectedIndex == 0)
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.exe_root_id = '" + cmbRoot.SelectedItem.Value + "'";
            }
            else if (cmbCityCode.SelectedIndex != 0 && cmbRoot.SelectedIndex != 0 && cmbVillagr.SelectedIndex != 0)
            {
                string strVill = cmbVillagr.SelectedValue.Split(char.Parse("-"))[0];
                string strCenName = cmbVillagr.SelectedValue.Split(char.Parse("-"))[1];
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.exe_root_id = '" + cmbRoot.SelectedItem.Value + "' and c.society_id = '" + strCenName + "' and c.village = '" + strVill + "'";
            }
            else if (cmbCityCode.SelectedIndex != 0 && cmbRoot.SelectedIndex == 0 && cmbVillagr.SelectedIndex != 0)
            {
                string strVill = cmbVillagr.SelectedValue.Split(char.Parse("-"))[0];
                string strCenName = cmbVillagr.SelectedValue.Split(char.Parse("-"))[1];
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.society_id = '" + strCenName + "' and c.village = '" + strVill + "'";
            }

            if (cmbStatus.SelectedIndex != 0)
            {
                if (cmbStatus.SelectedIndex == 1)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = 'P' and loan_approved = 'P'";
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = '" + cmbStatus.SelectedItem.Value + "'";
                }
                
            }

            if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
            {
                if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.created_on between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.created_on between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter To Date.";
                }
                else if (txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() != "")
                {
                    lblMsg.Text = "Please enter From Date.";
                }
                else
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.created_on between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and l.contra_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }

            }
            else
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
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
            grvLoanDeta.DataSource = dsSelectData;
            grvLoanDeta.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlSummery.Visible = true;
                string strSummery;
                lblDisb.Text = "0.00";
                lblIAmount.Text = "0.00";
                lblNoContra.Text = "0";
                lblSCharges.Text = "0.00";
                hstrSelectQuery1.Value = "";
                hstrSelectQuery1.Value = "select count(l.contra_code),sum(l.loan_amount),sum(l.service_charges),sum(l.interest_amount) from micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.loan_sta != 'C'";
                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
                {
                    if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.created_on between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else if (txtContraCode.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.created_on between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.created_on between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and l.contra_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }

                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows[0][0].ToString() != "")
                    {
                        lblNoContra.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblDisb.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                        lblSCharges.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][2].ToString()).ToString("#,##0.00");
                        lblIAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][3].ToString()).ToString("#,##0.00");
                    }
                }
                else
                {
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows[0][0].ToString() != "")
                    {
                        lblNoContra.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblDisb.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                        lblSCharges.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][2].ToString()).ToString("#,##0.00");
                        lblIAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][3].ToString()).ToString("#,##0.00");
                    }
                }
            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCityCode.SelectedIndex != 0)
            {
                cmbRoot.Enabled = true;
                cmbVillagr.Enabled = true;

                if (cmbVillagr.Items.Count > 0)
                {
                    cmbVillagr.Items.Clear();
                }

                if (cmbRoot.Items.Count > 0)
                {
                    cmbRoot.Items.Clear();
                }

                string strBranch = cmbCityCode.SelectedItem.Value;

                //Get Viilage
                DataSet dsGetVillge = objDBTask.selectData("select villages,center_name,idcenter_details from center_details where city_code = '" + strBranch + "'");
                if (dsGetVillge.Tables[0].Rows.Count > 0)
                {
                    cmbVillagr.Items.Add("");
                    for (int i = 0; i < dsGetVillge.Tables[0].Rows.Count; i++)
                    {
                        cmbVillagr.Items.Add("[" + dsGetVillge.Tables[0].Rows[i]["villages"] + "] - " + dsGetVillge.Tables[0].Rows[i]["center_name"].ToString());
                        cmbVillagr.Items[i + 1].Value = dsGetVillge.Tables[0].Rows[i]["villages"].ToString() + "-" + dsGetVillge.Tables[0].Rows[i]["idcenter_details"].ToString();

                    }
                }

                DataSet dsGetRootID = objDBTask.selectData("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");

                cmbRoot.Items.Add("");

                for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                {
                    cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                    cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();

                }
            }
            else
            {
                if (cmbRoot.Items.Count > 0)
                {
                    cmbRoot.Items.Clear();
                }

                if (cmbVillagr.Items.Count > 0)
                {
                    cmbVillagr.Items.Clear();
                }

                cmbVillagr.Enabled = false;

                cmbRoot.Enabled = false;
            }
        }
    }
}
