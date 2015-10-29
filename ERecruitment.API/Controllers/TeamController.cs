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
    public class TeamController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/Team
        public ICollection<TeamInfo> Get()
        {
            var TeamInfoes = Db.TeamInfo.ToList();
            return TeamInfoes;
        }

        // GET api/Team/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Team
        public string Post(TeamInfo objTeam)
        {
            try
            {
                int maxid = 0;
                if (Db.TeamInfo.Any())
                {
                    maxid = Db.TeamInfo.Max(e => e.TeamId);
                }
                var obj = new TeamInfo
                {
                    TeamId = maxid + 1,
                    TeamName = objTeam.TeamName
                };
                Db.TeamInfo.Add(obj);

                Db.SaveChanges();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(TeamInfo objTeam)
        {
            try
            {
                var obj = Db.TeamInfo.Find(objTeam.TeamId);
                obj.TeamName = objTeam.TeamName;

                Db.SaveChanges();
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/Team/5
        public string Delete(int id)
        {
            try
            {
                var obj = Db.TeamInfo.Find(id);
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
