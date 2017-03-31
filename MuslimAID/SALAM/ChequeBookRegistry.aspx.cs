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

namespace MuslimAID.SALAM
{
    public partial class ChequeBookRegistry : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedIn"].ToString() == "True")
                {
                    try
                    {
                        //Add Bank
                        DataSet dsBank;
                        MySqlCommand cmdBank = new MySqlCommand("select * from bank_tbl ORDER BY 2");
                        dsBank = objDBTask.selectData(cmdBank);
                        cmbBankName.Items.Add("");
                        for (int i = 0; i < dsBank.Tables[0].Rows.Count; i++)
                        {
                            cmbBankName.Items.Add(dsBank.Tables[0].Rows[i][1].ToString());
                            cmbBankName.Items[i + 1].Value = dsBank.Tables[0].Rows[i][0].ToString();
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        string Bank = cmbBankName.SelectedValue.ToString();
                        DataSet dsCheqno;
                        MySqlCommand cmdBank = new MySqlCommand("SELECT max(cheq_no) cheq_no FROM chequebook_registry WHERE bank = '" + Bank + "';");
                        dsCheqno = objDBTask.selectData(cmdBank);
                        if (dsCheqno.Tables[0].Rows.Count > 0)
                        {
                            txtStartChqNo.Text = (Convert.ToInt64(dsCheqno.Tables[0].Rows[0]["cheq_no"]) + 1).ToString();
                            txtStartChqNo.Enabled = false;
                        }
                    }
                    catch (Exception)
                    {
                        txtStartChqNo.Enabled = true;
                    }
                    lblLastDate.Text = "";
                }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBranch.Items.Count > 0)
                {
                    cmbBranch.Items.Clear();
                }

                if (cmbBankName.SelectedIndex == 0)
                {
                    txtBankCode.Text = "";
                }
                else
                {
                    string strBank = cmbBankName.SelectedItem.Value;
                    txtBankCode.Text = strBank;
                    DataSet dsGetBranch = cls_Connection.getDataSet("select * from bankbranch_tbl where BankCode = '" + strBank + "' ORDER BY 2;");
                    cmbBranch.Items.Add("");
                    for (int i = 0; i < dsGetBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbBranch.Items.Add(dsGetBranch.Tables[0].Rows[i][2].ToString());
                        cmbBranch.Items[i + 1].Value = dsGetBranch.Tables[0].Rows[i][1].ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                string Bank = cmbBankName.SelectedValue.ToString();
                DataSet dsCheqno;
                MySqlCommand cmdBank = new MySqlCommand("SELECT max(cheq_no) cheq_no FROM chequebook_registry WHERE bank = '" + Bank + "';");
                dsCheqno = objDBTask.selectData(cmdBank);
                if (dsCheqno.Tables[0].Rows.Count > 0)
                {
                    txtStartChqNo.Text = (Convert.ToInt64(dsCheqno.Tables[0].Rows[0]["cheq_no"]) + 1).ToString();
                    txtStartChqNo.Enabled = true;
                }
            }
            catch (Exception)
            {
                txtStartChqNo.Text = "";
                txtStartChqNo.Enabled = true;
                lblLDMsg.Text = "";
            }
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBranch.SelectedIndex == 0)
                {
                    txtBranchCode.Text = "";
                }
                else
                {
                    string strBranch = cmbBranch.SelectedItem.Value;
                    txtBranchCode.Text = strBranch;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Clear()
        {
            cmbBankName.SelectedIndex = -1;
            cmbBranch.SelectedIndex = -1;
            txtBankCode.Text = "";
            txtBranchCode.Text = "";
            txtStartChqNo.Text = "";
            txtNoChq.Text = "";
            txtStartChqNo.Enabled = true;
            lblLastDate.Text = "";
            txtAccountNo.Text = "";
        }

        private void Save()
        {
            try
            {
                if (cmbBankName.SelectedIndex == 0)
                {
                    lblLDMsg.Text = "Please enter Bank Name.";
                }
                else if (cmbBranch.SelectedIndex == 0)
                {
                    lblLDMsg.Text = "Please enter Account branch.";
                }
                else if (txtStartChqNo.Text.Trim() == "")
                {
                    lblLDMsg.Text = "Please Enter Start Cheque Number.";
                }
                else if (txtAccountNo.Text.Trim() == "")
                {
                    lblLDMsg.Text = "Please Enter Account Number.";
                }
                else if (txtNoChq.Text.Trim() == "")
                {
                    lblLDMsg.Text = "Please Enter Number of Cheque .";
                }
                else
                {
                    lblLDMsg.Text = "";
                    string cheq_no, bank, bank_branch, create_date, create_user, status, AccountNo;
                    int length = 0, CheqNo = 0;

                    #region Assign Values
                    cheq_no = txtStartChqNo.Text.Trim();
                    bank = txtBankCode.Text.Trim();
                    bank_branch = txtBranchCode.Text.Trim();
                    AccountNo = txtAccountNo.Text.Trim();
                    length = txtNoChq.Text == "" ? 0 : Convert.ToInt32(txtNoChq.Text);
                    create_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    create_user = Session["NIC"].ToString();
                    status = "1";
                    #endregion
                    CheqNo = Convert.ToInt32(cheq_no);

                    for (int i = 0; i < length; i++)
                    {
                        MySqlCommand cmdInsertLDQRY = new MySqlCommand("INSERT INTO `chequebook_registry`(`cheq_no`,`bank`,`bank_branch`,`create_date`,`create_user`,`status`,chq_status,AccountNo)VALUES(@cheq_no,@bank,@bank_branch,@create_date,@create_user,@status,@chq_status,@AccountNo);");

                        #region Assign Parameters
                        cmdInsertLDQRY.Parameters.Add("@cheq_no", MySqlDbType.VarChar, 45);
                        cmdInsertLDQRY.Parameters.Add("@bank", MySqlDbType.VarChar, 45);
                        cmdInsertLDQRY.Parameters.Add("@bank_branch", MySqlDbType.VarChar, 45);
                        cmdInsertLDQRY.Parameters.Add("@create_date", MySqlDbType.VarChar, 45);
                        cmdInsertLDQRY.Parameters.Add("@create_user", MySqlDbType.VarChar, 45);
                        cmdInsertLDQRY.Parameters.Add("@status", MySqlDbType.VarChar, 1);
                        cmdInsertLDQRY.Parameters.Add("@chq_status", MySqlDbType.VarChar, 1);
                        cmdInsertLDQRY.Parameters.Add("@AccountNo", MySqlDbType.VarChar, 20);
                        #endregion

                        #region DEclare Parametes
                        cmdInsertLDQRY.Parameters["@cheq_no"].Value = cheq_no;
                        cmdInsertLDQRY.Parameters["@bank"].Value = bank;
                        cmdInsertLDQRY.Parameters["@bank_branch"].Value = bank_branch;
                        cmdInsertLDQRY.Parameters["@create_date"].Value = create_date;
                        cmdInsertLDQRY.Parameters["@create_user"].Value = create_user;
                        cmdInsertLDQRY.Parameters["@status"].Value = status;
                        cmdInsertLDQRY.Parameters["@chq_status"].Value = "A";
                        cmdInsertLDQRY.Parameters["@AccountNo"].Value = AccountNo;
                        #endregion

                        try
                        {
                            int f;
                            f = objDBTask.insertEditData(cmdInsertLDQRY);
                            if (f == 1)
                            {
                                lblLDMsg.Text = "Successfully Added.";
                                Clear();
                            }
                            else
                            {
                                lblLDMsg.Text = "Error Occured!";
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        CheqNo++;
                        cheq_no = CheqNo.ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void txtNoChq_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblLastDate.Text = (Convert.ToInt32(txtStartChqNo.Text) + Convert.ToInt32(txtNoChq.Text) - 1).ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}
