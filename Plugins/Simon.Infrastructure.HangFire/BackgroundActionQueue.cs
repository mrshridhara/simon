using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Hangfire;

namespace Simon.Infrastructure.Hangfire
{
    /// <summary>
    /// Represents the background action queue.
    /// </summary>
    public class BackgroundActionQueue : IAsyncActionQueue
    {
        private readonly ISerializer serializer;

        /// <summary>
        /// Initializes an instance of <see cref="BackgroundActionQueue"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        protected BackgroundActionQueue(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        /// <summary>
        /// Enqueues the specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TAction">The type of the action.</typeparam>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        public async Task EnqueueAsync<TAction, TEntity>(TAction action, TEntity entity)
            where TAction : IAsyncAction<TEntity>
        {
            if (IsHangfireConfigured())
            {
                var entityAsJson = await this.serializer.SerializeAsync(entity);

                BackgroundJob.Enqueue<TAction>(
                    backgroundAction => backgroundAction.DeserializeAndExecute(entityAsJson));
            }
            else
            {
                await action.ExecuteAsync(entity);
            }
        }

        [DebuggerStepThrough]
        private static bool IsHangfireConfigured()
        {
            try
            {
                return (JobStorage.Current != null && JobActivator.Current != null);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}