using System.ComponentModel.DataAnnotations;

namespace CSupporter.Services.Factures.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductAmount { get; set; } = 1;
        [Required]
        public double ProductPrice { get; set; }


        public virtual Facture Facture { get; set; }
        public int FactureId { get; set; }
    }
}
