using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyLibraryApi
{
    using DataMaster.DbConnection;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetConnection();
        }

        private void SetConnection()
        {
            SqlCommander.DatabaseServer = "den1.mssql4.gear.host";
            SqlCommander.DatabasUserId = "mylibrarydata";
            SqlCommander.DatabasePassword = "Fq9m?1a?5WG3";
            SqlCommander.DatabaseName = "mylibrarydata";
        }
    }
}
