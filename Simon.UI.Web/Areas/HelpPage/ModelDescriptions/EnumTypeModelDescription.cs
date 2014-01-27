using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Simon.UI.Web.Areas.HelpPage.ModelDescriptions
{
	/// <summary>
	/// Represents the enum type model description.
	/// </summary>
    public class EnumTypeModelDescription : ModelDescription
    {
		/// <summary>
		/// Initializes an instance of <see cref="EnumTypeModelDescription"/> class.
		/// </summary>
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

		/// <summary>
		/// Gets the values.
		/// </summary>
        public Collection<EnumValueDescription> Values { get; private set; }
    }
}