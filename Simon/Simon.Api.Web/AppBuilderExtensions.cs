using Owin;
using System.Web.Http;

namespace Simon.Api.Web
{
    /// <summary>
    /// Extensions for <see cref="IAppBuilder"/> class.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Configures the Simon API in Owin.
        /// </summary>
        /// <param name="appBuilder">The app builder instance.</param>
        public static void ConfigureSimonApi(this IAppBuilder appBuilder)
        {
            ConfigureSimonApi(appBuilder, new HttpConfiguration());
        }

        /// <summary>
        /// Configures the Simon API in Owin using specified <paramref name="config"/>.
        /// </summary>
        /// <param name="appBuilder">The app builder instance.</param>
        /// <param name="config">The HTTP configuration.</param>
        public static void ConfigureSimonApi(this IAppBuilder appBuilder, HttpConfiguration config)
        {
            var dependencyResolver = IocConfig.RegisterDependencies(appBuilder, config);
            config.DependencyResolver = dependencyResolver;

            RouteConfig.Register(appBuilder, config);
        }
    }
}