using System.Web.Http;
using System.Web.Http.Dependencies;
using Microsoft.Owin.Extensions;
using Owin;
using Simon.Api.Web.Middlewares;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;

namespace Simon.Api.Web
{
    /// <summary>
    /// Extensions for <see cref="IAppBuilder"/> class.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Configures the Simon Web API to use basic authentication.
        /// </summary>
        /// <param name="appBuilder">The app builder instance.</param>
        /// <param name="dependencyResolver">The dependency resolver.</param>
        public static void UseBasicAuthentication(this IAppBuilder appBuilder, IDependencyResolver dependencyResolver)
        {
            Guard.NotNullArgument("appBuilder", appBuilder);
            Guard.NotNullArgument("dependencyResolver", dependencyResolver);

            var authenticationProvider = dependencyResolver.GetService(typeof(IAsyncAuthenticationProvider));

            appBuilder.Use<AuthenticationMiddleware>(authenticationProvider);
            appBuilder.UseStageMarker(PipelineStage.Authenticate);
        }

        /// <summary>
        /// Configures the Simon Web API in OWIN.
        /// </summary>
        /// <param name="appBuilder">The app builder instance.</param>
        public static void UseSimonWebApi(this IAppBuilder appBuilder)
        {
            Guard.NotNullArgument("appBuilder", appBuilder);

            appBuilder.UseSimonWebApi(new HttpConfiguration());
        }

        /// <summary>
        /// Configures the Simon Web API in OWIN using specified <paramref name="config"/>.
        /// </summary>
        /// <param name="appBuilder">The app builder instance.</param>
        /// <param name="config">The HTTP configuration.</param>
        public static void UseSimonWebApi(this IAppBuilder appBuilder, HttpConfiguration config)
        {
            Guard.NotNullArgument("appBuilder", appBuilder);
            Guard.NotNullArgument("config", config);

            var dependencyResolver = IocConfig.RegisterDependencies(appBuilder, config);
            config.DependencyResolver = dependencyResolver;

            appBuilder.UseBasicAuthentication(dependencyResolver);
            appBuilder.Use<CachingMiddleware>();

            RouteConfig.Register(appBuilder, config);
            FilterConfig.Register(config);
        }
    }
}