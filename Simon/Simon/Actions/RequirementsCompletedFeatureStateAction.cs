using Simon.BackgroundTasks;
using System.Threading.Tasks;

namespace Simon.Actions
{
    /// <summary>
    /// Represents the state action for requirements completed feature state.
    /// </summary>
    public sealed class RequirementsCompletedFeatureStateAction : IAsyncStateAction<Feature>
    {
        private readonly IBackgroundTask<GenerateFeatureTestsContext> generateFeatureTestsTask;

        /// <summary>
        /// Initializes an instance of <see cref="RequirementsCompletedFeatureStateAction"/> class.
        /// </summary>
        /// <param name="generateFeatureTestsTask">The generate feature tests task.</param>
        public RequirementsCompletedFeatureStateAction(IBackgroundTask<GenerateFeatureTestsContext> generateFeatureTestsTask)
        {
            this.generateFeatureTestsTask = generateFeatureTestsTask;
        }

        /// <summary>
        /// Determines whether the action is applicable for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The entity instance.</param>
        /// <returns>
        /// <c>true</c> if the rule is applicable for the
        /// current state of the entity, otherwise; <c>false</c>.
        /// </returns>
        public bool IsApplicable(Feature entiry)
        {
            return entiry.State == FeatureState.RequirementsCompleted;
        }

        /// <summary>
        /// Executes the action for the current state of the entity.
        /// </summary>
        /// <param name="entiry">The entity instance.</param>
        /// <returns>The task.</returns>
        public Task ExecuteAsync(Feature entiry)
        {
            return Task.Run(() =>
            {
                generateFeatureTestsTask.Enqueue(new GenerateFeatureTestsContext { Feature = entiry });
            });
        }
    }
}
