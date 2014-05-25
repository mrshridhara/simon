using System;
using System.Linq;

namespace Simon.Aspects
{
    public abstract class ArgumentsVarificationAttributeBase : Attribute
    {
        private readonly string[] argumentNames;

        protected ArgumentsVarificationAttributeBase(params string[] argumentNames)
        {
            this.argumentNames = argumentNames;
        }

        public bool IsApplicable(string argumentName)
        {
            if (this.argumentNames == null || this.argumentNames.Length == 0)
            {
                return true;
            }

            return this.argumentNames.Contains(argumentName);
        }

        public void Varify(string argumentName, object argumentValue)
        {
            if (this.IsApplicable(argumentName))
            {
                var exception = this.VarifyArgument(argumentName, argumentValue);
                if (exception != null)
                {
                    throw exception;
                }
            }
        }

        protected abstract Exception VarifyArgument(string argumentName, object argumentValue);
    }
}