using Simon.Aspects;
using System.Threading.Tasks;

namespace Simon.Domain.Process
{
    /// <summary>
    /// Defines an async process which takes a context of type <typeparamref name="TContext"/>
    /// and returns the result of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TContext">The type of context.</typeparam>
    /// <typeparam name="TResult">The type of result.</typeparam>
    public interface IAsyncProcess<in TContext, TResult>
    {
        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;TResult&gt;"/></returns>
        [ArgumentsNotNull]
        Task<TResult> ExecuteAsync(TContext context);
    }

    /// <summary>
    /// Defines an async process which takes  a context of type <typeparamref name="TContext"/>
    /// and does not return any value.
    /// </summary>
    /// <typeparam name="TContext">The type of context.</typeparam>
    public interface IAsyncProcess<in TContext>
    {
        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task"/></returns>
        [ArgumentsNotNull]
        Task ExecuteAsync(TContext context);
    }
}