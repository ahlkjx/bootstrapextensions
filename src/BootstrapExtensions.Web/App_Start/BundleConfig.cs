using System.Web.Optimization;

namespace BootstrapExtensions.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include("~/Scripts/jquery-{version}.js", "~/Scripts/bootstrap.js", "~/Scripts/app.js"));
            bundles.Add(new StyleBundle("~/bundle/css").Include("~/Content/css/bootstrap.css", "~/Content/css/styles.css", "~/Content/css/bootstrap-responsive.css"));
        }
    }
}