using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace MuslimAID
{
    public class cls_Connection
    {
        private static MySqlConnection connect = null;

        //Get Connection
        public static MySqlConnection DBConnect()
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                //con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.ConnectionString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
                return con;
            }
            catch (MySqlException mye)
            {
                //error.createErrorLog(mye.Message, mye.Source, "MySQL Error");
                return null;
            }
            catch (Exception e)
            {
                //error.createErrorLog(e.Message, e.Source, "Data Connection Error");
                return null;
            }
        }

        //Set Data by String
        public static void setData(String q)
        {
            MySqlCommand com;
            MySqlDataReader dr;
            connect = cls_Connection.DBConnect();
            try
            {
                connect.Open();
                com = new MySqlCommand(q);
                com.Connection = connect;
                dr = com.ExecuteReader();

                if (dr.RecordsAffected > 0)
                {
                    // MessageBox.Show("Record Successfuly Saved");
                }
                closeConnection();
            }
            catch (MySqlException mye)
            {
                //error.createErrorLog(mye.Message, mye.Source, "MySQL Error");
                closeConnection();
            }
            catch (Exception e)
            {
                //error.createErrorLog(e.Message, e.Source, "Data Sending Error");
                closeConnection();
            }
        }

        public int insertEditData(MySqlCommand cmdQRY)
        {
            try
            {
                int i;
                MySqlConnection mySqlCon = cls_Connection.DBConnect();

                cmdQRY.Connection = mySqlCon;

                mySqlCon.Open();
                i = cmdQRY.ExecuteNonQuery();
                mySqlCon.Close();

                return i;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Set My Sql Data Reader by String
        public static MySqlDataReader getData(String q)
        {
            MySqlCommand com;
            MySqlDataReader dr;
            connect = cls_Connection.DBConnect();
            try
            {
                connect.Open();
                com = new MySqlCommand(q);
                com.Connection = connect;
                dr = com.ExecuteReader();
                return dr;
            }
            catch (MySqlException mye)
            {
                //error.createErrorLog(mye.Message, mye.Source, "MySQL Error");
                closeConnection();
                return null;
            }
            catch (Exception e)
            {
                //error.createErrorLog(e.Message, e.Source, "Data Downloading Error");
                closeConnection();
                return null;
            }
        }

        //Get Dataset by String
        public static DataSet getDataSet(String q)
        {
            MySqlCommand com;
            MySqlDataAdapter da;
            DataSet ds;
            connect = cls_Connection.DBConnect();
            try
            {
                connect.Open();
                com = new MySqlCommand(q);
                com.Connection = connect;
                da = new MySqlDataAdapter(com);
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (MySqlException mye)
            {
                //error.createErrorLog(mye.Message, mye.Source, "MySQL Error");
                closeConnection();
                return null;
            }
            catch (Exception e)
            {
                //error.createErrorLog(e.Message, e.Source, "Data Downloading Error");
                closeConnection();
                return null;
            }
        }

        //Get Dataset by Command
        public DataSet GetDataSet(MySqlCommand SqlCmd)
        {
            DataSet SqlDS = new DataSet();
            try
            {
                SqlCmd.Connection = DBConnect();
                MySqlDataAdapter Sqldap = new MySqlDataAdapter(SqlCmd);
                Sqldap.Fill(SqlDS);
                return SqlDS;
            }
            catch (Exception Ex)
            {
                //throw Ex;
                return null;
            }
        }

        public DataSet selectData(MySqlCommand cmdQRY)
        {
            try
            {
                MySqlConnection mySqlCon = DBConnect();
                cmdQRY.Connection = mySqlCon;
                MySqlDataAdapter daData = new MySqlDataAdapter(cmdQRY);
                DataSet dsData = new DataSet();
                mySqlCon.Open();
                daData.Fill(dsData);
                mySqlCon.Close();
                return dsData;
            }
            catch (Exception ex)
            {
                //objCommonTasks.createErrorLog(DateTime.Now, ex.Message, ex.Source, cmdQRY.CommandText);
                return null;
            }
        }

        //Close Connection
        public static void closeConnection()
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
                connect.Dispose();
            }
        }

        //Login Validation
        public Boolean loginValidation(string strNIC, string strPassword)
        {
            DataSet dsAuthLogin = new DataSet();

            strPassword = EncodePasswordToBase64(strPassword);
            MySqlCommand cmdAuthUser = new MySqlCommand("select * from tblu_users where nic = @NIC and user_password = @Password;");
            cmdAuthUser.Parameters.Add("@NIC", MySqlDbType.VarChar, 10);
            cmdAuthUser.Parameters.Add("@Password", MySqlDbType.VarChar, 10);
            cmdAuthUser.Parameters["@NIC"].Value = strNIC;
            cmdAuthUser.Parameters["@Password"].Value = strPassword;

            dsAuthLogin = selectData(cmdAuthUser);

            if (dsAuthLogin.Tables[0].Rows.Count > 0)
            {
                //ADD MAIN SESSION VARIABLES
                //Session["LoggedIn"] = "True";
                //Session["NIC"] = dsAuthLogin.Tables[0].Rows[0]["nic"].ToString();
                //Session["Branch"] = dsAuthLogin.Tables[0].Rows[0]["branch_code"].ToString();
                //Session["UserType"] = dsAuthLogin.Tables[0].Rows[0]["user_type"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Encode Password To Base 64
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}
