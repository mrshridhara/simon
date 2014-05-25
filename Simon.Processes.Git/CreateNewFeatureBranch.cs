using Simon.Domain.Process;
using Simon.Domain.Process.Contexts;
using Simon.Domain.Process.Results;
using System;
using System.Threading.Tasks;

namespace Simon.Processes.Git
{
    /// <summary>
    /// Represents the process of creating new feature branch in a git repository.
    /// </summary>
    public sealed class CreateNewFeatureBranch
        : IAsyncProcess<CreateNewFeatureBranchContext, CreateNewFeatureBranchResult>
    {
        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;CreateNewFeatureBranchResult&gt;"/></returns>
        public async Task<CreateNewFeatureBranchResult> ExecuteAsync(CreateNewFeatureBranchContext context)
        {
            return await Task.Factory.StartNew(
                () => Execute(context),
                TaskCreationOptions.LongRunning);
        }

        private static CreateNewFeatureBranchResult Execute(CreateNewFeatureBranchContext context)
        {
            throw new NotImplementedException();
        }
    }
}
