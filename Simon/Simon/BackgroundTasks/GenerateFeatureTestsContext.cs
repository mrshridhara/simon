namespace Simon.BackgroundTasks
{
    /// <summary>
    /// Represents the context for generating feature tests.
    /// </summary>
    public sealed class GenerateFeatureTestsContext
    {
        /// <summary>
        /// Gets or sets the feature.
        /// </summary>
        public Feature Feature { get; set; }
    }
}