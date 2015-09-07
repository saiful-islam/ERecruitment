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
using Newtonsoft.Json.Linq;

namespace ERecruitment.API.Controllers
{
    public class ExamController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Skill
        public dynamic Get()
        {
            var jobs = (from j in Db.JobDetails
                        where !(from e in Db.ExamInfo.Where(e => e.IsExamCompleted)
                                select e.JobID)
                                .Contains(j.JobID)
                        select new
                        {
                            j.JobID,
                            j.JobName
                        }).Distinct();
            return jobs.ToList();
        }

        // GET api/Skill/5
        public dynamic Get(JObject jasonData)
        {
            int examId = Convert.ToInt32(jasonData["examId"].ToString());
            int jobId = Convert.ToInt32(jasonData["jobId"].ToString());
            var applicantInfoes = from a in Db.ApplicantInfo
                                  join e in Db.ExamInfo.Where(e=> e.ExamTypeID == examId && e.JobID==jobId)
                                  on a.ApplicantID equals e.ApplicantID
                                  select new
                                  {
                                      a.ApplicantID,
                                      a.FirstName,
                                      a.LastName,
                                      a.MobileNo,
                                      a.Email,
                                      e.Marks,
                                      e.IsRejected,
                                      e.IsPassed
                                  };
            return applicantInfoes;
        }

        // POST api/Skill
        public dynamic Post(JObject jasonData)
        {
            int examId = Convert.ToInt32(jasonData["examId"].ToString());
            int jobId = Convert.ToInt32(jasonData["jobId"].ToString());
            var applicantInfoes = from a in Db.ApplicantInfo
                join e in Db.ExamInfo.Where(e => e.ExamTypeID == examId && e.JobID == jobId)
                    on a.ApplicantID equals e.ApplicantID
                select new
                {
                    a.ApplicantID,
                    a.FirstName,
                    a.LastName,
                    a.MobileNo,
                    a.Email,
                    e.Marks,
                    e.IsRejected,
                    e.IsPassed
                };
            return applicantInfoes;
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
