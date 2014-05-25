using System;
using System.Linq;

namespace Simon.Aspects
{
    /// <summary>
    /// Defines a base class for all argument verification attributes.
    /// </summary>
    public abstract class ArgumentsVerificationAttributeBase : Attribute
    {
        private readonly string[] argumentNames;

        /// <summary>
        /// Initializes an instance of <see cref="ArgumentsVerificationAttributeBase"/> class.
        /// </summary>
        /// <param name="argumentNames">The argument names.</param>
        protected ArgumentsVerificationAttributeBase(params string[] argumentNames)
        {
            this.argumentNames = argumentNames;
        }

        /// <summary>
        /// Verifies the specified <paramref name="argumentValue"/> for validity.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argumentValue">The argument value.</param>
        public void Verify(string argumentName, object argumentValue)
        {
            if (IsApplicable(argumentNames, argumentName))
            {
                var exception = this.VerifyArgument(argumentName, argumentValue);
                if (exception != null)
                {
                    throw exception;
                }
            }
        }

        /// <summary>
        /// Verifies the specified <paramref name="argumentValue"/> for validity.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argumentValue">The argument value.</param>
        /// <returns>Any applicable exception.</returns>
        protected abstract Exception VerifyArgument(string argumentName, object argumentValue);

        private static bool IsApplicable(string[] argumentNames, string argumentName)
        {
            if (argumentNames == null || argumentNames.Length == 0)
            {
                return true;
            }

            return argumentNames.Contains(argumentName);
        }
    }
}