using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IchiPaint.Common;

namespace IchiPaint
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ConfigInfo.GetConfig();
        }
    }
}