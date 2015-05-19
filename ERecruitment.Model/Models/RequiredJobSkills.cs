using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class RequiredJobSkills
    {
        public RequiredJobSkills()
        {
 
        }
        [Key]
        [Column(Order = 1), ForeignKey("JobDetails")]
        public int JobID { get; set; }
        [Key]
        [Column(Order = 2), ForeignKey("SkillInfo")]
        public int SkillID { get; set; }

        public virtual JobDetails JobDetails { get; set; }
        public virtual SkillInfo SkillInfo { get; set; }
    }
}
