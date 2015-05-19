using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class ProjectThesisInfo
    {
        public ProjectThesisInfo()
        {
 
        }
        [Key]
        public int ProjectThesisID { get; set; }
        [Required]
        [ForeignKey("ApplicantInfo")]
        public int ApplicantID { get; set; }
        [Required]
        public string ProjectThesisName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string MajorRule { get; set; }
        [Required]
        public string Description { get; set; }
        public string URL { get; set; }
        [Required]
        public bool IsProject { get; set; }

        public virtual ApplicantInfo ApplicantInfo { get; set; }
    }
}
