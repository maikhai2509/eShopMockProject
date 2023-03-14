using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System;
using System.Collections.Generic;

namespace eShopSolution.Data.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Required]
        public int OrderID { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public string Address { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }
        public DateTime Date { get; set; }
        public bool Paided { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
        public int Deleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
