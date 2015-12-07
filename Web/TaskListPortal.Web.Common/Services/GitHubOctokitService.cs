namespace TaskListPortal.Web.Common.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Octokit;

    public class GitHubOctokitService : IGitHubOctokitService
    {
        public GitHubOctokitService()
        {
        }

        public async Task<IGitHubUserInfo> GetAnonymousUserInfo(string username)
        {
            GitHubClient github = new GitHubClient(new ProductHeaderValue("user"));
            var user = await github.User.Get(username);
            IGitHubUserInfo gitHubUserInfo = new GitHubUserInfo
            {
                FullName = user.Name,
                Id = user.Id,
                GitHubUrl = user.Url,
                Location = user.Location,
                Username = user.Login
            };
            return gitHubUserInfo;
        }

        public async Task<IGitHubUserRepository> GetAnonymousUserRepository(string username, string repositoryName)
        {
            GitHubClient github = new GitHubClient(new ProductHeaderValue("user"));
            var repository = await github.Repository.Get(username, repositoryName);
            IGitHubUserRepository gitHubUserRepository = new GitHubUserRepository
            {
                Id = repository.Id,
                Name = repository.Name,
                Description = repository.Description,
                CreatedOn = repository.CreatedAt,
                UpdatedOn = repository.UpdatedAt,
                GitHubUrl = repository.HtmlUrl
            };
            return gitHubUserRepository;
        }

        public async Task<IEnumerable<IGitHubUserRepository>> GetAnonymousUserRepositories(string username)
        {
            GitHubClient github = new GitHubClient(new ProductHeaderValue("user"));
            var repositories = await github.Repository.GetAllForUser(username);
            IEnumerable<IGitHubUserRepository> gitHubUserRepositories = repositories.Select(
                x => new GitHubUserRepository
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedAt,
                    UpdatedOn = x.UpdatedAt,
                    GitHubUrl = x.HtmlUrl
                });
            return gitHubUserRepositories;
        }

        public async Task<IDictionary<string, IGitHubCommit>> GetRepositoryCommits(string username, string repositoryName)
        {
            GitHubClient github = new GitHubClient(new ProductHeaderValue("user"));
            var commits = await github.Repository.Commits.GetAll(username, repositoryName);
            IDictionary<string, IGitHubCommit> gitHubCommits = new Dictionary<string, IGitHubCommit>();
            foreach (var item in commits)
            {
                gitHubCommits.Add(item.Sha, new GitHubCommit { Sha = item.Sha, Message = item.Commit.Message, GitHubUrl = item.HtmlUrl });
            }

            return gitHubCommits;
        }
    }
}