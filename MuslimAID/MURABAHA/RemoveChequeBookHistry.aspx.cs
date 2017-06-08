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
    public partial class RemoveChequeBookHistry : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (Session["UserType"] != "Cash Collector" || Session["UserType"] != "Cash Recovery Officer" || Session["UserType"] != "Special Recovery Officer")
                {
                    try
                    {
                        //Add Cheque                    
                        DataSet dsCheqNo;
                        MySqlCommand cmdCheqNo = new MySqlCommand("SELECT cheq_no FROM chequebook_registry where status = 1;");
                        dsCheqNo = cls_Connection.selectDataSet(cmdCheqNo);
                        cmbChqNo.Items.Add("");
                        for (int i = 0; i < dsCheqNo.Tables[0].Rows.Count; i++)
                        {
                            cmbChqNo.Items.Add(dsCheqNo.Tables[0].Rows[i][0].ToString());
                            cmbChqNo.Items[i + 1].Value = dsCheqNo.Tables[0].Rows[i][0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        cls_ErrorLog.createSErrorLog(ex.Message, ex.Source, "");
                    }
                }
                else
                {
                    Response.Redirect("murabha.aspx");
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void Clear()
        {
            lblNIC.Text = "";
            txtComment.Text = "";
            lblChequeDate.Text = "";
            lblAccountNo.Text = "";            
        }

        private void ExistCheq()
        {
            try
            {
                lblMsg.Text = "";
                Clear();
                if (txtRNo.Text.Trim() != "")
                {
                    string strRNo = txtRNo.Text.Trim();
                    DataSet dsChequeNo = cls_Connection.getDataSet("select * from chequebook_registry where cheq_no = '" + strRNo + "' and status = 1 ;");

                    if (dsChequeNo.Tables[0].Rows.Count > 0)
                    {
                        lblNIC.Text = dsChequeNo.Tables[0].Rows[0]["create_user"].ToString();
                        lblChequeDate.Text = dsChequeNo.Tables[0].Rows[0]["create_date"].ToString();
                        lblAccountNo.Text = dsChequeNo.Tables[0].Rows[0]["AccountNo"].ToString();
                        btnPeied.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "No Record Found.";
                    }
                }
                else
                {
                    lblMsg.Text = "Please enter Receipt No.";
                    btnPeied.Enabled = false;
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "No Record Found.";
            }
        }

        private void SaveCheqCancel()
        {
            try
            {
                lblMsg.Text = "";
                if (txtRNo.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Cheque No.";
                }
                else if (lblNIC.Text.Trim() == "")
                {
                    lblNIC.Text = "Please enter NIC.";
                }
                else if (txtComment.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Comment.";
                }
                else
                {
                    string strRNo = txtRNo.Text.Trim();
                    string strComment = txtComment.Text.Trim();
                    string strChequeDate = lblChequeDate.Text;
                    string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string strIp = Request.UserHostAddress;
                    string strAccount = lblAccountNo.Text;
                    string strloginID = Session["NIC"].ToString();

                    try
                    {
                        MySqlCommand cmdUpdateChequeNo = new MySqlCommand("Update chequebook_registry set chq_status = 'C', status = 0 where cheq_no = '" + strRNo + "';");
                        try
                        {
                            int g;
                            g = objDBTask.insertEditData(cmdUpdateChequeNo);
                            if (g == 1)
                            { }
                        }
                        catch (Exception ex)
                        {
                        }

                        MySqlCommand cmdUpdateChe = new MySqlCommand("INSERT INTO chequebookCancel(`cheq_no`,`contract_code`,`chequ_deta_on`,`cancel_date`,`cancel_user`,`ChequeAmount`,`AccountNo`,Comment) values ('" + strRNo + "','','','" + strDate + "','" + strloginID + "',0.00,'" + strAccount + "','" + strComment + "');");
                        try
                        {
                            int g;
                            g = objDBTask.insertEditData(cmdUpdateChe);
                            if (g == 1)
                            { }
                        }
                        catch (Exception ex)
                        {
                        }

                        lblMsg.Text = "Cheque is Remove.";
                        btnPeied.Enabled = false;
                        Clear();
                        txtRNo.Text = "";
                        try
                        {
                            //Add Cheque
                            if (cmbChqNo.Items.Count > 0)
                            {
                                cmbChqNo.Items.Clear();
                            }
                            DataSet dsCheqNo;
                            MySqlCommand cmdCheqNo = new MySqlCommand("SELECT cheq_no FROM chequebook_registry where status = 1;");
                            dsCheqNo = cls_Connection.selectDataSet(cmdCheqNo);
                            cmbChqNo.Items.Add("");
                            for (int i = 0; i < dsCheqNo.Tables[0].Rows.Count; i++)
                            {
                                cmbChqNo.Items.Add(dsCheqNo.Tables[0].Rows[i][0].ToString());
                                cmbChqNo.Items[i + 1].Value = dsCheqNo.Tables[0].Rows[i][0].ToString();
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "Error Occured!";
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void txtRNo_TextChanged(object sender, EventArgs e)
        {
            ExistCheq();
        }

        protected void btnPeied_Click(object sender, EventArgs e)
        {
            SaveCheqCancel();
        }

        protected void cmbChqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChqNo.SelectedIndex != 0)
            {
                txtRNo.Text = cmbChqNo.SelectedValue;
                ExistCheq();
            }
        }
    }
}
