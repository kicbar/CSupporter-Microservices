using System;
using System.ComponentModel.DataAnnotations;

namespace CSupporter.Services.Factures.Models
{
    public class Facture
    {
        [Key]
        public int FactureId { get; set; }
        [Required]
        public string FactureNo { get; set; }
        [Required]
        public DateTime FactureDate { get; set; } = DateTime.Now;
        [Required]
        [Range(1, 1000)]
        public double Value { get; set; }
        [Required]
        public int ContractorId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
