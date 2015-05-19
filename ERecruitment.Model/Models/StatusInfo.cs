using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class StatusInfo
    {
        public StatusInfo()
        {
            this.ApplicantInfo = new HashSet<ApplicantInfo>();
        }
        [Key]
        public int StatusCode { get; set; }
        [Required]
        public string Status { get; set; }

        public virtual ICollection<ApplicantInfo> ApplicantInfo { get; set; }
    }
}
