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
                        if (Session["UserType"] != "Cash Collector" || Session["UserType"] != "Cash Recovery Officer" || Session["UserType"] != "Special Recovery Officer")
                        {
                            strCC = Request.QueryString["CC"];
                            strCAC = Request.QueryString["CA"];
                            rdoIndividual.Checked = true;
                            txtBrNo.ReadOnly = true;

                            if (strCC != null && strCAC != null)
                            {
                                txtCC.Text = strCC;
                                txtCC.Enabled = false;
                            }
                            else
                            {
                                txtCC.Enabled = true;
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
            }
            catch (Exception)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            strCC = Request.QueryString["CC"];
            strCAC = Request.QueryString["CA"];
            try {
                if (txtSupplierName.Text == "")
                    lblMsg.Text = "Plese enter the supplier name";
                else if (txtContactPerson.Text.Trim() == "")
                    lblMsg.Text = "Plese enter the contact person";
                else if (txtNIC.Text.Trim() == "")
                    lblMsg.Text = "Plese enter the NIC";
                else if (txtBisAddress.Text == "")
                    lblMsg.Text = "Plese enter the business address";
                //else if (rdoIndividual.Checked && txtNameOnChecque.Text == "")
                //   lblMsg.Text = "Plese enter name you prefer to print on cheque.";
                //else if (rdoIndividual.Checked && txtNameOnChecque.Text.Length < 5)
                //    lblMsg.Text = "Name you prefer to print on cheque must be more than 5 charaters.";
                else {
                    //MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_supplier_details(contract_code,name,address,tele,mobile,br,nic,contact_person,invoice_value,suplier_type,name_on_cheque)VALUES (@contract_code,@name,@address,@tele,@mobile,@br,@nic,@contact_person,@invoice_value,@suplier_type,@name_on_cheque)");
                    MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO micro_supplier_details(contract_code,name,address,tele,mobile,br,nic,contact_person,invoice_value,suplier_type)VALUES (@contract_code,@name,@address,@tele,@mobile,@br,@nic,@contact_person,@invoice_value,@suplier_type)");

                    #region Parameter Declarations
                    cmdInsert.Parameters.AddWithValue("@contract_code", strCC);
                    cmdInsert.Parameters.AddWithValue("@name", txtSupplierName.Text.Trim().ToString());
                    cmdInsert.Parameters.AddWithValue("@address", txtBisAddress.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@tele", txtTelephone.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@mobile", txtMobile.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@br", txtBrNo.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@nic", txtNIC.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@contact_person", txtContactPerson.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@invoice_value", (txtInvoiceValue.Text.Trim()!="")? Convert.ToDouble(txtInvoiceValue.Text.Trim()):0.00);
                    cmdInsert.Parameters.AddWithValue("@suplier_type", (rdoIndividual.Checked) ? "I" : "B");
                    //cmdInsert.Parameters.AddWithValue("@name_on_cheque", txtNameOnChecque.Text.Trim());
                    #endregion

                    try
                    {
                        int i = objDBCon.insertEditData(cmdInsert);

                        if (i > 0)
                        {
                            clean();
                            lblMsg.Text = "Successfull";
                            Response.Redirect("loan_details.aspx?CC=" + strCC + "&CA=" + strCAC + "");
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
            txtBisAddress.Text = "";
            txtCC.Text = "";
            txtMobile.Text = "";
            txtSupplierName.Text = "";
            txtTelephone.Text = "";
            txtBrNo.Text = "";
            txtContactPerson.Text = "";
            txtInvoiceValue.Text = "";
            txtNIC.Text = "";
        }

        protected void txtCC_TextChanged(object sender, EventArgs e)
        {
            if (txtCC.Text.Trim() != "")
            {
                DataSet dsGetData = cls_Connection.getDataSet("SELECT * FROM `micro_supplier_details` WHERE contract_code ='"+txtCC.Text.Trim()+"'");
                if (dsGetData.Tables[0].Rows.Count > 0)
                {
                    txtSupplierName.Text = dsGetData.Tables[0].Rows[0]["name"].ToString();
                    if (dsGetData.Tables[0].Rows[0]["suplier_type"].ToString() == "I") {
                        rdoIndividual.Checked = true;
                        txtBrNo.ReadOnly = true;
                        //txtNameOnChecque.ReadOnly = true;
                        //txtNameOnChecque.Text = dsGetData.Tables[0].Rows[0]["name_on_cheque"].ToString();
                    } else {
                        rdoBusines.Checked = true;
                        txtBrNo.ReadOnly = false;
                        //txtNameOnChecque.ReadOnly = false;
                        txtBrNo.Text = dsGetData.Tables[0].Rows[0]["br"].ToString();
                    }
                    txtNIC.Text = dsGetData.Tables[0].Rows[0]["nic"].ToString();
                    txtContactPerson.Text = dsGetData.Tables[0].Rows[0]["contact_person"].ToString();
                    txtBisAddress.Text = dsGetData.Tables[0].Rows[0]["address"].ToString();
                    txtTelephone.Text = dsGetData.Tables[0].Rows[0]["tele"].ToString();
                    txtMobile.Text = dsGetData.Tables[0].Rows[0]["mobile"].ToString();
                    txtInvoiceValue.Text = dsGetData.Tables[0].Rows[0]["invoice_value"].ToString();

                    btnSubmit.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    btnSubmit.Enabled = true;
                    btnUpdate.Enabled = true;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string sType = (rdoIndividual.Checked) ? "I" : "B";
            strCAC = Request.QueryString["CA"];
            strCC = txtCC.Text.Trim();

            if (txtSupplierName.Text == "")
                    lblMsg.Text = "Plese enter the supplier name";
                else if (txtContactPerson.Text.Trim() == "")
                    lblMsg.Text = "Plese enter the contact person";
                else if (txtNIC.Text.Trim() == "")
                    lblMsg.Text = "Plese enter the NIC";
                else if (txtBisAddress.Text == "")
                    lblMsg.Text = "Plese enter the business address";
            //    else if (rdoIndividual.Checked && txtNameOnChecque.Text == "")
            //        lblMsg.Text = "Plese enter name you prefer to print on cheque.";
            //else if (rdoIndividual.Checked && txtNameOnChecque.Text.Length < 5)
            //    lblMsg.Text = "Name you prefer to print on cheque must be more than 5 charaters.";
            else
            {
                MySqlCommand cmdUpdateQRY = new MySqlCommand("UPDATE micro_supplier_details SET name='" + txtSupplierName.Text.Trim() + "', address='" + txtBisAddress.Text.Trim() + "', tele='" + txtTelephone.Text.Trim() + "', mobile='" + txtMobile.Text.Trim() + "', nic='" + txtNIC.Text.Trim() + "', invoice_value='" + txtInvoiceValue.Text.Trim() + "', contact_person='" + txtContactPerson.Text.Trim() + "', br='" + txtBrNo.Text.Trim() + "', suplier_type='" + sType + "'  where contract_code='" + txtCC.Text.Trim() + "';");
                try
                {
                    if (objDBCon.insertEditData(cmdUpdateQRY) > 0)
                    {
                        Clear();
                        lblMsg.Text = "Update Success.";
                        if (strCAC == "")
                            Response.Redirect("loan_details.aspx?CC=" + strCC + "&CA=" + strCAC + "");
                        else
                            Response.Redirect("loan_details.aspx?CC=" + strCC);

                        btnUpdate.Enabled = false;
                        btnSubmit.Enabled = true;
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

        protected void Clear()
        {
            txtBisAddress.Text = "";
            txtCC.Text = "";
            txtMobile.Text = "";
            txtSupplierName.Text = "";
            txtTelephone.Text = "";
        }

        protected void rdoIndividual_CheckedChanged(object sender, EventArgs e)
        {
            txtBrNo.Text = "";
            txtBrNo.ReadOnly = true;
        }

        protected void rdoBusines_CheckedChanged(object sender, EventArgs e)
        {
            txtBrNo.ReadOnly = false;
        }
    }
}
