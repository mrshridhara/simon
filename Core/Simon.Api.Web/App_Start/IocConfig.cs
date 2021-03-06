﻿using Autofac;
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
    /// Represents the configuration for the IoC registrations.
    /// </summary>
    public class IocConfig
    {
        static IocConfig()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

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

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var requiredAssemblyName = new AssemblyName(args.Name);
            return GetLoadedAssembly(requiredAssemblyName.Name);
        }

        private static void FinalizeGlobalSettings(IContainer container, GlobalSettings globalSettings)
        {
            var getGlobalPersistence
                = container.Resolve<IPersistence<GlobalSettings>>();

            getGlobalPersistence.UpdateAsync(globalSettings).Wait();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(globalSettings);
            builder.Update(container);
        }

        private static IEnumerable<Assembly> GetAllPluginAssemblies()
        {
            var pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Plugins");

            return
                Directory.GetFiles(pluginsPath, "*.dll", SearchOption.AllDirectories)
                    .Select(eachAssemblyName => TryLoadAssembly(eachAssemblyName))
                    .Where(loadedAssembly => loadedAssembly != null);
        }

        private static IEnumerable<Assembly> GetAllReferencedAssemblies(Assembly currentAssembly)
        {
            return
                currentAssembly
                    .GetReferencedAssemblies()
                    .Where(eachAssemblyName => eachAssemblyName.Name.Contains("Simon"))
                    .Select(eachAssemblyName => Assembly.Load(eachAssemblyName));
        }

        private static GlobalSettings GetCurrentGlobalSettings(IContainer container)
        {
            var getGlobalPersistence
                = container.Resolve<IPersistence<GlobalSettings>>();

            var result = getGlobalPersistence.ReadAsync().Result;
            return result.First();
        }

        private static Assembly GetLoadedAssembly(string assemblyName, bool isAssemblyPath = false)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            if (isAssemblyPath)
            {
                assemblyName = Path.GetFileNameWithoutExtension(assemblyName);
            }

            return loadedAssemblies.FirstOrDefault(eachLoadedAssembly => eachLoadedAssembly.GetName().Name == assemblyName);
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

        private static bool IsAssemblyLoaded(string assemblyPath)
        {
            return GetLoadedAssembly(assemblyPath, true) != null;
        }

        private static Assembly TryLoadAssembly(string eachAssemblyName)
        {
            if (IsAssemblyLoaded(eachAssemblyName))
            {
                return null;
            }

            try
            {
                var assemblyName = AssemblyName.GetAssemblyName(eachAssemblyName);
                return AppDomain.CurrentDomain.Load(assemblyName);
            }
            catch (BadImageFormatException)
            {
                return null;
            }
        }
    }
}