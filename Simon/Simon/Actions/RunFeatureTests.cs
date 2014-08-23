using Simon.Infrastructure;
using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Represents the action which runs the feature tests.
    /// </summary>
    public sealed class RunFeatureTests : AsyncActionBase<Feature>
    {
        /// <summary>
        /// Initializes an instance of <see cref="RunFeatureTests"/>class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public RunFeatureTests(ISerializer serializer)
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
            return entity.State == FeatureState.ReadyForFeatureTesting;
        }

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The task.</returns>
        public override Task ExecuteAsync(Feature entity)
        {
            // TODO: Run feature tests.
            // TODO: If tests are passing, mark as ready for integration testing.
            // TODO: Else, mark as failed testing.
            // TODO: Save the feature to the persistance.
            throw new System.NotImplementedException();
        }
    }
}