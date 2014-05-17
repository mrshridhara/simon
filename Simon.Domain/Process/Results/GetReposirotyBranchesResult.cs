using System.Collections.Generic;

namespace Simon.Domain.Process.Results
{
    /// <summary>
    /// Represents the result of getting repository branches.
    /// </summary>
    public sealed class GetReposirotyBranchesResult
    {
        /// <summary>
        /// Gets or sets the branches in a repo.
        /// </summary>
        public IEnumerable<SourceRepositoryBranch> Branches { get; set; }
    }
}