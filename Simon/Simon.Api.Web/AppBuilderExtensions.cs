﻿using Autofac.Integration.WebApi;
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
        /// <param name="config">The HTTP configuration.</param>
        public static void ConfigureSimonApi(this IAppBuilder appBuilder, HttpConfiguration config)
        {
            var container = IocConfig.RegisterDependencies();
            WebApiConfig.Register(config);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseWebApi(config);
        }
    }
}