using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;


namespace eShopSolution.Data.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Required]
        public int OrderDetailID { get; set; }

        public int? OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }

        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public bool Paided { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
        public int Deleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
