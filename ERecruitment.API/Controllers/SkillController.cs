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
    public class SkillController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Skill
        public ICollection<SkillInfo> Get()
        {
            var skillInfoes = Db.SkillInfo.ToList();
            return skillInfoes;
        }

        // GET api/Skill/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Skill
        public string Post(SkillInfo objSkill)
        {
            try
            {
                int maxid = 0;
                if (Db.SkillInfo.Any())
                {
                    maxid = Db.SkillInfo.Max(e => e.SkillID);
                }
                var obj = new SkillInfo
                {
                    SkillID = maxid + 1,
                    SkillName = objSkill.SkillName
                };
                Db.SkillInfo.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(SkillInfo objSkill)
        {
            try
            {
                var obj = Db.SkillInfo.Find(objSkill.SkillID);
                obj.SkillName = objSkill.SkillName;

                Db.SaveChanges();
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
                var obj = Db.SkillInfo.Find(id);
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
