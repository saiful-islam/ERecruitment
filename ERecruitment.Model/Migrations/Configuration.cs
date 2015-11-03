using ERecruitment.Model.Models;

namespace ERecruitment.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ERecruitment.Model.Context.ERecruitmentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ERecruitment.Model.Context.ERecruitmentDBContext context)
        {
            context.ExpertiseInfo.Add(new ExpertiseInfo { ExpertiseCode = 1, ExpertiseName = "Forntend" });
            context.ExpertiseInfo.Add(new ExpertiseInfo { ExpertiseCode = 2, ExpertiseName = "Database" });

            context.ExamTypeInfo.Add(new ExamTypeInfo { ExamTypeID = 1, ExamType = "Written" });
            context.ExamTypeInfo.Add(new ExamTypeInfo { ExamTypeID = 2, ExamType = "Viva" });
            context.ExamTypeInfo.Add(new ExamTypeInfo { ExamTypeID = 3, ExamType = "HR" });
            context.ExamTypeInfo.Add(new ExamTypeInfo { ExamTypeID = 4, ExamType = "Final Selection" });

            context.StatusInfo.Add(new StatusInfo { StatusCode = 1, Status = "Joined" });
            context.StatusInfo.Add(new StatusInfo { StatusCode = 2, Status = "Active" });
            context.StatusInfo.Add(new StatusInfo { StatusCode = 3, Status = "Leave Job" });
            context.StatusInfo.Add(new StatusInfo { StatusCode = 4, Status = "Rejected from written exam", ExamTypeID = 1});
            context.StatusInfo.Add(new StatusInfo { StatusCode = 5, Status = "Rejected from technical viva", ExamTypeID = 2 });
            context.StatusInfo.Add(new StatusInfo { StatusCode = 6, Status = "Rejected from HR viva", ExamTypeID = 3 });
            context.StatusInfo.Add(new StatusInfo { StatusCode = 7, Status = "Rejected from final selection", ExamTypeID = 4 });

            context.ApplicantInfo.Add(new ApplicantInfo
            {
                ApplicantID = 1,
                FirstName = "Saiful",
                LastName = "Islam",
                MobileNo = "01943053515",
                Email = "saifuliitdu@gmail.com",
                MailingAddress = "58/12-north mugdhapara, dhaka-1217",
                StatusCode = 2,
                ExpertiseCode = 2
            });
            context.ApplicantInfo.Add(new ApplicantInfo
            {
                ApplicantID = 2,
                FirstName = "Jasim",
                LastName = "Uddin",
                MobileNo = "01943053516",
                Email = "jasim.uddin@gmail.com",
                MailingAddress = "58/12-north banasree, dhaka-1215",
                StatusCode = 2,
                ExpertiseCode = 1
            });

            context.SkillInfo.Add(new SkillInfo { SkillID = 1, SkillName = "C#" });
            context.SkillInfo.Add(new SkillInfo { SkillID = 2, SkillName = "SQL Server" });

            context.ApplicantSkillHistory.Add(new ApplicantSkillHistory { ApplicantID = 1, SkillID = 1, IsPrimary = true});
            context.ApplicantSkillHistory.Add(new ApplicantSkillHistory { ApplicantID = 2, SkillID = 1, IsPrimary = true });
            context.ApplicantSkillHistory.Add(new ApplicantSkillHistory { ApplicantID = 1, SkillID = 2, IsPrimary = false });

            context.SectionInfo.Add(new SectionInfo { SectionId = 1, SectionName = "Database" });
            context.SectionInfo.Add(new SectionInfo { SectionId = 2, SectionName = "Front End" });
            context.SectionInfo.Add(new SectionInfo { SectionId = 3, SectionName = "OCD" });
            context.SectionInfo.Add(new SectionInfo { SectionId = 4, SectionName = "PMO" });
            
        }
    }
}
