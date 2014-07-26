namespace Simon.Infrastructure
{
    /// <summary>
    /// Represents each item in the global settings of the Simon application.
    /// </summary>
    public sealed class GlobalSettingsItem
    {
        /// <summary>
        /// Initializes the instance of <see cref="GlobalSettingsItem"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public GlobalSettingsItem(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; private set; }
    }
}
