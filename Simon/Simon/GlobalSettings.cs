using System.Collections.Generic;

namespace Simon
{
    /// <summary>
    /// Represents the global settings of the Simon application.
    /// </summary>
    public sealed class GlobalSettings
    {
        private readonly IDictionary<string, dynamic> settings;

        /// <summary>
        /// Initializes an instance of <see cref="GlobalSettings"/> class.
        /// </summary>
        /// <param name="settings">The settings dictionary.</param>
        public GlobalSettings(IDictionary<string, dynamic> settings)
        {
            this.settings = settings;
        }

        /// <summary>
        /// Gets the value of the setting specified in <paramref name="settingKey"/>.
        /// </summary>
        /// <param name="settingKey">The setting key.</param>
        /// <returns>
        /// The value of the setting specified in <paramref name="settingKey"/>.
        /// </returns>
        public dynamic this[string settingKey]
        {
            get
            {
                return this.settings[settingKey];
            }
        }
    }
}