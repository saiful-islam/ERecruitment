using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERecruitment.Model.Models;
using ERecruitment.Model.Context;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ERecruitment.API.Controllers
{
    public class RunningExamTypesController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/RequiredJobExamTypes
        public dynamic Get()
        {
            var RequiredJobExamTypeses = Db.RequiredJobExamTypes.ToList();
            return RequiredJobExamTypeses;
        }

        // GET api/RequiredJobExamTypes/5
        public dynamic Get(int id)
        {
            var examTypeInfoes = from rjt in Db.RequiredJobExamTypes.Where(r => r.JobID == id && r.IsRunning)
                join ext in Db.ExamTypeInfo on rjt.ExamTypeID equals ext.ExamTypeID
                select new
                {
                    ext.ExamTypeID,
                    ext.ExamType
                };
            return examTypeInfoes;
        }

        // POST api/RequiredJobExamTypes
        public string Post(List<RequiredJobExamTypes> objRequiredJobExamTypes)
        {

            return "Saved";

        }
        public string Put(List<RequiredJobExamTypes> objRequiredJobExamTypes)
        {
            return "Saved";
        }
        // DELETE api/RequiredJobExamTypes/5
        public string Delete(int id)
        {
            return "Saved";
        }
    }
}
