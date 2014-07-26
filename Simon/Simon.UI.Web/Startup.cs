using Microsoft.Owin;
using Owin;
using Simon.Api.Web;
using Simon.UI.Web.Areas.HelpPage;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(Simon.UI.Web.Startup))]
namespace Simon.UI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            AreaRegistration.RegisterAllAreas();
            HelpPageConfig.Register(config);

            appBuilder.ConfigureSimonApi(config);
        }
    }
}