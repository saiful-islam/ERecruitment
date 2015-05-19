using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ERecruitment.Model.Models
{
    public class AspNetUserLogins
    {
        [Key]
        [Column(Order = 1), ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string LoginProvider { get; set; }
        [Key]
        [Column(Order = 3)]
        public string ProviderKey { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
