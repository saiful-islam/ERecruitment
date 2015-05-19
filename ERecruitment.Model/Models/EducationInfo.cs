using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class EducationInfo
    {
        public EducationInfo()
        {
            this.EducationHistory = new HashSet<EducationHistory>();
        }
        [Key]
        public int EducationID { get; set; }
        [Required]
        public string EducationName { get; set; }

        public virtual ICollection<EducationHistory> EducationHistory { get; set; }
    }
}
