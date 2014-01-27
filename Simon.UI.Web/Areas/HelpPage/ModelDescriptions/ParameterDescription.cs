using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Simon.UI.Web.Areas.HelpPage.ModelDescriptions
{
	/// <summary>
	/// Represents the parameter description.
	/// </summary>
    public class ParameterDescription
    {
		/// <summary>
		/// Initializes an instance of <see cref="ParameterDescription"/> class.
		/// </summary>
        public ParameterDescription()
        {
            Annotations = new Collection<ParameterAnnotation>();
        }

		/// <summary>
		/// Gets the annotations.
		/// </summary>
        public Collection<ParameterAnnotation> Annotations { get; private set; }

		/// <summary>
		/// Gets or sets the documentation.
		/// </summary>
        public string Documentation { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the type description.
		/// </summary>
        public ModelDescription TypeDescription { get; set; }
    }
}