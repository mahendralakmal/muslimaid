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
    public partial class Chequ_Print : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strCC = Request.QueryString["CC"];
                if (strCC != null)
                {
                    DataSet dsGetChequData = objDBTask.selectData("select c.amount,c.chq_name,c.day1,c.day2,c.month1,c.month2,c.year1,c.year2,b.nic from chq_date c,micro_basic_detail b where c.contract_code = b.contract_code and c.contract_code = '" + strCC + "' and c.chq_status = 'A';");
                    if (dsGetChequData.Tables[0].Rows.Count > 0)
                    {
                        lblDay1.Text = dsGetChequData.Tables[0].Rows[0]["day1"].ToString();
                        lblDay2.Text = dsGetChequData.Tables[0].Rows[0]["day2"].ToString();
                        lblMonth1.Text = dsGetChequData.Tables[0].Rows[0]["month1"].ToString();
                        lblMonth2.Text = dsGetChequData.Tables[0].Rows[0]["month2"].ToString();
                        lblYear1.Text = dsGetChequData.Tables[0].Rows[0]["year1"].ToString();
                        lblYear2.Text = dsGetChequData.Tables[0].Rows[0]["year2"].ToString();

                        string strName = dsGetChequData.Tables[0].Rows[0]["chq_name"].ToString();
                        string strNIC = dsGetChequData.Tables[0].Rows[0]["nic"].ToString();
                        lblName.Text = strName + " " + strNIC;
                        string strAmount = dsGetChequData.Tables[0].Rows[0]["amount"].ToString();
                        decimal decAmount = Convert.ToDecimal(strAmount);
                        int intAmount = Convert.ToInt32(decAmount);
                        string strAmountText = NumberToText(intAmount, true, false);

                        lblAmount.Text = Convert.ToDecimal(strAmount).ToString("#,##0.00");
                        lblAmountText.Text = strAmountText;
                        
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
