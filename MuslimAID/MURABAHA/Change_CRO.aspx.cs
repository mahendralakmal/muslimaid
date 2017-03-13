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
    public partial class Change_CRO : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {
                if (!this.IsPostBack)
                {
                    string strBranch = Session["Branch"].ToString();
                    //lblBranch.Text = strBranch;
                    if (cmbCityCode.Items.Count > 0)
                    {
                        cmbCityCode.Items.Clear();
                    }
                    DataSet dsBranch;
                    MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM branch ORDER BY 2");
                    dsBranch = objDBTask.selectData(cmdBranch);
                    cmbCityCode.Items.Add("");
                    for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                    {
                        cmbCityCode.Items.Add(dsBranch.Tables[0].Rows[i][2].ToString());
                        cmbCityCode.Items[i + 1].Value = dsBranch.Tables[0].Rows[i][1].ToString();
                    }
                    cmbCityCode.SelectedValue = strBranch;
                    if (cmbRoot.Items.Count > 0)
                    {
                        cmbRoot.Items.Clear();
                    }
                    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");

                    cmbRoot.Items.Add("");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        private void Save()
        {
            try
            {
                lblMsg.Text = "";
                if (cmbCityCode.SelectedIndex == 0)
                {
                    lblMsg.Text = "Invalid Transaction.";
                }
                else if (cmbSocietyName.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select Center.";
                }
                else if (cmbRoot.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select CRO.";
                }
                else
                {
                    string root = cmbRoot.SelectedItem.Value;
                    MySqlCommand cmdUpdateCenter = new MySqlCommand("Update center_details set exective = '" + root + "' where idcenter_details = '" + cmbSocietyName.SelectedValue + "' and city_code = '" + cmbCityCode.SelectedValue + "';");
                    int i;
                    i = objDBTask.insertEditData(cmdUpdateCenter);

                    DataSet dsGetLoan = cls_Connection.getDataSet("select contract_code,society_id,city_code,idmicro_basic_detail from micro_basic_detail where city_code = '" + cmbCityCode.SelectedItem.Value + "' and society_id = '" + cmbSocietyName.SelectedValue + "';");

                    if (dsGetLoan.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < dsGetLoan.Tables[0].Rows.Count; j++)
                        {
                            string strCCode = dsGetLoan.Tables[0].Rows[j]["contract_code"].ToString();
                            string BranchCode = dsGetLoan.Tables[0].Rows[j]["city_code"].ToString();
                            string CenterCode = dsGetLoan.Tables[0].Rows[j]["society_id"].ToString();
                            string id = dsGetLoan.Tables[0].Rows[j]["idmicro_basic_detail"].ToString();
                            try
                            {
                                //Update CRO
                                MySqlCommand cmdUpdateCRO = new MySqlCommand("Update micro_basic_detail set root_id = '" + root + "' where idmicro_basic_detail = '" + id + "' and contract_code = '" + strCCode + "';");
                                int k;
                                k = objDBTask.insertEditData(cmdUpdateCRO);
                                if (k == 1)
                                {
                                    lblMsg.Text = "Updated Successfully";
                                }
                            }
                            catch (Exception)
                            {
                            }
                            //-----
                        }
                    }

                    lblMsg.Text = "Updated Successfully";
                    cmbRoot.SelectedIndex = 0;
                    cmbSocietyName.SelectedIndex = 0;
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

        protected void cmbCityCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strBranch = "";
                if (cmbCityCode.SelectedIndex != 0)
                {
                    strBranch = cmbCityCode.SelectedValue.ToString();
                    if (cmbRoot.Items.Count > 0)
                    {
                        cmbRoot.Items.Clear();
                    }
                    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "' order by exe_name;");

                    cmbRoot.Items.Add("");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
                    }

                    if (cmbSocietyName.Items.Count > 0)
                    {
                        cmbSocietyName.Items.Clear();
                    }
                    DataSet dsSocietyName;
                    MySqlCommand cmdSocietyName = new MySqlCommand("select idcenter_details,center_name from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "';");
                    dsSocietyName = objDBTask.selectData(cmdSocietyName);
                    if (dsSocietyName.Tables[0].Rows.Count > 0)
                    {
                        cmbSocietyName.Items.Add("");
                        for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
                        {
                            cmbSocietyName.Items.Add(dsSocietyName.Tables[0].Rows[i]["center_name"].ToString());
                            cmbSocietyName.Items[i + 1].Value = dsSocietyName.Tables[0].Rows[i]["idcenter_details"].ToString();
                        }
                        btnSubmit.Enabled = true;
                    }
                }
                lblMsg.Text = "";
            }
            catch (Exception)
            {
            }
        }
    }
}
