using System;

namespace Simon.Aspects
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ArgumentsNotNullAttribute : ArgumentsVarificationAttributeBase
    {
        public ArgumentsNotNullAttribute(params string[] argumentNames)
            : base(argumentNames) { }

        protected override Exception VarifyArgument(string argumentName, object argumentValue)
        {
            if (argumentValue == null)
            {
                return new ArgumentNullException(argumentName);
            }

            return null;
        }
    }
}