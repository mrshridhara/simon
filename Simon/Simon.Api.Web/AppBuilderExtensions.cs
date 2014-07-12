using Autofac.Integration.WebApi;
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
        /// <param name="app">The app builder instance.</param>
        /// <param name="config">The HTTP configuration.</param>
        public static void ConfigureSimonApi(this IAppBuilder app, HttpConfiguration config)
        {
            var container = IocConfig.RegisterDependencies();
            WebApiConfig.Register(config);

            // Create an assign a dependency resolver for Web API to use.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // This should be the first middleware added to the IAppBuilder.
            app.UseAutofacMiddleware(container);

            // Make sure the Autofac lifetime scope is passed to Web API.
            app.UseAutofacWebApi(config);
        }
    }
}