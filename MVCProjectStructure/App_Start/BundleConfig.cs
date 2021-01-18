using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCProjectStructure.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                       "~/Scripts/jquery-ui-{version}.js",
                       "~/Scripts/jquery-ui.unobtrusive-{version}.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                    "~/Scripts/jquery.unobtrusive-ajax.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      ));

            bundles.Add(new StyleBundle("~/SBAdmin/style").Include(
                "~/Content/bootstrap.css"
                ));
            bundles.Add(new StyleBundle("~/Content/ui").Include(
               ));

            // BundleTable.EnableOptimizations = true;
        }
    }
}