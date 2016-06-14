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
    public partial class Basic_Details_Report : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    DataSet dsCro;
                    MySqlCommand cmdCro = new MySqlCommand("SELECT exe_id, exe_name FROM micro_exective_root");
                    dsCro = objDBTask.selectData(cmdCro);
                    ddlCro.Items.Add("Select CRO");
                    for (int i = 0; i < dsCro.Tables[0].Rows.Count; i++)
                    {
                        ddlCro.Items.Add(dsCro.Tables[0].Rows[i][1].ToString());
                        ddlCro.Items[i + 1].Value = dsCro.Tables[0].Rows[i][0].ToString();
                    }

                    DataSet dsCenter;
                    MySqlCommand cmdCenter = new MySqlCommand("SELECT idcenter_details,concat(center_name, '-',villages) FROM center_details");
                    dsCenter = objDBTask.selectData(cmdCenter);
                    ddlCenter.Items.Add("Select Center");
                    for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                    {
                        ddlCenter.Items.Add(dsCenter.Tables[0].Rows[i][1].ToString());
                        ddlCenter.Items[i + 1].Value = dsCenter.Tables[0].Rows[i][0].ToString();
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
            hstrSelectQuery.Value = "SELECT concat(c.center_name, '-',c.villages) AS `GROUP`, l.contra_code ,b.full_name, b.p_address, b.land_no FROM center_details c, micro_loan_details l, micro_basic_detail b, micro_exective_root e WHERE b.contract_code= l.contra_code AND b.city_code = c.city_code AND b.root_id = e.exe_id AND b.society_id = c.idcenter_details AND e.branch_code = b.city_code";
            if (ddlCro.SelectedIndex != 0 || ddlCenter.SelectedIndex != 0 || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "")
            {
                if (txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && ddlCro.SelectedIndex != 0 && ddlCenter.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and e.exe_id = '" + ddlCro.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by e.exe_id asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && ddlCro.SelectedIndex == 0 || ddlCenter.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and c.idcenter_details = '" + ddlCenter.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "" && ddlCro.SelectedIndex != 0 || ddlCenter.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and e.exe_id = '" + ddlCro.SelectedValue.ToString() + "' and c.idcenter_details = '" + ddlCenter.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && ddlCro.SelectedIndex == 0 || ddlCenter.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && ddlCro.SelectedIndex != 0 || ddlCenter.SelectedIndex == 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and e.exe_id = '" + ddlCro.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
                else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && ddlCro.SelectedIndex == 0 || ddlCenter.SelectedIndex != 0)
                {
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.idcenter_details = '" + ddlCenter.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
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
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " and b.date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and c.idcenter_details = '" + ddlCenter.SelectedValue.ToString() + "' and e.exe_id = '" + ddlCro.SelectedValue.ToString() + "'";
                    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
                    loadDataToRepeater(hstrSelectQuery.Value);
                }
            }
            else
            {
                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by b.idmicro_basic_detail asc;";
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

            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

       
    }
}
