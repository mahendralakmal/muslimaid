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

namespace MuslimAID
{
    public partial class BranchAdd : System.Web.UI.Page
    {
        cls_Connection objDBTask = new cls_Connection();

        private void IsExsistBranch()
        {
            try
            {
                lblMsg.Text = "";
                if (txtBranchCode.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter branch code.";
                }
                else
                {
                    string strBranchCode = txtBranchCode.Text.Trim();

                    DataSet dsGetVillage = cls_Connection.getDataSet("select * from branch where b_code = '" + strBranchCode + "' ;");
                    if (dsGetVillage.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "Alredy created.";
                        btnSubmit.Enabled = false;
                    }
                    else
                    {
                        txtBranchName.Focus();
                        btnSubmit.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void IsExistName()
        {
            try
            {
                lblMsg.Text = "";
                if (txtBranchCode.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter branch code.";
                }
                if (txtBranchName.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter branch name.";
                }
                else
                {
                    string strBranchCode = txtBranchCode.Text.Trim();
                    string strBranch = txtBranchName.Text.Trim();

                    DataSet dsGetVillage = cls_Connection.getDataSet("select * from branch where b_name = '" + strBranch + "' ;");
                    if (dsGetVillage.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "Alredy created.";
                        btnSubmit.Enabled = false;
                    }
                    else
                    {
                        btnSubmit.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void Save()
        {
            try
            {
                lblMsg.Text = "";
                if (txtBranchCode.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter branch code.";
                }
                else if (txtBranchName.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter branch name.";
                }
                else
                {
                    string strVillage = txtBranchName.Text.Trim();
                    string strBranchCode = txtBranchCode.Text.Trim();

                    MySqlCommand cmdInsert = new MySqlCommand("insert into branch(b_code,b_name) values (@b_code,@b_name);");

                    #region DeclarareParamerts
                    cmdInsert.Parameters.Add("@b_code", MySqlDbType.VarChar, 3);
                    cmdInsert.Parameters.Add("@b_name", MySqlDbType.VarChar, 45);
                    #endregion

                    #region AssignParameters
                    cmdInsert.Parameters["@b_code"].Value = strBranchCode;
                    cmdInsert.Parameters["@b_name"].Value = strVillage;
                    #endregion

                    try
                    {
                        //Check Is Exist Branch Code
                        DataSet dsGetVillage = cls_Connection.getDataSet("select * from branch where b_code = '" + strBranchCode + "' ;");
                        if (dsGetVillage.Tables[0].Rows.Count == 0)
                        {
                            int i = objDBTask.insertEditData(cmdInsert);
                            if (i == 1)
                            {
                                lblMsg.Text = "Successfully Added Branch";
                                Clear();
                            }
                            else
                            {
                                lblMsg.Text = "Error Occured!";
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Alredy created. " + txtBranchCode.Text + " - " + txtBranchName.Text;
                            Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Clear()
        {
            txtBranchCode.Text = "";
            txtBranchName.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strloginID = Session["NIC"].ToString();

                string strType = Session["UserType"].ToString();
                if (strType == "ADM" || strType == "BOD" || strType == "CMG" || strType == "OMG")
                {
                    txtBranchCode.Focus();
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

        protected void txtBranchCode_TextChanged(object sender, EventArgs e)
        {
            if (txtBranchCode.Text.Trim() != "")
            {
                IsExsistBranch();
            }
        }

        protected void txtBranchName_TextChanged(object sender, EventArgs e)
        {
            if (txtBranchName.Text.Trim() != "")
            {
                IsExistName();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
