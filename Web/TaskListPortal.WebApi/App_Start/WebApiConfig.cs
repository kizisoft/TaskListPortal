namespace TaskListPortal.WebApi
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/repos/{repoName}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
               name: "CommentApi",
               routeTemplate: "api/repos/{repoName}/task/{taskId}/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional });
        }
    }
}