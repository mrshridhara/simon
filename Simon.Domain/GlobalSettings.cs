namespace Simon.Domain
{
    /// <summary>
    /// Represents the global settings of the Simon application.
    /// </summary>
    public sealed class GlobalSettings
    {
        /// <summary>
        /// Gets or sets the repo path.
        /// </summary>
        public string RepoPath { get; set; }

        /// <summary>
        /// Gets or sets the database connection string.
        /// </summary>
        public string DatabaseConnectionString { get; set; }
    }
}