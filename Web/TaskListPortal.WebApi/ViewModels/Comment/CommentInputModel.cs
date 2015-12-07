namespace TaskListPortal.WebApi.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using TaskListPortal.Web.Common.Sanitizer;

    public class CommentInputModel : SanitizableContentBaseViewModel
    {
        [Required]
        [MaxLength(1000)]
        [AllowHtml]
        public string Content
        {
            get { return this.SanitizedContent; }
            set { this.SanitizedContent = value; }
        }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }
    }
}