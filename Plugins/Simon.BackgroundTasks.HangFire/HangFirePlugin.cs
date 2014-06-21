using HangFire;
using HangFire.Redis;

namespace Simon.BackgroundTasks.HangFire
{
    /// <summary>
    /// Represents the plugin intializer.
    /// </summary>
    public sealed class HangFirePlugin : IPlugin
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
            if (globalSettings["HangFireRedisStorageServer"] == null)
            {
                globalSettings.Add("HangFireRedisStorageServer", "localhost:6379");
            }

            JobStorage.Current = new RedisStorage(globalSettings["HangFireRedisStorageServer"], 1);
            var server = new BackgroundJobServer();
            server.Start();

            return globalSettings;
        }
    }
}