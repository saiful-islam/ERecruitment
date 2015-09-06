using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkillID { get; set; }
        [Required]
        public string SkillName { get; set; }

        public virtual ICollection<ApplicantSkillHistory> ApplicantSkillHistory { get; set; }
        public virtual ICollection<RequiredJobSkills> RequiredJobSkills { get; set; }
    }
}
