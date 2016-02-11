using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace CusCar
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Assets/plugins/jQuery/jQuery-2.1.4.min.js",
                "~/Assets/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/Assets/plugins/fastclick/fastclick.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/ajaxPrefilters.js",
                "~/Scripts/app/app.bindings.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/login.viewmodel.js",
                "~/Scripts/app/register.viewmodel.js",
                "~/Scripts/app/registerExternal.viewmodel.js",
                "~/Scripts/app/manage.viewmodel.js",
                "~/Scripts/app/userInfo.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Assets/css/AdminLTE.min.css",
                 "~/Assets/css/skins/_all-skins.min.css",
                 "~/Assets/plugins/iCheck/square/blue.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                 "~/Scripts/angular.js",
                 "~/Scripts/angular-route.js",
                 "~/AngularController/routeConfig.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                 "~/Assets/plugins/datatables/jquery.dataTables.min.js",
                 "~/Assets/plugins/datatables/dataTables.bootstrap.min.js",
                 "~/Assets/plugins/datatables/angular-datatables.min.js"));

             bundles.Add(new ScriptBundle("~/bundles/appjs").Include(
                  "~/Assets/js/app.min.js"));
           
        }
    }
}
