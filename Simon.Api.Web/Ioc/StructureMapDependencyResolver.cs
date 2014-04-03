using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using Mvc = System.Web.Mvc;

namespace Simon.Api.Web.Ioc
{
    /// <summary>
    /// Defines the dependency resolver using structure map.
    /// </summary>
    public class StructureMapDependencyResolver : Mvc.IDependencyResolver
    {
        private IContainer container;

        /// <summary>
        /// Initializes an instance of <see cref="StructureMapDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
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
            if (serviceType.IsAbstract == false && serviceType.IsInterface == false)
            {
                return container.GetInstance(serviceType);
            }

            return container.TryGetInstance(serviceType);
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
            return container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}