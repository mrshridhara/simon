using Simon.UI.Web.Areas.HelpPage.Models;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace Simon.UI.Web.Areas.HelpPage.Controllers
{
	/// <summary>
	/// The controller that will handle requests for the help page.
	/// </summary>
	public class HelpController : Controller
	{
		/// <summary>
		/// Initializes an instance of <see cref="HelpController"/>.
		/// </summary>
		public HelpController()
			: this(GlobalConfiguration.Configuration)
		{
		}

		/// <summary>
		/// Initializes an instance of <see cref="HelpController"/> with the specified <paramref name="config"/>.
		/// </summary>
		/// <param name="config">The HTTP configuration.</param>
		public HelpController(HttpConfiguration config)
		{
			Configuration = config;
		}

		/// <summary>
		/// Get the HTTP configuration.
		/// </summary>
		public HttpConfiguration Configuration { get; private set; }

		/// <summary>
		/// GET /Help
		/// </summary>
		/// <returns>
		/// View for index page.
		/// </returns>
		public ActionResult Index()
		{
			ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
			return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
		}

		/// <summary>
		/// GET /Help/Api/{apiId}
		/// </summary>
		/// <param name="apiId">The API Id.</param>
		/// <returns>
		/// View for the specified API.
		/// </returns>
		public ActionResult Api(string apiId)
		{
			if (!String.IsNullOrEmpty(apiId))
			{
				HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
				if (apiModel != null)
				{
					return View(apiModel);
				}
			}

			return View("Error");
		}

		/// <summary>
		/// GET /Help/About
		/// </summary>
		/// <returns>
		/// View for about page.
		/// </returns>
		public ActionResult About()
		{
			return View();
		}
	}
}