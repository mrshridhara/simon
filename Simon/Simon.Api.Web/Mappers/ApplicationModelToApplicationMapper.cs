using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;

namespace Simon.Api.Web.Mappers
{
    /// <summary>
    /// Represents a mapper from <see cref="ApplicationModel"/> to <see cref="Application"/>.
    /// </summary>
    public sealed class ApplicationModelToApplicationMapper
        : IMapper<ApplicationModel, Application>
    {
        /// <summary>
        /// Copies the data from <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>
        /// The copied instance.
        /// </returns>
        public Application Map(ApplicationModel instance)
        {
            Guard.NotNullArgument("instance", instance);

            return new Application(
                instance.Id.GetValueOrDefault(),
                instance.Name,
                instance.Description,
                null);
        }
    }
}