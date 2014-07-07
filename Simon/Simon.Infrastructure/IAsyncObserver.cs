﻿using Simon.Infrastructure.Aspects;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines an async observer of entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAsyncObserver<in TEntity>
    {
        /// <summary>
        /// Updates the observer of the change in state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task for async operations.</returns>
        [ArgumentsNotNull]
        Task UpdateAsync(TEntity entity);
    }
}