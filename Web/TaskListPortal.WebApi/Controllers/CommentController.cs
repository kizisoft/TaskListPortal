namespace TaskListPortal.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using AutoMapper.QueryableExtensions;
    using TaskListPortal.Common.Repository;
    using TaskListPortal.Models;
    using TaskListPortal.Web.Common.Services;
    using TaskListPortal.WebApi.ViewModels.Comment;

    [EnableCors(origins: "http://localhost:7758", headers: "*", methods: "*")]
    public class CommentController : ApiController
    {
        private readonly IDbRepository<Comment> comments;
        private readonly IGitHubOctokitService gitHubOctokitService;

        public CommentController(IDbRepository<Comment> comments, IGitHubOctokitService gitHubOctokitService)
        {
            this.comments = comments;
            this.gitHubOctokitService = gitHubOctokitService;
        }

        public IHttpActionResult Get(int? taskId)
        {
            if (taskId == null)
            {
                return this.BadRequest("Task does not exist!");
            }

            var commentsDb = this.comments.All().Where(x => x.RepositoryTaskId == taskId).ProjectTo<CommentViewModel>().ToList();
            return this.Ok(commentsDb);
        }

        public async Task<IHttpActionResult> Post(string repoName, int taskId, [FromBody] CommentInputModel model)
        {
            if (string.IsNullOrEmpty(repoName) || !ModelState.IsValid)
            {
                return this.BadRequest("Input data is wrong!");
            }

            int currentPosition = 0;
            StringBuilder content = new StringBuilder();
            string pat = @"#\b([a-f0-9]{40})\b";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            var matches = r.Matches(model.Content);

            if (matches.Count > 0)
            {
                var gitHubCommits = await this.gitHubOctokitService.GetRepositoryCommits(model.AuthorName, repoName);
                for (int i = 0; i < matches.Count; i++)
                {
                    var sha = matches[i].Value.Substring(1);
                    if (gitHubCommits.ContainsKey(sha))
                    {
                        content.Append(model.Content.Substring(currentPosition, matches[i].Index - currentPosition));
                        content.Append("<a target=\"_blank\" href=\"" + gitHubCommits[sha].GitHubUrl + "\">" + gitHubCommits[sha].Message + "</a>");
                    }
                    else
                    {
                        content.Append(model.Content.Substring(currentPosition, matches[i].Index + matches[i].Length - currentPosition));
                    }

                    currentPosition = matches[i].Index + matches[i].Length;
                }
            }

            content.Append(model.Content.Substring(currentPosition, model.Content.Length - currentPosition));
            this.comments.Add(new Comment
            {
                AuthorId = model.AuthorId,
                Content = content.ToString(),
                RepositoryTaskId = taskId,
                IsDeleted = false,
                CreatedOn = DateTime.Now
            });
            this.comments.SaveChanges();
            return this.Ok();
        }
    }
}