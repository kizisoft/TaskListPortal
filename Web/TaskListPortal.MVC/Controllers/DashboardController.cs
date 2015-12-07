namespace TaskListPortal.MVC.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using TaskListPortal.MVC.ViewModels.GitHub;
    using TaskListPortal.Web.Common.Identity;
    using TaskListPortal.Web.Common.Services;

    public class DashboardController : BaseController
    {
        private readonly ICurrentUser user;
        private readonly IGitHubOctokitService gitHubOctokitService;

        public DashboardController(ICurrentUser user, IGitHubOctokitService gitHubOctokitService)
        {
            this.user = user;
            this.gitHubOctokitService = gitHubOctokitService;
        }

        public async Task<ActionResult> Index()
        {
            var loggedUser = this.user.Get();
            var repositories = await this.gitHubOctokitService.GetAnonymousUserRepositories(loggedUser.GitHubUsername);
            var model = repositories.AsQueryable().ProjectTo<GitHubRepositoryShortViewModel>().ToList();
            return this.View(model);
        }
    }
}