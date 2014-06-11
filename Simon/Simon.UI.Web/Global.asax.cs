using Simon.Api.Web;
using Simon.UI.Web.Areas.HelpPage;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Simon.UI.Web
{
    /// <summary>
    /// The application defenition class.
    /// </summary>
    public class SimonWebApplication : HttpApplication
    {
        /// <summary>
        /// Called when the application starts the web host.
        /// </summary>
        protected void Application_Start()
        {
            var resolver = IocConfig.RegisterDependencies();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(config =>
            {
                WebApiConfig.Register(config, resolver);
                HelpPageConfig.Register(config);
            });
        }
    }
}