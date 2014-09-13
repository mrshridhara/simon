using System;
using AutoMapper;
using Simon.Api.Web.Models;
using Simon.Infrastructure;

namespace Simon.Api.Web.Mappers
{
    /// <summary>
    /// Represents a mapper from <see cref="Version"/> to <see cref="SimonVersionModel"/>.
    /// </summary>
    public sealed class VersionToSimonVersionModelMapper
        : IMapper<Version, SimonVersionModel>
    {
        static VersionToSimonVersionModelMapper()
        {
            Mapper.CreateMap<Version, SimonVersionModel>()
                .ForMember(
                    dest => dest.DisplayText,
                    opt => opt.MapFrom(src => "v" + src.ToString(3) + " (pre-alpha)"));
        }

        /// <summary>
        /// Copies the data from <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>
        /// The copied instance.
        /// </returns>
        public SimonVersionModel Map(Version instance)
        {
            return Mapper.Map<Version, SimonVersionModel>(instance);
        }
    }
}