﻿using MongoDB.Driver;
using Simon.Infrastructure;

namespace Simon.Processes.Database
{
    internal static class MongoHelper
    {
        internal static MongoCollection<TEntity> GetMongoCollection<TEntity>(
            GlobalSettings globalSettings, string databaseName = Constants.DefaultDatabaseName)
        {
            var settingsItem = globalSettings[Constants.ConnectionStringKey];

            var client = new MongoClient(settingsItem.Value);
            var server = client.GetServer();
            var database = server.GetDatabase(databaseName);

            return database.GetCollection<TEntity>(typeof(TEntity).Name + "Collection");
        }
    }
}