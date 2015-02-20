using Simon.Infrastructure;
using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Represents the action deploys the feature to production.
    /// </summary>
    public sealed class DeployToProduction : ActionBase<Feature>
    {
        /// <summary>
        /// Initializes an instance of <see cref="DeployToProduction"/>class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public DeployToProduction(ISerializer serializer)
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
            // TODO: Deploy the main branch to production.
            // TODO: Mark as in production.
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
            return entity.State == FeatureState.ReadyForProduction;
        }
    }
}