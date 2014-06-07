using Simon.Api.Web.Ioc;
using Simon.Processes;
using Simon.Repositories;
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
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncPersistence<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncPersistence<>));

                    scanner.AddAllTypesOf<IAsyncProcessFactory>();
                    scanner.AddAllTypesOf<IHttpController>();
                });

                config.RegisterInterceptor(new StructureMapTypeInterceptor());
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