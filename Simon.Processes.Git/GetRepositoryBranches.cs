using LibGit2Sharp;
using Simon.Domain;
using Simon.Domain.Process;
using Simon.Domain.Process.Contexts;
using Simon.Domain.Process.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Simon.Processes.Git
{
    /// <summary>
    /// Represents the process of getting existing branches in a git repository.
    /// </summary>
    public sealed class GetRepositoryBranches
        : IAsyncProcess<GetReposirotyBranchesContext, GetReposirotyBranchesResult>
    {
        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;GetReposirotyBranchesResult&gt;"/></returns>
        public async Task<GetReposirotyBranchesResult> ExecuteAsync(GetReposirotyBranchesContext context)
        {
            return await Task.Factory.StartNew(
                () => Execute(context),
                TaskCreationOptions.LongRunning);
        }

        private static GetReposirotyBranchesResult Execute(GetReposirotyBranchesContext context)
        {
            var repo = new Repository(context.RepoPath);
            var branches
                = (from branch in repo.Branches
                   select new SourceRepositoryBranch(Guid.NewGuid(), branch.Name, branch.CanonicalName));

            return new GetReposirotyBranchesResult { Branches = branches };
        }
    }
}