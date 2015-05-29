using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines the structure of a CRUD persistence implementation.
    /// </summary>
    /// <typeparam name="TData">Type of the data.</typeparam>
    public interface IPersistence<TData>
    {
        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        Task<TData> CreateAsync(TData data);

        /// <summary>
        /// Deletes the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        Task DeleteAsync(TData data);

        /// <summary>
        /// Reads all the persisted data if the filter is null,
        /// otherwise; reads filtered data.
        /// </summary>
        /// <returns>
        /// The persisted data if the filter is null,
        /// otherwise; reads filtered data.
        /// </returns>
        Task<IQueryable<TData>> ReadAsync(Expression<Func<TData, bool>> filter = null);

        /// <summary>
        /// Updates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        Task UpdateAsync(TData data);
    }
}