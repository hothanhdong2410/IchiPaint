using System;
using System.Configuration;
using System.IO;
using System.Web;
using IchiPaint.Models;
using System.Collections.Generic;
using IchiPaint.DataAccess;
using System.Data;
using System.Linq;

namespace IchiPaint.Common
{
    public class DataMemory
    {
        public static List<News> c_lstNew = new List<News>();
        public static List<Project> c_lstProject = new List<Project>();
        public static List<Page> c_lstPage = new List<Page>();
        
        public static void LoadDbMem()
        {
            try
            {
                LoadNews();

                LoadProject();

                LoadPage();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }

        public static void LoadNews()
        {
            try
            {
                NewsDA _newsDa = new NewsDA();

                var portalSearchNews = new PortalSearchNewsIndex
                {
                    Start = 1,
                    End = 0,
                    Id = 0
                };
                var pTotal = 0;
                var ds = _newsDa.GetForPortalDetail(portalSearchNews, ref pTotal);

                c_lstNew = CBO<News>.FillCollectionFromDataSet(ds);
                c_lstNew = c_lstNew.OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }

        public static void LoadProject()
        {
            try
            {
                var request = new SearchProjectRequest
                {
                    Start = 1,
                    End = 0
                };
                var pTotal = 0;
                ProjectDa _ProjectDa = new ProjectDa();
                DataSet ds = _ProjectDa.Search(request,ref pTotal);
                c_lstProject = CBO<Project>.FillCollectionFromDataSet(ds);
                c_lstProject = c_lstProject.OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }

        public static void LoadPage()
        {
            try
            {
                var request = new SearchProjectRequest
                {
                    Start = 1,
                    End = 0
                };
                var pTotal = 0;
                PageDA _da = new PageDA();
                DataSet ds = _da.Search(request, ref pTotal);
                c_lstPage = CBO<Page>.FillCollectionFromDataSet(ds);
                c_lstPage = c_lstPage.OrderByDescending(m => m.Id).ToList();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }


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
            set
            {
                HttpContext.Current.Session["UserInfo"] = value;
            }
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
        public static string ContactPhone { get; set; }
        public static string EmailBusiness { get; set; }

        public static void GetConfig()
        {
            try
            {
                BaseDir = ConfigurationManager.AppSettings.Get("BaseDir");
                BaseUrl = ConfigurationManager.AppSettings.Get("BaseUrl");
                RecordOnPage = Convert.ToInt32(ConfigurationManager.AppSettings.Get("RecordOnPage"));
                RecordOnPageIndex = Convert.ToInt32(ConfigurationManager.AppSettings.Get("RecordOnPageIndex"));
                ConnectString = ConfigurationManager.AppSettings.Get("ConnectString");
                EmailBusiness = ConfigurationManager.AppSettings.Get("EmailBusiness");
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

                ContactPhone = ConfigurationManager.AppSettings.Get("ContactPhone");
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }
    }

    public class Logger
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}