using Castle.DynamicProxy;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Simon.Aspects.CastleCore
{
    /// <summary>
    /// Represents the aspect which verifies method arguments.
    /// </summary>
    public sealed class MethodArgumentVerificationAspect : IInterceptor
    {
        /// <summary>
        /// Intercepts the call to the proxied instance.
        /// </summary>
        /// <param name="invocation">The invocation details.</param>
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Arguments == null)
            {
                invocation.Proceed();
            }

            var attributeList = new List<ArgumentsVerificationAttributeBase>();
            Add<ArgumentsNotNullAttribute>(invocation.Method, ref attributeList);
            Add<ArgumentsNotEmptyAttribute>(invocation.Method, ref attributeList);
            Add<ArgumentsNotDefaultAttribute>(invocation.Method, ref attributeList);

            if (attributeList.Count == 0)
            {
                invocation.Proceed();
            }

            for (int argumentIndex = 0;
                argumentIndex < invocation.Arguments.Length;
                argumentIndex++)
            {
                var argumentName = invocation.Method.GetParameters()[argumentIndex].Name;
                var argumentValue = invocation.Arguments[argumentIndex];

                foreach (var attribute in attributeList)
                {
                    attribute.Verify(argumentName, argumentValue);
                }
            }

            invocation.Proceed();
        }

        private static void Add<TAttribute>(MethodInfo method, ref List<ArgumentsVerificationAttributeBase> attributeList)
            where TAttribute : ArgumentsVerificationAttributeBase
        {
            var attributes
                = method
                    .GetCustomAttributes(true)
                    .OfType<TAttribute>();

            attributeList.AddRange(attributes);
        }
    }
}