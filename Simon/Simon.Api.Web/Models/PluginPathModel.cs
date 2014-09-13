namespace Simon.Api.Web.Models
{
    /// <summary>
    /// Represents a navigation path of a plug-in.
    /// </summary>
    public sealed class PluginPathModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }
    }
}