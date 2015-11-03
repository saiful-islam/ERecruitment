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
using Microsoft.Ajax.Utilities;

namespace ERecruitment.API.Controllers
{
    public class ExamTypeController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Skill
        public ICollection<ExamTypeInfo> Get()
        {
            var examTypes = Db.ExamTypeInfo.Where(e=>e.ExamTypeID != 4).ToList();
            return examTypes;
        }

        // GET api/ExamType/5
        public dynamic Get(int id)
        {
            var examTypes = (from et in Db.ExamTypeInfo
                join ret in Db.RequiredJobExamTypes.Where(r=>r.JobID==id) on et.ExamTypeID equals ret.ExamTypeID
                select new
                {
                    et.ExamTypeID,
                    et.ExamType
                }).ToList();
            return examTypes;
        }
        /*public dynamic Get(int id)
        {
            if (id == 1)
            {
                var jobs =(from j in Db.JobDetails
                            where !(from e in Db.ExamInfo
                                    select e.JobID)
                                    .Contains(j.JobID)
                            select new
                           {
                                j.JobID,
                                j.JobName
                            }).Distinct();
                return jobs;
            }
            else
            {
                var jobs = (from j in Db.JobDetails
                            join e in Db.ExamInfo.Where(e => e.ExamTypeID == (id-1) && e.IsExamCompleted) on j.JobID equals e.JobID
                            select new
                            {
                                j.JobID,
                                j.JobName
                            }).Distinct();

                return jobs;
            }
            
        }*/

        // POST api/Skill
        public dynamic Post()
        {
            return "";
        }
        public string Put(SkillInfo objSkill)
        {
            try
            {
                
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/Skill/5
        public string Delete(int id)
        {
            try
            {
                
                return "Deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
