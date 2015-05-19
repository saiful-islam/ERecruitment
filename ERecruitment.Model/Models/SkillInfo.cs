using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class SkillInfo
    {
        public SkillInfo()
        {
            this.ApplicantSkillHistory = new HashSet<ApplicantSkillHistory>();
            this.RequiredJobSkills = new HashSet<RequiredJobSkills>();
        }
        [Key]
        public int SkillID { get; set; }
        [Required]
        public string SkillName { get; set; }

        public virtual ICollection<ApplicantSkillHistory> ApplicantSkillHistory { get; set; }
        public virtual ICollection<RequiredJobSkills> RequiredJobSkills { get; set; }
    }
}
