﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERecruitment.Model.Models
{
    public class InstituteInfo
    {
        public InstituteInfo()
        {
            this.EducationHistory = new HashSet<EducationHistory>();
            this.EducationCriteria = new HashSet<EducationCriteria>();
        }
        [Key]
        public int InstituteID { get; set; }
        [Required]
        public string InstituteName { get; set; }
        [Required]
        public bool IsPrivateUniversity { get; set; }
        [Required]
        public bool IsNationalUniversity { get; set; }

        public virtual ICollection<EducationHistory> EducationHistory { get; set; }
        public virtual ICollection<EducationCriteria> EducationCriteria { get; set; }
    }
}
