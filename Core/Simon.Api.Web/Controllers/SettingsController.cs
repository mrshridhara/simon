﻿using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    /// API to manipulate settings data.
    /// </summary>
    public sealed class SettingsController : ApiController
    {
        private readonly IPersistence<GlobalSettings> globalSettingsPersistence;

        /// <summary>
        /// Initializes an instance of <see cref="SettingsController"/>.
        /// </summary>
        /// <param name="globalSettingsPersistence">The global settings persistence.</param>
        public SettingsController(
            IPersistence<GlobalSettings> globalSettingsPersistence)
        {
            Guard.NotNullArgument(nameof(globalSettingsPersistence), globalSettingsPersistence);

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
            var globalSettingsSequence = await globalSettingsPersistence.ReadAsync();
            var globalSettings = globalSettingsSequence.FirstOrDefault();

            if (globalSettings == null)
                return NotFound();

            return Ok(globalSettings.AsEnumerable());
        }

        /// <summary>
        /// Updates the specified <paramref name="globalSettings"/>.
        /// </summary>
        /// <param name="globalSettings">The global settings taken from HTTP body.</param>
        /// <returns>
        /// Status of the addition.
        /// </returns>
        public async Task<IHttpActionResult> PostAsync([FromBody]IEnumerable<KeyValuePair<string, GlobalSettingsItem>> globalSettings)
        {
            await globalSettingsPersistence.UpdateAsync(new GlobalSettings(globalSettings));
            return Ok();
        }
    }
}