namespace Simon.Domain.Process.Contexts
{
    /// <summary>
    /// Represents the context for creating new feature branch.
    /// </summary>
    public sealed class CreateNewFeatureBranchContext
    {
        /// <summary>
        /// Gets or sets the feature.
        /// </summary>
        public Feature Feature { get; set; }

        /// <summary>
        /// Gets or sets the repo path.
        /// </summary>
        public string RepoPath { get; set; }
    }
}