using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Simon.Infrastructure;

namespace Simon.Processes.FileSystem
{
    /// <summary>
    /// Gets the installed plugins.
    /// </summary>
    public sealed class GetInstalledPlugins
        : IAsyncProcess<EmptyContext, GetInstalledPluginsResult>
    {
        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;GetInstalledPluginsResult&gt;"/></returns>
        public async Task<GetInstalledPluginsResult> ExecuteAsync(EmptyContext context)
        {
            return await Task.Run(() => Execute());
        }

        private static GetInstalledPluginsResult Execute()
        {
            var getInstalledPluginsResult = new GetInstalledPluginsResult();

            var pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Plugins");
            if (Directory.Exists(pluginsPath))
            {
                getInstalledPluginsResult.InstalledPlugins = GetPluginMetadata(pluginsPath);
            }

            return getInstalledPluginsResult;
        }

        private static IEnumerable<PluginMetadata> GetPluginMetadata(string pluginsPath)
        {
            foreach (var pluginFolder in Directory.EnumerateDirectories(pluginsPath))
            {
                yield return new PluginMetadata
                {
                    Name = new DirectoryInfo(pluginFolder).Name,
                    FullPath = pluginFolder
                };
            }
        }
    }
}