namespace Simon
{
    /// <summary>
    /// Represents the possibles states of a feature.
    /// </summary>
    public enum FeatureState
    {
        /// <summary>
        /// The unknown state. This is the default value.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The todo state.
        /// </summary>
        Todo,

        /// <summary>
        /// The in build state.
        /// </summary>
        InBuild,

        /// <summary>
        /// The build completed state.
        /// </summary>
        BuildCompleted,
        
        /// <summary>
        /// The in automated test state.
        /// </summary>
        InAutomatedTest,

        /// <summary>
        /// The in manual test state.
        /// </summary>
        InManualTest,

        /// <summary>
        /// The in production state.
        /// </summary>
        InProduction
    }
}