using Microsoft.Owin;
using Owin;
using Simon.Api.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(Simon.UI.Web.Startup))]
namespace Simon.UI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            appBuilder.ConfigureSimonApi(config);
        }
    }
}