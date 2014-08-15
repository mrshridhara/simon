using System;

namespace Simon.Api.Web.Models
{
    /// <summary>
    /// Represents an application
    /// </summary>
    public sealed class ApplicationModel
    {
        /// <summary>
        /// Gets or sets the ID for the instance.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the name for the instance.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description for the instance.
        /// </summary>
        public string Description { get; set; }
    }
}