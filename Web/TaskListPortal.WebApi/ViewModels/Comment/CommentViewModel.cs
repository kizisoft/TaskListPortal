namespace TaskListPortal.WebApi.ViewModels.Comment
{
    using System;
    using TaskListPortal.Models;
    using TaskListPortal.Web.Common.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}