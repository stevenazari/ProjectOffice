using System.Web;
using System.Web.Optimization;

namespace ProjectOffice
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //First the site core JS / CSS to avoid redundant calls.
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                //                "~/Scripts/jquery-{version}.js",
                "~/Scripts/components/jQuery/jquery-2.1.4.js",
                "~/scripts/components/jQuery/magnificPopup/jquery.magnific-popup.js",
                "~/scripts/components/jQuery/easing/jquery.easing.1.3.js",
                "~/scripts/components/jQuery/collapse/jquery.collapse.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/components/jQuery/validate/jquery.validate*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/scripts/components/vendor/bootstrap.js",
                "~/Scripts/components/respond.js",
                "~/Scripts/components/vendor/validator.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapTables").Include(
                "~/scripts/components/bootstrapTables/bootstrap-table.min.js",
                "~/scripts/components/bootstrapTables/bootstrap-table.en-US.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/scripts/components/owl.carousel.min.js",
                "~/css/components/slick/slick.js",
                "~/css/components/slick/slick.min.js",
                "~/scripts/components/bootsnav.js",
                "~/scripts/components/plugins.js",
                "~/scripts/main.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/components/vendor/modernizr-2.8.3-respond-1.4.2.min.js"
            ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/css/components/bootstrap/bootstrap.css",
                "~/css/components/bootstrap/bootstrap.min.css",
                "~/css/components/bootstrap/bootstrap-theme.min.css",
                "~/css/site.css",
                "~/css/components/slick/slick.css",
                "~/css/components/slick/slick-theme.css",
                "~/css/components/animate.css",
                "~/css/components/iconfont.css",
                "~/css/components/font-awesome.min.css",
                "~/css/components/magnific-popup.css",
                "~/css/components/bootsnav.css",
                //Theme Responsive css
                "~/css/components/responsive.css",

                "~/css/style.css",

                //Custom CSS
                "~/css/table-styles.css"
            ));

            bundles.Add(new StyleBundle("~/Content/formCSS").Include(
                "~/css/components/bootstrap/bootstrapValidator.min.css",
                "~/css/formCSS/style.css"
            ));







            //Form bundles JS
            bundles.Add(new ScriptBundle("~/bundles/formJS").Include(
                "~/Scripts/formJS/formJS.js"
            ));

            //Application List bundles JS
            bundles.Add(new ScriptBundle("~/bundles/applicationList").Include(
                "~/Scripts/formJS/ApplicationList/ApplicationList.js"
            ));

            //Support Company bundles JS
            bundles.Add(new ScriptBundle("~/bundles/addSupportCompany").Include(
                "~/Scripts/formJS/ApplicationList/Add_Support_Company_Validation.js"
            ));

            //Application bundles JS
            bundles.Add(new ScriptBundle("~/bundles/addApplication").Include(
                "~/Scripts/formJS/ApplicationList/Add_Application_Validation.js"
            ));

            //Server bundles JS
            bundles.Add(new ScriptBundle("~/bundles/addServer").Include(
                "~/Scripts/formJS/ApplicationList/Add_Server_Validation.js"
            ));

            //Environment bundles JS
            bundles.Add(new ScriptBundle("~/bundles/addEnvironment").Include(
                "~/Scripts/formJS/ApplicationList/Add_Environment_Validation.js"
            ));
        }
    }
}