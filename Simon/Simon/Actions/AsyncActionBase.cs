using System.Threading.Tasks;
using Simon.Infrastructure;

namespace Simon.Actions
{
    /// <summary>
    /// Defines a base class for actions.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class AsyncActionBase<TEntity> : IAsyncAction<TEntity>
    {
        private readonly ISerializer serializer;

        /// <summary>
        /// Initializes an instance of <see cref="AsyncActionBase&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        protected AsyncActionBase(ISerializer serializer)
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
        /// <param name="entity">The entity.</param>
        /// <returns>The task.</returns>
        public abstract Task ExecuteAsync(TEntity entity);

        /// <summary>
        /// De-serialize and executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entityInJson">The entity in JSON format.</param>
        /// <returns>The task.</returns>
        public async Task DeserializeAndExecute(string entityInJson)
        {
            var entity = await serializer.DeserializeAsync<TEntity>(entityInJson);
            await ExecuteAsync(entity);
        }
    }
}