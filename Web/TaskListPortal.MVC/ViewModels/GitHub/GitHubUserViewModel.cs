namespace TaskListPortal.MVC.ViewModels.GitHub
{
    using TaskListPortal.Web.Common.Mapping;
    using TaskListPortal.Web.Common.Services;

    public class GitHubUserViewModel : IMapFrom<IGitHubUserInfo>
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string GitHubUrl { get; set; }

        public string FullName { get; set; }

        public string Location { get; set; }
    }
}