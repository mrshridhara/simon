using Simon.Infrastructure;
using Simon.Processes.FileSystem;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    /// API to manipulate plug-ins data.
    /// </summary>
    public sealed class PluginsController : ApiController
    {
        private readonly IProcess<EmptyContext, GetInstalledPluginsResult> getInstalledPlugins;

        /// <summary>
        /// Initializes an instance of <see cref="PluginsController"/>.
        /// </summary>
        /// <param name="getInstalledPlugins">The get installed plug-ins process.</param>
        public PluginsController(
            IProcess<EmptyContext, GetInstalledPluginsResult> getInstalledPlugins)
        {
            this.getInstalledPlugins = getInstalledPlugins;
        }

        /// <summary>
        /// Gets the installed plug-ins.
        /// </summary>
        /// <returns>
        /// The installed plug-ins.
        /// </returns>
        public async Task<IHttpActionResult> Get()
        {
            var installedPluginsResult
                = await getInstalledPlugins.ExecuteAsync(EmptyContext.Instance);

            return Ok(installedPluginsResult.InstalledPlugins);
        }
    }
}