using System.Collections.Generic;

namespace Simon.Processes.SourceControl
{
    /// <summary>
    /// Represents the result of getting repository branches.
    /// </summary>
    public sealed class GetReposirotyBranchesResult
    {
        /// <summary>
        /// Gets or sets the branches in a repository.
        /// </summary>
        public IEnumerable<SourceControlBranch> Branches { get; set; }
    }
}