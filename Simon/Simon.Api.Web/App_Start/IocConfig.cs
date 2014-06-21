using Simon.Actions;
using Simon.Api.Web.Ioc;
using Simon.Aspects.StructureMap;
using Simon.BackgroundTasks;
using Simon.Observers;
using Simon.Processes;
using Simon.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;
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
        public static IDependencyResolver RegisterDependencies()
        {
            ObjectFactory.Initialize(config =>
            {
                config.Scan(scanner =>
                {
                    var currentAssembly = Assembly.GetExecutingAssembly();
                    scanner.Assembly(currentAssembly);

                    var allRequiredAssemblies =
                         GetAllReferencedAssemblies(currentAssembly)
                         .Union(GetAllPluginAssemblies());

                    foreach (var assembly in allRequiredAssemblies)
                    {
                        scanner.Assembly(assembly);
                    }

                    scanner.LookForRegistries();

                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncObserver<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncProcess<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncProcess<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncPersistence<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncPersistence<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncStateAction<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IBackgroundTask<>));

                    scanner.AddAllTypesOf<IAsyncProcessFactory>();
                    scanner.AddAllTypesOf<IPlugin>();
                    scanner.AddAllTypesOf<IHttpController>();
                });

                config.RegisterInterceptor(new AspectRegistrationInterceptor());
            });

            InitializeGlobalSettings(ObjectFactory.Container);
            var globalSettings = InitializePlugins(ObjectFactory.Container);
            FinalizeGlobalSettings(ObjectFactory.Container, globalSettings);

            return new StructureMapDependencyResolver(ObjectFactory.Container);
        }

        private static void InitializeGlobalSettings(IContainer container)
        {
            var getGlobalPersistence
                = container.GetInstance<IAsyncPersistence<GlobalSettings>>();

            var result = getGlobalPersistence.ReadAll().Result;

            container.EjectAllInstancesOf<GlobalSettings>();
            container.Inject<GlobalSettings>(result.First());
        }

        private static void FinalizeGlobalSettings(IContainer container, GlobalSettings globalSettings)
        {
            var getGlobalPersistence
                = container.GetInstance<IAsyncPersistence<GlobalSettings>>();

            getGlobalPersistence.Update(globalSettings).Wait();

            container.EjectAllInstancesOf<GlobalSettings>();
            container.Inject<GlobalSettings>(globalSettings);
        }

        private static GlobalSettings InitializePlugins(IContainer container)
        {
            var plugins = container.GetAllInstances<IPlugin>();
            var globalSettings = container.GetInstance<GlobalSettings>();
            foreach (var eachPlugin in plugins)
            {
                globalSettings = eachPlugin.Init(globalSettings);
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