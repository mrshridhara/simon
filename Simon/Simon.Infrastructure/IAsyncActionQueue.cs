using Simon.Infrastructure.Aspects;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines a queue for an action.
    /// </summary>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAsyncActionQueue<in TAction, in TEntity>
        where TAction : IAsyncAction<TEntity>
    {
        /// <summary>
        /// Enqueues the specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        [ArgumentsNotNull]
        Task EnqueueAsync(TAction action, TEntity entity);
    }
}