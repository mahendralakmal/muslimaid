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
    public partial class Cheque_Printing_Report : System.Web.UI.Page
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
            lblChqAmount.Text = "";
            lblChqCount.Text = "";
            grvChqDeta.DataSource = null;
            grvChqDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select d.contract_code,format(d.amount,2),l.chequ_no,d.chq_name,replace(replace(concat(d.day1,'',d.day2,'-',d.month1,'',d.month2,'-',d.year1,'',d.year2), ',,', ','), ',,', ',') chq_date,d.date_time from chq_date d, micro_basic_detail c, micro_loan_details l where c.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_sta != 'C' and d.chq_status = 'A'";
            if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
            {
                if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and d.contract_code = '" + txtContraCode.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by d.idchq_date asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and d.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by d.idchq_date asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and d.contract_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by d.idchq_date asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by d.idchq_date asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and d.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by d.idchq_date asc;";
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
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and d.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and d.contract_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by d.idchq_date asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
            }
            else
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by d.idchq_date asc;";
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
            grvChqDeta.DataSource = dsSelectData;
            grvChqDeta.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlChqDetail.Visible = true;
                string strSummery;
                hstrSelectQuery1.Value = "";
                hstrSelectQuery1.Value = "select count(d.contract_code),sum(d.amount) from chq_date d, micro_basic_detail c, micro_loan_details l where c.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_sta != 'C' and d.chq_status = 'A'";
                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
                {
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and d.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and d.contract_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and d.contract_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else if (txtContraCode.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and d.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and d.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and d.contract_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by d.idchq_date asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblChqCount.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblChqAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by d.idchq_date asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblChqCount.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblChqAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
            }
            else
            {
                pnlChqDetail.Visible = false;
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

       
    }
}
