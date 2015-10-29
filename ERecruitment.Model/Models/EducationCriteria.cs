using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class EducationCriteria
    {
        public EducationCriteria()
        {
 
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1), ForeignKey("JobDetails")]
        public int JobID { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2), ForeignKey("InstituteInfo")]
        public int InstituteID { get; set; }
        public virtual InstituteInfo InstituteInfo { get; set; }
        public virtual JobDetails JobDetails { get; set; }
    }
}
