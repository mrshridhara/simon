using LibGit2Sharp;
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
        private readonly GlobalSettings globalSettings;

        /// <summary>
        /// Initializes an instance of <see cref="GetRepositoryBranches"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        public GetRepositoryBranches(GlobalSettings globalSettings)
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

        private static GetReposirotyBranchesResult Execute(GlobalSettings globalSettings)
        {
            var repo = new Repository(globalSettings["RepoPath"]);
            var branches
                = (from branch in repo.Branches
                   select new SourceControlBranch(Guid.NewGuid(), branch.Name, branch.CanonicalName));

            return new GetReposirotyBranchesResult { Branches = branches };
        }
    }
}