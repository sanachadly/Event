using System.Web;
using System.Web.Optimization;

namespace EventClient
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            #region Template Design 

            bundles.Add(new ScriptBundle("~/template/js").Include(
                      "~/Content/plugins/jquery/jquery.js",
                      "~/Content/plugins/popper/popper.min.js",
                      "~/Content/plugins/bootstrap/js/bootstrap.min.js",
                      "~/Content/plugins/smoothscroll/SmoothScroll.min.js",
                      "~/Content/plugins/isotope/mixitup.min.js",
                      "~/Content/plugins/magnific-popup/jquery.magnific-popup.min.js",
                      "~/Content/plugins/slick/slick.min.js",
                      "~/Content/plugins/syotimer/jquery.syotimer.min.js",
                      "~/Content/plugins/google-map/gmap.js",
                      "~/Content/js/custom.js"
                      ));

            bundles.Add(new StyleBundle("~/template/css").Include(
                    "~/Content/plugins/bootstrap/css/bootstrap.min.css",
                    "~/Content/plugins/font-awsome/css/font-awesome.min.css",
                    "~/Content/plugins/magnific-popup/magnific-popup.css",
                    "~/Content/plugins/slick/slick.css",
                    "~/Content/plugins/slick/slick-theme.css",
                    "~/Content/css/style.css",
                    "~/Content/images/favicon.png"


                    ));







            #endregion
        }
    }
}
