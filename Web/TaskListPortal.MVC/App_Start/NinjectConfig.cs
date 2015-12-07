[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TaskListPortal.MVC.App_Start.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TaskListPortal.MVC.App_Start.NinjectConfig), "Stop")]

namespace TaskListPortal.MVC.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Security.Principal;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using TaskListPortal.Common.Repository;
    using TaskListPortal.Data;
    using TaskListPortal.Web.Common.Identity;
    using TaskListPortal.Web.Common.Services;

    public static class NinjectConfig
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<TaskListPortalDbContext>().InRequestScope();
            kernel.Bind(typeof(IDbRepository<>)).To(typeof(DbRepository<>));
            kernel.Bind<IIdentity>().ToMethod(c => HttpContext.Current.User.Identity);
            kernel.Bind<ICurrentUser>().To<CurrentUser>().InRequestScope();
            kernel.Bind<IGitHubOctokitService>().To<GitHubOctokitService>();
        }
    }
}