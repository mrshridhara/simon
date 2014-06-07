using System;
using System.Collections;
using System.Linq;

namespace Simon.Aspects
{
    /// <summary>
    /// Indicates that the arguments of a method should not be empty.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ArgumentsNotEmptyAttribute : ArgumentsVerificationAttributeBase
    {
        /// <summary>
        /// Initializes an instance of <see cref="ArgumentsNotEmptyAttribute"/> class.
        /// </summary>
        /// <param name="argumentNames">The argument names.</param>
        public ArgumentsNotEmptyAttribute(params string[] argumentNames)
            : base(argumentNames) { }

        /// <summary>
        /// Verifies the specified <paramref name="argumentValue"/> for validity.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argumentValue">The argument value.</param>
        /// <returns>Any applicable exception.</returns>
        protected override Exception VerifyArgument(string argumentName, object argumentValue)
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