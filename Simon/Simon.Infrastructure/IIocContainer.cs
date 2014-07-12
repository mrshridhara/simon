using System;
using System.Collections.Generic;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines an IOC container.
    /// </summary>
    public interface IIocContainer : IDisposable
    {
        /// <summary>
        /// Creates or resolves all registered instances of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>A sequence of instances.</returns>
        IEnumerable<T> GetAllInstances<T>();

        /// <summary>
        /// Creates or finds the default instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>An instance.</returns>
        T GetInstance<T>();

        /// <summary>
        /// Creates or resolves all registered instances of type <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A sequence of instances.</returns>
        IEnumerable<object> GetAllInstances(Type type);

        /// <summary>
        /// Creates or finds the default instance of type <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>An instance.</returns>
        object GetInstance(Type type);

        /// <summary>
        /// Gets the child container with isolated access.
        /// </summary>
        /// <returns>An IOC container.</returns>
        IIocContainer GetChildContainer();
    }
}