namespace Simon.Processes.Database
{
    /// <summary>
    /// Represents the result of getting feature for a source control branch.
    /// </summary>
    public sealed class GetFeatureForBranchResult
    {
        /// <summary>
        /// Gets or sets the feature.
        /// </summary>
        public Feature Feature { get; set; }
    }
}