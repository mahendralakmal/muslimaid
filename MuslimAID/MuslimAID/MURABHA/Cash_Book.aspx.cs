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
    public partial class Cash_Book : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                grvInstaDeta.AllowPaging = true;
                grvInstaDeta.PageSize = 20;


                grvLoanDeta.AllowPaging = true;
                grvLoanDeta.PageSize = 20;
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            grvInstaDeta.DataSource = null;
            grvInstaDeta.DataBind();

            grvLoanDeta.DataSource = null;
            grvLoanDeta.DataBind();

            GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            hstrSelectQuery.Value = "";
            hstrSelectQuery.Value = "select chequ_no,chequ_amount,chequ_deta_on from micro_loan_details where chequ_no != '' and loan_approved = 'Y'";
            hstrSelectQuery.Value = hstrSelectQuery.Value + " order by idloan_details desc;";
            loadDataToRepeater2(hstrSelectQuery.Value);

            hstrSelectQuery2.Value = "";
            hstrSelectQuery2.Value = "select idpais_history,paied_amount,date_time from micro_pais_history where tra_description = 'WI' and pay_status = 'D'";
            hstrSelectQuery2.Value = hstrSelectQuery2.Value + " order by idpais_history desc;";
            loadDataToRepeater(hstrSelectQuery2.Value);

            //if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "")
            //{
            //    if (txtContraCode.Text.Trim() != "" && txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() == "")
            //    {
            //        hstrSelectQuery.Value = hstrSelectQuery.Value + " where contract_code = '" + txtContraCode.Text.Trim() + "'";
            //        hstrSelectQuery.Value = hstrSelectQuery.Value + " order by idmicro_basic_detail desc;";
            //        loadDataToRepeater(hstrSelectQuery.Value);
            //    }
            //    else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "" && txtContraCode.Text.Trim() == "")
            //    {
            //        hstrSelectQuery.Value = hstrSelectQuery.Value + " where date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
            //        hstrSelectQuery.Value = hstrSelectQuery.Value + " order by idmicro_basic_detail desc;";
            //        loadDataToRepeater(hstrSelectQuery.Value);
            //    }
            //    else if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() == "")
            //    {
            //        lblMsg.Text = "Please enter To Date.";
            //    }
            //    else if (txtDateFrom.Text.Trim() == "" && txtDateTo.Text.Trim() != "")
            //    {
            //        lblMsg.Text = "Please enter From Date.";
            //    }
            //    else
            //    {
            //        hstrSelectQuery.Value = hstrSelectQuery.Value + " where date_time between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "' and contract_code = '" + txtContraCode.Text.Trim() + "'";
            //        hstrSelectQuery.Value = hstrSelectQuery.Value + " order by idmicro_basic_detail desc;";
            //        loadDataToRepeater(hstrSelectQuery.Value);
            //    }
            //}
            //else
            //{
            //    hstrSelectQuery.Value = hstrSelectQuery.Value + " order by idmicro_basic_detail desc;";
            //    loadDataToRepeater(hstrSelectQuery.Value);
            //}


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
            grvInstaDeta.DataSource = dsSelectData;
            grvInstaDeta.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void grvInstaDeta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            grvInstaDeta.PageIndex = e.NewPageIndex;


            // Rebind the GridView control to  
            // show data in the new page.
            GetSearch();
        }

        protected void loadDataToRepeater2(string strQRY)
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

            }
            else
            {
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void grvLoanDeta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            grvLoanDeta.PageIndex = e.NewPageIndex;


            // Rebind the GridView control to  
            // show data in the new page.
            GetSearch();
        }
    }
}
