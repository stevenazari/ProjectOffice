using System.Web;
using System.Web.Optimization;

namespace ProjectOffice
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                //                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-3.2.1.js",
                "~/scripts/jquery.magnific-popup.js",
                "~/scripts/jquery.easing.1.3.js",
                "~/scripts/jquery.collapse.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/validator.js"
            ));

            //Form bundles JS
            bundles.Add(new ScriptBundle("~/bundles/formJS").Include(
                //Form Validation
                "~/Scripts/formJS/Validation/sharedJS.js",
//                "~/Scripts/formJS/Validation/Add_Application_Validation.js",
//                "~/Scripts/formJS/Validation/Add_Server_Validation.js",
                "~/Scripts/formJS/Validation/Add_Support_Company_Validation.js"
            ));
            //End of form bundle JS

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/scripts/owl.carousel.min.js",
                "~/css/slick/slick.js",
                "~/css/slick/slick.min.js",
                "~/scripts/bootsnav.js",
                "~/scripts/plugins.js",
                "~/scripts/jquery.waypoints.js",
                "~/scripts/owl.carousel.js",
                "~/scripts/jquery.localScroll.js",
                "~/scripts/jquery.counterup.js",
                "~/scripts/wow.js",
                "~/scripts/main.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/vendor/modernizr-2.8.3-respond-1.4.2.min.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/css/bootstrap.css",
                "~/css/site.css",
                "~/css/slick/slick.css",
                "~/css/slick/slick-theme.css",
                "~/css/animate.css",
                "~/css/iconfont.css",
                "~/css/font-awesome.min.css",
                "~/css/magnific-popup.css",
                "~/css/bootsnav.css",
                //Theme Responsive css
                "~/css/responsive.css",

                //--xsslider slider css--
                    //"~/css/xsslider.css"
                //--For Plugins external css--
                    //"~/css/plugins.css"
                //--Theme custom css--
                    "~/css/style.css"
                    //"~/css/colors/maron.css"
            ));

            bundles.Add(new StyleBundle("~/Content/formCSS").Include(
                "~/css/formCSS/bootstrap.min.css",
                "~/css/formCSS/bootstrap-theme.min.css",
                "~/css/formCSS/bootstrapValidator.min.css",
                "~/css/formCSS/style.css"
            ));
        }
    }
}