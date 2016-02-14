using System.Reflection;
using System.Web.Http;
using GiftBox.Web.Infrastructure.Mapping;

namespace GiftBox.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using GiftBox.Web.App_Start;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            (new ViewEnginesConfig()).RegisterViewEngines();
            (new AutoMapperConfig(Assembly.GetExecutingAssembly())).Execute();
           
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DatabaseConfig.Initialize();
        }
    }
}
