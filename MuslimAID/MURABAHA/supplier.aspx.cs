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
    public partial class supplier : System.Web.UI.Page
    {
        string strCC; string strCAC;
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LoggedIn"].ToString() == "True")
                    {
                        strCC = Request.QueryString["CC"];
                        strCAC = Request.QueryString["CA"];

                        if (strCC != null && strCAC != null)
                        {
                            txtCC.Text = strCC;
                            txtCC.Enabled = false;
                            getBankDetails();                            
                        }
                        else
                        {
                            txtCC.Enabled = true;
                            getBankDetails();
                        }
                    }
                    else
                    {
                        Response.Redirect("../Login.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void getBankDetails()
        {
            DataSet ds = cls_Connection.getDataSet("SELECT * FROM `bank_tbl`");
            cmbSupplierBank.Items.Add(new ListItem("Select Bank", ""));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drRow in ds.Tables[0].Rows)
                {
                    cmbSupplierBank.Items.Add(new ListItem(drRow[1].ToString(), drRow[0].ToString()));
                }
            }
        }

        protected void cmbSupplierBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = cls_Connection.getDataSet("select * from bankbranch_tbl where BankCode = " + cmbSupplierBank.SelectedValue.ToString());
            cmbBnkBranch.Items.Add(new ListItem("Select Bank Branch",""));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drRow in ds.Tables[0].Rows)
                {
                    cmbBnkBranch.Items.Add(new ListItem(drRow[2].ToString(), drRow[1].ToString()));
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try {
                if (txtSupplierName.Text == "")
                    lblMsg.Text = "Plese enter the supplier name";
                //else if(cmbSupplierCategory.SelectedIndex.ToString() =="")
                //    lblMsg.Text = "Plese select the supplier category";
                else if (cmbSupplierBank.SelectedIndex.ToString() == "")
                    lblMsg.Text = "Plese select the supplier bank";
                else if (cmbBnkBranch.SelectedIndex.ToString() == "")
                    lblMsg.Text = "Plese select the supplier bank branch";
                else if (txtBisAddress.Text == "")
                    lblMsg.Text = "Plese enter the supplier address";
                else if (txtSupplierTelephone.Text == "")
                    lblMsg.Text = "Plese enter the supplier telephone";
                else if (txtAccountNumber.Text == "")
                    lblMsg.Text = "Plese enter the supplier account number";
                else if (txtAccountName.Text == "")
                    lblMsg.Text = "Plese enter the supplier account name";
                else {
                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_supplier_details(contract_code,name,address,tele,mobile,bank,branch,account_no,account_name)VALUES (@contract_code,@name,@address,@tele,@mobile,@bank,@branch,@account_no,@account_name)");

                    #region Parameter Declarations
                    cmdInsert.Parameters.AddWithValue("@contract_code", txtCC.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim().ToString());
                    //cmdInsert.Parameters.AddWithValue("@supplier_category", Convert.ToDecimal(cmbSupplierCategory.SelectedValue.ToString()));
                    cmdInsert.Parameters.AddWithValue("@address", txtBisAddress.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@tele", txtSupplierTelephone.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@mobile", txtSupplierMobile.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@bank", Convert.ToInt32(cmbSupplierBank.SelectedValue.ToString()));
                    cmdInsert.Parameters.AddWithValue("@branch", Convert.ToInt32(cmbBnkBranch.SelectedValue.ToString()));
                    cmdInsert.Parameters.AddWithValue("@account_no", txtAccountNumber.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@account_name", txtAccountName.Text.Trim());
                    #endregion

                    try
                    {
                        int i = objDBCon.insertEditData(cmdInsert);

                        if (i > 0)
                        {
                            clean();
                            lblMsg.Text = "Successfull";
                        }
                        else
                        {
                            lblMsg.Text = "Error Occured";
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception x)
            {

            }
        }

        protected void clean() {
            txtAccountName.Text = "";
            txtAccountNumber.Text = "";
            txtBisAddress.Text = "";
            txtCC.Text = "";
            txtSupplierMobile.Text = "";
            txtSupplierName.Text = "";
            txtSupplierTelephone.Text = "";
            cmbBnkBranch.SelectedIndex = 0;
            cmbSupplierBank.SelectedIndex = 0;
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            if (txtCC.Text.Trim() != "")
            {
                DataSet dsGetData = cls_Connection.getDataSet("SELECT * FROM `micro_supplier_details` WHERE contract_code ='"+txtCC.Text.Trim()+"'");
                if (dsGetData.Tables[0].Rows.Count > 0)
                {
                    txtSupplierName.Text = dsGetData.Tables[0].Rows[0]["name"].ToString();
                    txtBisAddress.Text = dsGetData.Tables[0].Rows[0]["address"].ToString();
                    txtSupplierTelephone.Text = dsGetData.Tables[0].Rows[0]["tele"].ToString();
                    txtSupplierMobile.Text = dsGetData.Tables[0].Rows[0]["mobile"].ToString();
                    cmbSupplierBank.SelectedValue = dsGetData.Tables[0].Rows[0]["bank"].ToString();
                    cmbBnkBranch.SelectedValue = dsGetData.Tables[0].Rows[0]["branch"].ToString();
                    txtAccountName.Text = dsGetData.Tables[0].Rows[0]["account_name"].ToString();
                    txtAccountNumber.Text = dsGetData.Tables[0].Rows[0]["account_no"].ToString();

                    btnSubmit.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    btnSubmit.Enabled = true;
                    btnUpdate.Enabled = false;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE micro_supplier_details SET name='" + txtSupplierName.Text.Trim() + "', address='" + txtBisAddress.Text.Trim() + "', tele='" + txtSupplierTelephone.Text.Trim() + "', mobile='" + txtSupplierMobile.Text.Trim() + "',bank=" + cmbSupplierBank.SelectedValue + ", branch =" + cmbBnkBranch.SelectedValue + ",account_no='" + txtAccountNumber.Text.Trim() + "', account_name='" + txtAccountName.Text.Trim() + "'");
            try
            {
                int i;
                i = objDBCon.insertEditData(cmdUpdateQRY);

                Clear();
                lblMsg.Text = "Update Success.";



                btnUpdate.Enabled = false;
                btnSubmit.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        protected void Clear()
        {
            txtAccountName.Text = "";
            txtAccountNumber.Text = "";
            txtBisAddress.Text = "";
            txtCC.Text = "";
            txtSupplierMobile.Text = "";
            txtSupplierName.Text = "";
            txtSupplierTelephone.Text = "";
            cmbBnkBranch.SelectedIndex = 0;
            cmbSupplierBank.SelectedIndex = 0;
        }
    }
}
