using System.Web.Http;
using Owin;
using Simon.Infrastructure.Middlewares;

namespace Simon.Api.Web
{
    /// <summary>
    /// Extensions for <see cref="IAppBuilder"/> class.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Configures the Simon Web API in OWIN.
        /// </summary>
        /// <param name="appBuilder">The app builder instance.</param>
        public static void UseSimonWebApi(this IAppBuilder appBuilder)
        {
            appBuilder.UseSimonWebApi(new HttpConfiguration());
        }

        /// <summary>
        /// Configures the Simon Web API in OWIN using specified <paramref name="config"/>.
        /// </summary>
        /// <param name="appBuilder">The app builder instance.</param>
        /// <param name="config">The HTTP configuration.</param>
        public static void UseSimonWebApi(this IAppBuilder appBuilder, HttpConfiguration config)
        {
            appBuilder.Use<AuthenticationMiddleware>();
            appBuilder.Use<CachingMiddleware>();

            var dependencyResolver = IocConfig.RegisterDependencies(appBuilder, config);
            config.DependencyResolver = dependencyResolver;

            RouteConfig.Register(appBuilder, config);
        }
    }
}