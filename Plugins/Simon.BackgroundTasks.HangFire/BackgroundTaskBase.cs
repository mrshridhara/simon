using HangFire;
using Newtonsoft.Json;

namespace Simon.BackgroundTasks.HangFire
{
    /// <summary>
    /// Represents the base class of a background task.
    /// </summary>
    /// <typeparam name="TContext">The type of context.</typeparam>
    public abstract class BackgroundTaskBase<TContext> : IBackgroundTask<TContext>
    {
        /// <summary>
        /// Enqueues the background task with the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Enqueue(TContext context)
        {
            dynamic task = this;

            EnqueueJob(task, context);
        }

        /// <summary>
        /// Executes the background task with the specified <paramref name="contextAsJson"/>.
        /// </summary>
        /// <param name="contextAsJson">The context in JSON format.</param>
        public void ExecuteWithJson(string contextAsJson)
        {
            var context = JsonConvert.DeserializeObject<TContext>(contextAsJson);

            Execute(context);
        }

        /// <summary>
        /// Executes the background task with the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        public abstract void Execute(TContext context);

        private static void EnqueueJob<TBackgroundTask>(TBackgroundTask backgroundTaskBase, TContext context)
            where TBackgroundTask : BackgroundTaskBase<TContext>
        {
            var contextAsJson = JsonConvert.SerializeObject(context);

            BackgroundJob.Enqueue<TBackgroundTask>(task => task.ExecuteWithJson(contextAsJson));
        }
    }
}