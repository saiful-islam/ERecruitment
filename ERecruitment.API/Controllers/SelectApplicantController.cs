using System;
using System.Collections.Generic;
using System.Globalization;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ERecruitment.API.Controllers
{
    public class SelectApplicantController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Skill
        public dynamic Get()
        {
            var applicantInfoes = from a in Db.ApplicantInfo.Include(a => a.ExpertiseInfo).Include(a => a.StatusInfo)
                                  join c in  (
                                                from c in Db.CareerInfo 
                                                 group c by new { c.ApplicantID } into g
                                                 select new
                                                 {
                                                     ApplicantID = g.Key.ApplicantID,
                                                     ExperianceDay =  g.Sum(x=>(x.LeaveDate-x.JoinDate).TotalDays)
                                                 }
                                                ) on a.ApplicantID equals c.ApplicantID
                                  where !(from e in Db.ExamInfo
                                          select e.ApplicantID)
                                    .Contains(c.ApplicantID)
                                  select new
                                  {
                                      a.ApplicantID,
                                      a.FirstName,
                                      a.LastName,
                                      a.MobileNo,
                                      a.Email,
                                      a.MailingAddress,
                                      a.StatusInfo.Status,
                                      a.ExpertiseInfo.ExpertiseName,
                                      Experiance=(c.ExperianceDay/365)
                                  };
            return applicantInfoes;
        }

        // GET api/Skill/5
        public string Get(JObject jasonData)
        {
            return "Nothing";
        }

        // POST api/Skill
        public string Post(JObject jasonData)
        {
            try
            {
                List<ApplicantInfo> objApplicants = JsonConvert.DeserializeObject<List<ApplicantInfo>>(jasonData["objApplicantInfo"].ToString());
                ExamInfo objExamInfo = JsonConvert.DeserializeObject<ExamInfo>(jasonData["objExamInfo"].ToString());

                List<RequiredJobExamTypes> objRequiredJobExamTypeses =
                    Db.RequiredJobExamTypes.Where(rj => rj.JobID == objExamInfo.JobID).ToList();

                foreach (RequiredJobExamTypes examTypes in objRequiredJobExamTypeses)
                {
                    if (examTypes.ExamTypeID == objExamInfo.ExamTypeID)
                    {
                        examTypes.IsRunning = true;
                    }
                    else
                    {
                        examTypes.IsRunning = false;
                    }
                    Db.Entry(examTypes).State = EntityState.Modified; 
                    Db.SaveChanges();
                }
                
                foreach (var applicant in objApplicants)
                {
                    var objExam = new ExamInfo
                    {
                        ApplicantID = applicant.ApplicantID,
                        JobID = objExamInfo.JobID,
                        ExamTypeID = objExamInfo.ExamTypeID,
                        ExamDate = objExamInfo.ExamDate
                    };
                    Db.ExamInfo.Add(objExam);
                    Db.SaveChanges();
                }

                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public dynamic Put(JObject jasonData)
        {
            int examTypeId = Convert.ToInt32(jasonData["examTypeId"].ToString());
            int jobId = Convert.ToInt32(jasonData["jobId"].ToString());

            int runExamType = Db.RequiredJobExamTypes.Where(e => e.JobID == jobId && e.IsRunning).Select(e => e.ExamTypeID).FirstOrDefault();
            var examInfoes = Db.ExamInfo.Where(e => e.JobID == jobId).ToList();
            if (examInfoes.Count <= 0)
            {
                var applicantInfoes =
                    from a in Db.ApplicantInfo.Include(a => a.ExpertiseInfo).Include(a => a.StatusInfo)
                    join c in
                        (
                            from c in Db.CareerInfo
                            group c by new { c.ApplicantID }
                                into g
                                select new
                                {
                                    g.Key.ApplicantID,
                                    ExperianceDay = g.Sum(x => DbFunctions.DiffDays(x.JoinDate, x.LeaveDate))
                                }
                            ) on a.ApplicantID equals c.ApplicantID
                    select new
                    {
                        a.ApplicantID,
                        a.FirstName,
                        a.LastName,
                        a.MobileNo,
                        a.Email,
                        a.MailingAddress,
                        a.StatusInfo.Status,
                        a.ExpertiseInfo.ExpertiseName,
                        Experiance = c.ExperianceDay,
                        IsSelected = false,
                        a.StatusCode,
                        a.ExpertiseCode
                    };
                return applicantInfoes;
            }
            else
            {
                var applicantInfoes =
                    from a in Db.ApplicantInfo.Include(a => a.ExpertiseInfo).Include(a => a.StatusInfo)
                    join c in
                        (
                            from c in Db.CareerInfo
                            group c by new { c.ApplicantID }
                                into g
                                select new
                                {
                                    g.Key.ApplicantID,
                                    ExperianceDay = g.Sum(x => DbFunctions.DiffDays(x.JoinDate, x.LeaveDate))
                                }
                            ) on a.ApplicantID equals c.ApplicantID
                    join e in Db.ExamInfo.Where(e => e.JobID == jobId
                                            && e.ExamTypeID == runExamType
                                            && e.IsPassed
                                            && e.IsExamCompleted
                                            && !e.IsRejected
                                            && examTypeId > runExamType
                                            ) on a.ApplicantID equals e.ApplicantID
                    select new
                    {
                        a.ApplicantID,
                        a.FirstName,
                        a.LastName,
                        a.MobileNo,
                        a.Email,
                        a.MailingAddress,
                        a.StatusInfo.Status,
                        a.ExpertiseInfo.ExpertiseName,
                        Experiance = c.ExperianceDay,
                        IsSelected = false,
                        a.StatusCode,
                        a.ExpertiseCode
                    };
                return applicantInfoes;
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
