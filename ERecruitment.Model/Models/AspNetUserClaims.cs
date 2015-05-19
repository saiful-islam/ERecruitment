using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ERecruitment.Model.Models
{
    public class AspNetUserClaims
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClaimType { get; set; }
        [Required]
        public string ClaimValue { get; set; }
        [Required]
        [ForeignKey("AspNetUsers")]
        public string User_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
