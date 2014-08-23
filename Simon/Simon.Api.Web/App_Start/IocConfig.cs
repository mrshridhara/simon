using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using Simon.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;

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
        /// <param name="config">The HTTP configuration.</param>
        /// <returns>A <see cref="IDependencyResolver"/> instance.</returns>
        public static IDependencyResolver RegisterDependencies(IAppBuilder appBuilder, HttpConfiguration config)
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

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);

            return new AutofacWebApiDependencyResolver(container);
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