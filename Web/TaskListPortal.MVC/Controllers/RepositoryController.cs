namespace TaskListPortal.MVC.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using AutoMapper;
    using TaskListPortal.MVC.ViewModels.GitHub;
    using TaskListPortal.Web.Common.Identity;
    using TaskListPortal.Web.Common.Services;

    public class RepositoryController : BaseController
    {
        private readonly ICurrentUser user;
        private readonly IGitHubOctokitService gitHubOctokitService;

        public RepositoryController(ICurrentUser user, IGitHubOctokitService gitHubOctokitService)
        {
            this.user = user;
            this.gitHubOctokitService = gitHubOctokitService;
        }

        public async Task<ActionResult> Index(string name)
        {
            var loggedUser = this.user.Get();
            IGitHubUserRepository repository;
            try
            {
                repository = await this.gitHubOctokitService.GetAnonymousUserRepository(loggedUser.GitHubUsername, name);
            }
            catch (Exception)
            {
                return this.HttpNotFound(string.Format("Repository [{0}] does not exist!", name));
            }

            var model = Mapper.Map<GitHubRepositoryLargeViewModel>(repository);
            model.AuthorId = loggedUser.Id;
            model.AuthorName = loggedUser.GitHubUsername;
            return this.View(model);
        }
    }
}