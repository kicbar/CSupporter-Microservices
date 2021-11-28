using System;
using System.ComponentModel.DataAnnotations;

namespace CSupporter.Services.Contractors.Models
{
    public class Contractor
    {
        [Key]
        public int ContractorId { get; set; }
        [Required]
        [Range(3, 150)]
        public string FirstName { get; set; }
        [Required]
        [Range(3, 150)]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        [Range(3, 300)]
        public string CompanyName { get; set; }
        public string CompanyDetails { get; set; }
        [RegularExpression(@"([0-9]{3})([0-9]{3})([0-9]{2})([0-9]{2})", ErrorMessage = "Error with NIP format.")]
        public string NIP { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
