using Owin;

namespace Simon.Api.Web
{
    /// <summary>
    /// Represents the OWIN start up class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the specified <paramref name="appBuilder"/>.
        /// </summary>
        /// <param name="appBuilder">The app builder.</param>
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseSimonWebApi();
        }
    }
}