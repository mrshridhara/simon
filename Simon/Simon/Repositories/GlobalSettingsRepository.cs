using Simon.Processes;
using Simon.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simon.Repositories
{
    /// <summary>
    /// Represents a global settings repository.
    /// </summary>
    public sealed class GlobalSettingsRepository
        : IAsyncPersistence<GlobalSettings>
    {
        private readonly GlobalSettings globalSettings;
        private readonly IAsyncProcessFactory asyncProcessFactory;

        /// <summary>
        /// Initializes an instance of <see cref="GlobalSettingsRepository"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <param name="asyncProcessFactory">The asyncProcess factory.</param>
        public GlobalSettingsRepository(
            GlobalSettings globalSettings,
            IAsyncProcessFactory asyncProcessFactory)
        {
            Guard.NotNullArgument("globalSettings", globalSettings);
            Guard.NotNullArgument("asyncProcessFactory", asyncProcessFactory);

            this.globalSettings = globalSettings;
            this.asyncProcessFactory = asyncProcessFactory;
        }

        /// <summary>
        /// Reads all the persisted data.
        /// </summary>
        /// <returns>
        /// All the persisted data.
        /// </returns>
        public Task<IEnumerable<GlobalSettings>> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Create(GlobalSettings data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Update(GlobalSettings data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Delete(GlobalSettings data)
        {
            throw new System.NotImplementedException();
        }
    }
}