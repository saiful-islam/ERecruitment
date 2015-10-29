namespace ERecruitment.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantInfo",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobileNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MailingAddress = c.String(nullable: false),
                        StatusCode = c.Int(nullable: false),
                        ExpertiseCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicantID)
                .ForeignKey("dbo.ExpertiseInfo", t => t.ExpertiseCode, cascadeDelete: true)
                .ForeignKey("dbo.StatusInfo", t => t.StatusCode, cascadeDelete: true)
                .Index(t => t.StatusCode)
                .Index(t => t.ExpertiseCode);
            
            CreateTable(
                "dbo.ApplicantSkillHistory",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicantID, t.SkillID })
                .ForeignKey("dbo.ApplicantInfo", t => t.ApplicantID, cascadeDelete: true)
                .ForeignKey("dbo.SkillInfo", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.ApplicantID)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.SkillInfo",
                c => new
                    {
                        SkillID = c.Int(nullable: false),
                        SkillName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID);
            
            CreateTable(
                "dbo.RequiredJobSkills",
                c => new
                    {
                        JobID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobID, t.SkillID })
                .ForeignKey("dbo.JobDetails", t => t.JobID, cascadeDelete: true)
                .ForeignKey("dbo.SkillInfo", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.JobID)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.JobDetails",
                c => new
                    {
                        JobID = c.Int(nullable: false),
                        JobName = c.String(nullable: false),
                        UserID = c.String(nullable: false),
                        MinimumExperiance = c.Single(nullable: false),
                        MaximumExperiance = c.Single(nullable: false),
                        SubmissionDeadline = c.DateTime(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.TeamInfo", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.EducationCriteria",
                c => new
                    {
                        JobID = c.Int(nullable: false),
                        InstituteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobID, t.InstituteID })
                .ForeignKey("dbo.InstituteInfo", t => t.InstituteID, cascadeDelete: true)
                .ForeignKey("dbo.JobDetails", t => t.JobID, cascadeDelete: true)
                .Index(t => t.JobID)
                .Index(t => t.InstituteID);
            
            CreateTable(
                "dbo.InstituteInfo",
                c => new
                    {
                        InstituteID = c.Int(nullable: false),
                        InstituteName = c.String(nullable: false),
                        IsPrivateUniversity = c.Boolean(nullable: false),
                        IsNationalUniversity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InstituteID);
            
            CreateTable(
                "dbo.EducationHistory",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false),
                        EducationID = c.Int(nullable: false),
                        InstituteID = c.Int(nullable: false),
                        Major = c.String(nullable: false),
                        Result = c.String(nullable: false),
                        PassingYear = c.DateTime(nullable: false),
                        IsOldResultSystem = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicantID, t.EducationID, t.InstituteID })
                .ForeignKey("dbo.ApplicantInfo", t => t.ApplicantID, cascadeDelete: true)
                .ForeignKey("dbo.EducationInfo", t => t.EducationID, cascadeDelete: true)
                .ForeignKey("dbo.InstituteInfo", t => t.InstituteID, cascadeDelete: true)
                .Index(t => t.ApplicantID)
                .Index(t => t.EducationID)
                .Index(t => t.InstituteID);
            
            CreateTable(
                "dbo.EducationInfo",
                c => new
                    {
                        EducationID = c.Int(nullable: false),
                        EducationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EducationID);
            
            CreateTable(
                "dbo.ExamInfo",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false),
                        JobID = c.Int(nullable: false),
                        ExamTypeID = c.Int(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                        Marks = c.Single(nullable: false),
                        IsRejected = c.Boolean(nullable: false),
                        IsExamCompleted = c.Boolean(nullable: false),
                        IsPassed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicantID, t.JobID, t.ExamTypeID })
                .ForeignKey("dbo.ApplicantInfo", t => t.ApplicantID, cascadeDelete: true)
                .ForeignKey("dbo.ExamTypeInfo", t => t.ExamTypeID, cascadeDelete: true)
                .ForeignKey("dbo.JobDetails", t => t.JobID, cascadeDelete: true)
                .Index(t => t.ApplicantID)
                .Index(t => t.JobID)
                .Index(t => t.ExamTypeID);
            
            CreateTable(
                "dbo.ExamTypeInfo",
                c => new
                    {
                        ExamTypeID = c.Int(nullable: false),
                        ExamType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExamTypeID);
            
            CreateTable(
                "dbo.TeamInfo",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        TeamName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.CareerInfo",
                c => new
                    {
                        CareerID = c.Int(nullable: false),
                        ApplicantID = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        LeaveDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CareerID)
                .ForeignKey("dbo.ApplicantInfo", t => t.ApplicantID, cascadeDelete: true)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.ExpertiseInfo",
                c => new
                    {
                        ExpertiseCode = c.Int(nullable: false),
                        ExpertiseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExpertiseCode);
            
            CreateTable(
                "dbo.ProjectThesisInfo",
                c => new
                    {
                        ProjectThesisID = c.Int(nullable: false),
                        ApplicantID = c.Int(nullable: false),
                        ProjectThesisName = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        MajorRule = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        URL = c.String(),
                        IsProject = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectThesisID)
                .ForeignKey("dbo.ApplicantInfo", t => t.ApplicantID, cascadeDelete: true)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.StatusInfo",
                c => new
                    {
                        StatusCode = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StatusCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicantInfo", "StatusCode", "dbo.StatusInfo");
            DropForeignKey("dbo.ProjectThesisInfo", "ApplicantID", "dbo.ApplicantInfo");
            DropForeignKey("dbo.ApplicantInfo", "ExpertiseCode", "dbo.ExpertiseInfo");
            DropForeignKey("dbo.CareerInfo", "ApplicantID", "dbo.ApplicantInfo");
            DropForeignKey("dbo.ApplicantSkillHistory", "SkillID", "dbo.SkillInfo");
            DropForeignKey("dbo.RequiredJobSkills", "SkillID", "dbo.SkillInfo");
            DropForeignKey("dbo.RequiredJobSkills", "JobID", "dbo.JobDetails");
            DropForeignKey("dbo.JobDetails", "TeamId", "dbo.TeamInfo");
            DropForeignKey("dbo.ExamInfo", "JobID", "dbo.JobDetails");
            DropForeignKey("dbo.ExamInfo", "ExamTypeID", "dbo.ExamTypeInfo");
            DropForeignKey("dbo.ExamInfo", "ApplicantID", "dbo.ApplicantInfo");
            DropForeignKey("dbo.EducationCriteria", "JobID", "dbo.JobDetails");
            DropForeignKey("dbo.EducationCriteria", "InstituteID", "dbo.InstituteInfo");
            DropForeignKey("dbo.EducationHistory", "InstituteID", "dbo.InstituteInfo");
            DropForeignKey("dbo.EducationHistory", "EducationID", "dbo.EducationInfo");
            DropForeignKey("dbo.EducationHistory", "ApplicantID", "dbo.ApplicantInfo");
            DropForeignKey("dbo.ApplicantSkillHistory", "ApplicantID", "dbo.ApplicantInfo");
            DropIndex("dbo.ProjectThesisInfo", new[] { "ApplicantID" });
            DropIndex("dbo.CareerInfo", new[] { "ApplicantID" });
            DropIndex("dbo.ExamInfo", new[] { "ExamTypeID" });
            DropIndex("dbo.ExamInfo", new[] { "JobID" });
            DropIndex("dbo.ExamInfo", new[] { "ApplicantID" });
            DropIndex("dbo.EducationHistory", new[] { "InstituteID" });
            DropIndex("dbo.EducationHistory", new[] { "EducationID" });
            DropIndex("dbo.EducationHistory", new[] { "ApplicantID" });
            DropIndex("dbo.EducationCriteria", new[] { "InstituteID" });
            DropIndex("dbo.EducationCriteria", new[] { "JobID" });
            DropIndex("dbo.JobDetails", new[] { "TeamId" });
            DropIndex("dbo.RequiredJobSkills", new[] { "SkillID" });
            DropIndex("dbo.RequiredJobSkills", new[] { "JobID" });
            DropIndex("dbo.ApplicantSkillHistory", new[] { "SkillID" });
            DropIndex("dbo.ApplicantSkillHistory", new[] { "ApplicantID" });
            DropIndex("dbo.ApplicantInfo", new[] { "ExpertiseCode" });
            DropIndex("dbo.ApplicantInfo", new[] { "StatusCode" });
            DropTable("dbo.StatusInfo");
            DropTable("dbo.ProjectThesisInfo");
            DropTable("dbo.ExpertiseInfo");
            DropTable("dbo.CareerInfo");
            DropTable("dbo.TeamInfo");
            DropTable("dbo.ExamTypeInfo");
            DropTable("dbo.ExamInfo");
            DropTable("dbo.EducationInfo");
            DropTable("dbo.EducationHistory");
            DropTable("dbo.InstituteInfo");
            DropTable("dbo.EducationCriteria");
            DropTable("dbo.JobDetails");
            DropTable("dbo.RequiredJobSkills");
            DropTable("dbo.SkillInfo");
            DropTable("dbo.ApplicantSkillHistory");
            DropTable("dbo.ApplicantInfo");
        }
    }
}
