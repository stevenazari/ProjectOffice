﻿using System.Web;
using System.Web.Optimization;

namespace ProjectOffice
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/scripts/vendor/jquery-1.11.2.min.js",
                "~/scripts/formJS/jquery-2.1.3.js",
                "~/scripts/jquery.magnific-popup.js",
                "~/scripts/jquery.easing.1.3.js",
                "~/scripts/jquery.collapse.js"
            ));

            //Form bundles
            bundles.Add(new ScriptBundle("~/bundles/formJS").Include(
               "~/Scripts/formJS/bootstrapValidator.min.js",
               "~/Scripts/formJS/index.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/formCSS").Include(
                "~/css/formCSS/bootstrapValidator.css",
                "~/css/formCSS/style.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/scripts/owl.carousel.min.js",
                "~/css/slick/slick.js",
                "~/css/slick/slick.min.js",
                "~/scripts/bootsnav.js",
                "~/scripts/plugins.js",
                "~/scripts/main.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/vendor/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/scripts/vendor/bootstrap.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/css/bootstrap.css",
                "~/css/site.css",
                "~/css/slick/slick.css",
                "~/css/slick/slick-theme.css",
                "~/css/animate.css",
                "~/css/iconfont.css",
                "~/css/font-awesome.min.css",
                "~/css/bootstrap.css",
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
        }
    }
}