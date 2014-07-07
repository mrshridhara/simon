using Simon.Infrastructure;

namespace Simon.Processes
{
    /// <summary>
    /// Represents the result of getting global settings.
    /// </summary>
    public sealed class GetGlobalSettingsResult
    {
        /// <summary>
        /// Gets or sets global settings.
        /// </summary>
        public GlobalSettings GlobalSettings { get; set; }
    }
}