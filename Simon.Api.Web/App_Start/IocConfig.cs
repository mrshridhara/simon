using Simon.Api.Web.Ioc;
using StructureMap;
using Mvc = System.Web.Mvc;
using WebApi = System.Web.Http.Controllers;

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
        public static void RegisterDependencies()
        {
            ObjectFactory.Initialize(config =>
            {
                config.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf<Mvc.IController>();
                    scanner.AddAllTypesOf<WebApi.IHttpController>();
                });
            });

            Mvc.DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}