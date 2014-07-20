using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Owin;
using Simon.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Simon.Api.Web
{
    /// <summary>
    /// Represents the configuraion for the IoC.
    /// </summary>
    public class IocConfig
    {
        /// <summary>
        /// Registers the dependencies to the IoC container.
        /// </summary>
        /// <param name="appBuilder">The app builder.</param>
        public static IContainer RegisterDependencies(IAppBuilder appBuilder)
        {
            var builder = new ContainerBuilder();

            var currentAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(currentAssembly);

            var allRequiredAssemblies
                = GetAllReferencedAssemblies(currentAssembly)
                    .Union(GetAllPluginAssemblies())
                    .ToList();

            allRequiredAssemblies.Add(currentAssembly);

            builder
                .RegisterAssemblyTypes(allRequiredAssemblies.ToArray())
                .AsImplementedInterfaces();

            var container = builder.Build();

            var globalSettings = GetCurrentGlobalSettings(container);
            var updatedGlobalSettings = InitializePlugins(appBuilder, container, globalSettings);

            FinalizeGlobalSettings(container, updatedGlobalSettings);

            return container;
        }

        private static GlobalSettings GetCurrentGlobalSettings(IContainer container)
        {
            var getGlobalPersistence
                = container.Resolve<IAsyncPersistence<GlobalSettings>>();

            var result = getGlobalPersistence.ReadAll().Result;
            return result.First();
        }

        private static void FinalizeGlobalSettings(IContainer container, GlobalSettings globalSettings)
        {
            var getGlobalPersistence
                = container.Resolve<IAsyncPersistence<GlobalSettings>>();

            getGlobalPersistence.Update(globalSettings).Wait();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(globalSettings);
            builder.Update(container);
        }

        private static GlobalSettings InitializePlugins(IAppBuilder appBuilder, IContainer container, GlobalSettings globalSettings)
        {
            var plugins = container.Resolve<IEnumerable<IPlugin>>();
            foreach (var eachPlugin in plugins)
            {
                globalSettings = eachPlugin.Init(appBuilder, container, globalSettings);
            }

            return globalSettings;
        }

        private static IEnumerable<Assembly> GetAllReferencedAssemblies(Assembly currentAssembly)
        {
            return
                currentAssembly
                    .GetReferencedAssemblies()
                    .Where(eachAssemblyName => eachAssemblyName.Name.Contains("Simon"))
                    .Select(eachAssemblyName => Assembly.Load(eachAssemblyName));
        }

        private static IEnumerable<Assembly> GetAllPluginAssemblies()
        {
            var pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Plugins");

            return
                Directory.GetFiles(pluginsPath, "*.dll", SearchOption.AllDirectories)
                    .Select(eachAssemblyName => TryLoadAssembly(eachAssemblyName))
                    .Where(loadedAssembly => loadedAssembly != null);
        }

        private static Assembly TryLoadAssembly(string eachAssemblyName)
        {
            if (IsAssemblyLoaded(eachAssemblyName) == false)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(eachAssemblyName);
                    AppDomain.CurrentDomain.Load(assembly.GetName());

                    return assembly;
                }
                catch (BadImageFormatException)
                {
                    return null;
                }
            }

            return null;
        }

        private static bool IsAssemblyLoaded(string assemblyPath)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var fileName = Path.GetFileNameWithoutExtension(assemblyPath);
            return loadedAssemblies.Any(eachLoadedAssembly => eachLoadedAssembly.GetName().Name == fileName);
        }
    }
}