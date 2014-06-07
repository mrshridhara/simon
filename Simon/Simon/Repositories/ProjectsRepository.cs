using Simon.Processes;
using Simon.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simon.Repositories
{
    /// <summary>
    /// Represents a projects repository.
    /// </summary>
    public sealed class ProjectsRepository
        : IAsyncPersistence<Project>
    {
        private readonly GlobalSettings globalSettings;
        private readonly IAsyncProcessFactory asyncProcessFactory;

        /// <summary>
        /// Initializes an instance of <see cref="ProjectsRepository"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <param name="asyncProcessFactory">The asyncProcess factory.</param>
        public ProjectsRepository(
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
        public Task<IEnumerable<Project>> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Create(Project data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Update(Project data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Delete(Project data)
        {
            throw new System.NotImplementedException();
        }
    }
}