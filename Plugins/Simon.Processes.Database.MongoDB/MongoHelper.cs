using MongoDB.Driver;

namespace Simon.Processes.Database.MongoDB
{
    internal static class MongoHelper
    {
        internal static MongoCollection<TEntity> GetMongoCollection<TEntity>(
            GlobalSettings globalSettings, string databaseName = Constants.DefaultDatabaseName)
        {
            var connectionString = globalSettings[Constants.ConnectionStringKey];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(databaseName);

            return database.GetCollection<TEntity>(typeof(TEntity).FullName);
        }
    }
}