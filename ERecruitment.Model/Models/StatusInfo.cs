using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusCode { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("ExamTypeInfo")]
        public int? ExamTypeID { get; set; }

        public virtual ICollection<ApplicantInfo> ApplicantInfo { get; set; }
        public virtual ExamTypeInfo ExamTypeInfo { get; set; }
    }
}
