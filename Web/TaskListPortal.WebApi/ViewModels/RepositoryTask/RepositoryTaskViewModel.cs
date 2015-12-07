namespace TaskListPortal.WebApi.ViewModels.RepositoryTask
{
    using System;
    using System.Collections.Generic;
    using TaskListPortal.Models;
    using TaskListPortal.Web.Common.Mapping;
    using TaskListPortal.WebApi.ViewModels.Comment;

    public class RepositoryTaskViewModel : IMapFrom<RepositoryTask>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public string Description { get; set; }

        public string RepositoryName { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}