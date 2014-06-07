using Castle.DynamicProxy;
using Elmah;
using System;
using System.Diagnostics;

namespace Simon.Aspects.CastleCore
{
    /// <summary>
    /// Represents the aspect to log errors in ELMAH.
    /// </summary>
    public sealed class ElmahErrorLoggingAspect : IInterceptor
    {
        /// <summary>
        /// Intercepts the call to the proxied instance.
        /// </summary>
        /// <param name="invocation">The invocation details.</param>
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                ErrorLog
                    .GetDefault(null)
                    .Log(new Error(exception));
                throw;
            }
        }
    }
}