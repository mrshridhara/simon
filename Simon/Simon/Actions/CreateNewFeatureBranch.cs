using Simon.Infrastructure;
using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Represents the action which creates new feature branch.
    /// </summary>
    public sealed class CreateNewFeatureBranch : AsyncActionBase<Feature>
    {
        /// <summary>
        /// Initializes an instance of <see cref="CreateNewFeatureBranch"/>class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public CreateNewFeatureBranch(ISerializer serializer)
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
            return entity.State == FeatureState.NewFeature;
        }

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The entity.</param>
        /// <returns>The task.</returns>
        public override Task ExecuteAsync(Feature entiry)
        {
            // TODO: Create new feature branch if it does not exists.

            throw new System.NotImplementedException();
        }
    }
}