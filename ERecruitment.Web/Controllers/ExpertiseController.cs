using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecruitment.Web.Controllers
{
    public class ExpertiseController : Controller
    {
        //
        // GET: /Expertise/
        public ActionResult Index()
        {
             return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int expertiseCode, string expertiseName)
        {
            ViewBag.expertiseCode = expertiseCode;
            ViewBag.expertiseName = expertiseName;
            return View();
        }

        public ActionResult Delete(int expertiseCode, string expertiseName)
        {
            ViewBag.expertiseCode = expertiseCode;
            ViewBag.expertiseName = expertiseName;
            return View();
        }
	}
}