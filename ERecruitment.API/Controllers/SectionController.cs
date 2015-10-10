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
    public class SectionController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Section
        public ICollection<SectionInfo> Get()
        {
            var SectionInfoes = Db.SectionInfo.ToList();
            return SectionInfoes;
        }

        // GET api/Section/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Section
        public string Post(SectionInfo objSection)
        {
            try
            {
                int maxid = 0;
                if (Db.SectionInfo.Any())
                {
                    maxid = Db.SectionInfo.Max(e => e.SectionId);
                }
                var obj = new SectionInfo
                {
                    SectionId = maxid + 1,
                    SectionName = objSection.SectionName
                };
                Db.SectionInfo.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(SectionInfo objSection)
        {
            try
            {
                var obj = Db.SectionInfo.Find(objSection.SectionId);
                obj.SectionName = objSection.SectionName;

                Db.SaveChanges();
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/Section/5
        public string Delete(int id)
        {
            try
            {
                var obj = Db.SectionInfo.Find(id);
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
