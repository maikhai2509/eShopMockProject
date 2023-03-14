using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace eShopSolution.Data.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public float DiscountPercent { get; set; }

        public int ViewCount { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Category { get; set; }
        public int StockQuantity { get; set; }
        public int Rating { get; set; }

        [StringLength(50)]
        public string Path_Img { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        public int Deleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public List<OrderDetail> orderDetails { get; set; }    
    }
}
