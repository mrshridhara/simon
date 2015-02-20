using System.Collections.Generic;

namespace Simon.Processes.Database
{
    /// <summary>
    /// Represents the result of getting all projects.
    /// </summary>
    public sealed class GetAllProjectsResult
    {
        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        public IEnumerable<Project> Projects { get; set; }
    }
}