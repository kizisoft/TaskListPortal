namespace TaskListPortal.Web.Common.Identity
{
    using TaskListPortal.Models;

    public interface ICurrentUser
    {
        User Get();
    }
}