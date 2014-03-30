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
            bundles.Add(new ScriptBundle("~/bundles/body-scripts").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/head-scripts").Include(
                        "~/Scripts/modernizr-{version}.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/body-scripts/app").Include(
                      "~/Scripts/app/ui.js",
                      "~/Scripts/app/ui.projects.js",
                      "~/Scripts/app/listAll.js",
                      "~/Scripts/app/listAll.projects.js",
                      "~/Scripts/app/open.js",
                      "~/Scripts/app/eventAttachments.js",
                      "~/Scripts/app/documentReady.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme",
                      "~/Content/bootstrap-tweaks.css",
                      "~/Content/item-specific.css"));
        }
    }
}