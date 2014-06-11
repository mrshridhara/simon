using Simon.Processes;
using Simon.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simon.Repositories
{
    /// <summary>
    /// Represents a global settings repository.
    /// </summary>
    public sealed class GlobalSettingsRepository
        : IAsyncPersistence<GlobalSettings>
    {
        private readonly IAsyncProcessFactory asyncProcessFactory;

        /// <summary>
        /// Initializes an instance of <see cref="GlobalSettingsRepository"/> class.
        /// </summary>
        /// <param name="asyncProcessFactory">The asyncProcess factory.</param>
        public GlobalSettingsRepository(
            IAsyncProcessFactory asyncProcessFactory)
        {
            Guard.NotNullArgument("asyncProcessFactory", asyncProcessFactory);

            this.asyncProcessFactory = asyncProcessFactory;
        }

        /// <summary>
        /// Reads all the persisted data.
        /// </summary>
        /// <returns>
        /// All the persisted data.
        /// </returns>
        public async Task<IEnumerable<GlobalSettings>> ReadAll()
        {
            var asyncProcess
                = asyncProcessFactory
                    .CreateAsyncProcess<
                        EmptyContext,
                        GetGlobalSettingsResult>(GlobalSettings.Empty);

            var globalSettings = await asyncProcess.ExecuteAsync(EmptyContext.Instance);

            return Enumerable.Repeat(globalSettings.GlobalSettings, 1);
        }

        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Create(GlobalSettings data)
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
            var asyncProcess
                = asyncProcessFactory
                    .CreateAsyncProcess<
                        UpdateGlobalSettingsContext>(GlobalSettings.Empty);

            await asyncProcess.ExecuteAsync(new UpdateGlobalSettingsContext
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