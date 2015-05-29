using AutoMapper;
using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;

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
            Mapper.CreateMap<Application, ApplicationModel>();
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
            Guard.NotNullArgument(nameof(instance), instance);

            return Mapper.Map<Application, ApplicationModel>(instance);
        }
    }
}