namespace Simon.Infrastructure
{
    internal static class Constants
    {
        public const string ConnectionStringKey
            = "MongoConnectionString";

        public const string DefaultDatabaseName
             = "Simon";

        public static readonly string PluginName
            = typeof(Constants).Assembly.FullName.Split(',')[0];
    }
}