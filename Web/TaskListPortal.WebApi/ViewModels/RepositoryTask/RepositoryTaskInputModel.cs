namespace TaskListPortal.WebApi.ViewModels.RepositoryTask
{
    using System.ComponentModel.DataAnnotations;
    using TaskListPortal.Models;

    public class RepositoryTaskInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public string Description { get; set; }
    }
}