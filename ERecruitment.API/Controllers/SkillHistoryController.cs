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
    public class SkillHistoryController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/SkillHistory
        public ICollection<ApplicantSkillHistory> Get()
        {
            var applicantSkillHistory = Db.ApplicantSkillHistory.ToList();
            return applicantSkillHistory;
        }

        // GET api/SkillHistory/5
        public ICollection<ApplicantSkillHistory> Get(int id)
        {
            var applicantSkillHistory = Db.ApplicantSkillHistory.Where(a=>a.ApplicantID==id).ToList();
            return applicantSkillHistory;
        }

        // POST api/SkillHistory
        public string Post(ApplicantSkillHistory objSkillHistory)
        {
            //try
            //{
            //    int maxid = 0;
            //    if (Db.ApplicantSkillHistory.Any())
            //    {
            //        maxid = Db.ApplicantSkillHistory.Max(e => e.SkillHistoryID);
            //    }
            //    var obj = new ApplicantSkillHistory
            //    {
            //        SkillHistoryID = maxid + 1,
            //        SkillHistoryName = objSkillHistory.SkillHistoryName
            //    };
            //    Db.ApplicantSkillHistory.Add(obj);

            //    Db.SaveChanges();
            //    return "Saved";
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
            return "Saved";
        }
        public string Put(ApplicantSkillHistory objSkillHistory)
        {
            //try
            //{
            //    var obj = Db.ApplicantSkillHistory.Find(objSkillHistory.SkillHistoryID);
            //    obj.SkillHistoryName = objSkillHistory.SkillHistoryName;

            //    Db.SaveChanges();
            //    return "Updated";
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
            return "Updated";
        }
        // DELETE api/SkillHistory/5
        public string Delete(int id)
        {
            //try
            //{
            //    var obj = Db.ApplicantSkillHistory.Find(id);
            //    Db.Entry(obj).State = EntityState.Deleted;
            //    Db.SaveChanges();
            //    return "Deleted";
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
            return "Deleted";
        }
    }
}
