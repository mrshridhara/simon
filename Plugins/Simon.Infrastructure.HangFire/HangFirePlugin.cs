using Autofac;
using Hangfire;
using Hangfire.Redis;
using Owin;

namespace Simon.Infrastructure.Hangfire
{
    /// <summary>
    /// Represents the plugin intializer.
    /// </summary>
    public sealed class HangfirePlugin : IPlugin
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
            if (globalSettings[Constants.HangfireRedisStorageServerKey] == null)
            {
                var settingItem
                    = new GlobalSettingsItem("Redis storage server for Hangfire", "localhost:6379");

                globalSettings.Add(Constants.HangfireRedisStorageServerKey, settingItem);
            }

            appBuilder.UseHangfire(config =>
            {
                var settingItem = globalSettings[Constants.HangfireRedisStorageServerKey];

                config.UseAutofacActivator(container);
                config.UseRedisStorage(settingItem.Value, 1);
                config.UseServer();
            });

            return globalSettings;
        }
    }
}