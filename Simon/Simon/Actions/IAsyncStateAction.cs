using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Defines a state action for an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of te entity.</typeparam>
    public interface IAsyncStateAction<TEntity>
    {
        /// <summary>
        /// Determines whether the action is applicable for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The entity instance.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        bool IsApplicable(TEntity entiry);

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The entity instance.</param>
        /// <returns>The rule status.</returns>
        Task ExecuteAsync(TEntity entiry);
    }
}