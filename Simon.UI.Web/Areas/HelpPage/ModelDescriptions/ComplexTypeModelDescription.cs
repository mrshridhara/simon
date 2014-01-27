using System.Collections.ObjectModel;

namespace Simon.UI.Web.Areas.HelpPage.ModelDescriptions
{
	/// <summary>
	/// Represents the complex type model description.
	/// </summary>
    public class ComplexTypeModelDescription : ModelDescription
    {
		/// <summary>
		/// Initializes an instance of <see cref="ComplexTypeModelDescription"/> class.
		/// </summary>
        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

		/// <summary>
		/// Gets the properties.
		/// </summary>
        public Collection<ParameterDescription> Properties { get; private set; }
    }
}