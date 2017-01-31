using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace MuslimAID.Common
{
    public class ErrorLog : System.Web.UI.Page
    {
        IFormatProvider frmt = new CultureInfo("en-US", true);
        public void createErrorLog(string strException, string strSource, string strOther)
        {
            DateTime strDateTime = DateTime.Now;
            String Path = Server.MapPath(@"\ErrorLogs");
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            // StreamWriter sw = new StreamWriter(Server.MapPath("ErrorLog\\ErrorLog-" + dtDateTime.ToString("yyyy-MM-dd hh.mm.ss.tt") + ".txt")); ajTest
            if (File.Exists(Path + "\\ErrorLog-" + strDateTime.ToString("yyyy-MM-dd") + ".txt"))
            {
                StreamWriter sw = new StreamWriter(Path + "\\ErrorLog-" + strDateTime.ToString("yyyy-MM-dd") + ".txt");
                sw.WriteLine("=============================================================");
                sw.WriteLine("Time      : " + strDateTime.ToString("yyyy-MM-dd hh:mm:ss tt"));
                sw.WriteLine("");
                sw.WriteLine("Exception : " + strException);
                sw.WriteLine("");
                sw.WriteLine("Source    : " + strSource);
                sw.WriteLine("");
                sw.WriteLine("Other     : " + strOther);
                sw.WriteLine("");
                sw.WriteLine("=============================================================");
                sw.Flush();
                sw.Close();
            }
            else
            {
                //Stream s = new FileStream("ErrorLog\\ErrorLog-" + strDateTime.ToString("yyyy-MM-dd") + ".txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(Path + "\\ErrorLog-" + strDateTime.ToString("yyyy-MM-dd") + ".txt");
                sw.WriteLine("=============================================================");
                sw.WriteLine("Time      : " + strDateTime.ToString("yyyy-MM-dd hh:mm:ss tt"));
                sw.WriteLine("");
                sw.WriteLine("Exception : " + strException);
                sw.WriteLine("");
                sw.WriteLine("Source    : " + strSource);
                sw.WriteLine("");
                sw.WriteLine("Other     : " + strOther);
                sw.WriteLine("");
                sw.WriteLine("=============================================================");
                sw.Flush();
                sw.Close();
            }
        }
    }
}