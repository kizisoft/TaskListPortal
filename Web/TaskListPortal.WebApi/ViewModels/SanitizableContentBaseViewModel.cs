namespace TaskListPortal.WebApi.ViewModels
{
    using System.Web.Mvc;
    using TaskListPortal.Web.Common.Sanitizer;

    public abstract class SanitizableContentBaseViewModel
    {
        private readonly ISanitizer sanitizer;

        private string sanitizedContent;

        public SanitizableContentBaseViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        protected string SanitizedContent
        {
            get { return this.sanitizedContent; }
            set { this.sanitizedContent = this.sanitizer.Sanitize(value); }
        }
    }
}