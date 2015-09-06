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
    public class EducationController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Education
        public ICollection<EducationInfo> Get()
        {
            var educationInfoes = Db.EducationInfo.ToList();
            return educationInfoes;
        }

        // GET api/Education/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Education
        public string Post(EducationInfo objEducation)
        {
            try
            {
                int maxid = 0;
                if (Db.EducationInfo.Any())
                {
                    maxid = Db.EducationInfo.Max(e => e.EducationID);
                }
                var obj = new EducationInfo
                {
                    EducationID = maxid + 1,
                    EducationName = objEducation.EducationName
                };
                Db.EducationInfo.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(EducationInfo objEducation)
        {
            try
            {
                var obj = Db.EducationInfo.Find(objEducation.EducationID);
                obj.EducationName = objEducation.EducationName;

                Db.SaveChanges();
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/Education/5
        public string Delete(int id)
        {
            try
            {
                var obj = Db.EducationInfo.Find(id);
                Db.Entry(obj).State = EntityState.Deleted;
                Db.SaveChanges();
                return "Deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
