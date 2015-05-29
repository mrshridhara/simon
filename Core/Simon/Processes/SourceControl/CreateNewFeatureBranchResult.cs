namespace Simon.Processes.SourceControl
{
    /// <summary>
    /// Represents the result of creating new feature branch.
    /// </summary>
    public sealed class CreateNewFeatureBranchResult
    {
        /// <summary>
        /// Gets or sets the feature branch.
        /// </summary>
        public SourceControlBranch FeatureBranch { get; set; }
    }
}