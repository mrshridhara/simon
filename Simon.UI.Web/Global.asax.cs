using Simon.UI.Web.Ioc;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Simon.UI.Web
{
	/// <summary>
	/// The application defenition class.
	/// </summary>
	public class WebApiApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// Called when the application starts the web host.
		/// </summary>
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			DependencyResolver.SetResolver(new StructureMapDependencyResolver());
		}
	}
}