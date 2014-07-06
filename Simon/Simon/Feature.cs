using Simon.Observers;
using Simon.Utilities;
using System;
using System.Collections.Generic;

namespace Simon
{
    /// <summary>
    /// Represents a feature of an application.
    /// </summary>
    public sealed class Feature : NamedEntityBase
    {
        private readonly IEnumerable<IAsyncObserver<Feature>> featureObservers;

        /// <summary>
        /// Inititalizes an instance of <see cref="Feature"/> class.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="state">The feature state.</param>
        /// <param name="featureObservers">The observers of feature.</param>
        public Feature(Guid id, string name, string description, FeatureState state, IEnumerable<IAsyncObserver<Feature>> featureObservers)
            : base(id, name, description)
        {
            Guard.NotNullArgument("featureObservers", featureObservers);

            this.State = state;
            this.featureObservers = featureObservers;
        }

        /// <summary>
        /// Gets the state of feature.
        /// </summary>
        public FeatureState State { get; private set; }

        /// <summary>
        /// Gets the application to which the feature belongs.
        /// </summary>
        public Application Application { get; private set; }

        /// <summary>
        /// Gets or sets the user who created the feature.
        /// </summary>
        public User CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user who modified the feature.
        /// </summary>
        public User ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the user who signed off the feature.
        /// </summary>
        public User SignedOffBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the feature was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the feature was modified.
        /// </summary>
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the feature branch in the source control repositiry.
        /// </summary>
        public SourceControlBranch Branch { get; set; }

        /// <summary>
        /// Sets the specified <paramref name="newApplication"/> as the application for this feature.
        /// </summary>
        /// <param name="newApplication">The application to be set.</param>
        public void SetApplication(Application newApplication)
        {
            Guard.NotNullArgument("newApplication", newApplication);

            if (this.Application != null)
            {
                throw new ApplicationException("Application can be set only once per instance.");
            }

            this.Application = newApplication;
        }

        /// <summary>
        /// Sets the specified <paramref name="newState"/> as the state for this feature.
        /// </summary>
        /// <param name="newState">The state to be set.</param>
        public void SetState(FeatureState newState)
        {
            Guard.NotDefaultValueArgument("newState", newState);

            this.State = newState;
            foreach (var eachFeatureObserver in featureObservers)
            {
                eachFeatureObserver.UpdateAsync(this);
            }
        }
    }
}