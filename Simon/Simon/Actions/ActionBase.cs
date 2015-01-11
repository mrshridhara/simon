using Simon.Infrastructure;
using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Defines a base class for actions.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class ActionBase<TEntity> : IAction<TEntity>
    {
        private readonly ISerializer serializer;

        /// <summary>
        /// Initializes an instance of <see cref="ActionBase&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        protected ActionBase(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        /// <summary>
        /// De-serialize and executes the action for the current state of the entity.
        /// </summary>
        /// <param name="serializedEntity">The serialized entity.</param>
        /// <returns>The task.</returns>
        public async Task DeserializeAndExecute(string serializedEntity)
        {
            var entity = await serializer.DeserializeAsync<TEntity>(serializedEntity);
            await ExecuteAsync(entity);
        }

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The task.</returns>
        public abstract Task ExecuteAsync(TEntity entity);

        /// <summary>
        /// Determines whether the action is applicable for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        public abstract bool IsApplicable(TEntity entity);
    }
}