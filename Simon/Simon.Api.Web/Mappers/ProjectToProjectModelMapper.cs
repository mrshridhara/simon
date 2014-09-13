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
        static ProjectToProjectModelMapper()
        {
            Mapper.CreateMap<Application, ApplicationModel>();
            Mapper.CreateMap<Project, ProjectModel>();
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