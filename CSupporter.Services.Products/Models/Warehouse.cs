using System;

namespace CSupporter.Services.Products.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
