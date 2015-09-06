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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ERecruitment.API.Controllers
{
    public class ApplicantController : ApiController
    {
        public readonly ERecruitmentDBContext Db = new ERecruitmentDBContext();
        // GET api/expertise
        public dynamic Get()
        {
            var applicantInfoes = from a in Db.ApplicantInfo.Include(a => a.ExpertiseInfo).Include(a => a.StatusInfo)
                                  select new
                                  {
                                      a.ApplicantID,
                                      a.FirstName,
                                      a.LastName,
                                      a.MobileNo,
                                      a.Email,
                                      a.MailingAddress,
                                      a.StatusInfo.Status,
                                      a.ExpertiseInfo.ExpertiseName
                                  };
            return applicantInfoes.ToList();
        }

        // GET api/expertise/5
        public ICollection<ApplicantInfo> Get(int id)
        {
            var applicantInfoes = Db.ApplicantInfo.Where(app=>app.ApplicantID==id).ToList();
                                 
            return applicantInfoes;
        }

        // POST api/expertise
        public string Post(JObject jasonData)
        {
            try
            {
                ApplicantInfo objApplicantInfo = JsonConvert.DeserializeObject<ApplicantInfo>(jasonData["objApplicantInfo"].ToString());
                List<CareerInfo> objCareerInfo = JsonConvert.DeserializeObject<List<CareerInfo>>(jasonData["objCareerInfo"].ToString());
                List<ProjectThesisInfo> objProjectThesisInfo = JsonConvert.DeserializeObject<List<ProjectThesisInfo>>(jasonData["objProjectThesisInfo"].ToString());
                List<EducationHistory> objEducation = JsonConvert.DeserializeObject<List<EducationHistory>>(jasonData["objEducation"].ToString());
                List<ApplicantSkillHistory> objSkillHistories = JsonConvert.DeserializeObject<List<ApplicantSkillHistory>>(jasonData["objSkill"].ToString());

                int applicantId =0;
                 if (Db.ApplicantInfo.Any())
                    {
                        applicantId = Db.ApplicantInfo.Max(a => a.ApplicantID);
                    }
                var objApplicant = new ApplicantInfo
                {
                    ApplicantID = applicantId+1,
                    FirstName = objApplicantInfo.FirstName,
                    LastName = objApplicantInfo.LastName,
                    MobileNo = objApplicantInfo.MobileNo,
                    Email = objApplicantInfo.Email,
                    MailingAddress = objApplicantInfo.MailingAddress,
                    StatusCode = objApplicantInfo.StatusCode,
                    ExpertiseCode = objApplicantInfo.ExpertiseCode
                };
                Db.ApplicantInfo.Add(objApplicant);
                Db.SaveChanges();

                foreach (var objC in objCareerInfo)
                {
                    int careerId = 0;
                    if (Db.CareerInfo.Any())
                    {
                        careerId = Db.CareerInfo.Max(e => e.CareerID);
                    }
                    var objCareer = new CareerInfo
                    {
                        CareerID = careerId+1,
                        ApplicantID = objApplicant.ApplicantID,
                        CompanyName = objC.CompanyName,
                        Title = objC.Title,
                        Location = objC.Location,
                        JoinDate = objC.JoinDate,
                        LeaveDate = objC.LeaveDate,
                        Description = objC.Description
                    };
                    Db.CareerInfo.Add(objCareer);
                    Db.SaveChanges();
                }

                foreach (var objP in objProjectThesisInfo)
                {
                    int projectThesisId = 0;
                    if (Db.ProjectThesisInfo.Any())
                    {
                        projectThesisId = Db.ProjectThesisInfo.Max(e => e.ProjectThesisID);
                    }
                    var objProjectThesis = new ProjectThesisInfo
                    {
                        ProjectThesisID = projectThesisId + 1,
                        ApplicantID = objApplicant.ApplicantID,
                        ProjectThesisName = objP.ProjectThesisName,
                        CompanyName = objP.CompanyName,
                        MajorRule = objP.MajorRule,
                        Description = objP.Description,
                        URL=objP.URL,
                        IsProject = objP.IsProject
                    };
                    Db.ProjectThesisInfo.Add(objProjectThesis);
                    Db.SaveChanges();
                }

                foreach (var objE in objEducation)
                {
                    var objEducationHistory = new EducationHistory
                    {
                        ApplicantID = objApplicant.ApplicantID,
                        EducationID = objE.EducationID,
                        InstituteID = objE.InstituteID,
                        Major = objE.Major,
                        Result = objE.Result,
                        PassingYear=objE.PassingYear,
                        IsOldResultSystem = objE.IsOldResultSystem
                    };
                    Db.EducationHistory.Add(objEducationHistory);
                    Db.SaveChanges();
                }

                foreach (var objS in objSkillHistories)
                {
                    var objSkillHistory = new ApplicantSkillHistory
                    {
                        ApplicantID = objApplicant.ApplicantID,
                        SkillID = objS.SkillID,
                        IsPrimary = objS.IsPrimary
                    };
                    Db.ApplicantSkillHistory.Add(objSkillHistory);
                    Db.SaveChanges();
                }

                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Put(JObject jasonData)
        {
            try
            {

                ApplicantInfo objApplicantInfo = JsonConvert.DeserializeObject<ApplicantInfo>(jasonData["objApplicantInfo"].ToString());
                List<CareerInfo> objCareerInfo = JsonConvert.DeserializeObject<List<CareerInfo>>(jasonData["objCareerInfo"].ToString());
                List<ProjectThesisInfo> objProjectThesisInfo = JsonConvert.DeserializeObject<List<ProjectThesisInfo>>(jasonData["objProjectThesisInfo"].ToString());
                List<EducationHistory> objEducation = JsonConvert.DeserializeObject<List<EducationHistory>>(jasonData["objEducation"].ToString());
                List<ApplicantSkillHistory> objSkillHistories = JsonConvert.DeserializeObject<List<ApplicantSkillHistory>>(jasonData["objSkill"].ToString());

                ApplicantInfo objApplicant = Db.ApplicantInfo.Single(a => a.ApplicantID == objApplicantInfo.ApplicantID);
                
                objApplicant.FirstName = objApplicantInfo.FirstName;
                objApplicant.LastName = objApplicantInfo.LastName;
                objApplicant.MobileNo = objApplicantInfo.MobileNo;
                objApplicant.Email = objApplicantInfo.Email;
                objApplicant.MailingAddress = objApplicantInfo.MailingAddress;
                objApplicant.StatusCode = objApplicantInfo.StatusCode;
                objApplicant.ExpertiseCode = objApplicantInfo.ExpertiseCode;
                
                Db.SaveChanges();

                List<CareerInfo> objOldCareerInfo = Db.CareerInfo.Where(c => c.ApplicantID == objApplicant.ApplicantID).ToList();
                List<CareerInfo> objNewCareerInfo = new List<CareerInfo>();

                foreach (var objC in objCareerInfo)
                {
                    int careerId = 0;
                    if (Db.CareerInfo.Any())
                    {
                        careerId = Db.CareerInfo.Max(e => e.CareerID);
                        var objCareer = Db.CareerInfo.Find(objC.CareerID);
                        if (objCareer==null)
                        {
                            objCareer = new CareerInfo
                            {
                                CareerID = careerId + 1,
                                ApplicantID = objApplicant.ApplicantID,
                                CompanyName = objC.CompanyName,
                                Title = objC.Title,
                                Location = objC.Location,
                                JoinDate = objC.JoinDate,
                                LeaveDate = objC.LeaveDate,
                                Description = objC.Description
                            };
                            objNewCareerInfo.Add(objCareer);
                            Db.CareerInfo.Add(objCareer);
                        }
                        else
                        {
                            objCareer.CompanyName = objC.CompanyName;
                            objCareer.Title = objC.Title;
                            objCareer.Location = objC.Location;
                            objCareer.JoinDate = objC.JoinDate;
                            objCareer.LeaveDate = objC.LeaveDate;
                            objCareer.Description = objC.Description;
                            objNewCareerInfo.Add(objCareer);
                            
                        }
                    }
                    else
                    {
                        var objCareer = new CareerInfo
                        {
                            CareerID = careerId + 1,
                            ApplicantID = objApplicant.ApplicantID,
                            CompanyName = objC.CompanyName,
                            Title = objC.Title,
                            Location = objC.Location,
                            JoinDate = objC.JoinDate,
                            LeaveDate = objC.LeaveDate,
                            Description = objC.Description
                        };
                        objNewCareerInfo.Add(objCareer);
                        Db.CareerInfo.Add(objCareer);
                    }
                    Db.SaveChanges();
                }

               
                List<CareerInfo> objRemovedCareerInfos = objOldCareerInfo.Except(objNewCareerInfo).ToList();
                foreach (var objC in objRemovedCareerInfos)
                {
                    Db.Entry(objC).State = EntityState.Deleted;
                    Db.SaveChanges();
                }



                List<ProjectThesisInfo> objOldProjectThesisInfo = Db.ProjectThesisInfo.Where(c => c.ApplicantID == objApplicant.ApplicantID).ToList();
                List<ProjectThesisInfo> objNewProjectThesisInfo = new List<ProjectThesisInfo>();

                foreach (var objP in objProjectThesisInfo)
                {
                    int projectThesisId = 0;
                    if (Db.ProjectThesisInfo.Any())
                    {
                        projectThesisId = Db.ProjectThesisInfo.Max(e => e.ProjectThesisID);
                        var objProjectThesis = Db.ProjectThesisInfo.Find(objP.ProjectThesisID);
                        if (objProjectThesis == null)
                        {
                            objProjectThesis = new ProjectThesisInfo
                            {
                                ProjectThesisID = projectThesisId + 1,
                                ApplicantID = objApplicant.ApplicantID,
                                ProjectThesisName = objP.ProjectThesisName,
                                CompanyName = objP.CompanyName,
                                MajorRule = objP.MajorRule,
                                Description = objP.Description,
                                URL = objP.URL,
                                IsProject = objP.IsProject
                            };
                            objNewProjectThesisInfo.Add(objProjectThesis);
                            Db.ProjectThesisInfo.Add(objProjectThesis);
                        }
                        else
                        {
                            objProjectThesis.ProjectThesisName = objP.ProjectThesisName;
                            objProjectThesis.CompanyName = objP.CompanyName;
                            objProjectThesis.MajorRule = objP.MajorRule;
                            objProjectThesis.Description = objP.Description;
                            objProjectThesis.URL = objP.URL;
                            objProjectThesis.IsProject = objP.IsProject;
                            objNewProjectThesisInfo.Add(objProjectThesis);
                        }
                    }
                    else
                    {


                        var objProjectThesis = new ProjectThesisInfo
                        {
                            ProjectThesisID = projectThesisId + 1,
                            ApplicantID = objApplicant.ApplicantID,
                            ProjectThesisName = objP.ProjectThesisName,
                            CompanyName = objP.CompanyName,
                            MajorRule = objP.MajorRule,
                            Description = objP.Description,
                            URL = objP.URL,
                            IsProject = objP.IsProject
                        };
                        objNewProjectThesisInfo.Add(objProjectThesis);
                        Db.ProjectThesisInfo.Add(objProjectThesis);
                    }
                    Db.SaveChanges();
                }

                List<ProjectThesisInfo> objRemovedProjectThesis = objOldProjectThesisInfo.Except(objNewProjectThesisInfo).ToList();
                foreach (var objP in objRemovedProjectThesis)
                {
                    Db.Entry(objP).State = EntityState.Deleted;
                    Db.SaveChanges();
                }




                List<EducationHistory> objOldEducationHistory = Db.EducationHistory.Where(e => e.ApplicantID == objApplicant.ApplicantID).ToList();
                foreach (var objE in objOldEducationHistory)
                {
                    Db.Entry(objE).State = EntityState.Deleted;
                    Db.SaveChanges();
                }


                foreach (var objE in objEducation)
                {
                    var objEducationHistory = new EducationHistory
                    {
                        ApplicantID = objApplicant.ApplicantID,
                        EducationID = objE.EducationID,
                        InstituteID = objE.InstituteID,
                        Major = objE.Major,
                        Result = objE.Result,
                        PassingYear = objE.PassingYear,
                        IsOldResultSystem = objE.IsOldResultSystem
                    };
                    Db.EducationHistory.Add(objEducationHistory);
                    Db.SaveChanges();
                }

                List<ApplicantSkillHistory> objOldSkillHistories = Db.ApplicantSkillHistory.Where(a => a.ApplicantID == objApplicant.ApplicantID).ToList();
                foreach (var objS in objOldSkillHistories)
                {
                    Db.Entry(objS).State = EntityState.Deleted;
                    Db.SaveChanges();
                }


                foreach (var objS in objSkillHistories)
                {
                    var objSkillHistory = new ApplicantSkillHistory
                    {
                        ApplicantID = objApplicant.ApplicantID,
                        SkillID = objS.SkillID,
                        IsPrimary = objS.IsPrimary
                    };
                    Db.ApplicantSkillHistory.Add(objSkillHistory);
                    Db.SaveChanges();
                }

                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/expertise/5
        public string Delete(int applicantId)
        {
            try
            {
                var obj = Db.ApplicantInfo.Find(applicantId);
                obj.StatusCode = 1;
                
                Db.SaveChanges();
                return "Joined";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
