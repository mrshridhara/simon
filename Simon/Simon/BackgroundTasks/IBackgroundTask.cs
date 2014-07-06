namespace Simon.BackgroundTasks
{
    /// <summary>
    /// Defines a background task with a context.
    /// </summary>
    /// <typeparam name="TContext">The type of context.</typeparam>
    public interface IBackgroundTask<TContext>
    {
        /// <summary>
        /// Enqueues the background task with the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        void Enqueue(TContext context);
    }
}