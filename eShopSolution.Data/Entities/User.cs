using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace eShopSolution.Data.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
        public int Role { get; set; }
        public string Avatar { get; set; }
        public bool Status { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Path_Img { get; set; }
        public bool VerifyEmail { get; set; }
        public bool VerifyContact { get; set; }
        public int Deleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(100)]
        public string VerifyToken { get; set; }
        public DateTime VerifyAt { get; set; }
        public List<Order> Orders { get; set; }

    }
}
