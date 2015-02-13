using AutoMapper;
using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;

namespace Simon.Api.Web.Mappers
{
    /// <summary>
    /// Represents a mapper from <see cref="GlobalSettingsItem"/> to <see cref="PluginPathModel"/>.
    /// </summary>
    public sealed class GlobalSettingsItemToPluginPathModelMapper
        : IMapper<GlobalSettingsItem, PluginPathModel>
    {
        static GlobalSettingsItemToPluginPathModelMapper()
        {
            Mapper.CreateMap<GlobalSettingsItem, PluginPathModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Value));
        }

        /// <summary>
        /// Copies the data from <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>
        /// The copied instance.
        /// </returns>
        public PluginPathModel Map(GlobalSettingsItem instance)
        {
            Guard.NotNullArgument("instance", instance);

            return Mapper.Map<GlobalSettingsItem, PluginPathModel>(instance);
        }
    }
}