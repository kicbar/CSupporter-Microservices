using System;

namespace CSupporter.Gateway.Dtos
{
    public class FactureDto
    {
        public int FactureId { get; set; }
        public string FactureNo { get; set; }
        public string FactureType { get; set; }
        public DateTime FactureDate { get; set; } = DateTime.Now;
        public double Value { get; set; }
        public int ContractorId { get; set; }
    }
}
