using System;
using System.Collections.Generic;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;

namespace Simon
{
    /// <summary>
    /// Represents a feature of an application.
    /// </summary>
    public sealed class Feature : NamedEntityBase
    {
        [NonSerialized]
        private IEnumerable<IAsyncObserver<Feature>> featureObservers;

        [NonSerialized]
        private Application application;

        /// <summary>
        /// Initializes an instance of <see cref="Feature"/> class.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="state">The feature state.</param>
        public Feature(Guid id, string name, string description, FeatureState state)
            : base(id, name, description)
        {
            Guard.NotNullArgument("featureObservers", featureObservers);

            this.State = state;
        }

        /// <summary>
        /// Gets the state of feature.
        /// </summary>
        public FeatureState State { get; private set; }

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
        /// Gets or sets the feature branch in the source control repository.
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// Gets the application to which the feature belongs.
        /// </summary>
        internal Application Application { get { return application; } }

        /// <summary>
        /// Sets the observers to be used.
        /// </summary>
        /// <param name="featureObservers">The feature observers.</param>
        public void SetObservers(IEnumerable<IAsyncObserver<Feature>> featureObservers)
        {
            this.featureObservers = featureObservers;
        }

        /// <summary>
        /// Sets the specified <paramref name="newApplication"/> as the application for this feature.
        /// </summary>
        /// <param name="newApplication">The application to be set.</param>
        public void SetApplication(Application newApplication)
        {
            Guard.NotNullArgument("newApplication", newApplication);

            if (this.application != null)
            {
                throw new ApplicationException("Application can be set only once per instance.");
            }

            this.application = newApplication;
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