using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class EducationHistory
    {
        public EducationHistory()
        {
 
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1), ForeignKey("ApplicantInfo")]
        public int ApplicantID { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2), ForeignKey("EducationInfo")]
        public int EducationID { get; set; }
        [Required]
        public string Major { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 3), ForeignKey("InstituteInfo")]
        public int InstituteID { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public DateTime PassingYear { get; set; }
        [Required]
        public bool IsOldResultSystem { get; set; }

        public virtual ApplicantInfo ApplicantInfo { get; set; }
        public virtual EducationInfo EducationInfo { get; set; }
        public virtual InstituteInfo InstituteInfo { get; set; }
    }
}
