using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using Simon.Processes;
using StructureMap;

namespace Simon.Api.Web.Ioc
{
    /// <summary>
    /// Represents the implementaion of <see cref="IAsyncProcessFactory"/>
    /// using StructureMap IoC container.
    /// </summary>
    public sealed class StructureMapAsyncProcessFactory : IAsyncProcessFactory
    {
        private readonly IContainer container;

        /// <summary>
        /// Initializes an instance of <see cref="StructureMapAsyncProcessFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public StructureMapAsyncProcessFactory(IContainer container)
        {
            Guard.NotNullArgument("container", container);

            this.container = container;
        }

        /// <summary>
        /// Creates an async process which takes a context of type <typeparamref name="TContext"/>
        /// and returns the result of type <typeparamref name="TResult"/>.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <typeparam name="TContext">The type of context.</typeparam>
        /// <typeparam name="TResult">The type of result.</typeparam>
        /// <returns>An instacnce of <see cref="IAsyncProcess&lt;TContext, TResult&gt;"/>.</returns>
        public IAsyncProcess<TContext, TResult> CreateAsyncProcess<TContext, TResult>(GlobalSettings globalSettings)
        {
            ResetGlobalSettings(this, globalSettings);
            return container.GetInstance<IAsyncProcess<TContext, TResult>>();
        }

        /// <summary>
        /// Creates an async process which takes  a context of type <typeparamref name="TContext"/>
        /// and does not return any value.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <typeparam name="TContext">The type of context.</typeparam>
        /// <returns>An instacnce of <see cref="IAsyncProcess&lt;TContext&gt;"/>.</returns>
        public IAsyncProcess<TContext> CreateAsyncProcess<TContext>(GlobalSettings globalSettings)
        {
            ResetGlobalSettings(this, globalSettings);
            return container.GetInstance<IAsyncProcess<TContext>>();
        }

        private static void ResetGlobalSettings(StructureMapAsyncProcessFactory asyncProcessFactory, GlobalSettings globalSettings)
        {
            asyncProcessFactory.container.EjectAllInstancesOf<GlobalSettings>();
            asyncProcessFactory.container.Inject<GlobalSettings>(globalSettings);
        }
    }
}