using System.Web;
using System.Web.Optimization;

namespace ERecruitment.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/angular.min.js",
                     "~/Scripts/Angular/AG/ag-grid.js",
                     "~/Scripts/site.js",
                     "~/Scripts/Angular/app.js",
                     "~/Scripts/Angular/Controllers/HomeController.js",
                     "~/Scripts/Angular/Controllers/ExpertiseController.js",
                     "~/Scripts/Angular/Controllers/StatusController.js",
                     "~/Scripts/Angular/Controllers/SkillController.js",
                     "~/Scripts/Angular/Controllers/ApplicantController.js",
                     "~/Scripts/Angular/Controllers/JobController.js",
                     "~/Scripts/Angular/Controllers/ExamController.js",
                     "~/Scripts/Angular/Controllers/SelectApplicantController.js",
                     "~/Scripts/Angular/Controllers/FinalSelectionController.js",
                     "~/Scripts/Angular/Models/ExpertiseModel.js",
                     "~/Scripts/Angular/Models/StatusModel.js",
                     "~/Scripts/Angular/Models/ApplicantModel.js",
                     "~/Scripts/Angular/Models/CareerModel.js",
                     "~/Scripts/Angular/Models/EducationModel.js",
                     "~/Scripts/Angular/Models/InstituteModel.js",
                     "~/Scripts/Angular/Models/JobModel.js",
                     "~/Scripts/Angular/Models/ProjectThesisModel.js",
                     "~/Scripts/Angular/Models/SkillModel.js",
                     "~/Scripts/Angular/Models/SkillHistoryModel.js",
                     "~/Scripts/Angular/Models/RequiredJobEducationModel.js",
                     "~/Scripts/Angular/Models/RequiredJobSkillModel.js",
                     "~/Scripts/Angular/Models/ExamModel.js",
                     "~/Scripts/aftersite.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/dataTables.bootstrap.min.css",
                       "~/Content/jquery.datetimepicker.css",
                       "~/Content/ag-grid.css",
                       "~/Content/theme-blue.css"));
        }
    }
}
