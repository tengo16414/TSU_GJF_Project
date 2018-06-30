using System.Web;
using System.Web.Optimization;

namespace GJF
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        /*"~/Scripts/jquery-{version}.js"*/
                        "~/Scripts/kendo/2017.3.913/jquery.min.js"
                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Kendo/css")
                .Include("~/Content/kendo/2017.3.913/kendo.common.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/kendo/2017.3.913/kendo.material.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/kendo/2017.3.913/kendo.mobile.common.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/kendo/2017.3.913/kendo.material.mobile.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Metronic/css")
                .Include("~/Content/Metronic/assets/global/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/plugins/simple-line-icons/simple-line-icons.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/plugins/morris/morris.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/plugins/fullcalendar/fullcalendar.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/plugins/jqvmap/jqvmap/jqvmap.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/css/components.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/global/css/plugins.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/layouts/layout3/css/layout.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/layouts/layout3/css/themes/default.css", new CssRewriteUrlTransform())
                .Include("~/Content/Metronic/assets/layouts/layout3/css/custom.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Kendo/scrypts").Include(
                  // "~/Scripts/kendo/2017.3.913/jquery.min.js",
                  "~/Scripts/kendo/2017.3.913/kendo.all.min.js",
                  "~/Scripts/kendo/2017.3.913/jszip.min.js",
                  "~/Scripts/kendo/2017.3.913/kendo.aspnetmvc.min.js",
                  "~/Scripts/kendo.modernizr.custom.js",
                  "~/Scripts/kendo/2017.3.913/cultures/kendo.culture.ka-GE.js",
                  "~/Scripts/kendo/2017.3.913/messages/kendo.messages.ka-GE.js",
                  "~/Scripts/kendo/2017.3.913/cultures/SetKendoCulture.js"
          ));


            bundles.Add(new ScriptBundle("~/Kendo/scrypts").Include(
                      "~/Scripts/Custom/Kendo/cultures/kendo.culture.ka-GE.js",
                      "~/Scripts/Custom/Kendo/messages/kendo.messages.ka-GE.js",
                      "~/Scripts/Custom/Kendo/cultures/SetKendoCulture.js"
                      ));

            bundles.Add(new ScriptBundle("~/Metronic/scrypts")
              .Include("~/Content/Metronic/assets/global/scripts/app.js", new CssRewriteUrlTransform())
              .Include("~/Content/Metronic/assets/layouts/layout3/scripts/layout.min.js", new CssRewriteUrlTransform())
              .Include("~/Content/Metronic/assets/layouts/layout3/scripts/demo.min.js", new CssRewriteUrlTransform())
              .Include("~/Content/Metronic/assets/layouts/global/scripts/quick-sidebar.min.js", new CssRewriteUrlTransform())
              .Include("~/Content/Metronic/assets/layouts/global/scripts/quick-nav.min.js", new CssRewriteUrlTransform()));
        }
    }
}
