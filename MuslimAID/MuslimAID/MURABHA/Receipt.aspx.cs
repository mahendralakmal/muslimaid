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
    public partial class Receipt : System.Web.UI.Page
    {
        CommonTasks objCommonTask = new CommonTasks();
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                //string strCC = Request.QueryString["CC"].ToString();
                //string strAmou = Request.QueryString["Amou"].ToString();
                //string strCC = Session["contraCode"].ToString();
                //string strAmou = Session["amount"].ToString();
                string strRecNo = Session["recno"].ToString();
                DataSet dsGetRecDeta = objDBTask.selectData("select p.contra_code,p.paied_amount,p.date_time,u.first_name from micro_pais_history p, users u where p.idpais_history = '" + strRecNo + "' and p.tra_description = 'WI' and p.user_nic = u.nic;");
                if (dsGetRecDeta.Tables[0].Rows.Count > 0)
                {
                    string strCC = dsGetRecDeta.Tables[0].Rows[0]["contra_code"].ToString();
                    string strAmou = dsGetRecDeta.Tables[0].Rows[0]["paied_amount"].ToString();
                    lblDate.Text = dsGetRecDeta.Tables[0].Rows[0]["date_time"].ToString();
                    lblTotal.Text = strAmou;
                    lblCasName.Text = dsGetRecDeta.Tables[0].Rows[0]["first_name"].ToString();

                    if (strCC != "" && strAmou != "")
                    {
                        DataSet dsREc = objDBTask.selectData("select c.nic,c.initial_name,c.p_address,b.b_name,l.current_loan_amount,l.due_date,l.arres_amou from micro_basic_detail c, branch b, micro_loan_details l where c.city_code = b.b_code and l.contra_code = c.contract_code and l.contra_code = '" + strCC + "';");
                        if (dsREc.Tables[0].Rows.Count > 0)
                        {
                            lblNIC.Text = dsREc.Tables[0].Rows[0]["nic"].ToString();
                            lblName.Text = dsREc.Tables[0].Rows[0]["initial_name"].ToString();
                            lblAddrss.Text = dsREc.Tables[0].Rows[0]["p_address"].ToString();
                            lblCenter.Text = dsREc.Tables[0].Rows[0]["b_name"].ToString();

                            lblFullBal.Text = dsREc.Tables[0].Rows[0]["current_loan_amount"].ToString();
                            lblDueDa.Text = dsREc.Tables[0].Rows[0]["due_date"].ToString();
                            lblArrears.Text = dsREc.Tables[0].Rows[0]["arres_amou"].ToString();

                            lblContrNo.Text = strCC;
                            //decimal decAmou = Convert.ToDecimal(strAmou);
                            lblAmou.Text = strAmou;
                            //Amount in Word
                            double d = Convert.ToDouble(strAmou);
                            decimal dec = Convert.ToDecimal(strAmou);
                            int i = (int)dec;
                            string decimalPart = dec.ToString().Split('.')[1];
                            if (decimalPart == "00")
                            {
                                string text = NumberToText(i, true, false) + " RUPEES ONLY.";
                                lblAmouText.Text = text;
                            }
                            else
                            {
                                int decimalone = Convert.ToInt32(decimalPart);
                                string text = NumberToText(i, true, false) + " RUPEES & " + NumberToText(decimalone, true, false) + " CENTS ONLY.";
                                //Console.WriteLine(text);
                                //Console.ReadKey();
                                lblAmouText.Text = text;
                            }

                            lblRecNo.Text = strRecNo;

                            string print = @"<script type='text/javascript'>
                                 window.print();
                                window.close();
                                </script>";
                            base.Response.Write(print);
                            Session.Remove("recno");
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ppUp", "prnt();", true);
                            //Response.Redirect("Paied.aspx");
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
