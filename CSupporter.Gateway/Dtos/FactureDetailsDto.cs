using System;
using System.Collections.Generic;

namespace CSupporter.Gateway.Dtos
{
    public class FactureDetailsDto
    {
        public int FactureId { get; set; }
        public string FactureNo { get; set; }
        public string FactureType { get; set; }
        public DateTime FactureDate { get; set; }
        public double FactureValue { get; set; }
        public string ContractorFirstName { get; set; }
        public string ContractorLastName { get; set; }
        public string ContractorAddress { get; set; }
        public string ContractorCompanyName { get; set; }
        public string ContractorNIP { get; set; }
        public List<PositionDto> Positions { get; set; }
    }
}
