namespace TaskListPortal.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TaskListPortal.Common.Models;
    using TaskListPortal.Data.Migrations;
    using TaskListPortal.Models;

    public class TaskListPortalDbContext : IdentityDbContext<User>
    {
        public TaskListPortalDbContext()
            : base("TaskListPortalConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskListPortalDbContext, Configuration>());
        }

        public IDbSet<RepositoryTask> RepositoryTasks { get; set; }

        public static TaskListPortalDbContext Create()
        {
            return new TaskListPortalDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            var entities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in entities)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}