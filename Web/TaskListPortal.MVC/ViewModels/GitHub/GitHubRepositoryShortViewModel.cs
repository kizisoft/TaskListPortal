namespace TaskListPortal.MVC.ViewModels.GitHub
{
    using TaskListPortal.Web.Common.Mapping;
    using TaskListPortal.Web.Common.Services;

    public class GitHubRepositoryShortViewModel : IMapFrom<IGitHubUserRepository>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}