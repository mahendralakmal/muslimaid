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

namespace MuslimAID.MURABAHA
{
    public partial class Service_Charges : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

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
            grvPayment.DataSource = null;
            grvPayment.DataBind();
            lblTotalPaied.Text = "";
            pnlPayment.Visible = false;
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
                    lblMsg.Text = "No record found...! Please chose other Branch Code.";
                    btnSerch.Enabled = false;
                }
            }
            else
            {
                if (cmbSocietyID.Items.Count > 0)
                {
                    cmbSocietyID.Items.Clear();
                }
                lblMsg.Text = "Please chose Branch Code.";
                btnSerch.Enabled = false;
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            grvPayment.DataSource = null;
            grvPayment.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex != 0 && cmbSocietyID.SelectedIndex >= 0)
            {
                string strCityCode = cmbCityCode.SelectedValue;
                string strSocietyID = cmbSocietyID.SelectedValue;

                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = "select b.contract_code,b.ca_code,b.nic,b.initial_name,l.service_charges,l.other_charges,l.registration_fee,l.walfare_fee from micro_basic_detail b,micro_loan_details l where b.city_code = '" + strCityCode + "' and b.society_id = '" + strSocietyID + "' and b.contract_code = l.contra_code and l.loan_approved = 'Y' and l.ser_char_sta = 'N' order by b.idmicro_basic_detail asc;";
                loadDataToRepeater(hstrSelectQuery.Value);

            }
        }

        protected void loadDataToRepeater(string strQRY)
        {
            //int iCurrentPage = Convert.ToInt32(strCurrentPage);
            //COUNT ALL RECORDS
            DataSet dsAllData = cls_Connection.getDataSet(strQRY);
            //iAllRows = dsAllData.Tables[0].Rows.Count;

            //GET RELEVANT DATA
            MySqlDataAdapter daData = new MySqlDataAdapter(strQRY, cls_Connection.DBConnect());
            DataSet dsSelectData = new DataSet();
            daData.Fill(dsSelectData);
            grvPayment.DataSource = dsSelectData;
            grvPayment.DataBind();

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlPayment.Visible = true;
            }
            else
            {
                pnlPayment.Visible = false;
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void lnkTPayment_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblTotalPaied.Text = "";
            decimal decX = 0;
            foreach (GridViewRow grows in grvPayment.Rows)
            {
                CheckBox chkPayment = grows.FindControl("chkPayment") as CheckBox;
                int id = grows.RowIndex;
                if (chkPayment.Checked)
                {
                    string strInsurance = grvPayment.Rows[id].Cells[4].Text;
                    string strDocument = grvPayment.Rows[id].Cells[5].Text;
                    string strRegis = grvPayment.Rows[id].Cells[6].Text;
                    string strWelfa = grvPayment.Rows[id].Cells[7].Text;

                    decimal decIns = Convert.ToDecimal(strInsurance);
                    decimal decDoc = Convert.ToDecimal(strDocument);
                    decimal decRegistr = Convert.ToDecimal(strRegis);
                    decimal decWelfa = Convert.ToDecimal(strWelfa);

                    decX = decX + decIns + decDoc + decRegistr + decWelfa;

                }
            }

            lblTotalPaied.Text = decX.ToString("#,##0.00");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            foreach (GridViewRow grows in grvPayment.Rows)
            {
                string strloginID = Session["NIC"].ToString();
                string strIp = Request.UserHostAddress;
                string strDate = DateTime.Now.ToString("yyyy-MM-dd");
                string strCityCode = cmbCityCode.SelectedValue;
                CheckBox chkPayment = grows.FindControl("chkPayment") as CheckBox;
                int id = grows.RowIndex;
                if (chkPayment.Checked)
                {
                    string strCCode = grvPayment.Rows[id].Cells[0].Text;
                    string strInsurance = grvPayment.Rows[id].Cells[5].Text;
                    string strDocument = grvPayment.Rows[id].Cells[4].Text;
                    string strRegis = grvPayment.Rows[id].Cells[6].Text;
                    string strWelfa = grvPayment.Rows[id].Cells[7].Text;

                    decimal decIns = Convert.ToDecimal(strInsurance);
                    decimal decDoc = Convert.ToDecimal(strDocument);
                    decimal decRegistr = Convert.ToDecimal(strRegis);
                    decimal decWelfa = Convert.ToDecimal(strWelfa);

                    decimal decTotal = decIns + decDoc + decRegistr + decWelfa;
                    int intTotal = Convert.ToInt32(decTotal);
                    string strTotalAmount = Convert.ToString(decTotal);
                    string strTotalText = NumberToText(intTotal, true, false);

                    MySqlCommand cmdInsertDocu = new MySqlCommand("INSERT INTO micro_service_charges(contract_code,document_amount,insurance_amount,city_code,user_nic,user_ip,date_time,total_amount_text,total_amount,welfair_fee,registration_fee)VALUES(@contract_code,@document_amount,@insurance_amount,@city_code,@user_nic,@user_ip,@date_time,@total_amount_text,@total_amount,@welfair_fee,@registration_fee);");

                    #region Assign Parameters
                    cmdInsertDocu.Parameters.Add("@contract_code", MySqlDbType.VarChar, 13);
                    cmdInsertDocu.Parameters.Add("@document_amount", MySqlDbType.Decimal, 10);
                    cmdInsertDocu.Parameters.Add("@insurance_amount", MySqlDbType.Decimal, 10);
                    cmdInsertDocu.Parameters.Add("@city_code", MySqlDbType.VarChar, 4);
                    cmdInsertDocu.Parameters.Add("@user_nic", MySqlDbType.VarChar, 10);
                    cmdInsertDocu.Parameters.Add("@user_ip", MySqlDbType.VarChar, 45);
                    cmdInsertDocu.Parameters.Add("@date_time", MySqlDbType.VarChar, 45);
                    cmdInsertDocu.Parameters.Add("@total_amount_text", MySqlDbType.VarChar, 255);
                    cmdInsertDocu.Parameters.Add("@total_amount", MySqlDbType.Decimal, 10);
                    cmdInsertDocu.Parameters.Add("@welfair_fee", MySqlDbType.Decimal, 10);
                    cmdInsertDocu.Parameters.Add("@registration_fee", MySqlDbType.Decimal, 10);
                    #endregion

                    #region DEclare Parametes
                    cmdInsertDocu.Parameters["@contract_code"].Value = strCCode;
                    cmdInsertDocu.Parameters["@document_amount"].Value = strDocument;
                    cmdInsertDocu.Parameters["@insurance_amount"].Value = strInsurance;
                    cmdInsertDocu.Parameters["@city_code"].Value = strCityCode;
                    cmdInsertDocu.Parameters["@user_nic"].Value = strloginID;
                    cmdInsertDocu.Parameters["@user_ip"].Value = strIp;
                    cmdInsertDocu.Parameters["@date_time"].Value = strDate;
                    cmdInsertDocu.Parameters["@total_amount_text"].Value = strTotalText;
                    cmdInsertDocu.Parameters["@total_amount"].Value = strTotalAmount;
                    cmdInsertDocu.Parameters["@welfair_fee"].Value = strWelfa;
                    cmdInsertDocu.Parameters["@registration_fee"].Value = strRegis;
                    #endregion

                    try
                    {
                        int b;
                        b = objDBTask.insertEditData(cmdInsertDocu);
                        if (b == 1)
                        {
                            string strStatus = "Y";
                            MySqlCommand cmdUpdateLoanServ = new MySqlCommand("Update micro_loan_details set ser_char_sta = '" + strStatus + "' where contra_code = '" + strCCode + "';");
                            int i;
                            i = objDBTask.insertEditData(cmdUpdateLoanServ);

                            lblMsg.Text = "Payment is Succsessfuled.";
                        }
                        else
                        {
                            lblMsg.Text = "Error occurred. Please try again.";
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            grvPayment.DataSource = null;
            grvPayment.DataBind();
            lblTotalPaied.Text = "";
            cmbCityCode.SelectedIndex = 0;
            if (cmbSocietyID.Items.Count > 0)
            {
                cmbSocietyID.Items.Clear();
            }
            pnlPayment.Visible = false;

            
        }

        public static string NumberToText(int number, bool useAnd, bool useArab)
        {
            if (number == 0) return "Zero";

            string and = useAnd ? "and " : ""; // deals with using 'and' separator

            if (number == -2147483648) return "Minus Two Hundred " + and + "Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred " + and + "Forty Eight";

            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "ONE ", "TWO ", "THREE ", "FOUR ", "FIVE ", "SIX ", "SEVEN ", "EIGHT ", "NINE " };
            string[] words1 = { "TEN ", "ELEVEN ", "TWELVE ", "THIRTEEN ", "FOURTEEN ", "FIFTEEN ", "SIXTEEN ", "SEVENTEEN ", "EIGHTEEN ", "NINETEEN " };
            string[] words2 = { "TWENTY ", "THIRTY ", "FOURTY ", "FIFTY ", "SIXTY ", "SEVENTY ", "EIGHTY", "NINETY " };
            string[] words3 = { "THOUSAND ", "LAKH ", "CRORE " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }

            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;

                u = num[i] % 10; // ones 
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens

                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);

                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }

            string temp = sb.ToString().TrimEnd();

            if (useArab && Math.Abs(number) >= 1000000000)
            {
                int index = temp.IndexOf("Hundred Crore");
                if (index > -1) return temp.Substring(0, index) + "Arab" + temp.Substring(index + 13);
                index = temp.IndexOf("Hundred");
                return temp.Substring(0, index) + "Arab" + temp.Substring(index + 7);
            }
            return temp;
        }
    }
}
