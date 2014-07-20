using Simon.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simon.Observers
{
    /// <summary>
    /// Represents a feature state observer.
    /// </summary>
    public sealed class FeatureStateObserver : IAsyncObserver<Feature>
    {
        private readonly IEnumerable<IAsyncAction<Feature>> stateActions;
        private readonly IAsyncActionQueue asyncActionQueue;

        /// <summary>
        /// Initializes an instance of <see cref="FeatureStateObserver"/> class.
        /// </summary>
        /// <param name="featureActions">The state actions.</param>
        /// <param name="asyncActionQueue">The async action queue.</param>
        public FeatureStateObserver(
            IEnumerable<IAsyncAction<Feature>> featureActions,
            IAsyncActionQueue asyncActionQueue)
        {
            this.stateActions = featureActions;
            this.asyncActionQueue = asyncActionQueue;
        }

        /// <summary>
        /// Updates the observer of the change in state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task for async operations.</returns>
        public async Task UpdateAsync(Feature entity)
        {
            foreach (dynamic eachFeatureAction in stateActions)
            {
                if (eachFeatureAction.IsApplicable(entity))
                {
                    await asyncActionQueue.EnqueueAsync(eachFeatureAction, entity);
                }
            }
        }
    }
}