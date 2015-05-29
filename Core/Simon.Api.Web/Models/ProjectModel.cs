using System;
using System.Collections.Generic;

namespace Simon.Api.Web.Models
{
    /// <summary>
    /// Represents a project.
    /// </summary>
    public sealed class ProjectModel
    {
        /// <summary>
        /// Gets or sets the applications.
        /// </summary>
        public IEnumerable<ApplicationModel> Applications { get; set; }

        /// <summary>
        /// Gets or sets the description for the instance.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID for the instance.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the name for the instance.
        /// </summary>
        public string Name { get; set; }
    }
}