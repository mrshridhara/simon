namespace Simon.Infrastructure
{
    internal static class Constants
    {
        public const string DashboardPathKey
            = "HangfireDashboardPath";

        public const string DefaultDatabaseName
            = "Simon_Hangfire";

        public const string MongoConnectionStringKey
            = "HangfireMongoConnectionString";

        public static readonly string PluginName
            = typeof(Constants).Assembly.FullName.Split(',')[0];
    }
}