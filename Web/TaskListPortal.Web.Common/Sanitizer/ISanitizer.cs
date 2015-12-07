namespace TaskListPortal.Web.Common.Sanitizer
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}