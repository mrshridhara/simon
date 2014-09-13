using Autofac;
using Owin;

namespace Simon.Infrastructure
{
    /// <summary>
    /// Defines the methods required to initialize a plug-in.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Initializes the plug-in and updates the specified <paramref name="globalSettings"/>
        /// if required.
        /// </summary>
        /// <param name="appBuilder">The app builder.</param>
        /// <param name="container">The IOC container.</param>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns>
        /// The updated instance of <see cref="GlobalSettings"/> class.
        /// </returns>
        GlobalSettings Init(IAppBuilder appBuilder, IContainer container, GlobalSettings globalSettings);
    }
}