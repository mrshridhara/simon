using HangFire;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Simon.Infrastructure.HangFire
{
    /// <summary>
    /// Represents the background action queue.
    /// </summary>
    /// <typeparam name="TAction">The type of the action.</typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public class BackgroundActionQueue<TAction, TContext> : IAsyncActionQueue<TAction, TContext>
        where TAction : IAsyncAction<TContext>
    {
        /// <summary>
        /// Enqueues the specified <paramref name="action"/>.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="context">The context.</param>
        public async Task EnqueueAsync(TAction action, TContext context)
        {
            if (IsHangFireConfigured())
            {
                var contextAsJson = JsonConvert.SerializeObject(context);

                BackgroundJob.Enqueue<TAction>(
                    backgroundAction => backgroundAction.DeserializeAndExecute(contextAsJson));
            }
            else
            {
                await action.ExecuteAsync(context);
            }
        }

        [DebuggerStepThrough]
        private static bool IsHangFireConfigured()
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