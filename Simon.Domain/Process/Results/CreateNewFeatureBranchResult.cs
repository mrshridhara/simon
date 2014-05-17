namespace Simon.Domain.Process.Results
{
    /// <summary>
    /// Represents the result of creating new feature branch.
    /// </summary>
    public sealed class CreateNewFeatureBranchResult
    {
        /// <summary>
        /// Gets or sets the feature branch.
        /// </summary>
        public SourceRepositoryBranch FeatureBranch { get; set; }
    }
}