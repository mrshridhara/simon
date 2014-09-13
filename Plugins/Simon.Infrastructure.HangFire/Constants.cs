﻿namespace Simon.Infrastructure.Hangfire
{
    /// <summary>
    /// Represents the constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The Hangfire redis storage server key.
        /// </summary>
        public const string HangfireRedisStorageServerKey
            = "HangfireRedisStorageServer";

        /// <summary>
        /// The Hangfire dashboard path key.
        /// </summary>
        public const string HangfireDashboardPathKey
            = "HangfireDashboardPath";
    }
}