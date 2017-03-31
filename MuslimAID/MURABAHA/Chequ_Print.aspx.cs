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

namespace MuslimAID.MURABHA
{
    public partial class Chequ_Print : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        string strRootID, strCityCode, strRID, strSoNumber, strLDMonInsto, strLast_date, strTotal_arrears, strTotal_amount, strLoan_granted, strLoan_granted_date, strRepayment_term;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strCC = Request.QueryString["CC"];
                if (strCC != null)
                {
                    DataSet dsGetChequData = cls_Connection.getDataSet("select c.amount,c.chq_name,c.day1,c.day2,c.month1,c.month2,c.year1,c.year2,b.nic from chq_date c,micro_basic_detail b where c.contract_code = b.contract_code and c.contract_code = '" + strCC + "' and c.chq_status = 'A';");
                    if (dsGetChequData.Tables[0].Rows.Count > 0)
                    {
                        lblDay1.Text = dsGetChequData.Tables[0].Rows[0]["day1"].ToString();
                        lblDay2.Text = dsGetChequData.Tables[0].Rows[0]["day2"].ToString();
                        lblMonth1.Text = dsGetChequData.Tables[0].Rows[0]["month1"].ToString();
                        lblMonth2.Text = dsGetChequData.Tables[0].Rows[0]["month2"].ToString();
                        lblYear1.Text = dsGetChequData.Tables[0].Rows[0]["year1"].ToString();
                        lblYear2.Text = dsGetChequData.Tables[0].Rows[0]["year2"].ToString();

                        string strName = dsGetChequData.Tables[0].Rows[0]["chq_name"].ToString();
                        string strNIC = "";// dsGetChequData.Tables[0].Rows[0]["nic"].ToString();
                        lblName.Text = strName + " " + " " + " " + strNIC;
                        string strAmount = dsGetChequData.Tables[0].Rows[0]["amount"].ToString();
                        decimal decAmount = Convert.ToDecimal(strAmount);
                        int intAmount = Convert.ToInt32(decAmount);
                        string strAmountText = NumberToText(intAmount, true, false);

                        lblAmount.Text = Convert.ToDecimal(strAmount).ToString("#,##0.00");
                        lblAmountText.Text = strAmountText;

                        //Save Transaction to POS/////////////////////////////////////////////////////////////////
                        #region SaveTransactiontoPOS

                        DataSet dsData = cls_Connection.getDataSet("select contract_code,initial_name,society_id,city_code,p_address,mobile_no,nic,root_id from micro_basic_detail where contract_code = '" + strCC + "';");
                        if (dsData.Tables[0].Rows.Count > 0)
                        {
                            strRootID = dsData.Tables[0].Rows[0]["root_id"].ToString();
                            strCityCode = dsData.Tables[0].Rows[0]["city_code"].ToString();
                            DataSet dsGetRoot = cls_Connection.getDataSet("select idrbf_exective_root from micro_exective_root where exe_id = '" + strRootID + "' and branch_code = '" + strCityCode + "' ;");
                            if (dsGetRoot.Tables[0].Rows.Count > 0)
                            {
                                strRID = dsGetRoot.Tables[0].Rows[0][0].ToString();
                            }
                            DataSet dsData1 = cls_Connection.getDataSet("select * from micro_loan_details where contra_code = '" + strCC + "';");
                            if (dsData1.Tables[0].Rows.Count > 0)
                            {
                                strLDMonInsto = dsData1.Tables[0].Rows[0]["monthly_instollment"].ToString();
                                strLast_date = dsData1.Tables[0].Rows[0]["loan_approved_on"].ToString();
                                strTotal_arrears = dsData1.Tables[0].Rows[0]["arres_amou"].ToString();
                                strTotal_amount = dsData1.Tables[0].Rows[0]["current_loan_amount"].ToString();
                                strLoan_granted = dsData1.Tables[0].Rows[0]["loan_amount"].ToString();
                                strLoan_granted_date = dsData1.Tables[0].Rows[0]["loan_approved_on"].ToString();
                                strRepayment_term = dsData1.Tables[0].Rows[0]["period"].ToString();
                            }
                        }

                        #endregion
                        ////////////////////////////////////////////////////////////////////////////////////////

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
                else
                {
                    string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                    base.Response.Write(close);
                }
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
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
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Fourty ", "Fifty ", "Sixty ", "Seventy ", "Eighty", "Ninety " };
            string[] words3 = { "Thousand ", "Hundred Thousand ", "Crore " };
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
