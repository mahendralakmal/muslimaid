using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;


namespace MuslimAID
{
    public class cls_ErrorLog : System.Web.UI.Page
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

        public static void createSErrorLog(string strException, string strSource, string strOther)
        {
            //DateTime strDateTime = DateTime.Now;
            //String Path = Server.MapPath(@"\ErrorLogs");
            //if (!Directory.Exists(Path))
            //{
            //    Directory.CreateDirectory(Path);
            //}

            //if (File.Exists(Path + "\\ErrorLog-" + strDateTime.ToString("yyyy-MM-dd") + ".txt"))
            //{
            //    StreamWriter sw = new StreamWriter(Path + "\\ErrorLog-" + strDateTime.ToString("yyyy-MM-dd") + ".txt");
            //    sw.WriteLine("=============================================================");
            //    sw.WriteLine("Time      : " + strDateTime.ToString("yyyy-MM-dd hh:mm:ss tt"));
            //    sw.WriteLine("");
            //    sw.WriteLine("Exception : " + strException);
            //    sw.WriteLine("");
            //    sw.WriteLine("Source    : " + strSource);
            //    sw.WriteLine("");
            //    sw.WriteLine("Other     : " + strOther);
            //    sw.WriteLine("");
            //    sw.WriteLine("=============================================================");
            //    sw.Flush();
            //    sw.Close();
            //}
            //else
            //{

            //    StreamWriter sw = new StreamWriter(Path + "\\ErrorLog-" + strDateTime.ToString("yyyy-MM-dd") + ".txt");
            //    sw.WriteLine("=============================================================");
            //    sw.WriteLine("Time      : " + strDateTime.ToString("yyyy-MM-dd hh:mm:ss tt"));
            //    sw.WriteLine("");
            //    sw.WriteLine("Exception : " + strException);
            //    sw.WriteLine("");
            //    sw.WriteLine("Source    : " + strSource);
            //    sw.WriteLine("");
            //    sw.WriteLine("Other     : " + strOther);
            //    sw.WriteLine("");
            //    sw.WriteLine("=============================================================");
            //    sw.Flush();
            //    sw.Close();
            //}
        }
    }
}