using Simon.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simon.Domain
{
    /// <summary>
    /// Represents a project.
    /// </summary>
    public class Project : DomainBase
    {
        private readonly List<Application> applications;

        /// <summary>
        /// Initializes an instance of a <see cref="Project"/> class.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="applications">The sequence of applications.</param>
        public Project(Guid id, string name, string description, IEnumerable<Application> applications)
            : base(id, name, description)
        {
            this.applications = new List<Application>();

            if (applications != null)
            {
                applications.AsParallel().ForAll(AddApplication);
            }
        }

        /// <summary>
        /// Gets the sequence of applications in the project.
        /// </summary>
        public IEnumerable<Application> Applications
        {
            get { return applications.AsReadOnly(); }
        }

        /// <summary>
        /// Adds the sepecified <paramref name="newApplication"/> to this project.
        /// </summary>
        /// <param name="newApplication">The application to be added.</param>
        public void AddApplication(Application newApplication)
        {
            Guard.NotNullArgument("newApplication", newApplication);

            newApplication.SetProject(this);
            this.applications.Add(newApplication);
        }
    }
}