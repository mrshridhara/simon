using Hangfire;
using Hangfire.Redis;

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
        /// <param name="globalSettings">The global settings.</param>
        /// <returns>
        /// The updated instnce of <see cref="GlobalSettings"/> class.
        /// </returns>
        public GlobalSettings Init(GlobalSettings globalSettings)
        {
            if (globalSettings[Constants.HangfireRedisStorageServerKey] == null)
            {
                globalSettings.Add(Constants.HangfireRedisStorageServerKey, "localhost:6379");
            }

            JobStorage.Current = new RedisStorage(globalSettings[Constants.HangfireRedisStorageServerKey], 1);
            var server = new BackgroundJobServer();
            server.Start();

            return globalSettings;
        }
    }
}