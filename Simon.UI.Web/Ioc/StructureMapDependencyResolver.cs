using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi = System.Web.Http.Controllers;
using Mvc = System.Web.Mvc;

namespace Simon.UI.Web.Ioc
{
	/// <summary>
	/// Defines the dependency resolver using structure map.
	/// </summary>
	public class StructureMapDependencyResolver : Mvc.IDependencyResolver
	{
		/// <summary>
		/// Initializes an instance of <see cref="StructureMapDependencyResolver"/> class.
		/// </summary>
		public StructureMapDependencyResolver()
		{
			ObjectFactory.Initialize(config =>
			{
				config.Scan(scanner =>
				{
					scanner.TheCallingAssembly();
					scanner.AddAllTypesOf<Mvc.IController>();
					scanner.AddAllTypesOf<WebApi.IHttpController>();
				});
			});
		}

		/// <summary>
		/// Resolves singly registered services that support arbitrary object creation.
		/// </summary>
		/// <param name="serviceType">The type of the requested service or object.</param>
		/// <returns>
		/// The requested service or object.
		/// </returns>
		public object GetService(Type serviceType)
		{
			return ObjectFactory.TryGetInstance(serviceType);
		}

		/// <summary>
		/// Resolves multiply registered services.
		/// </summary>
		/// <param name="serviceType">The type of the requested services.</param>
		/// <returns>
		/// The requested services.
		/// </returns>
		public IEnumerable<object> GetServices(Type serviceType)
		{
			return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
		}
	}
}