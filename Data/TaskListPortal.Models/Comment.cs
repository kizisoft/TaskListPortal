namespace TaskListPortal.Models
{
    using System;
    using TaskListPortal.Common.Models;

    public class Comment : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int RepositoryTaskId { get; set; }

        public virtual RepositoryTask RepositoryTask { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}