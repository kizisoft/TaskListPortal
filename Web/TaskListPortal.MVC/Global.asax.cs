namespace TaskListPortal.MVC
{
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using TaskListPortal.MVC.App_Start;
    using TaskListPortal.Web.Common.Mapping;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEnginesConfig.RegisterEngines(ViewEngines.Engines);
            AutoMapperConfig.RegisterMappings(Assembly.GetExecutingAssembly());
        }
    }
}