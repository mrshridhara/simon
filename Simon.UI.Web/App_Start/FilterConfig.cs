using System.Web.Mvc;

namespace Simon.UI.Web
{
	/// <summary>
	/// Represents the configuraion for the global action filters.
	/// </summary>
	public class FilterConfig
	{
		/// <summary>
		/// Registers the global action filters to the specified <paramref name="filters"/> instance.
		/// </summary>
		/// <param name="filters">The global filter collection.</param>
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
