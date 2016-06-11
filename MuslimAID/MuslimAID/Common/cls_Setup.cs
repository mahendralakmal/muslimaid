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
    public class cls_Setup
    {
        cls_Connection cConnection = new cls_Connection();
        public string ComCode, ComName, Location, Address, Telephone, Fax, EMail, Web, LocName;
        public bool HoMode;
        public DateTime StartDate, EndDate;

        public bool GetCompany(string LocCode)
        {
            MySqlCommand scmCompany = new MySqlCommand();
            scmCompany.CommandText = "Select com_code,com_name,com_branchcode,com_address,com_telephone,com_fax,com_email,com_web from tblu_company where com_branchcode ='" + LocCode + "';";
            DataSet dt_Company = cConnection.GetDataSet(scmCompany);

            if (dt_Company.Tables[0].Rows.Count > 0)
            {
                ComCode = dt_Company.Tables[0].Rows[0]["COM_CODE"].ToString(); ;
                ComName = dt_Company.Tables[0].Rows[0]["COM_NAME"].ToString();
                Location = dt_Company.Tables[0].Rows[0]["COM_BRANCHCODE"].ToString();
                Address = dt_Company.Tables[0].Rows[0]["COM_ADDRESS"].ToString();
                Telephone = dt_Company.Tables[0].Rows[0]["COM_TELEPHONE"].ToString();
                Fax = dt_Company.Tables[0].Rows[0]["COM_FAX"].ToString();
                EMail = dt_Company.Tables[0].Rows[0]["COM_EMAIL"].ToString();
                Web = dt_Company.Tables[0].Rows[0]["COM_WEB"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
