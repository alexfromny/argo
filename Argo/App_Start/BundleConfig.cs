using System.Collections.Generic;
using System.Web.Optimization;

namespace Argo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr") { Orderer = new AsIsBundleOrderer() }
                .Include(
                    "~/Scripts/modernizr.js",
                    "~/Scripts/modernizr-extentions.js",
                    "~/Scripts/respond.min.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/Content/styles/style").Include(
                      "~/Content/css/style.css"));
        }
    }

    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
