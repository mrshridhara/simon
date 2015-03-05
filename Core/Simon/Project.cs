using Simon.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simon
{
    /// <summary>
    /// Represents a project.
    /// </summary>
    public sealed class Project : NamedEntityBase
    {
        private List<Application> _applications;
        private List<Application> _Applications
        {
            get
            {
                if (_applications == null)
                {
                    _applications = new List<Application>();
                }

                return _applications;
            }
        }

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
            get { return _Applications.AsReadOnly(); }
        }

        /// <summary>
        /// Adds the specified <paramref name="newApplication"/> to this project.
        /// </summary>
        /// <param name="newApplication">The application to be added.</param>
        public void AddApplication(Application newApplication)
        {
            Guard.NotNullArgument("newApplication", newApplication);

            newApplication.SetProject(this);
            newApplication.SetId(Guid.NewGuid());
            _Applications.Add(newApplication);
        }

        /// <summary>
        /// Adds the specified <paramref name="updatedApplication"/> to this project.
        /// </summary>
        /// <param name="updatedApplication">The application to be added.</param>
        public void ReplaceApplication(Application updatedApplication)
        {
            Guard.NotNullArgument("updatedApplication", updatedApplication);

            if (updatedApplication.Id == Guid.Empty)
            {
                throw new ArgumentException(
                    "Application should contain a valid ID field.",
                    "updatedApplication");
            }

            var existingApplication
                = _Applications.FirstOrDefault(
                    eachApplication => eachApplication.Id == updatedApplication.Id);

            if (existingApplication == null)
            {
                throw new ArgumentException(
                    "Application with the specified ID does not exist.",
                    "updatedApplication");
            }

            updatedApplication.SetProject(this);
            _Applications.Remove(existingApplication);
            _Applications.Add(updatedApplication);
        }
    }
}