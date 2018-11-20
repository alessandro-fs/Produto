using System.Web;
using System.Web.Optimization;

namespace Produto.ECM
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/mainJS")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.validate*")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/respond.js")
                .Include("~/Scripts/modernizr-*")
                .Include("~/Scripts/site.js")
                );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/PagedList.css",
                      "~/Content/Site.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));
        }
    }
}
