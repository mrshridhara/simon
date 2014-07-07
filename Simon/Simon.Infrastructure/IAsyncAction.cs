using Simon.Infrastructure.Aspects;
using System.Threading.Tasks;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines an action for an entity.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public interface IAsyncAction<in TContext>
    {
        /// <summary>
        /// Determines whether the action is applicable for the current state of the entity.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        [ArgumentsNotNull]
        bool IsApplicable(TContext context);

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The task.</returns>
        [ArgumentsNotNull]
        Task ExecuteAsync(TContext context);

        /// <summary>
        /// Deserialize and executes the action for the current state of the entity.
        /// </summary>
        /// <param name="contextInJson">The context in JSON format.</param>
        /// <returns>The task.</returns>
        [ArgumentsNotNull]
        [ArgumentsNotEmpty]
        Task DeserializeAndExecute(string contextInJson);
    }
}