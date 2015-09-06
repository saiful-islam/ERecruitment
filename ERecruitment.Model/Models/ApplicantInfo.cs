using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class ApplicantInfo
    {
        public ApplicantInfo()
        {
            this.ApplicantSkillHistory = new HashSet<ApplicantSkillHistory>();
            this.EducationHistory = new HashSet<EducationHistory>();
            this.ExamInfo = new HashSet<ExamInfo>();
            this.CareerInfo = new HashSet<CareerInfo>();
            this.ProjectThesisInfo = new HashSet<ProjectThesisInfo>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicantID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MailingAddress { get; set; }
        [Required]
        [ForeignKey("StatusInfo")]
        public int StatusCode { get; set; }
        [Required]
        [ForeignKey("ExpertiseInfo")]
        public int ExpertiseCode { get; set; }

        public virtual ExpertiseInfo ExpertiseInfo { get; set; }
        public virtual StatusInfo StatusInfo { get; set; }
        public virtual ICollection<ApplicantSkillHistory> ApplicantSkillHistory { get; set; }
        public virtual ICollection<EducationHistory> EducationHistory { get; set; }
        public virtual ICollection<ExamInfo> ExamInfo { get; set; }
        public virtual ICollection<CareerInfo> CareerInfo { get; set; }
        public virtual ICollection<ProjectThesisInfo> ProjectThesisInfo { get; set; }
    }
}
