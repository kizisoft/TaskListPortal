namespace TaskListPortal.MVC.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using AutoMapper;
    using TaskListPortal.MVC.ViewModels.GitHub;
    using TaskListPortal.Web.Common.Identity;
    using TaskListPortal.Web.Common.Services;

    public class HomeController : BaseController
    {
        private readonly ICurrentUser user;
        private readonly IGitHubOctokitService gitHubOctokitService;

        public HomeController(ICurrentUser user, IGitHubOctokitService gitHubOctokitService)
        {
            this.user = user;
            this.gitHubOctokitService = gitHubOctokitService;
        }

        [OutputCache(Duration = 10 * 60, VaryByCustom = "User")]
        public async Task<ActionResult> Index()
        {
            var loggedUser = this.user.Get();
            IGitHubUserInfo gitHubUserInfo;
            try
            {
                gitHubUserInfo = await this.gitHubOctokitService.GetAnonymousUserInfo(loggedUser.GitHubUsername);
            }
            catch (Exception)
            {
                return this.HttpNotFound(string.Format("GitHub username [{0}] does not exist!", loggedUser.GitHubUsername));
            }

            var model = Mapper.Map<GitHubUserViewModel>(gitHubUserInfo);
            return this.View(model);
        }
    }
}