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
    public partial class Business_Detail_Report : System.Web.UI.Page
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
            grvBusiDeta.DataSource = null;
            grvBusiDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select b.contract_code,b.business_name,b.busi_duration,FORMAT(b.total_income,2),FORMAT(b.total_expenses,2),FORMAT(b.profit_lost,2),FORMAT(b.family_expenses,2),FORMAT(b.net_income,2) from micro_business_details b, micro_loan_details l, micro_basic_detail c where c.contract_code = l.contra_code and l.contra_code = b.contract_code and l.loan_sta != 'C'";
            if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
            {
                if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.contract_code = '" + txtContraCode.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.contract_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
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
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
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
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and b.contract_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
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
            grvBusiDeta.DataSource = dsSelectData;
            grvBusiDeta.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        
    }
}
