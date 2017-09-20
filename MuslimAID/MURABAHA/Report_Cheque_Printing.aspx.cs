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
using System.IO;
using System.Drawing;
using System.Globalization;

namespace MuslimAID.MURABHA
{
    public partial class Report_Cheque_Printing : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    DataSet dsBranch;
                    MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                    dsBranch = objDBTask.selectData(cmdBranch);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                        cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            lblChqAmount.Text = "";
            lblChqCount.Text = "";
            grvChqDeta.DataSource = null;
            grvChqDeta.DataBind();
            GetSearch();
        }

        protected void GetSearch()
        {
            try
            {
                lblMsg.Text = "";
                hstrSelectQuery.Value = "";
                hstrSelectQuery.Value = "select d.contract_code,format(d.amount,2) amount,l.chequ_no,d.chq_name,replace(replace(concat(d.day1,'',d.day2,'-',d.month1,'',d.month2,'-','20','',d.year1,'',d.year2), ',,', ','), ',,', ',') chq_date,d.date_time,d.user_nic,root_id,society_id,city_code from chq_date d, micro_basic_detail c, micro_loan_details l where c.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_sta != 'C' and d.chq_status = 'A'";

                if (cmbCityCode.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";
                if (cmbArea.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and c.area_code = '" + cmbArea.SelectedItem.Value.ToString() + "'";
                if (cmbVillage.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and c.village = '" + cmbVillage.SelectedItem.Value.ToString() + "'";
                if (cmbCRO.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and c.root_id = '" + cmbCRO.SelectedItem.Value.ToString() + "'";
                if (cmbVillagr.SelectedIndex > 0)
                    hstrSelectQuery.Value += " and c.society_id = '" + cmbVillagr.SelectedValue.ToString() + "' ";

                if (txtContraCode.Text.Trim() != "")
                    hstrSelectQuery.Value += " and l.contra_code = '" + txtContraCode.Text.Trim() + "'";
                if (txtContraCode.Text.Trim() != "")
                    hstrSelectQuery.Value += " and d.contract_code = '" + txtContraCode.Text.Trim() + "'";
                if (txtChequeNo.Text.Trim() != "" && txtToChequeNo.Text.Trim() != "")
                {
                    DateTime strTo = DateTime.ParseExact(txtDateTo.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    DateTime strStart = DateTime.ParseExact(txtDateFrom.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    hstrSelectQuery.Value += " and l.chequ_no BETWEEN '" + strStart.ToString() + "' and '" + strTo.ToString() + "' ";
                }
                if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                {
                    DateTime strTo = DateTime.ParseExact(txtDateTo.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    DateTime strStart = DateTime.ParseExact(txtDateFrom.Text.Trim(), "d-M-yyyy", CultureInfo.InvariantCulture);
                    hstrSelectQuery.Value += " and c.date_time BETWEEN '" + strStart.ToString("yyyy-MM-dd") + "' and '" + strTo.ToString("yyyy-MM-dd") + "'";
                }



                hstrSelectQuery.Value = hstrSelectQuery.Value + " order by l.chequ_no asc;";
                loadDataToRepeater(hstrSelectQuery.Value);
            }
            catch (Exception)
            {
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

            DataTable dt = new DataTable();
            DataColumn pChequ_no = new DataColumn("chequ_no", Type.GetType("System.String"));
            DataColumn pContract_code = new DataColumn("contract_code", Type.GetType("System.String"));
            DataColumn pAmount = new DataColumn("amount", Type.GetType("System.String"));
            DataColumn pChq_name = new DataColumn("chq_name", Type.GetType("System.String"));
            DataColumn pChq_date = new DataColumn("chq_date", Type.GetType("System.String"));
            DataColumn pDate_time = new DataColumn("date_time", Type.GetType("System.String"));
            DataColumn pUser_nic = new DataColumn("user_nic", Type.GetType("System.String"));
            DataColumn pRoot_id = new DataColumn("root_id", Type.GetType("System.String"));
            DataColumn pSociety_id = new DataColumn("society_id", Type.GetType("System.String"));

            dt.Columns.Add(pChequ_no);
            dt.Columns.Add(pContract_code);
            dt.Columns.Add(pChq_name);
            dt.Columns.Add(pAmount);
            dt.Columns.Add(pChq_date);
            dt.Columns.Add(pDate_time);
            dt.Columns.Add(pUser_nic);
            dt.Columns.Add(pRoot_id);
            dt.Columns.Add(pSociety_id);

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsSelectData.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["chequ_no"] = dsSelectData.Tables[0].Rows[i]["chequ_no"].ToString();
                    dr["contract_code"] = dsSelectData.Tables[0].Rows[i]["contract_code"].ToString();
                    dr["chq_name"] = dsSelectData.Tables[0].Rows[i]["chq_name"].ToString();
                    dr["amount"] = dsSelectData.Tables[0].Rows[i]["amount"].ToString();
                    dr["chq_date"] = dsSelectData.Tables[0].Rows[i]["chq_date"].ToString();
                    dr["date_time"] = dsSelectData.Tables[0].Rows[i]["date_time"].ToString();
                    dr["user_nic"] = dsSelectData.Tables[0].Rows[i]["user_nic"].ToString();
                    dr["society_id"] = CenterName(dsSelectData.Tables[0].Rows[i]["society_id"].ToString(), dsSelectData.Tables[0].Rows[i]["city_code"].ToString());
                    dr["root_id"] = CROName(dsSelectData.Tables[0].Rows[i]["root_id"].ToString(), dsSelectData.Tables[0].Rows[i]["city_code"].ToString());
                    dt.Rows.Add(dr);
                }
                grvChqDeta.DataSource = dt;
                grvChqDeta.DataBind();
            }

            if (dsSelectData.Tables[0].Rows.Count > 0)
            {
                pnlChqDetail.Visible = true;
                string strSummery;
                hstrSelectQuery1.Value = "";
                hstrSelectQuery1.Value = "select count(d.contract_code),sum(d.amount) from chq_date d, micro_basic_detail c, micro_loan_details l where c.contract_code = l.contra_code and l.contra_code = d.contract_code and l.loan_sta != 'C' and d.chq_status = 'A'";

                if (txtContraCode.Text.Trim() != "" || txtDateFrom.Text.Trim() != "" || txtDateTo.Text.Trim() != "" || cmbCityCode.SelectedIndex != 0 || cmbCRO.SelectedIndex != -1 || cmbVillagr.SelectedIndex != -1)
                {
                    if (cmbCityCode.SelectedIndex != 0)
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "'";

                        if (cmbVillagr.SelectedIndex != 0)
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.society_id = '" + cmbVillagr.SelectedValue.ToString() + "'";
                        }
                        if (cmbCRO.SelectedIndex != 0)
                        {
                            hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and c.root_id = '" + cmbCRO.SelectedValue.ToString() + "' ";
                        }
                    }
                    if (txtContraCode.Text.Trim() != "")
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and d.contract_code = '" + txtContraCode.Text.Trim() + "'";
                    }
                    if (txtDateFrom.Text.Trim() != "" && txtDateTo.Text.Trim() != "")
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and (DATE_FORMAT((d.date_time),'%Y-%m-%d')) between '" + txtDateFrom.Text.Trim() + "' and '" + txtDateTo.Text.Trim() + "'";
                    }
                    if (txtChequeNo.Text.Trim() != "" && txtToChequeNo.Text.Trim() != "")
                    {
                        hstrSelectQuery1.Value = hstrSelectQuery1.Value + " and l.chequ_no >= '" + txtChequeNo.Text.Trim() + "' and l.chequ_no <= '" + txtToChequeNo.Text.Trim() + "' ";
                    }
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by l.chequ_no asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblChqCount.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblChqAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
                else
                {
                    hstrSelectQuery1.Value = hstrSelectQuery1.Value + " order by l.chequ_no asc;";
                    strSummery = hstrSelectQuery1.Value;
                    DataSet dsSummery = cls_Connection.getDataSet(strSummery);
                    if (dsSummery.Tables[0].Rows.Count > 0)
                    {
                        lblChqCount.Text = dsSummery.Tables[0].Rows[0][0].ToString();
                        lblChqAmount.Text = Convert.ToDecimal(dsSummery.Tables[0].Rows[0][1].ToString()).ToString("#,##0.00");
                    }
                }
            }
            else
            {
                pnlChqDetail.Visible = false;
                lblMsg.Text = "No records found for your search criteria. Please try again.";
            }
        }

        private string CenterName(string CenterCode, string BranchCode)
        {
            try
            {
                string Center_Name = "";
                string strQRY = "select center_name from center_details where idcenter_details = '" + CenterCode + "' and city_code = '" + BranchCode + "'";
                MySqlCommand cmd = new MySqlCommand(strQRY, cls_Connection.DBConnect());
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                DataSet ds = objDBTask.selectData(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Center_Name = ds.Tables[0].Rows[0]["center_name"].ToString();
                    return Center_Name;
                }
                else
                {
                    return Center_Name;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string CROName(string CROCode, string BranchCode)
        {
            try
            {
                string CRO_Name = "";
                string strQRY = "select exe_name from micro_exective_root where exe_id = '" + CROCode + "' and branch_code = '" + BranchCode + "'";
                MySqlCommand cmd = new MySqlCommand(strQRY, cls_Connection.DBConnect());
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                DataSet ds = objDBTask.selectData(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CRO_Name = ds.Tables[0].Rows[0]["exe_name"].ToString();
                    return CRO_Name;
                }
                else
                {
                    return CRO_Name;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        //Export Excel----------------------------------
        protected void exportExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Cheque_Printing_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages

                    grvChqDeta.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in grvChqDeta.HeaderRow.Cells)
                    {
                        cell.BackColor = grvChqDeta.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in grvChqDeta.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grvChqDeta.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grvChqDeta.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grvChqDeta.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void View_Click(object sender, EventArgs e)
        {
            exportExcel();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCityCode.SelectedIndex != 0)
            {
                if (cmbArea.Items.Count > 0)
                {
                    cmbArea.Items.Clear();
                }

                if (cmbVillage.Items.Count > 0)
                {
                    cmbVillage.Items.Clear();
                }

                try
                {
                    DataSet dsVillage = cls_Connection.getDataSet("select * from area where branch_code = '" + cmbCityCode.SelectedItem.Value + "' ORDER BY area");
                    if (dsVillage.Tables[0].Rows.Count > 0)
                    {
                        cmbArea.Items.Add("Select Area");
                        btnSerch.Enabled = true;

                        for (int i = 0; i < dsVillage.Tables[0].Rows.Count; i++)
                        {
                            cmbArea.Items.Add(dsVillage.Tables[0].Rows[i][1].ToString());
                            cmbArea.Items[i + 1].Value = dsVillage.Tables[0].Rows[i][2].ToString();
                        }
                        cmbArea.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "No record found...! Please chose other city code.";
                        btnSerch.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load Areas according to selected branch");
                    return;
                }

                try
                {
                    string strBranch = cmbCityCode.SelectedItem.Value;

                    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");
                    if (cmbCRO.Items.Count > 0)
                    {
                        cmbCRO.Items.Clear();
                    }
                    cmbCRO.Items.Add("");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbCRO.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbCRO.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
                    }
                    //cmbRoot.Enabled = true;
                }
                catch (Exception ex)
                {
                    cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load MFO according to selected branch");
                    return;
                }
            }
            else
            {
                lblMsg.Text = "Please select branch";
                btnSerch.Enabled = false;
            }

            #region comment
            //try
            //{
            //    string strBranch = cmbCityCode.SelectedItem.Value;

            //    if (cmbCRO.Items.Count > 0)
            //    {
            //        cmbCRO.Items.Clear();
            //    }

            //    DataSet dsCro;
            //    MySqlCommand cmdCro = new MySqlCommand("SELECT exe_id, exe_name FROM micro_exective_root WHERE branch_code = '" + strBranch + "';");
            //    dsCro = objDBTask.selectData(cmdCro);
            //    cmbCRO.Items.Add("Select CRO");
            //    for (int i = 0; i < dsCro.Tables[0].Rows.Count; i++)
            //    {
            //        cmbCRO.Items.Add(dsCro.Tables[0].Rows[i][1].ToString());
            //        cmbCRO.Items[i + 1].Value = dsCro.Tables[0].Rows[i][0].ToString();
            //    }

            //    if (cmbVillagr.Items.Count > 0)
            //    {
            //        cmbVillagr.Items.Clear();
            //    }

            //    //Get Viilage
            //    DataSet dsGetVillge = cls_Connection.getDataSet("select villages,center_name,idcenter_details from center_details where city_code = '" + strBranch + "'");
            //    if (dsGetVillge.Tables[0].Rows.Count > 0)
            //    {
            //        cmbVillagr.Items.Add("");
            //        for (int i = 0; i < dsGetVillge.Tables[0].Rows.Count; i++)
            //        {
            //            //cmbVillagr.Items.Add("[" + dsGetVillge.Tables[0].Rows[i]["villages"] + "] - " + dsGetVillge.Tables[0].Rows[i]["center_name"].ToString());
            //            cmbVillagr.Items.Add(dsGetVillge.Tables[0].Rows[i]["center_name"].ToString());
            //            //cmbVillagr.Items[i + 1].Value = dsGetVillge.Tables[0].Rows[i]["villages"].ToString() + "-" + dsGetVillge.Tables[0].Rows[i]["idcenter_details"].ToString();
            //            cmbVillagr.Items[i + 1].Value = dsGetVillge.Tables[0].Rows[i]["idcenter_details"].ToString();
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}
            #endregion
        }

        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (cmbCityCode.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please chose city code.";
                    btnSerch.Enabled = false;
                }
                else if (cmbArea.SelectedIndex < 0)
                {
                    lblMsg.Text = "Please chose village name.";
                    btnSerch.Enabled = false;
                }
                else
                {
                    if (cmbVillage.Items.Count > 0)
                    {
                        cmbVillage.Items.Clear();
                    }

                    DataSet dsSocietyName = cls_Connection.getDataSet("SELECT villages_code,villages_name FROM villages_name WHERE city_code = '" + cmbCityCode.SelectedItem.Value + "' AND area_code ='" + cmbArea.SelectedItem.Value + "';");
                    if (dsSocietyName.Tables[0].Rows.Count > 0)
                    {
                        cmbVillage.Items.Add("Select Village");
                        for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
                        {
                            cmbVillage.Items.Add(dsSocietyName.Tables[0].Rows[i]["villages_name"].ToString());
                            cmbVillage.Items[i + 1].Value = dsSocietyName.Tables[0].Rows[i]["villages_code"].ToString();
                        }
                        cmbVillage.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "No record found...! Please chose other village name.";
                        btnSerch.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load villages according to selected area");
                return;
            }
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (cmbVillage.SelectedIndex != 0 && cmbCityCode.SelectedIndex != 0 && cmbArea.SelectedIndex != 0)
                {
                    DataSet dsGetSocietyID = cls_Connection.getDataSet("select exective from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "' and area_code = '" + cmbArea.SelectedItem.Value + "' and villages = '" + cmbVillage.SelectedItem.Value + "';");
                    if (dsGetSocietyID.Tables[0].Rows.Count > 0)
                    {
                        //txtSoNumber.Text = cmbSocietyName.SelectedItem.Value.ToString();

                        DataSet dsSCenter = cls_Connection.getDataSet("SELECT idcenter_details, center_name, center_day FROM center_details WHERE city_code = '" + cmbCityCode.SelectedItem.Value + "' AND area_code = '" + cmbArea.SelectedItem.Value + "' AND villages = '" + cmbVillage.SelectedItem.Value + "';");
                        cmbVillagr.Items.Clear();
                        if (dsSCenter.Tables[0].Rows.Count > 0)
                        {
                            cmbVillagr.Items.Add("Select Center");

                            for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                            {
                                cmbVillagr.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                                cmbVillagr.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                            }
                        }
                        cmbVillagr.Enabled = true;
                        //Edit 2014.09.18 CACode
                        //CACodeNew();
                        cmbCRO.SelectedValue = dsGetSocietyID.Tables[0].Rows[0]["exective"].ToString();
                        btnSerch.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "Invalid City Code or Society Name.";
                        btnSerch.Enabled = false;
                    }
                }
                else
                {
                    lblMsg.Text = "Please select city code or Society Name.";
                    btnSerch.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "Client basic details report load");
                return;
            }
        }
    }
}
