using System;
using System.Configuration;
using System.IO;
using System.Web;
using IchiPaint.Models;

namespace IchiPaint.Common
{
    public class DataMemory
    {
        public static PhongThuy PhongThuy { get; set; }


        public static User CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["UserInfo"] == null)
                    return null;
                else
                    return (User)HttpContext.Current.Session["UserInfo"];
            }
            set => HttpContext.Current.Session["UserInfo"] = value;
        }

        public static EmailInfo EmailOriginal { get; set; }

    }

    public class ConfigInfo
    {
        public static string BaseUrl { get; set; }
        public static string BaseDir { get; set; }
        public static string ConnectString { get; set; }
        public static int RecordOnPage = 10;
        public static int RecordOnPageIndex = 5;
        public static string ProductTemplate { get; set; }

        public static string EmailTemplate { get; set; }
        public static void GetConfig()
        {
            try
            {
                BaseDir = ConfigurationManager.AppSettings.Get("BaseDir");
                BaseUrl = ConfigurationManager.AppSettings.Get("BaseUrl");
                RecordOnPage = Convert.ToInt32(ConfigurationManager.AppSettings.Get("RecordOnPage"));
                RecordOnPageIndex = Convert.ToInt32(ConfigurationManager.AppSettings.Get("RecordOnPageIndex"));
                ConnectString = ConfigurationManager.AppSettings.Get("ConnectString");

                var fileTemplate = HttpRuntime.AppDomainAppPath + "\\Template\\Product.html";
                ProductTemplate = File.ReadAllText(fileTemplate);

                fileTemplate = HttpRuntime.AppDomainAppPath + "\\Template\\Menh.xls";
                DataMemory.PhongThuy = new PhongThuy(fileTemplate);

                fileTemplate = HttpRuntime.AppDomainAppPath + "\\Template\\DangKyTuVan.html";
                EmailTemplate = File.ReadAllText(fileTemplate);

                DataMemory.EmailOriginal = new EmailInfo()
                {
                    Host = ConfigurationManager.AppSettings.Get("EMailHost"),
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("EmailPost")),
                    Name = ConfigurationManager.AppSettings.Get("EMailFrom"),
                    EmailCC = ConfigurationManager.AppSettings.Get("EMailCC"),
                    PassWord = ConfigurationManager.AppSettings.Get("EMailPass"),
                    DisplayName = ConfigurationManager.AppSettings.Get("DisplayName"),
                    IsSsl = ConfigurationManager.AppSettings.Get("SSL") == "Y"
                };


            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                throw;
            }
        }
    }

    public class Logger
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}