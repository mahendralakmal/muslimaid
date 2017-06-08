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
                    cmbCityCode.Items.Add("Select Branch");
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

                    cmbRoot.Items.Add("Select Branch");

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
                    lblMsg.Text = "Please select branch.";
                }
                else if (cmbArea.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select branch.";
                }
                else if (cmbVillage.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select branch.";
                }
                else if (cmbSocietyName.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select Center.";
                }
                else if (cmbRoot.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select MFO.";
                }
                else if (cmbChangeMfo.SelectedIndex == 0)
                {
                    lblMsg.Text = "Please select Change MFO.";
                }
                else
                {
                    string root = cmbChangeMfo.SelectedItem.Value;
                    MySqlCommand cmdUpdateCenter = new MySqlCommand("UPDATE center_details SET exective = '" + root + "' WHERE idcenter_details = '" + cmbSocietyName.SelectedValue + "' AND city_code = '" + cmbCityCode.SelectedValue + "' AND area_code = '" + cmbArea.SelectedValue.ToString() + "' AND villages = '" + cmbVillage.SelectedValue.ToString() + "';");
                    int i;
                    i = objDBTask.insertEditData(cmdUpdateCenter);

                    DataSet dsGetLoan = cls_Connection.getDataSet("select contract_code,society_id,city_code,idmicro_basic_detail from micro_basic_detail where city_code = '" + cmbCityCode.SelectedItem.Value + "' and society_id = '" + cmbSocietyName.SelectedValue + "' AND area_code = '" + cmbArea.SelectedValue.ToString() + "' AND village = '" + cmbVillage.SelectedValue.ToString() + "';");

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
            lblMsg.Text = "";
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
                        btnSubmit.Enabled = true;

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
                        btnSubmit.Enabled = false;
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    string strBranch = cmbCityCode.SelectedItem.Value;

                    DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "';");
                    if (cmbChangeMfo.Items.Count > 0)
                    {
                        cmbChangeMfo.Items.Clear();
                    }
                    cmbChangeMfo.Items.Add("Select MFO to Change");

                    for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
                    {
                        cmbChangeMfo.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbChangeMfo.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
                    }
                    cmbChangeMfo.Enabled = true;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                lblMsg.Text = "Please chose city code.";
                btnSubmit.Enabled = false;
            }
            #region commented
            //try
            //{
            //    string strBranch = "";
            //    if (cmbCityCode.SelectedIndex != 0)
            //    {
            //        strBranch = cmbCityCode.SelectedValue.ToString();
            //        if (cmbRoot.Items.Count > 0)
            //        {
            //            cmbRoot.Items.Clear();
            //        }
            //        DataSet dsGetRootID = cls_Connection.getDataSet("select exe_id,exe_name from micro_exective_root where branch_code = '" + strBranch + "' order by exe_name;");

            //        cmbRoot.Items.Add("");

            //        for (int i = 0; i < dsGetRootID.Tables[0].Rows.Count; i++)
            //        {
            //            cmbRoot.Items.Add("[" + dsGetRootID.Tables[0].Rows[i]["exe_id"] + "] - " + dsGetRootID.Tables[0].Rows[i]["exe_name"].ToString());
            //            cmbRoot.Items[i + 1].Value = dsGetRootID.Tables[0].Rows[i]["exe_id"].ToString();
            //        }

            //        if (cmbSocietyName.Items.Count > 0)
            //        {
            //            cmbSocietyName.Items.Clear();
            //        }
            //        DataSet dsSocietyName;
            //        MySqlCommand cmdSocietyName = new MySqlCommand("select idcenter_details,center_name from center_details where city_code = '" + cmbCityCode.SelectedItem.Value + "';");
            //        dsSocietyName = objDBTask.selectData(cmdSocietyName);
            //        if (dsSocietyName.Tables[0].Rows.Count > 0)
            //        {
            //            cmbSocietyName.Items.Add("");
            //            for (int i = 0; i < dsSocietyName.Tables[0].Rows.Count; i++)
            //            {
            //                cmbSocietyName.Items.Add(dsSocietyName.Tables[0].Rows[i]["center_name"].ToString());
            //                cmbSocietyName.Items[i + 1].Value = dsSocietyName.Tables[0].Rows[i]["idcenter_details"].ToString();
            //            }
            //            btnSubmit.Enabled = true;
            //        }
            //    }
            //    lblMsg.Text = "";
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
                    btnSubmit.Enabled = false;
                }
                else if (cmbArea.SelectedIndex < 0)
                {
                    lblMsg.Text = "Please chose village name.";
                    btnSubmit.Enabled = false;
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
                        btnSubmit.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
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
                        cmbSocietyName.Items.Clear();
                        if (dsSCenter.Tables[0].Rows.Count > 0)
                        {
                            cmbSocietyName.Items.Add("Select Center");

                            for (int i = 0; i < dsSCenter.Tables[0].Rows.Count; i++)
                            {
                                cmbSocietyName.Items.Add(dsSCenter.Tables[0].Rows[i]["center_name"].ToString());
                                cmbSocietyName.Items[i + 1].Value = dsSCenter.Tables[0].Rows[i]["idcenter_details"].ToString();
                            }
                        }
                        cmbSocietyName.Enabled = true;
                        //Edit 2014.09.18 CACode
                        //CACodeNew();
                        cmbRoot.SelectedValue = dsGetSocietyID.Tables[0].Rows[0]["exective"].ToString();
                        btnSubmit.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "Invalid City Code or Society Name.";
                        btnSubmit.Enabled = false;
                    }
                }
                else
                {
                    lblMsg.Text = "Please select city code or Society Name.";
                    btnSubmit.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void cmbSocietyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataSet dsCenter = cls_Connection.getDataSet("SELECT exe_id, exe_name FROM center_details c, micro_exective_root e WHERE c.city_code = '" + cmbCityCode.SelectedValue.ToString() + "' AND c.area_code = '" + cmbArea.SelectedValue.ToString() + "' AND c.villages = '" + cmbVillage.SelectedValue.ToString() + "' AND c.idcenter_details = " + cmbSocietyName.SelectedValue.ToString() + " AND e.exe_id = c.exective AND e.branch_code = c.city_code;");

                cmbRoot.Items.Clear();
                if (dsCenter.Tables[0].Rows.Count > 0)
                {
                    cmbRoot.Items.Add("Select Root");
                    for (int i = 0; i < dsCenter.Tables[0].Rows.Count; i++)
                    {
                        cmbRoot.Items.Add(dsCenter.Tables[0].Rows[i]["exe_name"].ToString());
                        cmbRoot.Items[i + 1].Value = dsCenter.Tables[0].Rows[i]["exe_id"].ToString();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
