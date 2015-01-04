using Autofac;
using Owin;
using Simon.Infrastructure;

namespace Simon.Processes.Database.MongoDB
{
    /// <summary>
    /// Represents the plug-in initializer.
    /// </summary>
    public sealed class MongoDBPlugin : IPlugin
    {
        /// <summary>
        /// Initializes the plug-in and updates the specified <paramref name="globalSettings"/>
        /// if required.
        /// </summary>
        /// <param name="appBuilder">The app builder.</param>
        /// <param name="container">The IOC container.</param>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns>
        /// The updated instance of <see cref="GlobalSettings"/> class.
        /// </returns>
        public GlobalSettings Init(IAppBuilder appBuilder, IContainer container, GlobalSettings globalSettings)
        {
            if (globalSettings[Constants.ConnectionStringKey] == null)
            {
                var settingsItem
                    = new GlobalSettingsItem("MongoDB Connection String for Application Data", "mongodb://localhost");

                globalSettings.Add(Constants.ConnectionStringKey, settingsItem);
            }

            return globalSettings;
        }
    }
}