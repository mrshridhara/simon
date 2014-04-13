using Simon.Api.Web.Ioc;
using StructureMap;
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
                    scanner.AssemblyContainingType<WebApiConfig>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf<IHttpController>();
                });
            });

            return new StructureMapDependencyResolver(ObjectFactory.Container);
        }
    }
}