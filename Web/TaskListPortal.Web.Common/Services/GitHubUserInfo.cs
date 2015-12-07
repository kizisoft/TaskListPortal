namespace TaskListPortal.Web.Common.Services
{
    public class GitHubUserInfo : IGitHubUserInfo
    {
        public string FullName { get; set; }

        public string GitHubUrl { get; set; }

        public int Id { get; set; }

        public string Location { get; set; }

        public string Username { get; set; }
    }
}