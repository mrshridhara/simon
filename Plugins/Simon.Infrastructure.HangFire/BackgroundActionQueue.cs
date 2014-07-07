using Hangfire;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Simon.Infrastructure.Hangfire
{
    /// <summary>
    /// Represents the background action queue.
    /// </summary>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class BackgroundActionQueue<TAction, TEntity> : IAsyncActionQueue<TAction, TEntity>
        where TAction : IAsyncAction<TEntity>
    {
        /// <summary>
        /// Enqueues the specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        public async Task EnqueueAsync(TAction action, TEntity entity)
        {
            if (IsHangfireConfigured())
            {
                var entityAsJson = JsonConvert.SerializeObject(entity);

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