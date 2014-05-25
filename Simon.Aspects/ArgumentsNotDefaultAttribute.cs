using System;

namespace Simon.Aspects
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ArgumentsNotDefaultAttribute : ArgumentsVarificationAttributeBase
    {
        public ArgumentsNotDefaultAttribute(params string[] argumentNames)
            : base(argumentNames) { }

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