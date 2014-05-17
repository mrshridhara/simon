namespace Simon.Domain.Process.Contexts
{
    /// <summary>
    /// Represents the context for getting repository branches.
    /// </summary>
    public sealed class GetFeatureForBranchContext
    {
        /// <summary>
        /// Gets or sets the branch.
        /// </summary>
        public SourceRepositoryBranch Branch { get; set; }
    }
}