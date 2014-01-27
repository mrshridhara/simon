using System;

namespace Simon.UI.Web.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Represents a model description.
    /// </summary>
    public abstract class ModelDescription
    {
		/// <summary>
		/// Gets or sets the documentation.
		/// </summary>
        public string Documentation { get; set; }

		/// <summary>
		/// Gets or sets the model type.
		/// </summary>
        public Type ModelType { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
        public string Name { get; set; }
    }
}