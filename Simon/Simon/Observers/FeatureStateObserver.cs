using Simon.Actions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simon.Observers
{
    /// <summary>
    /// Represents a feature state observer.
    /// </summary>
    public sealed class FeatureStateObserver : IAsyncObserver<FeatureState>
    {
        private readonly IEnumerable<IAsyncStateAction<FeatureState>> stateActions;

        /// <summary>
        /// Initializes an instance of <see cref="FeatureStateObserver"/> class.
        /// </summary>
        /// <param name="stateActions">The state actions.</param>
        public FeatureStateObserver(IEnumerable<IAsyncStateAction<FeatureState>> stateActions)
        {
            this.stateActions = stateActions;
        }

        /// <summary>
        /// Updates the observer of the change in state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task for async operations.</returns>
        public async Task UpdateAsync(FeatureState entity)
        {
            foreach (var eachStateAction in stateActions)
            {
                if (eachStateAction.IsApplicable(entity))
                {
                    await eachStateAction.ExecuteAsync(entity);
                }
            }
        }
    }
}