namespace TaskListPortal.Web.Common.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGitHubOctokitService
    {
        Task<IGitHubUserInfo> GetAnonymousUserInfo(string username);

        Task<IGitHubUserRepository> GetAnonymousUserRepository(string username, string repositoryName);

        Task<IEnumerable<IGitHubUserRepository>> GetAnonymousUserRepositories(string username);

        Task<IDictionary<string, IGitHubCommit>> GetRepositoryCommits(string username, string repositoryName);
    }
}