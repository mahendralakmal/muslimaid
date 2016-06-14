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
    public partial class Service_Charges_Receipts : System.Web.UI.Page
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
                pnlReceiptPreview.Visible = false;
                pnlSearch.Visible = true;
                lblMsg.Text = "Please select city code.";
            }
            else if (cmbSocietyID.SelectedIndex < 0)
            {
                pnlReceiptPreview.Visible = false;
                pnlSearch.Visible = true;
                lblMsg.Text = "Please select society ID.";
            }
            else if (txtDate.Text.Trim() == "")
            {
                pnlReceiptPreview.Visible = false;
                pnlSearch.Visible = true;
                lblMsg.Text = "Please enter date.";
            }
            else
            {
                string strCityCode = cmbCityCode.SelectedValue;
                string strSocietyID = cmbSocietyID.SelectedValue;
                string strDate = txtDate.Text.Trim();
                string strQry = "select b.b_name,u.last_name,c.nic,c.initial_name,c.p_address,s.contract_code,s.document_amount,s.insurance_amount,s.date_time,s.total_amount_text,s.total_amount,s.idmicro_service_charges,s.welfair_fee,s.registration_fee from micro_service_charges s, micro_basic_detail c, branch b,users u where s.contract_code = c.contract_code and s.city_code = '" + strCityCode + "' and c.society_id = '" + strSocietyID + "' and s.date_time = '" + strDate + "' and b.b_code = s.city_code and u.nic = s.user_nic and payment_status = 'D';";
                loadDataToRepeater(strQry);
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
            repInvoice.DataSource = dsSelectData;
            repInvoice.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlReceiptPreview.Visible = true;
                pnlSearch.Visible = false;
            }
            else
            {
                pnlReceiptPreview.Visible = false;
                pnlSearch.Visible = true;
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }
    }
}
