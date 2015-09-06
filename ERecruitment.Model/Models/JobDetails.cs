using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class JobDetails
    {
        public JobDetails()
        {
            this.RequiredJobSkills = new HashSet<RequiredJobSkills>();
            this.EducationCriteria = new HashSet<EducationCriteria>();
            this.ExamInfo = new HashSet<ExamInfo>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobID { get; set; }
        [Required]
        public string JobName { get; set; }
        [Required]
        public string UserID { get; set; }
        public float MinimumExperiance { get; set; }
        public float MaximumExperiance { get; set; }
        [Required]
        public DateTime SubmissionDeadline { get; set; }

        public virtual ICollection<RequiredJobSkills> RequiredJobSkills { get; set; }
        public virtual ICollection<EducationCriteria> EducationCriteria { get; set; }
        public virtual ICollection<ExamInfo> ExamInfo { get; set; }
    }
}
