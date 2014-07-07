using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Represents the global settings of the Simon application.
    /// </summary>
    public sealed class GlobalSettings : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly IDictionary<string, string> settings;

        /// <summary>
        /// Initializes an instance of <see cref="GlobalSettings"/> class.
        /// </summary>
        /// <param name="settings">The settings sequence.</param>
        public GlobalSettings(IEnumerable<KeyValuePair<string, string>> settings)
        {
            this.settings
                = settings.ToDictionary(
                    eachSetting => eachSetting.Key,
                    eachSetting => eachSetting.Value);
        }

        /// <summary>
        /// Gets the empty instance of <see cref="GlobalSettings"/> class.
        /// </summary>
        public static readonly GlobalSettings Empty
            = new GlobalSettings(new Dictionary<string, string>());

        /// <summary>
        /// Gets the value of the setting specified in <paramref name="settingKey"/>.
        /// </summary>
        /// <param name="settingKey">The setting key.</param>
        /// <returns>
        /// The value of the setting specified in <paramref name="settingKey"/>.
        /// </returns>
        public string this[string settingKey]
        {
            get
            {
                string settingValue;
                if (settings.TryGetValue(settingKey, out settingValue))
                {
                    return settingValue;
                }

                return null;
            }
        }

        /// <summary>
        /// Adds the specified <paramref name="key"/> and <paramref name="value"/>
        /// to the current global settings instance.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, string value)
        {
            settings.Add(key, value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="IEnumerator&lt;T&gt;"/>
        /// that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return settings.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator"/> object that can be used to iterate through
        /// the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}