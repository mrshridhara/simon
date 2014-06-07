using System;
using System.Diagnostics;

namespace Simon.Utilities
{
    /// <summary>
    /// Defines methods to guard other methods from invalid parameters.
    /// This is a static class.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws an exception of type <see cref="ArgumentNullException"/>
        /// with parameter name as the specified <paramref name="argumentName"/>
        /// if the specified <paramref name="argumentValue"/> is null.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argumentValue">The argument value.</param>
        /// <typeparam name="TArgument">Type of the argument.</typeparam>
        [DebuggerStepThrough]
        public static void NotNullArgument<TArgument>(string argumentName, TArgument argumentValue)
            where TArgument : class
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws an exception of type <see cref="ArgumentNullException"/>
        /// with parameter name as the specified <paramref name="argumentName"/>
        /// if the specified <paramref name="argumentValue"/> is null
        /// and, an exception of type <see cref="ArgumentException"/>
        /// with parameter name as the specified <paramref name="argumentName"/>
        /// if the specified <paramref name="argumentValue"/> is empty.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argumentValue">The argument value.</param>
        [DebuggerStepThrough]
        public static void NotNullOrEmptyStringArgument(string argumentName, string argumentValue)
        {
            Guard.NotNullArgument(argumentName, argumentValue);

            if (argumentValue.Trim().Length == 0)
            {
                throw new ArgumentException("The value cannot be empty.", argumentName);
            }
        }

        /// <summary>
        /// Throws an exception of type <see cref="ArgumentException"/>
        /// with parameter name as the specified <paramref name="argumentName"/>
        /// if the specified <paramref name="argumentValue"/> is empty.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argumentValue">The argument value.</param>
        /// <typeparam name="TArgument">Type of argument.</typeparam>
        [DebuggerStepThrough]
        public static void NotDefaultValueArgument<TArgument>(string argumentName, TArgument argumentValue)
            where TArgument : struct
        {
            if (argumentValue.Equals(default(TArgument)))
            {
                throw new ArgumentException("The value cannot be default.", argumentName);
            }
        }
    }
}