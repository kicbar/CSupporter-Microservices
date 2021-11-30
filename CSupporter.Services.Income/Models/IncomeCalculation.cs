using System;
using System.ComponentModel.DataAnnotations;

namespace CSupporter.Services.Income.Models
{
    public class IncomeCalculation
    {
        public int CalculateId { get; set; }
        [Required]
        public double CalculateValue { get; set; }
        public DateTime CalculateDate { get; set; } = DateTime.Now;
    }
}
