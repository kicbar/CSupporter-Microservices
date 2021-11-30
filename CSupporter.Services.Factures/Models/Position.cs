using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int FactureId { get; set; }
        [ForeignKey("FactureId")]
        public virtual Facture Facture { get; set; }
    }
}
