namespace TaskListPortal.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskListPortalDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Make it false
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TaskListPortalDbContext context)
        {
            this.SeedUsers();
        }

        private void SeedUsers()
        {
            // TODO: Add Administrator
        }
    }
}