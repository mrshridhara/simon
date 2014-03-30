using System.Web.Mvc;
using System.Web.Routing;

namespace Simon.UI.Web
{
    /// <summary>
    /// Represents the configuraion for the routes.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes to the specified <paramref name="routes"/> instance.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}