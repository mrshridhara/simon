using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Simon.Api.Web
{
    /// <summary>
    /// Represents the configuraion for the Web API.
    /// </summary>
    public class WebApiConfig
    {
        /// <summary>
        /// Registers the HTTP route to the specified <paramref name="config"/> instance.
        /// </summary>
        /// <param name="config">The HTTP configuration.</param>
        /// <param name="dependencyResolver">The dependency resolver.</param>
        public static void Register(HttpConfiguration config, IDependencyResolver dependencyResolver)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = dependencyResolver;
        }
    }
}