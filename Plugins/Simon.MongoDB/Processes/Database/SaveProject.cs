using Simon.Infrastructure;
using System.Threading.Tasks;

namespace Simon.Processes.Database
{
    /// <summary>
    /// Represents the process of creating new project in the Mongo DB.
    /// </summary>
    public sealed class SaveProject
        : IProcess<SaveProjectContext>
    {
        private readonly GlobalSettings globalSettings;

        /// <summary>
        /// Initializes an instance of <see cref="SaveProject"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        public SaveProject(GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
        }

        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;CreateNewProjectResult&gt;"/></returns>
        public async Task ExecuteAsync(SaveProjectContext context)
        {
            await Task.Factory.StartNew(
                () => Execute(this.globalSettings, context),
                TaskCreationOptions.LongRunning);
        }

        private static void Execute(
            GlobalSettings globalSettings,
            SaveProjectContext context)
        {
            var projects = MongoHelper.GetMongoCollection<Project>(globalSettings);
            var result = projects.Save(context.Project);
        }
    }
}