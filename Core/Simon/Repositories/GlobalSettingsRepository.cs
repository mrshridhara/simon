using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using Simon.Processes.FileSystem;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            Guard.NotNullArgument(nameof(getGlobalSettings), getGlobalSettings);
            Guard.NotNullArgument(nameof(updateGlobalSettings), updateGlobalSettings);

            this.getGlobalSettings = getGlobalSettings;
            this.updateGlobalSettings = updateGlobalSettings;
        }

        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task<GlobalSettings> CreateAsync(GlobalSettings data)
        {
            throw new InvalidOperationException(
                "This operation is not supported for global settings.");
        }

        /// <summary>
        /// Deletes the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task DeleteAsync(GlobalSettings data)
        {
            throw new InvalidOperationException(
                "This operation is not supported for global settings.");
        }

        /// <summary>
        /// Reads all the persisted data if the filter is null,
        /// otherwise; reads filtered data.
        /// </summary>
        /// <returns>
        /// The persisted data if the filter is null,
        /// otherwise; reads filtered data.
        /// </returns>
        public async Task<IQueryable<GlobalSettings>> ReadAsync(Expression<Func<GlobalSettings, bool>> filter = null)
        {
            var globalSettings = await getGlobalSettings.ExecuteAsync(EmptyContext.Instance);

            return Enumerable.Repeat(globalSettings.GlobalSettings, 1).AsQueryable();
        }

        /// <summary>
        /// Updates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public async Task UpdateAsync(GlobalSettings data)
        {
            await updateGlobalSettings.ExecuteAsync(new UpdateGlobalSettingsContext
            {
                GlobalSettings = data
            });
        }
    }
}