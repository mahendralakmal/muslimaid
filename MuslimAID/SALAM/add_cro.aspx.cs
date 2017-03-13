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
    public partial class add_cro : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBCon = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strloginID = Session["NIC"].ToString();

                DataSet dsUserTy = cls_Connection.getDataSet("SELECT user_type FROM users WHERE nic = '" + strloginID + "';");
                //DataSet dsUserTy = objDBCon.getDataSet("select user_type from users where nic = '" + strloginID + "';");
                if (dsUserTy.Tables[0].Rows.Count > 0)
                {
                    string strType = dsUserTy.Tables[0].Rows[0]["user_type"].ToString();
                    if (strType == "Top Managment" || strType == "Admin")
                    {
                        if (!this.IsPostBack)
                        {
                            DataSet dsBranch = cls_Connection.getDataSet("SELECT * FROM branch ORDER BY 2");
                            cmbCityCode.Items.Add("Select Branch");

                            for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                            {
                                cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                                cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                            }
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
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                string strloginID = Session["NIC"].ToString();

                if (cmbCityCode.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select branch.";
                }
                else if (txtRootName.Text.Trim() == "")
                {
                    lblMsg.Text = "Please enter Root Name.";
                }

                else
                {
                    string strRootName = txtRootName.Text.Trim();
                    string strBranch = cmbCityCode.SelectedItem.Value;
                    //string strloginID = Session["NIC"].ToString();
                    string strIP = Request.UserHostAddress;
                    string strDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //string strNewID = txtRootID.Text.Trim();

                    DataSet dsGetCurrPassword = cls_Connection.getDataSet("select (IFNULL(MAX(exe_id),0) + 1) AS MAX from micro_exective_root where branch_code ='" + strBranch + "'");
                    if (dsGetCurrPassword.Tables[0].Rows.Count > 0)
                    {
                        string strNewID = dsGetCurrPassword.Tables[0].Rows[0][0].ToString();

                        MySqlCommand cmdInsertQRY = new MySqlCommand("INSERT INTO micro_exective_root(exe_id,exe_name,branch_code,create_user_id,create_ip,create_date_time)VALUES(@exe_id,@exe_name,@branch_code,@create_user_id,@create_ip,@create_date_time);");

                        #region Assign Parameters
                        cmdInsertQRY.Parameters.Add("@exe_id", MySqlDbType.VarChar, 2);
                        cmdInsertQRY.Parameters.Add("@exe_name", MySqlDbType.VarChar, 100);
                        cmdInsertQRY.Parameters.Add("@branch_code", MySqlDbType.VarChar, 10);
                        cmdInsertQRY.Parameters.Add("@create_user_id", MySqlDbType.VarChar, 10);
                        cmdInsertQRY.Parameters.Add("@create_ip", MySqlDbType.VarChar, 45);
                        cmdInsertQRY.Parameters.Add("@create_date_time", MySqlDbType.VarChar, 20);
                        #endregion

                        #region DEclare Parametes
                        cmdInsertQRY.Parameters["@exe_id"].Value = strNewID;
                        cmdInsertQRY.Parameters["@exe_name"].Value = strRootName;
                        cmdInsertQRY.Parameters["@branch_code"].Value = strBranch;
                        cmdInsertQRY.Parameters["@create_user_id"].Value = strloginID;
                        cmdInsertQRY.Parameters["@create_ip"].Value = strIP;
                        cmdInsertQRY.Parameters["@create_date_time"].Value = strDate;
                        #endregion

                        try
                        {
                            int ii;
                            ii = objDBCon.insertEditData(cmdInsertQRY);
                            if (ii == 1)
                            {
                                Reset();
                                lblMsg.Text = "Executive Added...Executive ID is " + strNewID + ".";
                            }
                            else
                            {
                                lblMsg.Text = "Error Error";
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }

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

        protected void Reset()
        {
            txtRootName.Text = "";
            //txtRootID.Text = "";
            cmbCityCode.SelectedIndex = 0;
        }

        protected void txtRootName_TextChanged(object sender, EventArgs e)

        {
            lblMsg.Text = "";
            if (cmbCityCode.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select branch.";
            }
            else if (txtRootName.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter Root Name.";
            }
            else
            {
                string strRootName = txtRootName.Text.Trim();
                string strBranch = cmbCityCode.SelectedItem.Value;
                DataSet dsGetCurrPassword = cls_Connection.getDataSet("select * from micro_exective_root where branch_code ='" + strBranch + "' and exe_name = '" + strRootName + "'");
                if (dsGetCurrPassword.Tables[0].Rows.Count > 0)
                {
                    lblMsg.Text = "Root Name Already used...!";
                    btnChange.Enabled = false;
                }
                else
                {
                    btnChange.Enabled = true;
                }
            }
        }
    }
}
