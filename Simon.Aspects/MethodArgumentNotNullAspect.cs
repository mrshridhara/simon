using Castle.DynamicProxy;
using System;
using System.Diagnostics;

namespace Simon.Aspects
{
    [DebuggerStepThrough]
    public sealed class MethodArgumentNotNullAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Arguments != null)
            {
                for (int argumentIndex = 0;
                    argumentIndex < invocation.Arguments.Length;
                    argumentIndex++)
                {
                    if (invocation.Arguments[argumentIndex] == null)
                    {
                        throw new ArgumentNullException(invocation.Method.GetParameters()[argumentIndex].Name);
                    }
                }
            }

            invocation.Proceed();
        }
    }
}