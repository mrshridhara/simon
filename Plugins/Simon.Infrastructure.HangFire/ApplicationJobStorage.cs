using Hangfire;
using Hangfire.Storage;
using Simon.Infrastructure.Utilities;
using System;

namespace Simon.Infrastructure.Hangfire
{
    /// <summary>
    /// Custom job storage implementation that will use the application storage
    /// to store Hangfire jobs.
    /// </summary>
    public sealed class ApplicationJobStorage : JobStorage
    {
        private readonly IStorageConnection storageConnection;
        private readonly IMonitoringApi monitoringApi;

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationJobStorage"/> class.
        /// </summary>
        /// <param name="storageConnection">The storage connection.</param>
        /// <param name="monitoringApi">The monitoring API.</param>
        public ApplicationJobStorage(
            IStorageConnection storageConnection,
            IMonitoringApi monitoringApi)
        {
            Guard.NotNullArgument("storageConnection", storageConnection);
            Guard.NotNullArgument("monitoringApi", monitoringApi);

            this.storageConnection = storageConnection;
            this.monitoringApi = monitoringApi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IStorageConnection GetConnection()
        {
            return storageConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IMonitoringApi GetMonitoringApi()
        {
            return monitoringApi;
        }
    }
}