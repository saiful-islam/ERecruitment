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
    public class StatusController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Status
        public ICollection<StatusInfo> Get()
        {
            var statusInfoes = Db.StatusInfo.ToList();
            return statusInfoes;
        }

        // GET api/Status/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Status
        public string Post(StatusInfo objStatus)
        {
            try
            {
                int maxid = 0;
                if (Db.StatusInfo.Any())
                {
                    maxid = Db.StatusInfo.Max(e => e.StatusCode);
                }
                var obj = new StatusInfo
                {
                    StatusCode = maxid + 1,
                    Status = objStatus.Status
                };
                Db.StatusInfo.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(StatusInfo objStatus)
        {
            try
            {
                var obj = Db.StatusInfo.Find(objStatus.StatusCode);
                obj.Status = objStatus.Status;

                Db.SaveChanges();
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/Status/5
        public string Delete(int id)
        {
            try
            {
                var obj = Db.StatusInfo.Find(id);
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
