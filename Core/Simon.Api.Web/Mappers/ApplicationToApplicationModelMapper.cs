using AutoMapper;
using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System;

namespace Simon.Api.Web.Mappers
{
    /// <summary>
    /// Represents a mapper from <see cref="Application"/> to <see cref="ApplicationModel"/>.
    /// </summary>
    public sealed class ApplicationToApplicationModelMapper
        : IMapper<Application, ApplicationModel>
    {
        static ApplicationToApplicationModelMapper()
        {
            Mapper.CreateMap<Application, ApplicationModel>()
                  .ForMember(
                    dest => dest.ProjectId,
                    opt => opt.MapFrom(
                        src => src.Project != null ? src.Project.Id : Guid.Empty));
        }

        /// <summary>
        /// Copies the data from <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>
        /// The copied instance.
        /// </returns>
        public ApplicationModel Map(Application instance)
        {
            Guard.NotNullArgument("instance", instance);

            return Mapper.Map<Application, ApplicationModel>(instance);
        }
    }
}