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
    public partial class salam_income_source_3 : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        cls_ErrorLog error = new cls_ErrorLog();

        protected void clear()
        {
            income_source_1.SelectedIndex = 0;
            income_source_2.SelectedIndex = 0;
            income_source_3.Text = "";
        }
        protected void get_income_type_2(int param)
        {
            DataSet dsINS;
            MySqlCommand cmdinsource = new MySqlCommand("SELECT * FROM salam_income_type_2 where income_type_1 = '" + param + "';");

            income_source_2.Items.Clear();
            income_source_2.Items.Add("Select Income Source 2");
            dsINS = objDBTask.selectData(cmdinsource);
            if (dsINS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsINS.Tables[0].Rows.Count; i++)
                {
                    income_source_2.Items.Add(dsINS.Tables[0].Rows[i][1].ToString());
                    income_source_2.Items[i + 1].Value = dsINS.Tables[0].Rows[i][0].ToString();
                }
            }
        }

        protected void get_income_type_1()
        {
            DataSet dsINS;
            MySqlCommand cmdinsource = new MySqlCommand("SELECT * FROM salam_income_type_1;");
            dsINS = objDBTask.selectData(cmdinsource);
            if (dsINS.Tables[0].Rows.Count > 0)
            {
                income_source_1.Items.Add("Select Income Source 1");

                for (int i = 0; i < dsINS.Tables[0].Rows.Count; i++)
                {
                    income_source_1.Items.Add(dsINS.Tables[0].Rows[i][1].ToString());
                    income_source_1.Items[i + 1].Value = dsINS.Tables[0].Rows[i][0].ToString();
                }
            }
        }

        protected void initial_load()
        {
            DataSet dsBranch;
            MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM salam_income_type_3 in3, salam_income_type_2 in2 where in3.income_type_2 = in2.income_2_id;");
            dsBranch = objDBTask.selectData(cmdBranch);
            if (dsBranch.Tables[0].Rows.Count > 0)
            {
                gv_income_source.DataSource = dsBranch;
                gv_income_source.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"].ToString() == "True")
            {

                if (!this.IsPostBack)
                {
                    //GetDate();
                    string strBranch = Session["Branch"].ToString();
                    string strUserType = Session["UserType"].ToString();

                    if (strUserType == "Top Managment")
                    {
                        initial_load();
                        get_income_type_1();
                        income_source_2.Items.Add("Select Income Source 2");
                    }
                    else
                    {
                        Response.Redirect("../SALAM/salam.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void income_source_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (income_source_1.SelectedIndex != 0)
            {
                get_income_type_2(Convert.ToInt32(income_source_1.SelectedValue));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (income_source_1.SelectedIndex != 0)
                {
                    if (income_source_2.Text.Trim() != "")
                    {
                        DataSet dsBranch;
                        string q = "SELECT * FROM salam_income_type_3 WHERE income_type_3 = '" + income_source_3.Text.Trim().ToLower() + "' AND income_type_2 = '" + income_source_2.SelectedValue.ToString() + "';";
                        MySqlCommand cmdBranch = new MySqlCommand(q);
                        dsBranch = objDBTask.selectData(cmdBranch);
                        if (dsBranch.Tables[0].Rows.Count > 0)
                        {
                            lblMsg.Text = "The income source type you entered is already exists...!";
                        }
                        else
                        {
                            MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO salam_income_type_3 (income_type_3, income_type_2) VALUES (@income_type_3, @income_type_2);");

                            cmdInsert.Parameters.AddWithValue("@income_type_3", income_source_3.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@income_type_2", income_source_2.SelectedValue.ToString());
                            if (objDBTask.insertEditData(cmdInsert) == 1)
                            {
                                lblMsg.Text = "Successfully Added...!";
                                initial_load();
                                clear();
                            }
                            else
                            {
                                lblMsg.Text = "Error Occured...!";
                            }
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Please input income source type 2";
                    }
                }
                else
                {
                    lblMsg.Text = "Please select income source 1";
                }
            }
            catch (Exception ex)
            {
                error.createErrorLog(ex.Message, ex.Source, "Create Income source 2");
            }
        }
    }
}
