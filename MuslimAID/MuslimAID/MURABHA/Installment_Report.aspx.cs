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
    public partial class Installment_Report : System.Web.UI.Page
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
                Response.Redirect("Default.aspx");
            }
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select p.idpais_history,p.contra_code,p.nic,b.initial_name,FORMAT(p.paied_amount,2),p.payment_type,p.chq_No,p.chq_bank,p.date_time from micro_basic_detail b, micro_pais_history p where p.tra_description = 'WI' and p.pay_status = 'D' and p.contra_code = b.contract_code";
            if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
            {
                if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and p.contra_code = '" + txtContraCode.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and p.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and p.contra_code = '" + txtContraCode.Text.Trim() + "' and b.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtContraCode.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and p.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and b.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
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
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and p.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and p.contra_code = '" + txtContraCode.Text.Trim() + "' and b.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
            }
            else
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by p.idpais_history asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            lblInsAmount.Text = "";
            lblMsg.Text = "";
            lblNoIns.Text = "";
            pnlSummery.Visible = false;
            grvMIn.DataSource = null;
            grvMIn.DataBind();

            GetSearch();
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
            grvMIn.DataSource = dsSelectData;
            grvMIn.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlSummery.Visible = true;
                string strSummery;
                hstrSelectQuery1.Value = "";
                hstrSelectQuery1.Value = "select count(p.contra_code),sum(p.paied_amount) from micro_pais_history p,micro_basic_detail c where p.tra_description = 'WI' and p.pay_status = 'D' and p.contra_code = c.contract_code";
                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0)
                {
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and p.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex == 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and p.contra_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    else if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and p.contra_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else if (txtContraCode.Text.Trim() == "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "" && cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and p.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }
                    else
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and p.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and p.contra_code = '" + txtContraCode.Text.Trim() + "' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                    }

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by p.idpais_history asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoIns.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblInsAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by p.idpais_history asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoIns.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblInsAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }


            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        
    }
}
