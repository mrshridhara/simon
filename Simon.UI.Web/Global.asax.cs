using Simon.Api.Web;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;

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
            IDependencyResolver resolver = IocConfig.RegisterDependencies();
            GlobalConfiguration.Configure(config => WebApiConfig.Register(config, resolver));
        }
    }
}