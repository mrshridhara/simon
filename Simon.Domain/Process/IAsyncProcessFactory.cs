namespace Simon.Domain.Process
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
        /// <typeparam name="TContext">The type of context.</typeparam>
        /// <typeparam name="TResult">The type of result.</typeparam>
        /// <returns>An instacnce of <see cref="IAsyncProcess&lt;TContext, TResult&gt;"/>.</returns>
        IAsyncProcess<TContext, TResult> CreateAsyncProcess<TContext, TResult>();

        /// <summary>
        /// Creates an async process which takes  a context of type <typeparamref name="TContext"/>
        /// and does not return any value.
        /// </summary>
        /// <typeparam name="TContext">The type of context.</typeparam>
        /// <returns>An instacnce of <see cref="IAsyncProcess&lt;TContext&gt;"/>.</returns>
        IAsyncProcess<TContext> CreateAsyncProcess<TContext>();
    }
}