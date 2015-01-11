namespace Simon.Infrastructure.Hangfire
{
    /// <summary>
    /// Represents the constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The dashboard path key.
        /// </summary>
        public const string DashboardPathKey
            = "HangfireDashboardPath";

        /// <summary>
        /// The default database name.
        /// </summary>
        public const string DefaultDatabaseName
             = "Simon_Hangfire";

        /// <summary>
        /// The Mongo DB connection string key.
        /// </summary>
        public const string MongoConnectionStringKey
            = "HangfireMongoConnectionString";
    }
}