namespace Simon.Domain.Process.Contexts
{
    /// <summary>
    /// Represents the context for getting repository branches.
    /// </summary>
    public sealed class GetReposirotyBranchesContext
    {
        /// <summary>
        /// Gets or sets the repo path.
        /// </summary>
        public string RepoPath { get; set; }
    }
}