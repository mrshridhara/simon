using LibGit2Sharp;
using Simon.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Simon.Processes.SourceControl.Git
{
    /// <summary>
    /// Represents the process of getting existing branches in a git repository.
    /// </summary>
    public sealed class GetRepositoryBranches
        : IAsyncProcess<EmptyContext, GetReposirotyBranchesResult>
    {
        private readonly Simon.Infrastructure.GlobalSettings globalSettings;

        /// <summary>
        /// Initializes an instance of <see cref="GetRepositoryBranches"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        public GetRepositoryBranches(Simon.Infrastructure.GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
        }

        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;GetReposirotyBranchesResult&gt;"/></returns>
        public async Task<GetReposirotyBranchesResult> ExecuteAsync(EmptyContext context)
        {
            return await Task.Factory.StartNew(
                () => Execute(this.globalSettings),
                TaskCreationOptions.LongRunning);
        }

        private static GetReposirotyBranchesResult Execute(Simon.Infrastructure.GlobalSettings globalSettings)
        {
            var settingItem = globalSettings[Constants.GitRepoPathKey];

            var repo = new Repository(settingItem.Value);
            var branches
                = (from branch in repo.Branches
                   select new SourceControlBranch(Guid.NewGuid(), branch.Name, branch.CanonicalName));

            return new GetReposirotyBranchesResult { Branches = branches };
        }
    }
}