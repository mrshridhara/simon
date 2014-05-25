using Castle.DynamicProxy;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Simon.Aspects.CastleCore
{
    public sealed class MethodArgumentVarificationAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Arguments == null)
            {
                invocation.Proceed();
            }

            var attributeList = new List<ArgumentsVarificationAttributeBase>();
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
                    attribute.Varify(argumentName, argumentValue);
                }
            }

            invocation.Proceed();
        }

        private static void Add<TAttribute>(MethodInfo method, ref List<ArgumentsVarificationAttributeBase> attributeList)
            where TAttribute : ArgumentsVarificationAttributeBase
        {
            var attributes
                = method
                    .GetCustomAttributes(false)
                    .OfType<TAttribute>();

            attributeList.AddRange(attributes);
        }
    }
}