using System.Web;
using System.Web.Http;

namespace Simon.UI.Web.Areas.HelpPage
{
	/// <summary>
	/// Use this class to customize the Help Page.
	/// For example you can set a custom <see cref="System.Web.Http.Description.IDocumentationProvider"/> to supply the documentation
	/// or you can provide the samples for the requests/responses.
	/// </summary>
	public static class HelpPageConfig
	{
		/// <summary>
		/// Registers the documentation provider to the sepecified <paramref name="config"/> instance.
		/// </summary>
		/// <param name="config">The HTTP configuration.</param>
		public static void Register(HttpConfiguration config)
		{
			config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/Simon.UI.Web.xml")));
		}
	}
}