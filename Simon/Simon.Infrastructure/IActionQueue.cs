using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines a queue for an action.
    /// </summary>
    public interface IActionQueue
    {
        /// <summary>
        /// Enqueues the specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TAction">The type of the action.</typeparam>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        Task EnqueueAsync<TAction, TEntity>(TAction action, TEntity entity)
            where TAction : IAction<TEntity>;
    }
}