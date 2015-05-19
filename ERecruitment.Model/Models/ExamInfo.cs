using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class ExamInfo
    {
        public ExamInfo()
        {
 
        }
        [Key]
        [Column(Order = 1), ForeignKey("ApplicantInfo")]
        public int ApplicantID { get; set; }
        [Key]
        [Column(Order = 2), ForeignKey("JobDetails")]
        public int JobID { get; set; }
        [Key]
        [Column(Order = 3), ForeignKey("ExamTypeInfo")]
        public int ExamTypeID { get; set; }
        [Required]
        public DateTime ExamDate { get; set; }
        [Required]
        public float Marks { get; set; }
        [Required]
        public bool IsRejected { get; set; }

        public virtual ApplicantInfo ApplicantInfo { get; set; }
        public virtual JobDetails JobDetails { get; set; }
        public virtual ExamTypeInfo ExamTypeInfo { get; set; }
    }
}
