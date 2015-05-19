using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class ApplicantSkillHistory
    {
        public ApplicantSkillHistory()
        {
 
        }
        [Key]
        [Column(Order = 1), ForeignKey("ApplicantInfo")]
        public int ApplicantID { get; set; }
        [Key]
        [Column(Order = 2), ForeignKey("SkillInfo")]
        public int SkillID { get; set; }
        public virtual ApplicantInfo ApplicantInfo { get; set; }
        public virtual SkillInfo SkillInfo { get; set; }
    }
}
