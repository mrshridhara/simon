using Simon.Infrastructure.Utilities;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace Simon.Api.Web.Ioc
{
    /// <summary>
    /// Defines the dependency resolver using structure map.
    /// </summary>
    public sealed class StructureMapDependencyResolver : Disposable, IDependencyResolver
    {
        private readonly IContainer container;

        /// <summary>
        /// Initializes an instance of <see cref="StructureMapDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>The dependency scope.</returns>
        public IDependencyScope BeginScope()
        {
            var nestedContainer = container.GetNestedContainer();
            return new StructureMapDependencyResolver(nestedContainer);
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

        /// <summary>
        /// Disposes the managed resources used in this class.
        /// </summary>
        protected override void DisposeManaged()
        {
            container.Dispose();
        }

        /// <summary>
        /// Disposes the unmanaged resources used in this class.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            // No unmanaged resources are used in this class.
        }
    }
}