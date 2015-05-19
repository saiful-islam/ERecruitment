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

namespace ERecruitment.API.Controllers
{
    public class ExpertiseController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/expertise
        public ICollection<ExpertiseInfo> Get()
        {
            var expertiseInfoes = Db.ExpertiseInfo.ToList();
            return expertiseInfoes;
        }

        // GET api/expertise/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/expertise
        public string Post(ExpertiseInfo objExpertise)
        {
            try
            {
                var obj = new ExpertiseInfo
                {
                    ExpertiseName = objExpertise.ExpertiseName
                };
                Db.ExpertiseInfo.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(int expertiseCode, ExpertiseInfo objExpertise)
        {
            try
            {
                ExpertiseInfo obj = new ExpertiseInfo { ExpertiseName = objExpertise.ExpertiseName };
                Db.ExpertiseInfo.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/expertise/5
        public void Delete(int id)
        {
        }
    }
}
