using Simon.Infrastructure.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Represents the global settings of the Simon application.
    /// </summary>
    public sealed class GlobalSettings : IEnumerable<KeyValuePair<string, GlobalSettingsItem>>
    {
        /// <summary>
        /// Gets the empty instance of <see cref="GlobalSettings"/> class.
        /// </summary>
        public static readonly GlobalSettings Empty
            = new GlobalSettings(new Dictionary<string, GlobalSettingsItem>());

        private readonly IDictionary<string, GlobalSettingsItem> settings;

        /// <summary>
        /// Initializes an instance of <see cref="GlobalSettings"/> class.
        /// </summary>
        /// <param name="settings">The settings sequence.</param>
        public GlobalSettings(IEnumerable<KeyValuePair<string, GlobalSettingsItem>> settings)
        {
            Guard.NotNullArgument(nameof(settings), settings);

            this.settings
                = settings.ToDictionary(
                    eachSetting => eachSetting.Key,
                    eachSetting => eachSetting.Value);
        }

        /// <summary>
        /// Gets the value of the setting specified in <paramref name="settingKey"/>.
        /// </summary>
        /// <param name="settingKey">The setting key.</param>
        /// <returns>
        /// The value of the setting specified in <paramref name="settingKey"/>.
        /// </returns>
        public GlobalSettingsItem this[string settingKey]
        {
            get
            {
                Guard.NotNullOrEmptyStringArgument(nameof(settingKey), settingKey);

                GlobalSettingsItem settingItem;
                if (settings.TryGetValue(settingKey, out settingItem))
                {
                    return settingItem;
                }

                return null;
            }
        }

        /// <summary>
        /// Adds the specified <paramref name="key"/> and <paramref name="item"/>
        /// to the current global settings instance.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        public void Add(string key, GlobalSettingsItem item)
        {
            Guard.NotNullOrEmptyStringArgument(nameof(key), key);
            Guard.NotNullArgument(nameof(item), item);

            settings.Add(key, item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="IEnumerator&lt;T&gt;"/>
        /// that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, GlobalSettingsItem>> GetEnumerator() => settings.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator"/> object that can be used to iterate through
        /// the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}