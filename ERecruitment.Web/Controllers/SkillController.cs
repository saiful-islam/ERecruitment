using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERecruitment.Web.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int SkillID, string SkillName)
        {
            ViewBag.SkillID = SkillID;
            ViewBag.SkillName = SkillName;
            return View();
        }

        public ActionResult Delete(int SkillID, string SkillName)
        {
            ViewBag.SkillID = SkillID;
            ViewBag.SkillName = SkillName;
            return View();
        }
    }
}