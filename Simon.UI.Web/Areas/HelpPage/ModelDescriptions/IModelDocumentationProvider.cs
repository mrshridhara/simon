using System;
using System.Reflection;

namespace Simon.UI.Web.Areas.HelpPage.ModelDescriptions
{
	/// <summary>
	/// Defines a model documentation provider.
	/// </summary>
    public interface IModelDocumentationProvider
    {
		/// <summary>
		/// Gets the documentatation of the specified <paramref name="member"/>.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <returns>
		/// Documentation for the specified <paramref name="member"/>.
		/// </returns>
        string GetDocumentation(MemberInfo member);

		/// <summary>
		/// Gets the documentatation of the specified <paramref name="type"/>.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>
		/// Documentation for the specified <paramref name="type"/>.
		/// </returns>
        string GetDocumentation(Type type);
    }
}