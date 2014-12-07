using Autofac;
using Hangfire;
using Owin;

namespace Simon.Infrastructure.Hangfire
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
            if (globalSettings[Constants.HangfireRedisStorageServerKey] == null)
            {
                var settingItem
                    = new GlobalSettingsItem("Hangfire Redis storage server", "localhost:6379");

                globalSettings.Add(Constants.HangfireRedisStorageServerKey, settingItem);
            }

            if (globalSettings[Constants.HangfireDashboardPathKey] == null)
            {
                var settingItem
                    = new GlobalSettingsItem("Hangfire Dashboard", "/hangfire", true);

                globalSettings.Add(Constants.HangfireDashboardPathKey, settingItem);
            }

            appBuilder.UseHangfire(config =>
            {
                var redisSettingItem = globalSettings[Constants.HangfireRedisStorageServerKey];
                var pathSettingItem = globalSettings[Constants.HangfireDashboardPathKey];

                config.UseDashboardPath(pathSettingItem.Value);
                config.UseAutofacActivator(container);

                var jobStorgae = container.Resolve<ApplicationJobStorage>();
                config.UseStorage(jobStorgae);
                config.UseServer();
            });

            return globalSettings;
        }
    }
}