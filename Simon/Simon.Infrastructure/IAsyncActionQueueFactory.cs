using Simon.Infrastructure.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines a factory for async action queue.
    /// </summary>
    public interface IAsyncActionQueueFactory
    {
        /// <summary>
        /// Creates an async action queue which takes a action of type <typeparamref name="TAction"/>
        /// and an entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TAction">The type of action.</typeparam>
        /// <typeparam name="TEntity">The type of entity.</typeparam>
        /// <returns>An instacnce of <see cref="IAsyncActionQueue&lt;TAction, TEntity&gt;"/>.</returns>
        [ArgumentsNotNull]
        IAsyncActionQueue<TAction, TEntity> CreateAsyncActionQueue<TAction, TEntity>(
            TAction action, TEntity entity)
            where TAction : IAsyncAction<TEntity>;
    }
}