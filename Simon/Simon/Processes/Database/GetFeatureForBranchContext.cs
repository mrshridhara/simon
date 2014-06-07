namespace Simon.Processes.Database
{
    /// <summary>
    /// Represents the context for getting repository branches.
    /// </summary>
    public sealed class GetFeatureForBranchContext
    {
        /// <summary>
        /// Gets or sets the branch.
        /// </summary>
        public SourceControlBranch Branch { get; set; }
    }
}