namespace TaskListPortal.Web.Common.Identity
{
    using System.Security.Principal;
    using Microsoft.AspNet.Identity;
    using TaskListPortal.Data;
    using TaskListPortal.Models;

    public class CurrentUser : ICurrentUser
    {
        private readonly TaskListPortalDbContext currentDbContext;
        private readonly IIdentity currentIdentity;

        private User user;

        public CurrentUser(IIdentity identity, TaskListPortalDbContext context)
        {
            this.currentDbContext = context;
            this.currentIdentity = identity;
        }

        public User Get()
        {
            return this.user ?? (this.user = this.currentDbContext.Users.Find(this.currentIdentity.GetUserId()));
        }
    }
}