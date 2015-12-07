namespace TaskListPortal.Web.Common.Services
{
    public interface IGitHubCommit
    {
        string Sha { get; set; }

        string Message { get; set; }

        string GitHubUrl { get; set; }
    }
}