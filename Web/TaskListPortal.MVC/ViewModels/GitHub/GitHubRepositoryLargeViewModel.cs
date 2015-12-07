namespace TaskListPortal.MVC.ViewModels.GitHub
{
    using System;
    using TaskListPortal.Web.Common.Mapping;
    using TaskListPortal.Web.Common.Services;

    public class GitHubRepositoryLargeViewModel : GitHubRepositoryShortViewModel, IMapFrom<IGitHubUserRepository>
    {
        public string Description { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public string GitHubUrl { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}