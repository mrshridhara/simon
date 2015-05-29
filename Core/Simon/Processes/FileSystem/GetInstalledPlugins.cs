using Simon.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Simon.Processes.FileSystem
{
    /// <summary>
    /// Gets the installed plug-ins.
    /// </summary>
    public sealed class GetInstalledPlugins
        : IProcess<EmptyContext, GetInstalledPluginsResult>
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
                var name = new DirectoryInfo(pluginFolder).Name;

                yield return new PluginMetadata
                {
                    Name = name,
                    FullPath = pluginFolder,
                    ShortName = name.Replace(" ", "-").ToLower()
                };
            }
        }
    }
}