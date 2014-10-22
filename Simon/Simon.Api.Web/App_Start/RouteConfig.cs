using System.Web.Http;
using Owin;

namespace Simon.Api.Web
{
    /// <summary>
    /// Represents the route configuration for the Web API.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// The default API route name.
        /// </summary>
        public const string DefaultRouteName = "DefaultApi";

        /// <summary>
        /// Registers the HTTP route to the specified <paramref name="config"/> instance.
        /// </summary>
        /// <param name="appBuilder">The app builder.</param>
        /// <param name="config">The HTTP configuration.</param>
        public static void Register(IAppBuilder appBuilder, HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: DefaultRouteName,
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            appBuilder.UseWebApi(config);
        }
    }
}