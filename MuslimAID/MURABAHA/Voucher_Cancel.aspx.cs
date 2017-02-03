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
//using CrystalDecisions.CrystalReports.Engine;

namespace MuslimAID.MURABAHA
{
    public partial class Voucher_Cancel : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                lblMsg.Text = "";
                pnlVoucher.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnPeied_Click(object sender, EventArgs e)
        {
            SaveVoucherCancel();
        }

        protected void Clear()
        {
            lblAmount.Text = "";
            lblContractCode.Text = "";
            lblName.Text = "";
            lblNIC.Text = "";
            txtComment.Text = "";
        }

        private void ExistVoucher()
        {
            lblMsg.Text = "";
            Clear();
            if (txtRNo.Text.Trim() != "")
            {
                string strRNo = txtRNo.Text.Trim();
                DataSet dsCD = cls_Connection.getDataSet("select c.contract_code,c.nic,c.initial_name,l.loan_amount AS paied_amount from micro_voucher_print h inner join micro_basic_detail c on c.contract_code = h.contract_code inner join micro_loan_details l on c.contract_code = l.contra_code where h.status = 1 and h.voucher_no = '" + strRNo + "';");
                if (dsCD.Tables[0].Rows.Count > 0)
                {
                    lblAmount.Text = dsCD.Tables[0].Rows[0]["paied_amount"].ToString();
                    lblContractCode.Text = dsCD.Tables[0].Rows[0]["contract_code"].ToString();
                    lblNIC.Text = dsCD.Tables[0].Rows[0]["nic"].ToString();
                    lblName.Text = dsCD.Tables[0].Rows[0]["initial_name"].ToString();
                    //lblType.Text = dsCD.Tables[0].Rows[0]["payment_type"].ToString();

                    btnPeied.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "No Record Found.";
                    btnPeied.Enabled = false;
                }
            }
            else
            {
                lblMsg.Text = "Please enter Receipt No.";
                btnPeied.Enabled = false;
            }
        }

        public DataSet GetPaymentVoucherDtl(string contractcode)
        {
            try
            {
                String query = @"SELECT V.voucher_no AS VoucherNo, NOW() AS PaymentDate, L.contra_code AS CustomerCode, D.nic AS NIC, D.initial_name AS CusName, L.chequ_no AS ChequeNo, 
	                                L.contra_code AS FacilityNo, concat('Weekly Loan Type, ', village, ' & Group ',team_id)  AS Description, L.chequ_amount AS Amount
                                    ,L.created_user_nic AS PreparedBy, '' AS CheckedBy, '' AS AuthorizedBy, loan_approved_user_nic AS ApprovedBy,
                                    acc_number AS BankAccNo,bank_name AS BankName,V.isPrint
                            FROM 	micro_loan_details AS L LEFT OUTER JOIN micro_basic_detail D ON L.contra_code = D.contract_code
	                                INNER JOIN micro_voucher_print V ON L.contra_code = V.contract_code
                            WHERE  	L.contra_code = '" + contractcode + "'  ;";
                DataSet ds = cls_Connection.getDataSet(query);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected void txtRNo_TextChanged(object sender, EventArgs e)
        {
            ExistVoucher();
        }

        private void SaveVoucherCancel()
        {
            lblMsg.Text = "";
            if (txtRNo.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Contract No.";
            }
            else if (lblAmount.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Amount.";
            }
            else if (lblContractCode.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Contract Code.";
            }
            else if (lblName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Name.";
            }
            else if (lblNIC.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter NIC.";
            }
            else if (txtComment.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Comment.";
            }
            else
            {
                string strRNo = txtRNo.Text.Trim();
                string strCCode = lblContractCode.Text.Trim();
                string strAmount = lblAmount.Text.Trim();
                decimal decAmou = Convert.ToDecimal(strAmount);
                string strComment = txtComment.Text.Trim();

                string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strIp = Request.UserHostAddress;
                string strloginID = Session["NIC"].ToString();

                MySqlCommand cmdVoucherCansel = new MySqlCommand("Update micro_voucher_print set status = 0,DescriptionCancel = '" + strComment + "',cancel_date = '" + strDate + "',cancel_user = '" + strloginID + "' where contract_code = '" + strCCode + "' AND status = 1 ;");
                try
                {
                    int f;
                    f = objDBTask.insertEditData(cmdVoucherCansel);
                    if (f == 1)
                    {
                        lblMsg.Text = "Voucher is Cancel.";
                        btnPeied.Enabled = false;
                        GetToGrid(strCCode);
                        Clear();
                        txtRNo.Text = "";
                    }
                    else
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void GetToGrid(string contractcode)
        {
            try
            {
                String query = @"SELECT * FROM micro_loan_details WHERE contra_code = '" + contractcode + "' ";
                DataSet ds1 = cls_Connection.getDataSet(query);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DataSet dsVoucher = GetPaymentVoucherDtl(contractcode);
                    if (dsVoucher.Tables[0].Rows.Count > 0)
                    {
                        lblComName.Text = "PRO IT Solutions";
                        lblAddress.Text = "No: 485/7A, Gunawardana Mawatha, Wijerama, Gangodawila, Nugegoda.";
                        lblTitle.Text = "Cancel Payment Voucher";

                        lblPaidTo.Text = dsVoucher.Tables[0].Rows[0]["CustomerCode"].ToString() + " " + dsVoucher.Tables[0].Rows[0]["CusName"].ToString();
                        lblVoucherNo.Text = dsVoucher.Tables[0].Rows[0]["VoucherNo"].ToString();
                        lblNIC.Text = dsVoucher.Tables[0].Rows[0]["NIC"].ToString();
                        lblDate.Text = dsVoucher.Tables[0].Rows[0]["PaymentDate"].ToString();
                        lblUserID.Text = Session["NIC"].ToString(); ;

                        DataTable dt = new DataTable();
                        DataColumn pChequeNo = new DataColumn("ChequeNo", Type.GetType("System.String"));
                        DataColumn pFacilityNo = new DataColumn("FacilityNo", Type.GetType("System.String"));
                        DataColumn pDescription = new DataColumn("Description", Type.GetType("System.String"));
                        DataColumn pAmount = new DataColumn("Amount", Type.GetType("System.String"));

                        dt.Columns.Add(pChequeNo);
                        dt.Columns.Add(pFacilityNo);
                        dt.Columns.Add(pDescription);
                        dt.Columns.Add(pAmount);

                        DataTable dt1 = new DataTable();
                        DataColumn p1 = new DataColumn("p1", Type.GetType("System.String"));
                        DataColumn p2 = new DataColumn("p2", Type.GetType("System.String"));
                        DataColumn p3 = new DataColumn("p3", Type.GetType("System.String"));
                        DataColumn p4 = new DataColumn("p4", Type.GetType("System.String"));
                        DataColumn p5 = new DataColumn("p5", Type.GetType("System.String"));
                        DataColumn p6 = new DataColumn("p6", Type.GetType("System.String"));

                        dt1.Columns.Add(p1);
                        dt1.Columns.Add(p2);
                        dt1.Columns.Add(p3);
                        dt1.Columns.Add(p4);
                        dt1.Columns.Add(p5);
                        dt1.Columns.Add(p6);

                        DataSet ds = dsVoucher;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["isPrint"].ToString() == "1")
                            {
                                DataRow dr;
                                dr = dt.NewRow();
                                dr["ChequeNo"] = "Cheque No";
                                dr["FacilityNo"] = "Facility No";
                                dr["Description"] = "Description";
                                dr["Amount"] = "Amount";
                                dt.Rows.Add(dr);

                                dr = dt.NewRow();
                                dr["ChequeNo"] = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
                                dr["FacilityNo"] = ds.Tables[0].Rows[0]["FacilityNo"].ToString();
                                dr["Description"] = ds.Tables[0].Rows[0]["Description"].ToString();
                                dr["Amount"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["Amount"]).ToString("#,##0.00");
                                dt.Rows.Add(dr);
                                dr = dt.NewRow();
                                dr["ChequeNo"] = "";
                                dr["FacilityNo"] = "";
                                dr["Description"] = NumberToText(Convert.ToInt32(ds.Tables[0].Rows[0]["Amount"]), true, false); ;
                                dr["Amount"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["Amount"]).ToString("#,##0.00");
                                dt.Rows.Add(dr);

                                grdVoucherBody.DataSource = dt;
                                grdVoucherBody.DataBind();
                                grdVoucherBody.Rows[0].Font.Bold = true;

                                DataRow dr1;
                                dr1 = dt1.NewRow();
                                dr1["p1"] = "Prepared By";
                                dr1["p2"] = "Checked By";
                                dr1["p3"] = "Authorized By";
                                dr1["p4"] = "Approved By";
                                dr1["p5"] = "Authorized Signatory";
                                dr1["p6"] = "Bank Account No & Bank Name";
                                dt1.Rows.Add(dr1);

                                dr1 = dt1.NewRow();
                                dr1["p1"] = "";
                                dr1["p2"] = "";
                                dr1["p3"] = "";
                                dr1["p4"] = "";
                                dr1["p5"] = "";
                                dr1["p6"] = dsVoucher.Tables[0].Rows[0]["BankAccNo"].ToString() + " " + dsVoucher.Tables[0].Rows[0]["BankName"].ToString();
                                dt1.Rows.Add(dr1);

                                grdApproval.DataSource = dt1;
                                grdApproval.DataBind();
                                grdApproval.Rows[0].Font.Bold = true;

                                pnlVoucher.Visible = true;
                            }
                            else
                            {
                                Clear();
                                lblMsg.Text = "Cheque Printed";
                            }
                        }
                    }
                    else
                    {
                        Clear();
                        lblMsg.Text = "Approve the Cheque";
                    }
                }
                else
                {
                    Clear();
                    lblMsg.Text = "Invalid Contract Code";
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "Invalid Contract Code";
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

                if (h > 0) sb.Append(words0[h] + "HUNDRED ");
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
                index = temp.IndexOf("HUNDRED");
                return temp.Substring(0, index) + "Arab" + temp.Substring(index + 7);
            }
            return temp;
        }

    }
}
