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
    public class InstituteController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Institute
        public ICollection<InstituteInfo> Get()
        {
            var instituteInfoes = Db.InstituteInfo.ToList();
            return instituteInfoes;
        }

        // GET api/Institute/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Institute
        public string Post(InstituteInfo objInstitute)
        {
            try
            {
                int maxid = 0;
                if (Db.InstituteInfo.Any())
                {
                    maxid = Db.InstituteInfo.Max(e => e.InstituteID);
                }
                var obj = new InstituteInfo
                {
                    InstituteID = maxid + 1,
                    InstituteName = objInstitute.InstituteName,
                    IsNationalUniversity = objInstitute.IsNationalUniversity,
                    IsPrivateUniversity = objInstitute.IsPrivateUniversity
                };
                Db.InstituteInfo.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(InstituteInfo objInstitute)
        {
            try
            {
                var obj = Db.InstituteInfo.Find(objInstitute.InstituteID);
                obj.InstituteName = objInstitute.InstituteName;
                obj.IsNationalUniversity = objInstitute.IsNationalUniversity;
                obj.IsPrivateUniversity = objInstitute.IsPrivateUniversity;

                Db.SaveChanges();
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/Institute/5
        public string Delete(int id)
        {
            try
            {
                var obj = Db.InstituteInfo.Find(id);
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
