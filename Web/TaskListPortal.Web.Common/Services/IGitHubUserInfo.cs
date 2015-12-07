namespace TaskListPortal.Web.Common.Services
{
    public interface IGitHubUserInfo
    {
        int Id { get; set; }

        string Username { get; set; }

        string GitHubUrl { get; set; }

        string FullName { get; set; }

        string Location { get; set; }
    }
}