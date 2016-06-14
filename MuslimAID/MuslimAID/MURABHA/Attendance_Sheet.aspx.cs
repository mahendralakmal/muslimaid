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
    public partial class Attendance_Sheet : System.Web.UI.Page
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
                    string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                    base.Response.Write(close);
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

        protected void GetSearch()
        {
            lblMsg.Text = "";
            pnlViewData.Visible = false;
            pnlSearch.Visible = true;
            if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select Branch code.";
            }
            else if (cmbSocietyID.SelectedIndex < 0)
            {
                lblMsg.Text = "Please select society id.";
            }
            else
            {
                string strCityCode = cmbCityCode.SelectedValue;
                string strSocietyID = cmbSocietyID.SelectedValue;

                DataSet dsGetSocietyName = objDBTask.selectData("select villages from center_details where city_code = '" + strCityCode + "' and idcenter_details = '" + strSocietyID + "';");
                lblSocietyName.Text = dsGetSocietyName.Tables[0].Rows[0][0].ToString();
                lblBranchCode.Text = strCityCode;

                string strQRY = "select l.contra_code,c.initial_name from micro_loan_details l,micro_basic_detail c where c.contract_code = l.contra_code and l.loan_approved = 'Y' and l.loan_sta != 'C' and l.chequ_no != '' and l.current_loan_amount > 0 and c.city_code = '" + strCityCode + "' and c.society_id = '" + strSocietyID + "';";
                loadDataToRepeater(strQRY);
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
            grvRepaySheet.DataSource = dsSelectData;
            grvRepaySheet.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlViewData.Visible = true;
                pnlSearch.Visible = false;

                lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                pnlViewData.Visible = false;
                pnlSearch.Visible = true;
                lblDate.Text = "";
                lblSocietyName.Text = "";
                lblBranchCode.Text = "";

                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            GetSearch();
        }
    }
}
