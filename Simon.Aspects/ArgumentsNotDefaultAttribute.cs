using System;

namespace Simon.Aspects
{
    /// <summary>
    /// Indicates that the arguments of a method should not be default.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ArgumentsNotDefaultAttribute : ArgumentsVarificationAttributeBase
    {
        /// <summary>
        /// Initializes an instance of <see cref="ArgumentsNotDefaultAttribute"/> class.
        /// </summary>
        /// <param name="argumentNames">The argument names.</param>
        public ArgumentsNotDefaultAttribute(params string[] argumentNames)
            : base(argumentNames) { }

        /// <summary>
        /// Varifies the specified <paramref name="argumentValue"/> for validity.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argumentValue">The argument value.</param>
        /// <returns>Any applicable exception.</returns>
        protected override Exception VarifyArgument(string argumentName, object argumentValue)
        {
            Exception castException;

            var value = TryCastAsValueType(argumentValue, out castException);
            if (castException != null)
            {
                return castException;
            }

            if (value == GetDefaultValue(argumentValue.GetType()))
            {
                return new ArgumentException("Value cannot be default.", argumentName);
            }

            return null;
        }

        private static ValueType TryCastAsValueType(object value, out Exception castException)
        {
            if (value != null && value.GetType().IsValueType)
            {
                castException = null;
                return (ValueType)value;
            }

            castException = new InvalidOperationException("ArgumentsNotDefault attrubute can only be applied for arguments of value types like int, double etc.");
            return default(ValueType);
        }

        private static object GetDefaultValue(Type valueType)
        {
            return Activator.CreateInstance(valueType);
        }
    }
}