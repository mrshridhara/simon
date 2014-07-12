using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    /// API to manipulate project data.
    /// </summary>
    public class SettingsController : ApiController
    {
        private readonly IAsyncPersistence<GlobalSettings> globalSettingsPersistence;

        /// <summary>
        /// Initializes an instance of <see cref="SettingsController"/>.
        /// </summary>
        /// <param name="globalSettingsPersistence">The global settings persistence.</param>
        public SettingsController(
            IAsyncPersistence<GlobalSettings> globalSettingsPersistence)
        {
            Guard.NotNullArgument("globalSettingsPersistence", globalSettingsPersistence);

            this.globalSettingsPersistence = globalSettingsPersistence;
        }

        /// <summary>
        /// Gets the global settings.
        /// </summary>
        /// <returns>
        /// The global settings.
        /// </returns>
        public async Task<IHttpActionResult> GetAsync()
        {
            return await Task.Run<IHttpActionResult>(async () =>
            {
                var globalSettingsSequence = await globalSettingsPersistence.ReadAll();
                var globalSettings = globalSettingsSequence.FirstOrDefault();

                if (globalSettings == null)
                    return NotFound();

                return Ok(globalSettings.AsEnumerable());
            });
        }

        /// <summary>
        /// Updates the specified <paramref name="globalSettings"/>.
        /// </summary>
        /// <param name="globalSettings">The global settings taken from HTTP body.</param>
        /// <returns>
        /// Status of the addition.
        /// </returns>
        public async Task<IHttpActionResult> PutAsync([FromBody]IEnumerable<KeyValuePair<string, string>> globalSettings)
        {
            return await Task.Run<IHttpActionResult>(async () =>
            {
                await globalSettingsPersistence.Update(new GlobalSettings(globalSettings));
                return Ok();
            });
        }
    }
}