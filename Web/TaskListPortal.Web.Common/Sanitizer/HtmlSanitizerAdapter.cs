namespace TaskListPortal.Web.Common.Sanitizer
{
    using Ganss.XSS;

    public class HtmlSanitizerAdapter : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var encoded = System.Security.SecurityElement.Escape(html);
            var result = sanitizer.Sanitize(encoded);

            return result;
        }
    }
}