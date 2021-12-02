using System;
using System.ComponentModel.DataAnnotations;

namespace CSupporter.Services.Products.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [Required]
        public int Amount { get; set; }
        public string Unit { get; set; } = "ITEMS";
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public DateTime InsertDate { get; set; } = DateTime.Now;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
