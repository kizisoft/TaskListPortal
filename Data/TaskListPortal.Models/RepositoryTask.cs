namespace TaskListPortal.Models
{
    using System;
    using System.Collections.Generic;
    using TaskListPortal.Common.Models;

    public class RepositoryTask : IAuditInfo, IDeletableEntity
    {
        private ICollection<Comment> comments;

        public RepositoryTask()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public string Description { get; set; }

        public string RepositoryName { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}