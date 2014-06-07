using System.Threading.Tasks;

namespace Simon.Processes.Database.MongoDB
{
    /// <summary>
    /// Represents the process of creating new project in the Mongo DB.
    /// </summary>
    public sealed class CreateNewProject
        : IAsyncProcess<CreateNewProjectContext, CreateNewProjectResult>
    {
        private readonly GlobalSettings globalSettings;

        /// <summary>
        /// Initializes an instance of <see cref="CreateNewProject"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        public CreateNewProject(GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
        }

        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;CreateNewProjectResult&gt;"/></returns>
        public async Task<CreateNewProjectResult> ExecuteAsync(CreateNewProjectContext context)
        {
            return await Task.Factory.StartNew(
                () => Execute(this.globalSettings, context),
                TaskCreationOptions.LongRunning);
        }

        private static CreateNewProjectResult Execute(
            GlobalSettings globalSettings,
            CreateNewProjectContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}