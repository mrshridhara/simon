using System.Web.Http;
using System.Web.Mvc;

namespace Simon.UI.Web.Areas.HelpPage
{
	/// <summary>
	/// Represents the registration of the help page area.
	/// </summary>
	public class HelpPageAreaRegistration : AreaRegistration
	{
		/// <summary>
		/// Gets the name of the area to register.
		/// </summary>
		public override string AreaName
		{
			get
			{
				return "HelpPage";
			}
		}

		/// <summary>
		/// Registers help page area using the specified <paramref name="context"/> instance.
		/// </summary>
		/// <param name="context">The area registration context.</param>
		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"HelpPage_Default",
				"Help/{action}/{apiId}",
				new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

			HelpPageConfig.Register(GlobalConfiguration.Configuration);
		}
	}
}