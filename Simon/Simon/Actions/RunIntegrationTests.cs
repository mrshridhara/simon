using Simon.Infrastructure;
using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Represents the action runs the integration tests.
    /// </summary>
    public sealed class RunIntegrationTests : ActionBase<Feature>
    {
        /// <summary>
        /// Initializes an instance of <see cref="RunIntegrationTests"/>class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public RunIntegrationTests(ISerializer serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The task.</returns>
        public override Task ExecuteAsync(Feature entity)
        {
            // TODO: Merge main branch to feature branch.
            // TODO: Run all the tests.
            // TODO: If tests are passing, deploy feature branch to test environment.
            // TODO: Update the feature with test link.
            // TODO: Mark as ready for manual testing.
            // TODO: Else, mark as failed testing.
            // TODO: Save the feature to the persistence.
            throw new System.NotImplementedException();
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
    }
}