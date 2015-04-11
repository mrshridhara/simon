﻿using Simon.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simon
{
    /// <summary>
    /// Represents an application.
    /// </summary>
    public sealed class Application : NamedEntityBase
    {
        private readonly List<Feature> _features = new List<Feature>();

        [NonSerialized]
        private Project project;

        /// <summary>
        /// Initializes an instance of <see cref="Application"/> class.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="features">The sequence of features.</param>
        public Application(Guid id, string name, string description, IEnumerable<Feature> features)
            : base(id, name, description)
        {
            if (features != null)
            {
                features.AsParallel().ForAll(AddFeature);
            }
        }

        /// <summary>
        /// Gets the sequence of features in the application.
        /// </summary>
        public IReadOnlyList<Feature> Features
        {
            get { return _features.AsReadOnly(); }
        }

        /// <summary>
        /// Gets the project to which this application belongs.
        /// </summary>
        internal Project Project { get { return project; } }

        /// <summary>
        /// Adds the specified <paramref name="newFeature"/> to this application.
        /// </summary>
        /// <param name="newFeature">The feature to be added.</param>
        public void AddFeature(Feature newFeature)
        {
            Guard.NotNullArgument("newFeature", newFeature);

            if (newFeature.Application != null)
                return;

            newFeature.SetApplication(this);
            if (newFeature.Id == Guid.Empty)
            {
                newFeature.SetId(Guid.NewGuid());
            }

            _features.Add(newFeature);
        }

        /// <summary>
        /// Sets the specified <paramref name="newProject"/> as the project for this application.
        /// </summary>
        /// <param name="newProject">The project to be set.</param>
        public void SetProject(Project newProject)
        {
            Guard.NotNullArgument("newProject", newProject);

            if (this.project != null)
            {
                throw new ApplicationException("Project can be set only once per instance.");
            }

            this.project = newProject;
        }
    }
}