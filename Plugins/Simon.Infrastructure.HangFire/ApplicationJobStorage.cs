using Hangfire;
using Hangfire.Storage;
using System;

namespace Simon.Infrastructure.Hangfire
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ApplicationJobStorage : JobStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IStorageConnection GetConnection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IMonitoringApi GetMonitoringApi()
        {
            throw new NotImplementedException();
        }
    }
}