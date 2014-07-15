using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines the structure of a CRUD persistence with filter implementation.
    /// </summary>
    /// <typeparam name="TData">Type of the data.</typeparam>
    /// <typeparam name="TFilter">The type of the filter.</typeparam>
    public interface IAsyncPersistence<TData, TFilter>
        : IAsyncPersistence<TData>
    {
        /// <summary>
        /// Gets all the persisted data matching the specified <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// All the persisted data matching the specified <paramref name="filter"/>.
        /// </returns>
        Task<IEnumerable<TData>> Read(TFilter filter);
    }

    /// <summary>
    /// Defines the structure of a CRUD persistence implementation.
    /// </summary>
    /// <typeparam name="TData">Type of the data.</typeparam>
    public interface IAsyncPersistence<TData>
    {
        /// <summary>
        /// Reads all the persisted data.
        /// </summary>
        /// <returns>
        /// All the persisted data.
        /// </returns>
        Task<IEnumerable<TData>> ReadAll();

        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        Task Create(TData data);

        /// <summary>
        /// Updates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        Task Update(TData data);

        /// <summary>
        /// Deletes the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        Task Delete(TData data);
    }
}