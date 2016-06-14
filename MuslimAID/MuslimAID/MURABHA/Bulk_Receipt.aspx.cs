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
    public partial class Bulk_Receipt : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        static int iAllPages;
        const int iRowCount = 5;
        static int iAllRows;

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
                        cmbCityCode.Items[i+1].Value = dsCity.Tables[0].Rows[i]["b_code"].ToString();
                    }
                }
                else
                {
                    Response.Redirect("../Default.aspx");
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
            }
            else
            {
                if (cmbSocietyID.Items.Count > 0)
                {
                    cmbSocietyID.Items.Clear();
                }
                lblMsg.Text = "Please chose city code.";
                btnSerch.Enabled = false;
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select city code.";
            }
            else if (cmbSocietyID.SelectedIndex < 0)
            {
                lblMsg.Text = "Please select society ID.";
            }
            else if (txtDate.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter date.";
            }
            else
            {
                string strCityCode = cmbCityCode.SelectedValue;
                string strSocietyID = cmbSocietyID.SelectedValue;
                string strDate = txtDate.Text.Trim();
                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = "select r.contract_code,r.rec_no,b.b_name,r.paied_amount,r.curr_arres,r.balance,r.due_date,r.invoice_date,r.amount_text,u.last_name,c.nic,c.initial_name,c.p_address from micro_receipt_history r, micro_basic_detail c, branch b,users u where r.contract_code = c.contract_code and r.city_code = '" + strCityCode + "' and c.society_id = '" + strSocietyID + "' and r.invoice_date = '" + strDate + "' and b.b_code = r.city_code and u.nic = r.cash_nic;";
                hiCurrentPage.Value = "1";
                loadDataToRepeater(hstrSelectQuery.Value, hiCurrentPage.Value);
            }
        }

        protected void loadDataToRepeater(string strQRY, string strCurrentPage)
        {
            int iCurrentPage = Convert.ToInt32(strCurrentPage);
            //COUNT ALL RECORDS
            DataSet dsAllData = objDBTask.selectData(strQRY);
            iAllRows = dsAllData.Tables[0].Rows.Count;
            //iAllCol = dsAllData.Tables[0].Columns.Count;

            //GET RELEVANT DATA
            MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, objDBTask.establishConnection());
            DataSet dsSelectData = new DataSet();
            daData.Fill(dsSelectData, (iCurrentPage - 1) * iRowCount, iRowCount, "Table");

            repInvoice.DataSource = dsSelectData;
            repInvoice.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                if (iAllRows % iRowCount > 0)
                {
                    iAllPages = iAllRows / iRowCount + 1;
                }
                else
                {
                    iAllPages = iAllRows / iRowCount;
                }

                lblPages.Text = "Page " + iCurrentPage + " of " + iAllPages + " Pages";
                lblPagesB.Text = "Page " + iCurrentPage + " of " + iAllPages + " Pages";
                pageNavigation();
                pnlReceiptPreview.Visible = true;
                pnlSearch.Visible = false;
                pnlFull.Visible = true;
            }
            else
            {
                pnlSearch.Visible = true;
                pnlReceiptPreview.Visible = false;
                pnlFull.Visible = false;
                lblMsg.Text = objCommonTask.literalWarningMessage("No records found for your search criteria. Please try again.");
                lnkFirst.Enabled = false;
                lnkLast.Enabled = false;
                lnkNext.Enabled = false;
                lnkPrevious.Enabled = false;

                lnkFirstB.Enabled = false;
                lnkLastB.Enabled = false;
                lnkNextB.Enabled = false;
                lnkPreviousB.Enabled = false;

                lnkFirst.Visible = false;
                lnkPrevious.Visible = false;
                lnkNext.Visible = false;
                lnkLast.Visible = false;

                lnkFirstB.Visible = false;
                lnkPreviousB.Visible = false;
                lnkNextB.Visible = false;
                lnkLastB.Visible = false;

                lblPages.Visible = false;
                lblPagesB.Visible = false;
            }
        }

        protected void pageNavigation()
        {
            lnkFirst.Visible = true;
            lnkPrevious.Visible = true;
            lnkNext.Visible = true;
            lnkLast.Visible = true;

            lnkFirstB.Visible = true;
            lnkPreviousB.Visible = true;
            lnkNextB.Visible = true;
            lnkLastB.Visible = true;

            lblPages.Visible = true;
            lblPagesB.Visible = true;

            if (hiCurrentPage.Value == "1")
            {
                lnkFirst.Enabled = false;
                lnkPrevious.Enabled = false;
                lnkNext.Enabled = true;
                lnkLast.Enabled = true;

                lnkFirstB.Enabled = false;
                lnkPreviousB.Enabled = false;
                lnkNextB.Enabled = true;
                lnkLastB.Enabled = true;
            }
            if (Convert.ToInt32(hiCurrentPage.Value) == iAllPages)
            {
                lnkFirst.Enabled = true;
                lnkPrevious.Enabled = true;
                lnkNext.Enabled = false;
                lnkLast.Enabled = false;

                lnkFirstB.Enabled = true;
                lnkPreviousB.Enabled = true;
                lnkNextB.Enabled = false;
                lnkLastB.Enabled = false;
            }
            if (Convert.ToInt32(hiCurrentPage.Value) == 1 && iAllPages == 1)
            {
                lnkFirst.Enabled = false;
                lnkPrevious.Enabled = false;
                lnkNext.Enabled = false;
                lnkLast.Enabled = false;

                lnkFirstB.Enabled = false;
                lnkPreviousB.Enabled = false;
                lnkNextB.Enabled = false;
                lnkLastB.Enabled = false;
            }
            if (Convert.ToInt32(hiCurrentPage.Value) != 1 && Convert.ToInt32(hiCurrentPage.Value) != iAllPages)
            {
                lnkFirst.Enabled = true;
                lnkPrevious.Enabled = true;
                lnkNext.Enabled = true;
                lnkLast.Enabled = true;

                lnkFirstB.Enabled = true;
                lnkPreviousB.Enabled = true;
                lnkNextB.Enabled = true;
                lnkLastB.Enabled = true;
            }
        }

        protected void lnkFirst_Click(object sender, EventArgs e)
        {
            hiCurrentPage.Value = "1";
            loadDataToRepeater(hstrSelectQuery.Value, hiCurrentPage.Value);
        }

        protected void lnkPrevious_Click(object sender, EventArgs e)
        {
            hiCurrentPage.Value = Convert.ToString(Convert.ToInt32(hiCurrentPage.Value) - 1);
            loadDataToRepeater(hstrSelectQuery.Value, hiCurrentPage.Value);
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            hiCurrentPage.Value = Convert.ToString(Convert.ToInt32(hiCurrentPage.Value) + 1);
            loadDataToRepeater(hstrSelectQuery.Value, hiCurrentPage.Value);
        }

        protected void lnkLast_Click(object sender, EventArgs e)
        {
            hiCurrentPage.Value = Convert.ToString(iAllPages);
            loadDataToRepeater(hstrSelectQuery.Value, hiCurrentPage.Value);
        }
    }
}
