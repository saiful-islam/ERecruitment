using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecruitment.Web.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int statusCode, string status)
        {
            ViewBag.statusCode = statusCode;
            ViewBag.status = status;
            return View();
        }

        public ActionResult Delete(int statusCode, string status)
        {
            ViewBag.statusCode = statusCode;
            ViewBag.status = status;
            return View();
        }
    }
}