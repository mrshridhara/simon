using System.Collections.Generic;
using System.Linq;

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
        public IQueryable<Project> Projects { get; set; }
    }
}