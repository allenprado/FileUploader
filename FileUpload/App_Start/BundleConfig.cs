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

            bundles.Add(new StyleBundle("~/Content/dataTables").Include(
                      "~/Content/datatables/dataTables.bootstrap4.min.css",
                      "~/Content/datatables/jquery.dataTables.min.css"));

            bundles.Add(new StyleBundle("~/Content/dataPicker").Include(
                      "~/Content/datapicker/datepicker3.css"));

            bundles.Add(new StyleBundle("~/Content/highcharts").Include(
                      "~/Content/highcharts/highcharts.css"));


            //==================== SCRIPTS =================================

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/scripts/toastr/toastr.js",
                        "~/scripts/toastr/toastrImp.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                       "~/scripts/datatables/dataTables.bootstrap4.js",
                       "~/scripts/datatables/jquery.dataTables.js",
                       "~/scripts/datatables/datatables-demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataPicker").Include(
                      "~/Scripts/datapicker/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
                      "~/Scripts/highcharts/highcharts.js",
                      "~/Scripts/highcharts/modules/exporting.js"));
        }
    }
}
