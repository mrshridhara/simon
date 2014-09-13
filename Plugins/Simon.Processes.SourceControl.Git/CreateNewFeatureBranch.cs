using System;
using System.Threading.Tasks;
using Simon.Infrastructure;

namespace Simon.Processes.SourceControl.Git
{
    /// <summary>
    /// Represents the process of creating new feature branch in a git repository.
    /// </summary>
    public sealed class CreateNewFeatureBranch
        : IAsyncProcess<CreateNewFeatureBranchContext, CreateNewFeatureBranchResult>
    {
        private readonly GlobalSettings globalSettings;

        /// <summary>
        /// Initializes an instance of <see cref="CreateNewFeatureBranch"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        public CreateNewFeatureBranch(GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
        }

        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;CreateNewFeatureBranchResult&gt;"/></returns>
        public async Task<CreateNewFeatureBranchResult> ExecuteAsync(CreateNewFeatureBranchContext context)
        {
            return await Task.Factory.StartNew(
                () => Execute(this.globalSettings, context),
                TaskCreationOptions.LongRunning);
        }

        private static CreateNewFeatureBranchResult Execute(
            GlobalSettings globalSettings,
            CreateNewFeatureBranchContext context)
        {
            throw new NotImplementedException();
        }
    }
}