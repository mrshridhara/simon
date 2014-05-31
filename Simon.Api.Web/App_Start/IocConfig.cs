using Simon.Api.Web.Ioc;
using Simon.Domain;
using Simon.Domain.Process;
using Simon.Domain.Process.Contexts;
using Simon.Domain.Process.Results;
using StructureMap;
using System.Collections.Generic;
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

                    foreach (var assembly in GetAllReferencedAssemblies(currentAssembly))
                    {
                        scanner.Assembly(assembly);
                    }

                    scanner.LookForRegistries();
                    scanner.WithDefaultConventions();

                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncProcess<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncProcess<>));

                    scanner.AddAllTypesOf<IAsyncProcessFactory>();
                    scanner.AddAllTypesOf<IHttpController>();
                });

                config.RegisterInterceptor(new StructureMapTypeInterceptor());

                config
                    .For<GlobalSettings>()
                    .Singleton()
                    .OnCreationForAll((context, globalSettings) =>
                    {
                        var getGlobalSettings
                            = context.GetInstance<IAsyncProcess<EmptyContext, GetGlobalSettingsResult>>();

                        var getGlobalSettingsResult
                            = getGlobalSettings
                                .ExecuteAsync(EmptyContext.Instance)
                                .Result;

                        globalSettings.RepoPath
                            = getGlobalSettingsResult.GlobalSettings.RepoPath;

                        globalSettings.DatabaseConnectionString
                            = getGlobalSettingsResult.GlobalSettings.DatabaseConnectionString;
                    });
            });

            return new StructureMapDependencyResolver(ObjectFactory.Container);
        }

        private static IEnumerable<Assembly> GetAllReferencedAssemblies(Assembly currentAssembly)
        {
            return
                currentAssembly
                    .GetReferencedAssemblies()
                    .Where(eachAssemblyName => eachAssemblyName.Name.Contains("Simon"))
                    .Select(eachAssemblyName => Assembly.Load(eachAssemblyName));
        }
    }
}