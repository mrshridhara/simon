using Castle.DynamicProxy;
using Elmah;
using System;
using System.Diagnostics;

namespace Simon.Aspects.CastleCore
{
    public sealed class ElmahErrorLoggingAspect : IInterceptor
    {
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