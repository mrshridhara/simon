namespace Simon
{
    /// <summary>
    /// Represents the possibles states of a feature.
    /// </summary>
    public enum FeatureState
    {
        /// <summary>
        /// The new feature state. This is the default value.
        /// </summary>
        NewFeature = 0,

        /// <summary>
        /// The requirements completed state.
        /// </summary>
        RequirementsCompleted,

        /// <summary>
        /// The ready for development state.
        /// </summary>
        ReadyForDevelopment,

        /// <summary>
        /// The in build state.
        /// </summary>
        InBuild,

        /// <summary>
        /// The ready for feature testing state.
        /// </summary>
        ReadyForFeatureTesting,

        /// <summary>
        /// The ready for integration testing state.
        /// </summary>
        ReadyForIntegrationTesting,

        /// <summary>
        /// The in automated test state.
        /// </summary>
        InAutomatedTest,

        /// <summary>
        /// The ready for manual testing state.
        /// </summary>
        ReadyForManualTesting,

        /// <summary>
        /// The in manual test state.
        /// </summary>
        InManualTest,

        /// <summary>
        /// The ready for production state.
        /// </summary>
        ReadyForProduction,

        /// <summary>
        /// The in production state.
        /// </summary>
        InProduction
    }
}