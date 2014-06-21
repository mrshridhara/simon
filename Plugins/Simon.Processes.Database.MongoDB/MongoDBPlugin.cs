namespace Simon.Processes.Database.MongoDB
{
    /// <summary>
    /// Represents the plugin intializer.
    /// </summary>
    public sealed class MongoDBPlugin : IPlugin
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
            if (globalSettings[Constants.ConnectionStringKey] == null)
            {
                globalSettings.Add(Constants.ConnectionStringKey, "mongodb://localhost");
            }

            return globalSettings;
        }
    }
}