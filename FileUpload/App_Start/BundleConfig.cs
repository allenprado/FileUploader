using System.Web;
using System.Web.Optimization;

namespace FileUpload
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //==================== STYLES =================================

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/toastr").Include(
                      "~/Content/toastr/toastr.css"));

            bundles.Add(new StyleBundle("~/Content/dataPicker").Include(
                      "~/Content/datapicker/datepicker3.css"));

            bundles.Add(new StyleBundle("~/Content/highcharts").Include(
                      "~/Content/highcharts/highcharts.css"));


            //==================== SCRIPTS =================================

            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                        "~/Scripts/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/scripts/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/toastr").Include(
                        "~/scripts/toastr/toastr.js",
                        "~/scripts/toastr/toastrImp.js"));

            bundles.Add(new ScriptBundle("~/scripts/dataPicker").Include(
                      "~/Scripts/datapicker/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/scripts/highcharts").Include(
                      "~/Scripts/highcharts/highcharts.js",
                      "~/Scripts/highcharts/modules/exporting.js"));
        }
    }
}
