namespace Simon.Processes.FileSystem
{
    /// <summary>
    /// Represents the context for updating global settings.
    /// </summary>
    public sealed class UpdateGlobalSettingsContext
    {
        /// <summary>
        /// Gets or sets the global settings.
        /// </summary>
        public GlobalSettings GlobalSettings { get; set; }
    }
}