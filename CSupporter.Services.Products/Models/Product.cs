using System.ComponentModel.DataAnnotations;

namespace CSupporter.Services.Products.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        public string Details { get; set; }
        public string Description { get; set; }

        public virtual Warehouse WarehouseAmounts { get; set; }
    }
}
