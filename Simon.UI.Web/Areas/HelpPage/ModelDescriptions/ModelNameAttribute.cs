using System;

namespace Simon.UI.Web.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Use this attribute to change the name of the <see cref="ModelDescription"/> generated for a type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public sealed class ModelNameAttribute : Attribute
    {
		/// <summary>
		/// Initializes an instance of <see cref="ModelNameAttribute"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
        public ModelNameAttribute(string name)
        {
            Name = name;
        }

		/// <summary>
		/// Gets the name.
		/// </summary>
        public string Name { get; private set; }
    }
}