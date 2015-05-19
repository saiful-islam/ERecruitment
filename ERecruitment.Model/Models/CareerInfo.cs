using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class CareerInfo
    {
        public CareerInfo()
        {
            
        }
        [Key]
        public int CareerID { get; set; }
        [Required]
        [ForeignKey("ApplicantInfo")]
        public int ApplicantID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        [Required]
        public DateTime LeaveDate { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ApplicantInfo ApplicantInfo { get; set; }
    }
}
