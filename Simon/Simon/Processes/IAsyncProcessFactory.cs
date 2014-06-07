using Simon.Aspects;

namespace Simon.Processes
{
    /// <summary>
    /// Defines a factory for creating async processes.
    /// </summary>
    public interface IAsyncProcessFactory
    {
        /// <summary>
        /// Creates an async process which takes a context of type <typeparamref name="TContext"/>
        /// and returns the result of type <typeparamref name="TResult"/>.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <typeparam name="TContext">The type of context.</typeparam>
        /// <typeparam name="TResult">The type of result.</typeparam>
        /// <returns>An instacnce of <see cref="IAsyncProcess&lt;TContext, TResult&gt;"/>.</returns>
        [ArgumentsNotNull]
        IAsyncProcess<TContext, TResult> CreateAsyncProcess<TContext, TResult>(
            GlobalSettings globalSettings);

        /// <summary>
        /// Creates an async process which takes  a context of type <typeparamref name="TContext"/>
        /// and does not return any value.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <typeparam name="TContext">The type of context.</typeparam>
        /// <returns>An instacnce of <see cref="IAsyncProcess&lt;TContext&gt;"/>.</returns>
        [ArgumentsNotNull]
        IAsyncProcess<TContext> CreateAsyncProcess<TContext>(GlobalSettings globalSettings);
    }
}