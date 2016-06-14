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
    public partial class Arrears_Report : System.Web.UI.Page
    {
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

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            if (cmbCityCode.SelectedIndex == 0)
            {
                hstrSelectQuery.Value = "select l.contra_code,c.initial_name,c.p_address,c.mobile_no,FORMAT(l.monthly_instollment,2),FORMAT(l.arres_amou,2),FORMAT(l.def,2),l.arres_count,DATE_FORMAT(l.due_date, '%Y-%m-%d'),DATE_FORMAT(l.chequ_deta_on, '%Y-%m-%d') from micro_basic_detail c, micro_loan_details l where l.contra_code = c.contract_code and l.arres_amou > 0 and l.loan_sta != 'C'";
            }
            else
            {
                hstrSelectQuery.Value = "select l.contra_code,c.initial_name,c.p_address,c.mobile_no,FORMAT(l.monthly_instollment,2),FORMAT(l.arres_amou,2),FORMAT(l.def,2),l.arres_count,DATE_FORMAT(l.due_date, '%Y-%m-%d'),DATE_FORMAT(l.chequ_deta_on, '%Y-%m-%d') from micro_basic_detail c, micro_loan_details l where l.contra_code = c.contract_code and l.arres_amou > 0 and l.loan_sta != 'C' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
            }

            if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' and l.loan_sta = 'E' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = 'E' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "1")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' and l.arres_count = '1' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "1")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' and l.loan_sta = 'E' and l.arres_count = '1' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "1")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = 'E' and l.arres_count = '1' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "1")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.arres_count = '1' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "2")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' and l.arres_count >= '2' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "2")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' and l.loan_sta = 'E' and l.arres_count >= '2' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "2")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.loan_sta = 'E' and l.arres_count >= '2' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "2")
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " and l.arres_count >= '2' order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            else
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by c.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }

            loadDataToRepeater(hstrSelectQuery.Value);
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
            grvArRep.DataSource = dsSelectData;
            grvArRep.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlSummery.Visible = true;
                string strSummery = "";
                hstrSelectQuery1.Value = "";
                if (cmbCityCode.SelectedIndex == 0)
                {
                    hstrSelectQuery1.Value = "select count(l.contra_code),sum(l.arres_amou) from micro_basic_detail c, micro_loan_details l where l.contra_code = c.contract_code and l.arres_amou > 0 and l.loan_sta != 'C'";
                }
                else
                {
                    hstrSelectQuery1.Value = "select count(l.contra_code),sum(l.arres_amou) from micro_basic_detail c, micro_loan_details l where l.contra_code = c.contract_code and l.arres_amou > 0 and l.loan_sta != 'C' and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                }

                if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.contra_code = '" + txtContraCode.Text.Trim() + "' and l.loan_sta = 'E'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.loan_sta = 'E'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "")
                {
                    //hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.loan_sta = 'D'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "1")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.arres_count = '1' and l.contra_code = '" + txtContraCode.Text.Trim() + "'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "1")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + "and l.arres_count = '1' and l.contra_code = '" + txtContraCode.Text.Trim() + "' and l.loan_sta = 'E'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "1")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.arres_count = '1' and l.loan_sta = 'E'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "1")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.arres_count = '1'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "2")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.arres_count >= '2' and l.contra_code = '" + txtContraCode.Text.Trim() + "'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() != "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "2")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + "and l.arres_count >= '2' and l.contra_code = '" + txtContraCode.Text.Trim() + "' and l.loan_sta = 'E'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "D" && cmbACount.SelectedItem.Value == "2")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.arres_count >= '2' and l.loan_sta = 'E'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else if (txtContraCode.Text.Trim() == "" && cmbStatus.SelectedItem.Value == "A" && cmbACount.SelectedItem.Value == "2")
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.arres_count >= '2'";

                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by c.idmicro_basic_detail desc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = objDBTask.selectData(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblNoArres.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblArreAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            lblNoArres.Text = "";
            lblMsg.Text = "";
            lblArreAmount.Text = "";
            pnlSummery.Visible = false;
            grvArRep.DataSource = null;
            grvArRep.DataBind();

            GetSearch();
        }

    }
}
