using Simon.Infrastructure;
using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Defines a base class for actions.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class AsyncActionBase<TEntity> : IAsyncAction<TEntity>
    {
        private readonly ISerializer<TEntity> serializer;

        /// <summary>
        /// Initializes an instance of <see cref="AsyncActionBase&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        protected AsyncActionBase(ISerializer<TEntity> serializer)
        {
            this.serializer = serializer;
        }

        /// <summary>
        /// Determines whether the action is applicable for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        public abstract bool IsApplicable(TEntity entity);

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The entity.</param>
        /// <returns>The task.</returns>
        public abstract Task ExecuteAsync(TEntity entiry);

        /// <summary>
        /// Deserialize and executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entityInJson">The entity in JSON format.</param>
        /// <returns>The task.</returns>
        public async Task DeserializeAndExecute(string entityInJson)
        {
            await ExecuteAsync(await serializer.DeserializeAsync(entityInJson));
        }
    }
}