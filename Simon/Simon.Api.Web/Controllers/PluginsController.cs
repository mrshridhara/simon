using System.Threading.Tasks;
using System.Web.Http;
using Simon.Infrastructure;
using Simon.Processes.FileSystem;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    /// API to manipulate plugins data.
    /// </summary>
    public sealed class PluginsController : ApiController
    {
        private readonly IAsyncProcess<EmptyContext, GetInstalledPluginsResult> getInstalledPlugins;

        /// <summary>
        /// Initializes an instance of <see cref="PluginsController"/>.
        /// </summary>
        /// <param name="getInstalledPlugins">The get installed plugins process.</param>
        public PluginsController(
            IAsyncProcess<EmptyContext, GetInstalledPluginsResult> getInstalledPlugins)
        {
            this.getInstalledPlugins = getInstalledPlugins;
        }

        /// <summary>
        /// Gets the installed plugins.
        /// </summary>
        /// <returns>
        /// The installed plugins.
        /// </returns>
        public async Task<IHttpActionResult> Get()
        {
            var installedPluginsResult
                = await getInstalledPlugins.ExecuteAsync(EmptyContext.Instance);

            return Ok(installedPluginsResult.InstalledPlugins);
        }
    }
}