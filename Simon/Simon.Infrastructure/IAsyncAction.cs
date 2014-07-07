using Simon.Infrastructure.Aspects;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines an action for an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAsyncAction<in TEntity>
    {
        /// <summary>
        /// Determines whether the action is applicable for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        [ArgumentsNotNull]
        bool IsApplicable(TEntity entity);

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The task.</returns>
        [ArgumentsNotNull]
        Task ExecuteAsync(TEntity entity);

        /// <summary>
        /// Deserialize and executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entityInJson">The entity in JSON format.</param>
        /// <returns>The task.</returns>
        [ArgumentsNotNull]
        [ArgumentsNotEmpty]
        Task DeserializeAndExecute(string entityInJson);
    }
}