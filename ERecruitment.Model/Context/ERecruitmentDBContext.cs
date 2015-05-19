using ERecruitment.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Context
{
    public class ERecruitmentDBContext : DbContext
    {
        public ERecruitmentDBContext()
            : base("name=ERecruitmentDBContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<AspNetRoles> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<ApplicantInfo> ApplicantInfo { get; set; }
        public DbSet<ApplicantSkillHistory> ApplicantSkillHistory { get; set; }
        public DbSet<CareerInfo> CareerInfo { get; set; }
        public DbSet<EducationCriteria> EducationCriteria { get; set; }
        public DbSet<EducationHistory> EducationHistory { get; set; }
        public DbSet<EducationInfo> EducationInfo { get; set; }
        public DbSet<ExamInfo> ExamInfo { get; set; }
        public DbSet<ExamTypeInfo> ExamTypeInfo { get; set; }
        public DbSet<ExpertiseInfo> ExpertiseInfo { get; set; }
        public DbSet<InstituteInfo> InstituteInfo { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }
        public DbSet<ProjectThesisInfo> ProjectThesisInfo { get; set; }
        public DbSet<RequiredJobSkills> RequiredJobSkills { get; set; }
        public DbSet<SkillInfo> SkillInfo { get; set; }
        public DbSet<StatusInfo> StatusInfo { get; set; }
    }
}
