using System;
using System.Collections;
using System.Linq;

namespace Simon.Aspects
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ArgumentsNotEmptyAttribute : ArgumentsVarificationAttributeBase
    {
        public ArgumentsNotEmptyAttribute(params string[] argumentNames)
            : base(argumentNames) { }

        protected override Exception VarifyArgument(string argumentName, object argumentValue)
        {
            Exception castException;

            var value = TryCastAsEnumerable(argumentValue, out castException);
            if (castException != null)
            {
                return castException;
            }

            if (value.Cast<object>().Any() == false)
            {
                return new ArgumentException("Value cannot be empty.", argumentName);
            }

            return null;
        }

        private static IEnumerable TryCastAsEnumerable(object value, out Exception castException)
        {
            if (value is IEnumerable)
            {
                castException = null;
                return (IEnumerable)value;
            }

            castException = new InvalidOperationException("ArgumentsNotEmpty attrubute can only be applied for arguments of enumerable types like string, list etc.");
            return default(IEnumerable);
        }
    }
}