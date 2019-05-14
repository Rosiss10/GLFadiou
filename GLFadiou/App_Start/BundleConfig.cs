using System.Web;
using System.Web.Optimization;

namespace GLFadiou
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                      "~/Asset/bower_components/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Asset/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Asset/dist/js/adminlte.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Asset/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Asset/bower_components/font-awesome/css/font-awesome.css",
                      "~/Asset/bower_components/Ionicons/css/ionicons.css",
                      "~/Asset/dist/css/AdminLTE.css",
                      "~/Asset/dist/css/skins/skin-blue.css"));
        }
    }
}
