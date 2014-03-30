using System.Web.Optimization;

namespace Simon.UI.Web
{
	/// <summary>
	/// Represents the configuraion for the content bundles.
	/// </summary>
	public class BundleConfig
	{
		/// <summary>
		/// Registers the conten bundles to the specified <paramref name="bundles"/> instance.
		/// </summary>
		/// <param name="bundles">The bundle collection.</param>
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/appscripts").Include(
					  "~/Scripts/app/listAll.js",
					  "~/Scripts/app/open.js",
					  "~/Scripts/app/eventAttachments.js",
					  "~/Scripts/app/documentReady.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));
		}
	}
}