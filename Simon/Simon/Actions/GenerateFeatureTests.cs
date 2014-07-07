using Simon.Infrastructure;
using System.Threading.Tasks;

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
        public GenerateFeatureTests(ISerializer<Feature> serializer)
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
        /// <param name="entiry">The entity.</param>
        /// <returns>The task.</returns>
        public override Task ExecuteAsync(Feature entiry)
        {
            throw new System.NotImplementedException();
        }
    }
}