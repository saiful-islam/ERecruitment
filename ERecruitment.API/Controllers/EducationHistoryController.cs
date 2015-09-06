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
    public class EducationHistoryController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/expertise
        public ICollection<EducationHistory> Get()
        {
            var EducationHistories = Db.EducationHistory.ToList();
            return EducationHistories;
        }

        // GET api/expertise/5
        public ICollection<EducationHistory> Get(int id)
        {
            var EducationHistories = Db.EducationHistory.Where(c => c.ApplicantID == id).ToList();
            return EducationHistories;
        }

        // POST api/expertise
        public string Post(EducationHistory objEducationHistory)
        {
            //try
            //{
            //    int maxid = Db.ExpertiseInfo.Max(e => e.ExpertiseCode);
            //    var obj = new ExpertiseInfo
            //    {
            //        ExpertiseCode = maxid + 1,
            //        ExpertiseName = objExpertise.ExpertiseName
            //    };
            //    Db.ExpertiseInfo.Add(obj);

            //    Db.SaveChanges();
            //    return "Saved";
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
            return "";
        }
        public string Put(EducationHistory objEducationHistory)
        {
            //try
            //{
            //    var obj = Db.ExpertiseInfo.Find(objExpertise.ExpertiseCode);
            //    obj.ExpertiseName = objExpertise.ExpertiseName;

            //    Db.SaveChanges();
            //    return "Updated";
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
            return "";
        }
        // DELETE api/expertise/5
        public string Delete(int id)
        {
            //try
            //{
            //    var obj = Db.ExpertiseInfo.Find(id);
            //    Db.Entry(obj).State = EntityState.Deleted;
            //    Db.SaveChanges();
            //    return "Deleted";
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
            return "";
        }
    }
}
