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
    public class RequiredJobExamTypesController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/RequiredJobExamTypes
        public ICollection<RequiredJobExamTypes> Get()
        {
            var RequiredJobExamTypeses = Db.RequiredJobExamTypes.ToList();
            return RequiredJobExamTypeses;
        }

        // GET api/RequiredJobExamTypes/5
        public ICollection<RequiredJobExamTypes> Get(int id)
        {
            var RequiredJobExamTypeses = Db.RequiredJobExamTypes.Where(r=>r.JobID==id).Include(r=>r.ExamTypeInfo).ToList();
            return RequiredJobExamTypeses;
        }

        // POST api/RequiredJobExamTypes
        public string Post(RequiredJobExamTypes objRequiredJobExamTypes)
        {
            try
            {
                var obj = new RequiredJobExamTypes
                {
                    JobID = objRequiredJobExamTypes.JobID,
                    ExamTypeID = objRequiredJobExamTypes.ExamTypeID,
                    IsRunning = objRequiredJobExamTypes.IsRunning
                };
                Db.RequiredJobExamTypes.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(RequiredJobExamTypes objRequiredJobExamTypes)
        {
            try
            {
                List<RequiredJobExamTypes> objJobExam = Db.RequiredJobExamTypes.Where(j => j.JobID == objRequiredJobExamTypes.JobID).ToList();
                foreach (var objS in objJobExam)
                {
                    Db.Entry(objS).State = EntityState.Deleted;
                    Db.SaveChanges();
                }
                this.Post(objRequiredJobExamTypes);
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/RequiredJobExamTypes/5
        public string Delete(int id)
        {
            try
            {
                List<RequiredJobExamTypes> objJobExam = Db.RequiredJobExamTypes.Where(j => j.JobID == id).ToList();
                foreach (var objS in objJobExam)
                {
                    Db.Entry(objS).State = EntityState.Deleted;
                    Db.SaveChanges();
                }
                return "Deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
