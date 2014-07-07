namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines the methods required to initialize a plugin.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Initializes the plugin and updates the specified <paramref name="globalSettings"/>
        /// if required.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns>
        /// The updated instnce of <see cref="GlobalSettings"/> class.
        /// </returns>
        GlobalSettings Init(GlobalSettings globalSettings);
    }
}