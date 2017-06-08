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
//using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;

namespace MuslimAID.SALAM
{
    public partial class VoucherPrint : System.Web.UI.Page
    {
        cls_Connection objDBTask = new cls_Connection();

        public void GetToGrid(string contractcode)
        {
            try
            {
                String query = @"select * from salam_loan_details where contra_code = '" + contractcode + "' ";
                DataSet ds1 = cls_Connection.getDataSet(query);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DataSet dsVoucher = GetPaymentVoucherDtl(contractcode);
                    if (dsVoucher.Tables[0].Rows.Count > 0)
                    {
                        lblComName.Text = " MUSLIM AID MICRO CREDIT (GUARANTEE) LIMITED ";
                        lblAddress.Text = "No: 22, School Lane, Nawala Road, Rajagiriya, Sri Lanka.";
                        lblTitle.Text = "Payment Voucher";

                        lblPaidTo.Text = dsVoucher.Tables[0].Rows[0]["CusName"].ToString() + " - " + dsVoucher.Tables[0].Rows[0]["ca_code"].ToString();
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
                            if (ds.Tables[0].Rows[0]["isPrint"].ToString() == "0")
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
                                dr["Description"] = ds.Tables[0].Rows[0]["Description1"].ToString();
                                dr["Amount"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["Amount"]).ToString("#,##0.00");
                                dt.Rows.Add(dr);

                                dr = dt.NewRow();
                                dr["ChequeNo"] = "";
                                dr["FacilityNo"] = "";
                                dr["Description"] = ds.Tables[0].Rows[0]["Description"].ToString();
                                dr["Amount"] = "";
                                dt.Rows.Add(dr);

                                dr = dt.NewRow();
                                dr["ChequeNo"] = "";
                                dr["FacilityNo"] = "";
                                dr["Description"] = "";
                                dr["Amount"] = "";
                                dt.Rows.Add(dr);

                                dr = dt.NewRow();
                                dr["ChequeNo"] = "";
                                dr["FacilityNo"] = "";
                                dr["Description"] = NumberToText(Convert.ToInt32(ds.Tables[0].Rows[0]["Amount"]), true, false) + "  Only";
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
                                dr1["p6"] = "Bank Acc. No & Bank Name";
                                dt1.Rows.Add(dr1);

                                dr1 = dt1.NewRow();
                                dr1["p1"] = "";
                                dr1["p2"] = "";
                                dr1["p3"] = "";
                                dr1["p4"] = "";
                                dr1["p5"] = "                                                   ";
                                dr1["p6"] = dsVoucher.Tables[0].Rows[0]["BankName"].ToString() + " " + dsVoucher.Tables[0].Rows[0]["AccountNo"].ToString();
                                dt1.Rows.Add(dr1);

                                grdApproval.DataSource = dt1;
                                grdApproval.DataBind();
                                grdApproval.Rows[0].Font.Bold = true;

                                pnlVoucher.Visible = true;
                                btnPrint.Visible = true;
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
                    lblMsg.Text = "Invalid Facility Code";
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "Invalid Facility Code";
            }
        }

        public DataSet GetPaymentVoucherDtl(string contractcode)
        {
            try
            {
                String query = @"SELECT V.voucher_no AS VoucherNo, NOW() AS PaymentDate, L.contra_code AS CustomerCode, D.nic AS NIC, D.initial_name AS CusName, L.chequ_no AS ChequeNo, 
	                                L.contra_code AS FacilityNo, 'Weekly Loan  ' AS Description1, concat(village,' - ',c.center_name, ' - Group ',team_id)  AS Description, L.chequ_amount AS Amount
                                    ,L.created_user_nic AS PreparedBy, '' AS CheckedBy, '' AS AuthorizedBy, loan_approved_user_nic AS ApprovedBy,
                                    acc_number AS BankAccNo,bank_name AS BankName,r.AccountNo,V.isPrint, D.ca_code
                            FROM 	salam_loan_details AS L LEFT OUTER JOIN salam_basic_detail D ON L.contra_code = D.contract_code
	                                INNER JOIN salam_voucher_print V ON L.contra_code = V.contract_code
                                    inner join chequebook_registry r on r.cheq_no = l.chequ_no
                                    left outer join center_details c on d.society_id = c.idcenter_details and d.city_code = c.city_code
                            WHERE  	L.contra_code = '" + contractcode + "' AND V.status = 1 and isPrint = 0 AND L.chequ_no != '' ;";
                DataSet ds = cls_Connection.getDataSet(query);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Clear()
        {
            lblMsg.Text = "";
            pnlVoucher.Visible = false;
            lblComName.Text = "";
            lblAddress.Text = "";
            lblTitle.Text = "";
            lblPaidTo.Text = "";
            lblVoucherNo.Text = "";
            lblNIC.Text = "";
            lblDate.Text = "";
            lblUserID.Text = "";
        }

        private void LoadVoucher(string contractcode)
        {
            // Retrieve the row that contains the button
            // from the Rows collection.
            try
            {
                DataSet dsVoucher = GetPaymentVoucherDtl(contractcode);
                if (dsVoucher.Tables[0].Rows.Count > 0)
                {
                    btnPrint.Visible = false;
                    try
                    {
                        MySqlCommand cmdUpdateTarget = new MySqlCommand("UPDATE salam_voucher_print SET isPrint = 1 WHERE contract_code = '" + contractcode + "' AND status = 1 ; ");
                        int o;
                        o = objDBTask.insertEditData(cmdUpdateTarget);
                        GetDate();
                        Clear();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (Session["UserType"] != "Cash Collector" || Session["UserType"] != "Cash Recovery Officer" || Session["UserType"] != "Special Recovery Officer")
                {
                    if (!this.IsPostBack)
                    {
                        string strBranch = Session["Branch"].ToString();
                        string strUserType = Session["UserType"].ToString();

                        DataSet dsBranch;
                        MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                        dsBranch = cls_Connection.selectDataSet(cmdBranch);
                        cmbBranch.Items.Add("");
                        for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                        {
                            cmbBranch.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                            cmbBranch.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                        }

                        DataSet dsCenter = new DataSet();
                        if (strUserType == "Top Management")
                        {
                            dsCenter = cls_Connection.getDataSet("select idcenter_details,center_name,villages from center_details ORDER BY idcenter_details asc");
                        }
                        else
                        {
                            dsCenter = cls_Connection.getDataSet("select idcenter_details,center_name,villages from center_details where city_code = '" + strBranch + "' ORDER BY idcenter_details asc");
                        }

                        Clear();
                        btnPrint.Visible = false;
                    }
                }
                else { Response.Redirect("salam.aspx"); }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            if (txtContraCode.Text != "")
            {
                grdVoucherBody.DataSource = null;
                grdVoucherBody.DataBind();
                GetToGrid(txtContraCode.Text);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtContraCode.Text != "")
            {
                LoadVoucher(txtContraCode.Text);
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

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdSocietyNo.Items.Count > 0)
            {
                cmdSocietyNo.Items.Clear();
            }

            DataSet dsCenter = new DataSet();
            string strBranchh = cmbBranch.SelectedItem.Value;
            dsCenter = cls_Connection.getDataSet("select idcenter_details,center_name,villages from center_details where city_code = '" + strBranchh + "' ORDER BY idcenter_details asc");

            //dsCenter = cls_Connection.getDataSet(cmdCenter);
            cmdSocietyNo.Items.Add("");

            for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
            {
                cmdSocietyNo.Items.Add(dsCenter.Tables[0].Rows[i]["center_name"] + "] - " + dsCenter.Tables[0].Rows[i]["villages"].ToString());
                cmdSocietyNo.Items[i + 1].Value = dsCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
            }
        }

        protected void GetDate()
        {
            try
            {
                string strBranch = Session["Branch"].ToString();
                string strUserType = Session["UserType"].ToString();

                DataSet dsLD = new DataSet();
                grvChequAppr.DataSource = null;
                grvChequAppr.DataBind();
                if (strUserType == "Top Management")
                {
                    if (cmdSocietyNo.SelectedIndex == 0)
                    {
                        dsLD = cls_Connection.getDataSet("select l.contra_code,b.initial_name,l.chequ_no,l.loan_amount,l.interest_amount,l.period from salam_loan_details l, salam_basic_detail b, salam_voucher_print v where b.contract_code = v.contract_code and v.isPrint = 0 and l.contra_code = b.contract_code and l.loan_approved = 'Y' and l.chequ_no is not null and l.loan_sta = 'P' and b.city_code = '" + strBranch + "' v.`status` = 1 order by l.chequ_no ;");
                    }
                    else
                    {
                        strBranch = cmbBranch.SelectedValue.ToString();
                        string strSoNo = cmdSocietyNo.SelectedItem.Value;

                        dsLD = cls_Connection.getDataSet("select l.contra_code,d.initial_name,l.chequ_no,l.loan_amount,l.interest_amount,l.period from salam_loan_details l,salam_basic_detail d, salam_voucher_print v where d.contract_code = v.contract_code and v.isPrint = 0 and l.contra_code = d.contract_code and l.loan_approved = 'Y' and l.chequ_no is not null and l.loan_sta = 'P' and d.society_id = '" + strSoNo + "' and d.city_code = '" + strBranch + "' and v.`status` = 1 order by l.chequ_no ;");
                    }
                }
                else
                {
                    strBranch = cmbBranch.SelectedValue.ToString();
                    string strSoNo = cmdSocietyNo.SelectedItem.Value;
                    if (cmdSocietyNo.SelectedIndex == 0)
                    {
                        dsLD = cls_Connection.getDataSet("select l.contra_code,l.loan_amount,l.interest_amount,l.period from salam_loan_details l, salam_basic_detail b, salam_voucher_print v where b.contract_code = v.contract_code and v.isPrint = 0 and l.contra_code = b.contract_code and l.loan_approved = 'Y' and l.chequ_no is not null and l.loan_sta = 'P' and d.society_id = '" + strSoNo + "' and d.city_code = '" + strBranch + "' and v.`status` = 1 order by l.chequ_no ;");
                    }
                    else
                    {
                        dsLD = cls_Connection.getDataSet("select l.contra_code,l.loan_amount,l.interest_amount,l.period from salam_loan_details l,salam_basic_detail d, salam_voucher_print v where d.contract_code = v.contract_code and v.isPrint = 0 and l.contra_code = d.contract_code and l.loan_approved = 'Y' and l.chequ_no is not null and l.loan_sta = 'P' and d.society_id = '" + strSoNo + "' and d.city_code = '" + strBranch + "' and v.`status` = 1 order by l.chequ_no ;");
                    }
                }

                if (dsLD.Tables[0].Rows.Count > 0)
                {
                    grvChequAppr.DataSource = dsLD;
                    grvChequAppr.DataBind();
                }
                else
                {
                    lblMsg.Text = "No records found for your search criteria. Please try again.";
                }
            }
            catch (Exception)
            {
                grvChequAppr.DataSource = null;
                grvChequAppr.DataBind();
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            grvChequAppr.DataSource = null;
            grvChequAppr.DataBind();
            GetDate();
        }

        protected void grvChequAppr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            { // Retrieve the row index stored in the // CommandArgument property. 
                int index = Convert.ToInt32(e.CommandArgument);
                int x = grvChequAppr.PageIndex;
                LoadTexboxes(x * 10 + index);
            }
        }

        private void LoadTexboxes(int index)
        {
            try
            {
                int No;
                // Retrieve the row that contains the button
                // from the Rows collection.
                string strBranch = cmbBranch.SelectedValue.ToString();
                string strSoNo = cmdSocietyNo.SelectedItem.Value;
                DataSet ds = cls_Connection.getDataSet("select l.contra_code,l.loan_amount,l.interest_amount,l.period from salam_loan_details l, salam_basic_detail b, salam_voucher_print v where b.contract_code = v.contract_code and v.isPrint = 0 and status = 1 and l.contra_code = b.contract_code and l.loan_approved = 'Y' and l.chequ_no is not null and l.loan_sta = 'P' and b.society_id = '" + strSoNo + "' and b.city_code = '" + strBranch + "' order by l.chequ_no ;");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtContraCode.Text = ds.Tables[0].Rows[index]["contra_code"].ToString();
                    if (txtContraCode.Text != "")
                    {
                        grdVoucherBody.DataSource = null;
                        grdVoucherBody.DataBind();
                        GetToGrid(txtContraCode.Text);
                    }
                }
                //  to add the item to text boxes. 
            }
            catch (Exception)
            {
            }
        }
    }
}
