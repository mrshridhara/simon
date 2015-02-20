using AutoMapper;
using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;

namespace Simon.Api.Web.Mappers
{
    /// <summary>
    /// Represents a mapper from <see cref="Project"/> to <see cref="ProjectModel"/>.
    /// </summary>
    public sealed class ProjectToProjectModelMapper
        : IMapper<Project, ProjectModel>
    {
        private readonly IMapper<Application, ApplicationModel> applicationToApplicationModelMapper;

        static ProjectToProjectModelMapper()
        {
            Mapper.CreateMap<Project, ProjectModel>();
        }

        /// <summary>
        /// Initializes an instance of <see cref="ProjectToProjectModelMapper"/> class.
        /// </summary>
        /// <param name="applicationToApplicationModelMapper">The application model to application mapper.</param>
        public ProjectToProjectModelMapper(
            IMapper<Application, ApplicationModel> applicationToApplicationModelMapper)
        {
            Guard.NotNullArgument("applicationToApplicationModelMapper", applicationToApplicationModelMapper);

            this.applicationToApplicationModelMapper = applicationToApplicationModelMapper;
        }

        /// <summary>
        /// Copies the data from <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>
        /// The copied instance.
        /// </returns>
        public ProjectModel Map(Project instance)
        {
            Guard.NotNullArgument("instance", instance);

            return Mapper.Map<Project, ProjectModel>(instance);
        }
    }
}