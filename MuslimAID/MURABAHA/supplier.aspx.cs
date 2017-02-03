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
                            txtCACode.Text = strCAC;
                            txtCC.Enabled = false;

                            DataSet ds = cls_Connection.getDataSet("select * from bank_tbl");
                            cmbSupplierBank.Items.Add(new ListItem("Select Bank",""));
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow drRow in ds.Tables[0].Rows)
                                {
                                    cmbSupplierBank.Items.Add(new ListItem(drRow[1].ToString(), drRow[0].ToString()));
                                }
                            }

                            //DataSet dsSC = cls_Connection.getDataSet("select * from supplier_category");
                            //cmbSupplierCategory.Items.Add(new ListItem("Select Supplier Category",""));
                            //if (dsSC.Tables[0].Rows.Count > 0)
                            //{
                            //    foreach (DataRow drRow in dsSC.Tables[0].Rows)
                            //    {
                            //        cmbSupplierCategory.Items.Add(new ListItem(drRow[1].ToString(), drRow[0].ToString()));
                            //    }
                            //}
                        }
                        else
                        {
                            txtCC.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
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
                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO supplier_details(contract_code,name,address,tele,mobile,bank,branch,account_no,account_name)VALUES (@contract_code,@name,@address,@tele,@mobile,@bank,@branch,@account_no,@account_name)");

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
                            Response.Redirect("supplier.aspx?CC=" + txtCC.Text.Trim() + "&CA=" + txtCACode.Text.Trim());
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
    }
}
