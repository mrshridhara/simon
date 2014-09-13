using System.Threading.Tasks;
using Simon.Infrastructure;

namespace Simon.Actions
{
    /// <summary>
    /// Represents the action which generates the feature tests.
    /// </summary>
    public sealed class GenerateFeatureTests : AsyncActionBase<Feature>
    {
        /// <summary>
        /// Initializes an instance of <see cref="GenerateFeatureTests"/>class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public GenerateFeatureTests(ISerializer serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Determines whether the action is applicable for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        public override bool IsApplicable(Feature entity)
        {
            return entity.State == FeatureState.RequirementsCompleted;
        }

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The task.</returns>
        public override Task ExecuteAsync(Feature entity)
        {
            // TODO: Generate feature tests.
            // TODO: Mark feature as ready for development.
            // TODO: Save the feature to the persistence.
            throw new System.NotImplementedException();
        }
    }
}