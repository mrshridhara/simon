using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Simon.Api.Web.Mappers
{
    /// <summary>
    /// Represents a mapper from <see cref="ProjectModel"/> to <see cref="Project"/>.
    /// </summary>
    public sealed class ProjectModelToProjectMapper
        : IMapper<ProjectModel, Project>
    {
        private readonly IMapper<ApplicationModel, Application> applicationModelToApplicationMapper;

        /// <summary>
        /// Initializes an instance of <see cref="ProjectModelToProjectMapper"/> class.
        /// </summary>
        /// <param name="applicationModelToApplicationMapper">The application model to application mapper.</param>
        public ProjectModelToProjectMapper(
            IMapper<ApplicationModel, Application> applicationModelToApplicationMapper)
        {
            Guard.NotNullArgument(nameof(applicationModelToApplicationMapper), applicationModelToApplicationMapper);

            this.applicationModelToApplicationMapper = applicationModelToApplicationMapper;
        }

        /// <summary>
        /// Copies the data from <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>
        /// The copied instance.
        /// </returns>
        public Project Map(ProjectModel instance)
        {
            Guard.NotNullArgument(nameof(instance), instance);

            IEnumerable<Application> applications = null;
            if (instance.Applications != null)
            {
                applications = instance.Applications
                    .Select(
                        eachApplication =>
                            applicationModelToApplicationMapper.Map(eachApplication));
            }

            return new Project(
                instance.Id.GetValueOrDefault(),
                instance.Name,
                instance.Description,
                applications);
        }
    }
}