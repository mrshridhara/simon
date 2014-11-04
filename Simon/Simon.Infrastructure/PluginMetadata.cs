namespace Simon.Infrastructure
{
    /// <summary>
    /// Represents the meta-data of a plug-in.
    /// </summary>
    public sealed class PluginMetadata
    {
        public string FullPath { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}