using Autofac;
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
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var currentAssembly = Assembly.GetExecutingAssembly();

            var allRequiredAssemblies
                = GetAllReferencedAssemblies(currentAssembly)
                    .Union(GetAllPluginAssemblies())
                    .ToList();

            allRequiredAssemblies.Add(currentAssembly);

            builder
                .RegisterAssemblyTypes(allRequiredAssemblies.ToArray())
                .AsImplementedInterfaces();

            return builder.Build();
        }

        //private static void InitializeGlobalSettings(IContainer container)
        //{
        //    var getGlobalPersistence
        //        = container.Resolve<IAsyncPersistence<GlobalSettings>>();

        //    var result = getGlobalPersistence.ReadAll().Result;

        //    container.EjectAllInstancesOf<GlobalSettings>();
        //    container.Inject<GlobalSettings>(result.First());
        //}

        //private static void FinalizeGlobalSettings(IContainer container, GlobalSettings globalSettings)
        //{
        //    var getGlobalPersistence
        //        = container.GetInstance<IAsyncPersistence<GlobalSettings>>();

        //    getGlobalPersistence.Update(globalSettings).Wait();

        //    container.EjectAllInstancesOf<GlobalSettings>();
        //    container.Inject<GlobalSettings>(globalSettings);
        //}

        //private static GlobalSettings InitializePlugins(IContainer container)
        //{
        //    var plugins = container.GetAllInstances<IPlugin>();
        //    var globalSettings = container.GetInstance<GlobalSettings>();
        //    foreach (var eachPlugin in plugins)
        //    {
        //        globalSettings = eachPlugin.Init(globalSettings);
        //    }

        //    return globalSettings;
        //}

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