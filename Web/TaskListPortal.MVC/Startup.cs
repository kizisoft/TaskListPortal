using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskListPortal.MVC.Startup))]

namespace TaskListPortal.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}