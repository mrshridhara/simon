using Simon.Api.Web.Ioc;
using Simon.Domain.Process;
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
                    scanner.Assembly(Assembly.GetExecutingAssembly());

                    foreach (var assembly in GetAllReferencedAssemblies())
                    {
                        scanner.Assembly(assembly);
                    }

                    scanner.WithDefaultConventions();

                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncProcess<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncProcess<>));

                    scanner.AddAllTypesOf<IAsyncProcessFactory>();
                    scanner.AddAllTypesOf<IHttpController>();
                });
            });

            return new StructureMapDependencyResolver(ObjectFactory.Container);
        }

        private static IEnumerable<Assembly> GetAllReferencedAssemblies()
        {
            return
                Assembly
                    .GetExecutingAssembly()
                    .GetReferencedAssemblies()
                    .Where(eachAssemblyName => eachAssemblyName.Name.Contains("Simon"))
                    .Select(eachAssemblyName => Assembly.Load(eachAssemblyName));
        }
    }
}