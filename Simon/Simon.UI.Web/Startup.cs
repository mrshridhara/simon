using Microsoft.Owin;
using Owin;
using Simon.Api.Web;

[assembly: OwinStartup(typeof(Simon.UI.Web.Startup))]
namespace Simon.UI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.ConfigureSimonApi();
        }
    }
}