namespace Simon.Infrastructure
{
    /// <summary>
    /// Represents the meta-data of a plug-in.
    /// </summary>
    public sealed class PluginMetadata
    {
        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the string representation of this instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}