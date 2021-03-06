USE [ImsRecruitmentSystem]
GO
/****** Object:  Table [dbo].[ApplicantInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicantInfo](
	[ApplicantID] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MobileNo] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[MailingAddress] [nvarchar](max) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[ExpertiseCode] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ApplicantInfo] PRIMARY KEY CLUSTERED 
(
	[ApplicantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicantSkillHistory]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicantSkillHistory](
	[ApplicantID] [int] NOT NULL,
	[SkillID] [int] NOT NULL,
	[IsPrimary] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ApplicantSkillHistory] PRIMARY KEY CLUSTERED 
(
	[ApplicantID] ASC,
	[SkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CareerInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CareerInfo](
	[CareerID] [int] NOT NULL,
	[ApplicantID] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[JoinDate] [datetime] NOT NULL,
	[LeaveDate] [datetime] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.CareerInfo] PRIMARY KEY CLUSTERED 
(
	[CareerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EducationCriteria]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationCriteria](
	[JobID] [int] NOT NULL,
	[InstituteID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.EducationCriteria] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC,
	[InstituteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EducationHistory]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationHistory](
	[ApplicantID] [int] NOT NULL,
	[EducationID] [int] NOT NULL,
	[InstituteID] [int] NOT NULL,
	[Major] [nvarchar](max) NOT NULL,
	[Result] [nvarchar](max) NOT NULL,
	[PassingYear] [datetime] NOT NULL,
	[IsOldResultSystem] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.EducationHistory] PRIMARY KEY CLUSTERED 
(
	[ApplicantID] ASC,
	[EducationID] ASC,
	[InstituteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EducationInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationInfo](
	[EducationID] [int] NOT NULL,
	[EducationName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.EducationInfo] PRIMARY KEY CLUSTERED 
(
	[EducationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamInfo](
	[ApplicantID] [int] NOT NULL,
	[JobID] [int] NOT NULL,
	[ExamTypeID] [int] NOT NULL,
	[ExamDate] [datetime] NOT NULL,
	[Marks] [real] NOT NULL,
	[IsRejected] [bit] NOT NULL,
	[IsExamCompleted] [bit] NOT NULL,
	[IsPassed] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ExamInfo] PRIMARY KEY CLUSTERED 
(
	[ApplicantID] ASC,
	[JobID] ASC,
	[ExamTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamTypeInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamTypeInfo](
	[ExamTypeID] [int] NOT NULL,
	[ExamType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.ExamTypeInfo] PRIMARY KEY CLUSTERED 
(
	[ExamTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpertiseInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpertiseInfo](
	[ExpertiseCode] [int] NOT NULL,
	[ExpertiseName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.ExpertiseInfo] PRIMARY KEY CLUSTERED 
(
	[ExpertiseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InstituteInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstituteInfo](
	[InstituteID] [int] NOT NULL,
	[InstituteName] [nvarchar](max) NOT NULL,
	[IsPrivateUniversity] [bit] NOT NULL,
	[IsNationalUniversity] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.InstituteInfo] PRIMARY KEY CLUSTERED 
(
	[InstituteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobDetails]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobDetails](
	[JobID] [int] NOT NULL,
	[JobName] [nvarchar](max) NOT NULL,
	[UserID] [nvarchar](max) NOT NULL,
	[MinimumExperiance] [real] NOT NULL,
	[MaximumExperiance] [real] NOT NULL,
	[SubmissionDeadline] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.JobDetails] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectThesisInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectThesisInfo](
	[ProjectThesisID] [int] NOT NULL,
	[ApplicantID] [int] NOT NULL,
	[ProjectThesisName] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[MajorRule] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[URL] [nvarchar](max) NULL,
	[IsProject] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ProjectThesisInfo] PRIMARY KEY CLUSTERED 
(
	[ProjectThesisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequiredJobSkills]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequiredJobSkills](
	[JobID] [int] NOT NULL,
	[SkillID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RequiredJobSkills] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC,
	[SkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SkillInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillInfo](
	[SkillID] [int] NOT NULL,
	[SkillName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.SkillInfo] PRIMARY KEY CLUSTERED 
(
	[SkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusInfo]    Script Date: 9/8/2015 10:31:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusInfo](
	[StatusCode] [int] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.StatusInfo] PRIMARY KEY CLUSTERED 
(
	[StatusCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[ApplicantInfo] ([ApplicantID], [FirstName], [LastName], [MobileNo], [Email], [MailingAddress], [StatusCode], [ExpertiseCode]) VALUES (1, N'Saiful', N'Islam', N'01943053515', N'saifuliitdu@gmail.com', N'58/12-north mugdhapara, dhaka-1217', 2, 2)
GO
INSERT [dbo].[ApplicantInfo] ([ApplicantID], [FirstName], [LastName], [MobileNo], [Email], [MailingAddress], [StatusCode], [ExpertiseCode]) VALUES (2, N'Mukul', N'Hossain', N'01121233', N'masudbikroy@gmail.com', N'sas', 2, 1)
GO
INSERT [dbo].[ApplicantSkillHistory] ([ApplicantID], [SkillID], [IsPrimary]) VALUES (1, 1, 1)
GO
INSERT [dbo].[ApplicantSkillHistory] ([ApplicantID], [SkillID], [IsPrimary]) VALUES (2, 1, 1)
GO
INSERT [dbo].[ApplicantSkillHistory] ([ApplicantID], [SkillID], [IsPrimary]) VALUES (2, 2, 0)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a21d481d-279b-4551-b98c-834a901c4a83', N'Admin')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'865e98f9-8d08-4d8c-91bc-f2aec1b3e107', N'a21d481d-279b-4551-b98c-834a901c4a83')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'865e98f9-8d08-4d8c-91bc-f2aec1b3e107', N'saiful.islam@bd.imshealth.com', 0, N'AIiZspmh/2btdT3+r+1MLdIfHP4JTM8DntWp3I5oi8LyOzwCkjySgNE4qI4ZHIuswQ==', N'2fa84d0a-750d-402a-a361-45b76acb8993', NULL, 0, 0, NULL, 1, 0, N'saiful.islam@bd.imshealth.com')
GO
INSERT [dbo].[CareerInfo] ([CareerID], [ApplicantID], [CompanyName], [Title], [Location], [JoinDate], [LeaveDate], [Description]) VALUES (1, 1, N'IMSA', N'asas', N'asas', CAST(0x0000A49200000000 AS DateTime), CAST(0x0000A58000000000 AS DateTime), N'asasas')
GO
INSERT [dbo].[CareerInfo] ([CareerID], [ApplicantID], [CompanyName], [Title], [Location], [JoinDate], [LeaveDate], [Description]) VALUES (2, 1, N'Southtech', N'asas', N'asasa', CAST(0x0000A41A00000000 AS DateTime), CAST(0x0000A41A00000000 AS DateTime), N'assas')
GO
INSERT [dbo].[CareerInfo] ([CareerID], [ApplicantID], [CompanyName], [Title], [Location], [JoinDate], [LeaveDate], [Description]) VALUES (3, 2, N'ISMS', N'asasas', N'sas', CAST(0x0000A41A00000000 AS DateTime), CAST(0x0000A41A00000000 AS DateTime), N'asas')
GO
INSERT [dbo].[EducationCriteria] ([JobID], [InstituteID]) VALUES (1, 2)
GO
INSERT [dbo].[EducationCriteria] ([JobID], [InstituteID]) VALUES (2, 2)
GO
INSERT [dbo].[EducationCriteria] ([JobID], [InstituteID]) VALUES (1, 3)
GO
INSERT [dbo].[EducationHistory] ([ApplicantID], [EducationID], [InstituteID], [Major], [Result], [PassingYear], [IsOldResultSystem]) VALUES (1, 1, 1, N'Science', N'First Class', CAST(0x0000982600000000 AS DateTime), 1)
GO
INSERT [dbo].[EducationHistory] ([ApplicantID], [EducationID], [InstituteID], [Major], [Result], [PassingYear], [IsOldResultSystem]) VALUES (1, 2, 1, N'Science', N'4.60', CAST(0x00009B0100000000 AS DateTime), 0)
GO
INSERT [dbo].[EducationHistory] ([ApplicantID], [EducationID], [InstituteID], [Major], [Result], [PassingYear], [IsOldResultSystem]) VALUES (1, 3, 3, N'SW', N'3.32', CAST(0x0000A0B600000000 AS DateTime), 0)
GO
INSERT [dbo].[EducationHistory] ([ApplicantID], [EducationID], [InstituteID], [Major], [Result], [PassingYear], [IsOldResultSystem]) VALUES (2, 3, 1, N'asas', N'3.65', CAST(0x0000A41A00000000 AS DateTime), 0)
GO
INSERT [dbo].[EducationInfo] ([EducationID], [EducationName]) VALUES (1, N'SSC')
GO
INSERT [dbo].[EducationInfo] ([EducationID], [EducationName]) VALUES (2, N'HSC')
GO
INSERT [dbo].[EducationInfo] ([EducationID], [EducationName]) VALUES (3, N'BSC in Computer')
GO
INSERT [dbo].[ExamInfo] ([ApplicantID], [JobID], [ExamTypeID], [ExamDate], [Marks], [IsRejected], [IsExamCompleted], [IsPassed]) VALUES (1, 1, 1, CAST(0x0000A52300000000 AS DateTime), 0, 0, 0, 0)
GO
INSERT [dbo].[ExamTypeInfo] ([ExamTypeID], [ExamType]) VALUES (1, N'Written')
GO
INSERT [dbo].[ExamTypeInfo] ([ExamTypeID], [ExamType]) VALUES (2, N'Viva')
GO
INSERT [dbo].[ExamTypeInfo] ([ExamTypeID], [ExamType]) VALUES (3, N'HR')
GO
INSERT [dbo].[ExpertiseInfo] ([ExpertiseCode], [ExpertiseName]) VALUES (1, N'Forntend')
GO
INSERT [dbo].[ExpertiseInfo] ([ExpertiseCode], [ExpertiseName]) VALUES (2, N'Database')
GO
INSERT [dbo].[InstituteInfo] ([InstituteID], [InstituteName], [IsPrivateUniversity], [IsNationalUniversity]) VALUES (1, N'Dhaka Board', 0, 0)
GO
INSERT [dbo].[InstituteInfo] ([InstituteID], [InstituteName], [IsPrivateUniversity], [IsNationalUniversity]) VALUES (2, N'BUET', 0, 0)
GO
INSERT [dbo].[InstituteInfo] ([InstituteID], [InstituteName], [IsPrivateUniversity], [IsNationalUniversity]) VALUES (3, N'Dhaka University', 0, 0)
GO
INSERT [dbo].[InstituteInfo] ([InstituteID], [InstituteName], [IsPrivateUniversity], [IsNationalUniversity]) VALUES (4, N'North South University', 1, 0)
GO
INSERT [dbo].[JobDetails] ([JobID], [JobName], [UserID], [MinimumExperiance], [MaximumExperiance], [SubmissionDeadline]) VALUES (1, N'Dot Net Developer', N'saiful.islam@bd.imshealth.com', 2, 5, CAST(0x0000A41A00000000 AS DateTime))
GO
INSERT [dbo].[JobDetails] ([JobID], [JobName], [UserID], [MinimumExperiance], [MaximumExperiance], [SubmissionDeadline]) VALUES (2, N'Sinior Software Engineer', N'saiful.islam@bd.imshealth.com', 2, 3, CAST(0x0000A52300000000 AS DateTime))
GO
INSERT [dbo].[ProjectThesisInfo] ([ProjectThesisID], [ApplicantID], [ProjectThesisName], [CompanyName], [MajorRule], [Description], [URL], [IsProject]) VALUES (1, 1, N'BASS', N'Southtech', N'All', N'SAS', N'http://localhost:6161/', 1)
GO
INSERT [dbo].[ProjectThesisInfo] ([ProjectThesisID], [ApplicantID], [ProjectThesisName], [CompanyName], [MajorRule], [Description], [URL], [IsProject]) VALUES (3, 2, N'sas', N'asa', N'ssasa', N'sasas', N'asas', 0)
GO
INSERT [dbo].[RequiredJobSkills] ([JobID], [SkillID]) VALUES (1, 1)
GO
INSERT [dbo].[RequiredJobSkills] ([JobID], [SkillID]) VALUES (2, 1)
GO
INSERT [dbo].[RequiredJobSkills] ([JobID], [SkillID]) VALUES (1, 2)
GO
INSERT [dbo].[SkillInfo] ([SkillID], [SkillName]) VALUES (1, N'C#')
GO
INSERT [dbo].[SkillInfo] ([SkillID], [SkillName]) VALUES (2, N'SQL Server')
GO
INSERT [dbo].[StatusInfo] ([StatusCode], [Status]) VALUES (1, N'Joined')
GO
INSERT [dbo].[StatusInfo] ([StatusCode], [Status]) VALUES (2, N'Active')
GO
INSERT [dbo].[StatusInfo] ([StatusCode], [Status]) VALUES (3, N'Leave Job')
GO
INSERT [dbo].[StatusInfo] ([StatusCode], [Status]) VALUES (4, N'Rejected from written exam')
GO
INSERT [dbo].[StatusInfo] ([StatusCode], [Status]) VALUES (5, N'Rejected from technical viva')
GO
ALTER TABLE [dbo].[ApplicantInfo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicantInfo_dbo.ExpertiseInfo_ExpertiseCode] FOREIGN KEY([ExpertiseCode])
REFERENCES [dbo].[ExpertiseInfo] ([ExpertiseCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicantInfo] CHECK CONSTRAINT [FK_dbo.ApplicantInfo_dbo.ExpertiseInfo_ExpertiseCode]
GO
ALTER TABLE [dbo].[ApplicantInfo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicantInfo_dbo.StatusInfo_StatusCode] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[StatusInfo] ([StatusCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicantInfo] CHECK CONSTRAINT [FK_dbo.ApplicantInfo_dbo.StatusInfo_StatusCode]
GO
ALTER TABLE [dbo].[ApplicantSkillHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicantSkillHistory_dbo.ApplicantInfo_ApplicantID] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[ApplicantInfo] ([ApplicantID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicantSkillHistory] CHECK CONSTRAINT [FK_dbo.ApplicantSkillHistory_dbo.ApplicantInfo_ApplicantID]
GO
ALTER TABLE [dbo].[ApplicantSkillHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicantSkillHistory_dbo.SkillInfo_SkillID] FOREIGN KEY([SkillID])
REFERENCES [dbo].[SkillInfo] ([SkillID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicantSkillHistory] CHECK CONSTRAINT [FK_dbo.ApplicantSkillHistory_dbo.SkillInfo_SkillID]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CareerInfo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CareerInfo_dbo.ApplicantInfo_ApplicantID] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[ApplicantInfo] ([ApplicantID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CareerInfo] CHECK CONSTRAINT [FK_dbo.CareerInfo_dbo.ApplicantInfo_ApplicantID]
GO
ALTER TABLE [dbo].[EducationCriteria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EducationCriteria_dbo.InstituteInfo_InstituteID] FOREIGN KEY([InstituteID])
REFERENCES [dbo].[InstituteInfo] ([InstituteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EducationCriteria] CHECK CONSTRAINT [FK_dbo.EducationCriteria_dbo.InstituteInfo_InstituteID]
GO
ALTER TABLE [dbo].[EducationCriteria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EducationCriteria_dbo.JobDetails_JobID] FOREIGN KEY([JobID])
REFERENCES [dbo].[JobDetails] ([JobID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EducationCriteria] CHECK CONSTRAINT [FK_dbo.EducationCriteria_dbo.JobDetails_JobID]
GO
ALTER TABLE [dbo].[EducationHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EducationHistory_dbo.ApplicantInfo_ApplicantID] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[ApplicantInfo] ([ApplicantID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EducationHistory] CHECK CONSTRAINT [FK_dbo.EducationHistory_dbo.ApplicantInfo_ApplicantID]
GO
ALTER TABLE [dbo].[EducationHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EducationHistory_dbo.EducationInfo_EducationID] FOREIGN KEY([EducationID])
REFERENCES [dbo].[EducationInfo] ([EducationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EducationHistory] CHECK CONSTRAINT [FK_dbo.EducationHistory_dbo.EducationInfo_EducationID]
GO
ALTER TABLE [dbo].[EducationHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EducationHistory_dbo.InstituteInfo_InstituteID] FOREIGN KEY([InstituteID])
REFERENCES [dbo].[InstituteInfo] ([InstituteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EducationHistory] CHECK CONSTRAINT [FK_dbo.EducationHistory_dbo.InstituteInfo_InstituteID]
GO
ALTER TABLE [dbo].[ExamInfo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExamInfo_dbo.ApplicantInfo_ApplicantID] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[ApplicantInfo] ([ApplicantID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamInfo] CHECK CONSTRAINT [FK_dbo.ExamInfo_dbo.ApplicantInfo_ApplicantID]
GO
ALTER TABLE [dbo].[ExamInfo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExamInfo_dbo.ExamTypeInfo_ExamTypeID] FOREIGN KEY([ExamTypeID])
REFERENCES [dbo].[ExamTypeInfo] ([ExamTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamInfo] CHECK CONSTRAINT [FK_dbo.ExamInfo_dbo.ExamTypeInfo_ExamTypeID]
GO
ALTER TABLE [dbo].[ExamInfo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExamInfo_dbo.JobDetails_JobID] FOREIGN KEY([JobID])
REFERENCES [dbo].[JobDetails] ([JobID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamInfo] CHECK CONSTRAINT [FK_dbo.ExamInfo_dbo.JobDetails_JobID]
GO
ALTER TABLE [dbo].[ProjectThesisInfo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProjectThesisInfo_dbo.ApplicantInfo_ApplicantID] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[ApplicantInfo] ([ApplicantID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectThesisInfo] CHECK CONSTRAINT [FK_dbo.ProjectThesisInfo_dbo.ApplicantInfo_ApplicantID]
GO
ALTER TABLE [dbo].[RequiredJobSkills]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RequiredJobSkills_dbo.JobDetails_JobID] FOREIGN KEY([JobID])
REFERENCES [dbo].[JobDetails] ([JobID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequiredJobSkills] CHECK CONSTRAINT [FK_dbo.RequiredJobSkills_dbo.JobDetails_JobID]
GO
ALTER TABLE [dbo].[RequiredJobSkills]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RequiredJobSkills_dbo.SkillInfo_SkillID] FOREIGN KEY([SkillID])
REFERENCES [dbo].[SkillInfo] ([SkillID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequiredJobSkills] CHECK CONSTRAINT [FK_dbo.RequiredJobSkills_dbo.SkillInfo_SkillID]
GO
