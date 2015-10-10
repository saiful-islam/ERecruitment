using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class SectionInfo
    {
        public SectionInfo()
        {
            this.JobDetails = new HashSet<JobDetails>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SectionId { get; set; }
        [Required]
        public string SectionName { get; set; }
        public virtual ICollection<JobDetails> JobDetails { get; set; }
    }
}
