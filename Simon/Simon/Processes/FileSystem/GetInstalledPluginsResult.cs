using Simon.Infrastructure;
using System.Collections.Generic;

namespace Simon.Processes.FileSystem
{
    /// <summary>
    /// Represents the result of getting installed plug-ins.
    /// </summary>
    public sealed class GetInstalledPluginsResult
    {
        /// <summary>
        /// Gets or sets installed plug-ins.
        /// </summary>
        public IEnumerable<PluginMetadata> InstalledPlugins { get; set; }
    }
}