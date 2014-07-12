using System.Web.Http;

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
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}