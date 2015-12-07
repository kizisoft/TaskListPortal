namespace TaskListPortal.WebApi
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using TaskListPortal.Web.Common.Mapping;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings(Assembly.GetExecutingAssembly());
        }
    }
}