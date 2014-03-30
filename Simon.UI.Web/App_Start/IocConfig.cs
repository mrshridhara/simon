using Simon.UI.Web.Ioc;
using StructureMap;
using Mvc = System.Web.Mvc;
using WebApi = System.Web.Http.Controllers;

namespace Simon.UI.Web
{
	public class IocConfig
	{
		public static void RegisterDependencies()
		{
			ObjectFactory.Initialize(config =>
			{
				config.Scan(scanner =>
				{
					scanner.TheCallingAssembly();
					scanner.WithDefaultConventions();
					scanner.AddAllTypesOf<Mvc.IController>();
					scanner.AddAllTypesOf<WebApi.IHttpController>();
				});
			});

			Mvc.DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
		}
	}
}