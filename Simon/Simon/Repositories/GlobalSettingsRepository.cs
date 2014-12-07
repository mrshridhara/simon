using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using Simon.Processes.FileSystem;

namespace Simon.Repositories
{
    /// <summary>
    /// Represents a global settings repository.
    /// </summary>
    public sealed class GlobalSettingsRepository
        : IPersistence<GlobalSettings>
    {
        private readonly IProcess<EmptyContext, GetGlobalSettingsResult> getGlobalSettings;
        private readonly IProcess<UpdateGlobalSettingsContext> updateGlobalSettings;

        /// <summary>
        /// Initializes an instance of <see cref="GlobalSettingsRepository"/> class.
        /// </summary>
        /// <param name="getGlobalSettings">The get global settings.</param>
        /// <param name="updateGlobalSettings">The update global settings.</param>
        public GlobalSettingsRepository(
            IProcess<EmptyContext, GetGlobalSettingsResult> getGlobalSettings,
            IProcess<UpdateGlobalSettingsContext> updateGlobalSettings)
        {
            Guard.NotNullArgument("getGlobalSettings", getGlobalSettings);
            Guard.NotNullArgument("updateGlobalSettings", updateGlobalSettings);

            this.getGlobalSettings = getGlobalSettings;
            this.updateGlobalSettings = updateGlobalSettings;
        }

        /// <summary>
        /// Reads all the persisted data.
        /// </summary>
        /// <returns>
        /// All the persisted data.
        /// </returns>
        public async Task<IEnumerable<GlobalSettings>> ReadAll()
        {
            var globalSettings = await getGlobalSettings.ExecuteAsync(EmptyContext.Instance);

            return Enumerable.Repeat(globalSettings.GlobalSettings, 1);
        }

        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task<GlobalSettings> Create(GlobalSettings data)
        {
            throw new InvalidOperationException(
                "This operation is not supported for global settings.");
        }

        /// <summary>
        /// Updates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public async Task Update(GlobalSettings data)
        {
            await updateGlobalSettings.ExecuteAsync(new UpdateGlobalSettingsContext
            {
                GlobalSettings = data
            });
        }

        /// <summary>
        /// Deletes the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Delete(GlobalSettings data)
        {
            throw new InvalidOperationException(
                "This operation is not supported for global settings.");
        }
    }
}