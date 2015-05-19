using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class ExpertiseInfo
    {
        public ExpertiseInfo()
        {
            this.ApplicantInfo = new HashSet<ApplicantInfo>();
        }
        [Key]
        public int ExpertiseCode { get; set; }
        [Required]
        public string ExpertiseName { get; set; }

        public virtual ICollection<ApplicantInfo> ApplicantInfo { get; set; }
    }
}
