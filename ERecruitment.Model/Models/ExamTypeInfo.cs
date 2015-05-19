using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class ExamTypeInfo
    {
        public ExamTypeInfo()
        {
            this.ExamInfo = new HashSet<ExamInfo>();
        }
        [Key]
        public int ExamTypeID { get; set; }
        [Required]
        public string ExamType { get; set; }

        public virtual ICollection<ExamInfo> ExamInfo { get; set; }
    }
}
