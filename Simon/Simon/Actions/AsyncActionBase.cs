using Simon.Infrastructure;
using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Defines a base class for actions.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public abstract class AsyncActionBase<TContext> : IAsyncAction<TContext>
    {
        private readonly ISerializer<TContext> serializer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serializer"></param>
        public AsyncActionBase(ISerializer<TContext> serializer)
        {
            this.serializer = serializer;
        }

        /// <summary>
        /// Determines whether the action is applicable for the current state of the entity.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        public abstract bool IsApplicable(TContext context);

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The context.</param>
        /// <returns>The task.</returns>
        public abstract Task ExecuteAsync(TContext entiry);

        /// <summary>
        /// Deserialize and executes the action for the current state of the entity.
        /// </summary>
        /// <param name="contextInJson">The context in JSON format.</param>
        /// <returns>The task.</returns>
        public async Task DeserializeAndExecute(string contextInJson)
        {
            await ExecuteAsync(await serializer.DeserializeAsync(contextInJson));
        }
    }
}