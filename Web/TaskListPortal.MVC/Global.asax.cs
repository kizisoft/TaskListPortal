namespace TaskListPortal.MVC
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using TaskListPortal.MVC.App_Start;
    using TaskListPortal.Web.Common.Mapping;

    public class MvcApplication : HttpApplication
    {
        private const string CookieName = ".AspNet.ApplicationCookie";

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom.Equals("User", StringComparison.InvariantCultureIgnoreCase))
            {
                var cookie = context.Request.Cookies[CookieName];
                return cookie != null ? cookie.Value : null;
            }

            return base.GetVaryByCustomString(context, custom);
        }

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