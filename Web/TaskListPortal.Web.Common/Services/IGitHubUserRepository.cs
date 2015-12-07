namespace TaskListPortal.Web.Common.Services
{
    using System;

    public interface IGitHubUserRepository
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        DateTimeOffset CreatedOn { get; set; }

        DateTimeOffset UpdatedOn { get; set; }

        string GitHubUrl { get; set; }
    }
}