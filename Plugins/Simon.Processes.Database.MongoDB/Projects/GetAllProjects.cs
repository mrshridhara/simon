using System.Linq;
using System.Threading.Tasks;
using Simon.Infrastructure;

namespace Simon.Processes.Database.MongoDB.Projects
{
    /// <summary>
    /// Represents the process of getting all the projects from the Mongo DB.
    /// </summary>
    public sealed class GetAllProjects
        : IProcess<EmptyContext, GetAllProjectsResult>
    {
        private readonly GlobalSettings globalSettings;

        /// <summary>
        /// Initializes an instance of <see cref="GetAllProjects"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        public GetAllProjects(GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
        }

        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;CreateNewProjectResult&gt;"/></returns>
        public async Task<GetAllProjectsResult> ExecuteAsync(EmptyContext context)
        {
            return await Task.Factory.StartNew(
                () => Execute(this.globalSettings),
                TaskCreationOptions.LongRunning);
        }

        private static GetAllProjectsResult Execute(
            GlobalSettings globalSettings)
        {
            var projects = MongoHelper.GetMongoCollection<Project>(globalSettings);
            var result = projects.FindAll();
            return new GetAllProjectsResult { Projects = result.ToList() };
        }
    }
}