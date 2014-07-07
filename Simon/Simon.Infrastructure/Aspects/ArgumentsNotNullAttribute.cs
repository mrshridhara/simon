using System;

namespace Simon.Infrastructure.Aspects
{
    /// <summary>
    /// Indicates that the arguments of a method should not be null.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ArgumentsNotNullAttribute : ArgumentsVerificationAttributeBase
    {
        /// <summary>
        /// Initializes an instance of <see cref="ArgumentsNotNullAttribute"/> class.
        /// </summary>
        /// <param name="argumentNames">The argument names.</param>
        public ArgumentsNotNullAttribute(params string[] argumentNames)
            : base(argumentNames) { }

        /// <summary>
        /// Verifies the specified <paramref name="argumentValue"/> for validity.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argumentValue">The argument value.</param>
        /// <returns>Any applicable exception.</returns>
        protected override Exception VerifyArgument(string argumentName, object argumentValue)
        {
            if (argumentValue == null)
            {
                return new ArgumentNullException(argumentName);
            }

            return null;
        }
    }
}