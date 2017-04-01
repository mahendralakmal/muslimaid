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
    public partial class salam_income_source_1 : System.Web.UI.Page
    {
        cls_CommonFunctions objCommonTask = new cls_CommonFunctions();
        cls_Connection objDBTask = new cls_Connection();
        cls_ErrorLog error = new cls_ErrorLog();

        protected void clear()
        {
            income_type_1.Text = "";
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

        protected void initial_load() {
            DataSet dsBranch;
            MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM salam_income_type_1;");
            dsBranch = objDBTask.selectData(cmdBranch);
            if (dsBranch.Tables[0].Rows.Count > 0)
            {
                gv_income_source.DataSource = dsBranch;
                gv_income_source.DataBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try {
                if (income_type_1.Text.Trim() != "")
                {
                    DataSet dsBranch;
                    MySqlCommand cmdBranch = new MySqlCommand("SELECT * FROM salam_income_type_1 WHERE income_type LIKE '%" + income_type_1.Text.Trim().ToLower() + "%';");
                    dsBranch = objDBTask.selectData(cmdBranch);
                    if (dsBranch.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "The income source type you entered is already exists...!";
                    }
                    else
                    {
                        MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO salam_income_type_1 (income_type) VALUES (@income_type);");

                        cmdInsert.Parameters.AddWithValue("@income_type", income_type_1.Text.Trim());
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
                    lblMsg.Text = "Please Enter Income source";
                }
            }
            catch (Exception ex)
            {
                error.createErrorLog(ex.Message, ex.Source, "Insert income source type 1");
            }
        }
    }
}
