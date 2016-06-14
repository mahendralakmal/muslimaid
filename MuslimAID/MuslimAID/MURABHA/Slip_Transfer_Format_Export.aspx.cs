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
using System.IO;
using System.Globalization;
using System.Drawing;

namespace LoanSystem.Micro
{
    public partial class Slip_Transfer_Format_Export : System.Web.UI.Page
    {
        DBTasks objDBTask = new DBTasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    string strUserType = Session["UserType"].ToString();
                    if (strUserType == "Top Managment")
                    {
                        DataSet dsCenter = objDBTask.selectData("select transfer_id,date_time from micro_slip_transfer_id ORDER BY idmicro_slip_transfer_id asc");

                        //dsCenter = objDBTask.selectData(cmdCenter);
                        cmbTransfer.Items.Add("");

                        for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                        {
                            cmbTransfer.Items.Add("[" + dsCenter.Tables[0].Rows[i]["transfer_id"] + "] - " + dsCenter.Tables[0].Rows[i]["date_time"].ToString());
                            cmbTransfer.Items[i + 1].Value = dsCenter.Tables[0].Rows[i]["transfer_id"].ToString();

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
                    //GetSearch();
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

        protected void GetSearch()
        {
            string strNewTransferID = cmbTransfer.SelectedItem.Value;

            if (strNewTransferID != "")
            {
                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = "SELECT l.chequ_amount,l.acc_name,l.acc_number,l.bank_code,l.branch_code,s.bank_code,s.branch_code,s.acc_no FROM micro_loan_details l,micro_slip_transfer s where l.contra_code = s.contra_code and l.loan_approved = 'Y' and l.bank_code != '' and l.ser_char_sta = 'Y' and s.transfer_id = '" + strNewTransferID + "'";
                string strQRY = hstrSelectQuery.Value;
                DataSet dsGetArre = objDBTask.selectData(strQRY);

                if (dsGetArre.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    DataRow dr;

                    dt.Columns.Add("1");
                    dt.Columns.Add("2");
                    dt.Columns.Add("3");
                    dt.Columns.Add("4");
                    dt.Columns.Add("5");
                    dt.Columns.Add("6");
                    dt.Columns.Add("7");
                    dt.Columns.Add("8");
                    dt.Columns.Add("9");
                    dt.Columns.Add("10");
                    dt.Columns.Add("11");
                    dt.Columns.Add("12");
                    dt.Columns.Add("13");
                    dt.Columns.Add("14");
                    dt.Columns.Add("15");
                    dt.Columns.Add("16");
                    dt.Columns.Add("17");

                    //int k = 0;
                    //decimal decAAmount = 0;

                    for (int i = 0; i < dsGetArre.Tables[0].Rows.Count; i++)
                    {
                        string strChqAmount = dsGetArre.Tables[0].Rows[i][0].ToString();
                        string strAccName = dsGetArre.Tables[0].Rows[i][1].ToString();
                        string strCusAccNo = dsGetArre.Tables[0].Rows[i][2].ToString();
                        string strCusBankCode = dsGetArre.Tables[0].Rows[i][3].ToString();
                        string strCusBranchCode = dsGetArre.Tables[0].Rows[i][4].ToString();
                        string strOurBankCode = dsGetArre.Tables[0].Rows[i][5].ToString();
                        string strOurBranchCode = dsGetArre.Tables[0].Rows[i][6].ToString();
                        string strOurAccNo = dsGetArre.Tables[0].Rows[i][7].ToString();

                        decimal decLAmount = Convert.ToDecimal(strChqAmount);
                        var Balance = decLAmount.ToString(CultureInfo.InvariantCulture).Split('.');
                        int FirstValue = int.Parse(Balance[0]);
                        int ScondValue = int.Parse(Balance[1]);
                        string strFirstValue = Convert.ToString(FirstValue);
                        string strSecondValue = "00";
                        if (ScondValue != 0)
                        {
                            strSecondValue = Convert.ToString(ScondValue);
                        }
                        string strFullValue = strFirstValue + strSecondValue;
                        //---Acc No ---------------------------------------------
                        int intAccNoCount = strCusAccNo.Length;
                        if (intAccNoCount == 15)
                        {
                            strCusAccNo = strCusAccNo.Substring(3, 12);
                        }
                        else if (intAccNoCount == 14)
                        {
                            strCusAccNo = strCusAccNo.Substring(2, 12);
                        }
                        else if (intAccNoCount == 13)
                        {
                            strCusAccNo = strCusAccNo.Substring(1, 12);
                        }
                        else if (intAccNoCount == 4)
                        {
                            strCusAccNo = "00000000" + strCusAccNo;
                        }
                        else if (intAccNoCount == 5)
                        {
                            strCusAccNo = "0000000" + strCusAccNo;
                        }
                        else if (intAccNoCount == 6)
                        {
                            strCusAccNo = "000000" + strCusAccNo;
                        }
                        else if (intAccNoCount == 7)
                        {
                            strCusAccNo = "00000" + strCusAccNo;
                        }
                        else if (intAccNoCount == 8)
                        {
                            strCusAccNo = "0000" + strCusAccNo;
                        }
                        else if (intAccNoCount == 9)
                        {
                            strCusAccNo = "000" + strCusAccNo;
                        }
                        else if (intAccNoCount == 10)
                        {
                            strCusAccNo = "00" + strCusAccNo;
                        }
                        else if (intAccNoCount == 11)
                        {
                            strCusAccNo = "0" + strCusAccNo;
                        }

                        //--LA------------------------------------------------------------------
                        int intChqAmount = strFullValue.Length;
                        if (intChqAmount == 6)
                        {
                            strFullValue = "000000" + strFullValue;
                        }
                        else if (intChqAmount == 7)
                        {
                            strFullValue = "00000" + strFullValue;
                        }
                        else if (intChqAmount == 8)
                        {
                            strFullValue = "0000" + strFullValue;
                        }
                        else if (intChqAmount == 9)
                        {
                            strFullValue = "000" + strFullValue;
                        }
                        else if (intChqAmount == 10)
                        {
                            strFullValue = "00" + strFullValue;
                        }
                        else if (intChqAmount == 11)
                        {
                            strFullValue = "0" + strFullValue;
                        }
                        //--Our Acc No------------------------------------------------------------------
                        int intOurAccNo = strOurAccNo.Length;
                        if (intOurAccNo == 8)
                        {
                            strOurAccNo = "0000" + strOurAccNo;
                        }
                        else if (intOurAccNo == 9)
                        {
                            strOurAccNo = "000" + strOurAccNo;
                        }
                        else if (intOurAccNo == 10)
                        {
                            strOurAccNo = "00" + strOurAccNo;
                        }
                        else if (intOurAccNo == 11)
                        {
                            strOurAccNo = "0" + strOurAccNo;
                        }

                        //--Cus Branch Code------------------------------------------------------------------
                        int intCusBranCode = strCusBranchCode.Length;
                        if (intCusBranCode == 1)
                        {
                            strCusBranchCode = "00" + strCusBranchCode;
                        }
                        else if (intCusBranCode == 2)
                        {
                            strCusBranchCode = "0" + strCusBranchCode;
                        }

                        //--Our Branch Code------------------------------------------------------------------
                        int intOurBranCode = strOurBranchCode.Length;
                        if (intOurBranCode == 1)
                        {
                            strOurBranchCode = "00" + strOurBranchCode;
                        }
                        else if (intOurBranCode == 2)
                        {
                            strOurBranchCode = "0" + strOurBranchCode;
                        }

                        //Date
                        string strYear = DateTime.Now.ToString("yy");
                        string strMonth = DateTime.Now.ToString("MM");
                        string strDate = DateTime.Now.ToString("dd");


                        dr = dt.NewRow();
                        dr["1"] = "0000";
                        dr["2"] = strCusBankCode;
                        dr["3"] = strCusBranchCode;
                        dr["4"] = strCusAccNo;
                        dr["5"] = strAccName;
                        dr["6"] = "52";
                        dr["7"] = "00000000";
                        dr["8"] = strFullValue;
                        dr["9"] = "SLR";
                        dr["10"] = strOurBankCode;
                        dr["11"] = strOurBranchCode;
                        dr["12"] = strOurAccNo;
                        dr["13"] = "M/S PROSPEROUS CAPITAL & Assurance (Pvt) Ltd";
                        dr["14"] = "LOAN";
                        dr["15"] = DateTime.Now.ToString("MMMM");
                        dr["16"] = strYear + strMonth + strDate;
                        dr["17"] = "000000";
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }

                    pnlARep.Visible = true;
                    btnExport.Enabled = true;
                    grvArRep.DataSource = dt;
                    grvArRep.DataBind();

                    btnSearch.Enabled = true;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbTransfer.SelectedIndex != 0)
            {
                grvArRep.DataSource = null;
                grvArRep.DataBind();

                GetSearch();
            }
            else
            {
                pnlARep.Visible = false;
                btnSearch.Enabled = false;
                btnExport.Enabled = false;
                grvArRep.DataSource = null;
                grvArRep.DataBind();
            }
        }

        protected void cmbTransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransfer.SelectedIndex != 0)
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
                btnExport.Enabled = false;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            exportExcel();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void exportExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                //grvCenDeta.AllowPaging = false;
                //this.BindGrid();

                grvArRep.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grvArRep.HeaderRow.Cells)
                {
                    cell.BackColor = grvArRep.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grvArRep.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grvArRep.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grvArRep.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grvArRep.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
}
