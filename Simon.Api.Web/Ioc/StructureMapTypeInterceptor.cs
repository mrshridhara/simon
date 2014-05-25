using Castle.DynamicProxy;
using Simon.Aspects.CastleCore;
using StructureMap;
using StructureMap.Interceptors;
using System;
using System.Linq;

namespace Simon.Api.Web.Ioc
{
    /// <summary>
    /// Represents a type interceptor for structure map.
    /// </summary>
    public class StructureMapTypeInterceptor : TypeInterceptor
    {
        /// <summary>
        /// Does this TypeInterceptor apply to the given type?
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// <c>true</c> if specified <paramref name="type"/> matches; otherwise <c>false</c>.
        /// </returns>
        public bool MatchesType(Type type)
        {
            return true;
        }

        /// <summary>
        /// An InstanceInterceptor can be registered on a per-Instance basis to act on,
        /// or even replace, the object that is created before it is passed back to the
        /// caller. This is primarily a hook for runtime AOP scenarios.
        /// </summary>
        /// <param name="target">The target instance.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        /// The processed instance.
        /// </returns>
        public object Process(object target, IContext context)
        {
            if (target == null)
                return null;

            var interfaces = target.GetType().GetInterfaces();

            if (interfaces.Length == 0)
                return target;

            var proxyGenerator = new ProxyGenerator();
            proxyGenerator.CreateInterfaceProxyWithTarget(
                interfaces[0],
                interfaces.Skip(1).ToArray(),
                target,
                new ElmahErrorLoggingAspect(),
                new MethodArgumentVarificationAspect());

            return target;
        }
    }
}
