namespace TaskListPortal.Web.Common.Services
{
    public class GitHubCommit : IGitHubCommit
    {
        public string Sha { get; set; }

        public string Message { get; set; }

        public string GitHubUrl { get; set; }
    }
}