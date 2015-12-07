namespace TaskListPortal.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using TaskListPortal.Common.Repository;
    using TaskListPortal.Models;
    using TaskListPortal.WebApi.ViewModels.RepositoryTask;

    [EnableCors(origins: "http://localhost:7758", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        private readonly IDbRepository<RepositoryTask> tasks;

        public TaskController(IDbRepository<RepositoryTask> tasks)
        {
            this.tasks = tasks;
        }

        //// TODO: Add validation of repoName and given Id if needed

        public IHttpActionResult Get(string repoName)
        {
            if (string.IsNullOrEmpty(repoName))
            {
                return this.BadRequest(string.Format("Repository {0} does not exist!", repoName));
            }

            var tasksDb = this.tasks.All().Where(x => x.RepositoryName == repoName).ProjectTo<RepositoryTaskViewModel>().ToList();
            return this.Ok(tasksDb);
        }

        public IHttpActionResult Get(int id)
        {
            var taskDb = this.tasks.All().ProjectTo<RepositoryTaskViewModel>().FirstOrDefault(x => x.Id == id);
            return this.Ok(taskDb);
        }

        public IHttpActionResult Post(string repoName, [FromBody] RepositoryTaskInputModel model)
        {
            if (string.IsNullOrEmpty(repoName) || !ModelState.IsValid)
            {
                return this.BadRequest("Input data is wrong!");
            }

            this.tasks.Add(new RepositoryTask
            {
                Name = model.Name,
                RepositoryName = repoName,
                Description = model.Description,
                Status = model.Status,
                IsDeleted = false,
                CreatedOn = DateTime.Now
            });
            this.tasks.SaveChanges();
            return this.Ok();
        }

        public IHttpActionResult Put(int id, [FromBody] RepositoryTaskInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Input data is wrong!");
            }

            var taskDb = this.tasks.All().FirstOrDefault(x => x.Id == id);
            if (taskDb == null)
            {
                return this.BadRequest(string.Format("Task with Id {0} does not exist!", id));
            }

            taskDb.Name = model.Name;
            taskDb.Description = model.Description;
            taskDb.Status = model.Status;
            taskDb.ModifiedOn = DateTime.Now;

            this.tasks.Update(taskDb);
            this.tasks.SaveChanges();
            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var taskDb = this.tasks.All().FirstOrDefault(x => x.Id == id);
            if (taskDb == null)
            {
                return this.BadRequest(string.Format("Task with Id {0} does not exist!", id));
            }

            this.tasks.Delete(taskDb);
            this.tasks.SaveChanges();
            return this.Ok();
        }
    }
}