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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ERecruitment.API.Controllers
{
    public class JobController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/expertise
        public dynamic Get()
        {
            var jobs = from exam in (
                from j in Db.JobDetails
                join e in Db.ExamInfo on j.JobID equals e.JobID into je
                from e in je.DefaultIfEmpty()
                join et in Db.ExamTypeInfo on e.ExamTypeID equals et.ExamTypeID into jet
                from et in jet.DefaultIfEmpty()
                join s in Db.SectionInfo on j.SectionId equals s.SectionId

                select new
                {
                    j.JobID,
                    j.JobName,
                    j.MinimumExperiance,
                    j.MaximumExperiance,
                    j.SubmissionDeadline,
                    ExamTypeID = et == null ? 0 : et.ExamTypeID,
                    ExamType = et == null ? "Initial" : et.ExamType,
                    s.SectionId,
                    s.SectionName
                }
                )
                group exam by exam.JobID
                into g
                orderby g.Key
                select g.OrderByDescending(z => z.ExamTypeID)
                    .FirstOrDefault();
            return jobs;
        }

        // GET api/expertise/5
        public ICollection<JobDetails> Get(int id)
        {
            var jobs = Db.JobDetails.Where(j => j.JobID == id).ToList();
            return jobs;
        }

        // POST api/expertise
        public string Post(JObject jasonData)
        {
             try
            {
                JobDetails objJob = JsonConvert.DeserializeObject<JobDetails>(jasonData["objJob"].ToString());
                List<RequiredJobSkills> objSkillHistories = JsonConvert.DeserializeObject<List<RequiredJobSkills>>(jasonData["objSkill"].ToString());

                int jobId =0;
                if (Db.JobDetails.Any())
                {
                    jobId = Db.JobDetails.Max(j => j.JobID);
                }
                var objJobDetails = new JobDetails
                {
                    JobID = jobId+1,
                    JobName = objJob.JobName,
                    UserID = objJob.UserID,
                    MinimumExperiance = objJob.MinimumExperiance,
                    MaximumExperiance = objJob.MaximumExperiance,
                    SubmissionDeadline = objJob.SubmissionDeadline,
                    SectionId = objJob.SectionId
                    
                };
                Db.JobDetails.Add(objJobDetails);
                Db.SaveChanges();

                foreach (var objS in objSkillHistories)
                {
                    var objSkillHistory = new RequiredJobSkills
                    {
                        JobID = objJobDetails.JobID,
                        SkillID = objS.SkillID
                    };
                    Db.RequiredJobSkills.Add(objSkillHistory);
                    Db.SaveChanges();
                }

                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(JObject jasonData)
        {
            try
            {

                JobDetails objJob = JsonConvert.DeserializeObject<JobDetails>(jasonData["objJob"].ToString());
                List<RequiredJobSkills> objSkillHistories = JsonConvert.DeserializeObject<List<RequiredJobSkills>>(jasonData["objSkill"].ToString());

                JobDetails objJobDetails = Db.JobDetails.Single(j => j.JobID == objJob.JobID);

                objJobDetails.JobName = objJob.JobName;
                objJobDetails.UserID = objJob.UserID;
                objJobDetails.MinimumExperiance = objJob.MinimumExperiance;
                objJobDetails.MaximumExperiance = objJob.MaximumExperiance;
                objJobDetails.SubmissionDeadline = objJob.SubmissionDeadline;
                objJobDetails.SectionId = objJob.SectionId;

                Db.SaveChanges();

                List<RequiredJobSkills> objOldSkillHistories = Db.RequiredJobSkills.Where(j => j.JobID == objJob.JobID).ToList();
                foreach (var objS in objOldSkillHistories)
                {
                    Db.Entry(objS).State = EntityState.Deleted;
                    Db.SaveChanges();
                }


                foreach (var objS in objSkillHistories)
                {
                    var objSkillHistory = new RequiredJobSkills
                    {
                        JobID = objJobDetails.JobID,
                        SkillID = objS.SkillID
                    };
                    Db.RequiredJobSkills.Add(objSkillHistory);
                    Db.SaveChanges();
                }

                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/expertise/5
        public string Delete(int applicantId)
        {
            try
            {
                var obj = Db.ApplicantInfo.Find(applicantId);
                obj.StatusCode = 1;
                
                Db.SaveChanges();
                return "Joined";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
