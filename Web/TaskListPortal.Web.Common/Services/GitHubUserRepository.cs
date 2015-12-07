namespace TaskListPortal.Web.Common.Services
{
    using System;

    public class GitHubUserRepository : IGitHubUserRepository
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public string GitHubUrl { get; set; }
    }
}