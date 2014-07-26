using Autofac;
using Owin;
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
        /// <param name="appBuilder">The app builder.</param>
        /// <param name="container">The IOC container.</param>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns>
        /// The updated instnce of <see cref="GlobalSettings"/> class.
        /// </returns>
        public GlobalSettings Init(IAppBuilder appBuilder, IContainer container, GlobalSettings globalSettings)
        {
            if (globalSettings[Constants.GitRepoPathKey] == null)
            {
                var settingItem
                    = new GlobalSettingsItem("Repository path for Git", "");

                globalSettings.Add(Constants.GitRepoPathKey, settingItem);
            }

            return globalSettings;
        }
    }
}