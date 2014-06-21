namespace Simon.BackgroundTasks
{
    /// <summary>
    /// Defines a background task with a context.
    /// </summary>
    /// <typeparam name="TContext">The type of context.</typeparam>
    public interface IBackgroundTask<TContext>
    {
        /// <summary>
        /// Executes the background task with the specified <paramref name="contextAsJson"/>.
        /// </summary>
        /// <param name="contextAsJson">The context in JSON format.</param>
        void ExecuteWithJson(string contextAsJson);

        /// <summary>
        /// Executes the background task with the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        void Execute(TContext context);
    }
}