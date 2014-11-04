using System.Collections.Generic;
using Simon.Infrastructure;

namespace Simon.Processes.FileSystem
{
    /// <summary>
    /// Represents the result of getting installed plugins.
    /// </summary>
    public sealed class GetInstalledPluginsResult
    {
        /// <summary>
        /// Gets or sets installed plugins.
        /// </summary>
        public IEnumerable<PluginMetadata> InstalledPlugins { get; set; }
    }
}