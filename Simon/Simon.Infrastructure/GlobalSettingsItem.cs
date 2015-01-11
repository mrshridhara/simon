using Simon.Infrastructure.Utilities;

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
        /// <param name="isNavigationPath">The is navigation path.</param>
        public GlobalSettingsItem(string name, string value, bool isNavigationPath = false)
        {
            Guard.NotNullArgument("name", name);
            Guard.NotNullArgument("value", value);

            this.Name = name;
            this.Value = value;
            this.IsNavigationPath = isNavigationPath;
        }

        /// <summary>
        /// Gets the is navigation path.
        /// </summary>
        public bool IsNavigationPath { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// <c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var otherItem = obj as GlobalSettingsItem;
            if (otherItem == null)
            {
                return false;
            }

            return
                this.Name.Equals(otherItem.Name)
                && this.Value.Equals(otherItem.Value);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return
                this.Name.GetHashCode()
                ^ this.Value.GetHashCode();
        }
    }
}