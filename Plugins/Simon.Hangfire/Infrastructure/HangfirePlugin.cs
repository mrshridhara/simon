using Autofac;
using Hangfire;
using Hangfire.Mongo;
using Owin;
using Simon.Infrastructure.Utilities;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Represents the plug-in initializer.
    /// </summary>
    public sealed class HangfirePlugin : IPlugin
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
            Guard.NotNullArgument(nameof(appBuilder), appBuilder);
            Guard.NotNullArgument(nameof(container), container);
            Guard.NotNullArgument(nameof(globalSettings), globalSettings);

            AddStorageServerDetailsIfRequired(globalSettings);
            AddDashboardDetailsIfRequired(globalSettings);

            appBuilder.UseHangfire(config =>
            {
                ConfigureHangfire(container, globalSettings, config);
            });

            return globalSettings;
        }

        private static void AddDashboardDetailsIfRequired(GlobalSettings globalSettings)
        {
            if (globalSettings[Constants.DashboardPathKey] == null)
            {
                var settingItem
                    = new GlobalSettingsItem(
                        "Hangfire Dashboard",
                        "/hangfire",
                        Constants.PluginName,
                        true);

                globalSettings.Add(Constants.DashboardPathKey, settingItem);
            }
        }

        private static void AddStorageServerDetailsIfRequired(GlobalSettings globalSettings)
        {
            if (globalSettings[Constants.MongoConnectionStringKey] == null)
            {
                var settingsItem
                    = new GlobalSettingsItem(
                        "MongoDB Connection String for Hangfire",
                        "mongodb://localhost",
                        Constants.PluginName);

                globalSettings.Add(Constants.MongoConnectionStringKey, settingsItem);
            }
        }

        private static void ConfigureHangfire(
            IContainer container,
            GlobalSettings globalSettings,
            IBootstrapperConfiguration config)
        {
            var mongoSettingItem = globalSettings[Constants.MongoConnectionStringKey];
            var pathSettingItem = globalSettings[Constants.DashboardPathKey];

            config.UseDashboardPath(pathSettingItem.Value);
            config.UseAutofacActivator(container);

            var jobStorgae
                = new MongoStorage(
                    mongoSettingItem.Value,
                    Constants.DefaultDatabaseName);

            config.UseStorage(jobStorgae);
            config.UseServer();
        }
    }
}