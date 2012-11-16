using System.Web;
using System.Web.Optimization;

namespace IssueTracker
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/assets/app_css").Include(
                "~/assets/css/bootstrap.css",
                "~/assets/css/app.css"
               ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            bundles.Add(new ScriptBundle("~/assets/app_js").Include(
                        "~/assets/js/modernizr-*",
                        "~/assets/js/jquery-{version}.js",
                "~/assets/js/jquery.unobtrusive*",
                "~/assets/js/jquery.validate*",
                "~/assets/js/jquery.validate*",
                "~/assets/js/underscore.js",
                "~/assets/js/backbone.js",
                "~/assets/js/bootstrap.js",
                "~/assets/js/backbone-articulation.js"
                        ));

            BundleTable.EnableOptimizations = true;
        }
    }
}