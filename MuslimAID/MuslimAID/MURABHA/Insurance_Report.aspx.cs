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
    public partial class Insurance_Report : System.Web.UI.Page
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
            grvCliDeta.DataSource = null;
            grvCliDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select s.contract_code,b.nic,b.initial_name,s.city_code,format(l.loan_amount,2),l.period,f.spouse_name,f.spouse_nic from micro_service_charges s,micro_basic_detail b,micro_loan_details l,micro_family_details f where b.contract_code = s.contract_code and f.contract_code = s.contract_code and f.contract_code = l.contra_code and s.payment_status = 'D'";
            if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
            {
                if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and s.contract_code = '" + txtContraCode.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by s.idmicro_service_charges asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and s.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by s.idmicro_service_charges asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and s.contract_code = '" + txtContraCode.Text.Trim() + "' and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by s.idmicro_service_charges asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by s.idmicro_service_charges asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and s.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by s.idmicro_service_charges asc;";
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
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and s.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and s.contract_code = '" + txtContraCode.Text.Trim() + "' and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by s.idmicro_service_charges asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
            }
            else
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by s.idmicro_service_charges asc;";
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
            grvCliDeta.DataSource = dsSelectData;
            grvCliDeta.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlClientDetail.Visible = true;
                pnlSummery.Visible = true;
                pnlNoData.Visible = false;

                string strSummery;
                hstrSelectQuery1.Value = "";
                hstrSelectQuery1.Value = "select count(s.contract_code) from micro_service_charges s,micro_family_details f where f.contract_code = s.contract_code and s.payment_status = 'D'";
                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
                {
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and s.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and s.contract_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and s.contract_code = '" + txtContraCode.Text.Trim() + "' and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else if (txtContraCode.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and s.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and s.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and s.contract_code = '" + txtContraCode.Text.Trim() + "' and s.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by s.idmicro_service_charges asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        string strCount = dsSummery.Tables[0].Rows[0][0].ToString();
                        decimal decCount = Convert.ToDecimal(strCount);
                        lblNoIns.Text = strCount;
                        decimal decAmount = decCount * 190;
                        lblInsAmount.Text = decAmount.ToString("#,##0.00");
                    }
                }
                else
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by s.idmicro_service_charges asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        string strCount = dsSummery.Tables[0].Rows[0][0].ToString();
                        decimal decCount = Convert.ToDecimal(strCount);
                        lblNoIns.Text = strCount;
                        decimal decAmount = decCount * 190;
                        lblInsAmount.Text = decAmount.ToString("#,##0.00");
                    }
                }
            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
                pnlClientDetail.Visible = false;
                pnlSummery.Visible = false;
                pnlNoData.Visible = false;
            }
        }
    }
}
