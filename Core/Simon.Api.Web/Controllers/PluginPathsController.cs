using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    /// API to manipulate plug-in paths.
    /// </summary>
    public sealed class PluginPathsController : ApiController
    {
        private readonly IMapper<GlobalSettingsItem, PluginPathModel> globalSettingsItemToPluginPathModelMapper;
        private readonly IPersistence<GlobalSettings> globalSettingsPersistence;

        /// <summary>
        /// Initializes an instance of <see cref="PluginPathsController"/>.
        /// </summary>
        /// <param name="globalSettingsPersistence">The global settings persistence.</param>
        /// <param name="globalSettingsItemToPluginPathModelMapper">The global settings item to plug-in path model mapper.</param>
        public PluginPathsController(
            IPersistence<GlobalSettings> globalSettingsPersistence,
            IMapper<GlobalSettingsItem, PluginPathModel> globalSettingsItemToPluginPathModelMapper)
        {
            Guard.NotNullArgument("globalSettingsPersistence", globalSettingsPersistence);
            Guard.NotNullArgument("globalSettingsItemToPluginPathModelMapper", globalSettingsItemToPluginPathModelMapper);

            this.globalSettingsPersistence = globalSettingsPersistence;
            this.globalSettingsItemToPluginPathModelMapper = globalSettingsItemToPluginPathModelMapper;
        }

        /// <summary>
        /// Gets the plug-in navigation paths set under global settings.
        /// </summary>
        /// <returns>
        /// The plug-in navigation paths set under global settings.
        /// </returns>
        public async Task<IHttpActionResult> GetAsync()
        {
            var globalSettingsSequence = await globalSettingsPersistence.ReadAsync();
            var globalSettings = globalSettingsSequence.FirstOrDefault();

            if (globalSettings == null)
                return NotFound();

            var pluginPaths
                = globalSettings
                    .Where(eachSetting => eachSetting.Value.IsNavigationPath)
                    .Select(eachSetting => globalSettingsItemToPluginPathModelMapper.Map(eachSetting.Value));

            return Ok(pluginPaths);
        }
    }
}