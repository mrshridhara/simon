using Simon.Infrastructure;

namespace Simon.Processes.SourceControl.Git
{
    /// <summary>
    /// Represents the plugin intializer.
    /// </summary>
    public sealed class GitPlugin : IPlugin
    {
        /// <summary>
        /// Initializes the plugin and updates the specified <paramref name="globalSettings"/>
        /// if required.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns>
        /// The updated instnce of <see cref="GlobalSettings"/> class.
        /// </returns>
        public GlobalSettings Init(GlobalSettings globalSettings)
        {
            if (globalSettings["GitRepoPath"] == null)
            {
                globalSettings.Add("GitRepoPath", "");
            }

            return globalSettings;
        }
    }
}