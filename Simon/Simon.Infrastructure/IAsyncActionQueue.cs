using Simon.Infrastructure.Aspects;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public interface IAsyncActionQueue<in TAction, in TContext>
        where TAction : IAsyncAction<TContext>
    {
        /// <summary>
        /// Enqueues the specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="context">The context.</param>
        [ArgumentsNotNull]
        Task EnqueueAsync(TAction action, TContext context);
    }
}